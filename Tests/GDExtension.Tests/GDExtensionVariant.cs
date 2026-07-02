using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace GDExtension.Tests;

[StructLayout(LayoutKind.Explicit, Size = 24)]
public readonly unsafe struct GDExtensionVariant : IDisposable
{
    private static readonly GDExtensionVariantFromTypeConstructorFunc s_fromFloatConstructor;
    private static readonly GDExtensionVariantFromTypeConstructorFunc s_fromStringNameConstructor;
    private static readonly GDExtensionVariantFromTypeConstructorFunc s_fromVector2Constructor;
    private static readonly GDExtensionTypeFromVariantConstructorFunc s_toFloatConstructor;

    static GDExtensionVariant()
    {
        s_fromFloatConstructor = GDExtensionInterface.GetVariantFromTypeConstructor(GDExtensionVariantTypeFloat);
        s_fromStringNameConstructor = GDExtensionInterface.GetVariantFromTypeConstructor(GDExtensionVariantTypeStringName);
        s_fromVector2Constructor = GDExtensionInterface.GetVariantFromTypeConstructor(GDExtensionVariantTypeVector2);
        s_toFloatConstructor = GDExtensionInterface.GetVariantToTypeConstructor(GDExtensionVariantTypeFloat);
    }

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

    public GDExtensionVariant(nint value)
    {
        fixed (GDExtensionVariant* self = &this)
        {
            s_fromStringNameConstructor.Invoke(new GDExtensionUninitializedVariantPtr(self), new GDExtensionTypePtr(&value));
        }
    }

    public GDExtensionVariant(Vector2 value)
    {
        fixed (GDExtensionVariant* self = &this)
        {
            s_fromVector2Constructor.Invoke(new GDExtensionUninitializedVariantPtr(self), new GDExtensionTypePtr(&value));
        }
    }

    public void Destroy()
    {
        fixed (GDExtensionVariant* self = &this)
        {
            GDExtensionInterface.VariantDestroy(new GDExtensionVariantPtr(self));
        }
    }

    public double ToFloat()
    {
        fixed (GDExtensionVariant* self = &this)
        {
            double result;
            s_toFloatConstructor.Invoke(new GDExtensionUninitializedTypePtr(&result), new GDExtensionVariantPtr(self));
            return result;
        }
    }

    public void Dispose()
    {
        Destroy();
    }
}
