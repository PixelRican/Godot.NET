/**************************************************************************/
/*  GDExtensionInterfaceVariantCallStatic.cs                              */
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
/// Calls a static method on a Variant.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceVariantCallStatic : IEquatable<GDExtensionInterfaceVariantCallStatic>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> _method;

    public GDExtensionInterfaceVariantCallStatic(delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> Method
    {
        get => _method;
    }

    /// <param name="pType">
    /// The variant type.
    /// </param>
    /// <param name="pMethod">
    /// A pointer to a StringName identifying the method.
    /// </param>
    /// <param name="pArgs">
    /// A pointer to a C array of Variant.
    /// </param>
    /// <param name="pArgumentCount">
    /// The number of arguments.
    /// </param>
    /// <param name="rReturn">
    /// A pointer a Variant which will be assigned the return value.
    /// </param>
    /// <param name="rError">
    /// A pointer the structure which will be updated with error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionVariantType pType, GDExtensionConstStringNamePtr pMethod, GDExtensionConstVariantPtr* pArgs, GDExtensionInt pArgumentCount, GDExtensionUninitializedVariantPtr rReturn, GDExtensionCallError* rError)
    {
        _method(pType, pMethod, pArgs, pArgumentCount, rReturn, rError);
    }

    public bool Equals(GDExtensionInterfaceVariantCallStatic other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceVariantCallStatic other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceVariantCallStatic left, GDExtensionInterfaceVariantCallStatic right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceVariantCallStatic left, GDExtensionInterfaceVariantCallStatic right)
    {
        return left._method != right._method;
    }
}
