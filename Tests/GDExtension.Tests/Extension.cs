using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

file static unsafe class Extension
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)], EntryPoint = "GDExample_Initialize")]
    private static GDExtensionBool Initialize(GDExtensionInterfaceGetProcAddress getProcAddress, GDExtensionClassLibraryPtr library, GDExtensionInitialization* initialization)
    {
        GDExtensionInterface.Initialize(getProcAddress);
        initialization->MinimumInitializationLevel = GDExtensionInitializationScene;
        initialization->Userdata = library.Pointer;
        initialization->Initialize = new GDExtensionInitializeCallback(&InitializeLevel);
        initialization->Deinitialize = new GDExtensionDeinitializeCallback(&DeinitializeLevel);
        return new GDExtensionBool(true);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void InitializeLevel(void* token, GDExtensionInitializationLevel level)
    {
        if (level == GDExtensionInitializationScene)
        {
            GDExampleMarshaller.Initialize(new GDExtensionClassLibraryPtr(token));
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DeinitializeLevel(void* token, GDExtensionInitializationLevel level)
    {
    }
}
