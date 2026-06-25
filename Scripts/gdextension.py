from io import IOBase
from typing import Any

def generate(data: dict[str, Any]) -> None:
    for type_data in data["types"]:
        name: str = type_data["name"]
        kind: str = type_data["kind"]
        with open(f"../Source/GDExtension/{name}.cs", "w") as file:
            HeaderGenerator.generate(file, type_data)
            CopyrightGenerator.generate(file, data)
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
    with open(f"../Source/GDExtension/GDExtensionInterface.cs", "w") as file:
        HeaderGenerator.generate(file, {"name" : "GDExtensionInterface"})
        CopyrightGenerator.generate(file, data)
        GDExtensionInterfaceGenerator.generate(file, data)

class TypeInfo:
    def __init__(self, typedef: str) -> None:
        self.is_readonly: bool = typedef.startswith("const")
        self.is_unsafe: bool = typedef.endswith("*")
        self.is_builtin: bool = True
        start: int = 6 if self.is_readonly else 0
        end: int = -1 if self.is_unsafe else len(typedef)
        self.name: str = typedef[start:end]
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
                self.name = "ushort"
            case "char32_t":
                self.name = "uint"
            case "wchar_t":
                self.name = "char"
            case "void" | "float" | "double":
                pass
            case _:
                self.is_builtin = False
        if self.is_unsafe:
            self.name += "*"

class FunctionInfo:
    def __init__(self, data: dict[str, Any]) -> None:
        type_parameters: list[str] = []
        argument_names: list[str] = []
        for i, argument in enumerate(data["arguments"]):
            argument_type: TypeInfo = TypeInfo(argument["type"])
            argument_name: str | None = argument.get("name")
            if argument_name:
                argument_name = argument_name.title().replace("_", "")
                argument_names.append(argument_name[0].lower() + argument_name[1:])
            else:
                argument_names.append(f"arg{i + 1}")
            type_parameters.append(argument_type.name)
        return_value: dict[str, Any] | None = data.get("return_value")
        if return_value:
            return_value_type: TypeInfo = TypeInfo(return_value["type"])
            type_parameters.append(return_value_type.name)
        else:
            type_parameters.append("void")
        self.name: str = data["name"]
        self.type: str = f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"
        self.return_value: str = type_parameters.pop(-1)
        self.parameter_list: str = ", ".join(" ".join(pair) for pair in zip(type_parameters, argument_names))
        self.argument_list: str = ", ".join(argument_names)

class HeaderGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        name: str = data["name"]
        file.write("/**************************************************************************/\n")
        file.write(f"/*  {name}.cs{" " * (67 - len(name))}*/\n")

class CopyrightGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        for line in data["_copyright"]:
            file.write(line)
            file.write("\n")
        file.write("\n")

class DeprecatedGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        since: str = data["since"]
        message: str | None = data.get("message")
        replace_with: str | None = data.get("replace_with")
        file.write(f"[Obsolete(\"Deprecated since Godot {since}.")
        if message:
            file.write(" ")
            file.write(message)
        if replace_with:
            file.write(" Use ")
            if "_" in replace_with:
                file.write("GDExtensionInterface.")
                file.write(replace_with.title().replace("_", ""))
            else:
                file.write(replace_with)
            file.write(" instead.")
        file.write("\")]\n")

class EnumGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        data_name: str = data["name"]
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        data_is_bitfield: bool | None = data.get("is_bitfield")
        if data_deprecated or data_is_bitfield:
            file.write("using System;\n")
            file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if data_deprecated:
            DeprecatedGenerator.generate(file, data_deprecated)
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
        file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if data_deprecated:
            DeprecatedGenerator.generate(file, data_deprecated)
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public readonly unsafe struct {data_name} : IEquatable<{data_name}>\n")
        file.write("{\n")
        file.write("    private readonly void* _pointer;\n")
        file.write("\n")
        file.write(f"    public {data_name}(void* pointer)\n")
        file.write("    {\n")
        file.write("        _pointer = pointer;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public void* Pointer\n")
        file.write("    {\n")
        file.write("        get => _pointer;\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public bool Equals({data_name} other)\n")
        file.write("    {\n")
        file.write("        return _pointer == other._pointer;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override bool Equals(object? obj)\n")
        file.write("    {\n")
        file.write(f"        return obj is {data_name} other && _pointer == other._pointer;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override int GetHashCode()\n")
        file.write("    {\n")
        file.write("        return new nint(_pointer).GetHashCode();\n")
        file.write("    }\n")
        if data_parent:
            file.write("\n")
            file.write(f"    public static implicit operator {data_name}({data_parent} parent)\n")
            file.write("    {\n")
            file.write(f"        return new {data_name}(parent.Pointer);\n")
            file.write("    }\n")
        file.write("\n")
        file.write(f"    public static bool operator ==({data_name} left, {data_name} right)\n")
        file.write("    {\n")
        file.write("        return left._pointer == right._pointer;\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public static bool operator !=({data_name} left, {data_name} right)\n")
        file.write("    {\n")
        file.write("        return left._pointer != right._pointer;\n")
        file.write("    }\n")
        file.write("}\n")

class AliasGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        data_name: str = data["name"]
        data_is_bool: bool = data_name.endswith("Bool")
        data_type: TypeInfo = TypeInfo(data["type"])
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        if data_deprecated or data_type.is_builtin:
            file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if data_deprecated:
            DeprecatedGenerator.generate(file, data_deprecated)
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        if data_type.is_builtin:
            file.write(f"public readonly struct {data_name} : IEquatable<{data_name}>\n")
        else:
            file.write(f"public struct {data_name}\n")
        file.write("{\n")
        if data_type.is_builtin:
            file.write(f"    private readonly {data_type.name} _value;\n")
            if data_is_bool:
                data_type.name = "bool"
        else:
            file.write(f"    public {data_type.name} Value;\n")
        file.write("\n")
        file.write(f"    public {data_name}({data_type.name} value)\n")
        file.write("    {\n")
        if data_is_bool:
            file.write("        _value = (byte)(value ? 1 : 0);\n")
        elif data_type.is_builtin:
            file.write("        _value = value;\n")
        else:
            file.write("        Value = value;\n")
        file.write("    }\n")
        if data_type.is_builtin:
            file.write("\n")
            file.write(f"    public {data_type.name} Value\n")
            file.write("    {\n")
            if data_is_bool:
                file.write("        get => _value != 0;\n")
            else:
                file.write("        get => _value;\n")
            file.write("    }\n")
            file.write("\n")
            file.write(f"    public bool Equals({data_name} other)\n")
            file.write("    {\n")
            file.write("        return _value == other._value;\n")
            file.write("    }\n")
            file.write("\n")
            file.write("    public override bool Equals(object? obj)\n")
            file.write("    {\n")
            file.write(f"        return obj is {data_name} other && _value == other._value;\n")
            file.write("    }\n")
            file.write("\n")
            file.write("    public override int GetHashCode()\n")
            file.write("    {\n")
            file.write("        return _value.GetHashCode();\n")
            file.write("    }\n")
            file.write("\n")
            file.write(f"    public static bool operator ==({data_name} left, {data_name} right)\n")
            file.write("    {\n")
            file.write("        return left._value == right._value;\n")
            file.write("    }\n")
            file.write("\n")
            file.write(f"    public static bool operator !=({data_name} left, {data_name} right)\n")
            file.write("    {\n")
            file.write("        return left._value != right._value;\n")
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
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if data_deprecated:
            DeprecatedGenerator.generate(file, data_deprecated)
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public struct {data_name}\n")
        file.write("{\n")
        for member in data["members"]:
            member_name: str = member["name"].title().replace("_", "")
            member_type: TypeInfo = TypeInfo(member["type"])
            modifiers: list[str] = ["public"]
            if member_type.is_readonly:
                modifiers.append("readonly")
            if member_type.is_unsafe:
                modifiers.append("unsafe")
            file.write(f"    {" ".join(modifiers)} {member_type.name} {member_name};\n")
        file.write("}\n")

class FunctionGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        function: FunctionInfo = FunctionInfo(data)
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        file.write("using System;\n")
        file.write("using System.Runtime.CompilerServices;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if data_deprecated:
            DeprecatedGenerator.generate(file, data_deprecated)
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public readonly unsafe struct {function.name} : IEquatable<{function.name}>\n")
        file.write("{\n")
        file.write(f"    private readonly {function.type} _method;\n")
        file.write("\n")
        file.write(f"    public {function.name}({function.type} method)\n")
        file.write("    {\n")
        file.write("        _method = method;\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public {function.type} Method\n")
        file.write("    {\n")
        file.write("        get => _method;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n")
        file.write(f"    public {function.return_value} Invoke({function.parameter_list})\n")
        file.write("    {\n")
        if function.return_value == "void":
            file.write(f"        _method({function.argument_list});\n")
        else:
            file.write(f"        return _method({function.argument_list});\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public bool Equals({function.name} other)\n")
        file.write("    {\n")
        file.write("        return _method == other._method;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override bool Equals(object? obj)\n")
        file.write("    {\n")
        file.write(f"        return obj is {function.name} other && _method == other._method;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override int GetHashCode()\n")
        file.write("    {\n")
        file.write("        return new nint(_method).GetHashCode();\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public static bool operator ==({function.name} left, {function.name} right)\n")
        file.write("    {\n")
        file.write("        return left._method == right._method;\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public static bool operator !=({function.name} left, {function.name} right)\n")
        file.write("    {\n")
        file.write("        return left._method != right._method;\n")
        file.write("    }\n")
        file.write("}\n")

class GDExtensionInterfaceGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        fields: dict[str, FunctionInfo] = {}
        file.write("using System;\n")
        file.write("using System.Runtime.CompilerServices;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        file.write("public static unsafe class GDExtensionInterface\n")
        file.write("{\n")
        for interface_data in data["interface"]:
            function: FunctionInfo = FunctionInfo(interface_data)
            field_name = f"s_{function.name[0]}{function.name.title().replace("_", "")[1:]}"
            fields[field_name] = function
            file.write(f"    private static {function.type} {field_name};\n")
        for field, interface_data in zip(fields.items(), data["interface"]):
            field_name, function = field
            interface_deprecated: dict[str, Any] | None = interface_data.get("deprecated")
            file.write("\n")
            if interface_deprecated:
                file.write("    ")
                DeprecatedGenerator.generate(file, interface_deprecated)
            file.write("    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n")
            file.write(f"    public static {function.return_value} {field_name[2].upper() + field_name[3:]}({function.parameter_list})\n")
            file.write("    {\n")
            if function.return_value == "void":
                file.write(f"        {field_name}({function.argument_list});\n")
            else:
                file.write(f"        return {field_name}({function.argument_list});\n")
            file.write("    }\n")
        file.write("\n")
        file.write("    public static void Initialize(GDExtensionInterfaceGetProcAddress getProcAddress)\n")
        file.write("    {\n")
        file.write("        ArgumentNullException.ThrowIfNull(getProcAddress.Method, nameof(getProcAddress));\n")
        for field_name, function in fields.items():
            file.write(f"        {field_name} = ({function.type})Load(getProcAddress, \"{function.name}\"u8);\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    private static void* Load(GDExtensionInterfaceGetProcAddress getProcAddress, ReadOnlySpan<byte> name)\n")
        file.write("    {\n")
        file.write("        fixed (byte* reference = name)\n")
        file.write("        {\n")
        file.write("            GDExtensionInterfaceFunctionPtr function = getProcAddress.Invoke(reference);\n")
        file.write("            return function.Method;\n")
        file.write("        }\n")
        file.write("    }\n")
        file.write("}\n")
