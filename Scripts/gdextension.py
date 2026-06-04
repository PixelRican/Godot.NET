from itertools import chain
from typing import Any, Iterator

def expand(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> str:
    match data["kind"]:
        case "enum":
            return EnumGenerator.expand(data, typedefs)
        case "handle":
            return HandleGenerator.expand(data, typedefs)
        case "alias":
            return AliasGenerator.expand(data, typedefs)
        case "struct":
            return StructGenerator.expand(data, typedefs)
        case "function":
            return FunctionGenerator.expand(data, typedefs)
        case _:
            raise ValueError(f"'data' has Invalid kind '{data['kind']}.'")

def generate(data: dict[str, Any]) -> None:
    def _copyright():
        for line in data["_copyright"]:
            file.write(line)
            file.write("\n")
        file.write("\n")

    typedefs: dict[str, dict[str, Any]] = {
        typedef["name"] : typedef for typedef in data["types"]
    }
    with open("../Source/GlobalUsings.cs", "w") as file:
        _copyright()
    for typedef in data["types"]:
        match typedef["kind"]:
            case "enum":
                with open("../Source/GlobalUsings.cs", "a") as file:
                    file.write(f"global using static Godot.NET.{typedef["name"]};\n")
                with open(f"../Source/{typedef["name"]}.cs", "w") as file:
                    _copyright()
                    file.writelines(EnumGenerator.generate(typedef, typedefs))
            case "handle":
                with open("../Source/GlobalUsings.cs", "a") as file:
                    file.writelines(HandleGenerator.generate(typedef, typedefs))
            case "alias":
                with open(f"../Source/{typedef["name"]}.cs", "w") as file:
                    _copyright()
                    file.writelines(AliasGenerator.generate(typedef, typedefs))
            case "struct":
                with open(f"../Source/{typedef["name"]}.cs", "w") as file:
                    _copyright()
                    file.writelines(StructGenerator.generate(typedef, typedefs))
            case "function":
                with open("../Source/GlobalUsings.cs", "a") as file:
                    file.writelines(FunctionGenerator.generate(typedef, typedefs))

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
            yield "using System;\n"
            yield "\n"
        yield "namespace Godot.NET;\n"
        yield "\n"
        if data.get("is_bitfield"):
            yield "[Flags]\n"
        yield f"public enum {data["name"]}\n"
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
        return "Godot.NET." + data["name"]

    @staticmethod
    def generate(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> Iterator[str]:
        data_name: str = data["name"]
        data_type, _, _ = resolve(data["type"])
        yield "using System.Runtime.InteropServices;\n"
        yield "\n"
        yield "namespace Godot.NET;\n"
        yield "\n"
        yield "[StructLayout(LayoutKind.Sequential)]\n"
        yield f"public readonly struct {data_name}\n"
        yield "{\n"
        yield f"    private readonly {data_type} _value;\n"
        yield "\n"
        yield f"    public {data_name}({data_type} value)\n"
        yield "    {\n"
        yield "        _value = value;\n"
        yield "    }\n"
        yield "\n"
        yield f"    public {data_type} Value\n"
        yield "    {\n"
        yield "        get => _value;\n"
        yield "    }\n"
        yield "}\n"

class StructGenerator(TypeGenerator):
    @staticmethod
    def expand(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> str:
        return "Godot.NET." + data["name"]

    @staticmethod
    def generate(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> Iterator[str]:
        deprecated: dict[str, Any] | None = data.get("deprecated")
        if deprecated:
            yield "using System;\n"
        yield "using System.Runtime.InteropServices;\n"
        yield "\n"
        yield "namespace Godot.NET;\n"
        yield "\n"
        if deprecated:
            yield f"[Obsolete(\"Deprecated since Godot {deprecated["since"]}. Use {deprecated["replace_with"]} instead.\")]\n"
        yield "[StructLayout(LayoutKind.Sequential)]\n"
        yield f"public struct {data["name"]}\n"
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
                argument_type = expand(typedef, typedefs) + argument_type[split:]
            type_parameters.append(argument_type)
        return f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"

    @staticmethod
    def generate(data: dict[str, Any], typedefs: dict[str, dict[str, Any]]) -> Iterator[str]:
        yield f"global using unsafe {data["name"]} = {FunctionGenerator.expand(data, typedefs)};\n"
