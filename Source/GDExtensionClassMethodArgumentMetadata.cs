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

internal enum GDExtensionClassMethodArgumentMetadata
{
    GDEXTENSION_METHOD_ARGUMENT_METADATA_NONE = 0,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_INT8 = 1,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_INT16 = 2,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_INT32 = 3,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_INT64 = 4,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_UINT8 = 5,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_UINT16 = 6,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_UINT32 = 7,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_UINT64 = 8,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_REAL_IS_FLOAT = 9,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_REAL_IS_DOUBLE = 10,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_CHAR16 = 11,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_INT_IS_CHAR32 = 12,
    GDEXTENSION_METHOD_ARGUMENT_METADATA_OBJECT_IS_REQUIRED = 13,
}
