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
            GDExtensionInterface.StringNameNewWithLatin1Chars(classNamePtr, name, GDExtensionBool.False);
        }

        GDExtensionObjectPtr @object = GDExtensionInterface.ClassdbConstructObject(classNamePtr);
        destructor.Method(new GDExtensionTypePtr(classNamePtr.Pointer));
        GDExample self = new GDExample(@object);
        GCHandle<GDExample> handle = new GCHandle<GDExample>(self);
        GDExtensionClassInstancePtr pointer = new GDExtensionClassInstancePtr((void*)GCHandle<GDExample>.ToIntPtr(handle));

        fixed (byte* name = "GDExample"u8)
        {
            GDExtensionInterface.StringNameNewWithLatin1Chars(classNamePtr, name, GDExtensionBool.False);
        }

        GDExtensionInstanceBindingCallbacks callbacks = default;
        GDExtensionInterface.ObjectSetInstance(@object, classNamePtr, pointer);
        GDExtensionInterface.ObjectSetInstanceBinding(@object, GDExtension.Library.Pointer, pointer.Pointer, &callbacks);
        destructor.Method(new GDExtensionTypePtr(classNamePtr.Pointer));
        return @object;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void FreeInstance(void* classUserdata, GDExtensionClassInstancePtr instance)
    {
        if (instance.Pointer != null)
        {
            GCHandle<GDExample>.FromIntPtr((nint)instance.Pointer).Dispose();
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
            GDExtensionInterface.StringNameNewWithLatin1Chars(classNamePtr, name, GDExtensionBool.False);
        }

        fixed (byte* name = "Sprite2D"u8)
        {
            GDExtensionInterface.StringNameNewWithLatin1Chars(parentClassNamePtr, name, GDExtensionBool.False);
        }

        GDExtensionClassCreationInfo2 classInfo = new GDExtensionClassCreationInfo2
        {
            IsExposed = GDExtensionBool.True,
            CreateInstanceFunc = new GDExtensionClassCreateInstance(&CreateInstance),
            FreeInstanceFunc = new GDExtensionClassFreeInstance(&FreeInstance)
        };
        GDExtensionInterface.ClassdbRegisterExtensionClass2(GDExtension.Library, classNamePtr, parentClassNamePtr, &classInfo);
        GDExtensionPtrDestructor destructor = GDExtensionInterface.VariantGetPtrDestructor(GDExtensionVariantTypeStringName);
        destructor.Method(new GDExtensionTypePtr(classNamePtr.Pointer));
        destructor.Method(new GDExtensionTypePtr(parentClassNamePtr.Pointer));
    }
}
