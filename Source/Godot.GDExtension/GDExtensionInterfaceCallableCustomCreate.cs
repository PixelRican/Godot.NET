/**************************************************************************/
/*  GDExtensionInterfaceCallableCustomCreate.cs                           */
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
/// Creates a custom Callable object from a function pointer.
/// Provided struct can be safely freed once the function returns.
/// </summary>
[Obsolete("Deprecated since Godot 4.3. Use callable_custom_create2 instead.")]
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceCallableCustomCreate : IEquatable<GDExtensionInterfaceCallableCustomCreate>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo*, void> _method;

    public GDExtensionInterfaceCallableCustomCreate(delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo*, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo*, void> Method => _method;

    /// <param name="r_callable">
    /// A pointer that will receive the new Callable.
    /// </param>
    /// <param name="p_callable_custom_info">
    /// The info required to construct a Callable.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionUninitializedTypePtr r_callable, GDExtensionCallableCustomInfo* p_callable_custom_info)
    {
        _method(r_callable, p_callable_custom_info);
    }

    public bool Equals(GDExtensionInterfaceCallableCustomCreate other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceCallableCustomCreate other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceCallableCustomCreate(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceCallableCustomCreate((delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo*, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceCallableCustomCreate left, GDExtensionInterfaceCallableCustomCreate right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceCallableCustomCreate left, GDExtensionInterfaceCallableCustomCreate right)
    {
        return left._method != right._method;
    }
}
