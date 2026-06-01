import api
import gdextension
import json

with open("gdextension_interface.json", "r") as file:
    interface = gdextension.Interface(json.load(file))
with open("../Source/GDExtensionInterface.cs", "w") as file:
    file.writelines(interface.generate())
with open("extension_api.json", "r") as file:
    api = api.Extension(json.load(file))
