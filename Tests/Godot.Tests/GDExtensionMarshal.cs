using System;
using System.Runtime.InteropServices;
using Godot.GDExtension;

namespace Godot.Tests;

public static unsafe class GDExtensionMarshal
{
    public static GDExtensionObjectPtr CreateInstance(void* token,
                                                      ExtensionObject target,
                                                      ReadOnlySpan<byte> className,
                                                      GDExtensionInstanceBindingCallbacks callbacks = default)
    {
        ArgumentNullException.ThrowIfNull(target);
        GDExtensionObjectPtr parent = target.Base;
        GCHandle<ExtensionObject> handle = new GCHandle<ExtensionObject>(target);
        GDExtensionClassInstancePtr instance = new GDExtensionClassInstancePtr((void*)GCHandle<ExtensionObject>.ToIntPtr(handle));
        nint classStringName = GDExtensionClassDB.ConstructStringName(className);
        GDExtensionInterface.ObjectSetInstance.Invoke(parent, new GDExtensionConstStringNamePtr(&classStringName), instance);
        GDExtensionClassDB.DestructStringName(classStringName);
        GDExtensionInterface.ObjectSetInstanceBinding.Invoke(parent, token, instance.Pointer, &callbacks);
        return parent;
    }

    public static void FreeInstance(GDExtensionClassInstancePtr instance)
    {
        GCHandle<ExtensionObject> handle = GCHandle<ExtensionObject>.FromIntPtr((nint)instance.Pointer);
        ExtensionObject target = handle.Target;
        handle.Dispose();
        target.Dispose();
    }

    public static T GetTarget<T>(GDExtensionClassInstancePtr instance) where T : ExtensionObject
    {
        GCHandle<T> handle = GCHandle<T>.FromIntPtr((nint)instance.Pointer);
        return handle.Target;
    }

    public static double ReadFloat(GDExtensionConstTypePtr pointer)
    {
        return *(double*)pointer.Pointer;
    }

    public static double ReadFloat(GDExtensionConstVariantPtr pointer)
    {
        return ((Variant*)pointer.Pointer)->ToFloat();
    }

    public static void WriteFloat(GDExtensionTypePtr destination, double value)
    {
        *(double*)destination.Pointer = value;
    }

    public static void WriteFloat(GDExtensionVariantPtr destination, double value)
    {
        *(Variant*)destination.Pointer = new Variant(value);
    }

    public static bool ValidateArguments(GDExtensionConstVariantPtr* arguments,
                                         GDExtensionInt argumentCount,
                                         GDExtensionCallError* error,
                                         ReadOnlySpan<GDExtensionVariantType> expectedTypes)
    {
        if (argumentCount.Value != expectedTypes.Length)
        {
            error->Error = argumentCount.Value < expectedTypes.Length
                ? GDExtensionCallErrorTooFewArguments
                : GDExtensionCallErrorTooManyArguments;
            error->Expected = expectedTypes.Length;
            return false;
        }

        for (int i = 0; i < expectedTypes.Length; i++)
        {
            GDExtensionConstVariantPtr argument = arguments[i];
            GDExtensionVariantType expectedType = expectedTypes[i];

            if (GDExtensionInterface.VariantGetType.Invoke(argument) != expectedType)
            {
                error->Error = GDExtensionCallErrorInvalidArgument;
                error->Expected = (int)expectedType;
                error->Argument = i;
                return false;
            }
        }

        return true;
    }
}
