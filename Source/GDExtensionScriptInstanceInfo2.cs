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

[Obsolete("Deprecated since Godot 4.3. Use GDExtensionScriptInstanceInfo3 instead.")]
[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionScriptInstanceInfo2
{
    public unsafe GDExtensionScriptInstanceSet set_func;
    public unsafe GDExtensionScriptInstanceGet get_func;
    public unsafe GDExtensionScriptInstanceGetPropertyList get_property_list_func;
    public unsafe GDExtensionScriptInstanceFreePropertyList free_property_list_func;
    public unsafe GDExtensionScriptInstanceGetClassCategory get_class_category_func;
    public unsafe GDExtensionScriptInstancePropertyCanRevert property_can_revert_func;
    public unsafe GDExtensionScriptInstancePropertyGetRevert property_get_revert_func;
    public unsafe GDExtensionScriptInstanceGetOwner get_owner_func;
    public unsafe GDExtensionScriptInstanceGetPropertyState get_property_state_func;
    public unsafe GDExtensionScriptInstanceGetMethodList get_method_list_func;
    public unsafe GDExtensionScriptInstanceFreeMethodList free_method_list_func;
    public unsafe GDExtensionScriptInstanceGetPropertyType get_property_type_func;
    public unsafe GDExtensionScriptInstanceValidateProperty validate_property_func;
    public unsafe GDExtensionScriptInstanceHasMethod has_method_func;
    public unsafe GDExtensionScriptInstanceCall call_func;
    public unsafe GDExtensionScriptInstanceNotification2 notification_func;
    public unsafe GDExtensionScriptInstanceToString to_string_func;
    public unsafe GDExtensionScriptInstanceRefCountIncremented refcount_incremented_func;
    public unsafe GDExtensionScriptInstanceRefCountDecremented refcount_decremented_func;
    public unsafe GDExtensionScriptInstanceGetScript get_script_func;
    public unsafe GDExtensionScriptInstanceIsPlaceholder is_placeholder_func;
    public unsafe GDExtensionScriptInstanceSet set_fallback_func;
    public unsafe GDExtensionScriptInstanceGet get_fallback_func;
    public unsafe GDExtensionScriptInstanceGetLanguage get_language_func;
    public unsafe GDExtensionScriptInstanceFree free_func;
}
