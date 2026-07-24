/**************************************************************************/
/*  GDExtensionInterfacePackedFloat64ArrayOperatorIndex.cs                */
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
/// Gets a pointer to a 64-bit float in a PackedFloat64Array.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfacePackedFloat64ArrayOperatorIndex : IEquatable<GDExtensionInterfacePackedFloat64ArrayOperatorIndex>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, double*> _method;

    public GDExtensionInterfacePackedFloat64ArrayOperatorIndex(delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, double*> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, double*> Method => _method;

    /// <param name="p_self">
    /// A pointer to a PackedFloat64Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the float to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested 64-bit float.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double* Invoke(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        return _method(p_self, p_index);
    }

    public bool Equals(GDExtensionInterfacePackedFloat64ArrayOperatorIndex other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfacePackedFloat64ArrayOperatorIndex other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfacePackedFloat64ArrayOperatorIndex(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfacePackedFloat64ArrayOperatorIndex((delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, double*>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfacePackedFloat64ArrayOperatorIndex left, GDExtensionInterfacePackedFloat64ArrayOperatorIndex right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfacePackedFloat64ArrayOperatorIndex left, GDExtensionInterfacePackedFloat64ArrayOperatorIndex right)
    {
        return left._method != right._method;
    }
}
