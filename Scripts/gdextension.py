from abc import ABC, abstractmethod
from csharp import *
from itertools import chain
from os.path import commonprefix
from re import Match, sub
from typing import Any, Generator, Optional


class GDExtensionStylizer:
    def __init__(self) -> None:
        self.__expansions: dict[str, str] = {
            "int8_t": "sbyte",
            "uint8_t": "byte",
            "int16_t": "short",
            "uint16_t": "ushort",
            "int32_t": "int",
            "uint32_t": "uint",
            "int64_t": "long",
            "uint64_t": "ulong",
            "size_t": "nuint",
            "char": "byte",
            "char16_t": "char",
            "char32_t": "uint",
            "wchar_t": "void",
            "GDExtensionStringPtr": "GDExtensionString*",
            "GDExtensionStringNamePtr": "GDExtensionStringName*",
            "GDExtensionVariantPtr": "GDExtensionVariant*",
            "GDExtensionBool": "bool",
            "GDExtensionInterfaceFunctionPtr": "void*"
        }
        self.__translations: dict[str, str] = {"NULL": "null"}

    def get_expansion(self, alias: str) -> str:
        def substitute(match: Match[str]) -> str:
            group: str = match.group(1)
            substitution: str = self.get_expansion(group)
            return match.group().replace(group, substitution)

        pointer: str = "*" * alias.endswith("*")
        key: str = alias.removeprefix("const ").removesuffix("*")
        if key.endswith(">"):
            return sub(r"(?:<|,\s)((?:const )?\w+\*?)", substitute, key) + pointer
        value: str = self.__expansions.get(key, key)
        if value in (key, "char"):
            return value + pointer
        return self.get_expansion(value) + pointer

    def set_expansion(self, alias: str, value: str) -> None:
        self.__expansions.setdefault(alias, value)

    def get_translation(self, string: str) -> str:
        def substitute(match: Match[str]) -> str:
            group: str = match.group()
            result: str = "{}"
            if group.startswith("`"):
                group = match.group(1)
                result = "`{}`"
            return result.format(self.__translations.get(group, group))

        return self.__translations.get(string) \
            or sub(r"`(\w+)`|([A-Z]{4,}+(_[A-Z]+)*)|([a-z]+(_[a-z]+)+)", substitute, string)

    def set_translation(self, string: str, value: str) -> None:
        self.__translations.setdefault(string, value)

    def translate(self, description: Optional[tuple[str, ...]]) -> Generator[str]:
        for line in description or ():
            separator: str = "<br/>" * (line is not description[-1])
            yield self.get_translation(line) + separator


