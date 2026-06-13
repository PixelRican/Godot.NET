using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

public static unsafe class GDExampleMarshaller
{
    public static void Initialize(GDExtensionClassLibraryPtr library)
    {
        GDExtensionClassDB.RegisterClass(library, "GDExample"u8, "Sprite2D"u8, &CreateInstance, &FreeInstance);
        GDExtensionClassDB.RegisterPropertyGetter(library, "GDExample"u8, "_get_amplitude"u8, &PropertyGetAmplitude, &PropertyGetAmplitude, GDExtensionVariantTypeFloat);
        GDExtensionClassDB.RegisterPropertySetter(library, "GDExample"u8, "_set_amplitude"u8, &PropertySetAmplitude, &PropertySetAmplitude, GDExtensionVariantTypeFloat);
        GDExtensionClassDB.RegisterProperty(library, "GDExample"u8, "amplitude"u8, "_get_amplitude"u8, "_set_amplitude"u8, GDExtensionVariantTypeFloat);
        GDExtensionClassDB.RegisterPropertyGetter(library, "GDExample"u8, "_get_speed"u8, &PropertyGetSpeed, &PropertyGetSpeed, GDExtensionVariantTypeFloat);
        GDExtensionClassDB.RegisterPropertySetter(library, "GDExample"u8, "_set_speed"u8, &PropertySetSpeed, &PropertySetSpeed, GDExtensionVariantTypeFloat);
        GDExtensionClassDB.RegisterProperty(library, "GDExample"u8, "speed"u8, "_get_speed"u8, "_set_speed"u8, GDExtensionVariantTypeFloat);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static GDExtensionObjectPtr CreateInstance(void* token)
    {
        return GDExtensionMarshal.CreateInstance(token, new GDExample(), "GDExample"u8);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void FreeInstance(void* token, GDExtensionClassInstancePtr instance)
    {
        GDExtensionMarshal.FreeInstance(instance);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertyGetAmplitude(void* token, GDExtensionClassInstancePtr instance, GDExtensionConstVariantPtr* arguments, GDExtensionInt argumentCount, GDExtensionVariantPtr result, GDExtensionCallError* error)
    {
        if (GDExtensionMarshal.ValidateArguments(arguments, argumentCount, error, []))
        {
            GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
            GDExtensionMarshal.WriteFloat(result, target.Amplitude);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertyGetAmplitude(void* token, GDExtensionClassInstancePtr instance, GDExtensionConstTypePtr* arguments, GDExtensionTypePtr result)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
        GDExtensionMarshal.WriteFloat(result, target.Amplitude);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertySetAmplitude(void* token, GDExtensionClassInstancePtr instance, GDExtensionConstVariantPtr* arguments, GDExtensionInt argumentCount, GDExtensionVariantPtr result, GDExtensionCallError* error)
    {
        if (GDExtensionMarshal.ValidateArguments(arguments, argumentCount, error, [GDExtensionVariantTypeFloat]))
        {
            GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
            target.Amplitude = GDExtensionMarshal.ReadFloat(arguments[0]);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertySetAmplitude(void* token, GDExtensionClassInstancePtr instance, GDExtensionConstTypePtr* arguments, GDExtensionTypePtr result)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
        target.Amplitude = GDExtensionMarshal.ReadFloat(arguments[0]);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertyGetSpeed(void* token, GDExtensionClassInstancePtr instance, GDExtensionConstVariantPtr* arguments, GDExtensionInt argumentCount, GDExtensionVariantPtr result, GDExtensionCallError* error)
    {
        if (GDExtensionMarshal.ValidateArguments(arguments, argumentCount, error, []))
        {
            GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
            GDExtensionMarshal.WriteFloat(result, target.Speed);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertyGetSpeed(void* token, GDExtensionClassInstancePtr instance, GDExtensionConstTypePtr* arguments, GDExtensionTypePtr result)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
        GDExtensionMarshal.WriteFloat(result, target.Speed);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertySetSpeed(void* token, GDExtensionClassInstancePtr instance, GDExtensionConstVariantPtr* arguments, GDExtensionInt argumentCount, GDExtensionVariantPtr result, GDExtensionCallError* error)
    {
        if (GDExtensionMarshal.ValidateArguments(arguments, argumentCount, error, [GDExtensionVariantTypeFloat]))
        {
            GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
            target.Speed = GDExtensionMarshal.ReadFloat(arguments[0]);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertySetSpeed(void* token, GDExtensionClassInstancePtr instance, GDExtensionConstTypePtr* arguments, GDExtensionTypePtr result)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
        target.Speed = GDExtensionMarshal.ReadFloat(arguments[0]);
    }
}
