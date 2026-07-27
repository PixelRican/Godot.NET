using Godot.Interop;

namespace Godot.Tests;

public static class VariantBridge
{
    private static GDExtensionVariantFromTypeConstructorFunc s_fromFloatConstructor;
    private static GDExtensionVariantFromTypeConstructorFunc s_fromStringNameConstructor;
    private static GDExtensionVariantFromTypeConstructorFunc s_fromVector2Constructor;
    private static GDExtensionTypeFromVariantConstructorFunc s_toFloatConstructor;

    public static GDExtensionVariantFromTypeConstructorFunc FromFloatConstructor
    {
        get => s_fromFloatConstructor;
    }

    public static GDExtensionVariantFromTypeConstructorFunc FromStringNameConstructor
    {
        get => s_fromStringNameConstructor;
    }

    public static GDExtensionVariantFromTypeConstructorFunc FromVector2Constructor
    {
        get => s_fromVector2Constructor;
    }

    public static GDExtensionTypeFromVariantConstructorFunc ToFloatConstructor
    {
        get => s_toFloatConstructor;
    }

    public static void Initialize()
    {
        s_fromFloatConstructor = GodotBridge.GDExtensionInterface.GetVariantFromTypeConstructor.Invoke(GDEXTENSION_VARIANT_TYPE_FLOAT);
        s_fromStringNameConstructor = GodotBridge.GDExtensionInterface.GetVariantFromTypeConstructor.Invoke(GDEXTENSION_VARIANT_TYPE_STRING_NAME);
        s_fromVector2Constructor = GodotBridge.GDExtensionInterface.GetVariantFromTypeConstructor.Invoke(GDEXTENSION_VARIANT_TYPE_VECTOR2);
        s_toFloatConstructor = GodotBridge.GDExtensionInterface.GetVariantToTypeConstructor.Invoke(GDEXTENSION_VARIANT_TYPE_FLOAT);
    }
}
