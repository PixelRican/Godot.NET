using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Godot.Interop;

namespace Godot.Tests;

[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct StringName : IDisposable, IEquatable<StringName>
{
    private readonly GDExtensionStringName _value;

    public StringName(ReadOnlySpan<byte> contents)
    {
        fixed (byte* reference = contents)
        fixed (GDExtensionStringName* self = &_value)
        {
            GDExtensionInterface.StringNameNewWithUtf8CharsAndLen(self, reference, contents.Length);
        }
    }

    public void Dispose()
    {
        fixed (GDExtensionStringName* self = &_value)
        {
            NativeMethods.StringNameDestructor(self);
        }
    }

    public bool Equals(StringName other)
    {
        return this == other;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is StringName other && this == other;
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(StringName left, StringName right)
    {
        bool result;
        NativeMethods.StringNameEqualOperatorEvaluator(&left._value, &right._value, &result);
        return result;
    }

    public static bool operator !=(StringName left, StringName right)
    {
        bool result;
        NativeMethods.StringNameNotEqualOperatorEvaluator(&left._value, &right._value, &result);
        return result;
    }
}
