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
using Godot.GDExtension;

namespace Godot.InteropServices;

#pragma warning disable CS0618 // Deprecated functions are loaded to maintain backwards compatibility with earlier versions.
public sealed unsafe class GDExtensionInterface
{
    public GDExtensionInterface(GDExtensionInterfaceGetProcAddress getProcAddress)
    {
        ArgumentNullException.ThrowIfNull(getProcAddress.Method, nameof(getProcAddress));
        GetGodotVersion = (GDExtensionInterfaceGetGodotVersion)Load(getProcAddress, "get_godot_version"u8);
        GetGodotVersion2 = (GDExtensionInterfaceGetGodotVersion2)Load(getProcAddress, "get_godot_version2"u8);
        MemAlloc = (GDExtensionInterfaceMemAlloc)Load(getProcAddress, "mem_alloc"u8);
        MemRealloc = (GDExtensionInterfaceMemRealloc)Load(getProcAddress, "mem_realloc"u8);
        MemFree = (GDExtensionInterfaceMemFree)Load(getProcAddress, "mem_free"u8);
        MemAlloc2 = (GDExtensionInterfaceMemAlloc2)Load(getProcAddress, "mem_alloc2"u8);
        MemRealloc2 = (GDExtensionInterfaceMemRealloc2)Load(getProcAddress, "mem_realloc2"u8);
        MemFree2 = (GDExtensionInterfaceMemFree2)Load(getProcAddress, "mem_free2"u8);
        PrintError = (GDExtensionInterfacePrintError)Load(getProcAddress, "print_error"u8);
        PrintErrorWithMessage = (GDExtensionInterfacePrintErrorWithMessage)Load(getProcAddress, "print_error_with_message"u8);
        PrintWarning = (GDExtensionInterfacePrintWarning)Load(getProcAddress, "print_warning"u8);
        PrintWarningWithMessage = (GDExtensionInterfacePrintWarningWithMessage)Load(getProcAddress, "print_warning_with_message"u8);
        PrintScriptError = (GDExtensionInterfacePrintScriptError)Load(getProcAddress, "print_script_error"u8);
        PrintScriptErrorWithMessage = (GDExtensionInterfacePrintScriptErrorWithMessage)Load(getProcAddress, "print_script_error_with_message"u8);
        GetNativeStructSize = (GDExtensionInterfaceGetNativeStructSize)Load(getProcAddress, "get_native_struct_size"u8);
        VariantNewCopy = (GDExtensionInterfaceVariantNewCopy)Load(getProcAddress, "variant_new_copy"u8);
        VariantNewNil = (GDExtensionInterfaceVariantNewNil)Load(getProcAddress, "variant_new_nil"u8);
        VariantDestroy = (GDExtensionInterfaceVariantDestroy)Load(getProcAddress, "variant_destroy"u8);
        VariantCall = (GDExtensionInterfaceVariantCall)Load(getProcAddress, "variant_call"u8);
        VariantCallStatic = (GDExtensionInterfaceVariantCallStatic)Load(getProcAddress, "variant_call_static"u8);
        VariantEvaluate = (GDExtensionInterfaceVariantEvaluate)Load(getProcAddress, "variant_evaluate"u8);
        VariantSet = (GDExtensionInterfaceVariantSet)Load(getProcAddress, "variant_set"u8);
        VariantSetNamed = (GDExtensionInterfaceVariantSetNamed)Load(getProcAddress, "variant_set_named"u8);
        VariantSetKeyed = (GDExtensionInterfaceVariantSetKeyed)Load(getProcAddress, "variant_set_keyed"u8);
        VariantSetIndexed = (GDExtensionInterfaceVariantSetIndexed)Load(getProcAddress, "variant_set_indexed"u8);
        VariantGet = (GDExtensionInterfaceVariantGet)Load(getProcAddress, "variant_get"u8);
        VariantGetNamed = (GDExtensionInterfaceVariantGetNamed)Load(getProcAddress, "variant_get_named"u8);
        VariantGetKeyed = (GDExtensionInterfaceVariantGetKeyed)Load(getProcAddress, "variant_get_keyed"u8);
        VariantGetIndexed = (GDExtensionInterfaceVariantGetIndexed)Load(getProcAddress, "variant_get_indexed"u8);
        VariantIterInit = (GDExtensionInterfaceVariantIterInit)Load(getProcAddress, "variant_iter_init"u8);
        VariantIterNext = (GDExtensionInterfaceVariantIterNext)Load(getProcAddress, "variant_iter_next"u8);
        VariantIterGet = (GDExtensionInterfaceVariantIterGet)Load(getProcAddress, "variant_iter_get"u8);
        VariantHash = (GDExtensionInterfaceVariantHash)Load(getProcAddress, "variant_hash"u8);
        VariantRecursiveHash = (GDExtensionInterfaceVariantRecursiveHash)Load(getProcAddress, "variant_recursive_hash"u8);
        VariantHashCompare = (GDExtensionInterfaceVariantHashCompare)Load(getProcAddress, "variant_hash_compare"u8);
        VariantBooleanize = (GDExtensionInterfaceVariantBooleanize)Load(getProcAddress, "variant_booleanize"u8);
        VariantDuplicate = (GDExtensionInterfaceVariantDuplicate)Load(getProcAddress, "variant_duplicate"u8);
        VariantStringify = (GDExtensionInterfaceVariantStringify)Load(getProcAddress, "variant_stringify"u8);
        VariantGetType = (GDExtensionInterfaceVariantGetType)Load(getProcAddress, "variant_get_type"u8);
        VariantHasMethod = (GDExtensionInterfaceVariantHasMethod)Load(getProcAddress, "variant_has_method"u8);
        VariantHasMember = (GDExtensionInterfaceVariantHasMember)Load(getProcAddress, "variant_has_member"u8);
        VariantHasKey = (GDExtensionInterfaceVariantHasKey)Load(getProcAddress, "variant_has_key"u8);
        VariantGetObjectInstanceId = (GDExtensionInterfaceVariantGetObjectInstanceId)Load(getProcAddress, "variant_get_object_instance_id"u8);
        VariantGetTypeName = (GDExtensionInterfaceVariantGetTypeName)Load(getProcAddress, "variant_get_type_name"u8);
        VariantGetTypeByName = (GDExtensionInterfaceVariantGetTypeByName)Load(getProcAddress, "variant_get_type_by_name"u8);
        VariantCanConvert = (GDExtensionInterfaceVariantCanConvert)Load(getProcAddress, "variant_can_convert"u8);
        VariantCanConvertStrict = (GDExtensionInterfaceVariantCanConvertStrict)Load(getProcAddress, "variant_can_convert_strict"u8);
        GetVariantFromTypeConstructor = (GDExtensionInterfaceGetVariantFromTypeConstructor)Load(getProcAddress, "get_variant_from_type_constructor"u8);
        GetVariantToTypeConstructor = (GDExtensionInterfaceGetVariantToTypeConstructor)Load(getProcAddress, "get_variant_to_type_constructor"u8);
        VariantGetPtrInternalGetter = (GDExtensionInterfaceVariantGetPtrInternalGetter)Load(getProcAddress, "variant_get_ptr_internal_getter"u8);
        VariantGetPtrOperatorEvaluator = (GDExtensionInterfaceVariantGetPtrOperatorEvaluator)Load(getProcAddress, "variant_get_ptr_operator_evaluator"u8);
        VariantGetPtrBuiltinMethod = (GDExtensionInterfaceVariantGetPtrBuiltinMethod)Load(getProcAddress, "variant_get_ptr_builtin_method"u8);
        VariantGetPtrConstructor = (GDExtensionInterfaceVariantGetPtrConstructor)Load(getProcAddress, "variant_get_ptr_constructor"u8);
        VariantGetPtrDestructor = (GDExtensionInterfaceVariantGetPtrDestructor)Load(getProcAddress, "variant_get_ptr_destructor"u8);
        VariantConstruct = (GDExtensionInterfaceVariantConstruct)Load(getProcAddress, "variant_construct"u8);
        VariantGetPtrSetter = (GDExtensionInterfaceVariantGetPtrSetter)Load(getProcAddress, "variant_get_ptr_setter"u8);
        VariantGetPtrGetter = (GDExtensionInterfaceVariantGetPtrGetter)Load(getProcAddress, "variant_get_ptr_getter"u8);
        VariantGetPtrIndexedSetter = (GDExtensionInterfaceVariantGetPtrIndexedSetter)Load(getProcAddress, "variant_get_ptr_indexed_setter"u8);
        VariantGetPtrIndexedGetter = (GDExtensionInterfaceVariantGetPtrIndexedGetter)Load(getProcAddress, "variant_get_ptr_indexed_getter"u8);
        VariantGetPtrKeyedSetter = (GDExtensionInterfaceVariantGetPtrKeyedSetter)Load(getProcAddress, "variant_get_ptr_keyed_setter"u8);
        VariantGetPtrKeyedGetter = (GDExtensionInterfaceVariantGetPtrKeyedGetter)Load(getProcAddress, "variant_get_ptr_keyed_getter"u8);
        VariantGetPtrKeyedChecker = (GDExtensionInterfaceVariantGetPtrKeyedChecker)Load(getProcAddress, "variant_get_ptr_keyed_checker"u8);
        VariantGetConstantValue = (GDExtensionInterfaceVariantGetConstantValue)Load(getProcAddress, "variant_get_constant_value"u8);
        VariantGetPtrUtilityFunction = (GDExtensionInterfaceVariantGetPtrUtilityFunction)Load(getProcAddress, "variant_get_ptr_utility_function"u8);
        StringNewWithLatin1Chars = (GDExtensionInterfaceStringNewWithLatin1Chars)Load(getProcAddress, "string_new_with_latin1_chars"u8);
        StringNewWithUtf8Chars = (GDExtensionInterfaceStringNewWithUtf8Chars)Load(getProcAddress, "string_new_with_utf8_chars"u8);
        StringNewWithUtf16Chars = (GDExtensionInterfaceStringNewWithUtf16Chars)Load(getProcAddress, "string_new_with_utf16_chars"u8);
        StringNewWithUtf32Chars = (GDExtensionInterfaceStringNewWithUtf32Chars)Load(getProcAddress, "string_new_with_utf32_chars"u8);
        StringNewWithWideChars = (GDExtensionInterfaceStringNewWithWideChars)Load(getProcAddress, "string_new_with_wide_chars"u8);
        StringNewWithLatin1CharsAndLen = (GDExtensionInterfaceStringNewWithLatin1CharsAndLen)Load(getProcAddress, "string_new_with_latin1_chars_and_len"u8);
        StringNewWithUtf8CharsAndLen = (GDExtensionInterfaceStringNewWithUtf8CharsAndLen)Load(getProcAddress, "string_new_with_utf8_chars_and_len"u8);
        StringNewWithUtf8CharsAndLen2 = (GDExtensionInterfaceStringNewWithUtf8CharsAndLen2)Load(getProcAddress, "string_new_with_utf8_chars_and_len2"u8);
        StringNewWithUtf16CharsAndLen = (GDExtensionInterfaceStringNewWithUtf16CharsAndLen)Load(getProcAddress, "string_new_with_utf16_chars_and_len"u8);
        StringNewWithUtf16CharsAndLen2 = (GDExtensionInterfaceStringNewWithUtf16CharsAndLen2)Load(getProcAddress, "string_new_with_utf16_chars_and_len2"u8);
        StringNewWithUtf32CharsAndLen = (GDExtensionInterfaceStringNewWithUtf32CharsAndLen)Load(getProcAddress, "string_new_with_utf32_chars_and_len"u8);
        StringNewWithWideCharsAndLen = (GDExtensionInterfaceStringNewWithWideCharsAndLen)Load(getProcAddress, "string_new_with_wide_chars_and_len"u8);
        StringToLatin1Chars = (GDExtensionInterfaceStringToLatin1Chars)Load(getProcAddress, "string_to_latin1_chars"u8);
        StringToUtf8Chars = (GDExtensionInterfaceStringToUtf8Chars)Load(getProcAddress, "string_to_utf8_chars"u8);
        StringToUtf16Chars = (GDExtensionInterfaceStringToUtf16Chars)Load(getProcAddress, "string_to_utf16_chars"u8);
        StringToUtf32Chars = (GDExtensionInterfaceStringToUtf32Chars)Load(getProcAddress, "string_to_utf32_chars"u8);
        StringToWideChars = (GDExtensionInterfaceStringToWideChars)Load(getProcAddress, "string_to_wide_chars"u8);
        StringOperatorIndex = (GDExtensionInterfaceStringOperatorIndex)Load(getProcAddress, "string_operator_index"u8);
        StringOperatorIndexConst = (GDExtensionInterfaceStringOperatorIndexConst)Load(getProcAddress, "string_operator_index_const"u8);
        StringOperatorPlusEqString = (GDExtensionInterfaceStringOperatorPlusEqString)Load(getProcAddress, "string_operator_plus_eq_string"u8);
        StringOperatorPlusEqChar = (GDExtensionInterfaceStringOperatorPlusEqChar)Load(getProcAddress, "string_operator_plus_eq_char"u8);
        StringOperatorPlusEqCstr = (GDExtensionInterfaceStringOperatorPlusEqCstr)Load(getProcAddress, "string_operator_plus_eq_cstr"u8);
        StringOperatorPlusEqWcstr = (GDExtensionInterfaceStringOperatorPlusEqWcstr)Load(getProcAddress, "string_operator_plus_eq_wcstr"u8);
        StringOperatorPlusEqC32Str = (GDExtensionInterfaceStringOperatorPlusEqC32Str)Load(getProcAddress, "string_operator_plus_eq_c32str"u8);
        StringResize = (GDExtensionInterfaceStringResize)Load(getProcAddress, "string_resize"u8);
        StringNameNewWithLatin1Chars = (GDExtensionInterfaceStringNameNewWithLatin1Chars)Load(getProcAddress, "string_name_new_with_latin1_chars"u8);
        StringNameNewWithUtf8Chars = (GDExtensionInterfaceStringNameNewWithUtf8Chars)Load(getProcAddress, "string_name_new_with_utf8_chars"u8);
        StringNameNewWithUtf8CharsAndLen = (GDExtensionInterfaceStringNameNewWithUtf8CharsAndLen)Load(getProcAddress, "string_name_new_with_utf8_chars_and_len"u8);
        XmlParserOpenBuffer = (GDExtensionInterfaceXmlParserOpenBuffer)Load(getProcAddress, "xml_parser_open_buffer"u8);
        FileAccessStoreBuffer = (GDExtensionInterfaceFileAccessStoreBuffer)Load(getProcAddress, "file_access_store_buffer"u8);
        FileAccessGetBuffer = (GDExtensionInterfaceFileAccessGetBuffer)Load(getProcAddress, "file_access_get_buffer"u8);
        ImagePtrw = (GDExtensionInterfaceImagePtrw)Load(getProcAddress, "image_ptrw"u8);
        ImagePtr = (GDExtensionInterfaceImagePtr)Load(getProcAddress, "image_ptr"u8);
        WorkerThreadPoolAddNativeGroupTask = (GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask)Load(getProcAddress, "worker_thread_pool_add_native_group_task"u8);
        WorkerThreadPoolAddNativeTask = (GDExtensionInterfaceWorkerThreadPoolAddNativeTask)Load(getProcAddress, "worker_thread_pool_add_native_task"u8);
        PackedByteArrayOperatorIndex = (GDExtensionInterfacePackedByteArrayOperatorIndex)Load(getProcAddress, "packed_byte_array_operator_index"u8);
        PackedByteArrayOperatorIndexConst = (GDExtensionInterfacePackedByteArrayOperatorIndexConst)Load(getProcAddress, "packed_byte_array_operator_index_const"u8);
        PackedFloat32ArrayOperatorIndex = (GDExtensionInterfacePackedFloat32ArrayOperatorIndex)Load(getProcAddress, "packed_float32_array_operator_index"u8);
        PackedFloat32ArrayOperatorIndexConst = (GDExtensionInterfacePackedFloat32ArrayOperatorIndexConst)Load(getProcAddress, "packed_float32_array_operator_index_const"u8);
        PackedFloat64ArrayOperatorIndex = (GDExtensionInterfacePackedFloat64ArrayOperatorIndex)Load(getProcAddress, "packed_float64_array_operator_index"u8);
        PackedFloat64ArrayOperatorIndexConst = (GDExtensionInterfacePackedFloat64ArrayOperatorIndexConst)Load(getProcAddress, "packed_float64_array_operator_index_const"u8);
        PackedInt32ArrayOperatorIndex = (GDExtensionInterfacePackedInt32ArrayOperatorIndex)Load(getProcAddress, "packed_int32_array_operator_index"u8);
        PackedInt32ArrayOperatorIndexConst = (GDExtensionInterfacePackedInt32ArrayOperatorIndexConst)Load(getProcAddress, "packed_int32_array_operator_index_const"u8);
        PackedInt64ArrayOperatorIndex = (GDExtensionInterfacePackedInt64ArrayOperatorIndex)Load(getProcAddress, "packed_int64_array_operator_index"u8);
        PackedInt64ArrayOperatorIndexConst = (GDExtensionInterfacePackedInt64ArrayOperatorIndexConst)Load(getProcAddress, "packed_int64_array_operator_index_const"u8);
        PackedStringArrayOperatorIndex = (GDExtensionInterfacePackedStringArrayOperatorIndex)Load(getProcAddress, "packed_string_array_operator_index"u8);
        PackedStringArrayOperatorIndexConst = (GDExtensionInterfacePackedStringArrayOperatorIndexConst)Load(getProcAddress, "packed_string_array_operator_index_const"u8);
        PackedVector2ArrayOperatorIndex = (GDExtensionInterfacePackedVector2ArrayOperatorIndex)Load(getProcAddress, "packed_vector2_array_operator_index"u8);
        PackedVector2ArrayOperatorIndexConst = (GDExtensionInterfacePackedVector2ArrayOperatorIndexConst)Load(getProcAddress, "packed_vector2_array_operator_index_const"u8);
        PackedVector3ArrayOperatorIndex = (GDExtensionInterfacePackedVector3ArrayOperatorIndex)Load(getProcAddress, "packed_vector3_array_operator_index"u8);
        PackedVector3ArrayOperatorIndexConst = (GDExtensionInterfacePackedVector3ArrayOperatorIndexConst)Load(getProcAddress, "packed_vector3_array_operator_index_const"u8);
        PackedVector4ArrayOperatorIndex = (GDExtensionInterfacePackedVector4ArrayOperatorIndex)Load(getProcAddress, "packed_vector4_array_operator_index"u8);
        PackedVector4ArrayOperatorIndexConst = (GDExtensionInterfacePackedVector4ArrayOperatorIndexConst)Load(getProcAddress, "packed_vector4_array_operator_index_const"u8);
        PackedColorArrayOperatorIndex = (GDExtensionInterfacePackedColorArrayOperatorIndex)Load(getProcAddress, "packed_color_array_operator_index"u8);
        PackedColorArrayOperatorIndexConst = (GDExtensionInterfacePackedColorArrayOperatorIndexConst)Load(getProcAddress, "packed_color_array_operator_index_const"u8);
        ArrayOperatorIndex = (GDExtensionInterfaceArrayOperatorIndex)Load(getProcAddress, "array_operator_index"u8);
        ArrayOperatorIndexConst = (GDExtensionInterfaceArrayOperatorIndexConst)Load(getProcAddress, "array_operator_index_const"u8);
        ArrayRef = (GDExtensionInterfaceArrayRef)Load(getProcAddress, "array_ref"u8);
        ArraySetTyped = (GDExtensionInterfaceArraySetTyped)Load(getProcAddress, "array_set_typed"u8);
        DictionaryOperatorIndex = (GDExtensionInterfaceDictionaryOperatorIndex)Load(getProcAddress, "dictionary_operator_index"u8);
        DictionaryOperatorIndexConst = (GDExtensionInterfaceDictionaryOperatorIndexConst)Load(getProcAddress, "dictionary_operator_index_const"u8);
        DictionarySetTyped = (GDExtensionInterfaceDictionarySetTyped)Load(getProcAddress, "dictionary_set_typed"u8);
        ObjectMethodBindCall = (GDExtensionInterfaceObjectMethodBindCall)Load(getProcAddress, "object_method_bind_call"u8);
        ObjectMethodBindPtrcall = (GDExtensionInterfaceObjectMethodBindPtrcall)Load(getProcAddress, "object_method_bind_ptrcall"u8);
        ObjectDestroy = (GDExtensionInterfaceObjectDestroy)Load(getProcAddress, "object_destroy"u8);
        GlobalGetSingleton = (GDExtensionInterfaceGlobalGetSingleton)Load(getProcAddress, "global_get_singleton"u8);
        ObjectGetInstanceBinding = (GDExtensionInterfaceObjectGetInstanceBinding)Load(getProcAddress, "object_get_instance_binding"u8);
        ObjectSetInstanceBinding = (GDExtensionInterfaceObjectSetInstanceBinding)Load(getProcAddress, "object_set_instance_binding"u8);
        ObjectFreeInstanceBinding = (GDExtensionInterfaceObjectFreeInstanceBinding)Load(getProcAddress, "object_free_instance_binding"u8);
        ObjectSetInstance = (GDExtensionInterfaceObjectSetInstance)Load(getProcAddress, "object_set_instance"u8);
        ObjectGetClassName = (GDExtensionInterfaceObjectGetClassName)Load(getProcAddress, "object_get_class_name"u8);
        ObjectCastTo = (GDExtensionInterfaceObjectCastTo)Load(getProcAddress, "object_cast_to"u8);
        ObjectGetInstanceFromId = (GDExtensionInterfaceObjectGetInstanceFromId)Load(getProcAddress, "object_get_instance_from_id"u8);
        ObjectGetInstanceId = (GDExtensionInterfaceObjectGetInstanceId)Load(getProcAddress, "object_get_instance_id"u8);
        ObjectHasScriptMethod = (GDExtensionInterfaceObjectHasScriptMethod)Load(getProcAddress, "object_has_script_method"u8);
        ObjectCallScriptMethod = (GDExtensionInterfaceObjectCallScriptMethod)Load(getProcAddress, "object_call_script_method"u8);
        RefGetObject = (GDExtensionInterfaceRefGetObject)Load(getProcAddress, "ref_get_object"u8);
        RefSetObject = (GDExtensionInterfaceRefSetObject)Load(getProcAddress, "ref_set_object"u8);
        ScriptInstanceCreate = (GDExtensionInterfaceScriptInstanceCreate)Load(getProcAddress, "script_instance_create"u8);
        ScriptInstanceCreate2 = (GDExtensionInterfaceScriptInstanceCreate2)Load(getProcAddress, "script_instance_create2"u8);
        ScriptInstanceCreate3 = (GDExtensionInterfaceScriptInstanceCreate3)Load(getProcAddress, "script_instance_create3"u8);
        PlaceholderScriptInstanceCreate = (GDExtensionInterfacePlaceholderScriptInstanceCreate)Load(getProcAddress, "placeholder_script_instance_create"u8);
        PlaceholderScriptInstanceUpdate = (GDExtensionInterfacePlaceholderScriptInstanceUpdate)Load(getProcAddress, "placeholder_script_instance_update"u8);
        ObjectGetScriptInstance = (GDExtensionInterfaceObjectGetScriptInstance)Load(getProcAddress, "object_get_script_instance"u8);
        ObjectSetScriptInstance = (GDExtensionInterfaceObjectSetScriptInstance)Load(getProcAddress, "object_set_script_instance"u8);
        CallableCustomCreate = (GDExtensionInterfaceCallableCustomCreate)Load(getProcAddress, "callable_custom_create"u8);
        CallableCustomCreate2 = (GDExtensionInterfaceCallableCustomCreate2)Load(getProcAddress, "callable_custom_create2"u8);
        CallableCustomGetUserdata = (GDExtensionInterfaceCallableCustomGetUserdata)Load(getProcAddress, "callable_custom_get_userdata"u8);
        ClassdbConstructObject = (GDExtensionInterfaceClassdbConstructObject)Load(getProcAddress, "classdb_construct_object"u8);
        ClassdbConstructObject2 = (GDExtensionInterfaceClassdbConstructObject2)Load(getProcAddress, "classdb_construct_object2"u8);
        ClassdbConstructObject3 = (GDExtensionInterfaceClassdbConstructObject3)Load(getProcAddress, "classdb_construct_object3"u8);
        ClassdbGetMethodBind = (GDExtensionInterfaceClassdbGetMethodBind)Load(getProcAddress, "classdb_get_method_bind"u8);
        ClassdbGetClassTag = (GDExtensionInterfaceClassdbGetClassTag)Load(getProcAddress, "classdb_get_class_tag"u8);
        ClassdbRegisterExtensionClass = (GDExtensionInterfaceClassdbRegisterExtensionClass)Load(getProcAddress, "classdb_register_extension_class"u8);
        ClassdbRegisterExtensionClass2 = (GDExtensionInterfaceClassdbRegisterExtensionClass2)Load(getProcAddress, "classdb_register_extension_class2"u8);
        ClassdbRegisterExtensionClass3 = (GDExtensionInterfaceClassdbRegisterExtensionClass3)Load(getProcAddress, "classdb_register_extension_class3"u8);
        ClassdbRegisterExtensionClass4 = (GDExtensionInterfaceClassdbRegisterExtensionClass4)Load(getProcAddress, "classdb_register_extension_class4"u8);
        ClassdbRegisterExtensionClass5 = (GDExtensionInterfaceClassdbRegisterExtensionClass5)Load(getProcAddress, "classdb_register_extension_class5"u8);
        ClassdbRegisterExtensionClass6 = (GDExtensionInterfaceClassdbRegisterExtensionClass6)Load(getProcAddress, "classdb_register_extension_class6"u8);
        ClassdbRegisterExtensionClassMethod = (GDExtensionInterfaceClassdbRegisterExtensionClassMethod)Load(getProcAddress, "classdb_register_extension_class_method"u8);
        ClassdbRegisterExtensionClassVirtualMethod = (GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod)Load(getProcAddress, "classdb_register_extension_class_virtual_method"u8);
        ClassdbRegisterExtensionClassIntegerConstant = (GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant)Load(getProcAddress, "classdb_register_extension_class_integer_constant"u8);
        ClassdbRegisterExtensionClassProperty = (GDExtensionInterfaceClassdbRegisterExtensionClassProperty)Load(getProcAddress, "classdb_register_extension_class_property"u8);
        ClassdbRegisterExtensionClassPropertyIndexed = (GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed)Load(getProcAddress, "classdb_register_extension_class_property_indexed"u8);
        ClassdbRegisterExtensionClassPropertyGroup = (GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup)Load(getProcAddress, "classdb_register_extension_class_property_group"u8);
        ClassdbRegisterExtensionClassPropertySubgroup = (GDExtensionInterfaceClassdbRegisterExtensionClassPropertySubgroup)Load(getProcAddress, "classdb_register_extension_class_property_subgroup"u8);
        ClassdbRegisterExtensionClassSignal = (GDExtensionInterfaceClassdbRegisterExtensionClassSignal)Load(getProcAddress, "classdb_register_extension_class_signal"u8);
        ClassdbUnregisterExtensionClass = (GDExtensionInterfaceClassdbUnregisterExtensionClass)Load(getProcAddress, "classdb_unregister_extension_class"u8);
        GetLibraryPath = (GDExtensionInterfaceGetLibraryPath)Load(getProcAddress, "get_library_path"u8);
        EditorAddPlugin = (GDExtensionInterfaceEditorAddPlugin)Load(getProcAddress, "editor_add_plugin"u8);
        EditorRemovePlugin = (GDExtensionInterfaceEditorRemovePlugin)Load(getProcAddress, "editor_remove_plugin"u8);
        EditorHelpLoadXmlFromUtf8Chars = (GDExtensionInterfaceEditorHelpLoadXmlFromUtf8Chars)Load(getProcAddress, "editor_help_load_xml_from_utf8_chars"u8);
        EditorHelpLoadXmlFromUtf8CharsAndLen = (GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen)Load(getProcAddress, "editor_help_load_xml_from_utf8_chars_and_len"u8);
        EditorRegisterGetClassesUsedCallback = (GDExtensionInterfaceEditorRegisterGetClassesUsedCallback)Load(getProcAddress, "editor_register_get_classes_used_callback"u8);
        RegisterMainLoopCallbacks = (GDExtensionInterfaceRegisterMainLoopCallbacks)Load(getProcAddress, "register_main_loop_callbacks"u8);
    }

