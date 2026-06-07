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
using System.Runtime.InteropServices;

namespace Godot.NET;

[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionConstStringNamePtr : IEquatable<GDExtensionConstStringNamePtr>
{
    private readonly void* _pointer;

    public GDExtensionConstStringNamePtr(void* pointer)
    {
        _pointer = pointer;
    }

    public void* Pointer
    {
        get => _pointer;
    }

    public bool Equals(GDExtensionConstStringNamePtr other)
    {
        return _pointer == other._pointer;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionConstStringNamePtr other && _pointer == other._pointer;
    }

    public override int GetHashCode()
    {
        return new nint(_pointer).GetHashCode();
    }

    public static explicit operator GDExtensionConstStringNamePtr(void* pointer)
    {
        return new GDExtensionConstStringNamePtr(pointer);
    }

    public static explicit operator void*(GDExtensionConstStringNamePtr handle)
    {
        return handle._pointer;
    }

    public static implicit operator GDExtensionConstStringNamePtr(GDExtensionStringNamePtr parent)
    {
        return new GDExtensionConstStringNamePtr(parent.Pointer);
    }

    public static bool operator ==(GDExtensionConstStringNamePtr left, GDExtensionConstStringNamePtr right)
    {
        return left._pointer == right._pointer;
    }

    public static bool operator !=(GDExtensionConstStringNamePtr left, GDExtensionConstStringNamePtr right)
    {
        return left._pointer != right._pointer;
    }
}
