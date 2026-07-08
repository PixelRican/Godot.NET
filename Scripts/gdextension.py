from copy import copy
from io import IOBase
from itertools import chain
from typing import Any

def generate(data: dict[str, Any]) -> None:
    types: dict[str, GDExtensionType] = {}
    _copyright: list[str] = data["_copyright"]
    for type_data in data["types"]:
        instance: GDExtensionType
        match type_data["kind"]:
            case "enum":
                enum: GDExtensionEnum = GDExtensionEnum(type_data)
                types[enum.name] = enum
                enum.generate(_copyright)
            case "handle":
                handle: GDExtensionHandle = GDExtensionHandle(type_data)
                types[handle.name] = handle
                handle.generate(_copyright)
            case "alias":
                alias: GDExtensionAlias = GDExtensionAlias(type_data)
                actual: GDExtensionType = alias
                if not alias.type.is_builtin:
                    actual = copy(types[alias.type.name])
                    actual.name = alias.name
                types[actual.name] = actual
                actual.generate(_copyright)
            case "struct":
                pass
            case "function":
                pass

class GDExtensionTypeReference:
    def __init__(self, typedef: str) -> None:
        self.name: str
        self.is_readonly: bool = typedef.startswith("const")
        self.is_unsafe: bool = typedef.endswith("*")
        self.is_builtin: bool = True
        start: int = 6 if self.is_readonly else 0
        end: int = -1 if self.is_unsafe else len(typedef)
        self.name = typedef[start:end]
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
            case "void" | "float" | "double":
                pass
            case _:
                self.is_builtin = False
        if self.is_unsafe:
            self.name += "*"

class GDExtensionDescription:
    def __init__(self, lines: list[str], tag: str = "summary", metadata: str = "", tab: bool = False) -> None:
        self.lines: list[str] = lines
        self.tag: str = tag
        self.metadata: str = metadata
        self.spacing: str = " " * 4 if tab else ""

    def dump(self, file: IOBase) -> None:
        file.write(f"{self.spacing}/// <{self.tag}")
        if self.metadata:
            file.write(f" {self.metadata}")
        file.write(">\n")
        for line in self.lines:
            file.write(f"{self.spacing}/// {line}\n")
        file.write(f"{self.spacing}/// </{self.tag}>\n")

class GDExtensionDeprecated:
    def __init__(self, data: dict[str, Any]) -> None:
        self.since: str = data["since"]
        self.message: str | None = data.get("message")
        self.replace_with: str | None = data.get("replace_with")

    def dump(self, file: IOBase) -> None:
        file.write(f"[Obsolete(\"Deprecated since Godot {self.since}.")
        if self.message:
            file.write(f" {self.message}")
        if self.replace_with:
            file.write(f" Use {self.replace_with} instead.")
        file.write("\")]\n")

class GDExtensionType:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.description: GDExtensionDescription | None = None
        self.deprecated: GDExtensionDeprecated | None = None
        data_description: list[str] | None = data.get("description")
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        if data_description:
            self.description = GDExtensionDescription(data_description)
        if data_deprecated:
            self.deprecated = GDExtensionDeprecated(data_deprecated)

    def generate(self, copyright_text: list[str]) -> None:
        with open(f"../Source/GDExtension/{self.name}.cs", "w") as file:
            file.write("/**************************************************************************/\n")
            file.write(f"/*  {self.name}.cs  {" " * (65 - len(self.name))}*/\n")
            for line in copyright_text:
                file.write(f"{line}\n")
            file.write("\n")
            self.dump(file)

    def dump(self, file: IOBase) -> None:
        raise NotImplementedError()

