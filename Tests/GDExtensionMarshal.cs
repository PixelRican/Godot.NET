using System;
using System.Runtime.InteropServices;
using Godot.Interop;

namespace Godot.Tests;

public static unsafe class GDExtensionMarshal
{
    public static void* CreateInstance(
        void* pToken,
        ExtensionObject pTarget,
        ReadOnlySpan<byte> pClassName,
        GDExtensionInstanceBindingCallbacks pCallbacks = default)
    {
        ArgumentNullException.ThrowIfNull(pTarget);
        GCHandle<ExtensionObject> handle = new GCHandle<ExtensionObject>(pTarget);
        void* instance = (void*)GCHandle<ExtensionObject>.ToIntPtr(handle);
        void* parent = (void*)pTarget.Base;

        using (StringName classStringName = new StringName(pClassName))
        {
            GDExtensionInterface.ObjectSetInstance(parent, (GDExtensionStringName*)&classStringName, instance);
        }

        GDExtensionInterface.ObjectSetInstanceBinding(parent, pToken, instance, &pCallbacks);
        return parent;
    }

    public static void FreeInstance(void* pInstance)
    {
        GCHandle<ExtensionObject> handle = GCHandle<ExtensionObject>.FromIntPtr((nint)pInstance);
        ExtensionObject target = handle.Target;
        handle.Dispose();
        target.Dispose();
    }

    public static T GetTarget<T>(void* pInstance) where T : ExtensionObject
    {
        GCHandle<T> handle = GCHandle<T>.FromIntPtr((nint)pInstance);
        return handle.Target;
    }

    public static double ReadFloat(void* pSource)
    {
        return *(double*)pSource;
    }

    public static double ReadFloat(GDExtensionVariant* pSource)
    {
        return ((Variant*)pSource)->ToFloat();
    }

    public static void WriteFloat(void* rDestination, double pValue)
    {
        *(double*)rDestination = pValue;
    }

    public static void WriteFloat(GDExtensionVariant* rDestination, double pValue)
    {
        *(Variant*)rDestination = new Variant(pValue);
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
