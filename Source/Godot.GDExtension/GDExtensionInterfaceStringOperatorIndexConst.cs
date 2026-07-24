/**************************************************************************/
/*  GDExtensionInterfaceStringOperatorIndexConst.cs                       */
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
/// Gets a const pointer to the character at the given index from a String.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceStringOperatorIndexConst : IEquatable<GDExtensionInterfaceStringOperatorIndexConst>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*> _method;

    public GDExtensionInterfaceStringOperatorIndexConst(delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*> Method => _method;

    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="p_index">
    /// The index.
    /// </param>
    /// <returns>
    /// A const pointer to the requested character.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint* Invoke(GDExtensionConstStringPtr p_self, GDExtensionInt p_index)
    {
        return _method(p_self, p_index);
    }

    public bool Equals(GDExtensionInterfaceStringOperatorIndexConst other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceStringOperatorIndexConst other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceStringOperatorIndexConst(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceStringOperatorIndexConst((delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceStringOperatorIndexConst left, GDExtensionInterfaceStringOperatorIndexConst right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceStringOperatorIndexConst left, GDExtensionInterfaceStringOperatorIndexConst right)
    {
        return left._method != right._method;
    }
}
