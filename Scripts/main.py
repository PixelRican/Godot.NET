from gdextension import GDExtensionInterface
from json import load
from typing import Any

if __name__ == "__main__":
    with open("data/gdextension_interface.json", "r") as file:
        interop_data: dict[str, Any] = load(file)
    GDExtensionInterface(interop_data).dump("Godot.Interop", "../Source/Interop")
