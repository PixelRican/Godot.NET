using System;

namespace Godot.NET.Tests;

public abstract class GDObject : IDisposable
{
    private GDExtensionObjectPtr _parent;

    protected GDObject(GDExtensionObjectPtr parent)
    {
        _parent = parent;
    }

    ~GDObject()
    {
        Dispose(disposing: false);
    }

    public GDExtensionObjectPtr Parent
    {
        get => _parent;
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
            _parent = default;
        }
    }
}
