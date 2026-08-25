from typing import Any


class GodotExtensionAPI:
    def __init__(self, data: dict[str, Any]) -> None:
        self.header: GodotHeader = GodotHeader(data["header"])
        self.builtin_class_sizes: list[GodotBuiltinClassSize] = [
            GodotBuiltinClassSize(element) for element in data["builtin_class_sizes"]
        ]
        self.builtin_class_member_offsets: list[GodotBuiltinClassMemberOffset] = [
            GodotBuiltinClassMemberOffset(element) for element in data["builtin_class_member_offsets"]
        ]
        self.global_constants: list = data["global_constants"]
        self.global_enums: list[GodotGlobalEnum] = [
            GodotGlobalEnum(element) for element in data["global_enums"]
        ]
        self.utility_functions: list[GodotUtilityFunction] = [
            GodotUtilityFunction(element) for element in data["utility_functions"]
        ]
        self.builtin_classes: list[GodotBuiltinClass] = [
            GodotBuiltinClass(element) for element in data["builtin_classes"]
        ]
        self.classes: list[GodotClass] = [
            GodotClass(element) for element in data["classes"]
        ]
        self.singletons: list[GodotSingleton] = [
            GodotSingleton(element) for element in data["singletons"]
        ]
        self.native_structures: list[GodotNativeStructure] = [
            GodotNativeStructure(element) for element in data["native_structures"]
        ]


class GodotHeader:
    def __init__(self, data: dict[str, Any]) -> None:
        self.version_major: int = data["version_major"]
        self.version_minor: int = data["version_minor"]
        self.version_patch: int = data["version_patch"]
        self.version_status: str = data["version_status"]
        self.version_build: str = data["version_build"]
        self.version_full_name: str = data["version_full_name"]
        self.precision: str = data["precision"]


class GodotBuiltinClassSize:
    def __init__(self, data: dict[str, Any]) -> None:
        self.build_configuration: str = data["build_configuration"]
        self.sizes: list[GodotBuiltinClassSizeRecord] = [
            GodotBuiltinClassSizeRecord(element) for element in data["sizes"]
        ]


class GodotBuiltinClassSizeRecord:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.size: int = data["size"]


class GodotBuiltinClassMemberOffset:
    def __init__(self, data: dict[str, Any]) -> None:
        self.build_configuration: str = data["build_configuration"]
        self.classes: list[GodotBuiltinClassMemberOffsetGrouping] = [
            GodotBuiltinClassMemberOffsetGrouping(element) for element in data["classes"]
        ]


class GodotBuiltinClassMemberOffsetGrouping:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.members: list[GodotBuiltinClassMemberOffsetRecord] = [
            GodotBuiltinClassMemberOffsetRecord(element) for element in data["members"]
        ]


class GodotBuiltinClassMemberOffsetRecord:
    def __init__(self, data: dict[str, Any]) -> None:
        self.member: str = data["member"]
        self.offset: int = data["offset"]
        self.meta: str = data["meta"]


class GodotGlobalEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.is_bitfield: bool = data["is_bitfield"]
        self.values: list[GodotGlobalEnumValue] = [
            GodotGlobalEnumValue(element) for element in data["values"]
        ]


class GodotGlobalEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]


class GodotUtilityFunction:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.return_type: str | None = data.get("return_type")
        self.category: str = data["category"]
        self.is_vararg: bool = data["is_vararg"]
        self.hash: int = data["hash"]
        self.arguments: list[GodotUtilityFunctionArgument] | None = None
        arguments: list[dict[str, Any]] | None = data.get("arguments")
        if arguments:
            self.arguments = [
                GodotUtilityFunctionArgument(element) for element in arguments
            ]


class GodotUtilityFunctionArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]


class GodotBuiltinClass:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.is_keyed: bool = data["is_keyed"]
        self.operators: list[GodotBuiltinClassOperator] = [
            GodotBuiltinClassOperator(element) for element in data["operators"]
        ]
        self.constructors: list[GodotBuiltinClassConstructor] = [
            GodotBuiltinClassConstructor(element) for element in data["constructors"]
        ]
        self.has_destructor: bool = data["has_destructor"]
        self.indexing_return_type: str | None = data.get("indexing_return_type")
        self.methods: list[GodotBuiltinClassMethod] | None = None
        self.constants: list[GodotBuiltinClassConstant] | None = None
        self.enums: list[GodotBuiltinClassEnum] | None = None
        methods: list[dict[str, Any]] | None = data.get("methods")
        constants: list[dict[str, Any]] | None = data.get("constants")
        enums: list[dict[str, Any]] | None = data.get("enums")
        if methods:
            self.methods = [
                GodotBuiltinClassMethod(element) for element in methods
            ]
        if constants:
            self.constants = [
                GodotBuiltinClassConstant(element) for element in constants
            ]
        if enums:
            self.enums = [
                GodotBuiltinClassEnum(element) for element in enums
            ]


