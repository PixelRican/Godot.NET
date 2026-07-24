/**************************************************************************/
/*  GDExtensionInterfaceStringNewWithUtf16CharsAndLen.cs                  */
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
/// Creates a String from a UTF-16 encoded C string with the given length.
/// </summary>
[Obsolete("Deprecated since Godot 4.3. Use string_new_with_utf16_chars_and_len2 instead.")]
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceStringNewWithUtf16CharsAndLen : IEquatable<GDExtensionInterfaceStringNewWithUtf16CharsAndLen>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void> _method;

    public GDExtensionInterfaceStringNewWithUtf16CharsAndLen(delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void> Method => _method;

    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a UTF-16 encoded C string.
    /// </param>
    /// <param name="p_char_count">
    /// The number of characters (not bytes).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionUninitializedStringPtr r_dest, char* p_contents, GDExtensionInt p_char_count)
    {
        _method(r_dest, p_contents, p_char_count);
    }

    public bool Equals(GDExtensionInterfaceStringNewWithUtf16CharsAndLen other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceStringNewWithUtf16CharsAndLen other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceStringNewWithUtf16CharsAndLen(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceStringNewWithUtf16CharsAndLen((delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceStringNewWithUtf16CharsAndLen left, GDExtensionInterfaceStringNewWithUtf16CharsAndLen right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceStringNewWithUtf16CharsAndLen left, GDExtensionInterfaceStringNewWithUtf16CharsAndLen right)
    {
        return left._method != right._method;
    }
}
