using Godot.Interop;

namespace Godot.Tests;

public static class StringBridge
{
    private static GDExtensionPtrDestructor s_destructor;

    public static GDExtensionPtrDestructor Destructor
    {
        get => s_destructor;
    }

    public static void Initialize()
    {
        s_destructor = GodotBridge.GDExtensionInterface.VariantGetPtrDestructor.Invoke(GDEXTENSION_VARIANT_TYPE_STRING);
    }
}
