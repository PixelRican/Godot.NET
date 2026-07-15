/**************************************************************************/
/*  GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod.cs     */
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
/// Registers a virtual method on an extension class in ClassDB, that can be implemented by scripts or other extensions.
/// Provided struct can be safely freed once the function returns.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod : IEquatable<GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassVirtualMethodInfo*, void> _method;

    public GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod(delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassVirtualMethodInfo*, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassVirtualMethodInfo*, void> Method
    {
        get => _method;
    }

    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_method_info">
    /// A pointer to a GDExtensionClassMethodInfo struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionClassVirtualMethodInfo* p_method_info)
    {
        _method(p_library, p_class_name, p_method_info);
    }

    public bool Equals(GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod((delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassVirtualMethodInfo*, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod left, GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod left, GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod right)
    {
        return left._method != right._method;
    }
}
