using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Godot.GDExtension;
using Godot.InteropServices;

namespace Godot.Tests;

public static unsafe class GodotBridge
{
    private static GDExtensionInterface? s_gdExtensionInterface;

    public static GDExtensionInterface GDExtensionInterface
    {
        get
        {
            GDExtensionInterface? value = s_gdExtensionInterface;

            if (value == null)
            {
                ThrowForUninitialized();
            }

            return value;
        }
    }

    public static GDExtensionBool Initialize(
        GDExtensionInterfaceGetProcAddress getProcAddress,
        GDExtensionClassLibraryPtr library,
        GDExtensionInitialization* initialization,
        GDExtensionInitializationLevel minimumInitializationLevel)
    {
        try
        {
            s_gdExtensionInterface = new GDExtensionInterface(getProcAddress);
            initialization->minimum_initialization_level = minimumInitializationLevel;
            initialization->userdata = library.Pointer;
            initialization->initialize = new GDExtensionInitializeCallback(&InitializeLevel);
            initialization->deinitialize = new GDExtensionDeinitializeCallback(&DeinitializeLevel);
            return new GDExtensionBool(true);
        }
        catch
        {
            return new GDExtensionBool(false);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void InitializeLevel(void* token, GDExtensionInitializationLevel level)
    {
        if (level != GDEXTENSION_INITIALIZATION_SCENE)
        {
            return;
        }

        VariantBridge.Initialize();
        StringBridge.Initialize();
        StringNameBridge.Initialize();
        ObjectBridge.Initialize();
        Sprite2DBridge.Initialize();
        GDExampleBridge.RegisterClass(new GDExtensionClassLibraryPtr(token));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DeinitializeLevel(void* token, GDExtensionInitializationLevel level)
    {
    }

    [DoesNotReturn]
    private static void ThrowForUninitialized()
    {
        throw new InvalidOperationException("GodotBridge has not been initialized.");
    }
}
