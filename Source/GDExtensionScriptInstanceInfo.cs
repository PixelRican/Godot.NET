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

[Obsolete("Deprecated since Godot 4.2. Use GDExtensionScriptInstanceInfo3 instead.")]
[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionScriptInstanceInfo
{
    public GDExtensionScriptInstanceSet set_func;
    public GDExtensionScriptInstanceGet get_func;
    public GDExtensionScriptInstanceGetPropertyList get_property_list_func;
    public GDExtensionScriptInstanceFreePropertyList free_property_list_func;
    public GDExtensionScriptInstancePropertyCanRevert property_can_revert_func;
    public GDExtensionScriptInstancePropertyGetRevert property_get_revert_func;
    public GDExtensionScriptInstanceGetOwner get_owner_func;
    public GDExtensionScriptInstanceGetPropertyState get_property_state_func;
    public GDExtensionScriptInstanceGetMethodList get_method_list_func;
    public GDExtensionScriptInstanceFreeMethodList free_method_list_func;
    public GDExtensionScriptInstanceGetPropertyType get_property_type_func;
    public GDExtensionScriptInstanceHasMethod has_method_func;
    public GDExtensionScriptInstanceCall call_func;
    public GDExtensionScriptInstanceNotification notification_func;
    public GDExtensionScriptInstanceToString to_string_func;
    public GDExtensionScriptInstanceRefCountIncremented refcount_incremented_func;
    public GDExtensionScriptInstanceRefCountDecremented refcount_decremented_func;
    public GDExtensionScriptInstanceGetScript get_script_func;
    public GDExtensionScriptInstanceIsPlaceholder is_placeholder_func;
    public GDExtensionScriptInstanceSet set_fallback_func;
    public GDExtensionScriptInstanceGet get_fallback_func;
    public GDExtensionScriptInstanceGetLanguage get_language_func;
    public GDExtensionScriptInstanceFree free_func;
}