    public GDExtensionInterfaceGetGodotVersion GetGodotVersion { get; }

    public GDExtensionInterfaceGetGodotVersion2 GetGodotVersion2 { get; }

    public GDExtensionInterfaceMemAlloc MemAlloc { get; }

    public GDExtensionInterfaceMemRealloc MemRealloc { get; }

    public GDExtensionInterfaceMemFree MemFree { get; }

    public GDExtensionInterfaceMemAlloc2 MemAlloc2 { get; }

    public GDExtensionInterfaceMemRealloc2 MemRealloc2 { get; }

    public GDExtensionInterfaceMemFree2 MemFree2 { get; }

    public GDExtensionInterfacePrintError PrintError { get; }

    public GDExtensionInterfacePrintErrorWithMessage PrintErrorWithMessage { get; }

    public GDExtensionInterfacePrintWarning PrintWarning { get; }

    public GDExtensionInterfacePrintWarningWithMessage PrintWarningWithMessage { get; }

    public GDExtensionInterfacePrintScriptError PrintScriptError { get; }

    public GDExtensionInterfacePrintScriptErrorWithMessage PrintScriptErrorWithMessage { get; }

    public GDExtensionInterfaceGetNativeStructSize GetNativeStructSize { get; }

    public GDExtensionInterfaceVariantNewCopy VariantNewCopy { get; }

