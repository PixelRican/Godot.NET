from typing import Any, Iterable

class GDExtensionInterface:
    def __init__(self, data: dict[str, Any]) -> None:
        self.copyright: list[str] = data["_copyright"]
        self.types: dict[str, GDExtensionType] = {}
        self.interface: dict[str, GDExtensionInterfaceFunction] = {}
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
            self.types[instance.name] = instance
        for function_data in data["interface"]:
            function: GDExtensionInterfaceFunction = GDExtensionInterfaceFunction(function_data)
            self.interface[function.name] = function

    def definition(self) -> Iterable[str]:
        yield "using System;\n"
        yield "using System.Diagnostics.CodeAnalysis;\n"
        yield "using System.Runtime.CompilerServices;\n"
        yield "\n"
        yield "namespace Godot.GDExtension;\n"
        yield "\n"
        yield "public static unsafe class GDExtensionInterface\n"
        yield "{\n"
        for function in self.interface.values():
            yield f"    private static {function.type} s_{function.name};\n"
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
        for function in self.interface.values():
            yield f"        s_{function.name} = ({function.type})Load(getProcAddress, \"{function.name}\"u8);\n"
        yield "    }\n"
        for function in self.interface.values():
            parameters: str = ", ".join(f"{argument.type} {argument.name}" for argument in function.arguments)
            arguments: str = ", ".join(argument.name for argument in function.arguments)
            yield "\n"
            if function.description:
                yield from function.description.documentation(indent=True)
            for argument in function.arguments:
                if argument.description:
                    yield from argument.description.documentation(indent=True)
            if function.return_value and function.return_value.description:
                yield from function.return_value.description.documentation(indent=True)
            if function.deprecated:
                yield function.deprecated.attribute(indent=True)
            yield "    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n"
            if function.return_value:
                yield f"    public static {function.return_value.type} {function.name}({parameters})\n"
                yield "    {\n"
                yield f"        var function = s_{function.name};\n"
                yield "        ThrowIfInvalid(function);\n"
                yield f"        return function({arguments});\n"
                yield "    }\n"
            else:
                yield f"    public static void {function.name}({parameters})\n"
                yield "    {\n"
                yield f"        var function = s_{function.name};\n"
                yield "        ThrowIfInvalid(function);\n"
                yield f"        function({arguments});\n"
                yield "    }\n"
        yield "\n"
        yield "    private static GDExtensionInterfaceFunctionPtr Load(GDExtensionInterfaceGetProcAddress getProcAddress, ReadOnlySpan<byte> functionName)\n"
        yield "    {\n"
        yield "        fixed (byte* p_function_name = functionName)\n"
        yield "        {\n"
        yield "            return getProcAddress(p_function_name);\n"
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
        with open("../Source/Godot.GDExtension/GlobalUsings.cs", "w") as file:
            file.writelines(self.header("GlobalUsings"))
            file.write("\n")
        for instance in self.types.values():
            definition: Iterable[str] = instance.definition(self)
            match instance:
                case GDExtensionEnum() | GDExtensionStruct():
                    with open(f"../Source/Godot.GDExtension/{instance.name}.cs", "w") as file:
                        file.writelines(self.header(instance.name))
                        file.write("\n")
                        file.writelines(definition)
                case _:
                    with open("../Source/Godot.GDExtension/GlobalUsings.cs", "a") as file:
                        file.writelines(definition)
        with open("../Source/Godot.GDExtension/GDExtensionInterface.cs", "w") as file:
            file.writelines(self.header("GDExtensionInterface"))
            file.write("\n")
            file.writelines(self.definition())

    def header(self, name: str) -> Iterable[str]:
        yield "/**************************************************************************/\n"
        yield f"/*  {name}.cs  {" " * (65 - len(name))}*/\n"
        for line in self.copyright:
            yield f"{line}\n"

    def unsafe(self, symbol: str) -> bool:
        return symbol.endswith("*") \
            or isinstance(self.types.get(symbol), (GDExtensionHandle, GDExtensionFunction))

class GDExtensionDescription:
    def __init__(self, lines: list[str], tag: str = "summary", metadata: str = "") -> None:
        self.lines: list[str] = lines
        self.tag: str = tag
        self.metadata: str = metadata

    def documentation(self, indent: bool = False) -> Iterable[str]:
        spacing: str = "    " if indent else ""
        metadata: str = f" {self.metadata}" if self.metadata else ""
        yield f"{spacing}/// <{self.tag}{metadata}>\n"
        for line in self.lines:
            yield f"{spacing}/// {line}\n"
        yield f"{spacing}/// </{self.tag}>\n"

