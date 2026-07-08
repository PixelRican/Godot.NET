/**************************************************************************/
/*  GDExtensionClassMethodInfo.cs                                         */
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

namespace GDExtension;

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassMethodInfo
{
    public GDExtensionStringNamePtr Name;
    public unsafe void* MethodUserdata;
    public GDExtensionClassMethodCall CallFunc;
    public GDExtensionClassMethodPtrCall PtrcallFunc;
    /// <summary>
    /// Bitfield of `GDExtensionClassMethodFlags`.
    /// </summary>
    public uint MethodFlags;
    /// <summary>
    /// If `has_return_value` is false, `return_value_info` and `return_value_metadata` are ignored.
    /// 
    /// @todo Consider dropping `has_return_value` and making the other two properties match `GDExtensionMethodInfo` and `GDExtensionClassVirtualMethod` for consistency in future version of this struct.
    /// </summary>
    public GDExtensionBool HasReturnValue;
    public unsafe GDExtensionPropertyInfo* ReturnValueInfo;
    public GDExtensionClassMethodArgumentMetadata ReturnValueMetadata;
    /// <summary>
    /// Arguments: `arguments_info` and `arguments_metadata` are array of size `argument_count`.
    /// Name and hint information for the argument can be omitted in release builds. Class name should always be present if it applies.
    /// 
    /// @todo Consider renaming `arguments_info` to `arguments` for consistency in future version of this struct.
    /// </summary>
    public uint ArgumentCount;
    public unsafe GDExtensionPropertyInfo* ArgumentsInfo;
    public unsafe GDExtensionClassMethodArgumentMetadata* ArgumentsMetadata;
    /// <summary>
    /// Default arguments: `default_arguments` is an array of size `default_argument_count`.
    /// </summary>
    public uint DefaultArgumentCount;
    public unsafe GDExtensionVariantPtr* DefaultArguments;
}
