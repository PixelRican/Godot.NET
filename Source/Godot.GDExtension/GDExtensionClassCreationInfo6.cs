/**************************************************************************/
/*  GDExtensionClassCreationInfo6.cs                                      */
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

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassCreationInfo6
{
    public GDExtensionBool is_virtual;
    public GDExtensionBool is_abstract;
    public GDExtensionBool is_exposed;
    public GDExtensionBool is_runtime;
    public unsafe GDExtensionConstStringPtr icon_path;
    public unsafe GDExtensionClassSet set_func;
    public unsafe GDExtensionClassGet get_func;
    public unsafe GDExtensionClassGetPropertyList get_property_list_func;
    public unsafe GDExtensionClassFreePropertyList2 free_property_list_func;
    public unsafe GDExtensionClassPropertyCanRevert property_can_revert_func;
    public unsafe GDExtensionClassPropertyGetRevert property_get_revert_func;
    public unsafe GDExtensionClassValidateProperty validate_property_func;
    public unsafe GDExtensionClassNotification2 notification_func;
    public unsafe GDExtensionClassToString to_string_func;
    public unsafe GDExtensionClassReference reference_func;
    public unsafe GDExtensionClassUnreference unreference_func;
    /// <summary>
    /// Class constructor. Required unless the class is virtual or abstract.
    /// </summary>
    public unsafe GDExtensionClassCreateInstance3 create_instance_func;
    /// <summary>
    /// Destructor; mandatory.
    /// </summary>
    public unsafe GDExtensionClassFreeInstance free_instance_func;
    public unsafe GDExtensionClassRecreateInstance recreate_instance_func;
    /// <summary>
    /// Queries a virtual function by name and returns a callback to invoke the requested virtual function.
    /// </summary>
    public unsafe GDExtensionClassGetVirtual2 get_virtual_func;
    /// <summary>
    /// Paired with `call_virtual_with_data_func`, this is an alternative to `get_virtual_func` for extensions that<br/>
    /// need or benefit from extra data when calling virtual functions.<br/>
    /// Returns user data that will be passed to `call_virtual_with_data_func`.<br/>
    /// Returning `NULL` from this function signals to Godot that the virtual function is not overridden.<br/>
    /// Data returned from this function should be managed by the extension and must be valid until the extension is deinitialized.<br/>
    /// You should supply either `get_virtual_func`, or `get_virtual_call_data_func` with `call_virtual_with_data_func`.
    /// </summary>
    public unsafe GDExtensionClassGetVirtualCallData2 get_virtual_call_data_func;
    /// <summary>
    /// Used to call virtual functions when `get_virtual_call_data_func` is not null.
    /// </summary>
    public unsafe GDExtensionClassCallVirtualWithData call_virtual_with_data_func;
    /// <summary>
    /// Per-class user data, later accessible in instance bindings.
    /// </summary>
    public unsafe void* class_userdata;
}
