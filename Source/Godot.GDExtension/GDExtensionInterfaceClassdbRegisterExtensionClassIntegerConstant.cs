/**************************************************************************/
/*  GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant.cs   */
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
/// Registers an integer constant on an extension class in the ClassDB.
/// Note about registering bitfield values (if p_is_bitfield is true): even though p_constant_value is signed, language bindings are
/// advised to treat bitfields as uint64_t, since this is generally clearer and can prevent mistakes like using -1 for setting all bits.
/// Language APIs should thus provide an abstraction that registers bitfields (uint64_t) separately from regular constants (int64_t).
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant : IEquatable<GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionBool, void> _method;

    public GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant(delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionBool, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionBool, void> Method
    {
        get => _method;
    }

    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_enum_name">
    /// A pointer to a StringName with the enum name.
    /// </param>
    /// <param name="p_constant_name">
    /// A pointer to a StringName with the constant name.
    /// </param>
    /// <param name="p_constant_value">
    /// The constant value.
    /// </param>
    /// <param name="p_is_bitfield">
    /// Whether or not this constant is part of a bitfield.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstStringNamePtr p_enum_name, GDExtensionConstStringNamePtr p_constant_name, GDExtensionInt p_constant_value, GDExtensionBool p_is_bitfield)
    {
        _method(p_library, p_class_name, p_enum_name, p_constant_name, p_constant_value, p_is_bitfield);
    }

    public bool Equals(GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant((delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionBool, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant left, GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant left, GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant right)
    {
        return left._method != right._method;
    }
}
