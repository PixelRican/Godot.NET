from gdextension import GDExtensionInterface
from json import load

if __name__ == "__main__":
    with open("gdextension_interface.json", "r") as file:
        interface: GDExtensionInterface = GDExtensionInterface(load(file))
    interface.generate()
