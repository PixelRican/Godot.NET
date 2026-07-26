/**************************************************************************/
/*  GDExtensionCallableCustomInfo2.cs                                     */
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

namespace Godot.GDExtension;

/// <summary>
/// Only `call_func` and `token` are strictly required, however, `object_id` should be passed if its not a static method.
/// 
/// `token` should point to an address that uniquely identifies the GDExtension (for example, the
/// `GDExtensionClassLibraryPtr` passed to the entry symbol function.
/// 
/// `hash_func`, `equal_func`, and `less_than_func` are optional. If not provided both `call_func` and
/// `callable_userdata` together are used as the identity of the callable for hashing and comparison purposes.
/// 
/// The hash returned by `hash_func` is cached, `hash_func` will not be called more than once per callable.
/// 
/// `is_valid_func` is necessary if the validity of the callable can change before destruction.
/// 
/// `free_func` is necessary if `callable_userdata` needs to be cleaned up when the callable is freed.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionCallableCustomInfo2
{
    public void* callable_userdata;
    public void* token;
    public GDObjectInstanceID object_id;
    public unsafe GDExtensionCallableCustomCall call_func;
    public unsafe GDExtensionCallableCustomIsValid is_valid_func;
    public unsafe GDExtensionCallableCustomFree free_func;
    public unsafe GDExtensionCallableCustomHash hash_func;
    public unsafe GDExtensionCallableCustomEqual equal_func;
    public unsafe GDExtensionCallableCustomLessThan less_than_func;
    public unsafe GDExtensionCallableCustomToString to_string_func;
    public unsafe GDExtensionCallableCustomGetArgumentCount get_argument_count_func;
}
