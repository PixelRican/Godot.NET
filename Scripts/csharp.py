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
                    if line:
                        file.write("    " * self.indent_level)
                        file.write(line)
                    file.write("\n")

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
        pointer: str = "*" * symbol.endswith("*")
        if key.endswith(">"):
            return sub(r"(?:<|,\s)((?:const )?\w+\*?)", substitute, key) + pointer
        value: str | None = self.expansions.get(key)
        if value == "char":
            return f"char{pointer}"
        return (self.expansion(value) if value else key) + pointer

    def translate(self, string: str, translation: str) -> None:
        self.translations[string] = translation

    def translate_default(self, string: str, translation: str) -> str:
        return self.translations.setdefault(string, translation)

    def translation(self, string: str) -> str:
        def substitute(match: Match[str]) -> str:
            group: str = match.group()
            result: str = "{}"
            if group.startswith("`"):
                group = match.group(1)
                result = "`{}`"
            return result.format(self.translations.get(group, group))

        return self.translations.get(string) \
            or sub(r"`(\w+)`|([A-Z]{4,}+(_[A-Z]+)*)|([a-z]+(_[a-z]+)+)", substitute, string)

class MemberInfo:
    def __init__(self) -> None:
        self.name: str = "_"
        self.description: list[str] = []
        self.attributes: set[str] = set()

    @property
    def modifiers(self) -> str:
        return "public"

    def documentation(self, generator: SourceGenerator) -> Iterable[str]:
        if not self.description:
            return
        yield "/// <summary>"
        last: str = self.description[-1]
        for line in self.description:
            separator: str = "<br/>" * (line is not last)
            yield f"/// {generator.translation(line)}{separator}"
        yield "/// </summary>"

class TypeInfo(MemberInfo):
    def __init__(self) -> None:
        super().__init__()
        self.access_modifier: str = "public"
        self.dependencies: set[str] = set()

    @property
    def modifiers(self) -> str:
        return self.access_modifier

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
        yield from self.definition(generator)

    def definition(self, generator: SourceGenerator) -> Iterable[str]:
        raise NotImplementedError()

class EnumerationInfo(TypeInfo):
    def __init__(self) -> None:
        super().__init__()
        self.underlying_type: str = ""
        self.members: list[ConstantInfo] = []

    def definition(self, generator: SourceGenerator) -> Iterable[str]:
        if self.underlying_type:
            yield f"{self.access_modifier} enum {self.name} : {self.underlying_type}"
        else:
            yield f"{self.access_modifier} enum {self.name}"
        yield "{"
        if self.members:
            last: ConstantInfo = self.members[-1]
            with generator.indent():
                for member in self.members:
                    separator: str = "," * (member is not last)
                    yield from member.documentation(generator)
                    yield f"{generator.translation(member.name)} = {member.value}{separator}"
        yield "}"

class ConstantInfo(MemberInfo):
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
        modifiers: list[str] = [self.access_modifier]
        if not self.is_value_type and self.is_static:
            modifiers.append("static")
        if self.is_unsafe:
            modifiers.append("unsafe")
        return " ".join(modifiers)

    def definition(self, generator: SourceGenerator) -> Iterable[str]:
        yield f"{self.modifiers} {"struct" if self.is_value_type else "class"} {self.name}"
        yield "{"
        with generator.indent():
            separate: bool = False
            for member in self.fields:
                separate = True
                yield from member.documentation(generator)
                yield f"{member.modifiers} {generator.expansion(member.type)} {generator.translation(member.name)};"
            for member in self.methods:
                if separate:
                    yield ""
                separate = True
                parameters: str = ", ".join(f"{generator.expansion(parameter.type)} {generator.translation(parameter.name)}" for parameter in member.parameters)
                yield from member.documentation(generator)
                for attribute in member.attributes:
                    yield f"[{generator.translation(attribute)}]"
                yield f"{member.modifiers} {generator.expansion(member.return_type.name)} {generator.translation(member.name)}({parameters})"
                yield "{"
                with generator.indent():
                    yield from member.body
                yield "}"
        yield "}"

class FieldInfo(MemberInfo):
    def __init__(self) -> None:
        super().__init__()
        self.type: str = "object"
        self.access_modifier: str = "public"
        self.is_static: bool = False
        self.is_readonly: bool = False

    @property
    def modifiers(self) -> str:
        modifiers: list[str] = [self.access_modifier]
        if self.is_static:
            modifiers.append("static")
        if self.is_readonly:
            modifiers.append("readonly")
        return " ".join(modifiers)

class MethodInfo(MemberInfo):
    def __init__(self) -> None:
        super().__init__()
        self.return_type: ReturnTypeInfo = ReturnTypeInfo()
        self.parameters: list[ParameterInfo] = []
        self.body: Iterable[str] = ("throw new System.NotImplementedException();",)
        self.access_modifier: str = "public"
        self.is_static: bool = False

    @property
    def modifiers(self) -> str:
        return f"{self.access_modifier} static" if self.is_static else self.access_modifier

    def documentation(self, generator: SourceGenerator) -> Iterable[str]:
        yield from super().documentation(generator)
        for parameter in self.parameters:
            yield from parameter.documentation(generator)
        yield from self.return_type.documentation(generator)

class ReturnTypeInfo(MemberInfo):
    def __init__(self) -> None:
        super().__init__()
        self.name: str = "void"

    def documentation(self, generator: SourceGenerator) -> Iterable[str]:
        if not self.description:
            return
        yield "/// <returns>"
        last: str = self.description[-1]
        for line in self.description:
            separator: str = "<br/>" * (line is not last)
            yield f"/// {generator.translation(line)}{separator}"
        yield "/// </returns>"

class ParameterInfo(MemberInfo):
    def __init__(self) -> None:
        super().__init__()
        self.type: str = "object"

    def documentation(self, generator: SourceGenerator) -> Iterable[str]:
        if not self.description:
            return
        yield f"/// <param name=\"{generator.translation(self.name)}\">"
        last: str = self.description[-1]
        for line in self.description:
            separator: str = "<br/>" * (line is not last)
            yield f"/// {generator.translation(line)}{separator}"
        yield "/// </param>"

class ExceptionInfo(MemberInfo):
    def documentation(self, generator: SourceGenerator) -> Iterable[str]:
        if not self.description:
            return
        yield f"/// <exception cref=\"{generator.translation(self.name)}\">"
        last: str = self.description[-1]
        for line in self.description:
            separator: str = "<br/>" * (line is not last)
            yield f"/// {generator.translation(line)}{separator}"
        yield "/// </exception>"

def camel(symbol: str) -> str:
    return symbol[0].lower() + pascal(symbol)[1:]

def pascal(symbol: str) -> str:
    return symbol.title().replace("_", "")
