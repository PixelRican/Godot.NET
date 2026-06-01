from typing import Any

class Extension:
    def __init__(self, data: dict[str, Any]) -> None:
        self.header: Header = Header(data["header"])
        self.builtin_class_sizes: list[BuiltinClassSize] = [
            BuiltinClassSize(element) for element in data["builtin_class_sizes"]
        ]
        self.builtin_class_member_offsets: list[BuiltinClassMemberOffset] = [
            BuiltinClassMemberOffset(element) for element in data["builtin_class_member_offsets"]
        ]
        self.global_constants: list = data["global_constants"]
        self.global_enums: list[GlobalEnum] = [
            GlobalEnum(element) for element in data["global_enums"]
        ]
        self.utility_functions: list[UtilityFunction] = [
            UtilityFunction(element) for element in data["utility_functions"]
        ]
        self.builtin_classes: list[BuiltinClass] = [
            BuiltinClass(element) for element in data["builtin_classes"]
        ]
        self.classes: list[Class] = [
            Class(element) for element in data["classes"]
        ]
        self.singletons: list[Singleton] = [
            Singleton(element) for element in data["singletons"]
        ]
        self.native_structures: list[NativeStructure] = [
            NativeStructure(element) for element in data["native_structures"]
        ]

class Header:
    def __init__(self, data: dict[str, Any]) -> None:
        self.version_major: int = data["version_major"]
        self.version_minor: int = data["version_minor"]
        self.version_patch: int = data["version_patch"]
        self.version_status: str = data["version_status"]
        self.version_build: str = data["version_build"]
        self.version_full_name: str = data["version_full_name"]
        self.precision: str = data["precision"]

class BuiltinClassSize:
    def __init__(self, data: dict[str, Any]) -> None:
        self.build_configuration: str = data["build_configuration"]
        self.sizes: list[BuiltinClassSizeRecord] = [
            BuiltinClassSizeRecord(element) for element in data["sizes"]
        ]

class BuiltinClassSizeRecord:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.size: int = data["size"]

class BuiltinClassMemberOffset:
    def __init__(self, data: dict[str, Any]) -> None:
        self.build_configuration: str = data["build_configuration"]
        self.classes: list[BuiltinClassMemberOffsetGrouping] = [
            BuiltinClassMemberOffsetGrouping(element) for element in data["classes"]
        ]

class BuiltinClassMemberOffsetGrouping:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.members: list[BuiltinClassMemberOffsetRecord] = [
            BuiltinClassMemberOffsetRecord(element) for element in data["members"]
        ]

class BuiltinClassMemberOffsetRecord:
    def __init__(self, data: dict[str, Any]) -> None:
        self.member: str = data["member"]
        self.offset: int = data["offset"]
        self.meta: str = data["meta"]

class GlobalEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.is_bitfield: bool = data["is_bitfield"]
        self.values: list[GlobalEnumValue] = [
            GlobalEnumValue(element) for element in data["values"]
        ]

class GlobalEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]

class UtilityFunction:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.return_type: str | None = data.get("return_type")
        self.category: str = data["category"]
        self.is_vararg: bool = data["is_vararg"]
        self.hash: int = data["hash"]
        self.arguments: list[UtilityFunctionArgument] | None = None
        arguments: list[dict[str, Any]] | None = data.get("arguments")
        if arguments:
            self.arguments = [
                UtilityFunctionArgument(element) for element in arguments
            ]

class UtilityFunctionArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]

class BuiltinClass:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.is_keyed: bool = data["is_keyed"]
        self.operators: list[BuiltinClassOperator] = [
            BuiltinClassOperator(element) for element in data["operators"]
        ]
        self.constructors: list[BuiltinClassConstructor] = [
            BuiltinClassConstructor(element) for element in data["constructors"]
        ]
        self.has_destructor: bool = data["has_destructor"]
        self.indexing_return_type: str | None = data.get("indexing_return_type")
        self.methods: list[BuiltinClassMethod] | None = None
        self.constants: list[BuiltinClassConstant] | None = None
        self.enums: list[BuiltinClassEnum] | None = None
        methods: list[dict[str, Any]] | None = data.get("methods")
        constants: list[dict[str, Any]] | None = data.get("constants")
        enums: list[dict[str, Any]] | None = data.get("enums")
        if methods:
            self.methods = [
                BuiltinClassMethod(element) for element in methods
            ]
        if constants:
            self.constants = [
                BuiltinClassConstant(element) for element in constants
            ]
        if enums:
            self.enums = [
                BuiltinClassEnum(element) for element in enums
            ]

