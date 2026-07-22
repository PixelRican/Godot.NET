/**************************************************************************/
/*  UnmanagedVariant.cs                                                   */
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

using System.Runtime.InteropServices;

namespace Godot.InteropServices;

[StructLayout(LayoutKind.Explicit)]
public struct UnmanagedVariant
{
    [FieldOffset(0)] public int Type;
    [FieldOffset(8)] public UnmanagedVariantData Data;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct UnmanagedVariantData
{
    [FieldOffset(0)] public byte Bool;
    [FieldOffset(0)] public long Int;
    [FieldOffset(0)] public double Float;
    [FieldOffset(0)] public void* Transform2D;
    [FieldOffset(0)] public void* Aabb;
    [FieldOffset(0)] public void* Basis;
    [FieldOffset(0)] public void* Transform3D;
    [FieldOffset(0)] public void* Projection;
    [FieldOffset(0)] public void* PackedArray;
    [FieldOffset(0)] public void* Ptr;
    [FieldOffset(0)] public UnmanagedVariantMem Mem;
}

[StructLayout(LayoutKind.Explicit, Size = sizeof(real_t) * 4)]
public struct UnmanagedVariantMem;
