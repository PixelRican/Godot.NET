from gdextension import GDExtensionInterface
from godot import GodotExtensionAPI
from json import load
from typing import Any


if __name__ == "__main__":
    with open("data/gdextension_interface.json", "r") as file:
        data: dict[str, Any] = load(file)
    GDExtensionInterface(data).dump("Godot.Interop", "../Source/Interop")
    with open("data/extension_api.json", "r") as file:
        data: dict[str, Any] = load(file)
    GodotExtensionAPI(data)
