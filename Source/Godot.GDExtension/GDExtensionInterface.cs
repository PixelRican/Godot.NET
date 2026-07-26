/**************************************************************************/
/*  GDExtensionInterface.cs                                               */
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

namespace Godot.GDExtension;

public static unsafe class GDExtensionInterface
{
    private static delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void> s_get_godot_version;
    private static delegate* unmanaged[Cdecl]<GDExtensionGodotVersion2*, void> s_get_godot_version2;
    private static delegate* unmanaged[Cdecl]<nuint, void*> s_mem_alloc;
    private static delegate* unmanaged[Cdecl]<void*, nuint, void*> s_mem_realloc;
    private static delegate* unmanaged[Cdecl]<void*, void> s_mem_free;
    private static delegate* unmanaged[Cdecl]<nuint, GDExtensionBool, void*> s_mem_alloc2;
    private static delegate* unmanaged[Cdecl]<void*, nuint, GDExtensionBool, void*> s_mem_realloc2;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionBool, void> s_mem_free2;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> s_print_error;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> s_print_error_with_message;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> s_print_warning;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> s_print_warning_with_message;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> s_print_script_error;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> s_print_script_error_with_message;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, ulong> s_get_native_struct_size;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr, void> s_variant_new_copy;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, void> s_variant_new_nil;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, void> s_variant_destroy;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> s_variant_call;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> s_variant_call_static;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> s_variant_evaluate;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> s_variant_set;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> s_variant_set_named;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> s_variant_set_keyed;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionInt, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool*, void> s_variant_set_indexed;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> s_variant_get;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> s_variant_get_named;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> s_variant_get_keyed;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool*, void> s_variant_get_indexed;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool> s_variant_iter_init;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool*, GDExtensionBool> s_variant_iter_next;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> s_variant_iter_get;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt> s_variant_hash;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionInt> s_variant_recursive_hash;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool> s_variant_hash_compare;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionBool> s_variant_booleanize;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool, void> s_variant_duplicate;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionStringPtr, void> s_variant_stringify;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantType> s_variant_get_type;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionBool> s_variant_has_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionBool> s_variant_has_member;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool> s_variant_has_key;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDObjectInstanceID> s_variant_get_object_instance_id;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedStringPtr, void> s_variant_get_type_name;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionVariantType> s_variant_get_type_by_name;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool> s_variant_can_convert;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool> s_variant_can_convert_strict;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantFromTypeConstructorFunc> s_get_variant_from_type_constructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionTypeFromVariantConstructorFunc> s_get_variant_to_type_constructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantGetInternalPtrFunc> s_variant_get_ptr_internal_getter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, GDExtensionPtrOperatorEvaluator> s_variant_get_ptr_operator_evaluator;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrBuiltInMethod> s_variant_get_ptr_builtin_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, int, GDExtensionPtrConstructor> s_variant_get_ptr_constructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrDestructor> s_variant_get_ptr_destructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr*, int, GDExtensionCallError*, void> s_variant_construct;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrSetter> s_variant_get_ptr_setter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrGetter> s_variant_get_ptr_getter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedSetter> s_variant_get_ptr_indexed_setter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedGetter> s_variant_get_ptr_indexed_getter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedSetter> s_variant_get_ptr_keyed_setter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedGetter> s_variant_get_ptr_keyed_getter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedChecker> s_variant_get_ptr_keyed_checker;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, void> s_variant_get_constant_value;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrUtilityFunction> s_variant_get_ptr_utility_function;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void> s_string_new_with_latin1_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void> s_string_new_with_utf8_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, void> s_string_new_with_utf16_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, void> s_string_new_with_utf32_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, void> s_string_new_with_wide_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> s_string_new_with_latin1_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> s_string_new_with_utf8_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, GDExtensionInt> s_string_new_with_utf8_chars_and_len2;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void> s_string_new_with_utf16_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, GDExtensionBool, GDExtensionInt> s_string_new_with_utf16_chars_and_len2;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, GDExtensionInt, void> s_string_new_with_utf32_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, GDExtensionInt, void> s_string_new_with_wide_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt> s_string_to_latin1_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt> s_string_to_utf8_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, char*, GDExtensionInt, GDExtensionInt> s_string_to_utf16_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt> s_string_to_utf32_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, void*, GDExtensionInt, GDExtensionInt> s_string_to_wide_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*> s_string_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*> s_string_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionConstStringPtr, void> s_string_operator_plus_eq_string;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint, void> s_string_operator_plus_eq_char;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, byte*, void> s_string_operator_plus_eq_cstr;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, void*, void> s_string_operator_plus_eq_wcstr;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint*, void> s_string_operator_plus_eq_c32str;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, GDExtensionInt> s_string_resize;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionBool, void> s_string_name_new_with_latin1_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, void> s_string_name_new_with_utf8_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionInt, void> s_string_name_new_with_utf8_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, nuint, GDExtensionInt> s_xml_parser_open_buffer;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, ulong, void> s_file_access_store_buffer;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, byte*, ulong, ulong> s_file_access_get_buffer;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*> s_image_ptrw;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*> s_image_ptr;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolGroupTask, void*, int, int, GDExtensionBool, GDExtensionConstStringPtr, long> s_worker_thread_pool_add_native_group_task;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolTask, void*, GDExtensionBool, GDExtensionConstStringPtr, long> s_worker_thread_pool_add_native_task;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, byte*> s_packed_byte_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, byte*> s_packed_byte_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, float*> s_packed_float32_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, float*> s_packed_float32_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, double*> s_packed_float64_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, double*> s_packed_float64_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, int*> s_packed_int32_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, int*> s_packed_int32_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, long*> s_packed_int64_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, long*> s_packed_int64_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionStringPtr> s_packed_string_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionStringPtr> s_packed_string_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packed_vector2_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packed_vector2_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packed_vector3_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packed_vector3_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packed_vector4_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packed_vector4_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packed_color_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packed_color_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionVariantPtr> s_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionVariantPtr> s_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstTypePtr, void> s_array_ref;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void> s_array_set_typed;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr> s_dictionary_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr> s_dictionary_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void> s_dictionary_set_typed;
    private static delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> s_object_method_bind_call;
    private static delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void> s_object_method_bind_ptrcall;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void> s_object_destroy;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> s_global_get_singleton;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, GDExtensionInstanceBindingCallbacks*, void*> s_object_get_instance_binding;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void*, GDExtensionInstanceBindingCallbacks*, void> s_object_set_instance_binding;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void> s_object_free_instance_binding;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionClassInstancePtr, void> s_object_set_instance;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionClassLibraryPtr, GDExtensionUninitializedStringNamePtr, GDExtensionBool> s_object_get_class_name;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, void*, GDExtensionObjectPtr> s_object_cast_to;
    private static delegate* unmanaged[Cdecl]<GDObjectInstanceID, GDExtensionObjectPtr> s_object_get_instance_from_id;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDObjectInstanceID> s_object_get_instance_id;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionConstStringNamePtr, GDExtensionBool> s_object_has_script_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> s_object_call_script_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstRefPtr, GDExtensionObjectPtr> s_ref_get_object;
    private static delegate* unmanaged[Cdecl]<GDExtensionRefPtr, GDExtensionObjectPtr, void> s_ref_set_object;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> s_script_instance_create;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> s_script_instance_create2;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo3*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> s_script_instance_create3;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstancePtr> s_placeholder_script_instance_create;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstancePtr, GDExtensionConstTypePtr, GDExtensionConstTypePtr, void> s_placeholder_script_instance_update;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr> s_object_get_script_instance;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr, void> s_object_set_script_instance;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo*, void> s_callable_custom_create;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo2*, void> s_callable_custom_create2;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, void*, void*> s_callable_custom_get_userdata;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> s_classdb_construct_object;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> s_classdb_construct_object2;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> s_classdb_construct_object3;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionMethodBindPtr> s_classdb_get_method_bind;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void*> s_classdb_get_class_tag;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo*, void> s_classdb_register_extension_class;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo2*, void> s_classdb_register_extension_class2;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo3*, void> s_classdb_register_extension_class3;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo4*, void> s_classdb_register_extension_class4;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo5*, void> s_classdb_register_extension_class5;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo6*, void> s_classdb_register_extension_class6;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassMethodInfo*, void> s_classdb_register_extension_class_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassVirtualMethodInfo*, void> s_classdb_register_extension_class_virtual_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionBool, void> s_classdb_register_extension_class_integer_constant;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, void> s_classdb_register_extension_class_property;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, void> s_classdb_register_extension_class_property_indexed;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void> s_classdb_register_extension_class_property_group;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void> s_classdb_register_extension_class_property_subgroup;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionInt, void> s_classdb_register_extension_class_signal;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, void> s_classdb_unregister_extension_class;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionUninitializedStringPtr, void> s_get_library_path;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void> s_editor_add_plugin;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void> s_editor_remove_plugin;
    private static delegate* unmanaged[Cdecl]<byte*, void> s_editor_help_load_xml_from_utf8_chars;
    private static delegate* unmanaged[Cdecl]<byte*, GDExtensionInt, void> s_editor_help_load_xml_from_utf8_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionEditorGetClassesUsedCallback, void> s_editor_register_get_classes_used_callback;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionMainLoopCallbacks*, void> s_register_main_loop_callbacks;

