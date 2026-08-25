from typing import Any, Optional, Union


class GodotExtensionAPI:
    def __init__(self, data: dict[str, Any]) -> None:
        self.header: GodotHeader = GodotHeader(data["header"])
        self.builtin_class_sizes: tuple[GodotBuiltinClassSize, ...] = tuple(
            map(GodotBuiltinClassSize, data["builtin_class_sizes"])
        )
        self.builtin_class_member_offsets: tuple[GodotBuiltinClassMemberOffset, ...] = tuple(
            map(GodotBuiltinClassMemberOffset, data["builtin_class_member_offsets"])
        )
        self.global_constants: tuple[Any, ...] = tuple(data["global_constants"])
        self.global_enums: tuple[GodotGlobalEnum, ...] = tuple(
            map(GodotGlobalEnum, data["global_enums"])
        )
        self.utility_functions: tuple[GodotUtilityFunction, ...] = tuple(
            map(GodotUtilityFunction, data["utility_functions"])
        )
        self.builtin_classes: tuple[GodotBuiltinClass, ...] = tuple(
            map(GodotBuiltinClass, data["builtin_classes"])
        )
        self.classes: tuple[GodotClass, ...] = tuple(
            map(GodotClass, data["classes"])
        )
        self.singletons: tuple[GodotSingleton, ...] = tuple(
            map(GodotSingleton, data["singletons"])
        )
        self.native_structures: tuple[GodotNativeStructure, ...] = tuple(
            map(GodotNativeStructure, data["native_structures"])
        )


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
        self.return_type: Optional[str] = data.get("return_type")
        self.category: str = data["category"]
        self.is_vararg: bool = data["is_vararg"]
        self.hash: int = data["hash"]
        self.arguments: Optional[list[GodotUtilityFunctionArgument]] = None
        if arguments := data.get("arguments"):
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
        self.indexing_return_type: Optional[str] = data.get("indexing_return_type")
        self.methods: Optional[list[GodotBuiltinClassMethod]] = None
        self.constants: Optional[list[GodotBuiltinClassConstant]] = None
        self.enums: Optional[list[GodotBuiltinClassEnum]] = None
        if methods := data.get("methods"):
            self.methods = [
                GodotBuiltinClassMethod(element) for element in methods
            ]
        if constants := data.get("constants"):
            self.constants = [
                GodotBuiltinClassConstant(element) for element in constants
            ]
        if enums := data.get("enums"):
            self.enums = [
                GodotBuiltinClassEnum(element) for element in enums
            ]


class GodotBuiltinClassOperator:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.right_type: Optional[str] = data.get("right_type")
        self.return_type: str = data["return_type"]


class GodotBuiltinClassConstructor:
    def __init__(self, data: dict[str, Any]) -> None:
        self.index: int = data["index"]
        self.arguments: Optional[list[GodotBuiltinClassConstructorArgument]] = None
        if arguments := data.get("arguments"):
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
        self.return_type: Optional[str] = data.get("return_type")
        self.is_vararg: bool = data["is_vararg"]
        self.is_const: bool = data["is_const"]
        self.is_static: bool = data["is_static"]
        self.hash: int = data["hash"]
        self.arguments: Optional[list[GodotBuiltinClassMethodArgument]] = None
        self.hash_compatibility: int = data["hash"]
        if arguments := data.get("arguments"):
            self.arguments = [
                GodotBuiltinClassMethodArgument(element) for element in arguments
            ]


class GodotBuiltinClassMethodArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.default_value: Union[str, float, int, bool, None] = data.get("default_value")


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
        self.inherits: Optional[str] = data.get("inherits")
        self.api_type: str = data["api_type"]
        self.enums: Optional[list[GodotClassEnum]] = None
        self.methods: Optional[list[GodotClassMethod]] = None
        self.properties: Optional[list[GodotClassProperty]] = None
        self.signals: Optional[list[GodotClassSignal]] = None
        self.constants: Optional[list[GodotClassConstant]] = None
        if enums := data.get("enums"):
            self.enums = [
                GodotClassEnum(element) for element in enums
            ]
        if methods := data.get("methods"):
            self.methods = [
                GodotClassMethod(element) for element in methods
            ]
        if properties := data.get("properties"):
            self.properties = [
                GodotClassProperty(element) for element in properties
            ]
        if signals := data.get("signals"):
            self.signals = [
                GodotClassSignal(element) for element in signals
            ]
        if constants := data.get("constants"):
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
        self.hash_compatibility: Optional[list[int]] = data.get("hash_compatibility")
        self.return_value: Optional[GodotClassMethodReturnValue] = None
        self.arguments: Optional[list[GodotClassMethodArgument]] = None
        self.is_required: Optional[bool] = data.get("is_required")
        if return_value := data.get("return_value"):
            self.return_value = GodotClassMethodReturnValue(return_value)
        if arguments := data.get("arguments"):
            self.arguments = [
                GodotClassMethodArgument(element) for element in arguments
            ]


class GodotClassMethodReturnValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.type: str = data["type"]
        self.meta: Optional[str] = data.get("meta")


class GodotClassMethodArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.default_value: Union[str, float, int, bool, None] = data.get("default_value")
        self.meta: Optional[str] = data.get("meta")


class GodotClassProperty:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.type: str = data["type"]
        self.setter: Optional[str] = data.get("setter")
        self.getter: Optional[str] = data.get("getter")
        self.index: Optional[int] = data.get("index")


class GodotClassSignal:
    def __init__(self, data: dict[str, Any]) -> None:
        self.name: str = data["name"]
        self.arguments: Optional[list[GodotClassSignalArgument]] = None
        if arguments := data.get("arguments"):
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
