/**************************************************************************/
/*  GDExtensionInterfaceWorkerThreadPoolAddNativeTask.cs                  */
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.GDExtension;

/// <summary>
/// Adds a task to an instance of WorkerThreadPool.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceWorkerThreadPoolAddNativeTask : IEquatable<GDExtensionInterfaceWorkerThreadPoolAddNativeTask>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolTask, void*, GDExtensionBool, GDExtensionConstStringPtr, long> _method;

    public GDExtensionInterfaceWorkerThreadPoolAddNativeTask(delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolTask, void*, GDExtensionBool, GDExtensionConstStringPtr, long> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolTask, void*, GDExtensionBool, GDExtensionConstStringPtr, long> Method => _method;

    /// <param name="p_instance">
    /// A pointer to a WorkerThreadPool object.
    /// </param>
    /// <param name="p_func">
    /// A pointer to a function to run in the thread pool.
    /// </param>
    /// <param name="p_userdata">
    /// A pointer to arbitrary data which will be passed to p_func.
    /// </param>
    /// <param name="p_high_priority">
    /// Whether or not this is a high priority task.
    /// </param>
    /// <param name="p_description">
    /// A pointer to a String with the task description.
    /// </param>
    /// <returns>
    /// The task ID.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long Invoke(GDExtensionObjectPtr p_instance, GDExtensionWorkerThreadPoolTask p_func, void* p_userdata, GDExtensionBool p_high_priority, GDExtensionConstStringPtr p_description)
    {
        return _method(p_instance, p_func, p_userdata, p_high_priority, p_description);
    }

    public bool Equals(GDExtensionInterfaceWorkerThreadPoolAddNativeTask other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceWorkerThreadPoolAddNativeTask other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceWorkerThreadPoolAddNativeTask(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceWorkerThreadPoolAddNativeTask((delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolTask, void*, GDExtensionBool, GDExtensionConstStringPtr, long>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceWorkerThreadPoolAddNativeTask left, GDExtensionInterfaceWorkerThreadPoolAddNativeTask right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceWorkerThreadPoolAddNativeTask left, GDExtensionInterfaceWorkerThreadPoolAddNativeTask right)
    {
        return left._method != right._method;
    }
}
