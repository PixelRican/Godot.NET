from csharp import *
from itertools import chain
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

    def dump(self, namespace: str, directory: str) -> None:
        def field_to_csharp(builds: tuple[GodotBuiltinClassMemberOffsetRecord, GodotBuiltinClassMemberOffsetRecord]) -> CSharpField:
            float_build, double_build = builds
            is_real_t: bool = float_build.meta == "float" and double_build.meta == "double"
            return CSharpField(
                name=pascal(float_build.member),
                type="real_t" if is_real_t else float_build.meta.removesuffix("32").replace("2i", "2I")
            )

        def class_to_csharp(builds: tuple[GodotBuiltinClassMemberOffsetGrouping, GodotBuiltinClassMemberOffsetGrouping]) -> CSharpStructure:
            float_build, double_build = builds
            return CSharpStructure(
                name=pascal(float_build.name),
                fields=map(field_to_csharp, zip(float_build.members, double_build.members)),
                methods=(),
                attributes=(
                    CSharpAttribute.struct_layout("Sequential"),
                ),
                dependencies=(
                    "System.Runtime.InteropServices",
                ),
                is_value_type=True
            )

        types: chain[CSharpType] = chain(
            map(class_to_csharp, zip(self.builtin_class_member_offsets[1].classes, self.builtin_class_member_offsets[3].classes))
        )
        dump(types, namespace, directory)


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

    @property
    def member(self) -> str:
        return self.__member

    @property
    def offset(self) -> int:
        return self.__offset

    @property
    def meta(self) -> str:
        return self.__meta


class GodotGlobalEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__is_bitfield: bool = data["is_bitfield"]
        self.__values: tuple[GodotGlobalEnumValue, ...] = tuple(
            map(GodotGlobalEnumValue, data["values"])
        )

    @property
    def name(self) -> str:
        return self.__name

    @property
    def is_bitfield(self) -> bool:
        return self.__is_bitfield

    @property
    def values(self) -> tuple[GodotGlobalEnumValue, ...]:
        return self.__values


class GodotGlobalEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__value: int = data["value"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def value(self) -> int:
        return self.__value


class GodotUtilityFunction:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__return_type: Optional[str] = data.get("return_type")
        self.__category: str = data["category"]
        self.__is_vararg: bool = data["is_vararg"]
        self.__hash: int = data["hash"]
        self.__arguments: Optional[tuple[GodotUtilityFunctionArgument, ...]] = None
        if arguments := data.get("arguments"):
            self.__arguments = tuple(
                map(GodotUtilityFunctionArgument, arguments)
            )

    @property
    def name(self) -> str:
        return self.__name

    @property
    def return_type(self) -> Optional[str]:
        return self.__return_type

    @property
    def category(self) -> str:
        return self.__category

    @property
    def is_vararg(self) -> bool:
        return self.__is_vararg

    @property
    def hash(self) -> int:
        return self.__hash

    @property
    def arguments(self) -> Optional[tuple[GodotUtilityFunctionArgument, ...]]:
        return self.__arguments


class GodotUtilityFunctionArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def type(self) -> str:
        return self.__type


class GodotBuiltinClass:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__is_keyed: bool = data["is_keyed"]
        self.__operators: tuple[GodotBuiltinClassOperator, ...] = tuple(
            map(GodotBuiltinClassOperator, data["operators"])
        )
        self.__constructors: tuple[GodotBuiltinClassConstructor, ...] = tuple(
            map(GodotBuiltinClassConstructor, data["constructors"])
        )
        self.__has_destructor: bool = data["has_destructor"]
        self.__indexing_return_type: Optional[str] = data.get("indexing_return_type")
        self.__methods: Optional[tuple[GodotBuiltinClassMethod, ...]] = None
        self.__constants: Optional[tuple[GodotBuiltinClassConstant, ...]] = None
        self.__enums: Optional[tuple[GodotBuiltinClassEnum, ...]] = None
        if methods := data.get("methods"):
            self.__methods = tuple(
                map(GodotBuiltinClassMethod, methods)
            )
        if constants := data.get("constants"):
            self.__constants = tuple(
                map(GodotBuiltinClassConstant, constants)
            )
        if enums := data.get("enums"):
            self.__enums = tuple(
                map(GodotBuiltinClassEnum, enums)
            )

    @property
    def name(self) -> str:
        return self.__name

    @property
    def is_keyed(self) -> bool:
        return self.__is_keyed

    @property
    def operators(self) -> tuple[GodotBuiltinClassOperator, ...]:
        return self.__operators

    @property
    def constructors(self) -> tuple[GodotBuiltinClassConstructor, ...]:
        return self.__constructors

    @property
    def has_destructor(self) -> bool:
        return self.__has_destructor

    @property
    def indexing_return_type(self) -> Optional[str]:
        return self.__indexing_return_type

    @property
    def methods(self) -> Optional[tuple[GodotBuiltinClassMethod, ...]]:
        return self.__methods

    @property
    def constants(self) -> Optional[tuple[GodotBuiltinClassConstant, ...]]:
        return self.__constants

    @property
    def enums(self) -> Optional[tuple[GodotBuiltinClassEnum, ...]]:
        return self.__enums


class GodotBuiltinClassOperator:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__right_type: Optional[str] = data.get("right_type")
        self.__return_type: str = data["return_type"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def right_type(self) -> Optional[str]:
        return self.__right_type

    @property
    def return_type(self) -> str:
        return self.__return_type


class GodotBuiltinClassConstructor:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__index: int = data["index"]
        self.__arguments: Optional[tuple[GodotBuiltinClassConstructorArgument, ...]] = None
        if arguments := data.get("arguments"):
            self.__arguments = tuple(
                map(GodotBuiltinClassConstructorArgument, arguments)
            )

    @property
    def index(self) -> int:
        return self.__index

    @property
    def arguments(self) -> Optional[tuple[GodotBuiltinClassConstructorArgument, ...]]:
        return self.__arguments


class GodotBuiltinClassConstructorArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def type(self) -> str:
        return self.__type


class GodotBuiltinClassMethod:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__return_type: Optional[str] = data.get("return_type")
        self.__is_vararg: bool = data["is_vararg"]
        self.__is_const: bool = data["is_const"]
        self.__is_static: bool = data["is_static"]
        self.__hash: int = data["hash"]
        self.__arguments: Optional[tuple[GodotBuiltinClassMethodArgument, ...]] = None
        self.__hash_compatibility: int = data["hash"]
        if arguments := data.get("arguments"):
            self.__arguments = tuple(
                map(GodotBuiltinClassMethodArgument, arguments)
            )

    @property
    def name(self) -> str:
        return self.__name

    @property
    def return_type(self) -> Optional[str]:
        return self.__return_type

    @property
    def is_vararg(self) -> bool:
        return self.__is_vararg

    @property
    def is_const(self) -> bool:
        return self.__is_const

    @property
    def is_static(self) -> bool:
        return self.__is_static

    @property
    def hash(self) -> int:
        return self.__hash

    @property
    def arguments(self) -> Optional[tuple[GodotBuiltinClassMethodArgument, ...]]:
        return self.__arguments

    @property
    def hash_compatibility(self) -> int:
        return self.__hash_compatibility


class GodotBuiltinClassMethodArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]
        self.__default_value: Union[str, float, int, bool, None] = data.get("default_value")

    @property
    def name(self) -> str:
        return self.__name

    @property
    def type(self) -> str:
        return self.__type

    @property
    def default_value(self) -> Union[str, float, int, bool, None]:
        return self.__default_value


class GodotBuiltinClassConstant:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]
        self.__value: str = data["value"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def type(self) -> str:
        return self.__type

    @property
    def value(self) -> str:
        return self.__value


class GodotBuiltinClassEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__values: tuple[GodotBuiltinClassEnumValue, ...] = tuple(
            map(GodotBuiltinClassEnumValue, data["values"])
        )

    @property
    def name(self) -> str:
        return self.__name

    @property
    def values(self) -> tuple[GodotBuiltinClassEnumValue, ...]:
        return self.__values


class GodotBuiltinClassEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__value: int = data["value"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def value(self) -> int:
        return self.__value


class GodotClass:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__is_refcounted: bool = data["is_refcounted"]
        self.__is_instantiable: bool = data["is_instantiable"]
        self.__inherits: Optional[str] = data.get("inherits")
        self.__api_type: str = data["api_type"]
        self.__enums: Optional[tuple[GodotClassEnum, ...]] = None
        self.__methods: Optional[tuple[GodotClassMethod, ...]] = None
        self.__properties: Optional[tuple[GodotClassProperty, ...]] = None
        self.__signals: Optional[tuple[GodotClassSignal, ...]] = None
        self.__constants: Optional[tuple[GodotClassConstant, ...]] = None
        if enums := data.get("enums"):
            self.__enums = tuple(
                map(GodotClassEnum, enums)
            )
        if methods := data.get("methods"):
            self.__methods = tuple(
                map(GodotClassMethod, methods)
            )
        if properties := data.get("properties"):
            self.__properties = tuple(
                map(GodotClassProperty, properties)
            )
        if signals := data.get("signals"):
            self.__signals = tuple(
                map(GodotClassSignal, signals)
            )
        if constants := data.get("constants"):
            self.__constants = tuple(
                map(GodotClassConstant, constants)
            )

    @property
    def name(self) -> str:
        return self.__name

    @property
    def is_refcounted(self) -> bool:
        return self.__is_refcounted

    @property
    def is_instantiable(self) -> bool:
        return self.__is_instantiable

    @property
    def inherits(self) -> Optional[str]:
        return self.__inherits

    @property
    def api_type(self) -> str:
        return self.__api_type

    @property
    def enums(self) -> Optional[tuple[GodotClassEnum, ...]]:
        return self.__enums

    @property
    def methods(self) -> Optional[tuple[GodotClassMethod, ...]]:
        return self.__methods

    @property
    def properties(self) -> Optional[tuple[GodotClassProperty, ...]]:
        return self.__properties

    @property
    def signals(self) -> Optional[tuple[GodotClassSignal, ...]]:
        return self.__signals

    @property
    def constants(self) -> Optional[tuple[GodotClassConstant, ...]]:
        return self.__constants


class GodotClassEnum:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__values: tuple[GodotClassEnumValue, ...] = tuple(
            map(GodotClassEnumValue, data["values"])
        )
        self.__is_bitfield: bool = data["is_bitfield"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def values(self) -> tuple[GodotClassEnumValue, ...]:
        return self.__values

    @property
    def is_bitfield(self) -> bool:
        return self.__is_bitfield


class GodotClassEnumValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__value: int = data["value"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def value(self) -> int:
        return self.__value


class GodotClassMethod:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__is_const: bool = data["is_const"]
        self.__is_vararg: bool = data["is_vararg"]
        self.__is_static: bool = data["is_static"]
        self.__is_virtual: bool = data["is_virtual"]
        self.__hash: int = data["hash"]
        self.__hash_compatibility: Optional[tuple[int, ...]] = data.get("hash_compatibility")
        self.__return_value: Optional[GodotClassMethodReturnValue] = None
        self.__arguments: Optional[tuple[GodotClassMethodArgument, ...]] = None
        self.__is_required: Optional[bool] = data.get("is_required")
        if return_value := data.get("return_value"):
            self.__return_value = GodotClassMethodReturnValue(return_value)
        if arguments := data.get("arguments"):
            self.__arguments = tuple(
                map(GodotClassMethodArgument, arguments)
            )

    @property
    def name(self) -> str:
        return self.__name

    @property
    def is_const(self) -> bool:
        return self.__is_const

    @property
    def is_vararg(self) -> bool:
        return self.__is_vararg

    @property
    def is_static(self) -> bool:
        return self.__is_static

    @property
    def is_virtual(self) -> bool:
        return self.__is_virtual

    @property
    def hash(self) -> int:
        return self.__hash

    @property
    def hash_compatibility(self) -> Optional[tuple[int, ...]]:
        return self.__hash_compatibility

    @property
    def return_value(self) -> Optional[GodotClassMethodReturnValue]:
        return self.__return_value

    @property
    def arguments(self) -> Optional[tuple[GodotClassMethodArgument, ...]]:
        return self.__arguments

    @property
    def is_required(self) -> Optional[bool]:
        return self.__is_required


class GodotClassMethodReturnValue:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__type: str = data["type"]
        self.__meta: Optional[str] = data.get("meta")

    @property
    def type(self) -> str:
        return self.__type

    @property
    def meta(self) -> Optional[str]:
        return self.__meta


class GodotClassMethodArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]
        self.__default_value: Union[str, float, int, bool, None] = data.get("default_value")
        self.__meta: Optional[str] = data.get("meta")

    @property
    def name(self) -> str:
        return self.__name

    @property
    def type(self) -> str:
        return self.__type

    @property
    def default_value(self) -> Union[str, float, int, bool, None]:
        return self.__default_value

    @property
    def meta(self) -> Optional[str]:
        return self.__meta


class GodotClassProperty:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]
        self.__setter: Optional[str] = data.get("setter")
        self.__getter: Optional[str] = data.get("getter")
        self.__index: Optional[int] = data.get("index")

    @property
    def name(self) -> str:
        return self.__name

    @property
    def type(self) -> str:
        return self.__type

    @property
    def setter(self) -> Optional[str]:
        return self.__setter

    @property
    def getter(self) -> Optional[str]:
        return self.__getter

    @property
    def index(self) -> Optional[int]:
        return self.__index


class GodotClassSignal:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__arguments: Optional[tuple[GodotClassSignalArgument, ...]] = None
        if arguments := data.get("arguments"):
            self.__arguments = tuple(
                map(GodotClassSignalArgument, arguments)
            )

    @property
    def name(self) -> str:
        return self.__name

    @property
    def arguments(self) -> Optional[tuple[GodotClassSignalArgument, ...]]:
        return self.__arguments


class GodotClassSignalArgument:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def type(self) -> str:
        return self.__type


class GodotClassConstant:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__value: int = data["value"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def value(self) -> int:
        return self.__value


class GodotSingleton:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__type: str = data["type"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def type(self) -> str:
        return self.__type


class GodotNativeStructure:
    def __init__(self, data: dict[str, Any]) -> None:
        self.__name: str = data["name"]
        self.__format: str = data["format"]

    @property
    def name(self) -> str:
        return self.__name

    @property
    def format(self) -> str:
        return self.__format
