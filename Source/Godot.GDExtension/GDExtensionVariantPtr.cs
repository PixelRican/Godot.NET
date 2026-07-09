/**************************************************************************/
/*  GDExtensionVariantPtr.cs                                              */
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

namespace GDExtension;

/// <summary>
/// In this API there are multiple functions which expect the caller to pass a pointer
/// on return value as parameter.
/// In order to make it clear if the caller should initialize the return value or not
/// we have two flavor of types:
/// - `GDExtensionXXXPtr` for pointer on an initialized value
/// - `GDExtensionUninitializedXXXPtr` for pointer on uninitialized value
/// 
/// Notes:
/// - Not respecting those requirements can seems harmless, but will lead to unexpected
/// segfault or memory leak (for instance with a specific compiler/OS, or when two
/// native extensions start doing ptrcall on each other).
/// - Initialization must be done with the function pointer returned by `variant_get_ptr_constructor`,
/// zero-initializing the variable should not be considered a valid initialization method here !
/// - Some types have no destructor (see `extension_api.json`'s `has_destructor` field), for
/// them it is always safe to skip the constructor for the return value if you are in a hurry ;-)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionVariantPtr : IEquatable<GDExtensionVariantPtr>
{
    private readonly void* _pointer;

    public GDExtensionVariantPtr(void* pointer)
    {
        _pointer = pointer;
    }

    public void* Pointer
    {
        get => _pointer;
    }

    public bool Equals(GDExtensionVariantPtr other)
    {
        return _pointer == other._pointer;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionVariantPtr other && _pointer == other._pointer;
    }

    public override int GetHashCode()
    {
        return new nint(_pointer).GetHashCode();
    }

    public static bool operator ==(GDExtensionVariantPtr left, GDExtensionVariantPtr right)
    {
        return left._pointer == right._pointer;
    }

    public static bool operator !=(GDExtensionVariantPtr left, GDExtensionVariantPtr right)
    {
        return left._pointer != right._pointer;
    }
}
