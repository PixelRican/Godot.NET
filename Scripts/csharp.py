from enum import StrEnum
from typing import Generator, Iterable, Iterator, Union


class XMLDocumentation:
    def __init__(self, tag: str, attributes: Iterable[XMLAttribute], description: Iterable[str]) -> None:
        self.__tag: str = tag
        self.__attributes: tuple[XMLAttribute, ...] = tuple(attributes)
        self.__description: tuple[str, ...] = tuple(description)

    def __iter__(self) -> Generator[str]:
        if self.description:
            elements: list[str] = [self.tag] + [str(attribute) for attribute in self.attributes]
            header: str = " ".join(elements)
            yield f"/// <{header}>"
            yield from (f"/// {line}" for line in self.description)
            yield f"/// </{self.tag}>"

    @property
    def tag(self) -> str:
        return self.__tag

    @property
    def attributes(self) -> tuple[XMLAttribute, ...]:
        return self.__attributes

    @property
    def description(self) -> tuple[str, ...]:
        return self.__description

    @staticmethod
    def exception(name: str, description: Iterable[str]) -> XMLDocumentation:
        attribute: XMLAttribute = XMLAttribute("cref", name)
        return XMLDocumentation("exception", (attribute,), description)

    @staticmethod
    def param(name: str, description: Iterable[str]) -> XMLDocumentation:
        attribute: XMLAttribute = XMLAttribute("name", name)
        return XMLDocumentation("param", (attribute,), description)

    @staticmethod
    def returns(description: Iterable[str]) -> XMLDocumentation:
        return XMLDocumentation("returns", (), description)

    @staticmethod
    def summary(description: Iterable[str]) -> XMLDocumentation:
        return XMLDocumentation("summary", (), description)


class XMLAttribute:
    def __init__(self, name: str, value: str) -> None:
        self.__name: str = name
        self.__value: str = value

    def __str__(self) -> str:
        return f"{self.name}=\"{self.value}\""

    @property
    def name(self) -> str:
        return self.__name

    @property
    def value(self) -> str:
        return self.__value


class CSharpAttribute:
    def __init__(self, name: str, arguments: Iterable[str] = ()) -> None:
        self.__name: str = name
        self.__arguments: tuple[str, ...] = tuple(arguments)

    def __str__(self) -> str:
        if self.arguments:
            arguments: str = ", ".join(argument for argument in self.arguments)
            return f"[{self.name}({arguments})]"
        return f"[{self.name}]"

    @property
    def name(self) -> str:
        return self.__name

    @property
    def arguments(self) -> tuple[str, ...]:
        return self.__arguments

    @staticmethod
    def method_impl(options: Union[str, Iterable[str]]) -> CSharpAttribute:
        argument: str
        if isinstance(options, str):
            argument = f"MethodImplOptions.{options}"
        else:
            argument = " | ".join(f"MethodImplOptions.{option}" for option in options)
        return CSharpAttribute("MethodImpl", (argument,))

    @staticmethod
    def obsolete(message: str) -> CSharpAttribute:
        return CSharpAttribute("Obsolete", (f"\"{message}\"",))

    @staticmethod
    def struct_layout(kind: str) -> CSharpAttribute:
        return CSharpAttribute("StructLayout", (f"LayoutKind.{kind}",))


class CSharpElement:
    def __init__(
            self,
            name: str,
            documentation: XMLDocumentation,
            attributes: Iterable[CSharpAttribute] = ()
        ) -> None:
        self.__name: str = name
        self.__documentation: XMLDocumentation = documentation
        self.__attributes: tuple[CSharpAttribute, ...] = tuple(sorted(attributes, key=lambda a: a.name))

    @property
    def name(self) -> str:
        return self.__name

    @property
    def documentation(self) -> XMLDocumentation:
        return self.__documentation

    @property
    def attributes(self) -> tuple[CSharpAttribute, ...]:
        return self.__attributes


class CSharpMember(CSharpElement):
    def __init__(
            self,
            name: str,
            description: Iterable[str] = (),
            attributes: Iterable[CSharpAttribute] = (),
            is_public: bool = True
        ) -> None:
        super().__init__(name, XMLDocumentation.summary(description), attributes)
        self.__is_public: bool = is_public

    @property
    def is_public(self) -> bool:
        return self.__is_public

    @property
    def access_modifier(self) -> str:
        return "public" if self.is_public else "private"


