/**************************************************************************/
/*  GDExtensionInterfacePlaceholderScriptInstanceUpdate.cs                */
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
/// Updates a placeholder script instance with the given properties and values.
/// The passed in placeholder must be an instance of PlaceHolderScriptInstance
/// such as the one returned by placeholder_script_instance_create().
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfacePlaceholderScriptInstanceUpdate : IEquatable<GDExtensionInterfacePlaceholderScriptInstanceUpdate>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionScriptInstancePtr, GDExtensionConstTypePtr, GDExtensionConstTypePtr, void> _method;

    public GDExtensionInterfacePlaceholderScriptInstanceUpdate(delegate* unmanaged[Cdecl]<GDExtensionScriptInstancePtr, GDExtensionConstTypePtr, GDExtensionConstTypePtr, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionScriptInstancePtr, GDExtensionConstTypePtr, GDExtensionConstTypePtr, void> Method => _method;

    /// <param name="p_placeholder">
    /// A pointer to a PlaceHolderScriptInstance.
    /// </param>
    /// <param name="p_properties">
    /// A pointer to an Array of Dictionary representing PropertyInfo.
    /// </param>
    /// <param name="p_values">
    /// A pointer to a Dictionary mapping StringName to Variant values.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionScriptInstancePtr p_placeholder, GDExtensionConstTypePtr p_properties, GDExtensionConstTypePtr p_values)
    {
        _method(p_placeholder, p_properties, p_values);
    }

    public bool Equals(GDExtensionInterfacePlaceholderScriptInstanceUpdate other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfacePlaceholderScriptInstanceUpdate other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfacePlaceholderScriptInstanceUpdate(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfacePlaceholderScriptInstanceUpdate((delegate* unmanaged[Cdecl]<GDExtensionScriptInstancePtr, GDExtensionConstTypePtr, GDExtensionConstTypePtr, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfacePlaceholderScriptInstanceUpdate left, GDExtensionInterfacePlaceholderScriptInstanceUpdate right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfacePlaceholderScriptInstanceUpdate left, GDExtensionInterfacePlaceholderScriptInstanceUpdate right)
    {
        return left._method != right._method;
    }
}
