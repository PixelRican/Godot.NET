/**************************************************************************/
/*  GDExtensionInterfaceObjectMethodBindPtrcall.cs                        */
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
/// Calls a method on an Object (using a "ptrcall").
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceObjectMethodBindPtrcall : IEquatable<GDExtensionInterfaceObjectMethodBindPtrcall>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void> _method;

    public GDExtensionInterfaceObjectMethodBindPtrcall(delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void> Method
    {
        get => _method;
    }

    /// <param name="p_method_bind">
    /// A pointer to the MethodBind representing the method on the Object's class.
    /// </param>
    /// <param name="p_instance">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_args">
    /// A pointer to a C array representing the arguments.
    /// </param>
    /// <param name="r_ret">
    /// A pointer to the Object that will receive the return value.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionMethodBindPtr p_method_bind, GDExtensionObjectPtr p_instance, GDExtensionConstTypePtr* p_args, GDExtensionTypePtr r_ret)
    {
        _method(p_method_bind, p_instance, p_args, r_ret);
    }

    public bool Equals(GDExtensionInterfaceObjectMethodBindPtrcall other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceObjectMethodBindPtrcall other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceObjectMethodBindPtrcall(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceObjectMethodBindPtrcall((delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceObjectMethodBindPtrcall left, GDExtensionInterfaceObjectMethodBindPtrcall right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceObjectMethodBindPtrcall left, GDExtensionInterfaceObjectMethodBindPtrcall right)
    {
        return left._method != right._method;
    }
}