class GDExtensionEnum(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.is_bitfield: bool = data.get("is_bitfield") or False
        self.values: list[GDExtensionEnumValue] = [
            GDExtensionEnumValue(value_data) for value_data in data["values"]
        ]

    def dump(self, file: IOBase) -> None:
        if self.deprecated or self.is_bitfield:
            file.write("using System;\n")
            file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if self.description:
            self.description.dump(file)
        if self.deprecated:
            self.deprecated.dump(file)
        if self.is_bitfield:
            file.write("[Flags]\n")
        file.write(f"public enum {self.name}\n")
        file.write("{\n")
        for value in self.values:
            if value.description:
                value.description.dump(file)
            file.write("    ")
            file.write(value.name)
            file.write(" = ")
            file.write(str(value.value))
            file.write(",\n")
        file.write("}\n")

class GDExtensionEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"].title().replace("_", "").replace("Gde", "GDE", 1)
        self.value: int = data["value"]
        self.description: GDExtensionDescription | None = None
        data_description: list[str] | None = data.get("description")
        if data_description:
            self.description = GDExtensionDescription(data_description, tab=True)

class GDExtensionHandle(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.parent: str | None = data.get("parent")

    def dump(self, file: IOBase) -> None:
        file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if self.description:
            self.description.dump(file)
        if self.deprecated:
            self.deprecated.dump(file)
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public readonly unsafe struct {self.name} : IEquatable<{self.name}>\n")
        file.write("{\n")
        file.write("    private readonly void* _pointer;\n")
        file.write("\n")
        file.write(f"    public {self.name}(void* pointer)\n")
        file.write("    {\n")
        file.write("        _pointer = pointer;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public void* Pointer\n")
        file.write("    {\n")
        file.write("        get => _pointer;\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public bool Equals({self.name} other)\n")
        file.write("    {\n")
        file.write("        return _pointer == other._pointer;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override bool Equals(object? obj)\n")
        file.write("    {\n")
        file.write(f"        return obj is {self.name} other && _pointer == other._pointer;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override int GetHashCode()\n")
        file.write("    {\n")
        file.write("        return new nint(_pointer).GetHashCode();\n")
        file.write("    }\n")
        if self.parent:
            file.write("\n")
            file.write(f"    public static implicit operator {self.name}({self.parent} parent)\n")
            file.write("    {\n")
            file.write(f"        return new {self.name}(parent.Pointer);\n")
            file.write("    }\n")
        file.write("\n")
        file.write(f"    public static bool operator ==({self.name} left, {self.name} right)\n")
        file.write("    {\n")
        file.write("        return left._pointer == right._pointer;\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public static bool operator !=({self.name} left, {self.name} right)\n")
        file.write("    {\n")
        file.write("        return left._pointer != right._pointer;\n")
        file.write("    }\n")
        file.write("}\n")

class GDExtensionAlias(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.type: GDExtensionTypeReference = GDExtensionTypeReference(data["type"])

    def dump(self, file: IOBase) -> None:
        file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if self.description:
            self.description.dump(file)
        if self.deprecated:
            self.deprecated.dump(file)
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public readonly struct {self.name} : IEquatable<{self.name}>\n")
        file.write("{\n")
        file.write(f"    private readonly {self.type.name} _value;\n")
        file.write("\n")
        if self.name.endswith("Bool"):
            file.write(f"    public {self.name}(bool value)\n")
            file.write("    {\n")
            file.write("        _value = (byte)(value ? 1 : 0);\n")
            file.write("    }\n")
            file.write("\n")
            file.write("    public bool Value\n")
            file.write("    {\n")
            file.write("        get => _value != 0;\n")
            file.write("    }\n")
        else:
            file.write(f"    public {self.name}({self.type.name} value)\n")
            file.write("    {\n")
            file.write("        _value = value;\n")
            file.write("    }\n")
            file.write("\n")
            file.write(f"    public {self.type.name} Value\n")
            file.write("    {\n")
            file.write("        get => _value;\n")
            file.write("    }\n")
        file.write("\n")
        file.write(f"    public bool Equals({self.name} other)\n")
        file.write("    {\n")
        file.write("        return _value == other._value;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override bool Equals(object? obj)\n")
        file.write("    {\n")
        file.write(f"        return obj is {self.name} other && _value == other._value;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override int GetHashCode()\n")
        file.write("    {\n")
        file.write("        return _value.GetHashCode();\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public static bool operator ==({self.name} left, {self.name} right)\n")
        file.write("    {\n")
        file.write("        return left._value == right._value;\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public static bool operator !=({self.name} left, {self.name} right)\n")
        file.write("    {\n")
        file.write("        return left._value != right._value;\n")
        file.write("    }\n")
        file.write("}\n")

def header(file: IOBase, name: str, _copyright: list[str]) -> None:
    file.write("/**************************************************************************/\n")
    file.write(f"/*  {name}.cs{" " * (67 - len(name))}*/\n")
    for line in _copyright:
        file.write(line)
        file.write("\n")
    file.write("\n")

def describe(file: IOBase, lines: list[str], tag: str = "summary", metadata: str = "", tab: bool = False) -> None:
    spaces: str = "    " if tab else ""
    file.write(f"{spaces}/// <{tag}")
    if metadata:
        file.write(f" {metadata}")
    file.write(">\n")
    for line in lines:
        words: list[str] = line.split(" ")
        for i, word in enumerate(words):
            word = word.replace("`NULL`", "<see langword=\"null\"/>", 1)
            word = word.replace("NULL", "<see langword=\"null\"/>", 1)
            word = word.replace("true", "<see langword=\"true\"/>", 1)
            word = word.replace("false", "<see langword=\"false\"/>", 1)
            words[i] = word
        line = " ".join(words)
        file.write(f"{spaces}/// {line}\n")
    file.write(f"{spaces}/// </{tag}>\n")

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
                self.name = "char"
            case "char32_t":
                self.name = "uint"
            case "wchar_t":
                self.name = "void"
            case "void" | "float" | "double":
                pass
            case _:
                self.is_builtin = False
        if self.is_unsafe:
            self.name += "*"

class FunctionInfo:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.description: list[str] | None = data.get("description")
        self.deprecated: dict[str, Any] | None = data.get("deprecated")
        self.arguments: list[ArgumentInfo] = []
        for i, argument in enumerate(data["arguments"]):
            argument_type: str = argument["type"]
            argument_name: str = argument.get("name")
            argument_description: list[str] | None = argument.get("description")
            if argument_name:
                argument_name = argument_name.title().replace("_", "")
                argument_name = argument_name[0].lower() + argument_name[1:]
            else:
                argument_name = f"arg{i + 1}"
            self.arguments.append(ArgumentInfo(argument_type, argument_name, argument_description))
        return_value: dict[str, Any] | None = data.get("return_value")
        if return_value:
            return_value_type: str = return_value["type"]
            return_value_description: list[str] | None = return_value.get("description")
            self.return_value: ReturnValueInfo = ReturnValueInfo(return_value_type, return_value_description)
        else:
            self.return_value: ReturnValueInfo = ReturnValueInfo("void", None)
        type_parameters: chain[str] = chain((argument.type for argument in self.arguments), [self.return_value.type])
        self.type: str = f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"
        self.parameter_list: str = ", ".join(f"{argument.type} {argument.name}" for argument in self.arguments)
        self.argument_list: str = ", ".join(argument.name for argument in self.arguments)

class ArgumentInfo:
    def __init__(self, typedef: str, name: str, description: list[str] | None) -> None:
        self.type: str = TypeInfo(typedef).name
        self.name: str = name
        self.description: list[str] | None = description

class ReturnValueInfo:
    def __init__(self, typedef: str, description: list[str] | None) -> None:
        self.type: str = TypeInfo(typedef).name
        self.description: list[str] | None = description

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
        data_description: list[str] | None = data.get("description")
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        data_is_bitfield: bool | None = data.get("is_bitfield")
        if data_deprecated or data_is_bitfield:
            file.write("using System;\n")
            file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if data_description:
            describe(file, data_description)
        if data_deprecated:
            DeprecatedGenerator.generate(file, data_deprecated)
        if data_is_bitfield:
            file.write("[Flags]\n")
        file.write(f"public enum {data_name}\n")
        file.write("{\n")
        for value in data["values"]:
            value_name: str = value["name"].title().replace("_", "").replace("Gde", "GDE", 1)
            value_value: int = value["value"]
            value_description: list[str] | None = value.get("description")
            if value_description:
                describe(file, value_description, tab=True)
            file.write(f"    {value_name} = {value_value},\n")
        file.write("}\n")

class HandleGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        data_name: str = data["name"]
        data_description: list[str] | None = data.get("description")
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        data_parent: str | None = data.get("parent")
        file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if data_description:
            describe(file, data_description)
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
        data_type: TypeInfo = TypeInfo(data["type"])
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        if not data_type.is_builtin:
            with open(f"../Source/GDExtension/{data_type.name}.cs", "r") as source_file:
                section: str = "copyright"
                for line in source_file:
                    match section:
                        case "copyright":
                            if not line.startswith("/"):
                                section = "global"
                            continue
                        case "global":
                            if line.find("Obsolete", 1) != -1:
                                if data_deprecated:
                                    DeprecatedGenerator.generate(file, data_deprecated)
                                continue
                            if line.endswith(data_type.name, 0, -1):
                                line = line.replace(data_type.name, data_name, 1)
                                section = "local"
                    file.write(line)
                return
        data_description: list[str] | None = data.get("description")
        file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if data_description:
            describe(file, data_description)
        if data_deprecated:
            DeprecatedGenerator.generate(file, data_deprecated)
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public readonly struct {data_name} : IEquatable<{data_name}>\n")
        file.write("{\n")
        file.write(f"    private readonly {data_type.name} _value;\n")
        file.write("\n")
        if data_name.endswith("Bool"):
            file.write(f"    public {data_name}(bool value)\n")
            file.write("    {\n")
            file.write("        _value = (byte)(value ? 1 : 0);\n")
            file.write("    }\n")
            file.write("\n")
            file.write("    public bool Value\n")
            file.write("    {\n")
            file.write("        get => _value != 0;\n")
            file.write("    }\n")
        else:
            file.write(f"    public {data_name}({data_type.name} value)\n")
            file.write("    {\n")
            file.write("        _value = value;\n")
            file.write("    }\n")
            file.write("\n")
            file.write(f"    public {data_type.name} Value\n")
            file.write("    {\n")
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
        data_description: list[str] | None = data.get("description")
        data_deprecated: dict[str, Any] | None = data.get("deprecated")
        if data_deprecated:
            file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if data_description:
            describe(file, data_description)
        if data_deprecated:
            DeprecatedGenerator.generate(file, data_deprecated)
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public struct {data_name}\n")
        file.write("{\n")
        for member in data["members"]:
            member_name: str = member["name"].title().replace("_", "")
            member_type: TypeInfo = TypeInfo(member["type"])
            member_description: list[str] | None = member.get("description")
            if member_description:
                describe(file, member_description, tab=True)
            file.write("    public ")
            if member_type.is_readonly:
                file.write("readonly ")
            if member_type.is_unsafe:
                file.write("unsafe ")
            file.write(f"{member_type.name} {member_name};\n")
        file.write("}\n")

class FunctionGenerator:
    @staticmethod
    def generate(file: IOBase, data: dict[str, Any]) -> None:
        function: FunctionInfo = FunctionInfo(data)
        file.write("using System;\n")
        file.write("using System.Runtime.CompilerServices;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace GDExtension;\n")
        file.write("\n")
        if function.description:
            describe(file, function.description)
        if function.deprecated:
            DeprecatedGenerator.generate(file, function.deprecated)
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
        file.write(f"    public {function.return_value.type} Invoke({function.parameter_list})\n")
        file.write("    {\n")
        if function.return_value.type == "void":
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
        for field_name, function in fields.items():
            file.write("\n")
            if function.description:
                describe(file, function.description, tab=True)
            for argument in function.arguments:
                if argument.description:
                    describe(file, argument.description, tag="param", metadata=f"name=\"{argument.name}\"", tab=True)
            if function.return_value.description:
                describe(file, function.return_value.description, tag="returns", tab=True)
            if function.deprecated:
                file.write("    ")
                DeprecatedGenerator.generate(file, function.deprecated)
            file.write("    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n")
            file.write(f"    public static {function.return_value.type} {field_name[2].upper() + field_name[3:]}({function.parameter_list})\n")
            file.write("    {\n")
            if function.return_value.type == "void":
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
