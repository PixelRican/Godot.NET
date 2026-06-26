/**************************************************************************/
/*  GDExtensionClassCreationInfo5.cs                                      */
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

[Obsolete("Deprecated since Godot 4.7. Use GDExtensionClassCreationInfo6 instead.")]
[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassCreationInfo5
{
    public GDExtensionBool IsVirtual;
    public GDExtensionBool IsAbstract;
    public GDExtensionBool IsExposed;
    public GDExtensionBool IsRuntime;
    public GDExtensionConstStringPtr IconPath;
    public GDExtensionClassSet SetFunc;
    public GDExtensionClassGet GetFunc;
    public GDExtensionClassGetPropertyList GetPropertyListFunc;
    public GDExtensionClassFreePropertyList2 FreePropertyListFunc;
    public GDExtensionClassPropertyCanRevert PropertyCanRevertFunc;
    public GDExtensionClassPropertyGetRevert PropertyGetRevertFunc;
    public GDExtensionClassValidateProperty ValidatePropertyFunc;
    public GDExtensionClassNotification2 NotificationFunc;
    public GDExtensionClassToString ToStringFunc;
    public GDExtensionClassReference ReferenceFunc;
    public GDExtensionClassUnreference UnreferenceFunc;
    /// <summary>
    /// Class constructor. Required unless the class is virtual or abstract.
    /// </summary>
    public GDExtensionClassCreateInstance2 CreateInstanceFunc;
    /// <summary>
    /// Destructor; mandatory.
    /// </summary>
    public GDExtensionClassFreeInstance FreeInstanceFunc;
    public GDExtensionClassRecreateInstance RecreateInstanceFunc;
    /// <summary>
    /// Queries a virtual function by name and returns a callback to invoke the requested virtual function.
    /// </summary>
    public GDExtensionClassGetVirtual2 GetVirtualFunc;
    /// <summary>
    /// Paired with `call_virtual_with_data_func`, this is an alternative to `get_virtual_func` for extensions that
    /// need or benefit from extra data when calling virtual functions.
    /// Returns user data that will be passed to `call_virtual_with_data_func`.
    /// Returning `null` from this function signals to Godot that the virtual function is not overridden.
    /// Data returned from this function should be managed by the extension and must be valid until the extension is deinitialized.
    /// You should supply either `get_virtual_func`, or `get_virtual_call_data_func` with `call_virtual_with_data_func`.
    /// </summary>
    public GDExtensionClassGetVirtualCallData2 GetVirtualCallDataFunc;
    /// <summary>
    /// Used to call virtual functions when `get_virtual_call_data_func` is not null.
    /// </summary>
    public GDExtensionClassCallVirtualWithData CallVirtualWithDataFunc;
    /// <summary>
    /// Per-class user data, later accessible in instance bindings.
    /// </summary>
    public unsafe void* ClassUserdata;
}
