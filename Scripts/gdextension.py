from itertools import chain
from typing import Any, Iterator

def generate(data: dict[str, Any]) -> None:
    typedefs: dict[str, dict[str, Any]] = {}
    global_section: list[dict[str, Any]] = []
    local_section: list[dict[str, Any]] = []
    for typedef in data["types"]:
        typedefs[typedef["name"]] = typedef
        match typedef["kind"]:
            case "handle" | "alias" | "function":
                global_section.append(typedef)
            case "enum" | "struct":
                local_section.append(typedef)
    with open("../Source/GDExtensionInterface.cs", "w") as file:
        for line in data["_copyright"]:
            file.write(line)
            file.write("\n")
        file.write("\n")
        for typedef in global_section:
            generator: type[TypeGenerator] = TypeGenerator.get(typedef["kind"])
            file.writelines(generator.generate(typedef, typedefs))
        file.write("\n")
        file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace Godot.NET;\n")
        for typedef in local_section:
            generator: type[TypeGenerator] = TypeGenerator.get(typedef["kind"])
            file.write("\n")
            file.writelines(generator.generate(typedef, typedefs))

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

class TypeGenerator:
    @staticmethod
    def get(kind: str) -> type[TypeGenerator]:
        match kind:
            case "enum":
                return EnumGenerator
            case "handle":
                return HandleGenerator
            case "alias":
                return AliasGenerator
            case "struct":
                return StructGenerator
            case "function":
                return FunctionGenerator
            case _:
                raise ValueError(f"Invalid kind '{kind}.'")

    @staticmethod
    def expand(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> str:
        raise NotImplementedError()

    @staticmethod
    def generate(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> Iterator[str]:
        raise NotImplementedError()

class EnumGenerator(TypeGenerator):
    @staticmethod
    def expand(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> str:
        return "Godot.NET." + data["name"]

    @staticmethod
    def generate(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> Iterator[str]:
        if data.get("is_bitfield"):
            yield "[Flags]\n"
        yield f"internal enum {data["name"]}\n"
        yield "{\n"
        for value in data["values"]:
            yield f"    {value["name"]} = {value["value"]},\n"
        yield "}\n"

class HandleGenerator(TypeGenerator):
    @staticmethod
    def expand(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> str:
        return "void*"

    @staticmethod
    def generate(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> Iterator[str]:
        yield f"global using unsafe {data["name"]} = void*;\n"

class AliasGenerator(TypeGenerator):
    @staticmethod
    def expand(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> str:
        typedef: dict[str, Any] | None = typedefs.get(data["type"])
        if typedef:
            generator: type[TypeGenerator] = TypeGenerator.get(typedef["kind"])
            return generator.expand(typedef, typedefs)
        alias_type, _, _ = resolve(data["type"])
        return alias_type

    @staticmethod
    def generate(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> Iterator[str]:
        yield f"global using {data["name"]} = {AliasGenerator.expand(data, typedefs)};\n"

class StructGenerator(TypeGenerator):
    @staticmethod
    def expand(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> str:
        return "Godot.NET." + data["name"]

    @staticmethod
    def generate(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> Iterator[str]:
        yield "[StructLayout(LayoutKind.Sequential)]\n"
        yield f"internal struct {data["name"]}\n"
        yield "{\n"
        for member in data["members"]:
            member_name: str = member["name"]
            if member_name == "string":
                member_name = "@string"
            member_type, is_readonly, is_unsafe = resolve(member["type"])
            modifiers: list[str] = ["public"]
            if is_readonly:
                modifiers.append("readonly")
            if is_unsafe:
                modifiers.append("unsafe")
            else:
                typedef: dict[str, Any] | None = typedefs.get(member["type"])
                if typedef and typedef["kind"] in ("handle", "function"):
                    modifiers.append("unsafe")
            yield f"    {" ".join(modifiers)} {member_type} {member_name};\n"
        yield "}\n"

class FunctionGenerator(TypeGenerator):
    @staticmethod
    def expand(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> str:
        type_parameters: list[str] = []
        for argument in chain(data["arguments"], [data.get("return_value") or {"type" : "void"}]):
            argument_type, _, is_unsafe = resolve(argument["type"])
            split: int = len(argument_type) - is_unsafe
            typedef: dict[str, Any] | None = typedefs.get(argument_type[:split])
            if typedef:
                generator: type[TypeGenerator] = TypeGenerator.get(typedef["kind"])
                argument_type = generator.expand(typedef, typedefs) + argument_type[split:]
            type_parameters.append(argument_type)
        return f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"

    @staticmethod
    def generate(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> Iterator[str]:
        yield f"global using unsafe {data["name"]} = {FunctionGenerator.expand(data, typedefs)};\n"
