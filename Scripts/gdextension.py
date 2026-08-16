from csharp import *
from os.path import commonprefix
from typing import Any, Iterable, Optional

def parse(data: dict[str, Any]) -> SourceGenerator:
    generator: SourceGenerator = SourceGenerator("Godot.Interop", "../Source/Interop")
    generator.set_expansion("GDExtensionStringPtr", "GDExtensionString*")
    generator.set_expansion("GDExtensionConstStringPtr", "GDExtensionString*")
    generator.set_expansion("GDExtensionUninitializedStringPtr", "GDExtensionString*")
    generator.set_expansion("GDExtensionStringNamePtr", "GDExtensionStringName*")
    generator.set_expansion("GDExtensionConstStringNamePtr", "GDExtensionStringName*")
    generator.set_expansion("GDExtensionUninitializedStringNamePtr", "GDExtensionStringName*")
    generator.set_expansion("GDExtensionVariantPtr", "GDExtensionVariant*")
    generator.set_expansion("GDExtensionConstVariantPtr", "GDExtensionVariant*")
    generator.set_expansion("GDExtensionUninitializedVariantPtr", "GDExtensionVariant*")
    generator.set_expansion("GDExtensionBool", "bool")
    generator.set_expansion("GDExtensionInterfaceFunctionPtr", "void*")
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
    interface(generator, data)
    return generator

def enum(generator: SourceGenerator, data: dict[str, Any]) -> None:
    enumeration: EnumerationInfo = EnumerationInfo()
    type_initialize(enumeration, data)
    if data.get("is_bitfield"):
        enumeration.underlying_type = "uint"
        enumeration.dependencies.add("System")
        enumeration.attributes.add("Flags")
    for member_data in data["values"]:
        member: ConstantInfo = ConstantInfo()
        member.name = member_data["name"]
        member.value = member_data["value"]
        if description := member_data.get("description"):
            member.documentation.description = documentation(description)
        enumeration.members.append(member)
    prefix: str = commonprefix([member.name for member in enumeration.members])
    for member in enumeration.members:
        if "MAX" in member.name:
            generator.set_translation(member.name, "Max")
        else:
            replacement: str = pascal(member.name.removeprefix(prefix)) \
                .removeprefix("Error") \
                .removeprefix("Initialization") \
                .replace("SD", "D", 1) \
                .replace("Uint", "UInt", 1)
            generator.set_translation(member.name, replacement)
    generator.add_type(enumeration)

def handle(generator: SourceGenerator, data: dict[str, Any]) -> None:
    handle_name: str = data["name"]
    generator.set_expansion(handle_name, "void*")

def alias(generator: SourceGenerator, data: dict[str, Any]) -> None:
    alias_name: str = data["name"]
    alias_type: str = data["type"]
    generator.set_expansion(alias_name, alias_type)

def struct(generator: SourceGenerator, data: dict[str, Any]) -> None:
    structure: ClassInfo = ClassInfo()
    type_initialize(structure, data)
    structure.is_value_type = True
    structure.is_unsafe = structure.name != "GDExtensionCallError"
    structure.dependencies.add("System.Runtime.InteropServices")
    structure.attributes.add("StructLayout(LayoutKind.Sequential)")
    for field_data in data["members"]:
        field: FieldInfo = FieldInfo()
        field.name = field_data["name"]
        if field.name == "method_flags":
            field.type = "GDExtensionClassMethodFlags"
        else:
            field.type = field_data["type"]
        if description := field_data.get("description"):
            field.documentation.description = documentation(description)
        structure.fields.append(field)
        generator.set_translation(field.name, pascal(preprocess(field.name)))
    generator.add_type(structure)

def function(generator: SourceGenerator, data: dict[str, Any]) -> None:
    function_name: str = data["name"]
    function_return_value: Optional[dict[str, Any]] = data.get("return_value")
    type_parameters: list[str] = [argument["type"] for argument in data["arguments"]]
    if function_return_value:
        type_parameters.append(function_return_value["type"])
    else:
        type_parameters.append("void")
    arguments: str = ", ".join(type_parameters)
    generator.set_expansion(function_name, f"delegate* unmanaged[Cdecl]<{arguments}>")

def interface(generator: SourceGenerator, data: dict[str, Any]) -> None:
    info: ClassInfo = ClassInfo()
    info.dependencies.add("System")
    info.dependencies.add("System.Diagnostics.CodeAnalysis")
    info.dependencies.add("System.Runtime.CompilerServices")
    info.documentation.description = ("Exposes functions from the GDExtension API.",)
    info.name = "GDExtensionInterface"
    info.is_static = True
    info.is_unsafe = True
    info.methods.append(interface_initialize(generator, info))
    for interface_data in data["interface"]:
        field, method = interface_delegate(generator, interface_data)
        info.fields.append(field)
        info.methods.append(method)
    info.methods.append(interface_load(generator))
    info.methods.append(interface_throw_if_invalid(generator))
    info.methods.append(interface_throw_for_invalid_function())
    generator.add_type(info)

def type_initialize(info: TypeInfo, data: dict[str, Any]) -> None:
    info.name = data["name"]
    if description := data.get("description", ()):
        info.documentation.description = documentation(description)
    deprecated: Optional[dict[str, str]] = data.get("deprecated")
    if deprecated:
        info.attributes.add(obsolete(deprecated))
        info.dependencies.add("System")

