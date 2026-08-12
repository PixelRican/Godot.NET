from csharp import SourceGenerator
from json import load
from typing import Any
import gdextension

if __name__ == "__main__":
    with open("gdextension_interface.json", "r") as file:
        interop_data: dict[str, Any] = load(file)
    interop_generator: SourceGenerator = gdextension.parse(interop_data)
    interop_generator.generate()
