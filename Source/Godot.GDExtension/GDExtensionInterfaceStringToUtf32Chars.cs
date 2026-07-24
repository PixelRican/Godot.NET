/**************************************************************************/
/*  GDExtensionInterfaceStringToUtf32Chars.cs                             */
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
/// Converts a String to a UTF-32 encoded C string.
/// It doesn't write a null terminator.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceStringToUtf32Chars : IEquatable<GDExtensionInterfaceStringToUtf32Chars>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt> _method;

    public GDExtensionInterfaceStringToUtf32Chars(delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt> Method => _method;

    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="r_text">
    /// A pointer to the buffer to hold the resulting data. If NULL is passed in, only the length will be computed.
    /// </param>
    /// <param name="p_max_write_length">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in characters (not bytes), not including a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionInt Invoke(GDExtensionConstStringPtr p_self, uint* r_text, GDExtensionInt p_max_write_length)
    {
        return _method(p_self, r_text, p_max_write_length);
    }

    public bool Equals(GDExtensionInterfaceStringToUtf32Chars other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceStringToUtf32Chars other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceStringToUtf32Chars(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceStringToUtf32Chars((delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceStringToUtf32Chars left, GDExtensionInterfaceStringToUtf32Chars right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceStringToUtf32Chars left, GDExtensionInterfaceStringToUtf32Chars right)
    {
        return left._method != right._method;
    }
}
