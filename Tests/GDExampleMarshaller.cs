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
        destructor.Method((GDExtensionTypePtr)(nint)classNamePtr);
        GDExample self = new GDExample(@object);
        GCHandle<GDExample> handle = new GCHandle<GDExample>(self);
        GDExtensionClassInstancePtr pointer = (GDExtensionClassInstancePtr)GCHandle<GDExample>.ToIntPtr(handle);

        fixed (byte* name = "GDExample"u8)
        {
            GDExtensionInterface.StringNameNewWithLatin1Chars(classNamePtr, name, GDExtensionBool.False);
        }

        GDExtensionInstanceBindingCallbacks callbacks = default;
        GDExtensionInterface.ObjectSetInstance(@object, classNamePtr, pointer);
        GDExtensionInterface.ObjectSetInstanceBinding(@object, (void*)GDExtension.Library, (void*)pointer, &callbacks);
        destructor.Method((GDExtensionTypePtr)(nint)classNamePtr);
        return @object;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void FreeInstance(void* classUserdata, GDExtensionClassInstancePtr instance)
    {
        if (instance.IsAllocated)
        {
            GCHandle<GDExample>.FromIntPtr((nint)instance).Dispose();
        }
    }

    public static void RegisterClass()
    {
        nint className;
        nint parentClassName;
        GDExtensionStringNamePtr classNamePtr = (GDExtensionStringNamePtr)(&className);
        GDExtensionStringNamePtr parentClassNamePtr = (GDExtensionStringNamePtr)(&parentClassName);

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
        destructor.Method((GDExtensionTypePtr)(nint)classNamePtr);
        destructor.Method((GDExtensionTypePtr)(nint)parentClassNamePtr);
    }
}
