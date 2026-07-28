using System;
using Godot.Interop;

namespace Godot.Tests;

public abstract unsafe class ExtensionObject : IDisposable
{
    private nint _base;

    protected ExtensionObject() : this("Object"u8)
    {
    }

    protected ExtensionObject(ReadOnlySpan<byte> baseClassName)
    {
        using StringName nameOfBase = new StringName(baseClassName);
        _base = (nint)GDExtensionInterface.ClassDBConstructObject((GDExtensionStringName*)&nameOfBase);
    }

    ~ExtensionObject()
    {
        Dispose(disposing: false);
    }

    public nint Base => _base;

    public void EmitSignal(StringName signal, params ReadOnlySpan<Variant> arguments)
    {
        using Variant signalVariant = new Variant(signal);
        Span<nint> pointerArguments = arguments.Length < 128
            ? stackalloc nint[arguments.Length + 1]
            : new nint[arguments.Length + 1];

        fixed (Variant* source = arguments)
        fixed (nint* destination = pointerArguments)
        {
            destination[0] = (nint)(&signalVariant);

            for (int i = 0; i < arguments.Length; i++)
            {
                destination[i + 1] = (nint)(&source[i]);
            }

            Variant result;
            GDExtensionInterface.ObjectMethodBindCall(
                NativeMethods.ObjectEmitSignalMethodBind,
                (void*)_base,
                (GDExtensionVariant**)destination,
                pointerArguments.Length,
                (GDExtensionVariant*)&result,
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
            _base = 0;
        }
    }
}
