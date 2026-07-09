/**************************************************************************/
/*  GDExtensionInterfaceCallableCustomGetUserdata.cs                      */
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
/// Retrieves the userdata pointer from a custom Callable.
/// If the Callable is not a custom Callable or the token does not match the one provided to callable_custom_create() via GDExtensionCallableCustomInfo then NULL will be returned.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceCallableCustomGetUserdata : IEquatable<GDExtensionInterfaceCallableCustomGetUserdata>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, void*, void*> _method;

    public GDExtensionInterfaceCallableCustomGetUserdata(delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, void*, void*> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, void*, void*> Method
    {
        get => _method;
    }

    /// <param name="pCallable">
    /// A pointer to a Callable.
    /// </param>
    /// <param name="pToken">
    /// A pointer to an address that uniquely identifies the GDExtension.
    /// </param>
    /// <returns>
    /// The userdata pointer given when creating this custom Callable.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* Invoke(GDExtensionConstTypePtr pCallable, void* pToken)
    {
        return _method(pCallable, pToken);
    }

    public bool Equals(GDExtensionInterfaceCallableCustomGetUserdata other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceCallableCustomGetUserdata other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceCallableCustomGetUserdata left, GDExtensionInterfaceCallableCustomGetUserdata right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceCallableCustomGetUserdata left, GDExtensionInterfaceCallableCustomGetUserdata right)
    {
        return left._method != right._method;
    }
}
