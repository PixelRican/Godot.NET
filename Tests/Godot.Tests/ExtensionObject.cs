using System;
using Godot.GDExtension;

namespace Godot.Tests;

public abstract unsafe class ExtensionObject : IDisposable
{
    private GDExtensionObjectPtr _base;

    protected ExtensionObject(ReadOnlySpan<byte> baseClassName)
    {
        using StringName nameOfBase = new StringName(baseClassName);
        _base = GDExtensionInterface.ClassdbConstructObject.Invoke(new GDExtensionConstStringNamePtr(&nameOfBase));
    }

    ~ExtensionObject()
    {
        Dispose(disposing: false);
    }

    public GDExtensionObjectPtr Base
    {
        get => _base;
    }

    public void EmitSignal(StringName signal, params ReadOnlySpan<Variant> arguments)
    {
        using Variant signalVariant = new Variant(signal);
        Span<GDExtensionConstVariantPtr> pointerArguments = arguments.Length < 128
            ? stackalloc GDExtensionConstVariantPtr[arguments.Length + 1]
            : new GDExtensionConstVariantPtr[arguments.Length + 1];

        fixed (Variant* source = arguments)
        fixed (GDExtensionConstVariantPtr* destination = pointerArguments)
        {
            destination[0] = new GDExtensionConstVariantPtr(&signalVariant);

            for (int i = 0; i < arguments.Length; i++)
            {
                destination[i + 1] = new GDExtensionConstVariantPtr(&source[i]);
            }

            Variant result;
            GDExtensionInterface.ObjectMethodBindCall.Invoke(
                ObjectBridge.EmitSignal,
                _base,
                destination,
                new GDExtensionInt(pointerArguments.Length),
                new GDExtensionUninitializedVariantPtr(&result),
                null);
            result.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _base = default;
        }
    }
}
