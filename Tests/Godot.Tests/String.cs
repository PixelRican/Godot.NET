using System;
using System.Runtime.InteropServices;
using Godot.Interop;

namespace Godot.Tests;

[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct String : IDisposable
{
    private readonly GDExtensionString _value;

    public String(ReadOnlySpan<byte> contents)
    {
        fixed (byte* reference = contents)
        fixed (GDExtensionString* self = &_value)
        {
            GDExtensionInterface.StringNewWithUtf8CharsAndLen(self, reference, contents.Length);
        }
    }

    public void Dispose()
    {
        fixed (GDExtensionString* self = &_value)
        {
            NativeMethods.StringDestructor(self);
        }
    }
}
