using System;
using Godot.GDExtension;

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
        GDExtensionConstTypePtr argument = new GDExtensionConstTypePtr(&value);
        GodotBridge.GDExtensionInterface.ObjectMethodBindPtrcall.Invoke(
            Sprite2DBridge.SetPosition,
            Base,
            &argument,
            default);
    }
}