    /// <summary>
    /// Loads the GDExtensionInterface functions from the specified address loader.
    /// </summary>
    /// <param name="getProcAddress">
    /// The address loader provided by the Godot Engine.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="getProcAddress"/> is <see langword="null"/>.
    /// </exception>
    public static void Initialize(GDExtensionInterfaceGetProcAddress getProcAddress)
    {
        ArgumentNullException.ThrowIfNull(getProcAddress);
        s_get_godot_version = (delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void>)Load(getProcAddress, "get_godot_version"u8);
        s_get_godot_version2 = (delegate* unmanaged[Cdecl]<GDExtensionGodotVersion2*, void>)Load(getProcAddress, "get_godot_version2"u8);
        s_mem_alloc = (delegate* unmanaged[Cdecl]<nuint, void*>)Load(getProcAddress, "mem_alloc"u8);
        s_mem_realloc = (delegate* unmanaged[Cdecl]<void*, nuint, void*>)Load(getProcAddress, "mem_realloc"u8);
        s_mem_free = (delegate* unmanaged[Cdecl]<void*, void>)Load(getProcAddress, "mem_free"u8);
        s_mem_alloc2 = (delegate* unmanaged[Cdecl]<nuint, GDExtensionBool, void*>)Load(getProcAddress, "mem_alloc2"u8);
        s_mem_realloc2 = (delegate* unmanaged[Cdecl]<void*, nuint, GDExtensionBool, void*>)Load(getProcAddress, "mem_realloc2"u8);
        s_mem_free2 = (delegate* unmanaged[Cdecl]<void*, GDExtensionBool, void>)Load(getProcAddress, "mem_free2"u8);
        s_print_error = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_error"u8);
        s_print_error_with_message = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_error_with_message"u8);
        s_print_warning = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_warning"u8);
        s_print_warning_with_message = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_warning_with_message"u8);
        s_print_script_error = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_script_error"u8);
        s_print_script_error_with_message = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_script_error_with_message"u8);
        s_get_native_struct_size = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, ulong>)Load(getProcAddress, "get_native_struct_size"u8);
        s_variant_new_copy = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr, void>)Load(getProcAddress, "variant_new_copy"u8);
        s_variant_new_nil = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, void>)Load(getProcAddress, "variant_new_nil"u8);
        s_variant_destroy = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, void>)Load(getProcAddress, "variant_destroy"u8);
        s_variant_call = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void>)Load(getProcAddress, "variant_call"u8);
        s_variant_call_static = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void>)Load(getProcAddress, "variant_call_static"u8);
        s_variant_evaluate = (delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_evaluate"u8);
        s_variant_set = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_set"u8);
        s_variant_set_named = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_set_named"u8);
        s_variant_set_keyed = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_set_keyed"u8);
        s_variant_set_indexed = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionInt, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool*, void>)Load(getProcAddress, "variant_set_indexed"u8);
        s_variant_get = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_get"u8);
        s_variant_get_named = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_get_named"u8);
        s_variant_get_keyed = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_get_keyed"u8);
        s_variant_get_indexed = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool*, void>)Load(getProcAddress, "variant_get_indexed"u8);
        s_variant_iter_init = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool>)Load(getProcAddress, "variant_iter_init"u8);
        s_variant_iter_next = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool*, GDExtensionBool>)Load(getProcAddress, "variant_iter_next"u8);
        s_variant_iter_get = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_iter_get"u8);
        s_variant_hash = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt>)Load(getProcAddress, "variant_hash"u8);
        s_variant_recursive_hash = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "variant_recursive_hash"u8);
        s_variant_hash_compare = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool>)Load(getProcAddress, "variant_hash_compare"u8);
        s_variant_booleanize = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionBool>)Load(getProcAddress, "variant_booleanize"u8);
        s_variant_duplicate = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool, void>)Load(getProcAddress, "variant_duplicate"u8);
        s_variant_stringify = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionStringPtr, void>)Load(getProcAddress, "variant_stringify"u8);
        s_variant_get_type = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantType>)Load(getProcAddress, "variant_get_type"u8);
        s_variant_has_method = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionBool>)Load(getProcAddress, "variant_has_method"u8);
        s_variant_has_member = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionBool>)Load(getProcAddress, "variant_has_member"u8);
        s_variant_has_key = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool>)Load(getProcAddress, "variant_has_key"u8);
        s_variant_get_object_instance_id = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDObjectInstanceID>)Load(getProcAddress, "variant_get_object_instance_id"u8);
        s_variant_get_type_name = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedStringPtr, void>)Load(getProcAddress, "variant_get_type_name"u8);
        s_variant_get_type_by_name = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionVariantType>)Load(getProcAddress, "variant_get_type_by_name"u8);
        s_variant_can_convert = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool>)Load(getProcAddress, "variant_can_convert"u8);
        s_variant_can_convert_strict = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool>)Load(getProcAddress, "variant_can_convert_strict"u8);
        s_get_variant_from_type_constructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantFromTypeConstructorFunc>)Load(getProcAddress, "get_variant_from_type_constructor"u8);
        s_get_variant_to_type_constructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionTypeFromVariantConstructorFunc>)Load(getProcAddress, "get_variant_to_type_constructor"u8);
        s_variant_get_ptr_internal_getter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantGetInternalPtrFunc>)Load(getProcAddress, "variant_get_ptr_internal_getter"u8);
        s_variant_get_ptr_operator_evaluator = (delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, GDExtensionPtrOperatorEvaluator>)Load(getProcAddress, "variant_get_ptr_operator_evaluator"u8);
        s_variant_get_ptr_builtin_method = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrBuiltInMethod>)Load(getProcAddress, "variant_get_ptr_builtin_method"u8);
        s_variant_get_ptr_constructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, int, GDExtensionPtrConstructor>)Load(getProcAddress, "variant_get_ptr_constructor"u8);
        s_variant_get_ptr_destructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrDestructor>)Load(getProcAddress, "variant_get_ptr_destructor"u8);
        s_variant_construct = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr*, int, GDExtensionCallError*, void>)Load(getProcAddress, "variant_construct"u8);
        s_variant_get_ptr_setter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrSetter>)Load(getProcAddress, "variant_get_ptr_setter"u8);
        s_variant_get_ptr_getter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrGetter>)Load(getProcAddress, "variant_get_ptr_getter"u8);
        s_variant_get_ptr_indexed_setter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedSetter>)Load(getProcAddress, "variant_get_ptr_indexed_setter"u8);
        s_variant_get_ptr_indexed_getter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedGetter>)Load(getProcAddress, "variant_get_ptr_indexed_getter"u8);
        s_variant_get_ptr_keyed_setter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedSetter>)Load(getProcAddress, "variant_get_ptr_keyed_setter"u8);
        s_variant_get_ptr_keyed_getter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedGetter>)Load(getProcAddress, "variant_get_ptr_keyed_getter"u8);
        s_variant_get_ptr_keyed_checker = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedChecker>)Load(getProcAddress, "variant_get_ptr_keyed_checker"u8);
        s_variant_get_constant_value = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, void>)Load(getProcAddress, "variant_get_constant_value"u8);
        s_variant_get_ptr_utility_function = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrUtilityFunction>)Load(getProcAddress, "variant_get_ptr_utility_function"u8);
        s_string_new_with_latin1_chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void>)Load(getProcAddress, "string_new_with_latin1_chars"u8);
        s_string_new_with_utf8_chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void>)Load(getProcAddress, "string_new_with_utf8_chars"u8);
        s_string_new_with_utf16_chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, void>)Load(getProcAddress, "string_new_with_utf16_chars"u8);
        s_string_new_with_utf32_chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, void>)Load(getProcAddress, "string_new_with_utf32_chars"u8);
        s_string_new_with_wide_chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, void>)Load(getProcAddress, "string_new_with_wide_chars"u8);
        s_string_new_with_latin1_chars_and_len = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_latin1_chars_and_len"u8);
        s_string_new_with_utf8_chars_and_len = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_utf8_chars_and_len"u8);
        s_string_new_with_utf8_chars_and_len2 = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_new_with_utf8_chars_and_len2"u8);
        s_string_new_with_utf16_chars_and_len = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_utf16_chars_and_len"u8);
        s_string_new_with_utf16_chars_and_len2 = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, GDExtensionBool, GDExtensionInt>)Load(getProcAddress, "string_new_with_utf16_chars_and_len2"u8);
        s_string_new_with_utf32_chars_and_len = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_utf32_chars_and_len"u8);
        s_string_new_with_wide_chars_and_len = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_wide_chars_and_len"u8);
        s_string_to_latin1_chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_latin1_chars"u8);
        s_string_to_utf8_chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_utf8_chars"u8);
        s_string_to_utf16_chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, char*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_utf16_chars"u8);
        s_string_to_utf32_chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_utf32_chars"u8);
        s_string_to_wide_chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, void*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_wide_chars"u8);
        s_string_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*>)Load(getProcAddress, "string_operator_index"u8);
        s_string_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*>)Load(getProcAddress, "string_operator_index_const"u8);
        s_string_operator_plus_eq_string = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionConstStringPtr, void>)Load(getProcAddress, "string_operator_plus_eq_string"u8);
        s_string_operator_plus_eq_char = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint, void>)Load(getProcAddress, "string_operator_plus_eq_char"u8);
        s_string_operator_plus_eq_cstr = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, byte*, void>)Load(getProcAddress, "string_operator_plus_eq_cstr"u8);
        s_string_operator_plus_eq_wcstr = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, void*, void>)Load(getProcAddress, "string_operator_plus_eq_wcstr"u8);
        s_string_operator_plus_eq_c32str = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint*, void>)Load(getProcAddress, "string_operator_plus_eq_c32str"u8);
        s_string_resize = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_resize"u8);
        s_string_name_new_with_latin1_chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionBool, void>)Load(getProcAddress, "string_name_new_with_latin1_chars"u8);
        s_string_name_new_with_utf8_chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, void>)Load(getProcAddress, "string_name_new_with_utf8_chars"u8);
        s_string_name_new_with_utf8_chars_and_len = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionInt, void>)Load(getProcAddress, "string_name_new_with_utf8_chars_and_len"u8);
        s_xml_parser_open_buffer = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, nuint, GDExtensionInt>)Load(getProcAddress, "xml_parser_open_buffer"u8);
        s_file_access_store_buffer = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, ulong, void>)Load(getProcAddress, "file_access_store_buffer"u8);
        s_file_access_get_buffer = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, byte*, ulong, ulong>)Load(getProcAddress, "file_access_get_buffer"u8);
        s_image_ptrw = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*>)Load(getProcAddress, "image_ptrw"u8);
        s_image_ptr = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*>)Load(getProcAddress, "image_ptr"u8);
        s_worker_thread_pool_add_native_group_task = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolGroupTask, void*, int, int, GDExtensionBool, GDExtensionConstStringPtr, long>)Load(getProcAddress, "worker_thread_pool_add_native_group_task"u8);
        s_worker_thread_pool_add_native_task = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolTask, void*, GDExtensionBool, GDExtensionConstStringPtr, long>)Load(getProcAddress, "worker_thread_pool_add_native_task"u8);
        s_packed_byte_array_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, byte*>)Load(getProcAddress, "packed_byte_array_operator_index"u8);
        s_packed_byte_array_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, byte*>)Load(getProcAddress, "packed_byte_array_operator_index_const"u8);
        s_packed_float32_array_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, float*>)Load(getProcAddress, "packed_float32_array_operator_index"u8);
        s_packed_float32_array_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, float*>)Load(getProcAddress, "packed_float32_array_operator_index_const"u8);
        s_packed_float64_array_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, double*>)Load(getProcAddress, "packed_float64_array_operator_index"u8);
        s_packed_float64_array_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, double*>)Load(getProcAddress, "packed_float64_array_operator_index_const"u8);
        s_packed_int32_array_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, int*>)Load(getProcAddress, "packed_int32_array_operator_index"u8);
        s_packed_int32_array_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, int*>)Load(getProcAddress, "packed_int32_array_operator_index_const"u8);
        s_packed_int64_array_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, long*>)Load(getProcAddress, "packed_int64_array_operator_index"u8);
        s_packed_int64_array_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, long*>)Load(getProcAddress, "packed_int64_array_operator_index_const"u8);
        s_packed_string_array_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionStringPtr>)Load(getProcAddress, "packed_string_array_operator_index"u8);
        s_packed_string_array_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionStringPtr>)Load(getProcAddress, "packed_string_array_operator_index_const"u8);
        s_packed_vector2_array_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector2_array_operator_index"u8);
        s_packed_vector2_array_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector2_array_operator_index_const"u8);
        s_packed_vector3_array_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector3_array_operator_index"u8);
        s_packed_vector3_array_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector3_array_operator_index_const"u8);
        s_packed_vector4_array_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector4_array_operator_index"u8);
        s_packed_vector4_array_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector4_array_operator_index_const"u8);
        s_packed_color_array_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_color_array_operator_index"u8);
        s_packed_color_array_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_color_array_operator_index_const"u8);
        s_array_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionVariantPtr>)Load(getProcAddress, "array_operator_index"u8);
        s_array_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionVariantPtr>)Load(getProcAddress, "array_operator_index_const"u8);
        s_array_ref = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstTypePtr, void>)Load(getProcAddress, "array_ref"u8);
        s_array_set_typed = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void>)Load(getProcAddress, "array_set_typed"u8);
        s_dictionary_operator_index = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr>)Load(getProcAddress, "dictionary_operator_index"u8);
        s_dictionary_operator_index_const = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr>)Load(getProcAddress, "dictionary_operator_index_const"u8);
        s_dictionary_set_typed = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void>)Load(getProcAddress, "dictionary_set_typed"u8);
        s_object_method_bind_call = (delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void>)Load(getProcAddress, "object_method_bind_call"u8);
        s_object_method_bind_ptrcall = (delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void>)Load(getProcAddress, "object_method_bind_ptrcall"u8);
        s_object_destroy = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void>)Load(getProcAddress, "object_destroy"u8);
        s_global_get_singleton = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr>)Load(getProcAddress, "global_get_singleton"u8);
        s_object_get_instance_binding = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, GDExtensionInstanceBindingCallbacks*, void*>)Load(getProcAddress, "object_get_instance_binding"u8);
        s_object_set_instance_binding = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void*, GDExtensionInstanceBindingCallbacks*, void>)Load(getProcAddress, "object_set_instance_binding"u8);
        s_object_free_instance_binding = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void>)Load(getProcAddress, "object_free_instance_binding"u8);
        s_object_set_instance = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionClassInstancePtr, void>)Load(getProcAddress, "object_set_instance"u8);
        s_object_get_class_name = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionClassLibraryPtr, GDExtensionUninitializedStringNamePtr, GDExtensionBool>)Load(getProcAddress, "object_get_class_name"u8);
        s_object_cast_to = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, void*, GDExtensionObjectPtr>)Load(getProcAddress, "object_cast_to"u8);
        s_object_get_instance_from_id = (delegate* unmanaged[Cdecl]<GDObjectInstanceID, GDExtensionObjectPtr>)Load(getProcAddress, "object_get_instance_from_id"u8);
        s_object_get_instance_id = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDObjectInstanceID>)Load(getProcAddress, "object_get_instance_id"u8);
        s_object_has_script_method = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionConstStringNamePtr, GDExtensionBool>)Load(getProcAddress, "object_has_script_method"u8);
        s_object_call_script_method = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void>)Load(getProcAddress, "object_call_script_method"u8);
        s_ref_get_object = (delegate* unmanaged[Cdecl]<GDExtensionConstRefPtr, GDExtensionObjectPtr>)Load(getProcAddress, "ref_get_object"u8);
        s_ref_set_object = (delegate* unmanaged[Cdecl]<GDExtensionRefPtr, GDExtensionObjectPtr, void>)Load(getProcAddress, "ref_set_object"u8);
        s_script_instance_create = (delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr>)Load(getProcAddress, "script_instance_create"u8);
        s_script_instance_create2 = (delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr>)Load(getProcAddress, "script_instance_create2"u8);
        s_script_instance_create3 = (delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo3*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr>)Load(getProcAddress, "script_instance_create3"u8);
        s_placeholder_script_instance_create = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstancePtr>)Load(getProcAddress, "placeholder_script_instance_create"u8);
        s_placeholder_script_instance_update = (delegate* unmanaged[Cdecl]<GDExtensionScriptInstancePtr, GDExtensionConstTypePtr, GDExtensionConstTypePtr, void>)Load(getProcAddress, "placeholder_script_instance_update"u8);
        s_object_get_script_instance = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr>)Load(getProcAddress, "object_get_script_instance"u8);
        s_object_set_script_instance = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr, void>)Load(getProcAddress, "object_set_script_instance"u8);
        s_callable_custom_create = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo*, void>)Load(getProcAddress, "callable_custom_create"u8);
        s_callable_custom_create2 = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo2*, void>)Load(getProcAddress, "callable_custom_create2"u8);
        s_callable_custom_get_userdata = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, void*, void*>)Load(getProcAddress, "callable_custom_get_userdata"u8);
        s_classdb_construct_object = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr>)Load(getProcAddress, "classdb_construct_object"u8);
        s_classdb_construct_object2 = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr>)Load(getProcAddress, "classdb_construct_object2"u8);
        s_classdb_construct_object3 = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr>)Load(getProcAddress, "classdb_construct_object3"u8);
        s_classdb_get_method_bind = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionMethodBindPtr>)Load(getProcAddress, "classdb_get_method_bind"u8);
        s_classdb_get_class_tag = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void*>)Load(getProcAddress, "classdb_get_class_tag"u8);
        s_classdb_register_extension_class = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo*, void>)Load(getProcAddress, "classdb_register_extension_class"u8);
        s_classdb_register_extension_class2 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo2*, void>)Load(getProcAddress, "classdb_register_extension_class2"u8);
        s_classdb_register_extension_class3 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo3*, void>)Load(getProcAddress, "classdb_register_extension_class3"u8);
        s_classdb_register_extension_class4 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo4*, void>)Load(getProcAddress, "classdb_register_extension_class4"u8);
        s_classdb_register_extension_class5 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo5*, void>)Load(getProcAddress, "classdb_register_extension_class5"u8);
        s_classdb_register_extension_class6 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo6*, void>)Load(getProcAddress, "classdb_register_extension_class6"u8);
        s_classdb_register_extension_class_method = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassMethodInfo*, void>)Load(getProcAddress, "classdb_register_extension_class_method"u8);
        s_classdb_register_extension_class_virtual_method = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassVirtualMethodInfo*, void>)Load(getProcAddress, "classdb_register_extension_class_virtual_method"u8);
        s_classdb_register_extension_class_integer_constant = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionBool, void>)Load(getProcAddress, "classdb_register_extension_class_integer_constant"u8);
        s_classdb_register_extension_class_property = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, void>)Load(getProcAddress, "classdb_register_extension_class_property"u8);
        s_classdb_register_extension_class_property_indexed = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, void>)Load(getProcAddress, "classdb_register_extension_class_property_indexed"u8);
        s_classdb_register_extension_class_property_group = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void>)Load(getProcAddress, "classdb_register_extension_class_property_group"u8);
        s_classdb_register_extension_class_property_subgroup = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void>)Load(getProcAddress, "classdb_register_extension_class_property_subgroup"u8);
        s_classdb_register_extension_class_signal = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionInt, void>)Load(getProcAddress, "classdb_register_extension_class_signal"u8);
        s_classdb_unregister_extension_class = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, void>)Load(getProcAddress, "classdb_unregister_extension_class"u8);
        s_get_library_path = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionUninitializedStringPtr, void>)Load(getProcAddress, "get_library_path"u8);
        s_editor_add_plugin = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void>)Load(getProcAddress, "editor_add_plugin"u8);
        s_editor_remove_plugin = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void>)Load(getProcAddress, "editor_remove_plugin"u8);
        s_editor_help_load_xml_from_utf8_chars = (delegate* unmanaged[Cdecl]<byte*, void>)Load(getProcAddress, "editor_help_load_xml_from_utf8_chars"u8);
        s_editor_help_load_xml_from_utf8_chars_and_len = (delegate* unmanaged[Cdecl]<byte*, GDExtensionInt, void>)Load(getProcAddress, "editor_help_load_xml_from_utf8_chars_and_len"u8);
        s_editor_register_get_classes_used_callback = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionEditorGetClassesUsedCallback, void>)Load(getProcAddress, "editor_register_get_classes_used_callback"u8);
        s_register_main_loop_callbacks = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionMainLoopCallbacks*, void>)Load(getProcAddress, "register_main_loop_callbacks"u8);
    }

    /// <summary>
    /// Gets the Godot version that the GDExtension was loaded into.
    /// </summary>
    /// <param name="r_godot_version">
    /// A pointer to the structure to write the version information into.
    /// </param>
    [Obsolete("Deprecated since Godot 4.5. Use get_godot_version2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void get_godot_version(GDExtensionGodotVersion* r_godot_version)
    {
        var function = s_get_godot_version;
        ThrowIfInvalid(function);
        function(r_godot_version);
    }

    /// <summary>
    /// Gets the Godot version that the GDExtension was loaded into.
    /// </summary>
    /// <param name="r_godot_version">
    /// A pointer to the structure to write the version information into.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void get_godot_version2(GDExtensionGodotVersion2* r_godot_version)
    {
        var function = s_get_godot_version2;
        ThrowIfInvalid(function);
        function(r_godot_version);
    }

    /// <summary>
    /// Allocates memory.
    /// </summary>
    /// <param name="p_bytes">
    /// The amount of memory to allocate in bytes.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or NULL if unsuccessful.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.6. Does not allow explicitly requesting padding. Use mem_alloc2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* mem_alloc(nuint p_bytes)
    {
        var function = s_mem_alloc;
        ThrowIfInvalid(function);
        return function(p_bytes);
    }

    /// <summary>
    /// Reallocates memory.
    /// </summary>
    /// <param name="p_ptr">
    /// A pointer to the previously allocated memory.
    /// </param>
    /// <param name="p_bytes">
    /// The number of bytes to resize the memory block to.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or NULL if unsuccessful.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.6. Does not allow explicitly requesting padding. Use mem_realloc2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* mem_realloc(void* p_ptr, nuint p_bytes)
    {
        var function = s_mem_realloc;
        ThrowIfInvalid(function);
        return function(p_ptr, p_bytes);
    }

    /// <summary>
    /// Frees memory.
    /// </summary>
    /// <param name="p_ptr">
    /// A pointer to the previously allocated memory.
    /// </param>
    [Obsolete("Deprecated since Godot 4.6. Does not allow explicitly requesting padding. Use mem_free2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void mem_free(void* p_ptr)
    {
        var function = s_mem_free;
        ThrowIfInvalid(function);
        function(p_ptr);
    }

    /// <summary>
    /// Allocates memory.
    /// </summary>
    /// <param name="p_bytes">
    /// The amount of memory to allocate in bytes.
    /// </param>
    /// <param name="p_pad_align">
    /// If true, the returned memory will have prepadding of at least 8 bytes.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or NULL if unsuccessful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* mem_alloc2(nuint p_bytes, GDExtensionBool p_pad_align)
    {
        var function = s_mem_alloc2;
        ThrowIfInvalid(function);
        return function(p_bytes, p_pad_align);
    }

    /// <summary>
    /// Reallocates memory.
    /// </summary>
    /// <param name="p_ptr">
    /// A pointer to the previously allocated memory.
    /// </param>
    /// <param name="p_bytes">
    /// The number of bytes to resize the memory block to.
    /// </param>
    /// <param name="p_pad_align">
    /// If true, the returned memory will have prepadding of at least 8 bytes.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or NULL if unsuccessful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* mem_realloc2(void* p_ptr, nuint p_bytes, GDExtensionBool p_pad_align)
    {
        var function = s_mem_realloc2;
        ThrowIfInvalid(function);
        return function(p_ptr, p_bytes, p_pad_align);
    }

    /// <summary>
    /// Frees memory.
    /// </summary>
    /// <param name="p_ptr">
    /// A pointer to the previously allocated memory.
    /// </param>
    /// <param name="p_pad_align">
    /// If true, the given memory was allocated with prepadding.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void mem_free2(void* p_ptr, GDExtensionBool p_pad_align)
    {
        var function = s_mem_free2;
        ThrowIfInvalid(function);
        function(p_ptr, p_pad_align);
    }

    /// <summary>
    /// Logs an error to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="p_description">
    /// The code triggering the error.
    /// </param>
    /// <param name="p_function">
    /// The function name where the error occurred.
    /// </param>
    /// <param name="p_file">
    /// The file where the error occurred.
    /// </param>
    /// <param name="p_line">
    /// The line where the error occurred.
    /// </param>
    /// <param name="p_editor_notify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void print_error(byte* p_description, byte* p_function, byte* p_file, int p_line, GDExtensionBool p_editor_notify)
    {
        var function = s_print_error;
        ThrowIfInvalid(function);
        function(p_description, p_function, p_file, p_line, p_editor_notify);
    }

    /// <summary>
    /// Logs an error with a message to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="p_description">
    /// The code triggering the error.
    /// </param>
    /// <param name="p_message">
    /// The message to show along with the error.
    /// </param>
    /// <param name="p_function">
    /// The function name where the error occurred.
    /// </param>
    /// <param name="p_file">
    /// The file where the error occurred.
    /// </param>
    /// <param name="p_line">
    /// The line where the error occurred.
    /// </param>
    /// <param name="p_editor_notify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void print_error_with_message(byte* p_description, byte* p_message, byte* p_function, byte* p_file, int p_line, GDExtensionBool p_editor_notify)
    {
        var function = s_print_error_with_message;
        ThrowIfInvalid(function);
        function(p_description, p_message, p_function, p_file, p_line, p_editor_notify);
    }

    /// <summary>
    /// Logs a warning to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="p_description">
    /// The code triggering the warning.
    /// </param>
    /// <param name="p_function">
    /// The function name where the warning occurred.
    /// </param>
    /// <param name="p_file">
    /// The file where the warning occurred.
    /// </param>
    /// <param name="p_line">
    /// The line where the warning occurred.
    /// </param>
    /// <param name="p_editor_notify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void print_warning(byte* p_description, byte* p_function, byte* p_file, int p_line, GDExtensionBool p_editor_notify)
    {
        var function = s_print_warning;
        ThrowIfInvalid(function);
        function(p_description, p_function, p_file, p_line, p_editor_notify);
    }

    /// <summary>
    /// Logs a warning with a message to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="p_description">
    /// The code triggering the warning.
    /// </param>
    /// <param name="p_message">
    /// The message to show along with the warning.
    /// </param>
    /// <param name="p_function">
    /// The function name where the warning occurred.
    /// </param>
    /// <param name="p_file">
    /// The file where the warning occurred.
    /// </param>
    /// <param name="p_line">
    /// The line where the warning occurred.
    /// </param>
    /// <param name="p_editor_notify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void print_warning_with_message(byte* p_description, byte* p_message, byte* p_function, byte* p_file, int p_line, GDExtensionBool p_editor_notify)
    {
        var function = s_print_warning_with_message;
        ThrowIfInvalid(function);
        function(p_description, p_message, p_function, p_file, p_line, p_editor_notify);
    }

    /// <summary>
    /// Logs a script error to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="p_description">
    /// The code triggering the error.
    /// </param>
    /// <param name="p_function">
    /// The function name where the error occurred.
    /// </param>
    /// <param name="p_file">
    /// The file where the error occurred.
    /// </param>
    /// <param name="p_line">
    /// The line where the error occurred.
    /// </param>
    /// <param name="p_editor_notify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void print_script_error(byte* p_description, byte* p_function, byte* p_file, int p_line, GDExtensionBool p_editor_notify)
    {
        var function = s_print_script_error;
        ThrowIfInvalid(function);
        function(p_description, p_function, p_file, p_line, p_editor_notify);
    }

    /// <summary>
    /// Logs a script error with a message to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="p_description">
    /// The code triggering the error.
    /// </param>
    /// <param name="p_message">
    /// The message to show along with the error.
    /// </param>
    /// <param name="p_function">
    /// The function name where the error occurred.
    /// </param>
    /// <param name="p_file">
    /// The file where the error occurred.
    /// </param>
    /// <param name="p_line">
    /// The line where the error occurred.
    /// </param>
    /// <param name="p_editor_notify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void print_script_error_with_message(byte* p_description, byte* p_message, byte* p_function, byte* p_file, int p_line, GDExtensionBool p_editor_notify)
    {
        var function = s_print_script_error_with_message;
        ThrowIfInvalid(function);
        function(p_description, p_message, p_function, p_file, p_line, p_editor_notify);
    }

    /// <summary>
    /// Gets the size of a native struct (ex. ObjectID) in bytes.
    /// </summary>
    /// <param name="p_name">
    /// A pointer to a StringName identifying the struct name.
    /// </param>
    /// <returns>
    /// The size in bytes.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong get_native_struct_size(GDExtensionConstStringNamePtr p_name)
    {
        var function = s_get_native_struct_size;
        ThrowIfInvalid(function);
        return function(p_name);
    }

    /// <summary>
    /// Copies one Variant into a another.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to the destination Variant.
    /// </param>
    /// <param name="p_src">
    /// A pointer to the source Variant.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_new_copy(GDExtensionUninitializedVariantPtr r_dest, GDExtensionConstVariantPtr p_src)
    {
        var function = s_variant_new_copy;
        ThrowIfInvalid(function);
        function(r_dest, p_src);
    }

    /// <summary>
    /// Creates a new Variant containing nil.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to the destination Variant.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_new_nil(GDExtensionUninitializedVariantPtr r_dest)
    {
        var function = s_variant_new_nil;
        ThrowIfInvalid(function);
        function(r_dest);
    }

    /// <summary>
    /// Destroys a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant to destroy.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_destroy(GDExtensionVariantPtr p_self)
    {
        var function = s_variant_destroy;
        ThrowIfInvalid(function);
        function(p_self);
    }

    /// <summary>
    /// Calls a method on a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_method">
    /// A pointer to a StringName identifying the method.
    /// </param>
    /// <param name="p_args">
    /// A pointer to a C array of Variant.
    /// </param>
    /// <param name="p_argument_count">
    /// The number of arguments.
    /// </param>
    /// <param name="r_return">
    /// A pointer a Variant which will be assigned the return value.
    /// </param>
    /// <param name="r_error">
    /// A pointer the structure which will hold error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_call(GDExtensionVariantPtr p_self, GDExtensionConstStringNamePtr p_method, GDExtensionConstVariantPtr* p_args, GDExtensionInt p_argument_count, GDExtensionUninitializedVariantPtr r_return, GDExtensionCallError* r_error)
    {
        var function = s_variant_call;
        ThrowIfInvalid(function);
        function(p_self, p_method, p_args, p_argument_count, r_return, r_error);
    }

    /// <summary>
    /// Calls a static method on a Variant.
    /// </summary>
    /// <param name="p_type">
    /// The variant type.
    /// </param>
    /// <param name="p_method">
    /// A pointer to a StringName identifying the method.
    /// </param>
    /// <param name="p_args">
    /// A pointer to a C array of Variant.
    /// </param>
    /// <param name="p_argument_count">
    /// The number of arguments.
    /// </param>
    /// <param name="r_return">
    /// A pointer a Variant which will be assigned the return value.
    /// </param>
    /// <param name="r_error">
    /// A pointer the structure which will be updated with error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_call_static(GDExtensionVariantType p_type, GDExtensionConstStringNamePtr p_method, GDExtensionConstVariantPtr* p_args, GDExtensionInt p_argument_count, GDExtensionUninitializedVariantPtr r_return, GDExtensionCallError* r_error)
    {
        var function = s_variant_call_static;
        ThrowIfInvalid(function);
        function(p_type, p_method, p_args, p_argument_count, r_return, r_error);
    }

    /// <summary>
    /// Evaluate an operator on two Variants.
    /// </summary>
    /// <param name="p_op">
    /// The operator to evaluate.
    /// </param>
    /// <param name="p_a">
    /// The first Variant.
    /// </param>
    /// <param name="p_b">
    /// The second Variant.
    /// </param>
    /// <param name="r_return">
    /// A pointer a Variant which will be assigned the return value.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_evaluate(GDExtensionVariantOperator p_op, GDExtensionConstVariantPtr p_a, GDExtensionConstVariantPtr p_b, GDExtensionUninitializedVariantPtr r_return, GDExtensionBool* r_valid)
    {
        var function = s_variant_evaluate;
        ThrowIfInvalid(function);
        function(p_op, p_a, p_b, r_return, r_valid);
    }

    /// <summary>
    /// Sets a key on a Variant to a value.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_key">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <param name="p_value">
    /// A pointer to a Variant representing the value.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_set(GDExtensionVariantPtr p_self, GDExtensionConstVariantPtr p_key, GDExtensionConstVariantPtr p_value, GDExtensionBool* r_valid)
    {
        var function = s_variant_set;
        ThrowIfInvalid(function);
        function(p_self, p_key, p_value, r_valid);
    }

    /// <summary>
    /// Sets a named key on a Variant to a value.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_key">
    /// A pointer to a StringName representing the key.
    /// </param>
    /// <param name="p_value">
    /// A pointer to a Variant representing the value.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_set_named(GDExtensionVariantPtr p_self, GDExtensionConstStringNamePtr p_key, GDExtensionConstVariantPtr p_value, GDExtensionBool* r_valid)
    {
        var function = s_variant_set_named;
        ThrowIfInvalid(function);
        function(p_self, p_key, p_value, r_valid);
    }

    /// <summary>
    /// Sets a keyed property on a Variant to a value.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_key">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <param name="p_value">
    /// A pointer to a Variant representing the value.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_set_keyed(GDExtensionVariantPtr p_self, GDExtensionConstVariantPtr p_key, GDExtensionConstVariantPtr p_value, GDExtensionBool* r_valid)
    {
        var function = s_variant_set_keyed;
        ThrowIfInvalid(function);
        function(p_self, p_key, p_value, r_valid);
    }

    /// <summary>
    /// Sets an index on a Variant to a value.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_index">
    /// The index.
    /// </param>
    /// <param name="p_value">
    /// A pointer to a Variant representing the value.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    /// <param name="r_oob">
    /// A pointer to a boolean which will be set to true if the index is out of bounds.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_set_indexed(GDExtensionVariantPtr p_self, GDExtensionInt p_index, GDExtensionConstVariantPtr p_value, GDExtensionBool* r_valid, GDExtensionBool* r_oob)
    {
        var function = s_variant_set_indexed;
        ThrowIfInvalid(function);
        function(p_self, p_index, p_value, r_valid, r_oob);
    }

    /// <summary>
    /// Gets the value of a key from a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_key">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <param name="r_ret">
    /// A pointer to a Variant which will be assigned the value.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_get(GDExtensionConstVariantPtr p_self, GDExtensionConstVariantPtr p_key, GDExtensionUninitializedVariantPtr r_ret, GDExtensionBool* r_valid)
    {
        var function = s_variant_get;
        ThrowIfInvalid(function);
        function(p_self, p_key, r_ret, r_valid);
    }

    /// <summary>
    /// Gets the value of a named key from a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_key">
    /// A pointer to a StringName representing the key.
    /// </param>
    /// <param name="r_ret">
    /// A pointer to a Variant which will be assigned the value.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_get_named(GDExtensionConstVariantPtr p_self, GDExtensionConstStringNamePtr p_key, GDExtensionUninitializedVariantPtr r_ret, GDExtensionBool* r_valid)
    {
        var function = s_variant_get_named;
        ThrowIfInvalid(function);
        function(p_self, p_key, r_ret, r_valid);
    }

    /// <summary>
    /// Gets the value of a keyed property from a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_key">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <param name="r_ret">
    /// A pointer to a Variant which will be assigned the value.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_get_keyed(GDExtensionConstVariantPtr p_self, GDExtensionConstVariantPtr p_key, GDExtensionUninitializedVariantPtr r_ret, GDExtensionBool* r_valid)
    {
        var function = s_variant_get_keyed;
        ThrowIfInvalid(function);
        function(p_self, p_key, r_ret, r_valid);
    }

    /// <summary>
    /// Gets the value of an index from a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_index">
    /// The index.
    /// </param>
    /// <param name="r_ret">
    /// A pointer to a Variant which will be assigned the value.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    /// <param name="r_oob">
    /// A pointer to a boolean which will be set to true if the index is out of bounds.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_get_indexed(GDExtensionConstVariantPtr p_self, GDExtensionInt p_index, GDExtensionUninitializedVariantPtr r_ret, GDExtensionBool* r_valid, GDExtensionBool* r_oob)
    {
        var function = s_variant_get_indexed;
        ThrowIfInvalid(function);
        function(p_self, p_index, r_ret, r_valid, r_oob);
    }

    /// <summary>
    /// Initializes an iterator over a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="r_iter">
    /// A pointer to a Variant which will be assigned the iterator.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    /// <returns>
    /// true if the operation is valid; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionBool variant_iter_init(GDExtensionConstVariantPtr p_self, GDExtensionUninitializedVariantPtr r_iter, GDExtensionBool* r_valid)
    {
        var function = s_variant_iter_init;
        ThrowIfInvalid(function);
        return function(p_self, r_iter, r_valid);
    }

    /// <summary>
    /// Gets the next value for an iterator over a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="r_iter">
    /// A pointer to a Variant which will be assigned the iterator.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    /// <returns>
    /// true if the operation is valid; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionBool variant_iter_next(GDExtensionConstVariantPtr p_self, GDExtensionVariantPtr r_iter, GDExtensionBool* r_valid)
    {
        var function = s_variant_iter_next;
        ThrowIfInvalid(function);
        return function(p_self, r_iter, r_valid);
    }

    /// <summary>
    /// Gets the next value for an iterator over a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="r_iter">
    /// A pointer to a Variant which will be assigned the iterator.
    /// </param>
    /// <param name="r_ret">
    /// A pointer to a Variant which will be assigned false if the operation is invalid.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_iter_get(GDExtensionConstVariantPtr p_self, GDExtensionVariantPtr r_iter, GDExtensionUninitializedVariantPtr r_ret, GDExtensionBool* r_valid)
    {
        var function = s_variant_iter_get;
        ThrowIfInvalid(function);
        function(p_self, r_iter, r_ret, r_valid);
    }

    /// <summary>
    /// Gets the hash of a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <returns>
    /// The hash value.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt variant_hash(GDExtensionConstVariantPtr p_self)
    {
        var function = s_variant_hash;
        ThrowIfInvalid(function);
        return function(p_self);
    }

    /// <summary>
    /// Gets the recursive hash of a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_recursion_count">
    /// The number of recursive loops so far.
    /// </param>
    /// <returns>
    /// The hash value.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt variant_recursive_hash(GDExtensionConstVariantPtr p_self, GDExtensionInt p_recursion_count)
    {
        var function = s_variant_recursive_hash;
        ThrowIfInvalid(function);
        return function(p_self, p_recursion_count);
    }

    /// <summary>
    /// Compares two Variants by their hash.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_other">
    /// A pointer to the other Variant to compare it to.
    /// </param>
    /// <returns>
    /// The hash value.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionBool variant_hash_compare(GDExtensionConstVariantPtr p_self, GDExtensionConstVariantPtr p_other)
    {
        var function = s_variant_hash_compare;
        ThrowIfInvalid(function);
        return function(p_self, p_other);
    }

    /// <summary>
    /// Converts a Variant to a boolean.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <returns>
    /// The boolean value of the Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionBool variant_booleanize(GDExtensionConstVariantPtr p_self)
    {
        var function = s_variant_booleanize;
        ThrowIfInvalid(function);
        return function(p_self);
    }

    /// <summary>
    /// Duplicates a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="r_ret">
    /// A pointer to a Variant to store the duplicated value.
    /// </param>
    /// <param name="p_deep">
    /// Whether or not to duplicate deeply (when supported by the Variant type).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_duplicate(GDExtensionConstVariantPtr p_self, GDExtensionVariantPtr r_ret, GDExtensionBool p_deep)
    {
        var function = s_variant_duplicate;
        ThrowIfInvalid(function);
        function(p_self, r_ret, p_deep);
    }

    /// <summary>
    /// Converts a Variant to a string.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="r_ret">
    /// A pointer to a String to store the resulting value.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_stringify(GDExtensionConstVariantPtr p_self, GDExtensionStringPtr r_ret)
    {
        var function = s_variant_stringify;
        ThrowIfInvalid(function);
        function(p_self, r_ret);
    }

    /// <summary>
    /// Gets the type of a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <returns>
    /// The variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariantType variant_get_type(GDExtensionConstVariantPtr p_self)
    {
        var function = s_variant_get_type;
        ThrowIfInvalid(function);
        return function(p_self);
    }

    /// <summary>
    /// Checks if a Variant has the given method.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_method">
    /// A pointer to a StringName with the method name.
    /// </param>
    /// <returns>
    /// true if the variant has the given method; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionBool variant_has_method(GDExtensionConstVariantPtr p_self, GDExtensionConstStringNamePtr p_method)
    {
        var function = s_variant_has_method;
        ThrowIfInvalid(function);
        return function(p_self, p_method);
    }

    /// <summary>
    /// Checks if a type of Variant has the given member.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <param name="p_member">
    /// A pointer to a StringName with the member name.
    /// </param>
    /// <returns>
    /// true if the variant has the given method; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionBool variant_has_member(GDExtensionVariantType p_type, GDExtensionConstStringNamePtr p_member)
    {
        var function = s_variant_has_member;
        ThrowIfInvalid(function);
        return function(p_type, p_member);
    }

    /// <summary>
    /// Checks if a Variant has a key.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="p_key">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <param name="r_valid">
    /// A pointer to a boolean which will be set to false if the key doesn't exist.
    /// </param>
    /// <returns>
    /// true if the key exists; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionBool variant_has_key(GDExtensionConstVariantPtr p_self, GDExtensionConstVariantPtr p_key, GDExtensionBool* r_valid)
    {
        var function = s_variant_has_key;
        ThrowIfInvalid(function);
        return function(p_self, p_key, r_valid);
    }

    /// <summary>
    /// Gets the object instance ID from a variant of type GDEXTENSION_VARIANT_TYPE_OBJECT.
    /// If the variant isn't of type GDEXTENSION_VARIANT_TYPE_OBJECT, then zero will be returned.
    /// The instance ID will be returned even if the object is no longer valid - use `object_get_instance_by_id()` to check if the object is still valid.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <returns>
    /// The instance ID for the contained object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDObjectInstanceID variant_get_object_instance_id(GDExtensionConstVariantPtr p_self)
    {
        var function = s_variant_get_object_instance_id;
        ThrowIfInvalid(function);
        return function(p_self);
    }

    /// <summary>
    /// Gets the name of a Variant type.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <param name="r_name">
    /// A pointer to a String to store the Variant type name.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_get_type_name(GDExtensionVariantType p_type, GDExtensionUninitializedStringPtr r_name)
    {
        var function = s_variant_get_type_name;
        ThrowIfInvalid(function);
        function(p_type, r_name);
    }

    /// <summary>
    /// Gets the Variant type by name.
    /// </summary>
    /// <param name="p_type_name">
    /// The variant type name.
    /// </param>
    /// <returns>
    /// The variant type for the given name; otherwise VARIANT_MAX if name is invalid.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariantType variant_get_type_by_name(GDExtensionConstStringPtr p_type_name)
    {
        var function = s_variant_get_type_by_name;
        ThrowIfInvalid(function);
        return function(p_type_name);
    }

    /// <summary>
    /// Checks if Variants can be converted from one type to another.
    /// </summary>
    /// <param name="p_from">
    /// The Variant type to convert from.
    /// </param>
    /// <param name="p_to">
    /// The Variant type to convert to.
    /// </param>
    /// <returns>
    /// true if the conversion is possible; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionBool variant_can_convert(GDExtensionVariantType p_from, GDExtensionVariantType p_to)
    {
        var function = s_variant_can_convert;
        ThrowIfInvalid(function);
        return function(p_from, p_to);
    }

    /// <summary>
    /// Checks if Variant can be converted from one type to another using stricter rules.
    /// </summary>
    /// <param name="p_from">
    /// The Variant type to convert from.
    /// </param>
    /// <param name="p_to">
    /// The Variant type to convert to.
    /// </param>
    /// <returns>
    /// true if the conversion is possible; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionBool variant_can_convert_strict(GDExtensionVariantType p_from, GDExtensionVariantType p_to)
    {
        var function = s_variant_can_convert_strict;
        ThrowIfInvalid(function);
        return function(p_from, p_to);
    }

    /// <summary>
    /// Gets a pointer to a function that can create a Variant of the given type from a raw value.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can create a Variant of the given type from a raw value.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariantFromTypeConstructorFunc get_variant_from_type_constructor(GDExtensionVariantType p_type)
    {
        var function = s_get_variant_from_type_constructor;
        ThrowIfInvalid(function);
        return function(p_type);
    }

    /// <summary>
    /// Gets a pointer to a function that can get the raw value from a Variant of the given type.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can get the raw value from a Variant of the given type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionTypeFromVariantConstructorFunc get_variant_to_type_constructor(GDExtensionVariantType p_type)
    {
        var function = s_get_variant_to_type_constructor;
        ThrowIfInvalid(function);
        return function(p_type);
    }

    /// <summary>
    /// Provides a function pointer for retrieving a pointer to a variant's internal value.
    /// Access to a variant's internal value can be used to modify it in-place, or to retrieve its value without the overhead of variant conversion functions.
    /// It is recommended to cache the getter for all variant types in a function table to avoid retrieval overhead upon use.
    /// 
    /// Each function assumes the variant's type has already been determined and matches the function.
    /// Invoking the function with a variant of a mismatched type has undefined behavior, and may lead to a segmentation fault.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a type-specific function that returns a pointer to the internal value of a variant. Check the implementation of this function (gdextension_variant_get_ptr_internal_getter) for pointee type info of each variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariantGetInternalPtrFunc variant_get_ptr_internal_getter(GDExtensionVariantType p_type)
    {
        var function = s_variant_get_ptr_internal_getter;
        ThrowIfInvalid(function);
        return function(p_type);
    }

    /// <summary>
    /// Gets a pointer to a function that can evaluate the given Variant operator on the given Variant types.
    /// </summary>
    /// <param name="p_operator">
    /// The variant operator.
    /// </param>
    /// <param name="p_type_a">
    /// The type of the first Variant.
    /// </param>
    /// <param name="p_type_b">
    /// The type of the second Variant.
    /// </param>
    /// <returns>
    /// A pointer to a function that can evaluate the given Variant operator on the given Variant types.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrOperatorEvaluator variant_get_ptr_operator_evaluator(GDExtensionVariantOperator p_operator, GDExtensionVariantType p_type_a, GDExtensionVariantType p_type_b)
    {
        var function = s_variant_get_ptr_operator_evaluator;
        ThrowIfInvalid(function);
        return function(p_operator, p_type_a, p_type_b);
    }

    /// <summary>
    /// Gets a pointer to a function that can call a builtin method on a type of Variant.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <param name="p_method">
    /// A pointer to a StringName with the method name.
    /// </param>
    /// <param name="p_hash">
    /// A hash representing the method signature.
    /// </param>
    /// <returns>
    /// A pointer to a function that can call a builtin method on a type of Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrBuiltInMethod variant_get_ptr_builtin_method(GDExtensionVariantType p_type, GDExtensionConstStringNamePtr p_method, GDExtensionInt p_hash)
    {
        var function = s_variant_get_ptr_builtin_method;
        ThrowIfInvalid(function);
        return function(p_type, p_method, p_hash);
    }

    /// <summary>
    /// Gets a pointer to a function that can call one of the constructors for a type of Variant.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <param name="p_constructor">
    /// The index of the constructor.
    /// </param>
    /// <returns>
    /// A pointer to a function that can call one of the constructors for a type of Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrConstructor variant_get_ptr_constructor(GDExtensionVariantType p_type, int p_constructor)
    {
        var function = s_variant_get_ptr_constructor;
        ThrowIfInvalid(function);
        return function(p_type, p_constructor);
    }

    /// <summary>
    /// Gets a pointer to a function than can call the destructor for a type of Variant.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function than can call the destructor for a type of Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrDestructor variant_get_ptr_destructor(GDExtensionVariantType p_type)
    {
        var function = s_variant_get_ptr_destructor;
        ThrowIfInvalid(function);
        return function(p_type);
    }

    /// <summary>
    /// Constructs a Variant of the given type, using the first constructor that matches the given arguments.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <param name="r_base">
    /// A pointer to a Variant to store the constructed value.
    /// </param>
    /// <param name="p_args">
    /// A pointer to a C array of Variant pointers representing the arguments for the constructor.
    /// </param>
    /// <param name="p_argument_count">
    /// The number of arguments to pass to the constructor.
    /// </param>
    /// <param name="r_error">
    /// A pointer the structure which will be updated with error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_construct(GDExtensionVariantType p_type, GDExtensionUninitializedVariantPtr r_base, GDExtensionConstVariantPtr* p_args, int p_argument_count, GDExtensionCallError* r_error)
    {
        var function = s_variant_construct;
        ThrowIfInvalid(function);
        function(p_type, r_base, p_args, p_argument_count, r_error);
    }

    /// <summary>
    /// Gets a pointer to a function that can call a member's setter on the given Variant type.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <param name="p_member">
    /// A pointer to a StringName with the member name.
    /// </param>
    /// <returns>
    /// A pointer to a function that can call a member's setter on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrSetter variant_get_ptr_setter(GDExtensionVariantType p_type, GDExtensionConstStringNamePtr p_member)
    {
        var function = s_variant_get_ptr_setter;
        ThrowIfInvalid(function);
        return function(p_type, p_member);
    }

    /// <summary>
    /// Gets a pointer to a function that can call a member's getter on the given Variant type.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <param name="p_member">
    /// A pointer to a StringName with the member name.
    /// </param>
    /// <returns>
    /// A pointer to a function that can call a member's getter on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrGetter variant_get_ptr_getter(GDExtensionVariantType p_type, GDExtensionConstStringNamePtr p_member)
    {
        var function = s_variant_get_ptr_getter;
        ThrowIfInvalid(function);
        return function(p_type, p_member);
    }

    /// <summary>
    /// Gets a pointer to a function that can set an index on the given Variant type.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can set an index on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrIndexedSetter variant_get_ptr_indexed_setter(GDExtensionVariantType p_type)
    {
        var function = s_variant_get_ptr_indexed_setter;
        ThrowIfInvalid(function);
        return function(p_type);
    }

    /// <summary>
    /// Gets a pointer to a function that can get an index on the given Variant type.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can get an index on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrIndexedGetter variant_get_ptr_indexed_getter(GDExtensionVariantType p_type)
    {
        var function = s_variant_get_ptr_indexed_getter;
        ThrowIfInvalid(function);
        return function(p_type);
    }

    /// <summary>
    /// Gets a pointer to a function that can set a key on the given Variant type.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can set a key on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrKeyedSetter variant_get_ptr_keyed_setter(GDExtensionVariantType p_type)
    {
        var function = s_variant_get_ptr_keyed_setter;
        ThrowIfInvalid(function);
        return function(p_type);
    }

    /// <summary>
    /// Gets a pointer to a function that can get a key on the given Variant type.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can get a key on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrKeyedGetter variant_get_ptr_keyed_getter(GDExtensionVariantType p_type)
    {
        var function = s_variant_get_ptr_keyed_getter;
        ThrowIfInvalid(function);
        return function(p_type);
    }

    /// <summary>
    /// Gets a pointer to a function that can check a key on the given Variant type.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can check a key on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrKeyedChecker variant_get_ptr_keyed_checker(GDExtensionVariantType p_type)
    {
        var function = s_variant_get_ptr_keyed_checker;
        ThrowIfInvalid(function);
        return function(p_type);
    }

    /// <summary>
    /// Gets the value of a constant from the given Variant type.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <param name="p_constant">
    /// A pointer to a StringName with the constant name.
    /// </param>
    /// <param name="r_ret">
    /// A pointer to a Variant to store the value.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void variant_get_constant_value(GDExtensionVariantType p_type, GDExtensionConstStringNamePtr p_constant, GDExtensionUninitializedVariantPtr r_ret)
    {
        var function = s_variant_get_constant_value;
        ThrowIfInvalid(function);
        function(p_type, p_constant, r_ret);
    }

    /// <summary>
    /// Gets a pointer to a function that can call a Variant utility function.
    /// </summary>
    /// <param name="p_function">
    /// A pointer to a StringName with the function name.
    /// </param>
    /// <param name="p_hash">
    /// A hash representing the function signature.
    /// </param>
    /// <returns>
    /// A pointer to a function that can call a Variant utility function.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionPtrUtilityFunction variant_get_ptr_utility_function(GDExtensionConstStringNamePtr p_function, GDExtensionInt p_hash)
    {
        var function = s_variant_get_ptr_utility_function;
        ThrowIfInvalid(function);
        return function(p_function, p_hash);
    }

    /// <summary>
    /// Creates a String from a Latin-1 encoded C string.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a Latin-1 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_new_with_latin1_chars(GDExtensionUninitializedStringPtr r_dest, byte* p_contents)
    {
        var function = s_string_new_with_latin1_chars;
        ThrowIfInvalid(function);
        function(r_dest, p_contents);
    }

    /// <summary>
    /// Creates a String from a UTF-8 encoded C string.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a UTF-8 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_new_with_utf8_chars(GDExtensionUninitializedStringPtr r_dest, byte* p_contents)
    {
        var function = s_string_new_with_utf8_chars;
        ThrowIfInvalid(function);
        function(r_dest, p_contents);
    }

    /// <summary>
    /// Creates a String from a UTF-16 encoded C string.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a UTF-16 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_new_with_utf16_chars(GDExtensionUninitializedStringPtr r_dest, char* p_contents)
    {
        var function = s_string_new_with_utf16_chars;
        ThrowIfInvalid(function);
        function(r_dest, p_contents);
    }

    /// <summary>
    /// Creates a String from a UTF-32 encoded C string.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a UTF-32 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_new_with_utf32_chars(GDExtensionUninitializedStringPtr r_dest, uint* p_contents)
    {
        var function = s_string_new_with_utf32_chars;
        ThrowIfInvalid(function);
        function(r_dest, p_contents);
    }

    /// <summary>
    /// Creates a String from a wide C string.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a wide C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_new_with_wide_chars(GDExtensionUninitializedStringPtr r_dest, void* p_contents)
    {
        var function = s_string_new_with_wide_chars;
        ThrowIfInvalid(function);
        function(r_dest, p_contents);
    }

    /// <summary>
    /// Creates a String from a Latin-1 encoded C string with the given length.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a Latin-1 encoded C string.
    /// </param>
    /// <param name="p_size">
    /// The number of characters (= number of bytes).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_new_with_latin1_chars_and_len(GDExtensionUninitializedStringPtr r_dest, byte* p_contents, GDExtensionInt p_size)
    {
        var function = s_string_new_with_latin1_chars_and_len;
        ThrowIfInvalid(function);
        function(r_dest, p_contents, p_size);
    }

    /// <summary>
    /// Creates a String from a UTF-8 encoded C string with the given length.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a UTF-8 encoded C string.
    /// </param>
    /// <param name="p_size">
    /// The number of bytes (not code units).
    /// </param>
    [Obsolete("Deprecated since Godot 4.3. Use string_new_with_utf8_chars_and_len2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_new_with_utf8_chars_and_len(GDExtensionUninitializedStringPtr r_dest, byte* p_contents, GDExtensionInt p_size)
    {
        var function = s_string_new_with_utf8_chars_and_len;
        ThrowIfInvalid(function);
        function(r_dest, p_contents, p_size);
    }

    /// <summary>
    /// Creates a String from a UTF-8 encoded C string with the given length.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a UTF-8 encoded C string.
    /// </param>
    /// <param name="p_size">
    /// The number of bytes (not code units).
    /// </param>
    /// <returns>
    /// Error code signifying if the operation successful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt string_new_with_utf8_chars_and_len2(GDExtensionUninitializedStringPtr r_dest, byte* p_contents, GDExtensionInt p_size)
    {
        var function = s_string_new_with_utf8_chars_and_len2;
        ThrowIfInvalid(function);
        return function(r_dest, p_contents, p_size);
    }

    /// <summary>
    /// Creates a String from a UTF-16 encoded C string with the given length.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a UTF-16 encoded C string.
    /// </param>
    /// <param name="p_char_count">
    /// The number of characters (not bytes).
    /// </param>
    [Obsolete("Deprecated since Godot 4.3. Use string_new_with_utf16_chars_and_len2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_new_with_utf16_chars_and_len(GDExtensionUninitializedStringPtr r_dest, char* p_contents, GDExtensionInt p_char_count)
    {
        var function = s_string_new_with_utf16_chars_and_len;
        ThrowIfInvalid(function);
        function(r_dest, p_contents, p_char_count);
    }

    /// <summary>
    /// Creates a String from a UTF-16 encoded C string with the given length.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a UTF-16 encoded C string.
    /// </param>
    /// <param name="p_char_count">
    /// The number of characters (not bytes).
    /// </param>
    /// <param name="p_default_little_endian">
    /// If true, UTF-16 use little endian.
    /// </param>
    /// <returns>
    /// Error code signifying if the operation successful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt string_new_with_utf16_chars_and_len2(GDExtensionUninitializedStringPtr r_dest, char* p_contents, GDExtensionInt p_char_count, GDExtensionBool p_default_little_endian)
    {
        var function = s_string_new_with_utf16_chars_and_len2;
        ThrowIfInvalid(function);
        return function(r_dest, p_contents, p_char_count, p_default_little_endian);
    }

    /// <summary>
    /// Creates a String from a UTF-32 encoded C string with the given length.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a UTF-32 encoded C string.
    /// </param>
    /// <param name="p_char_count">
    /// The number of characters (not bytes).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_new_with_utf32_chars_and_len(GDExtensionUninitializedStringPtr r_dest, uint* p_contents, GDExtensionInt p_char_count)
    {
        var function = s_string_new_with_utf32_chars_and_len;
        ThrowIfInvalid(function);
        function(r_dest, p_contents, p_char_count);
    }

    /// <summary>
    /// Creates a String from a wide C string with the given length.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a wide C string.
    /// </param>
    /// <param name="p_char_count">
    /// The number of characters (not bytes).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_new_with_wide_chars_and_len(GDExtensionUninitializedStringPtr r_dest, void* p_contents, GDExtensionInt p_char_count)
    {
        var function = s_string_new_with_wide_chars_and_len;
        ThrowIfInvalid(function);
        function(r_dest, p_contents, p_char_count);
    }

    /// <summary>
    /// Converts a String to a Latin-1 encoded C string.
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="r_text">
    /// A pointer to the buffer to hold the resulting data. If NULL is passed in, only the length will be computed.
    /// </param>
    /// <param name="p_max_write_length">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in characters, not including a null terminator. Characters that cannot be converted to Latin-1 are replaced with a space.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt string_to_latin1_chars(GDExtensionConstStringPtr p_self, byte* r_text, GDExtensionInt p_max_write_length)
    {
        var function = s_string_to_latin1_chars;
        ThrowIfInvalid(function);
        return function(p_self, r_text, p_max_write_length);
    }

    /// <summary>
    /// Converts a String to a UTF-8 encoded C string.
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="r_text">
    /// A pointer to the buffer to hold the resulting data. If NULL is passed in, only the length will be computed.
    /// </param>
    /// <param name="p_max_write_length">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in bytes (not characters), not including a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt string_to_utf8_chars(GDExtensionConstStringPtr p_self, byte* r_text, GDExtensionInt p_max_write_length)
    {
        var function = s_string_to_utf8_chars;
        ThrowIfInvalid(function);
        return function(p_self, r_text, p_max_write_length);
    }

    /// <summary>
    /// Converts a String to a UTF-16 encoded C string.
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="r_text">
    /// A pointer to the buffer to hold the resulting data. If NULL is passed in, only the length will be computed.
    /// </param>
    /// <param name="p_max_write_length">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in 16-bit code units (not bytes or characters), not including a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt string_to_utf16_chars(GDExtensionConstStringPtr p_self, char* r_text, GDExtensionInt p_max_write_length)
    {
        var function = s_string_to_utf16_chars;
        ThrowIfInvalid(function);
        return function(p_self, r_text, p_max_write_length);
    }

    /// <summary>
    /// Converts a String to a UTF-32 encoded C string.
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="r_text">
    /// A pointer to the buffer to hold the resulting data. If NULL is passed in, only the length will be computed.
    /// </param>
    /// <param name="p_max_write_length">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in characters (not bytes), not including a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt string_to_utf32_chars(GDExtensionConstStringPtr p_self, uint* r_text, GDExtensionInt p_max_write_length)
    {
        var function = s_string_to_utf32_chars;
        ThrowIfInvalid(function);
        return function(p_self, r_text, p_max_write_length);
    }

    /// <summary>
    /// Converts a String to a wide C string.
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="r_text">
    /// A pointer to the buffer to hold the resulting data. If NULL is passed in, only the length will be computed.
    /// </param>
    /// <param name="p_max_write_length">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in characters (for UTF-32) or 16-bit code units (for UTF-16), depending on the wchar_t representation. Does not include a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt string_to_wide_chars(GDExtensionConstStringPtr p_self, void* r_text, GDExtensionInt p_max_write_length)
    {
        var function = s_string_to_wide_chars;
        ThrowIfInvalid(function);
        return function(p_self, r_text, p_max_write_length);
    }

    /// <summary>
    /// Gets a pointer to the character at the given index from a String.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="p_index">
    /// The index.
    /// </param>
    /// <returns>
    /// A pointer to the requested character.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint* string_operator_index(GDExtensionStringPtr p_self, GDExtensionInt p_index)
    {
        var function = s_string_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to the character at the given index from a String.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="p_index">
    /// The index.
    /// </param>
    /// <returns>
    /// A const pointer to the requested character.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint* string_operator_index_const(GDExtensionConstStringPtr p_self, GDExtensionInt p_index)
    {
        var function = s_string_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Appends another String to a String.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="p_b">
    /// A pointer to the other String to append.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_operator_plus_eq_string(GDExtensionStringPtr p_self, GDExtensionConstStringPtr p_b)
    {
        var function = s_string_operator_plus_eq_string;
        ThrowIfInvalid(function);
        function(p_self, p_b);
    }

    /// <summary>
    /// Appends a character to a String.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="p_b">
    /// A pointer to the character to append.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_operator_plus_eq_char(GDExtensionStringPtr p_self, uint p_b)
    {
        var function = s_string_operator_plus_eq_char;
        ThrowIfInvalid(function);
        function(p_self, p_b);
    }

    /// <summary>
    /// Appends a Latin-1 encoded C string to a String.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="p_b">
    /// A pointer to a Latin-1 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_operator_plus_eq_cstr(GDExtensionStringPtr p_self, byte* p_b)
    {
        var function = s_string_operator_plus_eq_cstr;
        ThrowIfInvalid(function);
        function(p_self, p_b);
    }

    /// <summary>
    /// Appends a wide C string to a String.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="p_b">
    /// A pointer to a wide C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_operator_plus_eq_wcstr(GDExtensionStringPtr p_self, void* p_b)
    {
        var function = s_string_operator_plus_eq_wcstr;
        ThrowIfInvalid(function);
        function(p_self, p_b);
    }

    /// <summary>
    /// Appends a UTF-32 encoded C string to a String.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="p_b">
    /// A pointer to a UTF-32 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_operator_plus_eq_c32str(GDExtensionStringPtr p_self, uint* p_b)
    {
        var function = s_string_operator_plus_eq_c32str;
        ThrowIfInvalid(function);
        function(p_self, p_b);
    }

    /// <summary>
    /// Resizes the underlying string data to the given number of characters.
    /// Space needs to be allocated for the null terminating character ('\0') which
    /// also must be added manually, in order for all string functions to work correctly.
    /// 
    /// Warning: This is an error-prone operation - only use it if there's no other
    /// efficient way to accomplish your goal.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="p_resize">
    /// The new length for the String.
    /// </param>
    /// <returns>
    /// Error code signifying if the operation successful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt string_resize(GDExtensionStringPtr p_self, GDExtensionInt p_resize)
    {
        var function = s_string_resize;
        ThrowIfInvalid(function);
        return function(p_self, p_resize);
    }

    /// <summary>
    /// Creates a StringName from a Latin-1 encoded C string.
    /// If `p_is_static` is true, then:
    /// - The StringName will reuse the `p_contents` buffer instead of copying it.
    /// - You must guarantee that the buffer remains valid for the duration of the application (e.g. string literal).
    /// - You must not call a destructor for this StringName. Incrementing the initial reference once should achieve this.
    /// 
    /// `p_is_static` is purely an optimization and can easily introduce undefined behavior if used wrong. In case of doubt, set it to false.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to uninitialized storage, into which the newly created StringName is constructed.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a C string (null terminated and Latin-1 or ASCII encoded).
    /// </param>
    /// <param name="p_is_static">
    /// Whether the StringName reuses the buffer directly (see above).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_name_new_with_latin1_chars(GDExtensionUninitializedStringNamePtr r_dest, byte* p_contents, GDExtensionBool p_is_static)
    {
        var function = s_string_name_new_with_latin1_chars;
        ThrowIfInvalid(function);
        function(r_dest, p_contents, p_is_static);
    }

    /// <summary>
    /// Creates a StringName from a UTF-8 encoded C string.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to uninitialized storage, into which the newly created StringName is constructed.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a C string (null terminated and UTF-8 encoded).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_name_new_with_utf8_chars(GDExtensionUninitializedStringNamePtr r_dest, byte* p_contents)
    {
        var function = s_string_name_new_with_utf8_chars;
        ThrowIfInvalid(function);
        function(r_dest, p_contents);
    }

    /// <summary>
    /// Creates a StringName from a UTF-8 encoded string with a given number of characters.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to uninitialized storage, into which the newly created StringName is constructed.
    /// </param>
    /// <param name="p_contents">
    /// A pointer to a C string (null terminated and UTF-8 encoded).
    /// </param>
    /// <param name="p_size">
    /// The number of bytes (not UTF-8 code points).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void string_name_new_with_utf8_chars_and_len(GDExtensionUninitializedStringNamePtr r_dest, byte* p_contents, GDExtensionInt p_size)
    {
        var function = s_string_name_new_with_utf8_chars_and_len;
        ThrowIfInvalid(function);
        function(r_dest, p_contents, p_size);
    }

    /// <summary>
    /// Opens a raw XML buffer on an XMLParser instance.
    /// </summary>
    /// <param name="p_instance">
    /// A pointer to an XMLParser object.
    /// </param>
    /// <param name="p_buffer">
    /// A pointer to the buffer.
    /// </param>
    /// <param name="p_size">
    /// The size of the buffer.
    /// </param>
    /// <returns>
    /// A Godot error code (ex. OK, ERR_INVALID_DATA, etc).
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt xml_parser_open_buffer(GDExtensionObjectPtr p_instance, byte* p_buffer, nuint p_size)
    {
        var function = s_xml_parser_open_buffer;
        ThrowIfInvalid(function);
        return function(p_instance, p_buffer, p_size);
    }

    /// <summary>
    /// Stores the given buffer using an instance of FileAccess.
    /// </summary>
    /// <param name="p_instance">
    /// A pointer to a FileAccess object.
    /// </param>
    /// <param name="p_src">
    /// A pointer to the buffer.
    /// </param>
    /// <param name="p_length">
    /// The size of the buffer.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void file_access_store_buffer(GDExtensionObjectPtr p_instance, byte* p_src, ulong p_length)
    {
        var function = s_file_access_store_buffer;
        ThrowIfInvalid(function);
        function(p_instance, p_src, p_length);
    }

    /// <summary>
    /// Reads the next p_length bytes into the given buffer using an instance of FileAccess.
    /// </summary>
    /// <param name="p_instance">
    /// A pointer to a FileAccess object.
    /// </param>
    /// <param name="p_dst">
    /// A pointer to the buffer to store the data.
    /// </param>
    /// <param name="p_length">
    /// The requested number of bytes to read.
    /// </param>
    /// <returns>
    /// The actual number of bytes read (may be less than requested).
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong file_access_get_buffer(GDExtensionConstObjectPtr p_instance, byte* p_dst, ulong p_length)
    {
        var function = s_file_access_get_buffer;
        ThrowIfInvalid(function);
        return function(p_instance, p_dst, p_length);
    }

    /// <summary>
    /// Returns writable pointer to internal Image buffer.
    /// </summary>
    /// <param name="p_instance">
    /// A pointer to a Image object.
    /// </param>
    /// <returns>
    /// Pointer to internal Image buffer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte* image_ptrw(GDExtensionObjectPtr p_instance)
    {
        var function = s_image_ptrw;
        ThrowIfInvalid(function);
        return function(p_instance);
    }

    /// <summary>
    /// Returns read only pointer to internal Image buffer.
    /// </summary>
    /// <param name="p_instance">
    /// A pointer to a Image object.
    /// </param>
    /// <returns>
    /// Pointer to internal Image buffer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte* image_ptr(GDExtensionObjectPtr p_instance)
    {
        var function = s_image_ptr;
        ThrowIfInvalid(function);
        return function(p_instance);
    }

    /// <summary>
    /// Adds a group task to an instance of WorkerThreadPool.
    /// </summary>
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
    public static long worker_thread_pool_add_native_group_task(GDExtensionObjectPtr p_instance, GDExtensionWorkerThreadPoolGroupTask p_func, void* p_userdata, int p_elements, int p_tasks, GDExtensionBool p_high_priority, GDExtensionConstStringPtr p_description)
    {
        var function = s_worker_thread_pool_add_native_group_task;
        ThrowIfInvalid(function);
        return function(p_instance, p_func, p_userdata, p_elements, p_tasks, p_high_priority, p_description);
    }

    /// <summary>
    /// Adds a task to an instance of WorkerThreadPool.
    /// </summary>
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
    public static long worker_thread_pool_add_native_task(GDExtensionObjectPtr p_instance, GDExtensionWorkerThreadPoolTask p_func, void* p_userdata, GDExtensionBool p_high_priority, GDExtensionConstStringPtr p_description)
    {
        var function = s_worker_thread_pool_add_native_task;
        ThrowIfInvalid(function);
        return function(p_instance, p_func, p_userdata, p_high_priority, p_description);
    }

    /// <summary>
    /// Gets a pointer to a byte in a PackedByteArray.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to a PackedByteArray object.
    /// </param>
    /// <param name="p_index">
    /// The index of the byte to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested byte.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte* packed_byte_array_operator_index(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_byte_array_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to a byte in a PackedByteArray.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to a PackedByteArray object.
    /// </param>
    /// <param name="p_index">
    /// The index of the byte to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested byte.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte* packed_byte_array_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_byte_array_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a pointer to a 32-bit float in a PackedFloat32Array.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to a PackedFloat32Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the float to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested 32-bit float.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float* packed_float32_array_operator_index(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_float32_array_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to a 32-bit float in a PackedFloat32Array.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to a PackedFloat32Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the float to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested 32-bit float.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float* packed_float32_array_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_float32_array_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a pointer to a 64-bit float in a PackedFloat64Array.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to a PackedFloat64Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the float to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested 64-bit float.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double* packed_float64_array_operator_index(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_float64_array_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to a 64-bit float in a PackedFloat64Array.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to a PackedFloat64Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the float to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested 64-bit float.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double* packed_float64_array_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_float64_array_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a pointer to a 32-bit integer in a PackedInt32Array.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to a PackedInt32Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the integer to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested 32-bit integer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int* packed_int32_array_operator_index(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_int32_array_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to a 32-bit integer in a PackedInt32Array.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to a PackedInt32Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the integer to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested 32-bit integer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int* packed_int32_array_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_int32_array_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a pointer to a 64-bit integer in a PackedInt64Array.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to a PackedInt64Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the integer to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested 64-bit integer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long* packed_int64_array_operator_index(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_int64_array_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to a 64-bit integer in a PackedInt64Array.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to a PackedInt64Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the integer to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested 64-bit integer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long* packed_int64_array_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_int64_array_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a pointer to a string in a PackedStringArray.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to a PackedStringArray object.
    /// </param>
    /// <param name="p_index">
    /// The index of the String to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested String.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionStringPtr packed_string_array_operator_index(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_string_array_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to a string in a PackedStringArray.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to a PackedStringArray object.
    /// </param>
    /// <param name="p_index">
    /// The index of the String to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested String.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionStringPtr packed_string_array_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_string_array_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a pointer to a Vector2 in a PackedVector2Array.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to a PackedVector2Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the Vector2 to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested Vector2.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionTypePtr packed_vector2_array_operator_index(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_vector2_array_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to a Vector2 in a PackedVector2Array.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to a PackedVector2Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the Vector2 to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested Vector2.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionTypePtr packed_vector2_array_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_vector2_array_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a pointer to a Vector3 in a PackedVector3Array.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to a PackedVector3Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the Vector3 to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested Vector3.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionTypePtr packed_vector3_array_operator_index(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_vector3_array_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to a Vector3 in a PackedVector3Array.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to a PackedVector3Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the Vector3 to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested Vector3.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionTypePtr packed_vector3_array_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_vector3_array_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a pointer to a Vector4 in a PackedVector4Array.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to a PackedVector4Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the Vector4 to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested Vector4.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionTypePtr packed_vector4_array_operator_index(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_vector4_array_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to a Vector4 in a PackedVector4Array.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to a PackedVector4Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the Vector4 to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested Vector4.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionTypePtr packed_vector4_array_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_vector4_array_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a pointer to a color in a PackedColorArray.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to a PackedColorArray object.
    /// </param>
    /// <param name="p_index">
    /// The index of the Color to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested Color.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionTypePtr packed_color_array_operator_index(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_color_array_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to a color in a PackedColorArray.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to a PackedColorArray object.
    /// </param>
    /// <param name="p_index">
    /// The index of the Color to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested Color.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionTypePtr packed_color_array_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_packed_color_array_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a pointer to a Variant in an Array.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to an Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the Variant to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariantPtr array_operator_index(GDExtensionTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_array_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Gets a const pointer to a Variant in an Array.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to an Array object.
    /// </param>
    /// <param name="p_index">
    /// The index of the Variant to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariantPtr array_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionInt p_index)
    {
        var function = s_array_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_index);
    }

    /// <summary>
    /// Sets an Array to be a reference to another Array object.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Array object to update.
    /// </param>
    /// <param name="p_from">
    /// A pointer to the Array object to reference.
    /// </param>
    [Obsolete("Deprecated since Godot 4.5. Removed from interface. Use copy constructor instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void array_ref(GDExtensionTypePtr p_self, GDExtensionConstTypePtr p_from)
    {
        var function = s_array_ref;
        ThrowIfInvalid(function);
        function(p_self, p_from);
    }

    /// <summary>
    /// Makes an Array into a typed Array.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Array.
    /// </param>
    /// <param name="p_type">
    /// The type of Variant the Array will store.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the name of the object (if p_type is GDEXTENSION_VARIANT_TYPE_OBJECT).
    /// </param>
    /// <param name="p_script">
    /// A pointer to a Script object (if p_type is GDEXTENSION_VARIANT_TYPE_OBJECT and the base class is extended by a script).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void array_set_typed(GDExtensionTypePtr p_self, GDExtensionVariantType p_type, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstVariantPtr p_script)
    {
        var function = s_array_set_typed;
        ThrowIfInvalid(function);
        function(p_self, p_type, p_class_name, p_script);
    }

    /// <summary>
    /// Gets a pointer to a Variant in a Dictionary with the given key.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to a Dictionary object.
    /// </param>
    /// <param name="p_key">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <returns>
    /// A pointer to a Variant representing the value at the given key.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariantPtr dictionary_operator_index(GDExtensionTypePtr p_self, GDExtensionConstVariantPtr p_key)
    {
        var function = s_dictionary_operator_index;
        ThrowIfInvalid(function);
        return function(p_self, p_key);
    }

    /// <summary>
    /// Gets a const pointer to a Variant in a Dictionary with the given key.
    /// </summary>
    /// <param name="p_self">
    /// A const pointer to a Dictionary object.
    /// </param>
    /// <param name="p_key">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <returns>
    /// A const pointer to a Variant representing the value at the given key.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariantPtr dictionary_operator_index_const(GDExtensionConstTypePtr p_self, GDExtensionConstVariantPtr p_key)
    {
        var function = s_dictionary_operator_index_const;
        ThrowIfInvalid(function);
        return function(p_self, p_key);
    }

    /// <summary>
    /// Makes a Dictionary into a typed Dictionary.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Dictionary.
    /// </param>
    /// <param name="p_key_type">
    /// The type of Variant the Dictionary key will store.
    /// </param>
    /// <param name="p_key_class_name">
    /// A pointer to a StringName with the name of the object (if p_key_type is GDEXTENSION_VARIANT_TYPE_OBJECT).
    /// </param>
    /// <param name="p_key_script">
    /// A pointer to a Script object (if p_key_type is GDEXTENSION_VARIANT_TYPE_OBJECT and the base class is extended by a script).
    /// </param>
    /// <param name="p_value_type">
    /// The type of Variant the Dictionary value will store.
    /// </param>
    /// <param name="p_value_class_name">
    /// A pointer to a StringName with the name of the object (if p_value_type is GDEXTENSION_VARIANT_TYPE_OBJECT).
    /// </param>
    /// <param name="p_value_script">
    /// A pointer to a Script object (if p_value_type is GDEXTENSION_VARIANT_TYPE_OBJECT and the base class is extended by a script).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void dictionary_set_typed(GDExtensionTypePtr p_self, GDExtensionVariantType p_key_type, GDExtensionConstStringNamePtr p_key_class_name, GDExtensionConstVariantPtr p_key_script, GDExtensionVariantType p_value_type, GDExtensionConstStringNamePtr p_value_class_name, GDExtensionConstVariantPtr p_value_script)
    {
        var function = s_dictionary_set_typed;
        ThrowIfInvalid(function);
        function(p_self, p_key_type, p_key_class_name, p_key_script, p_value_type, p_value_class_name, p_value_script);
    }

    /// <summary>
    /// Calls a method on an Object.
    /// </summary>
    /// <param name="p_method_bind">
    /// A pointer to the MethodBind representing the method on the Object's class.
    /// </param>
    /// <param name="p_instance">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_args">
    /// A pointer to a C array of Variants representing the arguments.
    /// </param>
    /// <param name="p_arg_count">
    /// The number of arguments.
    /// </param>
    /// <param name="r_ret">
    /// A pointer to Variant which will receive the return value.
    /// </param>
    /// <param name="r_error">
    /// A pointer to a GDExtensionCallError struct that will receive error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void object_method_bind_call(GDExtensionMethodBindPtr p_method_bind, GDExtensionObjectPtr p_instance, GDExtensionConstVariantPtr* p_args, GDExtensionInt p_arg_count, GDExtensionUninitializedVariantPtr r_ret, GDExtensionCallError* r_error)
    {
        var function = s_object_method_bind_call;
        ThrowIfInvalid(function);
        function(p_method_bind, p_instance, p_args, p_arg_count, r_ret, r_error);
    }

    /// <summary>
    /// Calls a method on an Object (using a "ptrcall").
    /// </summary>
    /// <param name="p_method_bind">
    /// A pointer to the MethodBind representing the method on the Object's class.
    /// </param>
    /// <param name="p_instance">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_args">
    /// A pointer to a C array representing the arguments.
    /// </param>
    /// <param name="r_ret">
    /// A pointer to the Object that will receive the return value.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void object_method_bind_ptrcall(GDExtensionMethodBindPtr p_method_bind, GDExtensionObjectPtr p_instance, GDExtensionConstTypePtr* p_args, GDExtensionTypePtr r_ret)
    {
        var function = s_object_method_bind_ptrcall;
        ThrowIfInvalid(function);
        function(p_method_bind, p_instance, p_args, r_ret);
    }

    /// <summary>
    /// Destroys an Object.
    /// </summary>
    /// <param name="p_o">
    /// A pointer to the Object.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void object_destroy(GDExtensionObjectPtr p_o)
    {
        var function = s_object_destroy;
        ThrowIfInvalid(function);
        function(p_o);
    }

    /// <summary>
    /// Gets a global singleton by name.
    /// </summary>
    /// <param name="p_name">
    /// A pointer to a StringName with the singleton name.
    /// </param>
    /// <returns>
    /// A pointer to the singleton Object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr global_get_singleton(GDExtensionConstStringNamePtr p_name)
    {
        var function = s_global_get_singleton;
        ThrowIfInvalid(function);
        return function(p_name);
    }

    /// <summary>
    /// Gets a pointer representing an Object's instance binding.
    /// </summary>
    /// <param name="p_o">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_token">
    /// A token the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_callbacks">
    /// A pointer to a GDExtensionInstanceBindingCallbacks struct.
    /// </param>
    /// <returns>
    /// A pointer to the instance binding.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* object_get_instance_binding(GDExtensionObjectPtr p_o, void* p_token, GDExtensionInstanceBindingCallbacks* p_callbacks)
    {
        var function = s_object_get_instance_binding;
        ThrowIfInvalid(function);
        return function(p_o, p_token, p_callbacks);
    }

    /// <summary>
    /// Sets an Object's instance binding.
    /// </summary>
    /// <param name="p_o">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_token">
    /// A token the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_binding">
    /// A pointer to the instance binding.
    /// </param>
    /// <param name="p_callbacks">
    /// A pointer to a GDExtensionInstanceBindingCallbacks struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void object_set_instance_binding(GDExtensionObjectPtr p_o, void* p_token, void* p_binding, GDExtensionInstanceBindingCallbacks* p_callbacks)
    {
        var function = s_object_set_instance_binding;
        ThrowIfInvalid(function);
        function(p_o, p_token, p_binding, p_callbacks);
    }

    /// <summary>
    /// Free an Object's instance binding.
    /// </summary>
    /// <param name="p_o">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_token">
    /// A token the library received by the GDExtension's entry point function.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void object_free_instance_binding(GDExtensionObjectPtr p_o, void* p_token)
    {
        var function = s_object_free_instance_binding;
        ThrowIfInvalid(function);
        function(p_o, p_token);
    }

    /// <summary>
    /// Sets an extension class instance on a Object.
    /// `p_classname` should be a registered extension class and should extend the `p_o` Object's class.
    /// </summary>
    /// <param name="p_o">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_classname">
    /// A pointer to a StringName with the registered extension class's name.
    /// </param>
    /// <param name="p_instance">
    /// A pointer to the extension class instance.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void object_set_instance(GDExtensionObjectPtr p_o, GDExtensionConstStringNamePtr p_classname, GDExtensionClassInstancePtr p_instance)
    {
        var function = s_object_set_instance;
        ThrowIfInvalid(function);
        function(p_o, p_classname, p_instance);
    }

    /// <summary>
    /// Gets the class name of an Object.
    /// If the GDExtension wraps the Godot object in an abstraction specific to its class, this is the
    /// function that should be used to determine which wrapper to use.
    /// </summary>
    /// <param name="p_object">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="r_class_name">
    /// A pointer to a String to receive the class name.
    /// </param>
    /// <returns>
    /// true if successful in getting the class name; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionBool object_get_class_name(GDExtensionConstObjectPtr p_object, GDExtensionClassLibraryPtr p_library, GDExtensionUninitializedStringNamePtr r_class_name)
    {
        var function = s_object_get_class_name;
        ThrowIfInvalid(function);
        return function(p_object, p_library, r_class_name);
    }

    /// <summary>
    /// Casts an Object to a different type.
    /// </summary>
    /// <param name="p_object">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_class_tag">
    /// A pointer uniquely identifying a built-in class in the ClassDB.
    /// </param>
    /// <returns>
    /// Returns a pointer to the Object, or NULL if it can't be cast to the requested type.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.7. Use the `is_class` method on `Object` to check if an object can be cast instead. If true, the previous pointer can be reinterpreted as a pointer to the target type.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr object_cast_to(GDExtensionConstObjectPtr p_object, void* p_class_tag)
    {
        var function = s_object_cast_to;
        ThrowIfInvalid(function);
        return function(p_object, p_class_tag);
    }

    /// <summary>
    /// Gets an Object by its instance ID.
    /// </summary>
    /// <param name="p_instance_id">
    /// The instance ID.
    /// </param>
    /// <returns>
    /// A pointer to the Object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr object_get_instance_from_id(GDObjectInstanceID p_instance_id)
    {
        var function = s_object_get_instance_from_id;
        ThrowIfInvalid(function);
        return function(p_instance_id);
    }

    /// <summary>
    /// Gets the instance ID from an Object.
    /// </summary>
    /// <param name="p_object">
    /// A pointer to the Object.
    /// </param>
    /// <returns>
    /// The instance ID.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDObjectInstanceID object_get_instance_id(GDExtensionConstObjectPtr p_object)
    {
        var function = s_object_get_instance_id;
        ThrowIfInvalid(function);
        return function(p_object);
    }

    /// <summary>
    /// Checks if this object has a script with the given method.
    /// </summary>
    /// <param name="p_object">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_method">
    /// A pointer to a StringName identifying the method.
    /// </param>
    /// <returns>
    /// true if the object has a script and that script has a method with the given name. Returns false if the object has no script.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionBool object_has_script_method(GDExtensionConstObjectPtr p_object, GDExtensionConstStringNamePtr p_method)
    {
        var function = s_object_has_script_method;
        ThrowIfInvalid(function);
        return function(p_object, p_method);
    }

    /// <summary>
    /// Call the given script method on this object.
    /// </summary>
    /// <param name="p_object">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_method">
    /// A pointer to a StringName identifying the method.
    /// </param>
    /// <param name="p_args">
    /// A pointer to a C array of Variant.
    /// </param>
    /// <param name="p_argument_count">
    /// The number of arguments.
    /// </param>
    /// <param name="r_return">
    /// A pointer a Variant which will be assigned the return value.
    /// </param>
    /// <param name="r_error">
    /// A pointer the structure which will hold error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void object_call_script_method(GDExtensionObjectPtr p_object, GDExtensionConstStringNamePtr p_method, GDExtensionConstVariantPtr* p_args, GDExtensionInt p_argument_count, GDExtensionUninitializedVariantPtr r_return, GDExtensionCallError* r_error)
    {
        var function = s_object_call_script_method;
        ThrowIfInvalid(function);
        function(p_object, p_method, p_args, p_argument_count, r_return, r_error);
    }

    /// <summary>
    /// Gets the Object from a reference.
    /// </summary>
    /// <param name="p_ref">
    /// A pointer to the reference.
    /// </param>
    /// <returns>
    /// A pointer to the Object from the reference or NULL.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr ref_get_object(GDExtensionConstRefPtr p_ref)
    {
        var function = s_ref_get_object;
        ThrowIfInvalid(function);
        return function(p_ref);
    }

    /// <summary>
    /// Sets the Object referred to by a reference.
    /// </summary>
    /// <param name="p_ref">
    /// A pointer to the reference.
    /// </param>
    /// <param name="p_object">
    /// A pointer to the Object to refer to.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ref_set_object(GDExtensionRefPtr p_ref, GDExtensionObjectPtr p_object)
    {
        var function = s_ref_set_object;
        ThrowIfInvalid(function);
        function(p_ref, p_object);
    }

    /// <summary>
    /// Creates a script instance that contains the given info and instance data.
    /// </summary>
    /// <param name="p_info">
    /// A pointer to a GDExtensionScriptInstanceInfo struct.
    /// </param>
    /// <param name="p_instance_data">
    /// A pointer to a data representing the script instance in the GDExtension. This will be passed to all the function pointers on p_info.
    /// </param>
    /// <returns>
    /// A pointer to a ScriptInstanceExtension object.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.2. Use script_instance_create3 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionScriptInstancePtr script_instance_create(GDExtensionScriptInstanceInfo* p_info, GDExtensionScriptInstanceDataPtr p_instance_data)
    {
        var function = s_script_instance_create;
        ThrowIfInvalid(function);
        return function(p_info, p_instance_data);
    }

    /// <summary>
    /// Creates a script instance that contains the given info and instance data.
    /// </summary>
    /// <param name="p_info">
    /// A pointer to a GDExtensionScriptInstanceInfo2 struct.
    /// </param>
    /// <param name="p_instance_data">
    /// A pointer to a data representing the script instance in the GDExtension. This will be passed to all the function pointers on p_info.
    /// </param>
    /// <returns>
    /// A pointer to a ScriptInstanceExtension object.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.3. Use script_instance_create3 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionScriptInstancePtr script_instance_create2(GDExtensionScriptInstanceInfo2* p_info, GDExtensionScriptInstanceDataPtr p_instance_data)
    {
        var function = s_script_instance_create2;
        ThrowIfInvalid(function);
        return function(p_info, p_instance_data);
    }

    /// <summary>
    /// Creates a script instance that contains the given info and instance data.
    /// </summary>
    /// <param name="p_info">
    /// A pointer to a GDExtensionScriptInstanceInfo3 struct.
    /// </param>
    /// <param name="p_instance_data">
    /// A pointer to a data representing the script instance in the GDExtension. This will be passed to all the function pointers on p_info.
    /// </param>
    /// <returns>
    /// A pointer to a ScriptInstanceExtension object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionScriptInstancePtr script_instance_create3(GDExtensionScriptInstanceInfo3* p_info, GDExtensionScriptInstanceDataPtr p_instance_data)
    {
        var function = s_script_instance_create3;
        ThrowIfInvalid(function);
        return function(p_info, p_instance_data);
    }

    /// <summary>
    /// Creates a placeholder script instance for a given script and instance.
    /// This interface is optional as a custom placeholder could also be created with script_instance_create().
    /// </summary>
    /// <param name="p_language">
    /// A pointer to a ScriptLanguage.
    /// </param>
    /// <param name="p_script">
    /// A pointer to a Script.
    /// </param>
    /// <param name="p_owner">
    /// A pointer to an Object.
    /// </param>
    /// <returns>
    /// A pointer to a PlaceHolderScriptInstance object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionScriptInstancePtr placeholder_script_instance_create(GDExtensionObjectPtr p_language, GDExtensionObjectPtr p_script, GDExtensionObjectPtr p_owner)
    {
        var function = s_placeholder_script_instance_create;
        ThrowIfInvalid(function);
        return function(p_language, p_script, p_owner);
    }

    /// <summary>
    /// Updates a placeholder script instance with the given properties and values.
    /// The passed in placeholder must be an instance of PlaceHolderScriptInstance
    /// such as the one returned by placeholder_script_instance_create().
    /// </summary>
    /// <param name="p_placeholder">
    /// A pointer to a PlaceHolderScriptInstance.
    /// </param>
    /// <param name="p_properties">
    /// A pointer to an Array of Dictionary representing PropertyInfo.
    /// </param>
    /// <param name="p_values">
    /// A pointer to a Dictionary mapping StringName to Variant values.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void placeholder_script_instance_update(GDExtensionScriptInstancePtr p_placeholder, GDExtensionConstTypePtr p_properties, GDExtensionConstTypePtr p_values)
    {
        var function = s_placeholder_script_instance_update;
        ThrowIfInvalid(function);
        function(p_placeholder, p_properties, p_values);
    }

    /// <summary>
    /// Get the script instance data attached to this object.
    /// </summary>
    /// <param name="p_object">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_language">
    /// A pointer to the language expected for this script instance.
    /// </param>
    /// <returns>
    /// A GDExtensionScriptInstanceDataPtr that was attached to this object as part of script_instance_create.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionScriptInstanceDataPtr object_get_script_instance(GDExtensionConstObjectPtr p_object, GDExtensionObjectPtr p_language)
    {
        var function = s_object_get_script_instance;
        ThrowIfInvalid(function);
        return function(p_object, p_language);
    }

    /// <summary>
    /// Set the script instance data attached to this object.
    /// </summary>
    /// <param name="p_object">
    /// A pointer to the Object.
    /// </param>
    /// <param name="p_script_instance">
    /// A pointer to the script instance data to attach to this object.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void object_set_script_instance(GDExtensionObjectPtr p_object, GDExtensionScriptInstanceDataPtr p_script_instance)
    {
        var function = s_object_set_script_instance;
        ThrowIfInvalid(function);
        function(p_object, p_script_instance);
    }

    /// <summary>
    /// Creates a custom Callable object from a function pointer.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="r_callable">
    /// A pointer that will receive the new Callable.
    /// </param>
    /// <param name="p_callable_custom_info">
    /// The info required to construct a Callable.
    /// </param>
    [Obsolete("Deprecated since Godot 4.3. Use callable_custom_create2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void callable_custom_create(GDExtensionUninitializedTypePtr r_callable, GDExtensionCallableCustomInfo* p_callable_custom_info)
    {
        var function = s_callable_custom_create;
        ThrowIfInvalid(function);
        function(r_callable, p_callable_custom_info);
    }

    /// <summary>
    /// Creates a custom Callable object from a function pointer.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="r_callable">
    /// A pointer that will receive the new Callable.
    /// </param>
    /// <param name="p_callable_custom_info">
    /// The info required to construct a Callable.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void callable_custom_create2(GDExtensionUninitializedTypePtr r_callable, GDExtensionCallableCustomInfo2* p_callable_custom_info)
    {
        var function = s_callable_custom_create2;
        ThrowIfInvalid(function);
        function(r_callable, p_callable_custom_info);
    }

    /// <summary>
    /// Retrieves the userdata pointer from a custom Callable.
    /// If the Callable is not a custom Callable or the token does not match the one provided to callable_custom_create() via GDExtensionCallableCustomInfo then NULL will be returned.
    /// </summary>
    /// <param name="p_callable">
    /// A pointer to a Callable.
    /// </param>
    /// <param name="p_token">
    /// A pointer to an address that uniquely identifies the GDExtension.
    /// </param>
    /// <returns>
    /// The userdata pointer given when creating this custom Callable.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* callable_custom_get_userdata(GDExtensionConstTypePtr p_callable, void* p_token)
    {
        var function = s_callable_custom_get_userdata;
        ThrowIfInvalid(function);
        return function(p_callable, p_token);
    }

    /// <summary>
    /// Constructs an Object of the requested class.
    /// The passed class must be a built-in godot class, or an already-registered extension class. In both cases, object_set_instance() should be called to fully initialize the object.
    /// </summary>
    /// <param name="p_classname">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer to the newly created Object.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.4. Use classdb_construct_object3 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr classdb_construct_object(GDExtensionConstStringNamePtr p_classname)
    {
        var function = s_classdb_construct_object;
        ThrowIfInvalid(function);
        return function(p_classname);
    }

    /// <summary>
    /// Constructs an Object of the requested class.
    /// The passed class must be a built-in godot class, or an already-registered extension class. In both cases, object_set_instance() should be called to fully initialize the object.
    /// 
    /// "NOTIFICATION_POSTINITIALIZE" must be sent after construction.
    /// </summary>
    /// <param name="p_classname">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer to the newly created Object.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.7. Use classdb_construct_object3 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr classdb_construct_object2(GDExtensionConstStringNamePtr p_classname)
    {
        var function = s_classdb_construct_object2;
        ThrowIfInvalid(function);
        return function(p_classname);
    }

    /// <summary>
    /// Constructs an Object of the requested class.
    /// The passed class must be a built-in godot class, or an already-registered extension class. In both cases, object_set_instance() should be called to fully initialize the object.
    /// If the type is a subtype of RefCounted, it already has a refcount of 1. The caller must take ownership the refcount and is responsible for decrementing it again when the object is no longer needed.
    /// 
    /// "NOTIFICATION_POSTINITIALIZE" must be sent after construction.
    /// </summary>
    /// <param name="p_classname">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer to the newly created Object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr classdb_construct_object3(GDExtensionConstStringNamePtr p_classname)
    {
        var function = s_classdb_construct_object3;
        ThrowIfInvalid(function);
        return function(p_classname);
    }

    /// <summary>
    /// Gets a pointer to the MethodBind in ClassDB for the given class, method and hash.
    /// </summary>
    /// <param name="p_classname">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_methodname">
    /// A pointer to a StringName with the method name.
    /// </param>
    /// <param name="p_hash">
    /// A hash representing the function signature.
    /// </param>
    /// <returns>
    /// A pointer to the MethodBind from ClassDB.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionMethodBindPtr classdb_get_method_bind(GDExtensionConstStringNamePtr p_classname, GDExtensionConstStringNamePtr p_methodname, GDExtensionInt p_hash)
    {
        var function = s_classdb_get_method_bind;
        ThrowIfInvalid(function);
        return function(p_classname, p_methodname, p_hash);
    }

    /// <summary>
    /// Gets a pointer uniquely identifying the given built-in class in the ClassDB.
    /// </summary>
    /// <param name="p_classname">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer uniquely identifying the built-in class in the ClassDB.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.7. No longer needed. Use the `is_class` method on `Object` instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* classdb_get_class_tag(GDExtensionConstStringNamePtr p_classname)
    {
        var function = s_classdb_get_class_tag;
        ThrowIfInvalid(function);
        return function(p_classname);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_parent_class_name">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="p_extension_funcs">
    /// A pointer to a GDExtensionClassCreationInfo struct.
    /// </param>
    [Obsolete("Deprecated since Godot 4.2. Use classdb_register_extension_class6 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstStringNamePtr p_parent_class_name, GDExtensionClassCreationInfo* p_extension_funcs)
    {
        var function = s_classdb_register_extension_class;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_parent_class_name, p_extension_funcs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_parent_class_name">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="p_extension_funcs">
    /// A pointer to a GDExtensionClassCreationInfo2 struct.
    /// </param>
    [Obsolete("Deprecated since Godot 4.3. Use classdb_register_extension_class6 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class2(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstStringNamePtr p_parent_class_name, GDExtensionClassCreationInfo2* p_extension_funcs)
    {
        var function = s_classdb_register_extension_class2;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_parent_class_name, p_extension_funcs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_parent_class_name">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="p_extension_funcs">
    /// A pointer to a GDExtensionClassCreationInfo3 struct.
    /// </param>
    [Obsolete("Deprecated since Godot 4.4. Use classdb_register_extension_class6 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class3(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstStringNamePtr p_parent_class_name, GDExtensionClassCreationInfo3* p_extension_funcs)
    {
        var function = s_classdb_register_extension_class3;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_parent_class_name, p_extension_funcs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_parent_class_name">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="p_extension_funcs">
    /// A pointer to a GDExtensionClassCreationInfo4 struct.
    /// </param>
    [Obsolete("Deprecated since Godot 4.5. Use classdb_register_extension_class6 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class4(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstStringNamePtr p_parent_class_name, GDExtensionClassCreationInfo4* p_extension_funcs)
    {
        var function = s_classdb_register_extension_class4;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_parent_class_name, p_extension_funcs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_parent_class_name">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="p_extension_funcs">
    /// A pointer to a GDExtensionClassCreationInfo5 struct.
    /// </param>
    [Obsolete("Deprecated since Godot 4.7. Use classdb_register_extension_class6 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class5(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstStringNamePtr p_parent_class_name, GDExtensionClassCreationInfo5* p_extension_funcs)
    {
        var function = s_classdb_register_extension_class5;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_parent_class_name, p_extension_funcs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_parent_class_name">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="p_extension_funcs">
    /// A pointer to a GDExtensionClassCreationInfo6 struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class6(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstStringNamePtr p_parent_class_name, GDExtensionClassCreationInfo6* p_extension_funcs)
    {
        var function = s_classdb_register_extension_class6;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_parent_class_name, p_extension_funcs);
    }

    /// <summary>
    /// Registers a method on an extension class in the ClassDB.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_method_info">
    /// A pointer to a GDExtensionClassMethodInfo struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class_method(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionClassMethodInfo* p_method_info)
    {
        var function = s_classdb_register_extension_class_method;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_method_info);
    }

    /// <summary>
    /// Registers a virtual method on an extension class in ClassDB, that can be implemented by scripts or other extensions.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_method_info">
    /// A pointer to a GDExtensionClassMethodInfo struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class_virtual_method(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionClassVirtualMethodInfo* p_method_info)
    {
        var function = s_classdb_register_extension_class_virtual_method;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_method_info);
    }

    /// <summary>
    /// Registers an integer constant on an extension class in the ClassDB.
    /// Note about registering bitfield values (if p_is_bitfield is true): even though p_constant_value is signed, language bindings are
    /// advised to treat bitfields as uint64_t, since this is generally clearer and can prevent mistakes like using -1 for setting all bits.
    /// Language APIs should thus provide an abstraction that registers bitfields (uint64_t) separately from regular constants (int64_t).
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_enum_name">
    /// A pointer to a StringName with the enum name.
    /// </param>
    /// <param name="p_constant_name">
    /// A pointer to a StringName with the constant name.
    /// </param>
    /// <param name="p_constant_value">
    /// The constant value.
    /// </param>
    /// <param name="p_is_bitfield">
    /// Whether or not this constant is part of a bitfield.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class_integer_constant(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstStringNamePtr p_enum_name, GDExtensionConstStringNamePtr p_constant_name, GDExtensionInt p_constant_value, GDExtensionBool p_is_bitfield)
    {
        var function = s_classdb_register_extension_class_integer_constant;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_enum_name, p_constant_name, p_constant_value, p_is_bitfield);
    }

    /// <summary>
    /// Registers a property on an extension class in the ClassDB.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_info">
    /// A pointer to a GDExtensionPropertyInfo struct.
    /// </param>
    /// <param name="p_setter">
    /// A pointer to a StringName with the name of the setter method.
    /// </param>
    /// <param name="p_getter">
    /// A pointer to a StringName with the name of the getter method.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class_property(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionPropertyInfo* p_info, GDExtensionConstStringNamePtr p_setter, GDExtensionConstStringNamePtr p_getter)
    {
        var function = s_classdb_register_extension_class_property;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_info, p_setter, p_getter);
    }

    /// <summary>
    /// Registers an indexed property on an extension class in the ClassDB.
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_info">
    /// A pointer to a GDExtensionPropertyInfo struct.
    /// </param>
    /// <param name="p_setter">
    /// A pointer to a StringName with the name of the setter method.
    /// </param>
    /// <param name="p_getter">
    /// A pointer to a StringName with the name of the getter method.
    /// </param>
    /// <param name="p_index">
    /// The index to pass as the first argument to the getter and setter methods.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class_property_indexed(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionPropertyInfo* p_info, GDExtensionConstStringNamePtr p_setter, GDExtensionConstStringNamePtr p_getter, GDExtensionInt p_index)
    {
        var function = s_classdb_register_extension_class_property_indexed;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_info, p_setter, p_getter, p_index);
    }

    /// <summary>
    /// Registers a property group on an extension class in the ClassDB.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_group_name">
    /// A pointer to a String with the group name.
    /// </param>
    /// <param name="p_prefix">
    /// A pointer to a String with the prefix used by properties in this group.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class_property_group(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstStringPtr p_group_name, GDExtensionConstStringPtr p_prefix)
    {
        var function = s_classdb_register_extension_class_property_group;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_group_name, p_prefix);
    }

    /// <summary>
    /// Registers a property subgroup on an extension class in the ClassDB.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_subgroup_name">
    /// A pointer to a String with the subgroup name.
    /// </param>
    /// <param name="p_prefix">
    /// A pointer to a String with the prefix used by properties in this subgroup.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class_property_subgroup(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstStringPtr p_subgroup_name, GDExtensionConstStringPtr p_prefix)
    {
        var function = s_classdb_register_extension_class_property_subgroup;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_subgroup_name, p_prefix);
    }

    /// <summary>
    /// Registers a signal on an extension class in the ClassDB.
    /// Provided structs can be safely freed once the function returns.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="p_signal_name">
    /// A pointer to a StringName with the signal name.
    /// </param>
    /// <param name="p_argument_info">
    /// A pointer to a GDExtensionPropertyInfo struct.
    /// </param>
    /// <param name="p_argument_count">
    /// The number of arguments the signal receives.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_register_extension_class_signal(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name, GDExtensionConstStringNamePtr p_signal_name, GDExtensionPropertyInfo* p_argument_info, GDExtensionInt p_argument_count)
    {
        var function = s_classdb_register_extension_class_signal;
        ThrowIfInvalid(function);
        function(p_library, p_class_name, p_signal_name, p_argument_info, p_argument_count);
    }

    /// <summary>
    /// Unregisters an extension class in the ClassDB.
    /// Unregistering a parent class before a class that inherits it will result in failure. Inheritors must be unregistered first.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void classdb_unregister_extension_class(GDExtensionClassLibraryPtr p_library, GDExtensionConstStringNamePtr p_class_name)
    {
        var function = s_classdb_unregister_extension_class;
        ThrowIfInvalid(function);
        function(p_library, p_class_name);
    }

    /// <summary>
    /// Gets the path to the current GDExtension library.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="r_path">
    /// A pointer to a String which will receive the path.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void get_library_path(GDExtensionClassLibraryPtr p_library, GDExtensionUninitializedStringPtr r_path)
    {
        var function = s_get_library_path;
        ThrowIfInvalid(function);
        function(p_library, r_path);
    }

    /// <summary>
    /// Adds an editor plugin.
    /// It's safe to call during initialization.
    /// </summary>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the name of a class (descending from EditorPlugin) which is already registered with ClassDB.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void editor_add_plugin(GDExtensionConstStringNamePtr p_class_name)
    {
        var function = s_editor_add_plugin;
        ThrowIfInvalid(function);
        function(p_class_name);
    }

    /// <summary>
    /// Removes an editor plugin.
    /// </summary>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the name of a class that was previously added as an editor plugin.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void editor_remove_plugin(GDExtensionConstStringNamePtr p_class_name)
    {
        var function = s_editor_remove_plugin;
        ThrowIfInvalid(function);
        function(p_class_name);
    }

    /// <summary>
    /// Loads new XML-formatted documentation data in the editor.
    /// The provided pointer can be immediately freed once the function returns.
    /// </summary>
    /// <param name="p_data">
    /// A pointer to a UTF-8 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void editor_help_load_xml_from_utf8_chars(byte* p_data)
    {
        var function = s_editor_help_load_xml_from_utf8_chars;
        ThrowIfInvalid(function);
        function(p_data);
    }

    /// <summary>
    /// Loads new XML-formatted documentation data in the editor.
    /// The provided pointer can be immediately freed once the function returns.
    /// </summary>
    /// <param name="p_data">
    /// A pointer to a UTF-8 encoded C string.
    /// </param>
    /// <param name="p_size">
    /// The number of bytes (not code units).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void editor_help_load_xml_from_utf8_chars_and_len(byte* p_data, GDExtensionInt p_size)
    {
        var function = s_editor_help_load_xml_from_utf8_chars_and_len;
        ThrowIfInvalid(function);
        function(p_data, p_size);
    }

    /// <summary>
    /// Registers a callback that Godot can call to get the list of all classes (from ClassDB) that may be used by the calling GDExtension.
    /// This is used by the editor to generate a build profile (in "Tools" > "Engine Compilation Configuration Editor..." > "Detect from project"),
    /// in order to recompile Godot with only the classes used.
    /// In the provided callback, the GDExtension should provide the list of classes that _may_ be used statically, thus the time of invocation shouldn't matter.
    /// If a GDExtension doesn't register a callback, Godot will assume that it could be using any classes.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_callback">
    /// The callback to retrieve the list of classes used.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void editor_register_get_classes_used_callback(GDExtensionClassLibraryPtr p_library, GDExtensionEditorGetClassesUsedCallback p_callback)
    {
        var function = s_editor_register_get_classes_used_callback;
        ThrowIfInvalid(function);
        function(p_library, p_callback);
    }

    /// <summary>
    /// Registers callbacks to be called at different phases of the main loop.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_callbacks">
    /// A pointer to the structure that contains the callbacks.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void register_main_loop_callbacks(GDExtensionClassLibraryPtr p_library, GDExtensionMainLoopCallbacks* p_callbacks)
    {
        var function = s_register_main_loop_callbacks;
        ThrowIfInvalid(function);
        function(p_library, p_callbacks);
    }

    private static GDExtensionInterfaceFunctionPtr Load(GDExtensionInterfaceGetProcAddress getProcAddress, ReadOnlySpan<byte> functionName)
    {
        fixed (byte* p_function_name = functionName)
        {
            return getProcAddress(p_function_name);
        }
    }

    private static void ThrowIfInvalid(void* function)
    {
        if (function == null)
        {
            Throw();
        }

        [DoesNotReturn]
        static void Throw()
        {
            throw new InvalidOperationException("The specified function could not be loaded.");
        }
    }
}
