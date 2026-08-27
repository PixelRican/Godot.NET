from typing import Any, Optional, Union


class GodotExtensionAPI:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__header: GodotHeader = GodotHeader(data["header"])
        self.__builtin_class_sizes: tuple[GodotBuiltinClassSize, ...] = tuple(
            map(GodotBuiltinClassSize, data["builtin_class_sizes"])
        )
        self.__builtin_class_member_offsets: tuple[GodotBuiltinClassMemberOffset, ...] = tuple(
            map(GodotBuiltinClassMemberOffset, data["builtin_class_member_offsets"])
        )
        self.__global_constants: tuple[Any, ...] = tuple(data["global_constants"])
        self.__global_enums: tuple[GodotGlobalEnum, ...] = tuple(
            map(GodotGlobalEnum, data["global_enums"])
        )
        self.__utility_functions: tuple[GodotUtilityFunction, ...] = tuple(
            map(GodotUtilityFunction, data["utility_functions"])
        )
        self.__builtin_classes: tuple[GodotBuiltinClass, ...] = tuple(
            map(GodotBuiltinClass, data["builtin_classes"])
        )
        self.__classes: tuple[GodotClass, ...] = tuple(
            map(GodotClass, data["classes"])
        )
        self.__singletons: tuple[GodotSingleton, ...] = tuple(
            map(GodotSingleton, data["singletons"])
        )
        self.__native_structures: tuple[GodotNativeStructure, ...] = tuple(
            map(GodotNativeStructure, data["native_structures"])
        )

    @property
    def header(self) -> GodotHeader:
        return self.__header

    @property
    def builtin_class_sizes(self) -> tuple[GodotBuiltinClassSize, ...]:
        return self.__builtin_class_sizes

    @property
    def builtin_class_member_offsets(self) -> tuple[GodotBuiltinClassMemberOffset, ...]:
        return self.__builtin_class_member_offsets

    @property
    def global_constants(self) -> tuple[Any, ...]:
        return self.__global_constants

    @property
    def global_enums(self) -> tuple[GodotGlobalEnum, ...]:
        return self.__global_enums

    @property
    def utility_functions(self) -> tuple[GodotUtilityFunction, ...]:
        return self.__utility_functions

    @property
    def builtin_classes(self) -> tuple[GodotBuiltinClass, ...]:
        return self.__builtin_classes

    @property
    def classes(self) -> tuple[GodotClass, ...]:
        return self.__classes

    @property
    def singletons(self) -> tuple[GodotSingleton, ...]:
        return self.__singletons

    @property
    def native_structures(self) -> tuple[GodotNativeStructure, ...]:
        return self.__native_structures


class GodotHeader:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__version_major: int = data["version_major"]
        self.__version_minor: int = data["version_minor"]
        self.__version_patch: int = data["version_patch"]
        self.__version_status: str = data["version_status"]
        self.__version_build: str = data["version_build"]
        self.__version_full_name: str = data["version_full_name"]
        self.__precision: str = data["precision"]

    @property
    def version_major(self) -> int:
        return self.__version_major

    @property
    def version_minor(self) -> int:
        return self.__version_minor

    @property
    def version_patch(self) -> int:
        return self.__version_patch

    @property
    def version_status(self) -> str:
        return self.__version_status

    @property
    def version_build(self) -> str:
        return self.__version_build

    @property
    def version_full_name(self) -> str:
        return self.__version_full_name

    @property
    def precision(self) -> str:
        return self.__precision


class GodotBuiltinClassSize:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__build_configuration: str = data["build_configuration"]
        self.__sizes: tuple[GodotBuiltinClassSizeRecord, ...] = tuple(
            map(GodotBuiltinClassSizeRecord, data["sizes"])
        )

    @property
    def build_configuration(self) -> str:
        return self.__build_configuration

    @property
    def sizes(self) -> tuple[GodotBuiltinClassSizeRecord, ...]:
        return self.__sizes


class GodotBuiltinClassSizeRecord:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__size: int = data["size"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def size(self) -> int:
        return self.__size


class GodotBuiltinClassMemberOffset:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__build_configuration: str = data["build_configuration"]
        self.__classes: tuple[GodotBuiltinClassMemberOffsetGrouping, ...] = tuple(
            map(GodotBuiltinClassMemberOffsetGrouping, data["classes"])
        )

    @property
    def build_configuration(self) -> str:
        return self.__build_configuration

    @property
    def classes(self) -> tuple[GodotBuiltinClassMemberOffsetGrouping, ...]:
        return self.__classes


class GodotBuiltinClassMemberOffsetGrouping:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__members: tuple[GodotBuiltinClassMemberOffsetRecord, ...] = tuple(
            map(GodotBuiltinClassMemberOffsetRecord, data["members"])
        )

    @property
    def name(self) -> str:
        return self.__name

    @property
    def members(self) -> tuple[GodotBuiltinClassMemberOffsetRecord, ...]:
        return self.__members


class GodotBuiltinClassMemberOffsetRecord:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__member: str = data["member"]
        self.__offset: int = data["offset"]
        self.__meta: str = data["meta"]


class GodotGlobalEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__is_bitfield: bool = data["is_bitfield"]
        self.__values: list[GodotGlobalEnumValue] = [
            GodotGlobalEnumValue(element) for element in data["values"]
        ]


class GodotGlobalEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__value: int = data["value"]


class GodotUtilityFunction:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__return_type: Optional[str] = data.get("return_type")
        self.__category: str = data["category"]
        self.__is_vararg: bool = data["is_vararg"]
        self.__hash: int = data["hash"]
        self.__arguments: Optional[list[GodotUtilityFunctionArgument]] = None
        if arguments := data.get("arguments"):
            self.__arguments = [
                GodotUtilityFunctionArgument(element) for element in arguments
            ]


class GodotUtilityFunctionArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]


