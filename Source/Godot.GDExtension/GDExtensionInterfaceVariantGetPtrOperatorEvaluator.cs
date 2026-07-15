/**************************************************************************/
/*  GDExtensionInterfaceVariantGetPtrOperatorEvaluator.cs                 */
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
/// Gets a pointer to a function that can evaluate the given Variant operator on the given Variant types.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceVariantGetPtrOperatorEvaluator : IEquatable<GDExtensionInterfaceVariantGetPtrOperatorEvaluator>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, GDExtensionPtrOperatorEvaluator> _method;

    public GDExtensionInterfaceVariantGetPtrOperatorEvaluator(delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, GDExtensionPtrOperatorEvaluator> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, GDExtensionPtrOperatorEvaluator> Method
    {
        get => _method;
    }

    /// <param name="p_operator">
    /// The variant operator.
    /// </param>
    /// <param name="p_type_a">
    /// The type of the first Variant.
    /// </param>
    /// <param name="p_type_b">
    /// The type of the second Variant.
    /// </param>
    /// <returns>
    /// A pointer to a function that can evaluate the given Variant operator on the given Variant types.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionPtrOperatorEvaluator Invoke(GDExtensionVariantOperator p_operator, GDExtensionVariantType p_type_a, GDExtensionVariantType p_type_b)
    {
        return _method(p_operator, p_type_a, p_type_b);
    }

    public bool Equals(GDExtensionInterfaceVariantGetPtrOperatorEvaluator other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceVariantGetPtrOperatorEvaluator other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceVariantGetPtrOperatorEvaluator(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceVariantGetPtrOperatorEvaluator((delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, GDExtensionPtrOperatorEvaluator>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceVariantGetPtrOperatorEvaluator left, GDExtensionInterfaceVariantGetPtrOperatorEvaluator right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceVariantGetPtrOperatorEvaluator left, GDExtensionInterfaceVariantGetPtrOperatorEvaluator right)
    {
        return left._method != right._method;
    }
}
