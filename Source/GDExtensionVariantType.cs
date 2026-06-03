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

namespace Godot.NET;

internal enum GDExtensionVariantType
{
    GDEXTENSION_VARIANT_TYPE_NIL = 0,
    GDEXTENSION_VARIANT_TYPE_BOOL = 1,
    GDEXTENSION_VARIANT_TYPE_INT = 2,
    GDEXTENSION_VARIANT_TYPE_FLOAT = 3,
    GDEXTENSION_VARIANT_TYPE_STRING = 4,
    GDEXTENSION_VARIANT_TYPE_VECTOR2 = 5,
    GDEXTENSION_VARIANT_TYPE_VECTOR2I = 6,
    GDEXTENSION_VARIANT_TYPE_RECT2 = 7,
    GDEXTENSION_VARIANT_TYPE_RECT2I = 8,
    GDEXTENSION_VARIANT_TYPE_VECTOR3 = 9,
    GDEXTENSION_VARIANT_TYPE_VECTOR3I = 10,
    GDEXTENSION_VARIANT_TYPE_TRANSFORM2D = 11,
    GDEXTENSION_VARIANT_TYPE_VECTOR4 = 12,
    GDEXTENSION_VARIANT_TYPE_VECTOR4I = 13,
    GDEXTENSION_VARIANT_TYPE_PLANE = 14,
    GDEXTENSION_VARIANT_TYPE_QUATERNION = 15,
    GDEXTENSION_VARIANT_TYPE_AABB = 16,
    GDEXTENSION_VARIANT_TYPE_BASIS = 17,
    GDEXTENSION_VARIANT_TYPE_TRANSFORM3D = 18,
    GDEXTENSION_VARIANT_TYPE_PROJECTION = 19,
    GDEXTENSION_VARIANT_TYPE_COLOR = 20,
    GDEXTENSION_VARIANT_TYPE_STRING_NAME = 21,
    GDEXTENSION_VARIANT_TYPE_NODE_PATH = 22,
    GDEXTENSION_VARIANT_TYPE_RID = 23,
    GDEXTENSION_VARIANT_TYPE_OBJECT = 24,
    GDEXTENSION_VARIANT_TYPE_CALLABLE = 25,
    GDEXTENSION_VARIANT_TYPE_SIGNAL = 26,
    GDEXTENSION_VARIANT_TYPE_DICTIONARY = 27,
    GDEXTENSION_VARIANT_TYPE_ARRAY = 28,
    GDEXTENSION_VARIANT_TYPE_PACKED_BYTE_ARRAY = 29,
    GDEXTENSION_VARIANT_TYPE_PACKED_INT32_ARRAY = 30,
    GDEXTENSION_VARIANT_TYPE_PACKED_INT64_ARRAY = 31,
    GDEXTENSION_VARIANT_TYPE_PACKED_FLOAT32_ARRAY = 32,
    GDEXTENSION_VARIANT_TYPE_PACKED_FLOAT64_ARRAY = 33,
    GDEXTENSION_VARIANT_TYPE_PACKED_STRING_ARRAY = 34,
    GDEXTENSION_VARIANT_TYPE_PACKED_VECTOR2_ARRAY = 35,
    GDEXTENSION_VARIANT_TYPE_PACKED_VECTOR3_ARRAY = 36,
    GDEXTENSION_VARIANT_TYPE_PACKED_COLOR_ARRAY = 37,
    GDEXTENSION_VARIANT_TYPE_PACKED_VECTOR4_ARRAY = 38,
    GDEXTENSION_VARIANT_TYPE_VARIANT_MAX = 39,
}
