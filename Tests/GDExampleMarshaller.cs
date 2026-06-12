using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

public static unsafe class GDExampleMarshaller
{
    public static void RegisterClass(GDExtensionClassLibraryPtr library)
    {
        using GDStringName className = new GDStringName("GDExample"u8);
        using GDStringName parentClassName = new GDStringName("Sprite2D"u8);
        GDExtensionClassCreationInfo classInfo = new GDExtensionClassCreationInfo
        {
            ClassUserdata = library.Pointer,
            CreateInstanceFunc = new GDExtensionClassCreateInstance(&CreateInstance),
            FreeInstanceFunc = new GDExtensionClassFreeInstance(&FreeInstance),
        };
        GDExtensionInterface.ClassdbRegisterExtensionClass(library,
                                                           new GDExtensionConstStringNamePtr(&className),
                                                           new GDExtensionConstStringNamePtr(&parentClassName),
                                                           &classInfo);
        GDMarshal.BindMethod(library,
                             "GDExample"u8,
                             "GetAmplitude"u8,
                             (delegate*<GDExtensionClassInstancePtr, double>)&GetAmplitude,
                             GDExtensionVariantTypeFloat);
        GDMarshal.BindMethod(library,
                             "GDExample"u8,
                             "SetAmplitude"u8,
                             (delegate*<GDExtensionClassInstancePtr, double, void>)&SetAmplitude,
                             "value"u8,
                             GDExtensionVariantTypeFloat);
        GDMarshal.BindProperty(library,
                               "GDExample"u8,
                               "Amplitude"u8,
                               GDExtensionVariantTypeFloat,
                               "GetAmplitude"u8,
                               "SetAmplitude"u8);
        GDMarshal.BindMethod(library,
                             "GDExample"u8,
                             "GetSpeed"u8,
                             (delegate*<GDExtensionClassInstancePtr, double>)&GetSpeed,
                             GDExtensionVariantTypeFloat);
        GDMarshal.BindMethod(library,
                             "GDExample"u8,
                             "SetSpeed"u8,
                             (delegate*<GDExtensionClassInstancePtr, double, void>)&SetSpeed,
                             "value"u8,
                             GDExtensionVariantTypeFloat);
        GDMarshal.BindProperty(library,
                               "GDExample"u8,
                               "Speed"u8,
                               GDExtensionVariantTypeFloat,
                               "GetSpeed"u8,
                               "SetSpeed"u8);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static GDExtensionObjectPtr CreateInstance(void* classUserdata)
    {
        using GDStringName className = new GDStringName("GDExample"u8);
        using GDStringName parentClassName = new GDStringName("Sprite2D"u8);
        GDExtensionObjectPtr parent = GDExtensionInterface.ClassdbConstructObject(new GDExtensionConstStringNamePtr(&parentClassName));
        GDExample self = new GDExample(parent);
        GDExtensionClassInstancePtr instance = GDMarshal.ToPointer(new GCHandle<GDExample>(self));
        GDExtensionInterface.ObjectSetInstance(parent,
                                               new GDExtensionConstStringNamePtr(&className),
                                               instance);
        GDExtensionInstanceBindingCallbacks callbacks = default;
        GDExtensionInterface.ObjectSetInstanceBinding(parent, classUserdata, instance.Pointer, &callbacks);
        return parent;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void FreeInstance(void* classUserdata, GDExtensionClassInstancePtr instance)
    {
        GCHandle<GDExample> handle = GDMarshal.ToGCHandle<GDExample>(instance);
        GDExample self = handle.Target;
        handle.Dispose();
        self.Dispose();
    }

    private static double GetAmplitude(GDExtensionClassInstancePtr instance)
    {
        return GDMarshal.ToGCHandle<GDExample>(instance).Target.Amplitude;
    }

    private static void SetAmplitude(GDExtensionClassInstancePtr instance, double value)
    {
        GDMarshal.ToGCHandle<GDExample>(instance).Target.Amplitude = value;
    }

    private static double GetSpeed(GDExtensionClassInstancePtr instance)
    {
        return GDMarshal.ToGCHandle<GDExample>(instance).Target.Speed;
    }

    private static void SetSpeed(GDExtensionClassInstancePtr instance, double value)
    {
        GDMarshal.ToGCHandle<GDExample>(instance).Target.Speed = value;
    }
}
