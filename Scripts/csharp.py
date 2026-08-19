from typing import Generator, Iterable, Iterator


class XMLDocumentation:
    def __init__(self) -> None:
        self.tag: str = "summary"
        self.attributes: Iterable[XMLAttribute] = ()
        self.description: Iterable[str] = ()

    def __iter__(self) -> Generator[str]:
        description: Iterator[str] = iter(self.description)
        if first_line := next(description, None):
            elements: list[str] = [self.tag] + [str(attribute) for attribute in self.attributes]
            header: str = " ".join(elements)
            yield f"/// <{header}>"
            yield f"/// {first_line}"
            yield from (f"/// {line}" for line in description)
            yield f"/// </{self.tag}>"


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


class CSharpElement:
    def __init__(self) -> None:
        self.name: str = "_"
        self.documentation: XMLDocumentation = XMLDocumentation()
        self.attributes: list[CSharpAttribute] = []


class EncapsulatedCSharpElement(CSharpElement):
    def __init__(self) -> None:
        super().__init__()
        self.is_public: bool = True

    @property
    def modifiers(self) -> str:
        return "public" if self.is_public else "private"


class CSharpType(EncapsulatedCSharpElement):
    def __init__(self) -> None:
        super().__init__()
        self.dependencies: set[str] = set()

    def __iter__(self) -> Generator[str]:
        def key(attribute: CSharpAttribute) -> str:
            return attribute.name

        yield from self.documentation
        yield from (str(attribute) for attribute in sorted(self.attributes, key=key))
        yield from self.definition()

    def definition(self) -> Generator[str]:
        raise NotImplementedError()


class CSharpEnumeration(CSharpType):
    def __init__(self) -> None:
        super().__init__()
        self.underlying_type: str = ""
        self.members: list[CSharpEnumerationConstant] = []

    def definition(self) -> Generator[str]:
        if self.underlying_type:
            yield f"{self.modifiers} enum {self.name} : {self.underlying_type}"
        else:
            yield f"{self.modifiers} enum {self.name}"
        yield "{"
        for constant in self.members:
            separator: str = "," * (constant is not self.members[-1])
            yield from (indent(line) for line in constant.documentation)
            yield indent(f"{constant.name} = {constant.value}{separator}")
        yield "}"


class CSharpEnumerationConstant(CSharpElement):
    def __init__(self) -> None:
        super().__init__()
        self.value: int = 0


class CSharpClass(CSharpType):
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


class CSharpField(EncapsulatedCSharpElement):
    def __init__(self) -> None:
        super().__init__()
        self.type: str = "object"
        self.is_static: bool = False
        self.is_readonly: bool = False

    def __iter__(self) -> Generator[str]:
        yield from self.documentation
        yield f"{self.modifiers} {self.type} {self.name};"

    @property
    def modifiers(self) -> str:
        modifiers: list[str] = [super().modifiers]
        if self.is_static:
            modifiers.append("static")
        if self.is_readonly:
            modifiers.append("readonly")
        return " ".join(modifiers)


class CSharpMethod(EncapsulatedCSharpElement):
    def __init__(self) -> None:
        super().__init__()
        self.return_type: CSharpReturnType = CSharpReturnType()
        self.parameters: list[CSharpParameter] = []
        self.exceptions: list[CSharpException] = []
        self.body: Iterable[str] = ("throw new System.NotImplementedException();",)
        self.is_static: bool = False

    @property
    def modifiers(self) -> str:
        return f"{super().modifiers} static" if self.is_static else super().modifiers

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
        yield f"{self.modifiers} {self.return_type.name} {self.name}({parameters})"
        yield "{"
        yield from (indent(line) for line in self.body)
        yield "}"


class CSharpReturnType(CSharpElement):
    def __init__(self) -> None:
        super().__init__()
        self.name: str = "void"
        self.documentation.tag = "returns"


class CSharpParameter(CSharpElement):
    def __init__(self) -> None:
        def attribute() -> Iterator[XMLAttribute]:
            yield XMLAttribute("name", self.name)

        super().__init__()
        self.type: str = "object"
        self.documentation.tag = "param"
        self.documentation.attributes = attribute()

    def __str__(self) -> str:
        return f"{self.type} {self.name}"


class CSharpException(CSharpElement):
    def __init__(self) -> None:
        def attribute() -> Iterator[XMLAttribute]:
            yield XMLAttribute("cref", self.name)

        super().__init__()
        self.documentation.tag = "exception"
        self.documentation.attributes = attribute()


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