class CSharpType(CSharpMember):
    def __init__(
            self,
            name: str,
            description: Iterable[str] = (),
            attributes: Iterable[CSharpAttribute] = (),
            is_public: bool = True,
            dependencies: Iterable[str] = ()
        ) -> None:
        super().__init__(name, description, attributes, is_public)
        self.__dependencies: tuple[str, ...] = tuple(sorted(dependencies))

    @property
    def dependencies(self) -> tuple[str, ...]:
        return self.__dependencies


class CSharpEnumeration(CSharpType):
    def __init__(
            self,
            name: str,
            constants: Iterable[CSharpConstant],
            description: Iterable[str] = (),
            attributes: Iterable[CSharpAttribute] = (),
            is_public: bool = True,
            dependencies: Iterable[str] = (),
            underlying_type: str = ""
        ) -> None:
        super().__init__(name, description, attributes, is_public, dependencies)
        self.__constants: tuple[CSharpConstant, ...] = tuple(constants)
        self.__underlying_type: str = underlying_type

    def __iter__(self) -> Generator[str]:
        yield from self.documentation
        yield from (str(attribute) for attribute in self.attributes)
        if self.underlying_type:
            yield f"{self.access_modifier} enum {self.name} : {self.underlying_type}"
        else:
            yield f"{self.access_modifier} enum {self.name}"
        yield "{"
        if self.constants:
            for constant in self.constants[:-1]:
                yield from (indent(line) for line in constant)
            for line in self.constants[-1]:
                yield indent(line if line.startswith("///") else line.removesuffix(","))
        yield "}"

    @property
    def constants(self) -> tuple[CSharpConstant, ...]:
        return self.__constants

    @property
    def underlying_type(self) -> str:
        return self.__underlying_type


class CSharpConstant(CSharpElement):
    def __init__(
            self,
            name: str,
            value: int,
            description: Iterable[str] = (),
            attributes: Iterable[CSharpAttribute] = ()
        ) -> None:
        super().__init__(name, XMLDocumentation.summary(description), attributes)
        self.__value: int = value

    def __iter__(self) -> Generator[str]:
        yield from self.documentation
        yield from (str(attribute) for attribute in self.attributes)
        yield f"{self.name} = {self.value},"

    @property
    def value(self) -> int:
        return self.__value


class CSharpClass(CSharpType):
    def __init__(
            self,
            name: str,
            fields: Iterable[CSharpField],
            methods: Iterable[CSharpMethod],
            description: Iterable[str] = (),
            attributes: Iterable[CSharpAttribute] = (),
            is_public: bool = True,
            dependencies: Iterable[str] = (),
            is_value_type: bool = False,
            is_static: bool = False,
            is_unsafe: bool = False
        ) -> None:
        super().__init__(name, description, attributes, is_public, dependencies)
        self.__fields: tuple[CSharpField, ...] = tuple(fields)
        self.__methods: tuple[CSharpMethod, ...] = tuple(methods)
        self.__is_value_type: bool = is_value_type
        self.__is_static: bool = is_static
        self.__is_unsafe: bool = is_unsafe

    def __iter__(self) -> Generator[str]:
        yield from self.documentation
        yield (str(attribute) for attribute in self.attributes)
        yield f"{self.access_modifier} {self.kind} {self.name}"
        yield "{"
        separate: bool = False
        for field in self.fields:
            separate = True
            yield from (indent(line) for line in field)
        for method in self.methods:
            if separate:
                yield ""
            separate = True
            yield from (indent(line) for line in method)
        yield "}"

    @property
    def fields(self) -> tuple[CSharpField, ...]:
        return self.__fields

    @property
    def methods(self) -> tuple[CSharpMethod, ...]:
        return self.__methods

    @property
    def is_value_type(self) -> bool:
        return self.__is_value_type

    @property
    def is_static(self) -> bool:
        return self.__is_static

    @property
    def is_unsafe(self) -> bool:
        return self.__is_unsafe

    @property
    def kind(self) -> str:
        modifiers: list[str] = []
        if self.is_static:
            modifiers.append("static")
        if self.is_unsafe:
            modifiers.append("unsafe")
        modifiers.append("struct" if self.is_value_type else "class")
        return " ".join(modifiers)


