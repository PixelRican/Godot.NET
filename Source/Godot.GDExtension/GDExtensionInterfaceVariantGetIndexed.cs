/**************************************************************************/
/*  GDExtensionInterfaceVariantGetIndexed.cs                              */
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GDExtension;

/// <summary>
/// Gets the value of an index from a Variant.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceVariantGetIndexed : IEquatable<GDExtensionInterfaceVariantGetIndexed>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool*, void> _method;

    public GDExtensionInterfaceVariantGetIndexed(delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool*, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool*, void> Method
    {
        get => _method;
    }

    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pIndex">
    /// The index.
    /// </param>
    /// <param name="rRet">
    /// A pointer to a Variant which will be assigned the value.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    /// <param name="rOob">
    /// A pointer to a boolean which will be set to true if the index is out of bounds.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionConstVariantPtr pSelf, GDExtensionInt pIndex, GDExtensionUninitializedVariantPtr rRet, GDExtensionBool* rValid, GDExtensionBool* rOob)
    {
        _method(pSelf, pIndex, rRet, rValid, rOob);
    }

    public bool Equals(GDExtensionInterfaceVariantGetIndexed other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceVariantGetIndexed other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceVariantGetIndexed left, GDExtensionInterfaceVariantGetIndexed right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceVariantGetIndexed left, GDExtensionInterfaceVariantGetIndexed right)
    {
        return left._method != right._method;
    }
}
