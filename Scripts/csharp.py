from contextlib import contextmanager
from re import sub, Match
from typing import Any, Iterable

class SourceGenerator:
    def __init__(self) -> None:
        self.types: list[TypeInfo] = []
        self.expansions: dict[str, str] = {
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
        self.translations: dict[str, str] = {"NULL" : "null"}
        self.namespace: str = "Godot"
        self.output_directory: str = "."
        self.indent_level: int = 0

    def generate(self) -> None:
        for info in self.types:
            with open(f"{self.output_directory}/{info.name}.cs", "w") as file:
                for line in info.source(self):
                    indent: str = "    " * self.indent_level
                    file.write(f"{indent}{line}\n")

    @contextmanager
    def indent(self) -> Any:
        self.indent_level += 1
        try:
            yield self
        finally:
            self.indent_level -= 1

    def register(self, info: TypeInfo) -> None:
        self.types.append(info)

    def expand(self, symbol: str, expansion: str) -> None:
        self.expansions[symbol] = expansion

    def expand_default(self, symbol: str, expansion: str) -> str:
        return self.expansions.setdefault(symbol, expansion)

    def expansion(self, symbol: str) -> str:
        def substitute(match: Match[str]) -> str:
            group: str = match.group(1)
            substitution: str = self.expansion(group)
            return match.group().replace(group, substitution)

        key: str = symbol.removeprefix("const ").removesuffix("*")
        value: str = self.expansions.get(key, "")
        pointer: str = "*" * symbol.endswith("*")
        if not value:
            return key + pointer
        if value.startswith("delegate*"):
            return sub(r"(?:<|,\s)((?:const )*\w+\**)", substitute, value)
        return self.expansion(value) + pointer

    def translate(self, string: str, translation: str) -> None:
        self.translations[string] = translation

    def translate_default(self, string: str, translation: str) -> str:
        return self.translations.setdefault(string, translation)

    def translation(self, string: str) -> str:
        def substitute(match: Match[str]) -> str:
            if match.group() == "NULL":
                return "null"
            group: str = match.group(1)
            return f"`{self.translations.get(group, group)}`"

        return self.translations.get(string) or sub(r"`(\w+)`|NULL", substitute, string)

class MemberInfo:
    def __init__(self) -> None:
        self.name: str = "A"
        self.description: list[str] = []
        self.attributes: set[str] = set()

    def documentation(self, generator: SourceGenerator) -> Iterable[str]:
        if not self.description:
            return
        yield "/// <summary>"
        last: str = self.description[-1]
        for line in self.description:
            separator: str = "<br/>" * (line is not last)
            yield f"/// {generator.translation(line)}{separator}"
        yield "/// </summary>"

    def definition(self, generator: SourceGenerator) -> Iterable[str]:
        raise NotImplementedError()

class TypeInfo(MemberInfo):
    def __init__(self) -> None:
        super().__init__()
        self.dependencies: set[str] = set()
        self.base_type: str = ""

    @property
    def kind(self) -> str:
        raise NotImplementedError()

    def source(self, generator: SourceGenerator) -> Iterable[str]:
        yield "/**************************************************************************/"
        yield f"/*  {self.name}.cs  {" " * (65 - len(self.name))}*/"
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
        separate: bool = False
        for dependency in sorted(self.dependencies):
            separate = True
            yield f"using {dependency};"
        if separate:
            yield ""
        yield f"namespace {generator.namespace};"
        yield ""
        yield from self.documentation(generator)
        for attribute in sorted(self.attributes):
            yield f"[{generator.translation(attribute)}]"
        if self.base_type:
            yield f"public {self.kind} {self.name} : {self.base_type}"
        else:
            yield f"public {self.kind} {self.name}"
        yield "{"
        with generator.indent():
            yield from self.definition(generator)
        yield "}"

class EnumerationInfo(TypeInfo):
    def __init__(self) -> None:
        super().__init__()
        self.members: list[EnumerationConstantInfo] = []

    @property
    def kind(self) -> str:
        return "enum"

    def definition(self, generator: SourceGenerator) -> Iterable[str]:
        if not self.members:
            return
        last: EnumerationConstantInfo = self.members[-1]
        for member in self.members:
            separator: str = "," * (member is not last)
            yield from member.documentation(generator)
            yield f"{generator.translation(member.name)} = {member.value}{separator}"

class EnumerationConstantInfo(MemberInfo):
    def __init__(self) -> None:
        super().__init__()
        self.value: int = 0

class StructureInfo(TypeInfo):
    def __init__(self) -> None:
        super().__init__()
        self.is_unsafe: bool = False
        self.members: list[StructureFieldInfo] = []

    @property
    def kind(self) -> str:
        return "unsafe struct" if self.is_unsafe else "struct"

    def definition(self, generator: SourceGenerator) -> Iterable[str]:
        for member in self.members:
            yield from member.documentation(generator)
            yield f"public {generator.expansion(member.type)} {generator.translation(member.name)};"

class StructureFieldInfo(MemberInfo):
    def __init__(self) -> None:
        super().__init__()
        self.type: str = "object"

def camel(symbol: str) -> str:
    return symbol[0].lower() + pascal(symbol)[1:]

def pascal(symbol: str) -> str:
    return symbol.title().replace("_", "")
