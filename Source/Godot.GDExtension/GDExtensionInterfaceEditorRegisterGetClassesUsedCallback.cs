/**************************************************************************/
/*  GDExtensionInterfaceEditorRegisterGetClassesUsedCallback.cs           */
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
/// Registers a callback that Godot can call to get the list of all classes (from ClassDB) that may be used by the calling GDExtension.
/// This is used by the editor to generate a build profile (in "Tools" > "Engine Compilation Configuration Editor..." > "Detect from project"),
/// in order to recompile Godot with only the classes used.
/// In the provided callback, the GDExtension should provide the list of classes that _may_ be used statically, thus the time of invocation shouldn't matter.
/// If a GDExtension doesn't register a callback, Godot will assume that it could be using any classes.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceEditorRegisterGetClassesUsedCallback : IEquatable<GDExtensionInterfaceEditorRegisterGetClassesUsedCallback>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionEditorGetClassesUsedCallback, void> _method;

    public GDExtensionInterfaceEditorRegisterGetClassesUsedCallback(delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionEditorGetClassesUsedCallback, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionEditorGetClassesUsedCallback, void> Method
    {
        get => _method;
    }

    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pCallback">
    /// The callback to retrieve the list of classes used.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionClassLibraryPtr pLibrary, GDExtensionEditorGetClassesUsedCallback pCallback)
    {
        _method(pLibrary, pCallback);
    }

    public bool Equals(GDExtensionInterfaceEditorRegisterGetClassesUsedCallback other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceEditorRegisterGetClassesUsedCallback other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceEditorRegisterGetClassesUsedCallback(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceEditorRegisterGetClassesUsedCallback((delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionEditorGetClassesUsedCallback, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceEditorRegisterGetClassesUsedCallback left, GDExtensionInterfaceEditorRegisterGetClassesUsedCallback right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceEditorRegisterGetClassesUsedCallback left, GDExtensionInterfaceEditorRegisterGetClassesUsedCallback right)
    {
        return left._method != right._method;
    }
}
