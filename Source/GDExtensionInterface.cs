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

namespace Godot.NET;

public static unsafe class GDExtensionInterface
{
    private static delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void> get_godot_version;
    private static delegate* unmanaged[Cdecl]<GDExtensionGodotVersion2*, void> get_godot_version2;
    private static delegate* unmanaged[Cdecl]<nuint, void*> mem_alloc;
    private static delegate* unmanaged[Cdecl]<void*, nuint, void*> mem_realloc;
    private static delegate* unmanaged[Cdecl]<void*, void> mem_free;
    private static delegate* unmanaged[Cdecl]<nuint, GDExtensionBool, void*> mem_alloc2;
    private static delegate* unmanaged[Cdecl]<void*, nuint, GDExtensionBool, void*> mem_realloc2;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionBool, void> mem_free2;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> print_error;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> print_error_with_message;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> print_warning;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> print_warning_with_message;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> print_script_error;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> print_script_error_with_message;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, ulong> get_native_struct_size;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr, void> variant_new_copy;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, void> variant_new_nil;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, void> variant_destroy;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> variant_call;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> variant_call_static;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> variant_evaluate;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> variant_set;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> variant_set_named;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> variant_set_keyed;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionInt, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool*, void> variant_set_indexed;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> variant_get;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> variant_get_named;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> variant_get_keyed;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool*, void> variant_get_indexed;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool> variant_iter_init;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool*, GDExtensionBool> variant_iter_next;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> variant_iter_get;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt> variant_hash;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionInt> variant_recursive_hash;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool> variant_hash_compare;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionBool> variant_booleanize;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool, void> variant_duplicate;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionStringPtr, void> variant_stringify;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantType> variant_get_type;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionBool> variant_has_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionBool> variant_has_member;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool> variant_has_key;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDObjectInstanceID> variant_get_object_instance_id;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedStringPtr, void> variant_get_type_name;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool> variant_can_convert;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool> variant_can_convert_strict;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantFromTypeConstructorFunc> get_variant_from_type_constructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionTypeFromVariantConstructorFunc> get_variant_to_type_constructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantGetInternalPtrFunc> variant_get_ptr_internal_getter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, GDExtensionPtrOperatorEvaluator> variant_get_ptr_operator_evaluator;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrBuiltInMethod> variant_get_ptr_builtin_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, int, GDExtensionPtrConstructor> variant_get_ptr_constructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrDestructor> variant_get_ptr_destructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr*, int, GDExtensionCallError*, void> variant_construct;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrSetter> variant_get_ptr_setter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrGetter> variant_get_ptr_getter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedSetter> variant_get_ptr_indexed_setter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedGetter> variant_get_ptr_indexed_getter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedSetter> variant_get_ptr_keyed_setter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedGetter> variant_get_ptr_keyed_getter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedChecker> variant_get_ptr_keyed_checker;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, void> variant_get_constant_value;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrUtilityFunction> variant_get_ptr_utility_function;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void> string_new_with_latin1_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void> string_new_with_utf8_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, ushort*, void> string_new_with_utf16_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, void> string_new_with_utf32_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, void> string_new_with_wide_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> string_new_with_latin1_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> string_new_with_utf8_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, GDExtensionInt> string_new_with_utf8_chars_and_len2;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, ushort*, GDExtensionInt, void> string_new_with_utf16_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, ushort*, GDExtensionInt, GDExtensionBool, GDExtensionInt> string_new_with_utf16_chars_and_len2;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, GDExtensionInt, void> string_new_with_utf32_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void> string_new_with_wide_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt> string_to_latin1_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt> string_to_utf8_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, ushort*, GDExtensionInt, GDExtensionInt> string_to_utf16_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt> string_to_utf32_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, char*, GDExtensionInt, GDExtensionInt> string_to_wide_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*> string_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*> string_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionConstStringPtr, void> string_operator_plus_eq_string;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint, void> string_operator_plus_eq_char;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, byte*, void> string_operator_plus_eq_cstr;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, char*, void> string_operator_plus_eq_wcstr;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint*, void> string_operator_plus_eq_c32str;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, GDExtensionInt> string_resize;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionBool, void> string_name_new_with_latin1_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, void> string_name_new_with_utf8_chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionInt, void> string_name_new_with_utf8_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, nuint, GDExtensionInt> xml_parser_open_buffer;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, ulong, void> file_access_store_buffer;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, byte*, ulong, ulong> file_access_get_buffer;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*> image_ptrw;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*> image_ptr;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolGroupTask, void*, int, int, GDExtensionBool, GDExtensionConstStringPtr, long> worker_thread_pool_add_native_group_task;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolTask, void*, GDExtensionBool, GDExtensionConstStringPtr, long> worker_thread_pool_add_native_task;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, byte*> packed_byte_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, byte*> packed_byte_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, float*> packed_float32_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, float*> packed_float32_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, double*> packed_float64_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, double*> packed_float64_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, int*> packed_int32_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, int*> packed_int32_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, long*> packed_int64_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, long*> packed_int64_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionStringPtr> packed_string_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionStringPtr> packed_string_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> packed_vector2_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> packed_vector2_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> packed_vector3_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> packed_vector3_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> packed_vector4_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> packed_vector4_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> packed_color_array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> packed_color_array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionVariantPtr> array_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionVariantPtr> array_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstTypePtr, void> array_ref;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void> array_set_typed;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr> dictionary_operator_index;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr> dictionary_operator_index_const;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void> dictionary_set_typed;
    private static delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> object_method_bind_call;
    private static delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void> object_method_bind_ptrcall;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void> object_destroy;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> global_get_singleton;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, GDExtensionInstanceBindingCallbacks*, void*> object_get_instance_binding;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void*, GDExtensionInstanceBindingCallbacks*, void> object_set_instance_binding;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void> object_free_instance_binding;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionClassInstancePtr, void> object_set_instance;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionClassLibraryPtr, GDExtensionUninitializedStringNamePtr, GDExtensionBool> object_get_class_name;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, void*, GDExtensionObjectPtr> object_cast_to;
    private static delegate* unmanaged[Cdecl]<GDObjectInstanceID, GDExtensionObjectPtr> object_get_instance_from_id;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDObjectInstanceID> object_get_instance_id;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionConstStringNamePtr, GDExtensionBool> object_has_script_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> object_call_script_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstRefPtr, GDExtensionObjectPtr> ref_get_object;
    private static delegate* unmanaged[Cdecl]<GDExtensionRefPtr, GDExtensionObjectPtr, void> ref_set_object;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> script_instance_create;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> script_instance_create2;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo3*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> script_instance_create3;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstancePtr> placeholder_script_instance_create;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstancePtr, GDExtensionConstTypePtr, GDExtensionConstTypePtr, void> placeholder_script_instance_update;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr> object_get_script_instance;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr, void> object_set_script_instance;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo*, void> callable_custom_create;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo2*, void> callable_custom_create2;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, void*, void*> callable_custom_get_userdata;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> classdb_construct_object;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> classdb_construct_object2;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionMethodBindPtr> classdb_get_method_bind;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void*> classdb_get_class_tag;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo*, void> classdb_register_extension_class;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo2*, void> classdb_register_extension_class2;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo3*, void> classdb_register_extension_class3;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo4*, void> classdb_register_extension_class4;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo5*, void> classdb_register_extension_class5;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassMethodInfo*, void> classdb_register_extension_class_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassVirtualMethodInfo*, void> classdb_register_extension_class_virtual_method;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionBool, void> classdb_register_extension_class_integer_constant;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, void> classdb_register_extension_class_property;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, void> classdb_register_extension_class_property_indexed;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void> classdb_register_extension_class_property_group;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void> classdb_register_extension_class_property_subgroup;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionInt, void> classdb_register_extension_class_signal;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, void> classdb_unregister_extension_class;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionUninitializedStringPtr, void> get_library_path;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void> editor_add_plugin;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void> editor_remove_plugin;
    private static delegate* unmanaged[Cdecl]<byte*, void> editor_help_load_xml_from_utf8_chars;
    private static delegate* unmanaged[Cdecl]<byte*, GDExtensionInt, void> editor_help_load_xml_from_utf8_chars_and_len;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionEditorGetClassesUsedCallback, void> editor_register_get_classes_used_callback;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionMainLoopCallbacks*, void> register_main_loop_callbacks;
}