class CSharpField(CSharpMember):
    def __init__(self) -> None:
        super().__init__()
        self.type: str = "object"
        self.is_static: bool = False
        self.is_readonly: bool = False

    def __iter__(self) -> Generator[str]:
        yield from self.documentation
        yield f"{self.access_modifier} {self.type} {self.name};"

    @property
    def access_modifier(self) -> str:
        modifiers: list[str] = [super().access_modifier]
        if self.is_static:
            modifiers.append("static")
        if self.is_readonly:
            modifiers.append("readonly")
        return " ".join(modifiers)


class CSharpMethod(CSharpMember):
    def __init__(self) -> None:
        super().__init__()
        self.return_type: CSharpReturnType = CSharpReturnType()
        self.parameters: list[CSharpParameter] = []
        self.exceptions: list[CSharpException] = []
        self.body: Iterable[str] = ("throw new System.NotImplementedException();",)
        self.is_static: bool = False

    @property
    def access_modifier(self) -> str:
        return f"{super().access_modifier} static" if self.is_static else super().access_modifier

    def generator(self) -> Iterator[str]:
        def key(attribute: CSharpAttribute) -> str:
            return attribute.name

        yield from self.documentation
        for parameter in self.parameters:
            yield from parameter.documentation
        for exception in self.exceptions:
            yield from exception.documentation
        yield from self.return_type.documentation
        yield from (str(attribute) for attribute in sorted(self.attributes, key=key))
        parameters: str = ", ".join(str(parameter) for parameter in self.parameters)
        yield f"{self.access_modifier} {self.return_type.name} {self.name}({parameters})"
        yield "{"
        yield from (indent(line) for line in self.body)
        yield "}"


class CSharpReturnType(CSharpElement):
    def __init__(self) -> None:
        super().__init__()
        self.name: str = "void"


class CSharpParameter(CSharpElement):
    def __init__(self) -> None:
        super().__init__()
        self.type: str = "object"

    def __str__(self) -> str:
        return f"{self.type} {self.name}"


class CSharpException(CSharpElement):
    pass


def dump(types: Iterable[CSharpType], namespace: str, directory: str) -> None:
    for source in types:
        with open(f"{directory}/{source.name}.cs", "w") as file:
            file.writelines(f"{line}\n" for line in generate(source, namespace))


def generate(source: CSharpType, namespace: str) -> Generator[str, None, None]:
    yield "/**************************************************************************/"
    yield f"/*  {source.name}.cs  {" " * (65 - len(source.name))}*/"
    yield "/**************************************************************************/"
    yield "/*                         This file is part of:                          */"
    yield "/*                             GODOT ENGINE                               */"
    yield "/*                        https://godotengine.org                         */"
    yield "/**************************************************************************/"
    yield "/* Copyright (c) 2014-present Godot Engine contributors (see AUTHORS.md). */"
    yield "/* Copyright (c) 2007-2014 Juan Linietsky, Ariel Manzur.                  */"
    yield "/*                                                                        */"
    yield "/* Permission is hereby granted, free of charge, to any person obtaining  */"
    yield "/* a copy of this software and associated documentation files (the        */"
    yield "/* \"Software\"), to deal in the Software without restriction, including    */"
    yield "/* without limitation the rights to use, copy, modify, merge, publish,    */"
    yield "/* distribute, sublicense, and/or sell copies of the Software, and to     */"
    yield "/* permit persons to whom the Software is furnished to do so, subject to  */"
    yield "/* the following conditions:                                              */"
    yield "/*                                                                        */"
    yield "/* The above copyright notice and this permission notice shall be         */"
    yield "/* included in all copies or substantial portions of the Software.        */"
    yield "/*                                                                        */"
    yield "/* THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND,        */"
    yield "/* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF     */"
    yield "/* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. */"
    yield "/* IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY   */"
    yield "/* CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,   */"
    yield "/* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE      */"
    yield "/* SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                 */"
    yield "/**************************************************************************/"
    yield "/*              This file is generated. Edits will be lost.               */"
    yield "/**************************************************************************/"
    yield ""
    if dependencies := source.dependencies:
        yield from (f"using {dependency};" for dependency in dependencies)
        yield ""
    yield f"namespace {namespace};"
    yield ""
    yield from source


def indent(line: str) -> str:
    return f"    {line}".rstrip()


def camel(symbol: str) -> str:
    return symbol[0].lower() + pascal(symbol)[1:]


def pascal(symbol: str) -> str:
    return symbol.title().replace("_", "")
