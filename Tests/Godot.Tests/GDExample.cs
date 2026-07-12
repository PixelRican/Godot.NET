using System;
using System.Numerics;

namespace Godot.Tests;

public sealed class GDExample : ExtensionObject
{
    private readonly StringName _positionChanged;
    private double _amplitude;
    private double _speed;
    private double _timePassed;
    private double _timeEmit;

    public GDExample() : base("Sprite2D"u8)
    {
        _positionChanged = new StringName("position_changed"u8);
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
        _timeEmit += delta;
        Vector2 newPosition = new Vector2(
            x: (float)(_amplitude * (1.0 + Math.Sin(_timePassed * 2.0))),
            y: (float)(_amplitude * (1.0 + Math.Cos(_timePassed * 1.5))));
        GDExtensionClassDB.SetPosition(Base, newPosition);

        if (_timeEmit >= 1.0)
        {
            using Variant argument = new Variant(newPosition);
            EmitSignal(_positionChanged, argument);
            _timeEmit = 0.0;
        }
    }

    protected override void Dispose(bool disposing)
    {
        _positionChanged.Dispose();
        base.Dispose(disposing);
    }
}
