using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Godot.GDExtension;

namespace Godot.Tests;

[StructLayout(LayoutKind.Explicit, Size = 24)]
public readonly unsafe struct Variant : IDisposable
{
    public Variant(StringName value)
    {
        fixed (Variant* self = &this)
        {
            GDExtensionVariantFromTypeConstructorFunc constructor = VariantBridge.FromStringNameConstructor;
            constructor.Invoke(new GDExtensionUninitializedVariantPtr(self), new GDExtensionTypePtr(&value));
        }
    }

    public Variant(double value)
    {
        fixed (Variant* self = &this)
        {
            GDExtensionVariantFromTypeConstructorFunc constructor = VariantBridge.FromFloatConstructor;
            constructor.Invoke(new GDExtensionUninitializedVariantPtr(self), new GDExtensionTypePtr(&value));
        }
    }

    public Variant(Vector2 value)
    {
        fixed (Variant* self = &this)
        {
            GDExtensionVariantFromTypeConstructorFunc constructor = VariantBridge.FromVector2Constructor;
            constructor.Invoke(new GDExtensionUninitializedVariantPtr(self), new GDExtensionTypePtr(&value));
        }
    }

    public double ToFloat()
    {
        double result;

        fixed (Variant* self = &this)
        {
            GDExtensionTypeFromVariantConstructorFunc constructor = VariantBridge.ToFloatConstructor;
            constructor.Invoke(new GDExtensionUninitializedTypePtr(&result), new GDExtensionVariantPtr(self));
        }

        return result;
    }

    public void Dispose()
    {
        fixed (Variant* self = &this)
        {
            GDExtensionInterfaceVariantDestroy destructor = GDExtensionInterface.VariantDestroy;
            destructor.Invoke(new GDExtensionVariantPtr(self));
        }
    }
}
