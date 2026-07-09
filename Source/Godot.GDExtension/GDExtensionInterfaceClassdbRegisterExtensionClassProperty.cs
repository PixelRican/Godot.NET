/**************************************************************************/
/*  GDExtensionInterfaceClassdbRegisterExtensionClassProperty.cs          */
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
/// Registers a property on an extension class in the ClassDB.
/// Provided struct can be safely freed once the function returns.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceClassdbRegisterExtensionClassProperty : IEquatable<GDExtensionInterfaceClassdbRegisterExtensionClassProperty>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, void> _method;

    public GDExtensionInterfaceClassdbRegisterExtensionClassProperty(delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, void> Method
    {
        get => _method;
    }

    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pInfo">
    /// A pointer to a GDExtensionPropertyInfo struct.
    /// </param>
    /// <param name="pSetter">
    /// A pointer to a StringName with the name of the setter method.
    /// </param>
    /// <param name="pGetter">
    /// A pointer to a StringName with the name of the getter method.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionPropertyInfo* pInfo, GDExtensionConstStringNamePtr pSetter, GDExtensionConstStringNamePtr pGetter)
    {
        _method(pLibrary, pClassName, pInfo, pSetter, pGetter);
    }

    public bool Equals(GDExtensionInterfaceClassdbRegisterExtensionClassProperty other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceClassdbRegisterExtensionClassProperty other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceClassdbRegisterExtensionClassProperty left, GDExtensionInterfaceClassdbRegisterExtensionClassProperty right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceClassdbRegisterExtensionClassProperty left, GDExtensionInterfaceClassdbRegisterExtensionClassProperty right)
    {
        return left._method != right._method;
    }
}