class GDExtensionInterface:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__copyright: tuple[str, ...] = tuple(data["_copyright"])
        self.__schema: str = data["$schema"]
        self.__format_version: int = data["format_version"]
        self.__types: tuple[GDExtensionType, ...] = tuple(map(GDExtensionType.create, data["types"]))
        self.__interface: tuple[GDExtensionInterfaceFunction, ...] = tuple(map(GDExtensionInterfaceFunction, data["interface"]))

    @property
    def copyright(self) -> tuple[str, ...]:
        return self.__copyright

    @property
    def schema(self) -> str:
        return self.__schema

    @property
    def format_version(self) -> int:
        return self.__format_version

    @property
    def types(self) -> tuple[GDExtensionType, ...]:
        return self.__types

    @property
    def interface(self) -> tuple[GDExtensionInterfaceFunction, ...]:
        return self.__interface

    def to_csharp(self, stylizer: GDExtensionStylizer) -> CSharpStructure:
        def load_statement(pair: tuple[CSharpField, GDExtensionInterfaceFunction]) -> str:
            field, interface = pair
            return f"{field.name} = ({field.type})Load(pGetProcAddress, \"{interface.name}\"u8);"

        fields: tuple[CSharpField, ...]
        methods: tuple[CSharpMethod, ...]
        fields, methods = zip(*(interface.to_csharp(stylizer) for interface in self.interface))
        return CSharpStructure(
            name="GDExtensionInterface",
            fields=fields,
            methods=(
                CSharpMethod(
                    name="Initialize",
                    parameters=(
                        CSharpParameter(
                            name="pGetProcAddress",
                            type=stylizer.get_expansion("GDExtensionInterfaceGetProcAddress"),
                            description=(
                                "The address loader provided by the Godot Engine.",
                            ),
                        ),
                    ),
                    return_type=CSharpReturnType("void"),
                    exceptions=(
                        CSharpException(
                            name="ArgumentNullException",
                            description=(
                                "<paramref name=\"pGetProcAddress\"/> is <see langword=\"null\"/>.",
                            )
                        ),
                    ),
                    body=(
                        "ArgumentNullException.ThrowIfNull(pGetProcAddress);",
                        *map(load_statement, zip(fields, self.interface))
                    ),
                    description=(
                        "Loads the GDExtensionInterface functions from the specified address loader.",
                    ),
                    is_static=True
                ),
                *methods,
                CSharpMethod(
                    name="Load",
                    parameters=(
                        CSharpParameter(
                            name="pGetProcAddress",
                            type=stylizer.get_expansion("GDExtensionInterfaceGetProcAddress")
                        ),
                        CSharpParameter(
                            name="pFunctionName",
                            type="ReadOnlySpan<byte>"
                        )
                    ),
                    return_type=CSharpReturnType("void*"),
                    exceptions=(),
                    body=(
                        "fixed (byte* functionName = pFunctionName)",
                        "{",
                        indent("return pGetProcAddress(functionName);"),
                        "}"
                    ),
                    is_public=False,
                    is_static=True
                ),
                CSharpMethod(
                    name="ThrowIfInvalid",
                    parameters=(
                        CSharpParameter(
                            name="pFunction",
                            type="void*"
                        ),
                    ),
                    return_type=CSharpReturnType("void"),
                    exceptions=(),
                    body=(
                        "if (pFunction == null)",
                        "{",
                        indent("ThrowForInvalidFunction();"),
                        "}"
                    ),
                    is_public=False,
                    is_static=True
                ),
                CSharpMethod(
                    name="ThrowForInvalidFunction",
                    parameters=(),
                    return_type=CSharpReturnType("void"),
                    exceptions=(),
                    body=(
                        "throw new InvalidOperationException(\"Unable to call the specified function.\");",
                    ),
                    attributes=(
                        CSharpAttribute("DoesNotReturn"),
                    ),
                    is_public=False,
                    is_static=True
                )
            ),
            description=(
                "Exposes functions from the GDExtension API.",
            ),
            dependencies=(
                "System",
                "System.Diagnostics.CodeAnalysis",
                "System.Runtime.CompilerServices"
            ),
            is_static=True,
            is_unsafe=True
        )

    def dump(self, namespace: str, directory: str) -> None:
        def predicate(instance: GDExtensionType) -> bool:
            return isinstance(instance, (GDExtensionEnumeration, GDExtensionStructure))

        stylizer: GDExtensionStylizer = GDExtensionStylizer()
        for instance in chain(self.types, self.interface):
            instance.stylize(stylizer)
        types: chain[CSharpType] = chain(
            (instance.to_csharp(stylizer) for instance in filter(predicate, self.types)),
            (self.to_csharp(stylizer),)
        )
        dump(types, namespace, directory)


class GDExtensionDeprecated:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__since: str = data["since"]
        self.__message: Optional[str] = data.get("message")
        self.__replace_with: Optional[str] = data.get("replace_with")

    @property
    def since(self) -> str:
        return self.__since

    @property
    def message(self) -> Optional[str]:
        return self.__message

    @property
    def replace_with(self) -> Optional[str]:
        return self.__replace_with

    def to_csharp(self, stylizer: GDExtensionStylizer) -> CSharpAttribute:
        sentences: list[str] = [f"Deprecated since Godot {self.since}."]
        if self.message:
            sentences.append(self.message)
        if self.replace_with:
            sentences.append(f"Use `{stylizer.get_translation(self.replace_with)}` instead.")
        message: str = " ".join(sentences)
        return CSharpAttribute.obsolete(message)


class GDExtensionType(ABC):
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__kind: Optional[str] = data.get("kind")
        self.__description: Optional[tuple[str, ...]] = None
        self.__deprecated: Optional[GDExtensionDeprecated] = None
        if description := data.get("description"):
            self.__description = tuple(description)
        if deprecated := data.get("deprecated"):
            self.__deprecated = GDExtensionDeprecated(deprecated)

    @property
    def name(self) -> str:
        return self.__name

    @property
    def kind(self) -> Optional[str]:
        return self.__kind

    @property
    def description(self) -> Optional[tuple[str, ...]]:
        return self.__description

    @property
    def deprecated(self) -> Optional[GDExtensionDeprecated]:
        return self.__deprecated

    @abstractmethod
    def stylize(self, stylizer: GDExtensionStylizer) -> None:
        pass

    @staticmethod
    def create(data: dict[str, Any]) -> GDExtensionType:
        match kind := data["kind"]:
            case "enum":
                return GDExtensionEnumeration(data)
            case "handle":
                return GDExtensionHandle(data)
            case "alias":
                return GDExtensionAlias(data)
            case "struct":
                return GDExtensionStructure(data)
            case "function":
                return GDExtensionFunction(data)
            case _:
                raise ValueError(f"Unknown kind: {kind}")


