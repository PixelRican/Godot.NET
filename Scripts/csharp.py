from contextlib import contextmanager
from re import sub, Match
from typing import Any, Iterable, Iterator


class SourceGenerator:
    def __init__(self, namespace: str, output_directory: str) -> None:
        self.__namespace: str = namespace
        self.__output_directory: str = output_directory
        self.__types: list[TypeInfo] = []
        self.__expansions: dict[str, str] = {
            "int8_t" : "sbyte",
            "uint8_t" : "byte",
            "int16_t" : "short",
            "uint16_t" : "ushort",
            "int32_t" : "int",
            "uint32_t" : "uint",
            "int64_t" : "long",
            "uint64_t" : "ulong",
            "size_t" : "nuint",
            "char" : "byte",
            "char16_t" : "char",
            "char32_t" : "uint",
            "wchar_t" : "void"
        }
        self.__translations: dict[str, str] = {"NULL" : "null"}
        self.__indent_level: int = 0

    @contextmanager
    def indent(self) -> Any:
        self.__indent_level += 1
        try:
            yield self
        finally:
            self.__indent_level -= 1

    def add_type(self, item: TypeInfo) -> None:
        self.__types.append(item)

    def get_expansion(self, alias: str) -> str:
        def substitute(match: Match[str]) -> str:
            group: str = match.group(1)
            substitution: str = self.get_expansion(group)
            return match.group().replace(group, substitution)

        pointer: str = "*" * alias.endswith("*")
        key: str = alias.removeprefix("const ").removesuffix("*")
        if key.endswith(">"):
            return sub(r"(?:<|,\s)((?:const )?\w+\*?)", substitute, key) + pointer
        if value := self.__expansions.get(key):
            return (value if value == "char" else self.get_expansion(value)) + pointer
        return key + pointer

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

    def generate(self) -> None:
        for info in self.__types:
            with open(f"{self.__output_directory}/{info.name}.cs", "w") as file:
                file.writelines(self.__source(info))

    def __source(self, info: TypeInfo) -> Iterable[str]:
        yield "/**************************************************************************/\n"
        yield f"/*  {info.name}.cs  {" " * (65 - len(info.name))}*/\n"
        yield "/**************************************************************************/\n"
        yield "/*                         This file is part of:                          */\n"
        yield "/*                             GODOT ENGINE                               */\n"
        yield "/*                        https://godotengine.org                         */\n"
        yield "/**************************************************************************/\n"
        yield "/* Copyright (c) 2014-present Godot Engine contributors (see AUTHORS.md). */\n"
        yield "/* Copyright (c) 2007-2014 Juan Linietsky, Ariel Manzur.                  */\n"
        yield "/*                                                                        */\n"
        yield "/* Permission is hereby granted, free of charge, to any person obtaining  */\n"
        yield "/* a copy of this software and associated documentation files (the        */\n"
        yield "/* \"Software\"), to deal in the Software without restriction, including    */\n"
        yield "/* without limitation the rights to use, copy, modify, merge, publish,    */\n"
        yield "/* distribute, sublicense, and/or sell copies of the Software, and to     */\n"
        yield "/* permit persons to whom the Software is furnished to do so, subject to  */\n"
        yield "/* the following conditions:                                              */\n"
        yield "/*                                                                        */\n"
        yield "/* The above copyright notice and this permission notice shall be         */\n"
        yield "/* included in all copies or substantial portions of the Software.        */\n"
        yield "/*                                                                        */\n"
        yield "/* THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND,        */\n"
        yield "/* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF     */\n"
        yield "/* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. */\n"
        yield "/* IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY   */\n"
        yield "/* CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,   */\n"
        yield "/* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE      */\n"
        yield "/* SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                 */\n"
        yield "/**************************************************************************/\n"
        yield "/*              This file is generated. Edits will be lost.               */\n"
        yield "/**************************************************************************/\n"
        yield "\n"
        separate: bool = False
        for dependency in sorted(info.dependencies):
            separate = True
            yield f"using {dependency};\n"
        if separate:
            yield "\n"
        yield f"namespace {self.__namespace};\n"
        yield "\n"
        for line in info.source(self):
            indent: str = "    " * self.__indent_level if line else ""
            yield f"{indent}{line}\n"


class XMLDocumentation:
    def __init__(self) -> None:
        self.tag: str = "summary"
        self.attributes: Iterable[XMLAttribute] = ()
        self.description: Iterable[str] = ()

    def source(self, generator: SourceGenerator) -> Iterator[str]:
        description: Iterator[str] = iter(self.description)
        if first_line := next(description, None):
            elements: list[str] = [self.tag]
            for attribute in self.attributes:
                elements.append(f"{attribute.name}=\"{generator.get_translation(attribute.value)}\"")
            header: str = " ".join(elements)
            yield f"/// <{header}>"
            yield f"/// {generator.get_translation(first_line)}"
            for line in description:
                yield f"/// {generator.get_translation(line)}"
            yield f"/// </{self.tag}>"


class XMLAttribute:
    def __init__(self, name: str, value: str) -> None:
        self.__name: str = name
        self.__value: str = value

    @property
    def name(self) -> str:
        return self.__name

    @property
    def value(self) -> str:
        return self.__value


