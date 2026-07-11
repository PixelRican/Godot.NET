using Godot.GDExtension;

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
        s_destructor = GDExtensionInterface.VariantGetPtrDestructor.Invoke(GDExtensionVariantTypeString);
    }
}
