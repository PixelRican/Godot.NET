using Godot.Interop;

namespace Godot.Tests;

public static unsafe class Sprite2DBridge
{
    private static GDExtensionMethodBindPtr s_setPosition;

    public static GDExtensionMethodBindPtr SetPosition
    {
        get => s_setPosition;
    }

    public static void Initialize()
    {
        using StringName nameOfNode2D = new StringName("Node2D"u8);
        using StringName nameOfSetPosition = new StringName("set_position"u8);
        s_setPosition = GodotBridge.GDExtensionInterface.ClassdbGetMethodBind.Invoke(
            new GDExtensionConstStringNamePtr(&nameOfNode2D),
            new GDExtensionConstStringNamePtr(&nameOfSetPosition),
            new GDExtensionInt(743155724));
    }
}