class GDExtensionEnumeration(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.__is_bitfield: Optional[bool] = data.get("is_bitfield")
        self.__values: tuple[GDExtensionConstant, ...] = tuple(map(GDExtensionConstant, data["values"]))

    @property
    def is_bitfield(self) -> Optional[bool]:
        return self.__is_bitfield

    @property
    def values(self) -> tuple[GDExtensionConstant, ...]:
        return self.__values

    def stylize(self, stylizer: GDExtensionStylizer) -> None:
        prefix: str = commonprefix([value.name for value in self.values])
        for value in self.values:
            if "MAX" in value.name:
                stylizer.set_translation(value.name, "Max")
            else:
                replacement: str = pascal(value.name.removeprefix(prefix)) \
                    .removeprefix("Error") \
                    .removeprefix("Initialization") \
                    .replace("SD", "D", 1) \
                    .replace("Uint", "UInt", 1)
                stylizer.set_translation(value.name, replacement)

    def to_csharp(self, stylizer: GDExtensionStylizer) -> CSharpEnumeration:
        attributes: list[CSharpAttribute] = []
        dependencies: list[str] = []
        underlying_type: str = ""
        if self.deprecated:
            attributes.append(self.deprecated.to_csharp(stylizer))
            dependencies = ["System"]
        if self.is_bitfield:
            attributes.append(CSharpAttribute("Flags"))
            dependencies = ["System"]
            underlying_type = "uint"
        return CSharpEnumeration(
            name=self.name,
            constants=(constant.to_csharp(stylizer) for constant in self.values),
            description=stylizer.translate(self.description),
            attributes=attributes,
            dependencies=dependencies,
            underlying_type=underlying_type
        )


class GDExtensionConstant:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__value: int = data["value"]
        self.__description: Optional[tuple[str, ...]] = None
        if description := data.get("description"):
            self.__description = tuple(description)

    @property
    def name(self) -> str:
        return self.__name

    @property
    def value(self) -> int:
        return self.__value

    @property
    def description(self) -> Optional[tuple[str, ...]]:
        return self.__description

    def to_csharp(self, stylizer: GDExtensionStylizer) -> CSharpConstant:
        return CSharpConstant(
            name=stylizer.get_translation(self.name),
            value=self.value,
            description=stylizer.translate(self.description)
        )


class GDExtensionHandle(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.__is_const: Optional[bool] = data.get("is_const")
        self.__is_uninitialized: Optional[bool] = data.get("is_uninitialized")
        self.__parent: Optional[str] = data.get("parent")

    @property
    def is_const(self) -> Optional[bool]:
        return self.__is_const

    @property
    def is_uninitialized(self) -> Optional[bool]:
        return self.__is_uninitialized

    @property
    def parent(self) -> Optional[str]:
        return self.__parent

    def stylize(self, stylizer: GDExtensionStylizer) -> None:
        stylizer.set_expansion(self.name, self.parent or "void*")


class GDExtensionAlias(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.__type: str = data["type"]

    @property
    def type(self) -> str:
        return self.__type

    def stylize(self, stylizer: GDExtensionStylizer) -> None:
        stylizer.set_expansion(self.name, self.type)


class GDExtensionStructure(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.__members: tuple[GDExtensionField, ...] = tuple(map(GDExtensionField, data["members"]))

    @property
    def members(self) -> tuple[GDExtensionField, ...]:
        return self.__members

    def stylize(self, stylizer: GDExtensionStylizer) -> None:
        for member in self.members:
            stylizer.set_translation(member.name, pascal(preprocess(member.name)))

    def to_csharp(self, stylizer: GDExtensionStylizer) -> CSharpStructure:
        attributes: list[CSharpAttribute] = [CSharpAttribute.struct_layout("Sequential")]
        dependencies: list[str] = ["System.Runtime.InteropServices"]
        if self.deprecated:
            attributes.append(self.deprecated.to_csharp(stylizer))
            dependencies.append("System")
        return CSharpStructure(
            name=self.name,
            fields=(field.to_csharp(stylizer) for field in self.members),
            methods=(),
            description=stylizer.translate(self.description),
            attributes=attributes,
            dependencies=dependencies,
            is_value_type=True,
            is_unsafe=self.name != "GDExtensionCallError"
        )


class GDExtensionField:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]
        self.__description: Optional[tuple[str, ...]] = None
        if description := data.get("description"):
            self.__description = tuple(description)

    @property
    def name(self) -> str:
        return self.__name

    @property
    def type(self) -> str:
        return self.__type

    @property
    def description(self) -> Optional[tuple[str, ...]]:
        return self.__description

    def to_csharp(self, stylizer: GDExtensionStylizer) -> CSharpField:
        return CSharpField(
            name=stylizer.get_translation(self.name),
            type="GDExtensionClassMethodFlags" if self.name == "method_flags" else stylizer.get_expansion(self.type),
            description=stylizer.translate(self.description)
        )


class GDExtensionFunction(GDExtensionType):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.__arguments: tuple[GDExtensionParameter, ...] = tuple(map(GDExtensionParameter, data["arguments"]))
        self.__return_value: Optional[GDExtensionReturnType] = None
        if return_value := data.get("return_value"):
            self.__return_value = GDExtensionReturnType(return_value)

    @property
    def arguments(self) -> tuple[GDExtensionParameter, ...]:
        return self.__arguments

    @property
    def return_value(self) -> Optional[GDExtensionReturnType]:
        return self.__return_value

    def stylize(self, stylizer: GDExtensionStylizer) -> None:
        types: tuple[str, ...] = (
            *(argument.type for argument in self.arguments),
            self.return_value.type if self.return_value else "void"
        )
        arguments: str = ", ".join(types)
        stylizer.set_expansion(self.name, f"delegate* unmanaged[Cdecl]<{arguments}>")


class GDExtensionParameter:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data.get("name", "")
        self.__type: str = data["type"]
        self.__description: Optional[tuple[str, ...]] = None
        if description := data.get("description"):
            self.__description = tuple(description)

    @property
    def name(self) -> str:
        return self.__name

    @property
    def type(self) -> str:
        return self.__type

    @property
    def description(self) -> Optional[tuple[str, ...]]:
        return self.__description

    def to_csharp(self, stylizer: GDExtensionStylizer) -> CSharpParameter:
        return CSharpParameter(
            name=stylizer.get_translation(self.name),
            type=stylizer.get_expansion(self.type),
            description=stylizer.translate(self.description)
        )


class GDExtensionReturnType:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__type: str = data["type"]
        self.__description: Optional[tuple[str, ...]] = None
        if description := data.get("description"):
            self.__description = tuple(description)

    @property
    def type(self) -> str:
        return self.__type

    @property
    def description(self) -> Optional[tuple[str, ...]]:
        return self.__description

    def to_csharp(self, stylizer: GDExtensionStylizer) -> CSharpReturnType:
        return CSharpReturnType(
            name=stylizer.get_expansion(self.type),
            description=stylizer.translate(self.description)
        )


class GDExtensionInterfaceFunction(GDExtensionFunction):
    def __init__(self, data: dict[str, Any]) -> None:
        super().__init__(data)
        self.__since: str = data["since"]
        self.__see: Optional[str] = data.get("see")
        self.__legacy_type_name: Optional[str] = data.get("legacy_type_name")

    @property
    def since(self) -> str:
        return self.__since

    @property
    def see(self) -> Optional[str]:
        return self.__see

    @property
    def legacy_type_name(self) -> Optional[str]:
        return self.__legacy_type_name

    def stylize(self, stylizer: GDExtensionStylizer) -> None:
        super().stylize(stylizer)
        stylizer.set_translation(self.name, pascal(preprocess(self.name)))
        for argument in self.arguments:
            stylizer.set_translation(argument.name, camel(preprocess(argument.name)))

    def to_csharp(self, stylizer: GDExtensionStylizer) -> tuple[CSharpField, CSharpMethod]:
        name: str = stylizer.get_translation(self.name)
        parameters: tuple[CSharpParameter, ...] = tuple(
            argument.to_csharp(stylizer) for argument in self.arguments
        )
        arguments: str = ", ".join(argument.name for argument in parameters)
        return_type: CSharpReturnType = self.return_value.to_csharp(stylizer) if self.return_value else CSharpReturnType("void")
        attributes: list[CSharpAttribute] = [CSharpAttribute.method_impl("AggressiveInlining")]
        if self.deprecated:
            attributes.append(self.deprecated.to_csharp(stylizer))
        field: CSharpField = CSharpField(
            name=f"s_{name[0].lower()}{name[1:]}",
            type=stylizer.get_expansion(self.name),
            is_public=False,
            is_static=True
        )
        method: CSharpMethod = CSharpMethod(
            name=name,
            parameters=parameters,
            return_type=return_type,
            exceptions=(
                CSharpException(
                    name="InvalidOperationException",
                    description=(
                        "Unable to call the specified function.",
                    )
                ),
            ),
            body=(
                f"{field.type} function = {field.name};",
                "ThrowIfInvalid(function);",
                f"function({arguments});" if return_type.name == "void" else f"return function({arguments});"
            ),
            description=stylizer.translate(self.description),
            attributes=attributes,
            is_static=True
        )
        return field, method


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
