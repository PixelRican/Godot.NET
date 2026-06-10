using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

public static unsafe class GCHandleExtensions
{
    public static GDExtensionClassInstancePtr ToPointer<T>(this GCHandle<T> handle) where T : class
    {
        return new GDExtensionClassInstancePtr(GCHandle<T>.ToIntPtr(handle).ToPointer());
    }

    public static GCHandle<T> ToHandle<T>(this GDExtensionClassInstancePtr instance) where T : class
    {
        return GCHandle<T>.FromIntPtr((nint)instance.Pointer);
    }
}
