/**************************************************************************/
/*  GDExtensionInterfaceStringOperatorIndex.cs                            */
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
/// Gets a pointer to the character at the given index from a String.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceStringOperatorIndex : IEquatable<GDExtensionInterfaceStringOperatorIndex>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*> _method;

    public GDExtensionInterfaceStringOperatorIndex(delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*> Method
    {
        get => _method;
    }

    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="pIndex">
    /// The index.
    /// </param>
    /// <returns>
    /// A pointer to the requested character.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint* Invoke(GDExtensionStringPtr pSelf, GDExtensionInt pIndex)
    {
        return _method(pSelf, pIndex);
    }

    public bool Equals(GDExtensionInterfaceStringOperatorIndex other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceStringOperatorIndex other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceStringOperatorIndex(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceStringOperatorIndex((delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceStringOperatorIndex left, GDExtensionInterfaceStringOperatorIndex right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceStringOperatorIndex left, GDExtensionInterfaceStringOperatorIndex right)
    {
        return left._method != right._method;
    }
}
