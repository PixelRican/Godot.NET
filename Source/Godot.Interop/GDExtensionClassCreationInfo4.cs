/**************************************************************************/
/*  GDExtensionClassCreationInfo4.cs                                      */
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

namespace Godot.Interop;

[Obsolete("Deprecated since Godot 4.5. Use GDExtensionClassCreationInfo6 instead.")]
[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassCreationInfo4
{
    public bool IsVirtual;
    public bool IsAbstract;
    public bool IsExposed;
    public bool IsRuntime;
    public unsafe GDExtensionString* IconPath;
    public unsafe delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant*, bool> SetFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant*, bool> GetFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, uint*, GDExtensionPropertyInfo*> GetPropertyListFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, GDExtensionPropertyInfo*, uint, void> FreePropertyListFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, bool> PropertyCanRevertFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant*, bool> PropertyGetRevertFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, GDExtensionPropertyInfo*, bool> ValidatePropertyFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, int, bool, void> NotificationFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, bool*, GDExtensionString*, void> ToStringFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, void> ReferenceFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, void> UnreferenceFunc;
    /// <summary>
    /// Class constructor. Required unless the class is virtual or abstract.
    /// </summary>
    public unsafe delegate* unmanaged[Cdecl]<void*, bool, void*> CreateInstanceFunc;
    /// <summary>
    /// Destructor; mandatory.
    /// </summary>
    public unsafe delegate* unmanaged[Cdecl]<void*, void*, void> FreeInstanceFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, void*, void*> RecreateInstanceFunc;
    /// <summary>
    /// Queries a virtual function by name and returns a callback to invoke the requested virtual function.
    /// </summary>
    public unsafe delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, uint, delegate* unmanaged[Cdecl]<void*, void**, void*, void>> GetVirtualFunc;
    /// <summary>
    /// Paired with `CallVirtualWithDataFunc`, this is an alternative to `GetVirtualFunc` for extensions that<br/>
    /// need or benefit from extra data when calling virtual functions.<br/>
    /// Returns user data that will be passed to `CallVirtualWithDataFunc`.<br/>
    /// Returning `null` from this function signals to Godot that the virtual function is not overridden.<br/>
    /// Data returned from this function should be managed by the extension and must be valid until the extension is deinitialized.<br/>
    /// You should supply either `GetVirtualFunc`, or `GetVirtualCallDataFunc` with `CallVirtualWithDataFunc`.
    /// </summary>
    public unsafe delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, uint, void*> GetVirtualCallDataFunc;
    /// <summary>
    /// Used to call virtual functions when `GetVirtualCallDataFunc` is not null.
    /// </summary>
    public unsafe delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, void*, void**, void*, void> CallVirtualWithDataFunc;
    /// <summary>
    /// Per-class user data, later accessible in instance bindings.
    /// </summary>
    public unsafe void* ClassUserData;
}
