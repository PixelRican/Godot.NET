from os.path import commonprefix
from re import Match, sub
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
            function.stylize(self.symbols)
            self.interface.append(function)

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
            yield f"    private static {function.type} {function.field};\n"
        yield "\n"
        yield "    /// <summary>\n"
        yield "    /// Loads the GDExtensionInterface functions from the specified address loader.\n"
        yield "    /// </summary>\n"
        yield "    /// <param name=\"getProcAddress\">\n"
        yield "    /// The address loader provided by the Godot Engine.\n"
        yield "    /// </param>\n"
        yield "    /// <exception cref=\"ArgumentNullException\">\n"
        yield "    /// <paramref name=\"getProcAddress\"/> is <see langword=\"null\"/>.\n"
        yield "    /// </exception>\n"
        yield "    public static void Initialize(GDExtensionInterfaceGetProcAddress getProcAddress)\n"
        yield "    {\n"
        yield "        ArgumentNullException.ThrowIfNull(getProcAddress);\n"
        for function in self.interface:
            yield f"        {function.field} = ({function.type})Load(getProcAddress, \"{function.name}\"u8);\n"
        yield "    }\n"
        for function in self.interface:
            yield "\n"
            yield from function.definition(self.symbols)
        yield "\n"
        yield "    private static GDExtensionInterfaceFunctionPtr Load(GDExtensionInterfaceGetProcAddress getProcAddress, ReadOnlySpan<byte> functionName)\n"
        yield "    {\n"
        yield "        fixed (byte* pFunctionName = functionName)\n"
        yield "        {\n"
        yield "            return getProcAddress(pFunctionName);\n"
        yield "        }\n"
        yield "    }\n"
        yield "\n"
        yield "    private static void ThrowIfInvalid(void* function)\n"
        yield "    {\n"
        yield "        if (function == null)\n"
        yield "        {\n"
        yield "            Throw();\n"
        yield "        }\n"
        yield "\n"
        yield "        [DoesNotReturn]\n"
        yield "        static void Throw()\n"
        yield "        {\n"
        yield "            throw new InvalidOperationException(\"The specified function could not be loaded.\");\n"
        yield "        }\n"
        yield "    }\n"
        yield "}\n"

    def generate(self) -> None:
        with open("../Source/Godot.Interop/GlobalUsings.cs", "w") as file:
            file.writelines(self.header("GlobalUsings"))
            file.write("\n")
            file.write("#if REAL_T_IS_DOUBLE\n")
            file.write("global using real_t = double;\n")
            file.write("#else\n")
            file.write("global using real_t = float;\n")
            file.write("#endif\n")
            file.write("\n")
        for instance in self.types:
            definition: Iterable[str] = instance.definition(self.symbols)
            match instance:
                case GDExtensionEnum() | GDExtensionStruct():
                    with open(f"../Source/Godot.Interop/{instance.name}.cs", "w") as file:
                        file.writelines(self.header(instance.name))
                        file.write("\n")
                        file.writelines(definition)
                case _:
                    with open("../Source/Godot.Interop/GlobalUsings.cs", "a") as file:
                        file.writelines(definition)
        with open("../Source/Godot.Interop/GDExtensionInterface.cs", "w") as file:
            file.writelines(self.header("GDExtensionInterface"))
            file.write("\n")
            file.writelines(self.definition())

    def header(self, name: str) -> Iterable[str]:
        yield "/**************************************************************************/\n"
        yield f"/*  {name}.cs  {" " * (65 - len(name))}*/\n"
        for line in self.copyright:
            yield f"{line}\n"