    public GDExtensionInterfaceVariantNewNil VariantNewNil { get; }

    public GDExtensionInterfaceVariantDestroy VariantDestroy { get; }

    public GDExtensionInterfaceVariantCall VariantCall { get; }

    public GDExtensionInterfaceVariantCallStatic VariantCallStatic { get; }

    public GDExtensionInterfaceVariantEvaluate VariantEvaluate { get; }

    public GDExtensionInterfaceVariantSet VariantSet { get; }

    public GDExtensionInterfaceVariantSetNamed VariantSetNamed { get; }

    public GDExtensionInterfaceVariantSetKeyed VariantSetKeyed { get; }

    public GDExtensionInterfaceVariantSetIndexed VariantSetIndexed { get; }

    public GDExtensionInterfaceVariantGet VariantGet { get; }

    public GDExtensionInterfaceVariantGetNamed VariantGetNamed { get; }

    public GDExtensionInterfaceVariantGetKeyed VariantGetKeyed { get; }

    public GDExtensionInterfaceVariantGetIndexed VariantGetIndexed { get; }

    public GDExtensionInterfaceVariantIterInit VariantIterInit { get; }

    public GDExtensionInterfaceVariantIterNext VariantIterNext { get; }

    public GDExtensionInterfaceVariantIterGet VariantIterGet { get; }