class GodotBuiltinClassOperator:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.right_type: str | None = data.get("right_type")
        self.return_type: str = data["return_type"]


class GodotBuiltinClassConstructor:
    def __init__(self, data: dict[str, Any]) -> None:
        self.index: int = data["index"]
        self.arguments: list[GodotBuiltinClassConstructorArgument] | None = None
        arguments: list[dict[str, Any]] | None = data.get("arguments")
        if arguments:
            self.arguments = [
                GodotBuiltinClassConstructorArgument(element) for element in arguments
            ]


class GodotBuiltinClassConstructorArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]


class GodotBuiltinClassMethod:
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
                GodotBuiltinClassMethodArgument(element) for element in arguments
            ]


class GodotBuiltinClassMethodArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.default_value: str | float | int | bool | None = data.get("default_value")


class GodotBuiltinClassConstant:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.value: str = data["value"]


class GodotBuiltinClassEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.values: list[GodotBuiltinClassEnumValue] = [
            GodotBuiltinClassEnumValue(element) for element in data["values"]
        ]


class GodotBuiltinClassEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]


class GodotClass:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.is_refcounted: bool = data["is_refcounted"]
        self.is_instantiable: bool = data["is_instantiable"]
        self.inherits: str | None = data.get("inherits")
        self.api_type: str = data["api_type"]
        self.enums: list[GodotClassEnum] | None = None
        self.methods: list[GodotClassMethod] | None = None
        self.properties: list[GodotClassProperty] | None = None
        self.signals: list[GodotClassSignal] | None = None
        self.constants: list[GodotClassConstant] | None = None
        enums: list[dict[str, Any]] | None = data.get("enums")
        methods: list[dict[str, Any]] | None = data.get("methods")
        properties: list[dict[str, Any]] | None = data.get("properties")
        signals: list[dict[str, Any]] | None = data.get("signals")
        constants: list[dict[str, Any]] | None = data.get("constants")
        if enums:
            self.enums = [
                GodotClassEnum(element) for element in enums
            ]
        if methods:
            self.methods = [
                GodotClassMethod(element) for element in methods
            ]
        if properties:
            self.properties = [
                GodotClassProperty(element) for element in properties
            ]
        if signals:
            self.signals = [
                GodotClassSignal(element) for element in signals
            ]
        if constants:
            self.constants = [
                GodotClassConstant(element) for element in constants
            ]


class GodotClassEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.values: list[GodotClassEnumValue] = [
            GodotClassEnumValue(element) for element in data["values"]
        ]
        self.is_bitfield: bool = data["is_bitfield"]


class GodotClassEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]


class GodotClassMethod:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.is_const: bool = data["is_const"]
        self.is_vararg: bool = data["is_vararg"]
        self.is_static: bool = data["is_static"]
        self.is_virtual: bool = data["is_virtual"]
        self.hash: int = data["hash"]
        self.hash_compatibility: list[int] | None = data.get("hash_compatibility")
        self.return_value: GodotClassMethodReturnValue | None = None
        self.arguments: list[GodotClassMethodArgument] | None = None
        self.is_required: bool | None = data.get("is_required")
        return_value: dict[str, Any] | None = data.get("return_value")
        arguments: list[dict[str, Any]] | None = data.get("arguments")
        if return_value:
            self.return_value = GodotClassMethodReturnValue(return_value)
        if arguments:
            self.arguments = [
                GodotClassMethodArgument(element) for element in arguments
            ]


class GodotClassMethodReturnValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.type: str = data["type"]
        self.meta: str | None = data.get("meta")


class GodotClassMethodArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.default_value: str | float | int | bool | None = data.get("default_value")
        self.meta: str | None = data.get("meta")


class GodotClassProperty:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.setter: str | None = data.get("setter")
        self.getter: str | None = data.get("getter")
        self.index: int | None = data.get("index")


class GodotClassSignal:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.arguments: list[GodotClassSignalArgument] | None = None
        arguments: list[dict[str, Any]] | None = data.get("arguments")
        if arguments:
            self.arguments = [
                GodotClassSignalArgument(element) for element in arguments
            ]


class GodotClassSignalArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]


class GodotClassConstant:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.value: int = data["value"]


class GodotSingleton:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]


class GodotNativeStructure:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.format: str = data["format"]
