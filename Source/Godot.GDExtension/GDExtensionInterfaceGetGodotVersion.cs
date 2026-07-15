/**************************************************************************/
/*  GDExtensionInterfaceGetGodotVersion.cs                                */
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
/// Gets the Godot version that the GDExtension was loaded into.
/// </summary>
[Obsolete("Deprecated since Godot 4.5. Use get_godot_version2 instead.")]
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceGetGodotVersion : IEquatable<GDExtensionInterfaceGetGodotVersion>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void> _method;

    public GDExtensionInterfaceGetGodotVersion(delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void> Method
    {
        get => _method;
    }

    /// <param name="r_godot_version">
    /// A pointer to the structure to write the version information into.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionGodotVersion* r_godot_version)
    {
        _method(r_godot_version);
    }

    public bool Equals(GDExtensionInterfaceGetGodotVersion other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceGetGodotVersion other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceGetGodotVersion(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceGetGodotVersion((delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceGetGodotVersion left, GDExtensionInterfaceGetGodotVersion right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceGetGodotVersion left, GDExtensionInterfaceGetGodotVersion right)
    {
        return left._method != right._method;
    }
}
