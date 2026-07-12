using System.Runtime.InteropServices;

namespace Godot.Tests;

[StructLayout(LayoutKind.Sequential)]
public struct Vector2
{
    public Real X;
    public Real Y;

    public Vector2(Real x, Real y)
    {
        X = x;
        Y = y;
    }
}
