from os.path import commonprefix
from re import Match, sub
from style import camel, pascal, preprocess
from typing import Any, Iterable

class GDExtensionInterface:
    def __init__(self, data: dict[str, Any]) -> None:
        self.copyright: list[str] = data["_copyright"]
        self.types: list[GDExtensionType] = []
        self.interface: list[GDExtensionInterfaceFunction] = []
        self.symbols: GDExtensionSymbolTable = GDExtensionSymbolTable()
        for type_data in data["types"]:
            instance: GDExtensionType | None = None
            match type_data["kind"]:
                case "enum":
                    instance = GDExtensionEnum(type_data)
                case "handle":
                    instance = GDExtensionHandle(type_data)
                case "alias":
                    instance = GDExtensionAlias(type_data)
                case "struct":
                    instance = GDExtensionStruct(type_data)
                case "function":
                    instance = GDExtensionFunction(type_data)
            assert instance
            self.types.append(instance)
            self.symbols.register(instance)
            instance.stylize(self.symbols)
        for function_data in data["interface"]:
            function: GDExtensionInterfaceFunction = GDExtensionInterfaceFunction(function_data)
            self.interface.append(function)
            self.symbols.register(function)
            function.stylize(self.symbols)

    def definition(self) -> Iterable[str]:
        yield "using System;\n"
        yield "using System.Diagnostics.CodeAnalysis;\n"
        yield "using System.Runtime.CompilerServices;\n"
        yield "\n"
        yield "namespace Godot.Interop;\n"
        yield "\n"
        yield "public static unsafe class GDExtensionInterface\n"
        yield "{\n"
        for function in self.interface:
            yield f"    private static {function.expand(self.symbols)} {function.field};\n"
        yield "\n"
        yield "    /// <summary>\n"
        yield "    /// Loads the GDExtensionInterface functions from the specified address loader.\n"
        yield "    /// </summary>\n"
        yield "    /// <param name=\"pGetProcAddress\">\n"
        yield "    /// The address loader provided by the Godot Engine.\n"
        yield "    /// </param>\n"
        yield "    /// <exception cref=\"ArgumentNullException\">\n"
        yield "    /// <paramref name=\"pGetProcAddress\"/> is <see langword=\"null\"/>.\n"
        yield "    /// </exception>\n"
        yield "    public static void Initialize(delegate* unmanaged[Cdecl]<byte*, void*> pGetProcAddress)\n"
        yield "    {\n"
        yield "        ArgumentNullException.ThrowIfNull(pGetProcAddress);\n"
        for function in self.interface:
            yield f"        {function.field} = ({function.expand(self.symbols)})Load(pGetProcAddress, \"{function.name}\"u8);\n"
        yield "    }\n"
        for function in self.interface:
            yield "\n"
            yield from function.definition(self.symbols)
        yield "\n"
        yield "    private static void* Load(delegate* unmanaged[Cdecl]<byte*, void*> pGetProcAddress, ReadOnlySpan<byte> pFunctionName)\n"
        yield "    {\n"
        yield "        fixed (byte* functionName = pFunctionName)\n"
        yield "        {\n"
        yield "            return pGetProcAddress(functionName);\n"
        yield "        }\n"
        yield "    }\n"
        yield "\n"
        yield "    private static void ThrowIfInvalid(void* pFunction)\n"
        yield "    {\n"
        yield "        if (pFunction == null)\n"
        yield "        {\n"
        yield "            ThrowForInvalidFunction();\n"
        yield "        }\n"
        yield "    }\n"
        yield "\n"
        yield "    [DoesNotReturn]\n"
        yield "    private static void ThrowForInvalidFunction()\n"
        yield "    {\n"
        yield "        throw new InvalidOperationException(\"Unable to call the specified function.\");\n"
        yield "    }\n"
        yield "}\n"

    def generate(self) -> None:
        def dump(name: str, definition: Iterable[str]) -> None:
            with open(f"../Source/Interop/{name}.cs", "w") as file:
                file.write("/**************************************************************************/\n")
                file.write(f"/*  {name}.cs  {" " * (65 - len(name))}*/\n")
                for line in self.copyright:
                    file.write(f"{line}\n")
                file.write("\n")
                file.writelines(definition)

        for instance in self.types:
            if isinstance(instance, (GDExtensionEnum, GDExtensionStruct)):
                dump(instance.name, instance.definition(self.symbols))
        dump("GDExtensionInterface", self.definition())