class GDExtensionSymbolTable:
    def __init__(self) -> None:
        self.expansions: dict[str, str] = {}
        self.substitutions: dict[str, str] = {}
        self.types: dict[str, GDExtensionType] = {}

    def expand(self, symbol: str) -> str:
        expansion: str = self.expansions.get(symbol, "")
        if expansion:
            return expansion
        split: int = len(symbol) - symbol.endswith("*")
        instance: GDExtensionType | None = self.types.get(symbol[:split])
        expansion = instance.expand(self) + symbol[split:] if instance else symbol
        self.expansions[symbol] = expansion
        return expansion

    def register(self, instance: GDExtensionType) -> None:
        self.types[instance.name] = instance

    def replace(self, symbol: str, replacement: str) -> None:
        self.substitutions[symbol] = replacement

    def substitute(self, match: Match[str]) -> str:
        group: str = match.group(1)
        substitution: str = self.substitutions.get(group, group)
        return match.group().replace(group, substitution, 1)

    def transform(self, text: str) -> str:
        result: str = self.substitutions.get(text, "")
        if result:
            return result
        return sub(r"`(\w+)`", self.substitute, text.replace("NULL", "null"))

    def unsafe(self, symbol: str) -> bool:
        return symbol.endswith("*") \
            or isinstance(self.types.get(symbol), (GDExtensionHandle, GDExtensionFunction))

class GDExtensionDescription:
    def __init__(self, lines: list[str], tag: str = "summary", name: str = "") -> None:
        self.lines: list[str] = lines
        self.tag: str = tag
        self.name: str = name

    def documentation(self, symbols: GDExtensionSymbolTable, indent: bool = False) -> Iterable[str]:
        spacing: str = "    " if indent else ""
        metadata: str = f" name=\"{symbols.transform(self.name)}\"" if self.name else ""
        yield f"{spacing}/// <{self.tag}{metadata}>\n"
        for line in self.lines[:-1]:
            yield f"{spacing}/// {symbols.transform(line)}<br/>\n"
        yield f"{spacing}/// {symbols.transform(self.lines[-1])}\n"
        yield f"{spacing}/// </{self.tag}>\n"

class GDExtensionDeprecated:
    def __init__(self, data: dict[str, Any]) -> None:
        self.since: str = data["since"]
        self.message: str | None = data.get("message")
        self.replace_with: str | None = data.get("replace_with")

    def attribute(self, symbols: GDExtensionSymbolTable, indent: bool = False) -> str:
        spacing: str = "    " if indent else ""
        message: str = f" {self.message}" if self.message else ""
        replace_with: str = f" Use {symbols.transform(self.replace_with)} instead." if self.replace_with else ""
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
        raise NotImplementedError()

    def expand(self, symbols: GDExtensionSymbolTable) -> str:
        raise NotImplementedError()

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
        for value in self.values[:-1]:
            if value.description:
                yield from value.description.documentation(symbols, indent=True)
            yield f"    {symbols.transform(value.name)} = {value.value},\n"
        value: GDExtensionEnumValue = self.values[-1]
        if value.description:
            yield from value.description.documentation(symbols, indent=True)
        yield f"    {symbols.transform(value.name)} = {value.value}\n"
        yield "}\n"

    def expand(self, symbols: GDExtensionSymbolTable) -> str:
        return f"Godot.Interop.{self.name}"

    def stylize(self, symbols: GDExtensionSymbolTable) -> None:
        prefix: str = commonprefix([value.name for value in self.values])
        for value in self.values:
            if "MAX" in value.name:
                symbols.replace(value.name, "Max")
                continue
            words: list[str] = value.name.removeprefix(prefix).split("_")
            if words[0] == "ERROR" or len(words[0]) == 1:
                words.pop(0)
            if "INITIALIZATION" in words:
                words.remove("INITIALIZATION")
            for i, word in enumerate(words):
                if word.startswith("UINT"):
                    words[i] = "UInt" + word[4:]
                else:
                    words[i] = word.title()
            symbols.replace(value.name, "".join(words))

class GDExtensionEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description)

class GDExtensionHandle(GDExtensionType):
    def definition(self, symbols: GDExtensionSymbolTable) -> Iterable[str]:
        yield f"global using unsafe {self.name} = void*;\n"

    def expand(self, symbols: GDExtensionSymbolTable) -> str:
        return "void*"

