/**************************************************************************/
/*  GDExtensionInterfacePrintError.cs                                     */
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
/// Logs an error to Godot's built-in debugger and to the OS terminal.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfacePrintError : IEquatable<GDExtensionInterfacePrintError>
{
    private readonly delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> _method;

    public GDExtensionInterfacePrintError(delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> Method => _method;

    /// <param name="p_description">
    /// The code triggering the error.
    /// </param>
    /// <param name="p_function">
    /// The function name where the error occurred.
    /// </param>
    /// <param name="p_file">
    /// The file where the error occurred.
    /// </param>
    /// <param name="p_line">
    /// The line where the error occurred.
    /// </param>
    /// <param name="p_editor_notify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(byte* p_description, byte* p_function, byte* p_file, int p_line, GDExtensionBool p_editor_notify)
    {
        _method(p_description, p_function, p_file, p_line, p_editor_notify);
    }

    public bool Equals(GDExtensionInterfacePrintError other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfacePrintError other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfacePrintError(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfacePrintError((delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfacePrintError left, GDExtensionInterfacePrintError right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfacePrintError left, GDExtensionInterfacePrintError right)
    {
        return left._method != right._method;
    }
}
