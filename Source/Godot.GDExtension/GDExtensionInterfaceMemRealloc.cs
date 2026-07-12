/**************************************************************************/
/*  GDExtensionInterfaceMemRealloc.cs                                     */
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
/// Reallocates memory.
/// </summary>
[Obsolete("Deprecated since Godot 4.6. Does not allow explicitly requesting padding. Use mem_realloc2 instead.")]
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceMemRealloc : IEquatable<GDExtensionInterfaceMemRealloc>
{
    private readonly delegate* unmanaged[Cdecl]<void*, nuint, void*> _method;

    public GDExtensionInterfaceMemRealloc(delegate* unmanaged[Cdecl]<void*, nuint, void*> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<void*, nuint, void*> Method
    {
        get => _method;
    }

    /// <param name="pPtr">
    /// A pointer to the previously allocated memory.
    /// </param>
    /// <param name="pBytes">
    /// The number of bytes to resize the memory block to.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or NULL if unsuccessful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* Invoke(void* pPtr, nuint pBytes)
    {
        return _method(pPtr, pBytes);
    }

    public bool Equals(GDExtensionInterfaceMemRealloc other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceMemRealloc other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceMemRealloc(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceMemRealloc((delegate* unmanaged[Cdecl]<void*, nuint, void*>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceMemRealloc left, GDExtensionInterfaceMemRealloc right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceMemRealloc left, GDExtensionInterfaceMemRealloc right)
    {
        return left._method != right._method;
    }
}
