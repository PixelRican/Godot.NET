using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

public static unsafe class Program
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)], EntryPoint = "GDExample_Initialize")]
    private static GDExtensionBool Initialize(GDExtensionInterfaceGetProcAddress getProcAddress,
        GDExtensionClassLibraryPtr library, GDExtensionInitialization* initialization)
    {
        GDExtensionInterface.Initialize(getProcAddress);
        initialization->MinimumInitializationLevel = GDExtensionInitializationScene;
        initialization->Userdata = library.Pointer;
        initialization->Initialize = new GDExtensionInitializeCallback(&InitializeExtension);
        initialization->Deinitialize = new GDExtensionDeinitializeCallback(&DeinitializeExtension);
        return GDExtensionBool.True;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void InitializeExtension(void* userdata, GDExtensionInitializationLevel level)
    {
        if (level == GDExtensionInitializationScene)
        {
            GDExampleMarshaller.RegisterClass(userdata);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DeinitializeExtension(void* userdata, GDExtensionInitializationLevel level)
    {
        if (level == GDExtensionInitializationScene)
        {
            GDExampleMarshaller.DeregisterClass(userdata);
        }
    }
}