    public GDExtensionInterfaceVariantHash VariantHash { get; }

    public GDExtensionInterfaceVariantRecursiveHash VariantRecursiveHash { get; }

    public GDExtensionInterfaceVariantHashCompare VariantHashCompare { get; }

    public GDExtensionInterfaceVariantBooleanize VariantBooleanize { get; }

    public GDExtensionInterfaceVariantDuplicate VariantDuplicate { get; }

    public GDExtensionInterfaceVariantStringify VariantStringify { get; }

    public GDExtensionInterfaceVariantGetType VariantGetType { get; }

    public GDExtensionInterfaceVariantHasMethod VariantHasMethod { get; }

    public GDExtensionInterfaceVariantHasMember VariantHasMember { get; }

    public GDExtensionInterfaceVariantHasKey VariantHasKey { get; }

    public GDExtensionInterfaceVariantGetObjectInstanceId VariantGetObjectInstanceId { get; }

    public GDExtensionInterfaceVariantGetTypeName VariantGetTypeName { get; }

    public GDExtensionInterfaceVariantGetTypeByName VariantGetTypeByName { get; }

    public GDExtensionInterfaceVariantCanConvert VariantCanConvert { get; }

    public GDExtensionInterfaceVariantCanConvertStrict VariantCanConvertStrict { get; }

