/**************************************************************************/
/*  GDExtensionInterfaceFileAccessStoreBuffer.cs                          */
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
/// Stores the given buffer using an instance of FileAccess.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceFileAccessStoreBuffer : IEquatable<GDExtensionInterfaceFileAccessStoreBuffer>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, ulong, void> _method;

    public GDExtensionInterfaceFileAccessStoreBuffer(delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, ulong, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, ulong, void> Method
    {
        get => _method;
    }

    /// <param name="p_instance">
    /// A pointer to a FileAccess object.
    /// </param>
    /// <param name="p_src">
    /// A pointer to the buffer.
    /// </param>
    /// <param name="p_length">
    /// The size of the buffer.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionObjectPtr p_instance, byte* p_src, ulong p_length)
    {
        _method(p_instance, p_src, p_length);
    }

    public bool Equals(GDExtensionInterfaceFileAccessStoreBuffer other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceFileAccessStoreBuffer other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceFileAccessStoreBuffer(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceFileAccessStoreBuffer((delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, ulong, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceFileAccessStoreBuffer left, GDExtensionInterfaceFileAccessStoreBuffer right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceFileAccessStoreBuffer left, GDExtensionInterfaceFileAccessStoreBuffer right)
    {
        return left._method != right._method;
    }
}
