/**************************************************************************/
/*  GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup.cs     */
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
/// Registers a property group on an extension class in the ClassDB.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup : IEquatable<GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void> _method;

    public GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup(delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void> Method
    {
        get => _method;
    }

    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pGroupName">
    /// A pointer to a String with the group name.
    /// </param>
    /// <param name="pPrefix">
    /// A pointer to a String with the prefix used by properties in this group.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionConstStringPtr pGroupName, GDExtensionConstStringPtr pPrefix)
    {
        _method(pLibrary, pClassName, pGroupName, pPrefix);
    }

    public bool Equals(GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup left, GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup left, GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup right)
    {
        return left._method != right._method;
    }
}