    public GDExtensionInterfaceGetVariantFromTypeConstructor GetVariantFromTypeConstructor { get; }

    public GDExtensionInterfaceGetVariantToTypeConstructor GetVariantToTypeConstructor { get; }

    public GDExtensionInterfaceVariantGetPtrInternalGetter VariantGetPtrInternalGetter { get; }

    public GDExtensionInterfaceVariantGetPtrOperatorEvaluator VariantGetPtrOperatorEvaluator { get; }

    public GDExtensionInterfaceVariantGetPtrBuiltinMethod VariantGetPtrBuiltinMethod { get; }

    public GDExtensionInterfaceVariantGetPtrConstructor VariantGetPtrConstructor { get; }

    public GDExtensionInterfaceVariantGetPtrDestructor VariantGetPtrDestructor { get; }

    public GDExtensionInterfaceVariantConstruct VariantConstruct { get; }

    public GDExtensionInterfaceVariantGetPtrSetter VariantGetPtrSetter { get; }

    public GDExtensionInterfaceVariantGetPtrGetter VariantGetPtrGetter { get; }

    public GDExtensionInterfaceVariantGetPtrIndexedSetter VariantGetPtrIndexedSetter { get; }

    public GDExtensionInterfaceVariantGetPtrIndexedGetter VariantGetPtrIndexedGetter { get; }

