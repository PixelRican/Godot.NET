using System;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct GDStringName : IDisposable
{
    private void* _pointer;

    public GDStringName(ReadOnlySpan<byte> value)
    {
        fixed (byte* reference = value)
        fixed (void** pointer = &_pointer)
        {
            GDExtensionUninitializedStringNamePtr argument = new GDExtensionUninitializedStringNamePtr(pointer);
            GDExtensionInterface.StringNameNewWithLatin1Chars(argument, reference, new GDExtensionBool(false));
        }
    }

    public void Dispose()
    {
        fixed (void** pointer = &_pointer)
        {
            GDExtensionTypePtr argument = new GDExtensionTypePtr(pointer);
            GDExtensionInterface.VariantGetPtrDestructor(GDExtensionVariantTypeStringName).Method(argument);
        }
    }
}
