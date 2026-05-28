from itertools import chain
from typing import Any, Iterator
import json

class GDExtensionInterface:
    def __init__(self, data: dict[str, Any]) -> None:
        self.copyright: list[str] = data["_copyright"]
        self.schema: str = data["$schema"]
        self.format_version: int = data["format_version"]
        self.types: list[GDExtensionType] = []
        self.interface: list[GDExtensionInterfaceFunction] = []
        for type_data in data["types"]:
            name: str = type_data["name"]
            kind: str = type_data["kind"]
            match kind:
                case "enum":
                    self.types.append(GDExtensionEnum(type_data))
                case "handle":
                    self.types.append(GDExtensionHandle(type_data))
                case "alias":
                    self.types.append(GDExtensionAlias(type_data))
                case "struct":
                    self.types.append(GDExtensionStruct(type_data))
                case "function":
                    self.types.append(GDExtensionFunction(type_data))
                case _:
                    raise ValueError(f"'{name}' has invalid kind '{kind}.'")
        for interface_data in data["interface"]:
            self.interface.append(GDExtensionInterfaceFunction(interface_data))

    def generate(self) -> Iterator[str]:
        types: dict[str, GDExtensionType] = {}
        global_section: list[GDExtensionType] = []
        local_section: list[GDExtensionType] = []
        for element in self.types:
            types[element.name] = element
            match element.kind:
                case "handle" | "alias" | "function":
                    global_section.append(element)
                case "enum" | "struct":
                    local_section.append(element)
        for line in self.copyright:
            yield line + "\n"
        yield "\n"
        for element in chain(global_section, self.interface):
            for line in element.generate(types):
                yield line
        yield "\n"
        yield "using System;\n"
        yield "using System.Runtime.InteropServices;\n"
        yield "\n"
        yield "namespace Godot;\n"
        for element in local_section:
            yield "\n"
            for line in element.generate(types):
                yield line

class GDExtensionType:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.kind: str | None  = data.get("kind")
        self.description: list[str] | None = data.get("description")
        self.deprecated: GDExtensionDeprecated | None = None
        deprecated: dict[str, Any] | None = data.get("deprecated")
        if deprecated:
            self.deprecated = GDExtensionDeprecated(deprecated)

    def expand(self, types: dict[str, GDExtensionType]) -> str:
        raise NotImplementedError()

    def generate(self, types: dict[str, GDExtensionType]) -> Iterator[str]:
        raise NotImplementedError()

class GDExtensionDeprecated:
    def __init__(self, data: dict[str, Any]) -> None:
        self.since: str = data["since"]
        self.message: str | None = data.get("message")
        self.replacement: str | None = data.get("replacement")

class GDExtensionEnum(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.values: list[GDExtensionEnumValue] = [
            GDExtensionEnumValue(value) for value in data["values"]
        ]
        self.is_bitfield: bool | None = data.get("is_bitfield")

    def expand(self, types: dict[str, GDExtensionEnum]) -> str:
        return "Godot." + self.name

    def generate(self, types: dict[str, GDExtensionType]) -> Iterator[str]:
        if self.is_bitfield:
            yield "[Flags]\n"
        yield f"public enum {self.name}\n"
        yield "{\n"
        for member in self.values:
            member_name: str = member.name.title().replace("Gde", "GDE", 1).replace("_", "")
            member_value: int = member.value
            yield f"    {member_name} = {member_value},\n"
        yield "}\n"

class GDExtensionEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]
        self.description: list[str] | None = data.get("description")

