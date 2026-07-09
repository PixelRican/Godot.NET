from gdextension import GDExtensionInterface
from typing import Any
import json

with open("gdextension_interface.json", "r") as file:
    data: dict[str, Any] = json.load(file)
interface: GDExtensionInterface = GDExtensionInterface(data)
interface.generate()
