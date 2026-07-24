/**************************************************************************/
/*  GDExtensionScriptInstanceIsPlaceholder.cs                             */
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

[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionScriptInstanceIsPlaceholder : IEquatable<GDExtensionScriptInstanceIsPlaceholder>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceDataPtr, GDExtensionBool> _method;

    public GDExtensionScriptInstanceIsPlaceholder(delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceDataPtr, GDExtensionBool> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceDataPtr, GDExtensionBool> Method => _method;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionBool Invoke(GDExtensionScriptInstanceDataPtr p_instance)
    {
        return _method(p_instance);
    }

    public bool Equals(GDExtensionScriptInstanceIsPlaceholder other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionScriptInstanceIsPlaceholder other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionScriptInstanceIsPlaceholder left, GDExtensionScriptInstanceIsPlaceholder right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionScriptInstanceIsPlaceholder left, GDExtensionScriptInstanceIsPlaceholder right)
    {
        return left._method != right._method;
    }
}
