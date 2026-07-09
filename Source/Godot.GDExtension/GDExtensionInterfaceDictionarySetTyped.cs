/**************************************************************************/
/*  GDExtensionInterfaceDictionarySetTyped.cs                             */
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.GDExtension;

/// <summary>
/// Makes a Dictionary into a typed Dictionary.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GDExtensionInterfaceDictionarySetTyped : IEquatable<GDExtensionInterfaceDictionarySetTyped>
{
    private readonly delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void> _method;

    public GDExtensionInterfaceDictionarySetTyped(delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void> method)
    {
        _method = method;
    }

    public delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void> Method
    {
        get => _method;
    }

    /// <param name="pSelf">
    /// A pointer to the Dictionary.
    /// </param>
    /// <param name="pKeyType">
    /// The type of Variant the Dictionary key will store.
    /// </param>
    /// <param name="pKeyClassName">
    /// A pointer to a StringName with the name of the object (if p_key_type is GDEXTENSION_VARIANT_TYPE_OBJECT).
    /// </param>
    /// <param name="pKeyScript">
    /// A pointer to a Script object (if p_key_type is GDEXTENSION_VARIANT_TYPE_OBJECT and the base class is extended by a script).
    /// </param>
    /// <param name="pValueType">
    /// The type of Variant the Dictionary value will store.
    /// </param>
    /// <param name="pValueClassName">
    /// A pointer to a StringName with the name of the object (if p_value_type is GDEXTENSION_VARIANT_TYPE_OBJECT).
    /// </param>
    /// <param name="pValueScript">
    /// A pointer to a Script object (if p_value_type is GDEXTENSION_VARIANT_TYPE_OBJECT and the base class is extended by a script).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(GDExtensionTypePtr pSelf, GDExtensionVariantType pKeyType, GDExtensionConstStringNamePtr pKeyClassName, GDExtensionConstVariantPtr pKeyScript, GDExtensionVariantType pValueType, GDExtensionConstStringNamePtr pValueClassName, GDExtensionConstVariantPtr pValueScript)
    {
        _method(pSelf, pKeyType, pKeyClassName, pKeyScript, pValueType, pValueClassName, pValueScript);
    }

    public bool Equals(GDExtensionInterfaceDictionarySetTyped other)
    {
        return _method == other._method;
    }

    public override bool Equals(object? obj)
    {
        return obj is GDExtensionInterfaceDictionarySetTyped other && _method == other._method;
    }

    public override int GetHashCode()
    {
        return new nint(_method).GetHashCode();
    }

    public static bool operator ==(GDExtensionInterfaceDictionarySetTyped left, GDExtensionInterfaceDictionarySetTyped right)
    {
        return left._method == right._method;
    }

    public static bool operator !=(GDExtensionInterfaceDictionarySetTyped left, GDExtensionInterfaceDictionarySetTyped right)
    {
        return left._method != right._method;
    }
}
