from typing import Any, Iterable

class GDExtensionInterface:
    def __init__(self, data: dict[str, Any]) -> None:
        self.copyright: list[str] = data["_copyright"]
        self.types: dict[str, GDExtensionType] = {}
        self.interface: dict[str, GDExtensionFunction] = {}
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
            function: GDExtensionFunction = GDExtensionFunction(function_data)
            self.interface[function.name] = function

    def generate(self) -> None:
        with open("../Source/Godot.GDExtension/GlobalUsings.cs", "w") as file:
            file.writelines(self.header("GlobalUsings"))
            file.write("\n")
        for instance in self.types.values():
            definition: Iterable[str] = instance.definition(self.types)
            match instance:
                case GDExtensionEnum() | GDExtensionStruct():
                    with open(f"../Source/Godot.GDExtension/{instance.name}.cs", "w") as file:
                        file.writelines(self.header(instance.name))
                        file.write("\n")
                        file.writelines(definition)
                case _:
                    with open("../Source/Godot.GDExtension/GlobalUsings.cs", "a") as file:
                        file.writelines(definition)

    def header(self, name: str) -> Iterable[str]:
        yield "/**************************************************************************/\n"
        yield f"/*  {name}.cs  {" " * (65 - len(name))}*/\n"
        for line in self.copyright:
            yield f"{line}\n"

class GDExtensionSymbol:
    def __init__(self, name: str) -> None:
        self.is_const: bool = name.startswith("const")
        self.is_pointer: bool = name.endswith("*")
        start: int = 6 if self.is_const else 0
        end: int = -1 if self.is_pointer else len(name)
        self.name = name[start:end]
        match self.name:
            case "int8_t":
                self.name = "sbyte"
            case "uint8_t":
                self.name = "byte"
            case "int16_t":
                self.name = "short"
            case "uint16_t":
                self.name = "ushort"
            case "int32_t":
                self.name = "int"
            case "uint32_t":
                self.name = "uint"
            case "int64_t":
                self.name = "long"
            case "uint64_t":
                self.name = "ulong"
            case "size_t":
                self.name = "nuint"
            case "char":
                self.name = "byte"
            case "char16_t":
                self.name = "char"
            case "char32_t":
                self.name = "uint"
            case "wchar_t":
                self.name = "void"
        if self.is_pointer:
            self.name += "*"

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

    def attribute(self) -> str:
        message: str = f" {self.message}" if self.message else ""
        replace_with: str = f" Use {self.replace_with} instead." if self.replace_with else ""
        return f"[Obsolete(\"Deprecated since Godot {self.since}.{message}{replace_with}\")]\n"

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

    def definition(self, types: dict[str, GDExtensionType]) -> Iterable[str]:
        raise NotImplementedError()

    def expand(self, types: dict[str, GDExtensionType]) -> str:
        raise NotImplementedError()

class GDExtensionEnum(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.is_bitfield: bool = data.get("is_bitfield") or False
        self.values: list[GDExtensionEnumValue] = [
            GDExtensionEnumValue(value_data) for value_data in data["values"]
        ]

    def definition(self, types: dict[str, GDExtensionType]) -> Iterable[str]:
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

    def expand(self, types: dict[str, GDExtensionType]) -> str:
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
    def definition(self, types: dict[str, GDExtensionType]) -> Iterable[str]:
        yield f"global using unsafe {self.name} = void*;\n"

    def expand(self, types: dict[str, GDExtensionType]) -> str:
        return "void*"

class GDExtensionAlias(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.type: GDExtensionSymbol = GDExtensionSymbol(data["type"])
        if self.name.endswith("Bool"):
            self.type.name = "bool"

    def definition(self, types: dict[str, GDExtensionType]) -> Iterable[str]:
        yield f"global using {self.name} = {self.expand(types)};\n"

    def expand(self, types: dict[str, GDExtensionType]) -> str:
        instance: GDExtensionType | None = types.get(self.type.name)
        if instance:
            return instance.expand(types)
        return self.type.name

class GDExtensionStruct(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.members: list[GDExtensionStructMember] = [
            GDExtensionStructMember(member_data) for member_data in data["members"]
        ]

    def definition(self, types: dict[str, GDExtensionType]) -> Iterable[str]:
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
            readonly: str = "readonly " if member.type.is_const else ""
            unsafe: str = ""
            if not member.type.is_pointer:
                instance: GDExtensionType | None = types.get(member.type.name)
                if isinstance(instance, (GDExtensionHandle, GDExtensionFunction)):
                    unsafe = "unsafe "
            yield f"    public {readonly}{unsafe}{member.type.name} {member.name};\n"
        yield "}\n"

    def expand(self, types: dict[str, GDExtensionType]) -> str:
        return f"Godot.GDExtension.{self.name}"

class GDExtensionStructMember:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        if self.name == "string":
            self.name = "@string"
        self.type: GDExtensionSymbol = GDExtensionSymbol(data["type"])
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

    def definition(self, types: dict[str, GDExtensionType]) -> Iterable[str]:
        yield f"global using unsafe {self.name} = {self.expand(types)};\n"

    def expand(self, types: dict[str, GDExtensionType]) -> str:
        type_parameters: list[str] = []
        for argument in self.arguments:
            name: str = argument.type.name
            split: int = len(name) - argument.type.is_pointer
            target: GDExtensionType | None = types.get(name[:split])
            if target:
                name = target.expand(types) + name[split:]
            type_parameters.append(name)
        if self.return_value:
            name: str = self.return_value.type.name
            split: int = len(name) - self.return_value.type.is_pointer
            target: GDExtensionType | None = types.get(name[:split])
            if target:
                name = target.expand(types) + name[split:]
            type_parameters.append(name)
        else:
            type_parameters.append("void")
        return f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"

class GDExtensionFunctionArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data.get("name") or ""
        self.type: GDExtensionSymbol = GDExtensionSymbol(data["type"])
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description, tag="param", metadata=f"name=\"{self.name}\"")

class GDExtensionFunctionReturnValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.type: GDExtensionSymbol = GDExtensionSymbol(data["type"])
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description, tag="returns")
