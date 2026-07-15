using Godot.GDExtension;

namespace Godot.Tests;

public static class StringNameBridge
{
    private static GDExtensionPtrDestructor s_destructor;
    private static GDExtensionPtrOperatorEvaluator s_operatorEqual;
    private static GDExtensionPtrOperatorEvaluator s_operatorNotEqual;

    public static GDExtensionPtrDestructor Destructor
    {
        get => s_destructor;
    }

    public static GDExtensionPtrOperatorEvaluator OperatorEqual
    {
        get => s_operatorEqual;
    }

    public static GDExtensionPtrOperatorEvaluator OperatorNotEqual
    {
        get => s_operatorNotEqual;
    }

    public static void Initialize()
    {
        s_destructor = GDExtensionInterface.VariantGetPtrDestructor.Invoke(GDEXTENSION_VARIANT_TYPE_STRING_NAME);
        s_operatorEqual = GDExtensionInterface.VariantGetPtrOperatorEvaluator.Invoke(
            GDEXTENSION_VARIANT_OP_EQUAL,
            GDEXTENSION_VARIANT_TYPE_STRING_NAME,
            GDEXTENSION_VARIANT_TYPE_STRING_NAME);
        s_operatorNotEqual = GDExtensionInterface.VariantGetPtrOperatorEvaluator.Invoke(
            GDEXTENSION_VARIANT_OP_NOT_EQUAL,
            GDEXTENSION_VARIANT_TYPE_STRING_NAME,
            GDEXTENSION_VARIANT_TYPE_STRING_NAME);
    }
}
