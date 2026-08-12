from csharp import *
from os.path import commonprefix
from typing import Any

def parse(data: dict[str, Any]) -> SourceGenerator:
    generator: SourceGenerator = SourceGenerator()
    generator.namespace = "Godot.Interop"
    generator.output_directory = "../Source/Interop"
    generator.expand("GDExtensionStringPtr", "GDExtensionString*")
    generator.expand("GDExtensionConstStringPtr", "GDExtensionString*")
    generator.expand("GDExtensionUninitializedStringPtr", "GDExtensionString*")
    generator.expand("GDExtensionStringNamePtr", "GDExtensionStringName*")
    generator.expand("GDExtensionConstStringNamePtr", "GDExtensionStringName*")
    generator.expand("GDExtensionUninitializedStringNamePtr", "GDExtensionStringName*")
    generator.expand("GDExtensionVariantPtr", "GDExtensionVariant*")
    generator.expand("GDExtensionConstVariantPtr", "GDExtensionVariant*")
    generator.expand("GDExtensionUninitializedVariantPtr", "GDExtensionVariant*")
    generator.expand("GDExtensionBool", "bool")
    generator.expand("GDExtensionInterfaceFunctionPtr", "void*")
    for type_data in data["types"]:
        match type_data["kind"]:
            case "enum":
                enum(generator, type_data)
            case "handle":
                handle(generator, type_data)
            case "alias":
                alias(generator, type_data)
            case "struct":
                struct(generator, type_data)
            case "function":
                function(generator, type_data)
    return generator

def initialize(info: TypeInfo, data: dict[str, Any]) -> None:
    info.name = data["name"]
    info.description = data.get("description", info.description)
    deprecated: dict[str, str] | None = data.get("deprecated")
    if deprecated:
        since: str = deprecated["since"]
        message: str | None = deprecated.get("message")
        replace_with: str | None = deprecated.get("replace_with")
        sentences: list[str] = [f"Deprecated since Godot {since}."]
        if message:
            sentences.append(message)
        if replace_with:
            sentences.append(f"Use `{replace_with}` instead.")
        argument: str = " ".join(sentences)
        info.attributes.add(f"Obsolete(\"{argument}\")")
        info.dependencies.add("System")

def enum(generator: SourceGenerator, data: dict[str, Any]) -> None:
    enumeration: EnumerationInfo = EnumerationInfo()
    initialize(enumeration, data)
    if data.get("is_bitfield"):
        enumeration.underlying_type = "uint"
        enumeration.dependencies.add("System")
        enumeration.attributes.add("Flags")
    for member_data in data["values"]:
        member: EnumerationConstantInfo = EnumerationConstantInfo()
        member.name = member_data["name"]
        member.value = member_data["value"]
        member.description = member_data.get("description", member.description)
        enumeration.members.append(member)
    prefix: str = commonprefix([member.name for member in enumeration.members])
    for member in enumeration.members:
        if "MAX" in member.name:
            generator.translate(member.name, "Max")
        else:
            replacement: str = pascal(member.name.removeprefix(prefix)) \
                .removeprefix("Error") \
                .removeprefix("Initialization") \
                .replace("SD", "D", 1) \
                .replace("Uint", "UInt", 1)
            generator.translate(member.name, replacement)
    generator.register(enumeration)

def handle(generator: SourceGenerator, data: dict[str, Any]) -> None:
    handle_name: str = data["name"]
    generator.expand_default(handle_name, "void*")

def alias(generator: SourceGenerator, data: dict[str, Any]) -> None:
    alias_name: str = data["name"]
    alias_type: str = data["type"]
    generator.expand_default(alias_name, alias_type)

def struct(generator: SourceGenerator, data: dict[str, Any]) -> None:
    structure: StructureInfo = StructureInfo()
    initialize(structure, data)
    structure.is_unsafe = structure.name != "GDExtensionCallError"
    structure.dependencies.add("System.Runtime.InteropServices")
    structure.attributes.add("StructLayout(LayoutKind.Sequential)")
    for member_data in data["members"]:
        member: StructureFieldInfo = StructureFieldInfo()
        member.name = member_data["name"]
        if member.name == "method_flags":
            member.type = "GDExtensionClassMethodFlags"
        else:
            member.type = member_data["type"]
        member.description = member_data.get("description", member.description)
        structure.members.append(member)
        generator.translate(member.name, pascal(preprocess(member.name)))
    generator.register(structure)

def function(generator: SourceGenerator, data: dict[str, Any]) -> None:
    function_name: str = data["name"]
    function_return_value: dict[str, Any] | None = data.get("return_value")
    type_parameters: list[str] = [argument["type"] for argument in data["arguments"]]
    if function_return_value:
        type_parameters.append(function_return_value["type"])
    else:
        type_parameters.append("void")
    arguments: str = ", ".join(type_parameters)
    generator.expand_default(function_name, f"delegate* unmanaged[Cdecl]<{arguments}>")

def preprocess(symbol: str) -> str:
    def substitute(match: Match[str]) -> str:
        group: str = match.group()
        match group:
            case "ptrcall":
                return "ptr_call"
            case "userdata":
                return "user_data"
            case "refcount":
                return "ref_count"
            case "classdb":
                return "class_d_b"
            case "classname":
                return "class_name"
            case "methodname":
                return "method_name"
            case _:
                return group

    return sub(r"[a-z]+", substitute, symbol)