class GDExtensionAlias(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.type: str = translate(data["type"])
        if self.name.endswith("Bool"):
            self.type = "bool"

    def definition(self, symbols: GDExtensionSymbolTable) -> Iterable[str]:
        yield f"global using {self.name} = {symbols.expand(self.name)};\n"

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
        yield f"public struct {self.name}\n"
        yield "{\n"
        for member in self.members:
            if member.description:
                yield from member.description.documentation(symbols, indent=True)
            unsafe: str = "unsafe " * symbols.unsafe(member.type)
            yield f"    public {unsafe}{member.type} {symbols.transform(member.name)};\n"
        yield "}\n"

    def expand(self, symbols: GDExtensionSymbolTable) -> str:
        return f"Godot.Interop.{self.name}"

    def stylize(self, symbols: GDExtensionSymbolTable) -> None:
        for member in self.members:
            replacement: str = preprocess(member.name)
            symbols.replace(member.name, pascal(replacement))

class GDExtensionStructMember:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = translate(data["type"])
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

    def definition(self, symbols: GDExtensionSymbolTable) -> Iterable[str]:
        yield f"global using unsafe {self.name} = {symbols.expand(self.name)};\n"

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
        self.type: str = translate(data["type"])
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description, tag="param", name=self.name)

class GDExtensionFunctionReturnValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.type: str = translate(data["type"])
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description, tag="returns")

class GDExtensionInterfaceFunction(GDExtensionFunction):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        type_parameters: list[str] = []
        for argument in self.arguments:
            type_parameters.append(argument.type)
        if self.return_value:
            type_parameters.append(self.return_value.type)
        else:
            type_parameters.append("void")
        self.type: str = f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"
        self.field: str = preprocess(self.name)
        self.field = f"s_{camel(self.field)}"

    def definition(self, symbols: GDExtensionSymbolTable) -> Iterable[str]:
        parameters: str = ", ".join(f"{argument.type} {symbols.transform(argument.name)}" for argument in self.arguments)
        arguments: str = ", ".join(symbols.transform(argument.name) for argument in self.arguments)
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
            yield f"    public static {self.return_value.type} {symbols.transform(self.name)}({parameters})\n"
            yield "    {\n"
            yield f"        {self.type} function = {self.field};\n"
            yield "        ThrowIfInvalid(function);\n"
            yield f"        return function({arguments});\n"
            yield "    }\n"
        else:
            yield f"    public static void {symbols.transform(self.name)}({parameters})\n"
            yield "    {\n"
            yield f"        {self.type} function = {self.field};\n"
            yield "        ThrowIfInvalid(function);\n"
            yield f"        function({arguments});\n"
            yield "    }\n"

    def stylize(self, symbols: GDExtensionSymbolTable) -> None:
        replacement: str = preprocess(self.name)
        symbols.replace(self.name, pascal(replacement))
        for argument in self.arguments:
            replacement: str = preprocess(argument.name)
            symbols.replace(argument.name, camel(replacement))

def camel(symbol: str) -> str:
    return symbol[0].lower() + pascal(symbol)[1:]

def pascal(symbol: str) -> str:
    return symbol.title().replace("_", "")

def preprocess(symbol: str) -> str:
    return symbol.replace("ptrcall", "ptr_call") \
        .replace("refcount", "ref_count") \
        .replace("userdata", "user_data") \
        .replace("classdb", "class_d_b") \
        .replace("classname", "class_name") \
        .replace("methodname", "method_name")

def translate(symbol: str) -> str:
    name: str = symbol.removeprefix("const ").removesuffix("*")
    match name:
        case "int8_t":
            name = "sbyte"
        case "uint8_t":
            name = "byte"
        case "int16_t":
            name = "short"
        case "uint16_t":
            name = "ushort"
        case "int32_t":
            name = "int"
        case "uint32_t":
            name = "uint"
        case "int64_t":
            name = "long"
        case "uint64_t":
            name = "ulong"
        case "size_t":
            name = "nuint"
        case "char":
            name = "byte"
        case "char16_t":
            name = "char"
        case "char32_t":
            name = "uint"
        case "wchar_t":
            name = "void"
    return f"{name}*" if symbol.endswith("*") else name
