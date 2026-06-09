using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

using static GCHandle<GDExample>;

public static unsafe class GDExampleMarshaller
{
    public static void RegisterClass(void* userdata)
    {
        using GDExtensionStringName className = new GDExtensionStringName("GDExample"u8);
        using GDExtensionStringName parentClassName = new GDExtensionStringName("Sprite2D"u8);
        GDExtensionClassCreationInfo2 classInfo = new GDExtensionClassCreationInfo2
        {
            IsExposed = GDExtensionBool.True,
            ClassUserdata = userdata,
            CreateInstanceFunc = new GDExtensionClassCreateInstance(&CreateInstance),
            FreeInstanceFunc = new GDExtensionClassFreeInstance(&FreeInstance),
        };
        GDExtensionInterface.ClassdbRegisterExtensionClass2(new GDExtensionClassLibraryPtr(userdata),
                                                            new GDExtensionConstStringNamePtr(&className),
                                                            new GDExtensionConstStringNamePtr(&parentClassName),
                                                            &classInfo);
        GDExtensionMarshal.BindMethod(new GDExtensionClassLibraryPtr(userdata),
                                      "GDExample"u8,
                                      "GetAmplitude"u8,
                                      (delegate* unmanaged[Cdecl]<GCHandle<GDExample>, double>)&GetAmplitude,
                                      GDExtensionVariantTypeFloat);
        GDExtensionMarshal.BindMethod(new GDExtensionClassLibraryPtr(userdata),
                                      "GDExample"u8,
                                      "SetAmplitude"u8,
                                      (delegate* unmanaged[Cdecl]<GCHandle<GDExample>, double, void>)&SetAmplitude,
                                      "value"u8,
                                      GDExtensionVariantTypeFloat);
        GDExtensionMarshal.BindMethod(new GDExtensionClassLibraryPtr(userdata),
                                      "GDExample"u8,
                                      "GetSpeed"u8,
                                      (delegate* unmanaged[Cdecl]<GCHandle<GDExample>, double>)&GetAmplitude,
                                      GDExtensionVariantTypeFloat);
        GDExtensionMarshal.BindMethod(new GDExtensionClassLibraryPtr(userdata),
                                      "GDExample"u8,
                                      "SetSpeed"u8,
                                      (delegate* unmanaged[Cdecl]<GCHandle<GDExample>, double, void>)&SetAmplitude,
                                      "value"u8,
                                      GDExtensionVariantTypeFloat);
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

        void* handle = ToIntPtr(new GCHandle<GDExample>(self)).ToPointer();

        using (GDExtensionStringName className = new GDExtensionStringName("GDExample"u8))
        {
            GDExtensionInterface.ObjectSetInstance(self.Parent,
                                                   new GDExtensionConstStringNamePtr(&className),
                                                   new GDExtensionClassInstancePtr(handle));
        }

        GDExtensionInstanceBindingCallbacks callbacks = default;
        GDExtensionInterface.ObjectSetInstanceBinding(self.Parent, classUserdata, handle, &callbacks);
        return self.Parent;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void FreeInstance(void* classUserdata, GDExtensionClassInstancePtr instance)
    {
        if (instance.Pointer == null)
        {
            return;
        }

        using GCHandle<GDExample> handle = FromIntPtr((nint)instance.Pointer);
        handle.Target.Dispose();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static double GetAmplitude(GCHandle<GDExample> handle)
    {
        return handle.Target.Amplitude;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void SetAmplitude(GCHandle<GDExample> handle, double value)
    {
        handle.Target.Amplitude = value;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static double GetSpeed(GCHandle<GDExample> handle)
    {
        return handle.Target.Speed;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void SetSpeed(GCHandle<GDExample> handle, double value)
    {
        handle.Target.Speed = value;
    }
}
