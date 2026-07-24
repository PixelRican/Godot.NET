/**************************************************************************/
/*  GDExtensionInterfaceStringNameNewWithUtf8Chars.cs                     */
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
/// Creates a StringName from a UTF-8 encoded C string.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceStringNameNewWithUtf8Chars : IEquatable<GDExtensionInterfaceStringNameNewWithUtf8Chars>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, void> _method;

    public GDExtensionInterfaceStringNameNewWithUtf8Chars(delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, void> Method
    {
        get => _method;
    }

    /// <param name="r_dest">
    /// A pointer to uninitialized storage, into which the newly created StringName is constructed.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a C string (null terminated and UTF-8 encoded).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionUninitializedStringNamePtr r_dest, byte* p_contents)
    {
        _method(r_dest, p_contents);
    }

    public bool Equals(GDExtensionInterfaceStringNameNewWithUtf8Chars other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceStringNameNewWithUtf8Chars other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceStringNameNewWithUtf8Chars(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceStringNameNewWithUtf8Chars((delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceStringNameNewWithUtf8Chars left, GDExtensionInterfaceStringNameNewWithUtf8Chars right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceStringNameNewWithUtf8Chars left, GDExtensionInterfaceStringNameNewWithUtf8Chars right)
    {
        return left._method != right._method;
    }
}
