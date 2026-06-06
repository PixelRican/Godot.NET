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
public readonly struct GDExtensionClassLibraryPtr : IEquatable<GDExtensionClassLibraryPtr>
{
    private readonly nint _handle;

    public GDExtensionClassLibraryPtr(nint value)
    {
        _handle = value;
    }

    public unsafe GDExtensionClassLibraryPtr(void* value)
    {
        _handle = (nint)value;
    }

    public bool IsAllocated
    {
        get => _handle != 0;
    }

    public nint ToIntPtr()
    {
        return _handle;
    }

    public unsafe void* ToPointer()
    {
        return (void*)_handle;
    }

    public bool Equals(GDExtensionClassLibraryPtr other)
    {
        return _handle == other._handle;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionClassLibraryPtr other && _handle == other._handle;
    }

    public override int GetHashCode()
    {
        return _handle.GetHashCode();
    }

    public static explicit operator GDExtensionClassLibraryPtr(nint value)
    {
        return new GDExtensionClassLibraryPtr(value);
    }

    public static unsafe explicit operator GDExtensionClassLibraryPtr(void* value)
    {
        return new GDExtensionClassLibraryPtr(value);
    }

    public static explicit operator nint(GDExtensionClassLibraryPtr value)
    {
        return value._handle;
    }

    public static unsafe explicit operator void*(GDExtensionClassLibraryPtr value)
    {
        return (void*)value._handle;
    }

    public static bool operator ==(GDExtensionClassLibraryPtr left, GDExtensionClassLibraryPtr right)
    {
        return left._handle == right._handle;
    }

    public static bool operator !=(GDExtensionClassLibraryPtr left, GDExtensionClassLibraryPtr right)
    {
        return left._handle != right._handle;
    }
}