def interface_initialize(generator: SourceGenerator, info: ClassInfo) -> MethodInfo:
    def method_body() -> Iterable[str]:
        yield "ArgumentNullException.ThrowIfNull(pGetProcAddress);"
        for field, delegate in zip(info.fields, info.methods[1:]):
            yield f"{field.name} = ({generator.get_expansion(field.type)})Load(pGetProcAddress, \"{delegate.name}\"u8);"

    method: MethodInfo = MethodInfo()
    method.name = "Initialize"
    method.is_static = True
    method.body = method_body()
    method.documentation.description = ("Loads the GDExtensionInterface functions from the specified address loader.",)
    parameter: ParameterInfo = ParameterInfo()
    parameter.name = "pGetProcAddress"
    parameter.type = "GDExtensionInterfaceGetProcAddress"
    parameter.documentation.description = ("The address loader provided by the Godot Engine.",)
    method.parameters.append(parameter)
    exception: ExceptionInfo = ExceptionInfo()
    exception.name = "ArgumentNullException"
    exception.documentation.description = ("<paramref name=\"pGetProcAddress\"/> is <see langword=\"null\"/>.",)
    method.exceptions.append(exception)
    return method

def interface_delegate(generator: SourceGenerator, data: dict[str, Any]) -> tuple[FieldInfo, MethodInfo]:
    def method_body() -> Iterable[str]:
        yield f"{generator.get_expansion(field.type)} function = {field.name};"
        yield "ThrowIfInvalid(function);"
        arguments: str = ", ".join(generator.get_translation(argument.name) for argument in method.parameters)
        if method.return_type.name == "void":
            yield f"function({arguments});"
        else:
            yield f"return function({arguments});"

    method: MethodInfo = MethodInfo()
    method.name = data["name"]
    method.attributes.add("MethodImpl(MethodImplOptions.AggressiveInlining)")
    if description := data.get("description"):
        method.documentation.description = documentation(description)
    method.body = method_body()
    method.is_static = True
    deprecated: Optional[dict[str, str]] = data.get("deprecated")
    return_type_data: Optional[dict[str, Any]] = data.get("return_value")
    if deprecated:
        method.attributes.add(obsolete(deprecated))
    if return_type_data:
        method.return_type.name = return_type_data["type"]
        if description := return_type_data.get("description"):
            method.return_type.documentation.description = documentation(description)
    for parameter_data in data["arguments"]:
        parameter: ParameterInfo = ParameterInfo()
        parameter.name = parameter_data["name"]
        parameter.type = parameter_data["type"]
        if description := parameter_data.get("description"):
            parameter.documentation.description = documentation(description)
        method.parameters.append(parameter)
        generator.set_translation(parameter.name, camel(preprocess(parameter.name)))
    type_parameters: str = ", ".join([parameter.type for parameter in method.parameters] + [method.return_type.name])
    field: FieldInfo = FieldInfo()
    field.name = f"s_{camel(preprocess(method.name))}"
    field.type = f"delegate* unmanaged[Cdecl]<{type_parameters}>"
    field.is_public = False
    field.is_static = True
    generator.set_translation(method.name, pascal(preprocess(method.name)))
    return field, method

def interface_load(generator: SourceGenerator) -> MethodInfo:
    def method_body() -> Iterable[str]:
        yield "fixed (byte* functionName = pFunctionName)"
        yield "{"
        with generator.indent():
            yield "return pGetProcAddress(functionName);"
        yield "}"

    method: MethodInfo = MethodInfo()
    method.name = "Load"
    method.body = method_body()
    method.is_public = False
    method.is_static = True
    method.return_type.name = "void*"
    parameter1: ParameterInfo = ParameterInfo()
    parameter1.name = "pGetProcAddress"
    parameter1.type = "GDExtensionInterfaceGetProcAddress"
    parameter2: ParameterInfo = ParameterInfo()
    parameter2.name = "pFunctionName"
    parameter2.type = "ReadOnlySpan<byte>"
    method.parameters.append(parameter1)
    method.parameters.append(parameter2)
    return method

def interface_throw_if_invalid(generator: SourceGenerator) -> MethodInfo:
    def method_body() -> Iterable[str]:
        yield "if (pFunction == null)"
        yield "{"
        with generator.indent():
            yield "ThrowForInvalidFunction();"
        yield "}"

    method: MethodInfo = MethodInfo()
    method.name = "ThrowIfInvalid"
    method.body = method_body()
    method.is_public = False
    method.is_static = True
    parameter: ParameterInfo = ParameterInfo()
    parameter.name = "pFunction"
    parameter.type = "void*"
    method.parameters.append(parameter)
    return method

def interface_throw_for_invalid_function() -> MethodInfo:
    method: MethodInfo = MethodInfo()
    method.name = "ThrowForInvalidFunction"
    method.body = ("throw new InvalidOperationException(\"Unable to call the specified function.\");",)
    method.is_public = False
    method.is_static = True
    return method

def obsolete(data: dict[str, str]) -> str:
    since: str = data["since"]
    message: Optional[str] = data.get("message")
    replace_with: Optional[str] = data.get("replace_with")
    sentences: list[str] = [f"Deprecated since Godot {since}."]
    if message:
        sentences.append(message)
    if replace_with:
        sentences.append(f"Use `{replace_with}` instead.")
    argument: str = " ".join(sentences)
    return f"Obsolete(\"{argument}\")"

def documentation(description: list[str]) -> Iterable[str]:
    last_line: str = description[-1]
    for line in description:
        separator: str = "<br/>" * (line is not last_line)
        yield line + separator

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
