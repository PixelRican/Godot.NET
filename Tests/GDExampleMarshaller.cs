using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

public static unsafe class GDExampleMarshaller
{
    public static void RegisterClass(GDExtensionClassLibraryPtr library)
    {
        GDExtensionClassDB.RegisterClass(library,
                              "GDExample"u8,
                              "Sprite2D"u8,
                              new GDExtensionClassCreateInstance(&CreateInstance),
                              new GDExtensionClassFreeInstance(&FreeInstance));
        GDExtensionClassDB.RegisterPropertyGetter(library,
                                       "GDExample"u8,
                                       "GetAmplitude"u8,
                                       (delegate*<GDExtensionClassInstancePtr, double>)&GetAmplitude,
                                       GDExtensionVariantTypeFloat);
        GDExtensionClassDB.RegisterPropertySetter(library,
                                       "GDExample"u8,
                                       "SetAmplitude"u8,
                                       (delegate*<GDExtensionClassInstancePtr, double, void>)&SetAmplitude,
                                       GDExtensionVariantTypeFloat);
        GDExtensionClassDB.RegisterProperty(library,
                                 "GDExample"u8,
                                 "Amplitude"u8,
                                 GDExtensionVariantTypeFloat,
                                 "GetAmplitude"u8,
                                 "SetAmplitude"u8);
        GDExtensionClassDB.RegisterPropertyGetter(library,
                                       "GDExample"u8,
                                       "GetSpeed"u8,
                                       (delegate*<GDExtensionClassInstancePtr, double>)&GetSpeed,
                                       GDExtensionVariantTypeFloat);
        GDExtensionClassDB.RegisterPropertySetter(library,
                                       "GDExample"u8,
                                       "SetSpeed"u8,
                                       (delegate*<GDExtensionClassInstancePtr, double, void>)&SetSpeed,
                                       GDExtensionVariantTypeFloat);
        GDExtensionClassDB.RegisterProperty(library,
                                 "GDExample"u8,
                                 "Speed"u8,
                                 GDExtensionVariantTypeFloat,
                                 "GetSpeed"u8,
                                 "SetSpeed"u8);
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

    private static double GetAmplitude(GDExtensionClassInstancePtr instance)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
        return target.Amplitude;
    }

    private static void SetAmplitude(GDExtensionClassInstancePtr instance, double value)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
        target.Amplitude = value;
    }

    private static double GetSpeed(GDExtensionClassInstancePtr instance)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
        return target.Speed;
    }

    private static void SetSpeed(GDExtensionClassInstancePtr instance, double value)
    {
        GDExample target = GDExtensionMarshal.GetTarget<GDExample>(instance);
        target.Speed = value;
    }
}