    public GDExtensionInterfaceVariantGetPtrKeyedSetter VariantGetPtrKeyedSetter { get; }

    public GDExtensionInterfaceVariantGetPtrKeyedGetter VariantGetPtrKeyedGetter { get; }

    public GDExtensionInterfaceVariantGetPtrKeyedChecker VariantGetPtrKeyedChecker { get; }

    public GDExtensionInterfaceVariantGetConstantValue VariantGetConstantValue { get; }

    public GDExtensionInterfaceVariantGetPtrUtilityFunction VariantGetPtrUtilityFunction { get; }

    public GDExtensionInterfaceStringNewWithLatin1Chars StringNewWithLatin1Chars { get; }

    public GDExtensionInterfaceStringNewWithUtf8Chars StringNewWithUtf8Chars { get; }

    public GDExtensionInterfaceStringNewWithUtf16Chars StringNewWithUtf16Chars { get; }

    public GDExtensionInterfaceStringNewWithUtf32Chars StringNewWithUtf32Chars { get; }

    public GDExtensionInterfaceStringNewWithWideChars StringNewWithWideChars { get; }

    public GDExtensionInterfaceStringNewWithLatin1CharsAndLen StringNewWithLatin1CharsAndLen { get; }

    public GDExtensionInterfaceStringNewWithUtf8CharsAndLen StringNewWithUtf8CharsAndLen { get; }

