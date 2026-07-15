/**************************************************************************/
/*  GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed.cs   */
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
/// Registers an indexed property on an extension class in the ClassDB.
/// Provided struct can be safely freed once the function returns.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed : IEquatable<GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, void> _method;

    public GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed(delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, void> Method
    {
        get => _method;
    }

    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_info">
    /// A pointer to a GDExtensionPropertyInfo struct.
    /// </param>
    /// <param name="p_setter">
    /// A pointer to a StringName with the name of the setter method.
    /// </param>
    /// <param name="p_getter">
    /// A pointer to a StringName with the name of the getter method.
    /// </param>
    /// <param name="p_index">
    /// The index to pass as the first argument to the getter and setter methods.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionPropertyInfo* p_info, GDExtensionConstStringNamePtr p_setter, GDExtensionConstStringNamePtr p_getter, GDExtensionInt p_index)
    {
        _method(p_library, p_class_name, p_info, p_setter, p_getter, p_index);
    }

    public bool Equals(GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed((delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed left, GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed left, GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed right)
    {
        return left._method != right._method;
    }
}
