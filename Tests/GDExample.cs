namespace Godot.NET.Tests;

public sealed class GDExample : GDObject
{
    private double _amplitude;
    private double _speed;

    public GDExample(GDExtensionObjectPtr parent) : base(parent)
    {
        _amplitude = 10.0;
        _speed = 1.0;
    }

    public double Amplitude
    {
        get => _amplitude;
        set => _amplitude = value;
    }

    public double Speed
    {
        get => _speed;
        set => _speed = value;
    }
}
