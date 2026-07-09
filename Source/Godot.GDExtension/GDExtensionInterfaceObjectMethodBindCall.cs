/**************************************************************************/
/*  GDExtensionInterfaceObjectMethodBindCall.cs                           */
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
/// Calls a method on an Object.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceObjectMethodBindCall : IEquatable<GDExtensionInterfaceObjectMethodBindCall>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> _method;

    public GDExtensionInterfaceObjectMethodBindCall(delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> Method
    {
        get => _method;
    }

    /// <param name="pMethodBind">
    /// A pointer to the MethodBind representing the method on the Object's class.
    /// </param>
    /// <param name="pInstance">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pArgs">
    /// A pointer to a C array of Variants representing the arguments.
    /// </param>
    /// <param name="pArgCount">
    /// The number of arguments.
    /// </param>
    /// <param name="rRet">
    /// A pointer to Variant which will receive the return value.
    /// </param>
    /// <param name="rError">
    /// A pointer to a GDExtensionCallError struct that will receive error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionMethodBindPtr pMethodBind, GDExtensionObjectPtr pInstance, GDExtensionConstVariantPtr* pArgs, GDExtensionInt pArgCount, GDExtensionUninitializedVariantPtr rRet, GDExtensionCallError* rError)
    {
        _method(pMethodBind, pInstance, pArgs, pArgCount, rRet, rError);
    }

    public bool Equals(GDExtensionInterfaceObjectMethodBindCall other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceObjectMethodBindCall other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceObjectMethodBindCall left, GDExtensionInterfaceObjectMethodBindCall right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceObjectMethodBindCall left, GDExtensionInterfaceObjectMethodBindCall right)
    {
        return left._method != right._method;
    }
}
