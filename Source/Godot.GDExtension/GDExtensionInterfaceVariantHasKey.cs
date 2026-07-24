/**************************************************************************/
/*  GDExtensionInterfaceVariantHasKey.cs                                  */
/**************************************************************************/
/*                         This file is part of:                          */
/*                             GODOT ENGINE                               */
/*                        https://godotengine.org                         */
/**************************************************************************/
/* Copyright (c) 2014-present Godot Engine contributors (see AUTHORS.md). */
/* Copyright (c) 2007-2014 Juan Linietsky, Ariel Manzur.                  */
/*                                                                        */
/* Permission is hereby granted, free of charge, to any person obtaining  */
/* a copy of this software and associated documentation files (the        */
/* "Software"), to deal in the Software without restriction, including    */
/* without limitation the rights to use, copy, modify, merge, publish,    */
/* distribute, sublicense, and/or sell copies of the Software, and to     */
/* permit persons to whom the Software is furnished to do so, subject to  */
/* the following conditions:                                              */
/*                                                                        */
/* The above copyright notice and this permission notice shall be         */
/* included in all copies or substantial portions of the Software.        */
/*                                                                        */
/* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,        */
/* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF     */
/* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. */
/* IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY   */
/* CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,   */
/* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE      */
/* SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                 */
/**************************************************************************/

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.GDExtension;

/// <summary>
/// Checks if a Variant has a key.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceVariantHasKey : IEquatable<GDExtensionInterfaceVariantHasKey>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool> _method;

    public GDExtensionInterfaceVariantHasKey(delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool> Method => _method;

    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_key">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the key doesn't exist.
    /// </param>
    /// <returns>
    /// true if the key exists; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionBool Invoke(GDExtensionConstVariantPtr p_self, GDExtensionConstVariantPtr p_key, GDExtensionBool* r_valid)
    {
        return _method(p_self, p_key, r_valid);
    }

    public bool Equals(GDExtensionInterfaceVariantHasKey other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceVariantHasKey other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceVariantHasKey(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceVariantHasKey((delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceVariantHasKey left, GDExtensionInterfaceVariantHasKey right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceVariantHasKey left, GDExtensionInterfaceVariantHasKey right)
    {
        return left._method != right._method;
    }
}
