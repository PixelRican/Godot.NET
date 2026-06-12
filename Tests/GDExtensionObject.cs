using System;

namespace Godot.NET.Tests;

public abstract class GDExtensionObject : IDisposable
{
    private GDExtensionObjectPtr _base;

    protected GDExtensionObject(ReadOnlySpan<byte> baseClassName)
    {
        _base = GDExtensionClassDB.ConstructObject(baseClassName);
    }

    ~GDExtensionObject()
    {
        Dispose(disposing: false);
    }

    public GDExtensionObjectPtr Base
    {
        get => _base;
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
