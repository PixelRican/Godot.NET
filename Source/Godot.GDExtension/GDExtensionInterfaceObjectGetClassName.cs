/**************************************************************************/
/*  GDExtensionInterfaceObjectGetClassName.cs                             */
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
/// Gets the class name of an Object.
/// If the GDExtension wraps the Godot object in an abstraction specific to its class, this is the
/// function that should be used to determine which wrapper to use.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceObjectGetClassName : IEquatable<GDExtensionInterfaceObjectGetClassName>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionClassLibraryPtr, GDExtensionUninitializedStringNamePtr, GDExtensionBool> _method;

    public GDExtensionInterfaceObjectGetClassName(delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionClassLibraryPtr, GDExtensionUninitializedStringNamePtr, GDExtensionBool> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionClassLibraryPtr, GDExtensionUninitializedStringNamePtr, GDExtensionBool> Method
    {
        get => _method;
    }

    /// <param name="pObject">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="rClassName">
    /// A pointer to a String to receive the class name.
    /// </param>
    /// <returns>
    /// true if successful in getting the class name; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionBool Invoke(GDExtensionConstObjectPtr pObject, GDExtensionClassLibraryPtr pLibrary, GDExtensionUninitializedStringNamePtr rClassName)
    {
        return _method(pObject, pLibrary, rClassName);
    }

    public bool Equals(GDExtensionInterfaceObjectGetClassName other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceObjectGetClassName other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceObjectGetClassName left, GDExtensionInterfaceObjectGetClassName right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceObjectGetClassName left, GDExtensionInterfaceObjectGetClassName right)
    {
        return left._method != right._method;
    }
}
