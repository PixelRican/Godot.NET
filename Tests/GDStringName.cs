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
        GDExtensionUninitializedStringNamePtr self = new GDExtensionUninitializedStringNamePtr(&handle);
        GDExtensionInt length = new GDExtensionInt(value.Length);

        fixed (byte* reference = value)
        {
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
