using System;
using System.Runtime.InteropServices;
using Godot.Interop;

namespace Godot.Tests;

[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct Variant : IDisposable
{
    private readonly GDExtensionVariant _value;

    public Variant(StringName value)
    {
        fixed (GDExtensionVariant* self = &_value)
        {
            NativeMethods.VariantFromStringNameConstructor(self, &value);
        }
    }

    public Variant(double value)
    {
        fixed (GDExtensionVariant* self = &_value)
        {
            NativeMethods.VariantFromFloatConstructor(self, &value);
        }
    }

    public Variant(Vector2 value)
    {
        fixed (GDExtensionVariant* self = &_value)
        {
            NativeMethods.VariantFromVector2Constructor(self, &value);
        }
    }

    public double ToFloat()
    {
        fixed (GDExtensionVariant* self = &_value)
        {
            double result;
            NativeMethods.VariantToFloatConstructor(&result, self);
            return result;
        }
    }

    public void Dispose()
    {
        fixed (GDExtensionVariant* self = &_value)
        {
            GDExtensionInterface.VariantDestroy(self);
        }
    }
}
