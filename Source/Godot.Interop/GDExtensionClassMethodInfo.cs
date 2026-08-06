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

namespace Godot.Interop;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct GDExtensionClassMethodInfo
{
    public GDExtensionStringName* Name;
    public void* MethodUserData;
    public delegate* unmanaged[Cdecl]<void*, void*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> CallFunc;
    public delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void> PtrCallFunc;
    /// <summary>
    /// Bitfield of `GDExtensionClassMethodFlags`.
    /// </summary>
    public GDExtensionClassMethodFlags MethodFlags;
    /// <summary>
    /// If `HasReturnValue` is false, `ReturnValueInfo` and `ReturnValueMetadata` are ignored.<br/>
    /// <br/>
    /// @todo Consider dropping `HasReturnValue` and making the other two properties match `GDExtensionMethodInfo` and `GDExtensionClassVirtualMethod` for consistency in future version of this struct.
    /// </summary>
    public bool HasReturnValue;
    public GDExtensionPropertyInfo* ReturnValueInfo;
    public GDExtensionClassMethodArgumentMetadata ReturnValueMetadata;
    /// <summary>
    /// Arguments: `ArgumentsInfo` and `ArgumentsMetadata` are array of size `ArgumentCount`.<br/>
    /// Name and hint information for the argument can be omitted in release builds. Class name should always be present if it applies.<br/>
    /// <br/>
    /// @todo Consider renaming `ArgumentsInfo` to `Arguments` for consistency in future version of this struct.
    /// </summary>
    public uint ArgumentCount;
    public GDExtensionPropertyInfo* ArgumentsInfo;
    public GDExtensionClassMethodArgumentMetadata* ArgumentsMetadata;
    /// <summary>
    /// Default arguments: `DefaultArguments` is an array of size `DefaultArgumentCount`.
    /// </summary>
    public uint DefaultArgumentCount;
    public GDExtensionVariant** DefaultArguments;
}
