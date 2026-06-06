from io import IOBase
from typing import Any

def function(data: dict[str, Any]):
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
    return f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"

def generate(data: dict[str, Any]) -> None:
    for type_data in data["types"]:
        name: str = type_data["name"]
        kind: str = type_data["kind"]
        with open(f"../Source/{name}.cs", "w") as file:
            for line in data["_copyright"]:
                file.write(line)
                file.write("\n")
            file.write("\n")
            match kind:
                case "enum":
                    EnumGenerator.generate(file, type_data)
                case "handle":
                    HandleGenerator.generate(file, type_data)
                case "alias":
                    AliasGenerator.generate(file, type_data)
                case "struct":
                    StructGenerator.generate(file, type_data)
                case "function":
                    FunctionGenerator.generate(file, type_data)
                case _:
                    raise ValueError(f"'{name}' has invalid kind '{kind}.'")
    with open(f"../Source/GDExtensionInterface.cs", "w") as file:
        for line in data["_copyright"]:
            file.write(line)
            file.write("\n")
        file.write("\n")
        GDExtensionInterfaceGenerator.generate(file, data)

def obsolete(data: dict[str, Any]) -> str:
    since: str = data["since"]
    message: str | None = data.get("message")
    replace_with: str | None = data.get("replace_with")
    sentence: list[str] = [f"Deprecated since Godot {since}."]
    if message:
        sentence.append(message)
    if replace_with:
        if "_" in replace_with:
            replace_with = "GDExtensionInterface." + replace_with.title().replace("_", "")
        sentence.append(f"Use {replace_with} instead.")
    return f"[Obsolete(\"{" ".join(sentence)}\")]\n"

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
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        data_name: str = data["name"]
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        data_is_bitfield: bool | None = data.get("is_bitfield")
        if data_deprecated or data_is_bitfield:
            file.write("using System;\n")
            file.write("\n")
        file.write("namespace Godot.NET;\n")
        file.write("\n")
        if data_deprecated:
            file.write(obsolete(data_deprecated))
        if data_is_bitfield:
            file.write("[Flags]\n")
        file.write(f"public enum {data_name}\n")
        file.write("{\n")
        for value in data["values"]:
            value_name: str = value["name"].title().replace("_", "").replace("Gde", "GDE", 1)
            value_value: int = value["value"]
            file.write(f"    {value_name} = {value_value},\n")
        file.write("}\n")

class HandleGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        data_name: str = data["name"]
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        data_parent: str | None = data.get("parent")
        if data_deprecated:
            file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace Godot.NET;\n")
        file.write("\n")
        if data_deprecated:
            file.write(obsolete(data_deprecated))
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public readonly unsafe struct {data_name}\n")
        file.write("{\n")
        file.write("    private readonly void* _value;\n")
        file.write("\n")
        file.write(f"    public {data_name}(void* value)\n")
        file.write("    {\n")
        file.write("        _value = value;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public void* Value\n")
        file.write("    {\n")
        file.write("        get => _value;\n")
        file.write("    }\n")
        if data_parent:
            file.write("\n")
            file.write(f"    public static implicit operator {data_name}({data_parent} parent)\n")
            file.write("    {\n")
            file.write(f"        return new {data_name}(parent.Value);\n")
            file.write("    }\n")
        file.write("}\n")

class AliasGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        data_name: str = data["name"]
        data_type, _, _ = resolve(data["type"])
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        if data_deprecated:
            file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace Godot.NET;\n")
        file.write("\n")
        if data_deprecated:
            file.write(obsolete(data_deprecated))
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public readonly struct {data_name}\n")
        file.write("{\n")
        file.write(f"    private readonly {data_type} _value;\n")
        file.write("\n")
        file.write(f"    public {data_name}({data_type} value)\n")
        file.write("    {\n")
        file.write("        _value = value;\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public {data_type} Value\n")
        file.write("    {\n")
        file.write("        get => _value;\n")
        file.write("    }\n")
        file.write("}\n")

class StructGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        data_name: str = data["name"]
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        if data_deprecated:
            file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace Godot.NET;\n")
        file.write("\n")
        if data_deprecated:
            file.write(obsolete(data_deprecated))
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public struct {data_name}\n")
        file.write("{\n")
        for member in data["members"]:
            member_name: str = member["name"].title().replace("_", "")
            member_type, is_readonly, is_unsafe = resolve(member["type"])
            modifiers: list[str] = ["public"]
            if is_readonly:
                modifiers.append("readonly")
            if is_unsafe:
                modifiers.append("unsafe")
            file.write(f"    {" ".join(modifiers)} {member_type} {member_name};\n")
        file.write("}\n")

class FunctionGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        data_name: str = data["name"]
        data_type: str = function(data)
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        if data_deprecated:
            file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace Godot.NET;\n")
        file.write("\n")
        if data_deprecated:
            file.write(obsolete(data_deprecated))
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public readonly unsafe struct {data_name}\n")
        file.write("{\n")
        file.write(f"    private readonly {data_type} _method;\n")
        file.write("\n")
        file.write(f"    public {data_name}({data_type} method)\n")
        file.write("    {\n")
        file.write("        _method = method;\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public {data_type} Method\n")
        file.write("    {\n")
        file.write("        get => _method;\n")
        file.write("    }\n")
        file.write("}\n")

class GDExtensionInterfaceGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        interface: list[dict[str, Any]] = data["interface"]
        fields: list[tuple[str, str, str]] = []
        file.write("using System;\n")
        file.write("\n")
        file.write("namespace Godot.NET;\n")
        file.write("\n")
        file.write("public static unsafe class GDExtensionInterface\n")
        file.write("{\n")
        for interface_data in interface:
            interface_name: str = interface_data["name"]
            field_name = f"s_{interface_name[0]}{interface_name.title().replace("_", "")[1:]}"
            field_type: str = function(interface_data)
            fields.append((interface_name, field_name, field_type))
            file.write(f"    private static {field_type} {field_name};\n")
        for interface_data, field in zip(interface, fields):
            _, field_name, field_type = field
            interface_deprecated: dict[str, Any] | None = interface_data.get("deprecated")
            file.write("\n")
            if interface_deprecated:
                file.write("    " + obsolete(interface_deprecated))
            file.write(f"    public static {field_type} {field_name[2].upper() + field_name[3:]}\n")
            file.write("    {\n")
            file.write(f"        get => {field_name};\n")
            file.write("    }\n")
        file.write("\n")
        file.write("    public static void Initialize(GDExtensionInterfaceGetProcAddress getProcAddress)\n")
        file.write("    {\n")
        file.write("        if (getProcAddress.Method == null)\n")
        file.write("        {\n")
        file.write("            throw new ArgumentNullException(nameof(getProcAddress));\n")
        file.write("        }\n")
        file.write("\n")
        for interface_name, field_name, field_type in fields:
            file.write(f"        {field_name} = ({field_type})Load(getProcAddress, \"{interface_name}\"u8);\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    private static void* Load(GDExtensionInterfaceGetProcAddress getProcAddress, ReadOnlySpan<byte> name)\n")
        file.write("    {\n")
        file.write("        fixed (byte* reference = name)\n")
        file.write("        {\n")
        file.write("            GDExtensionInterfaceFunctionPtr function = getProcAddress.Method(reference);\n")
        file.write("            return function.Method;\n")
        file.write("        }\n")
        file.write("    }\n")
        file.write("}\n")
