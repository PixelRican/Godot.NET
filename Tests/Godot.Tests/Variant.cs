using System;
using System.Runtime.InteropServices;
using Godot.Interop;

namespace Godot.Tests;

#if REAL_IS_DOUBLE
[StructLayout(LayoutKind.Explicit, Size = 40)]
#else
[StructLayout(LayoutKind.Explicit, Size = 24)]
#endif
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
            GDExtensionInterfaceVariantDestroy destructor = GodotBridge.GDExtensionInterface.VariantDestroy;
            destructor.Invoke(new GDExtensionVariantPtr(self));
        }
    }
}
