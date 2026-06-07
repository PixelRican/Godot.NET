using System;

namespace Godot.NET.Tests;

public abstract class GDExtensionObject : IDisposable
{
    private GDExtensionObjectPtr _parent;

    ~GDExtensionObject()
    {
        Dispose(disposing: false);
    }

    public GDExtensionObjectPtr Parent
    {
        get => _parent;
        init => _parent = value;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        _parent = default;
    }
}
