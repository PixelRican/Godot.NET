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
        s_destructor = GDExtensionInterface.VariantGetPtrDestructor.Invoke(GDExtensionVariantTypeStringName);
        s_operatorEqual = GDExtensionInterface.VariantGetPtrOperatorEvaluator.Invoke(
            GDExtensionVariantOpEqual,
            GDExtensionVariantTypeStringName,
            GDExtensionVariantTypeStringName);
        s_operatorNotEqual = GDExtensionInterface.VariantGetPtrOperatorEvaluator.Invoke(
            GDExtensionVariantOpNotEqual,
            GDExtensionVariantTypeStringName,
            GDExtensionVariantTypeStringName);
    }
}
