/**************************************************************************/
/*  GDExtensionInitializationFunction.cs                                  */
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
/// Each GDExtension should define a C function that matches the signature of GDExtensionInitializationFunction,
/// and export it so that it can be loaded via dlopen() or equivalent for the given platform.
/// 
/// For example:
/// 
///   GDExtensionBool my_extension_init(GDExtensionInterfaceGetProcAddress p_get_proc_address, GDExtensionClassLibraryPtr p_library, GDExtensionInitialization *r_initialization);
/// 
/// This function's name must be specified as the 'entry_symbol' in the .gdextension file.
/// 
/// This makes it the entry point of the GDExtension and will be called on initialization.
/// 
/// The GDExtension can then modify the r_initialization structure, setting the minimum initialization level,
/// and providing pointers to functions that will be called at various stages of initialization/shutdown.
/// 
/// The rest of the GDExtension's interface to Godot consists of function pointers that can be loaded
/// by calling p_get_proc_address("...") with the name of the function.
/// 
/// For example:
/// 
///   GDExtensionInterfaceGetGodotVersion get_godot_version = (GDExtensionInterfaceGetGodotVersion)p_get_proc_address("get_godot_version");
/// 
/// (Note that snippet may cause "cast between incompatible function types" on some compilers, you can
/// silence this by adding an intermediary `void*` cast.)
/// 
/// You can then call it like a normal function:
/// 
///   GDExtensionGodotVersion godot_version;
///   get_godot_version(&godot_version);
///   printf("Godot v%d.%d.%d\n", godot_version.major, godot_version.minor, godot_version.patch);
/// 
/// All of these interface functions are described below, together with the name that's used to load it,
/// and the function pointer typedef that shows its signature.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInitializationFunction : IEquatable<GDExtensionInitializationFunction>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionInterfaceGetProcAddress, GDExtensionClassLibraryPtr, GDExtensionInitialization*, GDExtensionBool> _method;

    public GDExtensionInitializationFunction(delegate* unmanaged[Cdecl]<GDExtensionInterfaceGetProcAddress, GDExtensionClassLibraryPtr, GDExtensionInitialization*, GDExtensionBool> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionInterfaceGetProcAddress, GDExtensionClassLibraryPtr, GDExtensionInitialization*, GDExtensionBool> Method
    {
        get => _method;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public GDExtensionBool Invoke(GDExtensionInterfaceGetProcAddress p_get_proc_address, GDExtensionClassLibraryPtr p_library, GDExtensionInitialization* r_initialization)
    {
        return _method(p_get_proc_address, p_library, r_initialization);
    }

    public bool Equals(GDExtensionInitializationFunction other)
    {
        return _method == other._method;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GDExtensionInitializationFunction other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInitializationFunction left, GDExtensionInitializationFunction right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInitializationFunction left, GDExtensionInitializationFunction right)
    {
        return left._method != right._method;
    }
}