class GDExtensionSymbolTable:
    def __init__(self) -> None:
        self.expansions: dict[str, str] = {
            "void" : "void",
            "int8_t" : "sbyte",
            "uint8_t" : "byte",
            "int16_t" : "short",
            "uint16_t" : "ushort",
            "int32_t" : "int",
            "uint32_t" : "uint",
            "int64_t" : "long",
            "uint64_t" : "ulong",
            "size_t" : "nuint",
            "char" : "byte",
            "char16_t" : "char",
            "char32_t" : "uint",
            "wchar_t" : "void",
            "float" : "float",
            "double" : "double",
            "GDExtensionStringPtr" : "GDExtensionString*",
            "GDExtensionConstStringPtr" : "GDExtensionString*",
            "GDExtensionUninitializedStringPtr" : "GDExtensionString*",
            "GDExtensionStringNamePtr" : "GDExtensionStringName*",
            "GDExtensionConstStringNamePtr" : "GDExtensionStringName*",
            "GDExtensionUninitializedStringNamePtr" : "GDExtensionStringName*",
            "GDExtensionVariantPtr" : "GDExtensionVariant*",
            "GDExtensionConstVariantPtr" : "GDExtensionVariant*",
            "GDExtensionUninitializedVariantPtr" : "GDExtensionVariant*",
            "GDExtensionBool" : "bool",
            "GDExtensionInterfaceFunctionPtr" : "void*"
        }
        self.substitutions: dict[str, str] = {"NULL" : "null"}
        self.types: dict[str, GDExtensionType] = {}

    def expand(self, symbol: str) -> str:
        key: str = symbol.removeprefix("const ").removesuffix("*")
        value: str = self.expansions.get(key, "")
        if not value:
            instance: GDExtensionType = self.types[key]
            value = instance.expand(self)
            self.expansions[key] = value
        return f"{value}*" if symbol.endswith("*") else value

    def register(self, instance: GDExtensionType) -> None:
        self.types[instance.name] = instance

    def replace(self, symbol: str, replacement: str) -> None:
        self.substitutions[symbol] = replacement

    def stylize(self, text: str) -> str:
        def substitute(match: Match[str]) -> str:
            group: str = match.group()
            target: str = group
            if target.startswith("`") and target.endswith("`"):
                target = match.group(1)
            substitution: str = self.substitutions.get(target, target)
            return group.replace(target, substitution)

        result: str = self.substitutions.get(text, "")
        if result:
            return result
        return sub(r"`(\w+)`|([A-Z]{4,}+(_[A-Z]+)*)|([a-z]+(_[a-z]+)+)", substitute, text)

class GDExtensionDescription:
    def __init__(self, lines: list[str], tag: str = "summary", name: str = "") -> None:
        self.lines: list[str] = lines
        self.tag: str = tag
        self.name: str = name

    def documentation(self, symbols: GDExtensionSymbolTable, indent: bool = False) -> Iterable[str]:
        spacing: str = "    " if indent else ""
        metadata: str = f" name=\"{symbols.stylize(self.name)}\"" if self.name else ""
        yield f"{spacing}/// <{self.tag}{metadata}>\n"
        for line in self.lines[:-1]:
            yield f"{spacing}/// {symbols.stylize(line)}<br/>\n"
        yield f"{spacing}/// {symbols.stylize(self.lines[-1])}\n"
        yield f"{spacing}/// </{self.tag}>\n"

class GDExtensionDeprecated:
    def __init__(self, data: dict[str, Any]) -> None:
        self.since: str = data["since"]
        self.message: str | None = data.get("message")
        self.replace_with: str | None = data.get("replace_with")

    def attribute(self, symbols: GDExtensionSymbolTable, indent: bool = False) -> str:
        spacing: str = "    " if indent else ""
        message: str = f" {self.message}" if self.message else ""
        replace_with: str = f" Use {symbols.stylize(self.replace_with)} instead." if self.replace_with else ""
        return f"{spacing}[Obsolete(\"Deprecated since Godot {self.since}.{message}{replace_with}\")]\n"

class GDExtensionType:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.description: GDExtensionDescription | None = None
        self.deprecated: GDExtensionDeprecated | None = None
        description: list[str] | None = data.get("description")
        deprecated: dict[str, Any] | None = data.get("deprecated")
        if description:
            self.description = GDExtensionDescription(description)
        if deprecated:
            self.deprecated = GDExtensionDeprecated(deprecated)

    def definition(self, symbols: GDExtensionSymbolTable) -> Iterable[str]:
        pass

    def expand(self, symbols: GDExtensionSymbolTable) -> str:
        return self.name

    def stylize(self, symbols: GDExtensionSymbolTable) -> None:
        pass

class GDExtensionEnum(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.is_bitfield: bool = data.get("is_bitfield") or False
        self.values: list[GDExtensionEnumValue] = [
            GDExtensionEnumValue(value_data) for value_data in data["values"]
        ]

    def definition(self, symbols: GDExtensionSymbolTable) -> Iterable[str]:
        if self.deprecated or self.is_bitfield:
            yield "using System;\n"
            yield "\n"
        yield "namespace Godot.Interop;\n"
        yield "\n"
        if self.description:
            yield from self.description.documentation(symbols)
        if self.deprecated:
            yield self.deprecated.attribute(symbols)
        if self.is_bitfield:
            yield "[Flags]\n"
            yield f"public enum {self.name} : uint\n"
        else:
            yield f"public enum {self.name}\n"
        yield "{\n"
        end: int = len(self.values) - 1
        for i, value in enumerate(self.values):
            separator: str = "," if i < end else ""
            if value.description:
                yield from value.description.documentation(symbols, indent=True)
            yield f"    {symbols.stylize(value.name)} = {value.value}{separator}\n"
        yield "}\n"

    def stylize(self, symbols: GDExtensionSymbolTable) -> None:
        prefix: str = commonprefix([value.name for value in self.values])
        for value in self.values:
            replacement: str = pascal(value.name.removeprefix(prefix))
            if "Max" in replacement:
                replacement = "Max"
            else:
                replacement = replacement.removeprefix("Error") \
                    .removeprefix("Initialization") \
                    .replace("SDefault", "Default", 1) \
                    .replace("Uint", "UInt", 1)
            symbols.replace(value.name, replacement)

class GDExtensionEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description)

