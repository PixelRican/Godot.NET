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

[Obsolete("Deprecated since Godot 4.2. Use GDExtensionClassCreationInfo4 instead.")]
[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassCreationInfo
{
    public GDExtensionBool is_virtual;
    public GDExtensionBool is_abstract;
    public GDExtensionClassSet set_func;
    public GDExtensionClassGet get_func;
    public GDExtensionClassGetPropertyList get_property_list_func;
    public GDExtensionClassFreePropertyList free_property_list_func;
    public GDExtensionClassPropertyCanRevert property_can_revert_func;
    public GDExtensionClassPropertyGetRevert property_get_revert_func;
    public GDExtensionClassNotification notification_func;
    public GDExtensionClassToString to_string_func;
    public GDExtensionClassReference reference_func;
    public GDExtensionClassUnreference unreference_func;
    public GDExtensionClassCreateInstance create_instance_func;
    public GDExtensionClassFreeInstance free_instance_func;
    public GDExtensionClassGetVirtual get_virtual_func;
    public GDExtensionClassGetRID get_rid_func;
    public unsafe void* class_userdata;
}
