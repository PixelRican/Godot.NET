/**************************************************************************/
/*  GDExtensionInterfacePackedInt32ArrayOperatorIndex.cs                  */
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

namespace Godot.GDExtension;

/// <summary>
/// Gets a pointer to a 32-bit integer in a PackedInt32Array.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfacePackedInt32ArrayOperatorIndex : IEquatable<GDExtensionInterfacePackedInt32ArrayOperatorIndex>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, int*> _method;

    public GDExtensionInterfacePackedInt32ArrayOperatorIndex(delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, int*> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, int*> Method
    {
        get => _method;
    }

    /// <param name="p_self">
    /// A pointer to a PackedInt32Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the integer to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested 32-bit integer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int* Invoke(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        return _method(p_self, p_index);
    }

    public bool Equals(GDExtensionInterfacePackedInt32ArrayOperatorIndex other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfacePackedInt32ArrayOperatorIndex other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfacePackedInt32ArrayOperatorIndex(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfacePackedInt32ArrayOperatorIndex((delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, int*>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfacePackedInt32ArrayOperatorIndex left, GDExtensionInterfacePackedInt32ArrayOperatorIndex right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfacePackedInt32ArrayOperatorIndex left, GDExtensionInterfacePackedInt32ArrayOperatorIndex right)
    {
        return left._method != right._method;
    }
}
