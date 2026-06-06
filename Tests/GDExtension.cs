using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

using static GDExtensionInitializationLevel;

internal static unsafe class GDExtension
{
    private static GDExtensionClassLibraryPtr s_library;

    public static GDExtensionClassLibraryPtr Library
    {
        get => s_library;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)], EntryPoint = "Godot.NET.Tests.GDExtension.Initialize")]
    private static GDExtensionBool Initialize(GDExtensionInterfaceGetProcAddress getProcAddress,
        GDExtensionClassLibraryPtr library, GDExtensionInitialization* initialization)
    {
        s_library = library;
        GDExtensionInterface.Initialize(getProcAddress);
        initialization->Initialize = new GDExtensionInitializeCallback(&InitializeModule);
        initialization->Deinitialize = new GDExtensionDeinitializeCallback(&DeinitializeModule);
        initialization->Userdata = null;
        initialization->MinimumInitializationLevel = GDExtensionInitializationScene;
        return GDExtensionBool.True;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void InitializeModule(void* userdata, GDExtensionInitializationLevel level)
    {
        if (level == GDExtensionInitializationScene)
        {
            GDExampleMarshaller.RegisterClass();
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DeinitializeModule(void* userdata, GDExtensionInitializationLevel level)
    {
    }
}
