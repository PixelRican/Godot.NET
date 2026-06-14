using System;
using System.Numerics;

namespace Godot.NET.Tests;

public sealed class GDExample : GDExtensionObject
{
    private double _amplitude;
    private double _speed;
    private double _timePassed;

    public GDExample() : base("Sprite2D"u8)
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

    public void Process(double delta)
    {
        _timePassed += _speed * delta;
        GDExtensionClassDB.SetPosition(Base, new Vector2
        {
            X = (float)(_amplitude * (1.0 + Math.Sin(_timePassed * 2.0))),
            Y = (float)(_amplitude * (1.0 + Math.Cos(_timePassed * 1.5)))
        });
    }
}