class GDExtensionHandle(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.parent: str | None = data.get("parent")
        self.is_const: bool | None = data.get("is_const")
        self.is_uninitialized: bool | None = data.get("is_uninitialized")

    def expand(self, types: dict[str, GDExtensionType]) -> str:
        return "void*"

    def generate(self, types: dict[str, GDExtensionType]) -> Iterator[str]:
        yield f"global using unsafe {self.name} = void*;\n"

class GDExtensionAlias(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.type: str = data["type"]

    def expand(self, types: dict[str, GDExtensionType]) -> str:
        typedef: GDExtensionType | None = types.get(self.type)
        if typedef:
            return typedef.expand(types)
        alias_type, _, _ = resolve(self.type)
        return alias_type

    def generate(self, types: dict[str, GDExtensionType]) -> Iterator[str]:
        yield f"global using {self.name} = {self.expand(types)};\n"

class GDExtensionStruct(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.members: list[GDExtensionStructMember] = [
            GDExtensionStructMember(member) for member in data["members"]
        ]

    def expand(self, types: dict[str, GDExtensionType]) -> str:
        return "Godot." + self.name

    def generate(self, types: dict[str, GDExtensionType]) -> Iterator[str]:
        yield "[StructLayout(LayoutKind.Sequential)]\n"
        yield f"public struct {self.name}\n"
        yield "{\n"
        for member in self.members:
            member_name: str = member.name.title().replace("_", "")
            member_type, is_readonly, is_unsafe = resolve(member.type)
            modifiers: list[str] = ["public"]
            if is_readonly:
                modifiers.append("readonly")
            if is_unsafe or isinstance(types.get(member_type), (GDExtensionHandle, GDExtensionFunction)):
                modifiers.append("unsafe")
            yield f"    {" ".join(modifiers)} {member_type} {member_name};\n"
        yield "}\n"

class GDExtensionStructMember:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.description: list[str] | None = data.get("description")

class GDExtensionFunction(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.arguments: list[GDExtensionFunctionArgument] = [
            GDExtensionFunctionArgument(argument) for argument in data["arguments"]
        ]
        self.return_value: GDExtensionFunctionReturnValue | None = None
        return_value: dict[str, Any] | None = data.get("return_value")
        if return_value:
            self.return_value = GDExtensionFunctionReturnValue(return_value)

    def expand(self, types: dict[str, GDExtensionType]) -> str:
        type_parameters: list[str] = []
        for argument in self.arguments:
            argument_type, _, is_unsafe = resolve(argument.type)
            split: int = len(argument_type) - is_unsafe
            typedef: GDExtensionType | None = types.get(argument_type[:split])
            if typedef:
                argument_type = typedef.expand(types) + argument_type[split:]
            type_parameters.append(argument_type)
        if self.return_value:
            return_value_type, _, is_unsafe = resolve(self.return_value.type)
            split: int = len(return_value_type) - is_unsafe
            typedef: GDExtensionType | None = types.get(return_value_type[:split])
            if typedef:
                return_value_type = typedef.expand(types) + return_value_type[split:]
            type_parameters.append(return_value_type)
        else:
            type_parameters.append("void")
        return f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"

    def generate(self, types: dict[str, GDExtensionType]) -> Iterator[str]:
        yield f"global using unsafe {self.name} = {self.expand(types)};\n"

class GDExtensionFunctionReturnValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.type: str = data["type"]
        self.description: list[str] | None = data.get("description")

class GDExtensionFunctionArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.type: str = data["type"]
        self.name: str | None = data.get("name")
        self.description: list[str] | None = data.get("description")

class GDExtensionInterfaceFunction(GDExtensionFunction):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.since: str = data["since"]
        self.see: list[str] | None = data.get("see")
        self.legacy_type_name: str | None = data.get("legacy_type_name")

    def generate(self, types: dict[str, GDExtensionType]) -> Iterator[str]:
        function_name: str = "GDExtensionInterface" + self.name.title().replace("_", "")
        yield f"global using unsafe {function_name} = {self.expand(types)};\n"

def resolve(typedef: str) -> tuple[str, bool, bool]:
    is_readonly: bool = typedef.startswith("const")
    is_unsafe: bool = typedef.endswith("*")
    start: int = 6 if is_readonly else 0
    end: int = -1 if is_unsafe else len(typedef)
    name: str = typedef[start:end]
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
            name = "ushort"
        case "char32_t":
            name = "uint"
        case "wchar_t":
            name = "char"
    if is_unsafe:
        name += "*"
    return name, is_readonly, is_unsafe

if __name__ == "__main__":
    # with open("gdextension_interface.json", "r") as file:
    #     interface = GDExtensionInterface(json.load(file))
    # with open("../Source/GDExtensionInterface.cs", "w") as file:
    #     file.writelines(interface.generate())
    with open("extension_api.json", "r") as file:
        print(*json.load(file), sep="\n")
