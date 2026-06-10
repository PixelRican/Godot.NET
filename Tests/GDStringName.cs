using System;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct GDStringName : IDisposable
{
    private nint _handle;

    public GDStringName(ReadOnlySpan<byte> value)
    {
        nint handle;

        fixed (byte* reference = value)
        {
            GDExtensionUninitializedStringNamePtr self = new GDExtensionUninitializedStringNamePtr(&handle);
            GDExtensionInt length = new GDExtensionInt(value.Length);
            GDExtensionInterface.StringNameNewWithUtf8CharsAndLen(self, reference, length);
        }

        _handle = handle;
    }

    public void Dispose()
    {
        nint handle = _handle;
        GDExtensionTypePtr self = new GDExtensionTypePtr(&handle);
        GDExtensionInterface.VariantGetPtrDestructor(GDExtensionVariantTypeStringName).Method(self);
        _handle = 0;
    }
}