class BuiltinClassOperator:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.right_type: str | None = data.get("right_type")
        self.return_type: str = data["return_type"]

class BuiltinClassConstructor:
    def __init__(self, data: dict[str, Any]) -> None:
        self.index: int = data["index"]
        self.arguments: list[BuiltinClassConstructorArgument] | None = None
        arguments: list[dict[str, Any]] | None = data.get("arguments")
        if arguments:
            self.arguments = [
                BuiltinClassConstructorArgument(element) for element in arguments
            ]

class BuiltinClassConstructorArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]

class BuiltinClassMethod:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.return_type: str | None = data.get("return_type")
        self.is_vararg: bool = data["is_vararg"]
        self.is_const: bool = data["is_const"]
        self.is_static: bool = data["is_static"]
        self.hash: int = data["hash"]
        self.arguments: list | None = None
        self.hash_compatibility: int = data["hash"]
        arguments: list[dict[str, Any]] | None = data.get("arguments")
        if arguments:
            self.arguments = [
                BuiltinClassMethodArgument(element) for element in arguments
            ]

class BuiltinClassMethodArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.default_value: str | float | int | bool | None = data.get("default_value")

class BuiltinClassConstant:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.value: str = data["value"]

class BuiltinClassEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.values: list[BuiltinClassEnumValue] = [
            BuiltinClassEnumValue(element) for element in data["values"]
        ]

class BuiltinClassEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]

class Class:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.is_refcounted: bool = data["is_refcounted"]
        self.is_instantiable: bool = data["is_instantiable"]
        self.inherits: str | None = data.get("inherits")
        self.api_type: str = data["api_type"]
        self.enums: list[ClassEnum] | None = None
        self.methods: list[ClassMethod] | None = None
        self.properties: list[ClassProperty] | None = None
        self.signals: list[ClassSignal] | None = None
        self.constants: list[ClassConstant] | None = None
        enums: list[dict[str, Any]] | None = data.get("enums")
        methods: list[dict[str, Any]] | None = data.get("methods")
        properties: list[dict[str, Any]] | None = data.get("properties")
        signals: list[dict[str, Any]] | None = data.get("signals")
        constants: list[dict[str, Any]] | None = data.get("constants")
        if enums:
            self.enums = [
                ClassEnum(element) for element in enums
            ]
        if methods:
            self.methods = [
                ClassMethod(element) for element in methods
            ]
        if properties:
            self.properties = [
                ClassProperty(element) for element in properties
            ]
        if signals:
            self.signals = [
                ClassSignal(element) for element in signals
            ]
        if constants:
            self.constants = [
                ClassConstant(element) for element in constants
            ]

class ClassEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.values: list[ClassEnumValue] = [
            ClassEnumValue(element) for element in data["values"]
        ]
        self.is_bitfield: bool = data["is_bitfield"]

class ClassEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]

class ClassMethod:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.is_const: bool = data["is_const"]
        self.is_vararg: bool = data["is_vararg"]
        self.is_static: bool = data["is_static"]
        self.is_virtual: bool = data["is_virtual"]
        self.hash: int = data["hash"]
        self.hash_compatibility: list[int] | None = data.get("hash_compatibility")
        self.return_value: ClassMethodReturnValue | None = None
        self.arguments: list[ClassMethodArgument] | None = None
        self.is_required: bool | None = data.get("is_required")
        return_value: dict[str, Any] | None = data.get("return_value")
        arguments: list[dict[str, Any]] | None = data.get("arguments")
        if return_value:
            self.return_value = ClassMethodReturnValue(return_value)
        if arguments:
            self.arguments = [
                ClassMethodArgument(element) for element in arguments
            ]

class ClassMethodReturnValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.type: str = data["type"]
        self.meta: str | None = data.get("meta")

class ClassMethodArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.default_value: str | float | int | bool | None = data.get("default_value")
        self.meta: str | None = data.get("meta")

class ClassProperty:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.setter: str | None = data.get("setter")
        self.getter: str | None = data.get("getter")
        self.index: int | None = data.get("index")

class ClassSignal:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.arguments: list[ClassSignalArgument] | None = None
        arguments: list[dict[str, Any]] | None = data.get("arguments")
        if arguments:
            self.arguments = [
                ClassSignalArgument(element) for element in arguments
            ]

class ClassSignalArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]

class ClassConstant:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]

class Singleton:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]

class NativeStructure:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.format: str = data["format"]
