using System;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct GDString : IDisposable
{
    private nint _handle;

    public GDString(ReadOnlySpan<byte> value)
    {
        nint handle;
        GDExtensionUninitializedStringPtr self = new GDExtensionUninitializedStringPtr(&handle);
        GDExtensionInt length = new GDExtensionInt(value.Length);

        fixed (byte* reference = value)
        {
            GDExtensionInterface.StringNewWithUtf8CharsAndLen2(self, reference, length);
        }

        _handle = handle;
    }

    public void Dispose()
    {
        nint handle = _handle;
        GDExtensionTypePtr self = new GDExtensionTypePtr(&handle);
        GDExtensionInterface.VariantGetPtrDestructor(GDExtensionVariantTypeString).Method(self);
        _handle = 0;
    }
}
