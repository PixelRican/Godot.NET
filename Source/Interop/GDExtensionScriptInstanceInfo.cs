/**************************************************************************/
/*  GDExtensionScriptInstanceInfo.cs                                      */
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
/*              This file is generated. Edits will be lost.               */
/**************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace Godot.Interop;

[Obsolete("Deprecated since Godot 4.2. Use `GDExtensionScriptInstanceInfo3` instead.")]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct GDExtensionScriptInstanceInfo
{
    public delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant*, bool> SetFunc;
    public delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant*, bool> GetFunc;
    public delegate* unmanaged[Cdecl]<void*, uint*, GDExtensionPropertyInfo*> GetPropertyListFunc;
    public delegate* unmanaged[Cdecl]<void*, GDExtensionPropertyInfo*, void> FreePropertyListFunc;
    public delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, bool> PropertyCanRevertFunc;
    public delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant*, bool> PropertyGetRevertFunc;
    public delegate* unmanaged[Cdecl]<void*, void*> GetOwnerFunc;
    public delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<GDExtensionStringName*, GDExtensionVariant*, void*, void>, void*, void> GetPropertyStateFunc;
    public delegate* unmanaged[Cdecl]<void*, uint*, GDExtensionMethodInfo*> GetMethodListFunc;
    public delegate* unmanaged[Cdecl]<void*, GDExtensionMethodInfo*, void> FreeMethodListFunc;
    public delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, bool*, GDExtensionVariantType> GetPropertyTypeFunc;
    public delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, bool> HasMethodFunc;
    public delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> CallFunc;
    public delegate* unmanaged[Cdecl]<void*, int, void> NotificationFunc;
    public delegate* unmanaged[Cdecl]<void*, bool*, GDExtensionString*, void> ToStringFunc;
    public delegate* unmanaged[Cdecl]<void*, void> RefCountIncrementedFunc;
    public delegate* unmanaged[Cdecl]<void*, bool> RefCountDecrementedFunc;
    public delegate* unmanaged[Cdecl]<void*, void*> GetScriptFunc;
    public delegate* unmanaged[Cdecl]<void*, bool> IsPlaceholderFunc;
    public delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant*, bool> SetFallbackFunc;
    public delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant*, bool> GetFallbackFunc;
    public delegate* unmanaged[Cdecl]<void*, void*> GetLanguageFunc;
    public delegate* unmanaged[Cdecl]<void*, void> FreeFunc;
}
