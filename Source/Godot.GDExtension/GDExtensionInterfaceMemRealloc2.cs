/**************************************************************************/
/*  GDExtensionInterfaceMemRealloc2.cs                                    */
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
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceMemRealloc2 : IEquatable<GDExtensionInterfaceMemRealloc2>
{
    private readonly delegate* unmanaged[Cdecl]<void*, nuint, GDExtensionBool, void*> _method;

    public GDExtensionInterfaceMemRealloc2(delegate* unmanaged[Cdecl]<void*, nuint, GDExtensionBool, void*> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<void*, nuint, GDExtensionBool, void*> Method
    {
        get => _method;
    }

    /// <param name="p_ptr">
    /// A pointer to the previously allocated memory.
    /// </param>
    /// <param name="p_bytes">
    /// The number of bytes to resize the memory block to.
    /// </param>
    /// <param name="p_pad_align">
    /// If true, the returned memory will have prepadding of at least 8 bytes.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or NULL if unsuccessful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* Invoke(void* p_ptr, nuint p_bytes, GDExtensionBool p_pad_align)
    {
        return _method(p_ptr, p_bytes, p_pad_align);
    }

    public bool Equals(GDExtensionInterfaceMemRealloc2 other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceMemRealloc2 other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceMemRealloc2(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceMemRealloc2((delegate* unmanaged[Cdecl]<void*, nuint, GDExtensionBool, void*>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceMemRealloc2 left, GDExtensionInterfaceMemRealloc2 right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceMemRealloc2 left, GDExtensionInterfaceMemRealloc2 right)
    {
        return left._method != right._method;
    }
}
