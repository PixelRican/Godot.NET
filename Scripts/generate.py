from gdextension import GDExtensionBindings
from interop import GDExtensionInterface
from typing import Any
import json

if __name__ == "__main__":
    with open("gdextension_interface.json", "r") as file:
        data: dict[str, Any] = json.load(file)
    bindings: GDExtensionBindings = GDExtensionBindings(data)
    interface: GDExtensionInterface = GDExtensionInterface(bindings)
    bindings.generate()
    interface.generate()
