/**************************************************************************/
/*  GDExtensionGodotVersion2.cs                                           */
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
public unsafe struct GDExtensionGodotVersion2
{
    public uint Major;
    public uint Minor;
    public uint Patch;
    /// <summary>
    /// Full version encoded as hexadecimal with one byte (2 hex digits) per number (e.g. for "3.1.12" it would be 0x03010C)
    /// </summary>
    public uint Hex;
    /// <summary>
    /// (e.g. "stable", "beta", "rc1", "rc2")
    /// </summary>
    public byte* Status;
    /// <summary>
    /// (e.g. "custom_build")
    /// </summary>
    public byte* Build;
    /// <summary>
    /// Full Git commit hash.
    /// </summary>
    public byte* Hash;
    /// <summary>
    /// Git commit date UNIX timestamp in seconds, or 0 if unavailable.
    /// </summary>
    public ulong Timestamp;
    /// <summary>
    /// (e.g. "Godot v3.1.4.stable.official.mono")
    /// </summary>
    public byte* String;
}
