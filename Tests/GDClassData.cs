using System;

namespace Godot.NET.Tests;

public struct GDClassData : IDisposable
{
    private readonly GDExtensionClassLibraryPtr _library;
    private GDStringName _className;
    private GDStringName _parentClassName;

    public GDClassData(GDExtensionClassLibraryPtr library, GDStringName className, GDStringName parentClassName)
    {
        _library = library;
        _className = className;
        _parentClassName = parentClassName;
    }

    public readonly GDExtensionClassLibraryPtr Library
    {
        get => _library;
    }

    public readonly GDStringName ClassName
    {
        get => _className;
    }

    public readonly GDStringName ParentClassName
    {
        get => _parentClassName;
    }

    public void Dispose()
    {
        _className.Dispose();
        _parentClassName.Dispose();
    }
}
