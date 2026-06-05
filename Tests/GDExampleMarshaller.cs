using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

using static GDExtensionVariantType;

internal static unsafe class GDExampleMarshaller
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static GDExtensionObjectPtr CreateInstance(void* classUserdata)
    {
        GDExtensionPtrDestructor destructor = GDExtensionInterface.VariantGetPtrDestructor(GDExtensionVariantTypeStringName);
        nint className;
        GDExtensionStringNamePtr classNamePtr = new GDExtensionStringNamePtr(&className);

        fixed (byte* name = "Sprite2D"u8)
        {
            GDExtensionInterface.StringNameNewWithLatin1Chars(classNamePtr, name, new GDExtensionBool(0));
        }

        GDExtensionObjectPtr @object = GDExtensionInterface.ClassdbConstructObject(classNamePtr);
        destructor.Method(new GDExtensionTypePtr(classNamePtr.Value));
        GDExample self = new GDExample(@object);
        GCHandle<GDExample> handle = new GCHandle<GDExample>(self);
        GDExtensionClassInstancePtr pointer = new GDExtensionClassInstancePtr(GCHandle<GDExample>.ToIntPtr(handle).ToPointer());

        fixed (byte* name = "GDExample"u8)
        {
            GDExtensionInterface.StringNameNewWithLatin1Chars(classNamePtr, name, new GDExtensionBool(0));
        }

        GDExtensionInstanceBindingCallbacks callbacks = default;
        GDExtensionInterface.ObjectSetInstance(@object, classNamePtr, pointer);
        GDExtensionInterface.ObjectSetInstanceBinding(@object, GDExtension.Library.Value, pointer.Value, &callbacks);
        destructor.Method(new GDExtensionTypePtr(classNamePtr.Value));
        return @object;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void FreeInstance(void* classUserdata, GDExtensionClassInstancePtr instance)
    {
        if (instance.Value != null)
        {
            GCHandle<GDExample>.FromIntPtr((nint)instance.Value).Dispose();
        }
    }

    public static void RegisterClass()
    {
        nint className;
        nint parentClassName;
        GDExtensionStringNamePtr classNamePtr = new GDExtensionStringNamePtr(&className);
        GDExtensionStringNamePtr parentClassNamePtr = new GDExtensionStringNamePtr(&parentClassName);

        fixed (byte* name = "GDExample"u8)
        {
            GDExtensionInterface.StringNameNewWithLatin1Chars(classNamePtr, name, new GDExtensionBool(0));
        }

        fixed (byte* name = "Sprite2D"u8)
        {
            GDExtensionInterface.StringNameNewWithLatin1Chars(parentClassNamePtr, name, new GDExtensionBool(0));
        }

        GDExtensionClassCreationInfo2 classInfo = new GDExtensionClassCreationInfo2
        {
            IsExposed = new GDExtensionBool(1),
            CreateInstanceFunc = new GDExtensionClassCreateInstance(&CreateInstance),
            FreeInstanceFunc = new GDExtensionClassFreeInstance(&FreeInstance)
        };
        GDExtensionInterface.ClassdbRegisterExtensionClass2(GDExtension.Library, classNamePtr, parentClassNamePtr, &classInfo);
        GDExtensionPtrDestructor destructor = GDExtensionInterface.VariantGetPtrDestructor(GDExtensionVariantTypeStringName);
        destructor.Method(new GDExtensionTypePtr(classNamePtr.Value));
        destructor.Method(new GDExtensionTypePtr(parentClassNamePtr.Value));
    }
}
