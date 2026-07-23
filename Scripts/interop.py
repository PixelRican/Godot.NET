from gdextension import GDExtensionBindings, FunctionInfo

class GDExtensionInterface:
    def __init__(self, bindings: GDExtensionBindings) -> None:
        self.bindings: GDExtensionBindings = bindings
        self.members: list[GDExtensionInterfaceMember] = [
            GDExtensionInterfaceMember(function) for function in bindings.interface.values()
        ]

    def generate(self) -> None:
        with open(f"../Source/Godot.InteropServices/GDExtensionInterface.cs", "w") as file:
            file.write("/**************************************************************************/\n")
            file.write("/*  GDExtensionInterface.cs                                               */\n")
            for line in self.bindings.copyright:
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
            for member in self.members:
                file.write(f"    private readonly {member.function.name} {member.field};\n")
            file.write("\n")
            file.write("    public GDExtensionInterface(GDExtensionInterfaceGetProcAddress getProcAddress)\n")
            file.write("    {\n")
            file.write("        ArgumentNullException.ThrowIfNull(getProcAddress.Method, nameof(getProcAddress));\n")
            for member in self.members:
                file.write(f"        {member.field} = ({member.function.name})Load(getProcAddress, \"{member.function.entry_point}\"u8);\n")
            file.write("    }\n")
            for member in self.members:
                file.write("\n")
                file.write(f"    public {member.function.name} {member.property}\n")
                file.write("    {\n")
                file.write(f"        get => {member.field};\n")
                file.write("    }\n")
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

class GDExtensionInterfaceMember:
    def __init__(self, function: FunctionInfo) -> None:
        self.function: FunctionInfo = function
        self.property: str = function.name.removeprefix("GDExtensionInterface")
        self.field: str = f"_{self.property[0].lower()}{self.property[1:]}"
