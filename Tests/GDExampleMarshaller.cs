using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

public static unsafe class GDExampleMarshaller
{
    public static void RegisterClass(GDExtensionClassLibraryPtr library)
    {
        using GDStringName className = new GDStringName("GDExample"u8);
        using GDStringName parentClassName = new GDStringName("Sprite2D"u8);
        GDExtensionClassCreationInfo2 classInfo = new GDExtensionClassCreationInfo2
        {
            IsExposed = new GDExtensionBool(true),
            ClassUserdata = library.Pointer,
            CreateInstanceFunc = new GDExtensionClassCreateInstance(&CreateInstance),
            FreeInstanceFunc = new GDExtensionClassFreeInstance(&FreeInstance),
        };
        GDExtensionInterface.ClassdbRegisterExtensionClass2(library,
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
        GDExample self;

        using (GDStringName className = new GDStringName("Sprite2D"u8))
        {
            self = new GDExample
            {
                Parent = GDExtensionInterface.ClassdbConstructObject(new GDExtensionConstStringNamePtr(&className))
            };
        }

        GDExtensionClassInstancePtr instance = new GCHandle<GDExample>(self).ToPointer();

        using (GDStringName className = new GDStringName("GDExample"u8))
        {
            GDExtensionInterface.ObjectSetInstance(self.Parent,
                                                   new GDExtensionConstStringNamePtr(&className),
                                                   instance);
        }

        GDExtensionInstanceBindingCallbacks callbacks = default;
        GDExtensionInterface.ObjectSetInstanceBinding(self.Parent, classUserdata, instance.Pointer, &callbacks);
        return self.Parent;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void FreeInstance(void* classUserdata, GDExtensionClassInstancePtr instance)
    {
        GCHandle<GDExample> handle = instance.ToHandle<GDExample>();
        GDExample self = handle.Target;
        handle.Dispose();
        self.Dispose();
    }

    private static double GetAmplitude(GDExtensionClassInstancePtr instance)
    {
        return instance.ToHandle<GDExample>().Target.Amplitude;
    }

    private static void SetAmplitude(GDExtensionClassInstancePtr instance, double value)
    {
        instance.ToHandle<GDExample>().Target.Amplitude = value;
    }

    private static double GetSpeed(GDExtensionClassInstancePtr instance)
    {
        return instance.ToHandle<GDExample>().Target.Speed;
    }

    private static void SetSpeed(GDExtensionClassInstancePtr instance, double value)
    {
        instance.ToHandle<GDExample>().Target.Speed = value;
    }
}
