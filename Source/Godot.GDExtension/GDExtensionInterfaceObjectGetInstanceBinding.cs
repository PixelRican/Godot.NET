/**************************************************************************/
/*  GDExtensionInterfaceObjectGetInstanceBinding.cs                       */
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
/// Gets a pointer representing an Object's instance binding.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceObjectGetInstanceBinding : IEquatable<GDExtensionInterfaceObjectGetInstanceBinding>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, GDExtensionInstanceBindingCallbacks*, void*> _method;

    public GDExtensionInterfaceObjectGetInstanceBinding(delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, GDExtensionInstanceBindingCallbacks*, void*> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, GDExtensionInstanceBindingCallbacks*, void*> Method
    {
        get => _method;
    }

    /// <param name="p_o">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_token">
    /// A token the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_callbacks">
    /// A pointer to a GDExtensionInstanceBindingCallbacks struct.
    /// </param>
    /// <returns>
    /// A pointer to the instance binding.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* Invoke(GDExtensionObjectPtr p_o, void* p_token, GDExtensionInstanceBindingCallbacks* p_callbacks)
    {
        return _method(p_o, p_token, p_callbacks);
    }

    public bool Equals(GDExtensionInterfaceObjectGetInstanceBinding other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceObjectGetInstanceBinding other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceObjectGetInstanceBinding(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceObjectGetInstanceBinding((delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, GDExtensionInstanceBindingCallbacks*, void*>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceObjectGetInstanceBinding left, GDExtensionInterfaceObjectGetInstanceBinding right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceObjectGetInstanceBinding left, GDExtensionInterfaceObjectGetInstanceBinding right)
    {
        return left._method != right._method;
    }
}
