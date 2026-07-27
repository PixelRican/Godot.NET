using System;
using System.Runtime.InteropServices;
using Godot.Interop;

namespace Godot.Tests;

#if BUILD_32
[StructLayout(LayoutKind.Explicit, Size = 4)]
#else
[StructLayout(LayoutKind.Explicit, Size = 8)]
#endif
public readonly unsafe struct String : IDisposable
{
    public String(ReadOnlySpan<byte> contents)
    {
        fixed (String* self = &this)
        fixed (byte* reference = contents)
        {
            GodotBridge.GDExtensionInterface.StringNewWithUtf8CharsAndLen.Invoke(
                new GDExtensionUninitializedStringPtr(self),
                reference,
                new GDExtensionInt(contents.Length));
        }
    }

    public void Dispose()
    {
        fixed (String* self = &this)
        {
            StringBridge.Destructor.Invoke(new GDExtensionTypePtr(self));
        }
    }
}
