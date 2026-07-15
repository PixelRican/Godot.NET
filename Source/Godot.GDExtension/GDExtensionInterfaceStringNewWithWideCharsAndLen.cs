/**************************************************************************/
/*  GDExtensionInterfaceStringNewWithWideCharsAndLen.cs                   */
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
/// Creates a String from a wide C string with the given length.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceStringNewWithWideCharsAndLen : IEquatable<GDExtensionInterfaceStringNewWithWideCharsAndLen>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, GDExtensionInt, void> _method;

    public GDExtensionInterfaceStringNewWithWideCharsAndLen(delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, GDExtensionInt, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, GDExtensionInt, void> Method
    {
        get => _method;
    }

    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a wide C string.
    /// </param>
    /// <param name="p_char_count">
    /// The number of characters (not bytes).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionUninitializedStringPtr r_dest, void* p_contents, GDExtensionInt p_char_count)
    {
        _method(r_dest, p_contents, p_char_count);
    }

    public bool Equals(GDExtensionInterfaceStringNewWithWideCharsAndLen other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceStringNewWithWideCharsAndLen other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceStringNewWithWideCharsAndLen(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceStringNewWithWideCharsAndLen((delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, GDExtensionInt, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceStringNewWithWideCharsAndLen left, GDExtensionInterfaceStringNewWithWideCharsAndLen right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceStringNewWithWideCharsAndLen left, GDExtensionInterfaceStringNewWithWideCharsAndLen right)
    {
        return left._method != right._method;
    }
}
