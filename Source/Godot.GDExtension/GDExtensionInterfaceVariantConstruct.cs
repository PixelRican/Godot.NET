/**************************************************************************/
/*  GDExtensionInterfaceVariantConstruct.cs                               */
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
/// Constructs a Variant of the given type, using the first constructor that matches the given arguments.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceVariantConstruct : IEquatable<GDExtensionInterfaceVariantConstruct>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr*, int, GDExtensionCallError*, void> _method;

    public GDExtensionInterfaceVariantConstruct(delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr*, int, GDExtensionCallError*, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr*, int, GDExtensionCallError*, void> Method
    {
        get => _method;
    }

    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <param name="r_base">
    /// A pointer to a Variant to store the constructed value.
    /// </param>
    /// <param name="p_args">
    /// A pointer to a C array of Variant pointers representing the arguments for the constructor.
    /// </param>
    /// <param name="p_argument_count">
    /// The number of arguments to pass to the constructor.
    /// </param>
    /// <param name="r_error">
    /// A pointer the structure which will be updated with error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionVariantType p_type, GDExtensionUninitializedVariantPtr r_base, GDExtensionConstVariantPtr* p_args, int p_argument_count, GDExtensionCallError* r_error)
    {
        _method(p_type, r_base, p_args, p_argument_count, r_error);
    }

    public bool Equals(GDExtensionInterfaceVariantConstruct other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceVariantConstruct other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceVariantConstruct(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceVariantConstruct((delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr*, int, GDExtensionCallError*, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceVariantConstruct left, GDExtensionInterfaceVariantConstruct right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceVariantConstruct left, GDExtensionInterfaceVariantConstruct right)
    {
        return left._method != right._method;
    }
}