class ProgramElement:
    def __init__(self) -> None:
        self.name: str = "_"
        self.documentation: XMLDocumentation = XMLDocumentation()
        self.attributes: set[str] = set()


class EncapsulatedProgramElement(ProgramElement):
    def __init__(self) -> None:
        super().__init__()
        self.is_public: bool = True

    @property
    def modifiers(self) -> str:
        return "public" if self.is_public else "private"


class TypeInfo(EncapsulatedProgramElement):
    def __init__(self) -> None:
        super().__init__()
        self.dependencies: set[str] = set()

    def source(self, generator: SourceGenerator) -> Iterator[str]:
        yield from self.documentation.source(generator)
        for attribute in sorted(self.attributes):
            yield f"[{generator.get_translation(attribute)}]"
        yield from self.definition(generator)

    def definition(self, generator: SourceGenerator) -> Iterator[str]:
        raise NotImplementedError()


class EnumerationInfo(TypeInfo):
    def __init__(self) -> None:
        super().__init__()
        self.underlying_type: str = ""
        self.members: list[ConstantInfo] = []

    def definition(self, generator: SourceGenerator) -> Iterator[str]:
        if self.underlying_type:
            yield f"{self.modifiers} enum {self.name} : {self.underlying_type}"
        else:
            yield f"{self.modifiers} enum {self.name}"
        yield "{"
        if self.members:
            last: ConstantInfo = self.members[-1]
            with generator.indent():
                for member in self.members:
                    separator: str = "," * (member is not last)
                    yield from member.documentation.source(generator)
                    yield f"{generator.get_translation(member.name)} = {member.value}{separator}"
        yield "}"


class ConstantInfo(ProgramElement):
    def __init__(self) -> None:
        super().__init__()
        self.value: int = 0


class ClassInfo(TypeInfo):
    def __init__(self) -> None:
        super().__init__()
        self.fields: list[FieldInfo] = []
        self.methods: list[MethodInfo] = []
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

    def definition(self, generator: SourceGenerator) -> Iterator[str]:
        yield f"{self.modifiers} {"struct" if self.is_value_type else "class"} {self.name}"
        yield "{"
        with generator.indent():
            separate: bool = False
            for member in self.fields:
                separate = True
                yield from member.documentation.source(generator)
                yield f"{member.modifiers} {generator.get_expansion(member.type)} {generator.get_translation(member.name)};"
            for member in self.methods:
                if separate:
                    yield ""
                separate = True
                yield from member.source(generator)
        yield "}"


class FieldInfo(EncapsulatedProgramElement):
    def __init__(self) -> None:
        super().__init__()
        self.type: str = "object"
        self.is_static: bool = False
        self.is_readonly: bool = False

    @property
    def modifiers(self) -> str:
        modifiers: list[str] = [super().modifiers]
        if self.is_static:
            modifiers.append("static")
        if self.is_readonly:
            modifiers.append("readonly")
        return " ".join(modifiers)


class MethodInfo(EncapsulatedProgramElement):
    def __init__(self) -> None:
        super().__init__()
        self.return_type: ReturnTypeInfo = ReturnTypeInfo()
        self.parameters: list[ParameterInfo] = []
        self.exceptions: list[ExceptionInfo] = []
        self.body: Iterable[str] = ("throw new System.NotImplementedException();",)
        self.is_static: bool = False

    @property
    def modifiers(self) -> str:
        return f"{super().modifiers} static" if self.is_static else super().modifiers

    def source(self, generator: SourceGenerator) -> Iterator[str]:
        yield from self.documentation.source(generator)
        for parameter in self.parameters:
            yield from parameter.documentation.source(generator)
        for exception in self.exceptions:
            yield from exception.documentation.source(generator)
        yield from self.return_type.documentation.source(generator)
        for attribute in sorted(self.attributes):
            yield f"[{generator.get_translation(attribute)}]"
        parameters: str = ", ".join(f"{generator.get_expansion(parameter.type)} {generator.get_translation(parameter.name)}" for parameter in self.parameters)
        yield f"{self.modifiers} {generator.get_expansion(self.return_type.name)} {generator.get_translation(self.name)}({parameters})"
        yield "{"
        with generator.indent():
            yield from self.body
        yield "}"


class ReturnTypeInfo(ProgramElement):
    def __init__(self) -> None:
        super().__init__()
        self.name: str = "void"
        self.documentation.tag = "returns"


class ParameterInfo(ProgramElement):
    def __init__(self) -> None:
        def attribute() -> Iterator[XMLAttribute]:
            yield XMLAttribute("name", self.name)

        super().__init__()
        self.type: str = "object"
        self.documentation.tag = "param"
        self.documentation.attributes = attribute()


class ExceptionInfo(ProgramElement):
    def __init__(self) -> None:
        def attribute() -> Iterator[XMLAttribute]:
            yield XMLAttribute("cref", self.name)

        super().__init__()
        self.documentation.tag = "exception"
        self.documentation.attributes = attribute()


def camel(symbol: str) -> str:
    return symbol[0].lower() + pascal(symbol)[1:]


def pascal(symbol: str) -> str:
    return symbol.title().replace("_", "")