class GodotBuiltinClass:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__is_keyed: bool = data["is_keyed"]
        self.__operators: list[GodotBuiltinClassOperator] = [
            GodotBuiltinClassOperator(element) for element in data["operators"]
        ]
        self.__constructors: list[GodotBuiltinClassConstructor] = [
            GodotBuiltinClassConstructor(element) for element in data["constructors"]
        ]
        self.__has_destructor: bool = data["has_destructor"]
        self.__indexing_return_type: Optional[str] = data.get("indexing_return_type")
        self.__methods: Optional[list[GodotBuiltinClassMethod]] = None
        self.__constants: Optional[list[GodotBuiltinClassConstant]] = None
        self.__enums: Optional[list[GodotBuiltinClassEnum]] = None
        if methods := data.get("methods"):
            self.__methods = [
                GodotBuiltinClassMethod(element) for element in methods
            ]
        if constants := data.get("constants"):
            self.__constants = [
                GodotBuiltinClassConstant(element) for element in constants
            ]
        if enums := data.get("enums"):
            self.__enums = [
                GodotBuiltinClassEnum(element) for element in enums
            ]


class GodotBuiltinClassOperator:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__right_type: Optional[str] = data.get("right_type")
        self.__return_type: str = data["return_type"]


class GodotBuiltinClassConstructor:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__index: int = data["index"]
        self.__arguments: Optional[list[GodotBuiltinClassConstructorArgument]] = None
        if arguments := data.get("arguments"):
            self.__arguments = [
                GodotBuiltinClassConstructorArgument(element) for element in arguments
            ]


class GodotBuiltinClassConstructorArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]


class GodotBuiltinClassMethod:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__return_type: Optional[str] = data.get("return_type")
        self.__is_vararg: bool = data["is_vararg"]
        self.__is_const: bool = data["is_const"]
        self.__is_static: bool = data["is_static"]
        self.__hash: int = data["hash"]
        self.__arguments: Optional[list[GodotBuiltinClassMethodArgument]] = None
        self.__hash_compatibility: int = data["hash"]
        if arguments := data.get("arguments"):
            self.__arguments = [
                GodotBuiltinClassMethodArgument(element) for element in arguments
            ]


class GodotBuiltinClassMethodArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]
        self.__default_value: Union[str, float, int, bool, None] = data.get("default_value")


class GodotBuiltinClassConstant:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]
        self.__value: str = data["value"]


class GodotBuiltinClassEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__values: list[GodotBuiltinClassEnumValue] = [
            GodotBuiltinClassEnumValue(element) for element in data["values"]
        ]


class GodotBuiltinClassEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__value: int = data["value"]


class GodotClass:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__is_refcounted: bool = data["is_refcounted"]
        self.__is_instantiable: bool = data["is_instantiable"]
        self.__inherits: Optional[str] = data.get("inherits")
        self.__api_type: str = data["api_type"]
        self.__enums: Optional[list[GodotClassEnum]] = None
        self.__methods: Optional[list[GodotClassMethod]] = None
        self.__properties: Optional[list[GodotClassProperty]] = None
        self.__signals: Optional[list[GodotClassSignal]] = None
        self.__constants: Optional[list[GodotClassConstant]] = None
        if enums := data.get("enums"):
            self.__enums = [
                GodotClassEnum(element) for element in enums
            ]
        if methods := data.get("methods"):
            self.__methods = [
                GodotClassMethod(element) for element in methods
            ]
        if properties := data.get("properties"):
            self.__properties = [
                GodotClassProperty(element) for element in properties
            ]
        if signals := data.get("signals"):
            self.__signals = [
                GodotClassSignal(element) for element in signals
            ]
        if constants := data.get("constants"):
            self.__constants = [
                GodotClassConstant(element) for element in constants
            ]


class GodotClassEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__values: list[GodotClassEnumValue] = [
            GodotClassEnumValue(element) for element in data["values"]
        ]
        self.__is_bitfield: bool = data["is_bitfield"]


class GodotClassEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__value: int = data["value"]


class GodotClassMethod:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__is_const: bool = data["is_const"]
        self.__is_vararg: bool = data["is_vararg"]
        self.__is_static: bool = data["is_static"]
        self.__is_virtual: bool = data["is_virtual"]
        self.__hash: int = data["hash"]
        self.__hash_compatibility: Optional[list[int]] = data.get("hash_compatibility")
        self.__return_value: Optional[GodotClassMethodReturnValue] = None
        self.__arguments: Optional[list[GodotClassMethodArgument]] = None
        self.__is_required: Optional[bool] = data.get("is_required")
        if return_value := data.get("return_value"):
            self.__return_value = GodotClassMethodReturnValue(return_value)
        if arguments := data.get("arguments"):
            self.__arguments = [
                GodotClassMethodArgument(element) for element in arguments
            ]


class GodotClassMethodReturnValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__type: str = data["type"]
        self.__meta: Optional[str] = data.get("meta")


class GodotClassMethodArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]
        self.__default_value: Union[str, float, int, bool, None] = data.get("default_value")
        self.__meta: Optional[str] = data.get("meta")


class GodotClassProperty:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]
        self.__setter: Optional[str] = data.get("setter")
        self.__getter: Optional[str] = data.get("getter")
        self.__index: Optional[int] = data.get("index")


class GodotClassSignal:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__arguments: Optional[list[GodotClassSignalArgument]] = None
        if arguments := data.get("arguments"):
            self.__arguments = [
                GodotClassSignalArgument(element) for element in arguments
            ]


class GodotClassSignalArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]


class GodotClassConstant:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__value: int = data["value"]


class GodotSingleton:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]


class GodotNativeStructure:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__format: str = data["format"]
