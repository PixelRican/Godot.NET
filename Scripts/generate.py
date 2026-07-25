from gdextension import GDExtensionInterface
from godot import GodotBindings
from interop import InteropServices
import json

if __name__ == "__main__":
    with open("gdextension_interface.json", "r") as file:
        gdextension: GDExtensionInterface = GDExtensionInterface(json.load(file))
    with open("extension_api.json", "r") as file:
        godot: GodotBindings = GodotBindings(json.load(file))
    interop: InteropServices = InteropServices(gdextension, godot)
    gdextension.generate()
    interop.generate()
