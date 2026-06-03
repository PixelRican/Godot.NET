from typing import Any
import gdextension
import json

with open("gdextension_interface.json", "r") as file:
    data: dict[str, Any] = json.load(file)
gdextension.generate(data)
