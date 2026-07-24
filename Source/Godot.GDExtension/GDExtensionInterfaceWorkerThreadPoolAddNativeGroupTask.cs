/**************************************************************************/
/*  GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask.cs             */
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
/// Adds a group task to an instance of WorkerThreadPool.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask : IEquatable<GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolGroupTask, void*, int, int, GDExtensionBool, GDExtensionConstStringPtr, long> _method;

    public GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask(delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolGroupTask, void*, int, int, GDExtensionBool, GDExtensionConstStringPtr, long> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolGroupTask, void*, int, int, GDExtensionBool, GDExtensionConstStringPtr, long> Method
    {
        get => _method;
    }

    /// <param name="p_instance">
    /// A pointer to a WorkerThreadPool object.
    /// </param>
    /// <param name="p_func">
    /// A pointer to a function to run in the thread pool.
    /// </param>
    /// <param name="p_userdata">
    /// A pointer to arbitrary data which will be passed to p_func.
    /// </param>
    /// <param name="p_elements">
    /// The number of element needed in the group.
    /// </param>
    /// <param name="p_tasks">
    /// The number of tasks needed in the group.
    /// </param>
    /// <param name="p_high_priority">
    /// Whether or not this is a high priority task.
    /// </param>
    /// <param name="p_description">
    /// A pointer to a String with the task description.
    /// </param>
    /// <returns>
    /// The task group ID.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long Invoke(GDExtensionObjectPtr p_instance, GDExtensionWorkerThreadPoolGroupTask p_func, void* p_userdata, int p_elements, int p_tasks, GDExtensionBool p_high_priority, GDExtensionConstStringPtr p_description)
    {
        return _method(p_instance, p_func, p_userdata, p_elements, p_tasks, p_high_priority, p_description);
    }

    public bool Equals(GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static explicit operator GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask(GDExtensionInterfaceFunctionPtr function)
    {
        return new GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask((delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolGroupTask, void*, int, int, GDExtensionBool, GDExtensionConstStringPtr, long>)function.Method);
    }

    public static bool operator ==(GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask left, GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask left, GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask right)
    {
        return left._method != right._method;
    }
}
