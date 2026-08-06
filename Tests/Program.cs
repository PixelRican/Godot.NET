using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Godot.Interop;

namespace Godot.Tests;

public static unsafe class Program
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)], EntryPoint = "GDExample_Initialize")]
    private static bool Initialize(delegate* unmanaged[Cdecl]<byte*, void*> pGetProcAddress, void* pLibrary, GDExtensionInitialization* rInitialization)
    {
        try
        {
            GDExtensionInterface.Initialize(pGetProcAddress);
            *rInitialization = new GDExtensionInitialization
            {
                MinimumInitializationLevel = GDExtensionInitializationLevel.Scene,
                UserData = pLibrary,
                Initialize = &InitializeLevel,
                Deinitialize = &DeinitializeLevel
            };
            return true;
        }
        catch
        {
            return false;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void InitializeLevel(void* pToken, GDExtensionInitializationLevel pLevel)
    {
        if (pLevel == GDExtensionInitializationLevel.Scene)
        {
            GDExampleBridge.RegisterClass(pToken);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DeinitializeLevel(void* pToken, GDExtensionInitializationLevel pLevel)
    {
    }
}
