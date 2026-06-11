using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

public static unsafe class GDExampleMarshaller
{
    public static void RegisterClass(GDExtensionClassLibraryPtr library)
    {
        GDClassData* data = (GDClassData*)GDExtensionInterface.MemAlloc2((nuint)sizeof(GDClassData), new GDExtensionBool(false));
        GDStringName className = new GDStringName("GDExample"u8);
        GDStringName parentClassName = new GDStringName("Sprite2D"u8);
        *data = new GDClassData(library, className, parentClassName);
        GDExtensionClassCreationInfo2 classInfo = new GDExtensionClassCreationInfo2
        {
            IsExposed = new GDExtensionBool(true),
            ClassUserdata = data,
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
        GDClassData* data = (GDClassData*)classUserdata;
        GDExtensionClassLibraryPtr library = data->Library;
        GDStringName className = data->ClassName;
        GDStringName parentClassName = data->ParentClassName;
        GDExtensionObjectPtr parent = GDExtensionInterface.ClassdbConstructObject(new GDExtensionConstStringNamePtr(&parentClassName));
        GDExample self = new GDExample
        {
            Parent = parent
        };
        GDExtensionClassInstancePtr instance = new GCHandle<GDExample>(self).ToPointer();
        GDExtensionInterface.ObjectSetInstance(parent,
                                               new GDExtensionConstStringNamePtr(&className),
                                               instance);
        GDExtensionInstanceBindingCallbacks callbacks = default;
        GDExtensionInterface.ObjectSetInstanceBinding(parent, library.Pointer, instance.Pointer, &callbacks);
        return parent;
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
