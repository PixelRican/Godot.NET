using System;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct GDString : IDisposable
{
    private void* _pointer;

    public GDString(ReadOnlySpan<byte> value)
    {
        fixed (byte* reference = value)
        fixed (void** pointer = &_pointer)
        {
            GDExtensionUninitializedStringPtr argument = new GDExtensionUninitializedStringPtr(pointer);
            GDExtensionInterface.StringNewWithUtf8Chars(argument, reference);
        }
    }

    public void Dispose()
    {
        fixed (void** pointer = &_pointer)
        {
            GDExtensionTypePtr argument = new GDExtensionTypePtr(pointer);
            GDExtensionInterface.VariantGetPtrDestructor(GDExtensionVariantTypeString).Method(argument);
        }
    }
}
