from typing import Any, Iterator

def generate(data: dict[str, Any]) -> None:
    for typedef in data["types"]:
        with open(f"../Source/{typedef["name"]}.cs", "w") as file:
            for line in data["_copyright"]:
                file.write(line)
                file.write("\n")
            file.write("\n")
            match typedef["kind"]:
                case "enum":
                    file.writelines(EnumGenerator.generate(typedef))
                case "handle":
                    file.writelines(HandleGenerator.generate(typedef))
                case "alias":
                    file.writelines(AliasGenerator.generate(typedef))
                case "struct":
                    file.writelines(StructGenerator.generate(typedef))
                case "function":
                    file.writelines(FunctionGenerator.generate(typedef))

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

class EnumGenerator:
    @staticmethod
    def generate(data: dict[str, Any]) -> Iterator[str]:
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

class HandleGenerator:
    @staticmethod
    def generate(data: dict[str, Any]) -> Iterator[str]:
        data_name: str = data["name"]
        data_parent: str | None = data.get("parent")
        yield "using System.Runtime.InteropServices;\n"
        yield "\n"
        yield "namespace Godot.NET;\n"
        yield "\n"
        yield "[StructLayout(LayoutKind.Sequential)]\n"
        yield f"public readonly struct {data_name}\n"
        yield "{\n"
        yield f"    private readonly nint _handle;\n"
        yield "\n"
        yield f"    public {data_name}(nint handle)\n"
        yield "    {\n"
        yield "        _handle = handle;\n"
        yield "    }\n"
        yield "\n"
        yield f"    public nint Handle\n"
        yield "    {\n"
        yield "        get => _handle;\n"
        yield "    }\n"
        if data_parent:
            yield "\n"
            yield f"    public static implicit operator {data_name}({data_parent} parent)\n"
            yield "    {\n"
            yield f"        return new {data_name}(parent.Handle);\n"
            yield "    }\n"
        yield "}\n"

class AliasGenerator:
    @staticmethod
    def generate(data: dict[str, Any]) -> Iterator[str]:
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

class StructGenerator:
    @staticmethod
    def generate(data: dict[str, Any]) -> Iterator[str]:
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
            yield f"    {" ".join(modifiers)} {member_type} {member_name};\n"
        yield "}\n"

class FunctionGenerator:
    @staticmethod
    def generate(data: dict[str, Any]) -> Iterator[str]:
        type_parameters: list[str] = []
        for argument in data["arguments"]:
            argument_type, _, _ = resolve(argument["type"])
            type_parameters.append(argument_type)
        return_value: dict[str, Any] | None = data.get("return_value")
        if return_value:
            return_value_type, _, _ = resolve(return_value["type"])
            type_parameters.append(return_value_type)
        else:
            type_parameters.append("void")
        data_name: str = data["name"]
        data_type: str = f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"
        yield "using System.Runtime.InteropServices;\n"
        yield "\n"
        yield "namespace Godot.NET;\n"
        yield "\n"
        yield "[StructLayout(LayoutKind.Sequential)]\n"
        yield f"public readonly unsafe struct {data_name}\n"
        yield "{\n"
        yield f"    private readonly {data_type} _method;\n"
        yield "\n"
        yield f"    public {data_name}({data_type} method)\n"
        yield "    {\n"
        yield "        _method = method;\n"
        yield "    }\n"
        yield "\n"
        yield f"    public {data_type} Method\n"
        yield "    {\n"
        yield "        get => _method;\n"
        yield "    }\n"
        yield "}\n"
