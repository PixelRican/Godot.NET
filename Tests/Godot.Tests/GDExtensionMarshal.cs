using System;
using System.Runtime.InteropServices;
using Godot.Interop;

namespace Godot.Tests;

public static unsafe class GDExtensionMarshal
{
    public static void* CreateInstance(
        void* token,
        ExtensionObject target,
        ReadOnlySpan<byte> className,
        GDExtensionInstanceBindingCallbacks callbacks = default)
    {
        ArgumentNullException.ThrowIfNull(target);
        GCHandle<ExtensionObject> handle = new GCHandle<ExtensionObject>(target);
        void* instance = (void*)GCHandle<ExtensionObject>.ToIntPtr(handle);
        void* parent = (void*)target.Base;

        using (StringName classStringName = new StringName(className))
        {
            GDExtensionInterface.ObjectSetInstance(parent, (GDExtensionStringName*)&classStringName, instance);
        }

        GDExtensionInterface.ObjectSetInstanceBinding(parent, token, instance, &callbacks);
        return parent;
    }

    public static void FreeInstance(void* instance)
    {
        GCHandle<ExtensionObject> handle = GCHandle<ExtensionObject>.FromIntPtr((nint)instance);
        ExtensionObject target = handle.Target;
        handle.Dispose();
        target.Dispose();
    }

    public static T GetTarget<T>(void* instance) where T : ExtensionObject
    {
        GCHandle<T> handle = GCHandle<T>.FromIntPtr((nint)instance);
        return handle.Target;
    }

    public static double ReadFloat(void* pointer)
    {
        return *(double*)pointer;
    }

    public static double ReadFloat(GDExtensionVariant* pointer)
    {
        return ((Variant*)pointer)->ToFloat();
    }

    public static void WriteFloat(void* destination, double value)
    {
        *(double*)destination = value;
    }

    public static void WriteFloat(GDExtensionVariant* destination, double value)
    {
        *(Variant*)destination = new Variant(value);
    }

    public static bool ValidateArguments(
        GDExtensionVariant** pArguments,
        long pArgumentCount,
        GDExtensionCallError* rError,
        ReadOnlySpan<GDExtensionVariantType> pExpectedTypes)
    {
        if (pArgumentCount != pExpectedTypes.Length)
        {
            *rError = new GDExtensionCallError
            {
                Error = pArgumentCount < pExpectedTypes.Length
                    ? GDExtensionCallErrorType.TooFewArguments
                    : GDExtensionCallErrorType.TooManyArguments,
                Expected = pExpectedTypes.Length
            };
            return false;
        }

        for (int i = 0; i < pExpectedTypes.Length; i++)
        {
            GDExtensionVariant* argument = pArguments[i];
            GDExtensionVariantType expectedType = pExpectedTypes[i];

            if (GDExtensionInterface.VariantGetType(argument) != expectedType)
            {
                *rError = new GDExtensionCallError
                {
                    Error = GDExtensionCallErrorType.InvalidArgument,
                    Expected = (int)expectedType,
                    Argument = i
                };
                return false;
            }
        }

        return true;
    }
}
