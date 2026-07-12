using Godot.GDExtension;

namespace Godot.Tests;

public static unsafe class ObjectBridge
{
    private static GDExtensionMethodBindPtr s_emitSignal;

    public static GDExtensionMethodBindPtr EmitSignal
    {
        get => s_emitSignal;
    }

    public static void Initialize()
    {
        using StringName nameOfObject = new StringName("Object"u8);
        using StringName nameOfEmitSignal = new StringName("emit_signal"u8);
        s_emitSignal = GDExtensionInterface.ClassdbGetMethodBind.Invoke(
            new GDExtensionConstStringNamePtr(&nameOfObject),
            new GDExtensionConstStringNamePtr(&nameOfEmitSignal),
            new GDExtensionInt(4047867050));
    }
}
