using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Godot.Interop;

namespace Godot.Tests;

public static unsafe class GDExampleBridge
{
    public static void RegisterClass(void* pToken)
    {
        GDExtensionClassDB.RegisterClass(pToken, "GDExample"u8, "Sprite2D"u8, &CreateInstance, &FreeInstance, &GetVirtual);
        GDExtensionClassDB.RegisterPropertyGetter(pToken, "GDExample"u8, "_get_amplitude"u8, &PropertyGetAmplitude, &PropertyGetAmplitude, GDExtensionVariantType.Float);
        GDExtensionClassDB.RegisterPropertySetter(pToken, "GDExample"u8, "_set_amplitude"u8, &PropertySetAmplitude, &PropertySetAmplitude, GDExtensionVariantType.Float);
        GDExtensionClassDB.RegisterProperty(pToken, "GDExample"u8, "amplitude"u8, "_get_amplitude"u8, "_set_amplitude"u8, GDExtensionVariantType.Float);
        GDExtensionClassDB.RegisterPropertyGetter(pToken, "GDExample"u8, "_get_speed"u8, &PropertyGetSpeed, &PropertyGetSpeed, GDExtensionVariantType.Float);
        GDExtensionClassDB.RegisterPropertySetter(pToken, "GDExample"u8, "_set_speed"u8, &PropertySetSpeed, &PropertySetSpeed, GDExtensionVariantType.Float);
        GDExtensionClassDB.RegisterProperty(pToken, "GDExample"u8, "speed"u8, "_get_speed"u8, "_set_speed"u8, GDExtensionVariantType.Float);
        GDExtensionClassDB.RegisterSignal(pToken, "GDExample"u8, "position_changed"u8, "new_position"u8, GDExtensionVariantType.Vector2);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void* CreateInstance(void* pToken)
    {
        return GDExtensionMarshal.CreateInstance(pToken, new GDExample(), "GDExample"u8);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void FreeInstance(void* pToken, void* pInstance)
    {
        GDExtensionMarshal.FreeInstance(pInstance);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static delegate* unmanaged[Cdecl]<void*, void**, void*, void> GetVirtual(void* pToken, GDExtensionStringName* pMethodName)
    {
        using StringName nameOfProcess = new StringName("_process"u8);

        if (((StringName*)pMethodName)->Equals(nameOfProcess))
        {
            return &VirtualProcess;
        }

        return default;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertyGetAmplitude(void* pToken, void* pInstance, GDExtensionVariant** pArguments, long pArgumentCount, GDExtensionVariant* rResult, GDExtensionCallError* rError)
    {
        if (GDExtensionMarshal.ValidateArguments(pArguments, pArgumentCount, rError, []))
        {
            GDExample target = GDExtensionMarshal.GetTarget<GDExample>(pInstance);
            GDExtensionMarshal.WriteFloat(rResult, target.Amplitude);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertyGetAmplitude(void* pToken, void* pInstance, void** pArguments, void* rResult)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(pInstance);
        GDExtensionMarshal.WriteFloat(rResult, target.Amplitude);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertySetAmplitude(void* pToken, void* pInstance, GDExtensionVariant** pArguments, long pArgumentCount, GDExtensionVariant* rResult, GDExtensionCallError* rError)
    {
        if (GDExtensionMarshal.ValidateArguments(pArguments, pArgumentCount, rError, [GDExtensionVariantType.Float]))
        {
            GDExample target = GDExtensionMarshal.GetTarget<GDExample>(pInstance);
            target.Amplitude = GDExtensionMarshal.ReadFloat(pArguments[0]);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertySetAmplitude(void* pToken, void* pInstance, void** pArguments, void* rResult)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(pInstance);
        target.Amplitude = GDExtensionMarshal.ReadFloat(pArguments[0]);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertyGetSpeed(void* pToken, void* pInstance, GDExtensionVariant** pArguments, long pArgumentCount, GDExtensionVariant* rResult, GDExtensionCallError* rError)
    {
        if (GDExtensionMarshal.ValidateArguments(pArguments, pArgumentCount, rError, []))
        {
            GDExample target = GDExtensionMarshal.GetTarget<GDExample>(pInstance);
            GDExtensionMarshal.WriteFloat(rResult, target.Speed);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertyGetSpeed(void* pToken, void* pInstance, void** pArguments, void* rResult)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(pInstance);
        GDExtensionMarshal.WriteFloat(rResult, target.Speed);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertySetSpeed(void* pToken, void* pInstance, GDExtensionVariant** pArguments, long pArgumentCount, GDExtensionVariant* rResult, GDExtensionCallError* rError)
    {
        if (GDExtensionMarshal.ValidateArguments(pArguments, pArgumentCount, rError, [GDExtensionVariantType.Float]))
        {
            GDExample target = GDExtensionMarshal.GetTarget<GDExample>(pInstance);
            target.Speed = GDExtensionMarshal.ReadFloat(pArguments[0]);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PropertySetSpeed(void* pToken, void* pInstance, void** pArguments, void* rResult)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(pInstance);
        target.Speed = GDExtensionMarshal.ReadFloat(pArguments[0]);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void VirtualProcess(void* pInstance, void** pArguments, void* rResult)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(pInstance);
        target.Process(GDExtensionMarshal.ReadFloat(pArguments[0]));
    }
}
