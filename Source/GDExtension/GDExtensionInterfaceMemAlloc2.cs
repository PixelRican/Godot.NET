/**************************************************************************/
/*  GDExtensionInterfaceMemAlloc2.cs                                      */
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
/// Allocates memory.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceMemAlloc2 : IEquatable<GDExtensionInterfaceMemAlloc2>
{
    private readonly delegate* unmanaged[Cdecl]<nuint, GDExtensionBool, void*> _method;

    public GDExtensionInterfaceMemAlloc2(delegate* unmanaged[Cdecl]<nuint, GDExtensionBool, void*> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<nuint, GDExtensionBool, void*> Method
    {
        get => _method;
    }

    /// <param name="pBytes">
    /// The amount of memory to allocate in bytes.
    /// </param>
    /// <param name="pPadAlign">
    /// If true, the returned memory will have prepadding of at least 8 bytes.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or NULL if unsuccessful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* Invoke(nuint pBytes, GDExtensionBool pPadAlign)
    {
        return _method(pBytes, pPadAlign);
    }

    public bool Equals(GDExtensionInterfaceMemAlloc2 other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceMemAlloc2 other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceMemAlloc2 left, GDExtensionInterfaceMemAlloc2 right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceMemAlloc2 left, GDExtensionInterfaceMemAlloc2 right)
    {
        return left._method != right._method;
    }
}
