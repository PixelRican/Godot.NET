from gdextension import GDExtensionInterface
from godot import GodotExtensionAPI
from json import load

if __name__ == "__main__":
    with open("gdextension_interface.json", "r") as file:
        interface: GDExtensionInterface = GDExtensionInterface(load(file))
    with open("extension_api.json", "r") as file:
        api: GodotExtensionAPI = GodotExtensionAPI(load(file))
    interface.generate()
    api.generate()
