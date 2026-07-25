from copy import copy
from io import IOBase
from itertools import chain
from typing import Any, Iterable

class GDExtensionInterface:
    def __init__(self, data: dict[str, Any]) -> None:
        self.copyright: str = "\n".join(data["_copyright"]) + "\n\n"
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
                    alias: GDExtensionAlias = GDExtensionAlias(type_data)
                    if alias.type.is_builtin:
                        instance = alias
                    else:
                        instance = copy(self.types[alias.type.name])
                        instance.name = alias.name
                        instance.description = alias.description
                        instance.deprecated = alias.deprecated
                case "struct":
                    instance = GDExtensionStruct(type_data)
                case "function":
                    instance = GDExtensionFunction(type_data)
            assert instance
            self.types[instance.name] = instance
        for function_data in data["interface"]:
            function: GDExtensionFunction = GDExtensionFunction(function_data)
            assert function.entry_point
            self.interface[function.entry_point] = function

    def generate(self) -> None:
        for instance in chain(self.types.values(), self.interface.values()):
            with open(f"../Source/Godot.GDExtension/{instance.name}.cs", "w") as file:
                file.write("/**************************************************************************/\n")
                file.write(f"/*  {instance.name}.cs  {" " * (65 - len(instance.name))}*/\n")
                file.write(self.copyright)
                instance.dump(file)

class GDExtensionSymbol:
    def __init__(self, name: str) -> None:
        self.name: str
        self.is_readonly: bool = name.startswith("const")
        self.is_unsafe: bool = name.endswith("*")
        self.is_builtin: bool = True
        start: int = 6 if self.is_readonly else 0
        end: int = -1 if self.is_unsafe else len(name)
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
            case "void" | "float" | "double":
                pass
            case _:
                self.is_builtin = False
        if self.is_unsafe:
            self.name += "*"

class GDExtensionDescription:
    def __init__(self, lines: list[str], tag: str = "summary", metadata: str = "", indent: bool = False) -> None:
        self.lines: list[str] = lines
        self.tag: str = tag
        self.metadata: str = metadata
        self.spacing: str = " " * 4 if indent else ""

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
        description: list[str] | None = data.get("description")
        deprecated: dict[str, Any] | None = data.get("deprecated")
        if description:
            self.description = GDExtensionDescription(description)
        if deprecated:
            self.deprecated = GDExtensionDeprecated(deprecated)

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
        file.write("namespace Godot.GDExtension;\n")
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
            file.write(f"    {value.name} = {value.value},\n")
        file.write("}\n")

class GDExtensionEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description, indent=True)

