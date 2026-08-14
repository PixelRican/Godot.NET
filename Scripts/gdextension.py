from csharp import *
from os.path import commonprefix
from typing import Any, Iterable, Optional

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
    generator.expand(handle_name, "void*")

def alias(generator: SourceGenerator, data: dict[str, Any]) -> None:
    alias_name: str = data["name"]
    alias_type: str = data["type"]
    generator.expand(alias_name, alias_type)

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
        field.description = field_data.get("description", field.description)
        structure.fields.append(field)
        generator.translate(field.name, pascal(preprocess(field.name)))
    generator.register(structure)

def function(generator: SourceGenerator, data: dict[str, Any]) -> None:
    function_name: str = data["name"]
    function_return_value: Optional[dict[str, Any]] = data.get("return_value")
    type_parameters: list[str] = [argument["type"] for argument in data["arguments"]]
    if function_return_value:
        type_parameters.append(function_return_value["type"])
    else:
        type_parameters.append("void")
    arguments: str = ", ".join(type_parameters)
    generator.expand(function_name, f"delegate* unmanaged[Cdecl]<{arguments}>")

def interface(generator: SourceGenerator, data: dict[str, Any]) -> None:
    info: ClassInfo = ClassInfo()
    info.dependencies.add("System")
    info.dependencies.add("System.Diagnostics.CodeAnalysis")
    info.dependencies.add("System.Runtime.CompilerServices")
    info.description.append("Exposes functions from the GDExtension API.")
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
    generator.register(info)

def type_initialize(info: TypeInfo, data: dict[str, Any]) -> None:
    info.name = data["name"]
    info.description = data.get("description", info.description)
    deprecated: Optional[dict[str, str]] = data.get("deprecated")
    if deprecated:
        info.attributes.add(obsolete(deprecated))
        info.dependencies.add("System")

def interface_initialize(generator: SourceGenerator, info: ClassInfo) -> MethodInfo:
    def method_body() -> Iterable[str]:
        yield "ArgumentNullException.ThrowIfNull(pGetProcAddress);"
        for field, delegate in zip(info.fields, info.methods[1:]):
            yield f"{field.name} = ({generator.expansion(field.type)})Load(pGetProcAddress, \"{delegate.name}\"u8);"

    method: MethodInfo = MethodInfo()
    method.name = "Initialize"
    method.is_static = True
    method.body = method_body()
    method.description.append("Loads the GDExtensionInterface functions from the specified address loader.")
    parameter: ParameterInfo = ParameterInfo()
    parameter.name = "pGetProcAddress"
    parameter.type = "GDExtensionInterfaceGetProcAddress"
    parameter.description.append("The address loader provided by the Godot Engine.")
    method.parameters.append(parameter)
    exception: ExceptionInfo = ExceptionInfo()
    exception.name = "ArgumentNullException"
    exception.description.append("<paramref name=\"pGetProcAddress\"/> is <see langword=\"null\"/>.")
    method.exceptions.append(exception)
    return method

def interface_delegate(generator: SourceGenerator, data: dict[str, Any]) -> tuple[FieldInfo, MethodInfo]:
    def method_body() -> Iterable[str]:
        yield f"{generator.expansion(field.type)} function = {field.name};"
        yield "ThrowIfInvalid(function);"
        arguments: str = ", ".join(generator.translation(argument.name) for argument in method.parameters)
        if method.return_type.name == "void":
            yield f"function({arguments});"
        else:
            yield f"return function({arguments});"

    method: MethodInfo = MethodInfo()
    method.name = data["name"]
    method.attributes.add("MethodImpl(MethodImplOptions.AggressiveInlining)")
    method.description = data.get("description", method.description)
    method.body = method_body()
    method.is_static = True
    deprecated: Optional[dict[str, str]] = data.get("deprecated")
    return_type_data: Optional[dict[str, Any]] = data.get("return_value")
    if deprecated:
        method.attributes.add(obsolete(deprecated))
    if return_type_data:
        method.return_type.name = return_type_data["type"]
        method.return_type.description = return_type_data.get("description", method.return_type.description)
    for parameter_data in data["arguments"]:
        parameter: ParameterInfo = ParameterInfo()
        parameter.name = parameter_data["name"]
        parameter.type = parameter_data["type"]
        parameter.description = parameter_data.get("description", parameter.description)
        method.parameters.append(parameter)
        generator.translate(parameter.name, camel(preprocess(parameter.name)))
    type_parameters: str = ", ".join([parameter.type for parameter in method.parameters] + [method.return_type.name])
    field: FieldInfo = FieldInfo()
    field.name = f"s_{camel(preprocess(method.name))}"
    field.type = f"delegate* unmanaged[Cdecl]<{type_parameters}>"
    field.access_modifier = "private"
    field.is_static = True
    generator.translate(method.name, pascal(preprocess(method.name)))
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
    method.access_modifier = "private"
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
    method.access_modifier = "private"
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
    method.access_modifier = "private"
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
