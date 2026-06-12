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
}
