from gdextension import GDExtensionInterface
from typing import Any
import json

def main() -> None:
    with open("gdextension_interface.json", "r") as file:
        data: dict[str, Any] = json.load(file)
    interface: GDExtensionInterface = GDExtensionInterface(data)
    interface.generate()

if __name__ == "__main__":
    main()
