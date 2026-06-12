using System;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

public static unsafe class GDExtensionMarshal
{
    public static GDExtensionObjectPtr CreateInstance(void* token, GDExtensionObject target, ReadOnlySpan<byte> className)
    {
        ArgumentNullException.ThrowIfNull(target);
        GDExtensionObjectPtr parent = target.Base;
        GCHandle<GDExtensionObject> handle = new GCHandle<GDExtensionObject>(target);
        GDExtensionClassInstancePtr instance = new GDExtensionClassInstancePtr((void*)GCHandle<GDExtensionObject>.ToIntPtr(handle));

        using (GDStringName classStringName = new GDStringName(className))
        {
            GDExtensionInterface.ObjectSetInstance(parent, new GDExtensionConstStringNamePtr(&classStringName), instance);
        }

        GDExtensionInstanceBindingCallbacks callbacks = default;
        GDExtensionInterface.ObjectSetInstanceBinding(parent, token, instance.Pointer, &callbacks);
        return parent;
    }

    public static void FreeInstance(GDExtensionClassInstancePtr instance)
    {
        GCHandle<GDExtensionObject> handle = GCHandle<GDExtensionObject>.FromIntPtr((nint)instance.Pointer);
        GDExtensionObject target = handle.Target;
        handle.Dispose();
        target.Dispose();
    }

    public static T GetTarget<T>(GDExtensionClassInstancePtr instance) where T : GDExtensionObject
    {
        GCHandle<T> handle = GCHandle<T>.FromIntPtr((nint)instance.Pointer);
        return handle.Target;
    }

    public static double ReadFloat(GDExtensionConstVariantPtr variant)
    {
        double result;
        GDExtensionTypeFromVariantConstructorFunc constructor = GDExtensionInterface.GetVariantToTypeConstructor(GDExtensionVariantTypeFloat);
        constructor.Method(new GDExtensionUninitializedTypePtr(&result), new GDExtensionVariantPtr(variant.Pointer));
        return result;
    }

    public static void WriteFloat(GDExtensionVariantPtr variant, double value)
    {
        GDExtensionVariantFromTypeConstructorFunc constructor = GDExtensionInterface.GetVariantFromTypeConstructor(GDExtensionVariantTypeFloat);
        constructor.Method(variant, new GDExtensionTypePtr(&value));
    }

    public static bool ValidateArguments(GDExtensionConstVariantPtr* arguments, GDExtensionInt argumentCount, GDExtensionCallError* error, ReadOnlySpan<GDExtensionVariantType> expectedTypes)
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

            if (GDExtensionInterface.VariantGetType(argument) != expectedType)
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
