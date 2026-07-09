/**************************************************************************/
/*  GDExtensionInterfaceVariantGetPtrInternalGetter.cs                    */
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
/// Provides a function pointer for retrieving a pointer to a variant's internal value.
/// Access to a variant's internal value can be used to modify it in-place, or to retrieve its value without the overhead of variant conversion functions.
/// It is recommended to cache the getter for all variant types in a function table to avoid retrieval overhead upon use.
/// 
/// Each function assumes the variant's type has already been determined and matches the function.
/// Invoking the function with a variant of a mismatched type has undefined behavior, and may lead to a segmentation fault.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceVariantGetPtrInternalGetter : IEquatable<GDExtensionInterfaceVariantGetPtrInternalGetter>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantGetInternalPtrFunc> _method;

    public GDExtensionInterfaceVariantGetPtrInternalGetter(delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantGetInternalPtrFunc> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantGetInternalPtrFunc> Method
    {
        get => _method;
    }

    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a type-specific function that returns a pointer to the internal value of a variant. Check the implementation of this function (gdextension_variant_get_ptr_internal_getter) for pointee type info of each variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionVariantGetInternalPtrFunc Invoke(GDExtensionVariantType pType)
    {
        return _method(pType);
    }

    public bool Equals(GDExtensionInterfaceVariantGetPtrInternalGetter other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceVariantGetPtrInternalGetter other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceVariantGetPtrInternalGetter left, GDExtensionInterfaceVariantGetPtrInternalGetter right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceVariantGetPtrInternalGetter left, GDExtensionInterfaceVariantGetPtrInternalGetter right)
    {
        return left._method != right._method;
    }
}
