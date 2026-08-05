/**************************************************************************/
/*  GDExtensionCallableCustomInfo2.cs                                     */
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

/// <summary>
/// Only `CallFunc` and `Token` are strictly required, however, `ObjectId` should be passed if its not a static method.<br/>
/// <br/>
/// `Token` should point to an address that uniquely identifies the GDExtension (for example, the<br/>
/// `GDExtensionClassLibraryPtr` passed to the entry symbol function.<br/>
/// <br/>
/// `HashFunc`, `EqualFunc`, and `LessThanFunc` are optional. If not provided both `CallFunc` and<br/>
/// `CallableUserData` together are used as the identity of the callable for hashing and comparison purposes.<br/>
/// <br/>
/// The hash returned by `HashFunc` is cached, `HashFunc` will not be called more than once per callable.<br/>
/// <br/>
/// `IsValidFunc` is necessary if the validity of the callable can change before destruction.<br/>
/// <br/>
/// `FreeFunc` is necessary if `CallableUserData` needs to be cleaned up when the callable is freed.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionCallableCustomInfo2
{
    public unsafe void* CallableUserData;
    public unsafe void* Token;
    public ulong ObjectId;
    public unsafe delegate* unmanaged[Cdecl]<void*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> CallFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, bool> IsValidFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, void> FreeFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, uint> HashFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, void*, bool> EqualFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, void*, bool> LessThanFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, bool*, GDExtensionString*, void> ToStringFunc;
    public unsafe delegate* unmanaged[Cdecl]<void*, bool*, long> GetArgumentCountFunc;
}