class GDExtensionDeprecated:
    def __init__(self, data: dict[str, Any]) -> None:
        self.since: str = data["since"]
        self.message: str | None = data.get("message")
        self.replace_with: str | None = data.get("replace_with")

    def attribute(self, indent: bool = False) -> str:
        spacing: str = "    " if indent else ""
        message: str = f" {self.message}" if self.message else ""
        replace_with: str = f" Use {self.replace_with} instead." if self.replace_with else ""
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

    def definition(self, interface: GDExtensionInterface) -> Iterable[str]:
        raise NotImplementedError()

    def expand(self, interface: GDExtensionInterface) -> str:
        raise NotImplementedError()

class GDExtensionEnum(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.is_bitfield: bool = data.get("is_bitfield") or False
        self.values: list[GDExtensionEnumValue] = [
            GDExtensionEnumValue(value_data) for value_data in data["values"]
        ]

    def definition(self, interface: GDExtensionInterface) -> Iterable[str]:
        if self.deprecated or self.is_bitfield:
            yield "using System;\n"
            yield "\n"
        yield "namespace Godot.GDExtension;\n"
        yield "\n"
        if self.description:
            yield from self.description.documentation()
        if self.deprecated:
            yield self.deprecated.attribute()
        if self.is_bitfield:
            yield "[Flags]\n"
        yield f"public enum {self.name}\n"
        yield "{\n"
        for value in self.values[:-1]:
            if value.description:
                yield from value.description.documentation(indent=True)
            yield f"    {value.name} = {value.value},\n"
        value: GDExtensionEnumValue = self.values[-1]
        if value.description:
            yield from value.description.documentation(indent=True)
        yield f"    {value.name} = {value.value}\n"
        yield "}\n"

    def expand(self, interface: GDExtensionInterface) -> str:
        return f"Godot.GDExtension.{self.name}"

class GDExtensionEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description)

class GDExtensionHandle(GDExtensionType):
    def definition(self, interface: GDExtensionInterface) -> Iterable[str]:
        yield f"global using unsafe {self.name} = void*;\n"

    def expand(self, interface: GDExtensionInterface) -> str:
        return "void*"

class GDExtensionAlias(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.type: str = translate(data["type"])
        if self.name.endswith("Bool"):
            self.type = "bool"

    def definition(self, interface: GDExtensionInterface) -> Iterable[str]:
        yield f"global using {self.name} = {self.expand(interface)};\n"

    def expand(self, interface: GDExtensionInterface) -> str:
        instance: GDExtensionType | None = interface.types.get(self.type)
        if instance:
            return instance.expand(interface)
        return self.type

class GDExtensionStruct(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.members: list[GDExtensionStructMember] = [
            GDExtensionStructMember(member_data) for member_data in data["members"]
        ]

    def definition(self, interface: GDExtensionInterface) -> Iterable[str]:
        if self.deprecated:
            yield "using System;\n"
        yield "using System.Runtime.InteropServices;\n"
        yield "\n"
        yield "namespace Godot.GDExtension;\n"
        yield "\n"
        if self.description:
            yield from self.description.documentation()
        if self.deprecated:
            yield self.deprecated.attribute()
        yield "[StructLayout(LayoutKind.Sequential)]\n"
        yield f"public struct {self.name}\n"
        yield "{\n"
        for member in self.members:
            if member.description:
                yield from member.description.documentation(indent=True)
            unsafe: str = "unsafe " * interface.unsafe(member.type)
            yield f"    public {unsafe}{member.type} {member.name};\n"
        yield "}\n"

    def expand(self, interface: GDExtensionInterface) -> str:
        return f"Godot.GDExtension.{self.name}"

class GDExtensionStructMember:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        if self.name == "string":
            self.name = "@string"
        self.type: str = translate(data["type"])
        self.description: GDExtensionDescription | None = None
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
            self.return_value = GDExtensionFunctionReturnValue(return_value)

    def definition(self, interface: GDExtensionInterface) -> Iterable[str]:
        yield f"global using unsafe {self.name} = {self.expand(interface)};\n"

    def expand(self, interface: GDExtensionInterface) -> str:
        type_parameters: list[str] = []
        for argument in self.arguments:
            name: str = argument.type
            split: int = len(name) - argument.type.endswith("*")
            target: GDExtensionType | None = interface.types.get(name[:split])
            if target:
                name = target.expand(interface) + name[split:]
            type_parameters.append(name)
        if self.return_value:
            name: str = self.return_value.type
            split: int = len(name) - self.return_value.type.endswith("*")
            target: GDExtensionType | None = interface.types.get(name[:split])
            if target:
                name = target.expand(interface) + name[split:]
            type_parameters.append(name)
        else:
            type_parameters.append("void")
        return f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"

class GDExtensionFunctionArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data.get("name") or ""
        self.type: str = translate(data["type"])
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description, tag="param", metadata=f"name=\"{self.name}\"")

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
