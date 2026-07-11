using System;
using Godot.GDExtension;

namespace Godot.Tests;

public readonly unsafe struct String : IDisposable
{
    private readonly nint _data;

    public String(ReadOnlySpan<byte> contents)
    {
        fixed (String* self = &this)
        fixed (byte* reference = contents)
        {
            GDExtensionInterface.StringNewWithUtf8CharsAndLen.Invoke(
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
