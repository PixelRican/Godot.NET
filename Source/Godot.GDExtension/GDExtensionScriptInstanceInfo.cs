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

using System;
using System.Runtime.InteropServices;

namespace Godot.GDExtension;

[Obsolete("Deprecated since Godot 4.2. Use GDExtensionScriptInstanceInfo3 instead.")]
[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionScriptInstanceInfo
{
    public unsafe GDExtensionScriptInstanceSet SetFunc;
    public unsafe GDExtensionScriptInstanceGet GetFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyList GetPropertyListFunc;
    public unsafe GDExtensionScriptInstanceFreePropertyList FreePropertyListFunc;
    public unsafe GDExtensionScriptInstancePropertyCanRevert PropertyCanRevertFunc;
    public unsafe GDExtensionScriptInstancePropertyGetRevert PropertyGetRevertFunc;
    public unsafe GDExtensionScriptInstanceGetOwner GetOwnerFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyState GetPropertyStateFunc;
    public unsafe GDExtensionScriptInstanceGetMethodList GetMethodListFunc;
    public unsafe GDExtensionScriptInstanceFreeMethodList FreeMethodListFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyType GetPropertyTypeFunc;
    public unsafe GDExtensionScriptInstanceHasMethod HasMethodFunc;
    public unsafe GDExtensionScriptInstanceCall CallFunc;
    public unsafe GDExtensionScriptInstanceNotification NotificationFunc;
    public unsafe GDExtensionScriptInstanceToString ToStringFunc;
    public unsafe GDExtensionScriptInstanceRefCountIncremented RefcountIncrementedFunc;
    public unsafe GDExtensionScriptInstanceRefCountDecremented RefcountDecrementedFunc;
    public unsafe GDExtensionScriptInstanceGetScript GetScriptFunc;
    public unsafe GDExtensionScriptInstanceIsPlaceholder IsPlaceholderFunc;
    public unsafe GDExtensionScriptInstanceSet SetFallbackFunc;
    public unsafe GDExtensionScriptInstanceGet GetFallbackFunc;
    public unsafe GDExtensionScriptInstanceGetLanguage GetLanguageFunc;
    public unsafe GDExtensionScriptInstanceFree FreeFunc;
}
