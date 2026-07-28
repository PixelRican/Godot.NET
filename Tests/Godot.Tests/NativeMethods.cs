using Godot.Interop;

namespace Godot.Tests;

public static unsafe class NativeMethods
{
    static NativeMethods()
    {
        StringDestructor = GDExtensionInterface.VariantGetPtrDestructor(GDExtensionVariantType.String);
        StringNameDestructor = GDExtensionInterface.VariantGetPtrDestructor(GDExtensionVariantType.StringName);
        StringNameEqualOperatorEvaluator = GDExtensionInterface.VariantGetPtrOperatorEvaluator(
            GDExtensionVariantOperator.Equal,
            GDExtensionVariantType.StringName,
            GDExtensionVariantType.StringName);
        StringNameNotEqualOperatorEvaluator = GDExtensionInterface.VariantGetPtrOperatorEvaluator(
            GDExtensionVariantOperator.NotEqual,
            GDExtensionVariantType.StringName,
            GDExtensionVariantType.StringName);
        VariantFromFloatConstructor = GDExtensionInterface.GetVariantFromTypeConstructor(GDExtensionVariantType.Float);
        VariantFromStringNameConstructor = GDExtensionInterface.GetVariantFromTypeConstructor(GDExtensionVariantType.StringName);
        VariantFromVector2Constructor = GDExtensionInterface.GetVariantFromTypeConstructor(GDExtensionVariantType.Vector2);
        VariantToFloatConstructor = GDExtensionInterface.GetVariantToTypeConstructor(GDExtensionVariantType.Float);
        using StringName nameOfObject = new StringName("Object"u8);
        using StringName nameOfEmitSignal = new StringName("emit_signal"u8);
        using StringName nameOfNode2D = new StringName("Node2D"u8);
        using StringName nameOfSetPosition = new StringName("set_position"u8);
        Node2DSetPositionMethodBind = GDExtensionInterface.ClassDBGetMethodBind(
            (GDExtensionStringName*)&nameOfNode2D,
            (GDExtensionStringName*)&nameOfSetPosition,
            743155724);
        ObjectEmitSignalMethodBind = GDExtensionInterface.ClassDBGetMethodBind(
            (GDExtensionStringName*)&nameOfObject,
            (GDExtensionStringName*)&nameOfEmitSignal,
            4047867050);
    }

    public static void* Node2DSetPositionMethodBind { get; }

    public static void* ObjectEmitSignalMethodBind { get; }

    public static delegate* unmanaged[Cdecl]<void*, void> StringDestructor { get; }

    public static delegate* unmanaged[Cdecl]<void*, void> StringNameDestructor { get; }

    public static delegate* unmanaged[Cdecl]<void*, void*, void*, void> StringNameEqualOperatorEvaluator { get; }

    public static delegate* unmanaged[Cdecl]<void*, void*, void*, void> StringNameNotEqualOperatorEvaluator { get; }

    public static delegate* unmanaged[Cdecl]<GDExtensionVariant*, void*, void> VariantFromFloatConstructor { get; }

    public static delegate* unmanaged[Cdecl]<GDExtensionVariant*, void*, void> VariantFromStringNameConstructor { get; }

    public static delegate* unmanaged[Cdecl]<GDExtensionVariant*, void*, void> VariantFromVector2Constructor { get; }

    public static delegate* unmanaged[Cdecl]<void*, GDExtensionVariant*, void> VariantToFloatConstructor { get; }
}
