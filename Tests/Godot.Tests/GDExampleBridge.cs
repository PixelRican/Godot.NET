using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Godot.GDExtension;

namespace Godot.Tests;

public static unsafe class GDExampleBridge
{
    public static void RegisterClass(GDExtensionClassLibraryPtr library)
    {
        GDExtensionClassDB.RegisterClass(library, "GDExample"u8, "Sprite2D"u8, &CreateInstance, &FreeInstance, &GetVirtual);
        GDExtensionClassDB.RegisterPropertyGetter(library, "GDExample"u8, "_get_amplitude"u8, &PropertyGetAmplitude, &PropertyGetAmplitude, GDEXTENSION_VARIANT_TYPE_FLOAT);
        GDExtensionClassDB.RegisterPropertySetter(library, "GDExample"u8, "_set_amplitude"u8, &PropertySetAmplitude, &PropertySetAmplitude, GDEXTENSION_VARIANT_TYPE_FLOAT);
        GDExtensionClassDB.RegisterProperty(library, "GDExample"u8, "amplitude"u8, "_get_amplitude"u8, "_set_amplitude"u8, GDEXTENSION_VARIANT_TYPE_FLOAT);
        GDExtensionClassDB.RegisterPropertyGetter(library, "GDExample"u8, "_get_speed"u8, &PropertyGetSpeed, &PropertyGetSpeed, GDEXTENSION_VARIANT_TYPE_FLOAT);
        GDExtensionClassDB.RegisterPropertySetter(library, "GDExample"u8, "_set_speed"u8, &PropertySetSpeed, &PropertySetSpeed, GDEXTENSION_VARIANT_TYPE_FLOAT);
        GDExtensionClassDB.RegisterProperty(library, "GDExample"u8, "speed"u8, "_get_speed"u8, "_set_speed"u8, GDEXTENSION_VARIANT_TYPE_FLOAT);
        GDExtensionClassDB.RegisterSignal(library, "GDExample"u8, "position_changed"u8, "new_position"u8, GDEXTENSION_VARIANT_TYPE_VECTOR2);
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
    private static GDExtensionClassCallVirtual GetVirtual(void* token, GDExtensionConstStringNamePtr methodName)
    {
        using StringName processName = new StringName("_process"u8);

        if (((StringName*)methodName.Pointer)->Equals(processName))
        {
            return new GDExtensionClassCallVirtual(&VirtualProcess);
        }

        return default;
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
        if (GDExtensionMarshal.ValidateArguments(arguments, argumentCount, error, [GDEXTENSION_VARIANT_TYPE_FLOAT]))
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
        if (GDExtensionMarshal.ValidateArguments(arguments, argumentCount, error, [GDEXTENSION_VARIANT_TYPE_FLOAT]))
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

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void VirtualProcess(GDExtensionClassInstancePtr instance, GDExtensionConstTypePtr* arguments, GDExtensionTypePtr result)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
        target.Process(GDExtensionMarshal.ReadFloat(arguments[0]));
    }
}
