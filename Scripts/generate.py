from gdextension import GDExtensionInterface
import json

if __name__ == "__main__":
    with open("gdextension_interface.json", "r") as file:
        interface: GDExtensionInterface = GDExtensionInterface(json.load(file))
    interface.generate()
