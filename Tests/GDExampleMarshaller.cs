using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

using static GCHandle<GDExample>;

public static unsafe class GDExampleMarshaller
{
    public static void RegisterClass(void* userdata)
    {
        using GDExtensionStringName className = new GDExtensionStringName("GDExtension"u8);
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
    }

    public static void DeregisterClass(void* userdata)
    {
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

        using (GDExtensionStringName className = new GDExtensionStringName("GDExtension"u8))
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
}
