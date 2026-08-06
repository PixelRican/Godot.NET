/**************************************************************************/
/*  GDExtensionVariant.cs                                                 */
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

namespace Godot.Interop;

[StructLayout(LayoutKind.Explicit)]
public readonly unsafe struct GDExtensionVariant
{
    [FieldOffset(0)] private readonly GDExtensionVariantType _type;
    [FieldOffset(8)] private readonly DataUnion _data;

    [StructLayout(LayoutKind.Explicit)]
    private struct DataUnion
    {
        [FieldOffset(0)] public bool Bool;
        [FieldOffset(0)] public long Int;
        [FieldOffset(0)] public double Float;
        [FieldOffset(0)] public Transform2D* Transform2D;
        [FieldOffset(0)] public Aabb* Aabb;
        [FieldOffset(0)] public Basis* Basis;
        [FieldOffset(0)] public Transform3D* Transform3D;
        [FieldOffset(0)] public Projection* Projection;
        [FieldOffset(0)] public void* PackedArray;
        [FieldOffset(0)] public void* Ptr;
        [FieldOffset(0)] public MemUnion Mem;
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct MemUnion
    {
        [FieldOffset(0)] public GDExtensionStringName StringName;
        [FieldOffset(0)] public GDExtensionString String;
        [FieldOffset(0)] public Vector4 Vector4;
        [FieldOffset(0)] public Vector4I Vector4I;
        [FieldOffset(0)] public Vector3 Vector3;
        [FieldOffset(0)] public Vector3I Vector3I;
        [FieldOffset(0)] public Vector2 Vector2;
        [FieldOffset(0)] public Vector2I Vector2I;
        [FieldOffset(0)] public Rect2 Rect2;
        [FieldOffset(0)] public Rect2I Rect2I;
        [FieldOffset(0)] public Plane Plane;
        [FieldOffset(0)] public Quaternion Quaternion;
        [FieldOffset(0)] public Color Color;
        // [FieldOffset(0)] public GDExtensionNodePath NodePath;
        // [FieldOffset(0)] public Rid Rid;
        // [FieldOffset(0)] public GDExtensionObjectData ObjData;
        // [FieldOffset(0)] public GDExtensionCallable Callable;
        // [FieldOffset(0)] public GDExtensionSignal Signal;
        // [FieldOffset(0)] public GDExtensionDictionary Dictionary;
        // [FieldOffset(0)] public GDExtensionArray Array;
    }
}
