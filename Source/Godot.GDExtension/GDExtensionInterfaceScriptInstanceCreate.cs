/**************************************************************************/
/*  GDExtensionInterfaceScriptInstanceCreate.cs                           */
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
/// Creates a script instance that contains the given info and instance data.
/// </summary>
[Obsolete("Deprecated since Godot 4.2. Use script_instance_create3 instead.")]
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceScriptInstanceCreate : IEquatable<GDExtensionInterfaceScriptInstanceCreate>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> _method;

    public GDExtensionInterfaceScriptInstanceCreate(delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> Method => _method;

    /// <param name="p_info">
    /// A pointer to a GDExtensionScriptInstanceInfo struct.
    /// </param>
    /// <param name="p_instance_data">
    /// A pointer to a data representing the script instance in the GDExtension. This will be passed to all the function pointers on p_info.
    /// </param>
    /// <returns>
    /// A pointer to a ScriptInstanceExtension object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionScriptInstancePtr Invoke(GDExtensionScriptInstanceInfo* p_info, GDExtensionScriptInstanceDataPtr p_instance_data)
    {
        return _method(p_info, p_instance_data);
    }

    public bool Equals(GDExtensionInterfaceScriptInstanceCreate other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceScriptInstanceCreate other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceScriptInstanceCreate(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceScriptInstanceCreate((delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceScriptInstanceCreate left, GDExtensionInterfaceScriptInstanceCreate right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceScriptInstanceCreate left, GDExtensionInterfaceScriptInstanceCreate right)
    {
        return left._method != right._method;
    }
}