    public GDExtensionInterfaceStringNewWithUtf8CharsAndLen2 StringNewWithUtf8CharsAndLen2 { get; }

    public GDExtensionInterfaceStringNewWithUtf16CharsAndLen StringNewWithUtf16CharsAndLen { get; }

    public GDExtensionInterfaceStringNewWithUtf16CharsAndLen2 StringNewWithUtf16CharsAndLen2 { get; }

    public GDExtensionInterfaceStringNewWithUtf32CharsAndLen StringNewWithUtf32CharsAndLen { get; }

    public GDExtensionInterfaceStringNewWithWideCharsAndLen StringNewWithWideCharsAndLen { get; }

    public GDExtensionInterfaceStringToLatin1Chars StringToLatin1Chars { get; }

    public GDExtensionInterfaceStringToUtf8Chars StringToUtf8Chars { get; }

    public GDExtensionInterfaceStringToUtf16Chars StringToUtf16Chars { get; }

    public GDExtensionInterfaceStringToUtf32Chars StringToUtf32Chars { get; }

    public GDExtensionInterfaceStringToWideChars StringToWideChars { get; }

    public GDExtensionInterfaceStringOperatorIndex StringOperatorIndex { get; }

    public GDExtensionInterfaceStringOperatorIndexConst StringOperatorIndexConst { get; }

    public GDExtensionInterfaceStringOperatorPlusEqString StringOperatorPlusEqString { get; }

    public GDExtensionInterfaceStringOperatorPlusEqChar StringOperatorPlusEqChar { get; }

    public GDExtensionInterfaceStringOperatorPlusEqCstr StringOperatorPlusEqCstr { get; }

    public GDExtensionInterfaceStringOperatorPlusEqWcstr StringOperatorPlusEqWcstr { get; }

    public GDExtensionInterfaceStringOperatorPlusEqC32Str StringOperatorPlusEqC32Str { get; }

    public GDExtensionInterfaceStringResize StringResize { get; }

    public GDExtensionInterfaceStringNameNewWithLatin1Chars StringNameNewWithLatin1Chars { get; }

    public GDExtensionInterfaceStringNameNewWithUtf8Chars StringNameNewWithUtf8Chars { get; }

    public GDExtensionInterfaceStringNameNewWithUtf8CharsAndLen StringNameNewWithUtf8CharsAndLen { get; }

    public GDExtensionInterfaceXmlParserOpenBuffer XmlParserOpenBuffer { get; }

    public GDExtensionInterfaceFileAccessStoreBuffer FileAccessStoreBuffer { get; }

    public GDExtensionInterfaceFileAccessGetBuffer FileAccessGetBuffer { get; }

    public GDExtensionInterfaceImagePtrw ImagePtrw { get; }

    public GDExtensionInterfaceImagePtr ImagePtr { get; }

    public GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask WorkerThreadPoolAddNativeGroupTask { get; }

    public GDExtensionInterfaceWorkerThreadPoolAddNativeTask WorkerThreadPoolAddNativeTask { get; }

    public GDExtensionInterfacePackedByteArrayOperatorIndex PackedByteArrayOperatorIndex { get; }

    public GDExtensionInterfacePackedByteArrayOperatorIndexConst PackedByteArrayOperatorIndexConst { get; }

    public GDExtensionInterfacePackedFloat32ArrayOperatorIndex PackedFloat32ArrayOperatorIndex { get; }

    public GDExtensionInterfacePackedFloat32ArrayOperatorIndexConst PackedFloat32ArrayOperatorIndexConst { get; }

    public GDExtensionInterfacePackedFloat64ArrayOperatorIndex PackedFloat64ArrayOperatorIndex { get; }

    public GDExtensionInterfacePackedFloat64ArrayOperatorIndexConst PackedFloat64ArrayOperatorIndexConst { get; }

    public GDExtensionInterfacePackedInt32ArrayOperatorIndex PackedInt32ArrayOperatorIndex { get; }

    public GDExtensionInterfacePackedInt32ArrayOperatorIndexConst PackedInt32ArrayOperatorIndexConst { get; }

    public GDExtensionInterfacePackedInt64ArrayOperatorIndex PackedInt64ArrayOperatorIndex { get; }

    public GDExtensionInterfacePackedInt64ArrayOperatorIndexConst PackedInt64ArrayOperatorIndexConst { get; }

    public GDExtensionInterfacePackedStringArrayOperatorIndex PackedStringArrayOperatorIndex { get; }

    public GDExtensionInterfacePackedStringArrayOperatorIndexConst PackedStringArrayOperatorIndexConst { get; }

    public GDExtensionInterfacePackedVector2ArrayOperatorIndex PackedVector2ArrayOperatorIndex { get; }

    public GDExtensionInterfacePackedVector2ArrayOperatorIndexConst PackedVector2ArrayOperatorIndexConst { get; }

    public GDExtensionInterfacePackedVector3ArrayOperatorIndex PackedVector3ArrayOperatorIndex { get; }

    public GDExtensionInterfacePackedVector3ArrayOperatorIndexConst PackedVector3ArrayOperatorIndexConst { get; }

    public GDExtensionInterfacePackedVector4ArrayOperatorIndex PackedVector4ArrayOperatorIndex { get; }

    public GDExtensionInterfacePackedVector4ArrayOperatorIndexConst PackedVector4ArrayOperatorIndexConst { get; }

    public GDExtensionInterfacePackedColorArrayOperatorIndex PackedColorArrayOperatorIndex { get; }

    public GDExtensionInterfacePackedColorArrayOperatorIndexConst PackedColorArrayOperatorIndexConst { get; }

    public GDExtensionInterfaceArrayOperatorIndex ArrayOperatorIndex { get; }

    public GDExtensionInterfaceArrayOperatorIndexConst ArrayOperatorIndexConst { get; }