class GDExtensionHandle(GDExtensionType):
    def expand(self, symbols: GDExtensionSymbolTable) -> str:
        return "void*"

class GDExtensionAlias(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.type: str = data["type"]

    def expand(self, symbols: GDExtensionSymbolTable) -> str:
        return symbols.expand(self.type)

class GDExtensionStruct(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.members: list[GDExtensionStructMember] = [
            GDExtensionStructMember(member_data) for member_data in data["members"]
        ]

    def definition(self, symbols: GDExtensionSymbolTable) -> Iterable[str]:
        if self.deprecated:
            yield "using System;\n"
        yield "using System.Runtime.InteropServices;\n"
        yield "\n"
        yield "namespace Godot.Interop;\n"
        yield "\n"
        if self.description:
            yield from self.description.documentation(symbols)
        if self.deprecated:
            yield self.deprecated.attribute(symbols)
        yield "[StructLayout(LayoutKind.Sequential)]\n"
        if self.name == "GDExtensionCallError":
            yield "public struct GDExtensionCallError\n"
        else:
            yield f"public unsafe struct {self.name}\n"
        yield "{\n"
        for member in self.members:
            if member.description:
                yield from member.description.documentation(symbols, indent=True)
            yield f"    public {symbols.expand(member.type)} {symbols.stylize(member.name)};\n"
        yield "}\n"

    def stylize(self, symbols: GDExtensionSymbolTable) -> None:
        for member in self.members:
            replacement: str = preprocess(member.name)
            symbols.replace(member.name, pascal(replacement))

class GDExtensionStructMember:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.description: GDExtensionDescription | None = None
        if self.name == "method_flags":
            self.type = "GDExtensionClassMethodFlags"
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description)

class GDExtensionFunction(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.arguments: list[GDExtensionFunctionArgument] = []
        self.return_value: GDExtensionFunctionReturnValue | None = None
        for argument in data["arguments"]:
            self.arguments.append(GDExtensionFunctionArgument(argument))
        return_value: dict[str, Any] | None = data.get("return_value")
        if return_value:
            self.return_value: GDExtensionFunctionReturnValue = GDExtensionFunctionReturnValue(return_value)

    def expand(self, symbols: GDExtensionSymbolTable) -> str:
        type_parameters: list[str] = []
        for argument in self.arguments:
            type_parameters.append(symbols.expand(argument.type))
        if self.return_value:
            type_parameters.append(symbols.expand(self.return_value.type))
        else:
            type_parameters.append("void")
        return f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"

class GDExtensionFunctionArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data.get("name", "")
        self.type: str = data["type"]
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description, tag="param", name=self.name)

class GDExtensionFunctionReturnValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.type: str = data["type"]
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description, tag="returns")

class GDExtensionInterfaceFunction(GDExtensionFunction):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.field: str = preprocess(self.name)
        self.field = f"s_{camel(self.field)}"

    def definition(self, symbols: GDExtensionSymbolTable) -> Iterable[str]:
        parameters: str = ", ".join(f"{symbols.expand(argument.type)} {symbols.stylize(argument.name)}" for argument in self.arguments)
        arguments: str = ", ".join(symbols.stylize(argument.name) for argument in self.arguments)
        if self.description:
            yield from self.description.documentation(symbols, indent=True)
        for argument in self.arguments:
            if argument.description:
                yield from argument.description.documentation(symbols, indent=True)
        if self.return_value and self.return_value.description:
            yield from self.return_value.description.documentation(symbols, indent=True)
        if self.deprecated:
            yield self.deprecated.attribute(symbols, indent=True)
        yield "    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n"
        if self.return_value:
            yield f"    public static {symbols.expand(self.return_value.type)} {symbols.stylize(self.name)}({parameters})\n"
            yield "    {\n"
            yield f"        {self.expand(symbols)} function = {self.field};\n"
            yield "        ThrowIfInvalid(function);\n"
            yield f"        return function({arguments});\n"
            yield "    }\n"
        else:
            yield f"    public static void {symbols.stylize(self.name)}({parameters})\n"
            yield "    {\n"
            yield f"        {self.expand(symbols)} function = {self.field};\n"
            yield "        ThrowIfInvalid(function);\n"
            yield f"        function({arguments});\n"
            yield "    }\n"

    def stylize(self, symbols: GDExtensionSymbolTable) -> None:
        replacement: str = preprocess(self.name)
        symbols.replace(self.name, pascal(replacement))
        for argument in self.arguments:
            replacement: str = preprocess(argument.name)
            symbols.replace(argument.name, camel(replacement))
