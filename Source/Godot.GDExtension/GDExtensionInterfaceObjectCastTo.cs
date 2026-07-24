/**************************************************************************/
/*  GDExtensionInterfaceObjectCastTo.cs                                   */
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
/// Casts an Object to a different type.
/// </summary>
[Obsolete("Deprecated since Godot 4.7. Use the `is_class` method on `Object` to check if an object can be cast instead. If true, the previous pointer can be reinterpreted as a pointer to the target type.")]
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceObjectCastTo : IEquatable<GDExtensionInterfaceObjectCastTo>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, void*, GDExtensionObjectPtr> _method;

    public GDExtensionInterfaceObjectCastTo(delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, void*, GDExtensionObjectPtr> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, void*, GDExtensionObjectPtr> Method => _method;

    /// <param name="p_object">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_class_tag">
    /// A pointer uniquely identifying a built-in class in the ClassDB.
    /// </param>
    /// <returns>
    /// Returns a pointer to the Object, or NULL if it can't be cast to the requested type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionObjectPtr Invoke(GDExtensionConstObjectPtr p_object, void* p_class_tag)
    {
        return _method(p_object, p_class_tag);
    }

    public bool Equals(GDExtensionInterfaceObjectCastTo other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceObjectCastTo other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceObjectCastTo(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceObjectCastTo((delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, void*, GDExtensionObjectPtr>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceObjectCastTo left, GDExtensionInterfaceObjectCastTo right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceObjectCastTo left, GDExtensionInterfaceObjectCastTo right)
    {
        return left._method != right._method;
    }
}
