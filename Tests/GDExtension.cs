using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

using static GDExtensionInitializationLevel;

internal static unsafe class GDExtension
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)], EntryPoint = "Godot.NET.Tests.GDExtension.Initialize")]
    private static GDExtensionBool Initialize(GDExtensionInterfaceGetProcAddress getProcAddress,
        GDExtensionClassLibraryPtr library, GDExtensionInitialization* initialization)
    {
        initialization->Initialize = new GDExtensionInitializeCallback(&InitializeModule);
        initialization->Deinitialize = new GDExtensionDeinitializeCallback(&DeinitializeModule);
        initialization->Userdata = null;
        initialization->MinimumInitializationLevel = GDExtensionInitializationScene;
        return new GDExtensionBool(1);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void InitializeModule(void* userdata, GDExtensionInitializationLevel level)
    {
        if (level != GDExtensionInitializationScene)
        {
            return;
        }

        File.WriteAllText("log.txt", "Hello World!\n");
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DeinitializeModule(void* userdata, GDExtensionInitializationLevel level)
    {
        if (level != GDExtensionInitializationScene)
        {
            return;
        }

        File.AppendAllText("log.txt", "Goodbye World!\n");
    }
}
