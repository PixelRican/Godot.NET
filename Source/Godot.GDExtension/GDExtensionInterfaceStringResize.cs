/**************************************************************************/
/*  GDExtensionInterfaceStringResize.cs                                   */
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
/// Resizes the underlying string data to the given number of characters.
/// Space needs to be allocated for the null terminating character ('\0') which
/// also must be added manually, in order for all string functions to work correctly.
/// 
/// Warning: This is an error-prone operation - only use it if there's no other
/// efficient way to accomplish your goal.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceStringResize : IEquatable<GDExtensionInterfaceStringResize>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, GDExtensionInt> _method;

    public GDExtensionInterfaceStringResize(delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, GDExtensionInt> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, GDExtensionInt> Method => _method;

    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="p_resize">
    /// The new length for the String.
    /// </param>
    /// <returns>
    /// Error code signifying if the operation successful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionInt Invoke(GDExtensionStringPtr p_self, GDExtensionInt p_resize)
    {
        return _method(p_self, p_resize);
    }

    public bool Equals(GDExtensionInterfaceStringResize other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceStringResize other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceStringResize(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceStringResize((delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, GDExtensionInt>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceStringResize left, GDExtensionInterfaceStringResize right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceStringResize left, GDExtensionInterfaceStringResize right)
    {
        return left._method != right._method;
    }
}
