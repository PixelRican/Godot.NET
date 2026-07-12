using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Godot.GDExtension;

namespace Godot.Tests;

#if BUILD_32
[StructLayout(LayoutKind.Explicit, Size = 4)]
#else
[StructLayout(LayoutKind.Explicit, Size = 8)]
#endif
public readonly unsafe struct StringName : IDisposable, IEquatable<StringName>
{
    public StringName(ReadOnlySpan<byte> contents)
    {
        fixed (StringName* self = &this)
        fixed (byte* reference = contents)
        {
            GDExtensionInterface.StringNameNewWithUtf8CharsAndLen.Invoke(
                new GDExtensionUninitializedStringNamePtr(self),
                reference,
                new GDExtensionInt(contents.Length));
        }
    }

    public void Dispose()
    {
        fixed (StringName* self = &this)
        {
            StringNameBridge.Destructor.Invoke(new GDExtensionTypePtr(self));
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
        GDExtensionBool result;
        StringNameBridge.OperatorEqual.Invoke(
            new GDExtensionConstTypePtr(&left),
            new GDExtensionConstTypePtr(&right),
            new GDExtensionTypePtr(&result));
        return result.Value;
    }

    public static bool operator !=(StringName left, StringName right)
    {
        GDExtensionBool result;
        StringNameBridge.OperatorNotEqual.Invoke(
            new GDExtensionConstTypePtr(&left),
            new GDExtensionConstTypePtr(&right),
            new GDExtensionTypePtr(&result));
        return result.Value;
    }
}
