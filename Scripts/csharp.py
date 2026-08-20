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


class CSharpAccessModifier(StrEnum):
    NONE = ""
    PUBLIC = "public"
    PRIVATE = "private"


class CSharpAttribute:
    def __init__(self, name: str, arguments: Iterable[str] = ()) -> None:
        self.__name: str = name
        self.__arguments: tuple[str, ...] = tuple(arguments)

    def __str__(self) -> str:
        if self.__arguments:
            arguments: str = ", ".join(argument for argument in self.__arguments)
            return f"[{self.__name}({arguments})]"
        return f"[{self.__name}]"

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
            attributes: Iterable[CSharpAttribute]
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
            description: Iterable[str],
            attributes: Iterable[CSharpAttribute],
            access_modifier: CSharpAccessModifier = CSharpAccessModifier.PUBLIC
        ) -> None:
        super().__init__(name, XMLDocumentation.summary(description), attributes)
        self.__access_modifier: CSharpAccessModifier = access_modifier

    @property
    def access_modifier(self) -> CSharpAccessModifier:
        return self.__access_modifier


class CSharpEnumeration(CSharpMember):
    def __init__(self) -> None:
        super().__init__()
        self.underlying_type: str = ""
        self.constants: list[CSharpConstant] = []

    def definition(self) -> Generator[str]:
        if self.underlying_type:
            yield f"{self.modifiers} enum {self.name} : {self.underlying_type}"
        else:
            yield f"{self.modifiers} enum {self.name}"
        yield "{"
        for constant in self.constants:
            separator: str = "," * (constant is not self.constants[-1])
            yield from (indent(line) for line in constant.documentation)
            yield indent(f"{constant.name} = {constant.value}{separator}")
        yield "}"


class CSharpConstant(CSharpElement):
    def __init__(self) -> None:
        super().__init__()
        self.value: int = 0


class CSharpClass(CSharpMember):
    def __init__(self) -> None:
        super().__init__()
        self.fields: list[CSharpField] = []
        self.methods: list[CSharpMethod] = []
        self.is_value_type: bool = False
        self.is_static: bool = False
        self.is_unsafe: bool = False

    @property
    def modifiers(self) -> str:
        modifiers: list[str] = [super().modifiers]
        if not self.is_value_type and self.is_static:
            modifiers.append("static")
        if self.is_unsafe:
            modifiers.append("unsafe")
        return " ".join(modifiers)

    def definition(self) -> Iterator[str]:
        yield f"{self.modifiers} {"struct" if self.is_value_type else "class"} {self.name}"
        yield "{"
        separate: bool = False
        for field in self.fields:
            separate = True
            yield from (indent(line) for line in field)
        for member in self.methods:
            if separate:
                yield ""
            else:
                separate = True
            yield from (indent(line) for line in member.generator())
        yield "}"


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


def dump(types: Iterable[CSharpMember], namespace: str, directory: str) -> None:
    for source in types:
        with open(f"{directory}/{source.name}.cs", "w") as file:
            file.writelines(f"{line}\n" for line in generate(source, namespace))


def generate(source: CSharpMember, namespace: str) -> Generator[str, None, None]:
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
    if dependencies := sorted(source.dependencies):
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
