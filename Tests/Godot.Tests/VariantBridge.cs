using Godot.GDExtension;

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
        s_fromFloatConstructor = GDExtensionInterface.GetVariantFromTypeConstructor.Invoke(GDExtensionVariantTypeFloat);
        s_fromStringNameConstructor = GDExtensionInterface.GetVariantFromTypeConstructor.Invoke(GDExtensionVariantTypeStringName);
        s_fromVector2Constructor = GDExtensionInterface.GetVariantFromTypeConstructor.Invoke(GDExtensionVariantTypeVector2);
        s_toFloatConstructor = GDExtensionInterface.GetVariantToTypeConstructor.Invoke(GDExtensionVariantTypeFloat);
    }
}
