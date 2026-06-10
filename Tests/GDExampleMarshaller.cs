using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

public static unsafe class GDExampleMarshaller
{
    public static void RegisterClass(GDExtensionClassLibraryPtr library)
    {
        using GDExtensionStringName className = new GDExtensionStringName("GDExample"u8);
        using GDExtensionStringName parentClassName = new GDExtensionStringName("Sprite2D"u8);
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
        GDExtensionMarshal.BindMethod(library,
                                      "GDExample"u8,
                                      "GetAmplitude"u8,
                                      (delegate*<GDExtensionClassInstancePtr, double>)&GetAmplitude,
                                      GDExtensionVariantTypeFloat);
        GDExtensionMarshal.BindMethod(library,
                                      "GDExample"u8,
                                      "SetAmplitude"u8,
                                      (delegate*<GDExtensionClassInstancePtr, double, void>)&SetAmplitude,
                                      "value"u8,
                                      GDExtensionVariantTypeFloat);
        GDExtensionMarshal.BindProperty(library,
                                        "GDExample"u8,
                                        "Amplitude"u8,
                                        GDExtensionVariantTypeFloat,
                                        "GetAmplitude"u8,
                                        "SetAmplitude"u8);
        GDExtensionMarshal.BindMethod(library,
                                      "GDExample"u8,
                                      "GetSpeed"u8,
                                      (delegate*<GDExtensionClassInstancePtr, double>)&GetSpeed,
                                      GDExtensionVariantTypeFloat);
        GDExtensionMarshal.BindMethod(library,
                                      "GDExample"u8,
                                      "SetSpeed"u8,
                                      (delegate*<GDExtensionClassInstancePtr, double, void>)&SetSpeed,
                                      "value"u8,
                                      GDExtensionVariantTypeFloat);
        GDExtensionMarshal.BindProperty(library,
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

        using (GDExtensionStringName className = new GDExtensionStringName("Sprite2D"u8))
        {
            self = new GDExample
            {
                Parent = GDExtensionInterface.ClassdbConstructObject(new GDExtensionConstStringNamePtr(&className))
            };
        }

        GDExtensionClassInstancePtr instance = new GCHandle<GDExample>(self).ToPointer();

        using (GDExtensionStringName className = new GDExtensionStringName("GDExample"u8))
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
        if (instance.Pointer == null)
        {
            return;
        }

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
