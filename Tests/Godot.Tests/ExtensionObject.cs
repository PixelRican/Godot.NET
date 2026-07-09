using System;
using Godot.GDExtension;

namespace Godot.Tests;

public abstract class ExtensionObject : IDisposable
{
    private GDExtensionObjectPtr _base;

    protected ExtensionObject(ReadOnlySpan<byte> baseClassName)
    {
        _base = GDExtensionClassDB.ConstructObject(baseClassName);
    }

    ~ExtensionObject()
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
