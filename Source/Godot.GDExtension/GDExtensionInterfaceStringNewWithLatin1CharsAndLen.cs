/**************************************************************************/
/*  GDExtensionInterfaceStringNewWithLatin1CharsAndLen.cs                 */
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
/// Creates a String from a Latin-1 encoded C string with the given length.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceStringNewWithLatin1CharsAndLen : IEquatable<GDExtensionInterfaceStringNewWithLatin1CharsAndLen>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> _method;

    public GDExtensionInterfaceStringNewWithLatin1CharsAndLen(delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> Method
    {
        get => _method;
    }

    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a Latin-1 encoded C string.
    /// </param>
    /// <param name="pSize">
    /// The number of characters (= number of bytes).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionUninitializedStringPtr rDest, byte* pContents, GDExtensionInt pSize)
    {
        _method(rDest, pContents, pSize);
    }

    public bool Equals(GDExtensionInterfaceStringNewWithLatin1CharsAndLen other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceStringNewWithLatin1CharsAndLen other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceStringNewWithLatin1CharsAndLen left, GDExtensionInterfaceStringNewWithLatin1CharsAndLen right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceStringNewWithLatin1CharsAndLen left, GDExtensionInterfaceStringNewWithLatin1CharsAndLen right)
    {
        return left._method != right._method;
    }
}
