/**************************************************************************/
/*  GDExtensionInterfaceClassdbGetClassTag.cs                             */
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
/// Gets a pointer uniquely identifying the given built-in class in the ClassDB.
/// </summary>
[Obsolete("Deprecated since Godot 4.7. No longer needed. Use the `is_class` method on `Object` instead.")]
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceClassdbGetClassTag : IEquatable<GDExtensionInterfaceClassdbGetClassTag>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void*> _method;

    public GDExtensionInterfaceClassdbGetClassTag(delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void*> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void*> Method
    {
        get => _method;
    }

    /// <param name="pClassname">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer uniquely identifying the built-in class in the ClassDB.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* Invoke(GDExtensionConstStringNamePtr pClassname)
    {
        return _method(pClassname);
    }

    public bool Equals(GDExtensionInterfaceClassdbGetClassTag other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceClassdbGetClassTag other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceClassdbGetClassTag left, GDExtensionInterfaceClassdbGetClassTag right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceClassdbGetClassTag left, GDExtensionInterfaceClassdbGetClassTag right)
    {
        return left._method != right._method;
    }
}
