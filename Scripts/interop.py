from gdextension import GDExtensionInterface, GDExtensionFunction
from godot import GodotBindings
from typing import Any

class InteropServices:
    def __init__(self, gdextension: GDExtensionInterface, godot: GodotBindings) -> None:
        self.copyright: list[str] = gdextension.copyright
        self.types: dict[str, Any] = {
            "GDExtensionInterface" : GDExtensionLoader(gdextension)
        }

    def generate(self) -> None:
        for instance in self.types.values():
            instance.generate(self.copyright)

class GDExtensionLoader:
    def __init__(self, bindings: GDExtensionInterface) -> None:
        self.properties: dict[str, GDExtensionFunction] = {
            function.name.removeprefix("GDExtensionInterface") : function for function in bindings.interface.values()
        }

    def generate(self, copyright_text: str) -> None:
        with open(f"../Source/Godot.InteropServices/GDExtensionInterface.cs", "w") as file:
            file.write("/**************************************************************************/\n")
            file.write("/*  GDExtensionInterface.cs                                               */\n")
            for line in copyright_text:
                file.write(f"{line}\n")
            file.write("\n")
            file.write("using System;\n")
            file.write("using Godot.GDExtension;\n")
            file.write("\n")
            file.write("namespace Godot.InteropServices;\n")
            file.write("\n")
            file.write("#pragma warning disable CS0618 // Deprecated functions are loaded to maintain backwards compatibility with earlier versions.\n")
            file.write("public sealed unsafe class GDExtensionInterface\n")
            file.write("{\n")
            file.write("    public GDExtensionInterface(GDExtensionInterfaceGetProcAddress getProcAddress)\n")
            file.write("    {\n")
            file.write("        ArgumentNullException.ThrowIfNull(getProcAddress.Method, nameof(getProcAddress));\n")
            for name, function in self.properties.items():
                file.write(f"        {name} = ({function.name})Load(getProcAddress, \"{function.entry_point}\"u8);\n")
            file.write("    }\n")
            for name, function in self.properties.items():
                file.write("\n")
                file.write(f"    public {function.name} {name} {{ get; }}\n")
            file.write("\n")
            file.write("    private static GDExtensionInterfaceFunctionPtr Load(GDExtensionInterfaceGetProcAddress getProcAddress, ReadOnlySpan<byte> functionName)\n")
            file.write("    {\n")
            file.write("        fixed (byte* p_function_name = functionName)\n")
            file.write("        {\n")
            file.write("            GDExtensionInterfaceFunctionPtr function = getProcAddress.Invoke(p_function_name);\n")
            file.write("\n")
            file.write("            if (function.Method == null)\n")
            file.write("            {\n")
            file.write("                throw new ArgumentException($\"Failed to load \\\"{new string((sbyte*)p_function_name)}\\\" from the specified address loader.\", nameof(getProcAddress));\n")
            file.write("            }\n")
            file.write("\n")
            file.write("            return function;\n")
            file.write("        }\n")
            file.write("    }\n")
            file.write("}\n")
            file.write("#pragma warning disable CS0618 // Deprecated functions are loaded to maintain backwards compatibility with earlier versions.\n")
