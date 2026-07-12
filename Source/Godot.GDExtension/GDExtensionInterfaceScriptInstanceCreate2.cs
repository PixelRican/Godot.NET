/**************************************************************************/
/*  GDExtensionInterfaceScriptInstanceCreate2.cs                          */
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
/// Creates a script instance that contains the given info and instance data.
/// </summary>
[Obsolete("Deprecated since Godot 4.3. Use script_instance_create3 instead.")]
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceScriptInstanceCreate2 : IEquatable<GDExtensionInterfaceScriptInstanceCreate2>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> _method;

    public GDExtensionInterfaceScriptInstanceCreate2(delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> Method
    {
        get => _method;
    }

    /// <param name="pInfo">
    /// A pointer to a GDExtensionScriptInstanceInfo2 struct.
    /// </param>
    /// <param name="pInstanceData">
    /// A pointer to a data representing the script instance in the GDExtension. This will be passed to all the function pointers on p_info.
    /// </param>
    /// <returns>
    /// A pointer to a ScriptInstanceExtension object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionScriptInstancePtr Invoke(GDExtensionScriptInstanceInfo2* pInfo, GDExtensionScriptInstanceDataPtr pInstanceData)
    {
        return _method(pInfo, pInstanceData);
    }

    public bool Equals(GDExtensionInterfaceScriptInstanceCreate2 other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceScriptInstanceCreate2 other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceScriptInstanceCreate2(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceScriptInstanceCreate2((delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceScriptInstanceCreate2 left, GDExtensionInterfaceScriptInstanceCreate2 right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceScriptInstanceCreate2 left, GDExtensionInterfaceScriptInstanceCreate2 right)
    {
        return left._method != right._method;
    }
}