class GDExtensionHandle(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.parent: str | None = data.get("parent")

    def dump(self, file: IOBase) -> None:
        file.write("using System;\n")
        file.write("using System.Diagnostics.CodeAnalysis;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace Godot.GDExtension;\n")
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
        file.write("    public void* Pointer => _pointer;\n")
        file.write("\n")
        file.write(f"    public bool Equals({self.name} other)\n")
        file.write("    {\n")
        file.write("        return _pointer == other._pointer;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override bool Equals([NotNullWhen(true)] object? obj)\n")
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
        self.type: GDExtensionSymbol = GDExtensionSymbol(data["type"])

    def dump(self, file: IOBase) -> None:
        file.write("using System;\n")
        file.write("using System.Diagnostics.CodeAnalysis;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace Godot.GDExtension;\n")
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
            file.write("    public bool Value => _value != 0;\n")
        else:
            file.write(f"    public {self.name}({self.type.name} value)\n")
            file.write("    {\n")
            file.write("        _value = value;\n")
            file.write("    }\n")
            file.write("\n")
            file.write(f"    public {self.type.name} Value => _value;\n")
        file.write("\n")
        file.write(f"    public bool Equals({self.name} other)\n")
        file.write("    {\n")
        file.write("        return _value == other._value;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override bool Equals([NotNullWhen(true)] object? obj)\n")
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

class GDExtensionStruct(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.members: list[GDExtensionStructMember] = [
            GDExtensionStructMember(member_data) for member_data in data["members"]
        ]

    def dump(self, file: IOBase) -> None:
        if self.deprecated:
            file.write("using System;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace Godot.GDExtension;\n")
        file.write("\n")
        if self.description:
            self.description.dump(file)
        if self.deprecated:
            self.deprecated.dump(file)
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public struct {self.name}\n")
        file.write("{\n")
        for member in self.members:
            if member.description:
                member.description.dump(file)
            file.write("    public ")
            if member.type.is_readonly:
                file.write("readonly ")
            if member.type.is_unsafe:
                file.write("unsafe ")
            file.write(f"{member.type.name} {member.name};\n")
        file.write("}\n")

class GDExtensionStructMember:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        if self.name == "string":
            self.name = "@string"
        self.type: GDExtensionSymbol = GDExtensionSymbol(data["type"])
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description, indent=True)

class GDExtensionFunction(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.entry_point: str | None = None
        if self.name[0].islower():
            self.entry_point = self.name
            self.name = "GDExtensionInterface" + self.name.title().replace("_", "")
        self.arguments: list[GDExtensionFunctionArgument] = []
        self.return_value: GDExtensionFunctionReturnValue | None = None
        type_parameters: list[str] = []
        for i, argument_data in enumerate(data["arguments"]):
            if not argument_data.get("name"):
                argument_data = argument_data.copy()
                argument_data["name"] = f"p_{i}"
            argument: GDExtensionFunctionArgument = GDExtensionFunctionArgument(argument_data)
            type_parameters.append(argument.type.name)
            self.arguments.append(argument)
        return_value_data: dict[str, Any] | None = data.get("return_value")
        argument_iterable: Iterable[str] = (argument.type.name for argument in self.arguments)
        return_iterable: Iterable[str]
        if return_value_data:
            return_value: GDExtensionFunctionReturnValue = GDExtensionFunctionReturnValue(return_value_data)
            return_iterable = (return_value.type.name,)
            self.return_value = return_value
        else:
            return_iterable = ("void",)
        type_parameters: chain[str] = chain(argument_iterable, return_iterable)
        self.type: str = f"delegate* unmanaged[Cdecl]<{", ".join(type_parameters)}>"
        self.parameter_list: str = ", ".join(f"{argument.type.name} {argument.name}" for argument in self.arguments)
        self.argument_list: str = ", ".join(argument.name for argument in self.arguments)

    def dump(self, file: IOBase) -> None:
        file.write("using System;\n")
        file.write("using System.Diagnostics.CodeAnalysis;\n")
        file.write("using System.Runtime.CompilerServices;\n")
        file.write("using System.Runtime.InteropServices;\n")
        file.write("\n")
        file.write("namespace Godot.GDExtension;\n")
        file.write("\n")
        if self.description:
            self.description.dump(file)
        if self.deprecated:
            self.deprecated.dump(file)
        file.write("[StructLayout(LayoutKind.Sequential)]\n")
        file.write(f"public readonly unsafe struct {self.name} : IEquatable<{self.name}>\n")
        file.write("{\n")
        file.write(f"    private readonly {self.type} _method;\n")
        file.write("\n")
        file.write(f"    public {self.name}({self.type} method)\n")
        file.write("    {\n")
        file.write("        _method = method;\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public {self.type} Method => _method;\n")
        file.write("\n")
        for argument in self.arguments:
            if argument.description:
                argument.description.dump(file)
        if self.return_value and self.return_value.description:
            self.return_value.description.dump(file)
        file.write("    [MethodImpl(MethodImplOptions.AggressiveInlining)]\n")
        if self.return_value:
            file.write(f"    public {self.return_value.type.name} Invoke({self.parameter_list})\n")
            file.write("    {\n")
            file.write(f"        return _method({self.argument_list});\n")
            file.write("    }\n")
        else:
            file.write(f"    public void Invoke({self.parameter_list})\n")
            file.write("    {\n")
            file.write(f"        _method({self.argument_list});\n")
            file.write("    }\n")
        file.write("\n")
        file.write(f"    public bool Equals({self.name} other)\n")
        file.write("    {\n")
        file.write("        return _method == other._method;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override bool Equals([NotNullWhen(true)] object? obj)\n")
        file.write("    {\n")
        file.write(f"        return obj is {self.name} other && _method == other._method;\n")
        file.write("    }\n")
        file.write("\n")
        file.write("    public override int GetHashCode()\n")
        file.write("    {\n")
        file.write("        return new nint(_method).GetHashCode();\n")
        file.write("    }\n")
        if self.entry_point:
            file.write("\n")
            file.write(f"    public static explicit operator {self.name}(GDExtensionInterfaceFunctionPtr function)\n")
            file.write("    {\n")
            file.write(f"        return new {self.name}(({self.type})function.Method);\n")
            file.write("    }\n")
        file.write("\n")
        file.write(f"    public static bool operator ==({self.name} left, {self.name} right)\n")
        file.write("    {\n")
        file.write("        return left._method == right._method;\n")
        file.write("    }\n")
        file.write("\n")
        file.write(f"    public static bool operator !=({self.name} left, {self.name} right)\n")
        file.write("    {\n")
        file.write("        return left._method != right._method;\n")
        file.write("    }\n")
        file.write("}\n")

class GDExtensionFunctionArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: GDExtensionSymbol = GDExtensionSymbol(data["type"])
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description, tag="param", metadata=f"name=\"{self.name}\"", indent=True)

class GDExtensionFunctionReturnValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.type: GDExtensionSymbol = GDExtensionSymbol(data["type"])
        self.description: GDExtensionDescription | None = None
        description: list[str] | None = data.get("description")
        if description:
            self.description = GDExtensionDescription(description, tag="returns", indent=True)
