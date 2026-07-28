using System;
using Godot.Interop;

namespace Godot.Tests;

public abstract unsafe class ExtensionSprite2D : ExtensionObject
{
    protected ExtensionSprite2D() : base("Sprite2D"u8)
    {
    }

    protected ExtensionSprite2D(ReadOnlySpan<byte> baseClassName) : base(baseClassName)
    {
    }

    public void SetPosition(Vector2 value)
    {
        void* argument = &value;
        GDExtensionInterface.ObjectMethodBindPtrCall(
            NativeMethods.Node2DSetPositionMethodBind,
            (void*)Base,
            &argument,
            null);
    }
}
