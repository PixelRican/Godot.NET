/**************************************************************************/
/*  GDExtensionInterfaceStringToUtf16Chars.cs                             */
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
/// Converts a String to a UTF-16 encoded C string.
/// It doesn't write a null terminator.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceStringToUtf16Chars : IEquatable<GDExtensionInterfaceStringToUtf16Chars>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, char*, GDExtensionInt, GDExtensionInt> _method;

    public GDExtensionInterfaceStringToUtf16Chars(delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, char*, GDExtensionInt, GDExtensionInt> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, char*, GDExtensionInt, GDExtensionInt> Method
    {
        get => _method;
    }

    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="rText">
    /// A pointer to the buffer to hold the resulting data. If NULL is passed in, only the length will be computed.
    /// </param>
    /// <param name="pMaxWriteLength">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in 16-bit code units (not bytes or characters), not including a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionInt Invoke(GDExtensionConstStringPtr pSelf, char* rText, GDExtensionInt pMaxWriteLength)
    {
        return _method(pSelf, rText, pMaxWriteLength);
    }

    public bool Equals(GDExtensionInterfaceStringToUtf16Chars other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceStringToUtf16Chars other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceStringToUtf16Chars left, GDExtensionInterfaceStringToUtf16Chars right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceStringToUtf16Chars left, GDExtensionInterfaceStringToUtf16Chars right)
    {
        return left._method != right._method;
    }
}
