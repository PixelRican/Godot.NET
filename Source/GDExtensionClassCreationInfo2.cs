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

[Obsolete("Deprecated since Godot 4.3. Use GDExtensionClassCreationInfo4 instead.")]
[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassCreationInfo2
{
    public GDExtensionBool IsVirtual;
    public GDExtensionBool IsAbstract;
    public GDExtensionBool IsExposed;
    public GDExtensionClassSet SetFunc;
    public GDExtensionClassGet GetFunc;
    public GDExtensionClassGetPropertyList GetPropertyListFunc;
    public GDExtensionClassFreePropertyList FreePropertyListFunc;
    public GDExtensionClassPropertyCanRevert PropertyCanRevertFunc;
    public GDExtensionClassPropertyGetRevert PropertyGetRevertFunc;
    public GDExtensionClassValidateProperty ValidatePropertyFunc;
    public GDExtensionClassNotification2 NotificationFunc;
    public GDExtensionClassToString ToStringFunc;
    public GDExtensionClassReference ReferenceFunc;
    public GDExtensionClassUnreference UnreferenceFunc;
    public GDExtensionClassCreateInstance CreateInstanceFunc;
    public GDExtensionClassFreeInstance FreeInstanceFunc;
    public GDExtensionClassRecreateInstance RecreateInstanceFunc;
    public GDExtensionClassGetVirtual GetVirtualFunc;
    public GDExtensionClassGetVirtualCallData GetVirtualCallDataFunc;
    public GDExtensionClassCallVirtualWithData CallVirtualWithDataFunc;
    public GDExtensionClassGetRID GetRidFunc;
    public unsafe void* ClassUserdata;
}
