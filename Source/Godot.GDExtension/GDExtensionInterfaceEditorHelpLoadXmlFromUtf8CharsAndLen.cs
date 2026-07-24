/**************************************************************************/
/*  GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen.cs           */
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
/// Loads new XML-formatted documentation data in the editor.
/// The provided pointer can be immediately freed once the function returns.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen : IEquatable<GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen>
{
    private readonly delegate* unmanaged[Cdecl]<byte*, GDExtensionInt, void> _method;

    public GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen(delegate* unmanaged[Cdecl]<byte*, GDExtensionInt, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<byte*, GDExtensionInt, void> Method => _method;

    /// <param name="p_data">
    /// A pointer to a UTF-8 encoded C string.
    /// </param>
    /// <param name="p_size">
    /// The number of bytes (not code units).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(byte* p_data, GDExtensionInt p_size)
    {
        _method(p_data, p_size);
    }

    public bool Equals(GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen((delegate* unmanaged[Cdecl]<byte*, GDExtensionInt, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen left, GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen left, GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen right)
    {
        return left._method != right._method;
    }
}