    public GDExtensionInterfaceArrayRef ArrayRef { get; }

    public GDExtensionInterfaceArraySetTyped ArraySetTyped { get; }

    public GDExtensionInterfaceDictionaryOperatorIndex DictionaryOperatorIndex { get; }

    public GDExtensionInterfaceDictionaryOperatorIndexConst DictionaryOperatorIndexConst { get; }

    public GDExtensionInterfaceDictionarySetTyped DictionarySetTyped { get; }

    public GDExtensionInterfaceObjectMethodBindCall ObjectMethodBindCall { get; }

    public GDExtensionInterfaceObjectMethodBindPtrcall ObjectMethodBindPtrcall { get; }

    public GDExtensionInterfaceObjectDestroy ObjectDestroy { get; }

    public GDExtensionInterfaceGlobalGetSingleton GlobalGetSingleton { get; }

    public GDExtensionInterfaceObjectGetInstanceBinding ObjectGetInstanceBinding { get; }

    public GDExtensionInterfaceObjectSetInstanceBinding ObjectSetInstanceBinding { get; }

    public GDExtensionInterfaceObjectFreeInstanceBinding ObjectFreeInstanceBinding { get; }

    public GDExtensionInterfaceObjectSetInstance ObjectSetInstance { get; }

    public GDExtensionInterfaceObjectGetClassName ObjectGetClassName { get; }

    public GDExtensionInterfaceObjectCastTo ObjectCastTo { get; }

    public GDExtensionInterfaceObjectGetInstanceFromId ObjectGetInstanceFromId { get; }

    public GDExtensionInterfaceObjectGetInstanceId ObjectGetInstanceId { get; }

    public GDExtensionInterfaceObjectHasScriptMethod ObjectHasScriptMethod { get; }

    public GDExtensionInterfaceObjectCallScriptMethod ObjectCallScriptMethod { get; }

    public GDExtensionInterfaceRefGetObject RefGetObject { get; }

    public GDExtensionInterfaceRefSetObject RefSetObject { get; }

    public GDExtensionInterfaceScriptInstanceCreate ScriptInstanceCreate { get; }

    public GDExtensionInterfaceScriptInstanceCreate2 ScriptInstanceCreate2 { get; }

    public GDExtensionInterfaceScriptInstanceCreate3 ScriptInstanceCreate3 { get; }

    public GDExtensionInterfacePlaceholderScriptInstanceCreate PlaceholderScriptInstanceCreate { get; }

    public GDExtensionInterfacePlaceholderScriptInstanceUpdate PlaceholderScriptInstanceUpdate { get; }

    public GDExtensionInterfaceObjectGetScriptInstance ObjectGetScriptInstance { get; }

    public GDExtensionInterfaceObjectSetScriptInstance ObjectSetScriptInstance { get; }

    public GDExtensionInterfaceCallableCustomCreate CallableCustomCreate { get; }

    public GDExtensionInterfaceCallableCustomCreate2 CallableCustomCreate2 { get; }

    public GDExtensionInterfaceCallableCustomGetUserdata CallableCustomGetUserdata { get; }

    public GDExtensionInterfaceClassdbConstructObject ClassdbConstructObject { get; }

    public GDExtensionInterfaceClassdbConstructObject2 ClassdbConstructObject2 { get; }

    public GDExtensionInterfaceClassdbConstructObject3 ClassdbConstructObject3 { get; }

    public GDExtensionInterfaceClassdbGetMethodBind ClassdbGetMethodBind { get; }

    public GDExtensionInterfaceClassdbGetClassTag ClassdbGetClassTag { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClass ClassdbRegisterExtensionClass { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClass2 ClassdbRegisterExtensionClass2 { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClass3 ClassdbRegisterExtensionClass3 { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClass4 ClassdbRegisterExtensionClass4 { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClass5 ClassdbRegisterExtensionClass5 { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClass6 ClassdbRegisterExtensionClass6 { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClassMethod ClassdbRegisterExtensionClassMethod { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod ClassdbRegisterExtensionClassVirtualMethod { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant ClassdbRegisterExtensionClassIntegerConstant { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClassProperty ClassdbRegisterExtensionClassProperty { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed ClassdbRegisterExtensionClassPropertyIndexed { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup ClassdbRegisterExtensionClassPropertyGroup { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClassPropertySubgroup ClassdbRegisterExtensionClassPropertySubgroup { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClassSignal ClassdbRegisterExtensionClassSignal { get; }

    public GDExtensionInterfaceClassdbUnregisterExtensionClass ClassdbUnregisterExtensionClass { get; }

    public GDExtensionInterfaceGetLibraryPath GetLibraryPath { get; }

    public GDExtensionInterfaceEditorAddPlugin EditorAddPlugin { get; }

    public GDExtensionInterfaceEditorRemovePlugin EditorRemovePlugin { get; }

    public GDExtensionInterfaceEditorHelpLoadXmlFromUtf8Chars EditorHelpLoadXmlFromUtf8Chars { get; }

    public GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen EditorHelpLoadXmlFromUtf8CharsAndLen { get; }

    public GDExtensionInterfaceEditorRegisterGetClassesUsedCallback EditorRegisterGetClassesUsedCallback { get; }

    public GDExtensionInterfaceRegisterMainLoopCallbacks RegisterMainLoopCallbacks { get; }

    private static GDExtensionInterfaceFunctionPtr Load(GDExtensionInterfaceGetProcAddress getProcAddress, ReadOnlySpan<byte> functionName)
    {
        fixed (byte* p_function_name = functionName)
        {
            GDExtensionInterfaceFunctionPtr function = getProcAddress.Invoke(p_function_name);

            if (function.Method == null)
            {
                throw new ArgumentException($"Failed to load \"{new string((sbyte*)p_function_name)}\" from the specified address loader.", nameof(getProcAddress));
            }

            return function;
        }
    }
}
#pragma warning disable CS0618 // Deprecated functions are loaded to maintain backwards compatibility with earlier versions.
