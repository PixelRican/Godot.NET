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

#pragma warning disable CS0618 // Deprecated functions are loaded to maintain backwards compatibility.
public sealed unsafe class GDExtensionInterface
{
    private readonly GDExtensionInterfaceGetGodotVersion _getGodotVersion;
    private readonly GDExtensionInterfaceGetGodotVersion2 _getGodotVersion2;
    private readonly GDExtensionInterfaceMemAlloc _memAlloc;
    private readonly GDExtensionInterfaceMemRealloc _memRealloc;
    private readonly GDExtensionInterfaceMemFree _memFree;
    private readonly GDExtensionInterfaceMemAlloc2 _memAlloc2;
    private readonly GDExtensionInterfaceMemRealloc2 _memRealloc2;
    private readonly GDExtensionInterfaceMemFree2 _memFree2;
    private readonly GDExtensionInterfacePrintError _printError;
    private readonly GDExtensionInterfacePrintErrorWithMessage _printErrorWithMessage;
    private readonly GDExtensionInterfacePrintWarning _printWarning;
    private readonly GDExtensionInterfacePrintWarningWithMessage _printWarningWithMessage;
    private readonly GDExtensionInterfacePrintScriptError _printScriptError;
    private readonly GDExtensionInterfacePrintScriptErrorWithMessage _printScriptErrorWithMessage;
    private readonly GDExtensionInterfaceGetNativeStructSize _getNativeStructSize;
    private readonly GDExtensionInterfaceVariantNewCopy _variantNewCopy;
    private readonly GDExtensionInterfaceVariantNewNil _variantNewNil;
    private readonly GDExtensionInterfaceVariantDestroy _variantDestroy;
    private readonly GDExtensionInterfaceVariantCall _variantCall;
    private readonly GDExtensionInterfaceVariantCallStatic _variantCallStatic;
    private readonly GDExtensionInterfaceVariantEvaluate _variantEvaluate;
    private readonly GDExtensionInterfaceVariantSet _variantSet;
    private readonly GDExtensionInterfaceVariantSetNamed _variantSetNamed;
    private readonly GDExtensionInterfaceVariantSetKeyed _variantSetKeyed;
    private readonly GDExtensionInterfaceVariantSetIndexed _variantSetIndexed;
    private readonly GDExtensionInterfaceVariantGet _variantGet;
    private readonly GDExtensionInterfaceVariantGetNamed _variantGetNamed;
    private readonly GDExtensionInterfaceVariantGetKeyed _variantGetKeyed;
    private readonly GDExtensionInterfaceVariantGetIndexed _variantGetIndexed;
    private readonly GDExtensionInterfaceVariantIterInit _variantIterInit;
    private readonly GDExtensionInterfaceVariantIterNext _variantIterNext;
    private readonly GDExtensionInterfaceVariantIterGet _variantIterGet;
    private readonly GDExtensionInterfaceVariantHash _variantHash;
    private readonly GDExtensionInterfaceVariantRecursiveHash _variantRecursiveHash;
    private readonly GDExtensionInterfaceVariantHashCompare _variantHashCompare;
    private readonly GDExtensionInterfaceVariantBooleanize _variantBooleanize;
    private readonly GDExtensionInterfaceVariantDuplicate _variantDuplicate;
    private readonly GDExtensionInterfaceVariantStringify _variantStringify;
    private readonly GDExtensionInterfaceVariantGetType _variantGetType;
    private readonly GDExtensionInterfaceVariantHasMethod _variantHasMethod;
    private readonly GDExtensionInterfaceVariantHasMember _variantHasMember;
    private readonly GDExtensionInterfaceVariantHasKey _variantHasKey;
    private readonly GDExtensionInterfaceVariantGetObjectInstanceId _variantGetObjectInstanceId;
    private readonly GDExtensionInterfaceVariantGetTypeName _variantGetTypeName;
    private readonly GDExtensionInterfaceVariantGetTypeByName _variantGetTypeByName;
    private readonly GDExtensionInterfaceVariantCanConvert _variantCanConvert;
    private readonly GDExtensionInterfaceVariantCanConvertStrict _variantCanConvertStrict;
    private readonly GDExtensionInterfaceGetVariantFromTypeConstructor _getVariantFromTypeConstructor;
    private readonly GDExtensionInterfaceGetVariantToTypeConstructor _getVariantToTypeConstructor;
    private readonly GDExtensionInterfaceVariantGetPtrInternalGetter _variantGetPtrInternalGetter;
    private readonly GDExtensionInterfaceVariantGetPtrOperatorEvaluator _variantGetPtrOperatorEvaluator;
    private readonly GDExtensionInterfaceVariantGetPtrBuiltinMethod _variantGetPtrBuiltinMethod;
    private readonly GDExtensionInterfaceVariantGetPtrConstructor _variantGetPtrConstructor;
    private readonly GDExtensionInterfaceVariantGetPtrDestructor _variantGetPtrDestructor;
    private readonly GDExtensionInterfaceVariantConstruct _variantConstruct;
    private readonly GDExtensionInterfaceVariantGetPtrSetter _variantGetPtrSetter;
    private readonly GDExtensionInterfaceVariantGetPtrGetter _variantGetPtrGetter;
    private readonly GDExtensionInterfaceVariantGetPtrIndexedSetter _variantGetPtrIndexedSetter;
    private readonly GDExtensionInterfaceVariantGetPtrIndexedGetter _variantGetPtrIndexedGetter;
    private readonly GDExtensionInterfaceVariantGetPtrKeyedSetter _variantGetPtrKeyedSetter;
    private readonly GDExtensionInterfaceVariantGetPtrKeyedGetter _variantGetPtrKeyedGetter;
    private readonly GDExtensionInterfaceVariantGetPtrKeyedChecker _variantGetPtrKeyedChecker;
    private readonly GDExtensionInterfaceVariantGetConstantValue _variantGetConstantValue;
    private readonly GDExtensionInterfaceVariantGetPtrUtilityFunction _variantGetPtrUtilityFunction;
    private readonly GDExtensionInterfaceStringNewWithLatin1Chars _stringNewWithLatin1Chars;
    private readonly GDExtensionInterfaceStringNewWithUtf8Chars _stringNewWithUtf8Chars;
    private readonly GDExtensionInterfaceStringNewWithUtf16Chars _stringNewWithUtf16Chars;
    private readonly GDExtensionInterfaceStringNewWithUtf32Chars _stringNewWithUtf32Chars;
    private readonly GDExtensionInterfaceStringNewWithWideChars _stringNewWithWideChars;
    private readonly GDExtensionInterfaceStringNewWithLatin1CharsAndLen _stringNewWithLatin1CharsAndLen;
    private readonly GDExtensionInterfaceStringNewWithUtf8CharsAndLen _stringNewWithUtf8CharsAndLen;
    private readonly GDExtensionInterfaceStringNewWithUtf8CharsAndLen2 _stringNewWithUtf8CharsAndLen2;
    private readonly GDExtensionInterfaceStringNewWithUtf16CharsAndLen _stringNewWithUtf16CharsAndLen;
    private readonly GDExtensionInterfaceStringNewWithUtf16CharsAndLen2 _stringNewWithUtf16CharsAndLen2;
    private readonly GDExtensionInterfaceStringNewWithUtf32CharsAndLen _stringNewWithUtf32CharsAndLen;
    private readonly GDExtensionInterfaceStringNewWithWideCharsAndLen _stringNewWithWideCharsAndLen;
    private readonly GDExtensionInterfaceStringToLatin1Chars _stringToLatin1Chars;
    private readonly GDExtensionInterfaceStringToUtf8Chars _stringToUtf8Chars;
    private readonly GDExtensionInterfaceStringToUtf16Chars _stringToUtf16Chars;
    private readonly GDExtensionInterfaceStringToUtf32Chars _stringToUtf32Chars;
    private readonly GDExtensionInterfaceStringToWideChars _stringToWideChars;
    private readonly GDExtensionInterfaceStringOperatorIndex _stringOperatorIndex;
    private readonly GDExtensionInterfaceStringOperatorIndexConst _stringOperatorIndexConst;
    private readonly GDExtensionInterfaceStringOperatorPlusEqString _stringOperatorPlusEqString;
    private readonly GDExtensionInterfaceStringOperatorPlusEqChar _stringOperatorPlusEqChar;
    private readonly GDExtensionInterfaceStringOperatorPlusEqCstr _stringOperatorPlusEqCstr;
    private readonly GDExtensionInterfaceStringOperatorPlusEqWcstr _stringOperatorPlusEqWcstr;
    private readonly GDExtensionInterfaceStringOperatorPlusEqC32Str _stringOperatorPlusEqC32Str;
    private readonly GDExtensionInterfaceStringResize _stringResize;
    private readonly GDExtensionInterfaceStringNameNewWithLatin1Chars _stringNameNewWithLatin1Chars;
    private readonly GDExtensionInterfaceStringNameNewWithUtf8Chars _stringNameNewWithUtf8Chars;
    private readonly GDExtensionInterfaceStringNameNewWithUtf8CharsAndLen _stringNameNewWithUtf8CharsAndLen;
    private readonly GDExtensionInterfaceXmlParserOpenBuffer _xmlParserOpenBuffer;
    private readonly GDExtensionInterfaceFileAccessStoreBuffer _fileAccessStoreBuffer;
    private readonly GDExtensionInterfaceFileAccessGetBuffer _fileAccessGetBuffer;
    private readonly GDExtensionInterfaceImagePtrw _imagePtrw;
    private readonly GDExtensionInterfaceImagePtr _imagePtr;
    private readonly GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask _workerThreadPoolAddNativeGroupTask;
    private readonly GDExtensionInterfaceWorkerThreadPoolAddNativeTask _workerThreadPoolAddNativeTask;
    private readonly GDExtensionInterfacePackedByteArrayOperatorIndex _packedByteArrayOperatorIndex;
    private readonly GDExtensionInterfacePackedByteArrayOperatorIndexConst _packedByteArrayOperatorIndexConst;
    private readonly GDExtensionInterfacePackedFloat32ArrayOperatorIndex _packedFloat32ArrayOperatorIndex;
    private readonly GDExtensionInterfacePackedFloat32ArrayOperatorIndexConst _packedFloat32ArrayOperatorIndexConst;
    private readonly GDExtensionInterfacePackedFloat64ArrayOperatorIndex _packedFloat64ArrayOperatorIndex;
    private readonly GDExtensionInterfacePackedFloat64ArrayOperatorIndexConst _packedFloat64ArrayOperatorIndexConst;
    private readonly GDExtensionInterfacePackedInt32ArrayOperatorIndex _packedInt32ArrayOperatorIndex;
    private readonly GDExtensionInterfacePackedInt32ArrayOperatorIndexConst _packedInt32ArrayOperatorIndexConst;
    private readonly GDExtensionInterfacePackedInt64ArrayOperatorIndex _packedInt64ArrayOperatorIndex;
    private readonly GDExtensionInterfacePackedInt64ArrayOperatorIndexConst _packedInt64ArrayOperatorIndexConst;
    private readonly GDExtensionInterfacePackedStringArrayOperatorIndex _packedStringArrayOperatorIndex;
    private readonly GDExtensionInterfacePackedStringArrayOperatorIndexConst _packedStringArrayOperatorIndexConst;
    private readonly GDExtensionInterfacePackedVector2ArrayOperatorIndex _packedVector2ArrayOperatorIndex;
    private readonly GDExtensionInterfacePackedVector2ArrayOperatorIndexConst _packedVector2ArrayOperatorIndexConst;
    private readonly GDExtensionInterfacePackedVector3ArrayOperatorIndex _packedVector3ArrayOperatorIndex;
    private readonly GDExtensionInterfacePackedVector3ArrayOperatorIndexConst _packedVector3ArrayOperatorIndexConst;
    private readonly GDExtensionInterfacePackedVector4ArrayOperatorIndex _packedVector4ArrayOperatorIndex;
    private readonly GDExtensionInterfacePackedVector4ArrayOperatorIndexConst _packedVector4ArrayOperatorIndexConst;
    private readonly GDExtensionInterfacePackedColorArrayOperatorIndex _packedColorArrayOperatorIndex;
    private readonly GDExtensionInterfacePackedColorArrayOperatorIndexConst _packedColorArrayOperatorIndexConst;
    private readonly GDExtensionInterfaceArrayOperatorIndex _arrayOperatorIndex;
    private readonly GDExtensionInterfaceArrayOperatorIndexConst _arrayOperatorIndexConst;
    private readonly GDExtensionInterfaceArrayRef _arrayRef;
    private readonly GDExtensionInterfaceArraySetTyped _arraySetTyped;
    private readonly GDExtensionInterfaceDictionaryOperatorIndex _dictionaryOperatorIndex;
    private readonly GDExtensionInterfaceDictionaryOperatorIndexConst _dictionaryOperatorIndexConst;
    private readonly GDExtensionInterfaceDictionarySetTyped _dictionarySetTyped;
    private readonly GDExtensionInterfaceObjectMethodBindCall _objectMethodBindCall;
    private readonly GDExtensionInterfaceObjectMethodBindPtrcall _objectMethodBindPtrcall;
    private readonly GDExtensionInterfaceObjectDestroy _objectDestroy;
    private readonly GDExtensionInterfaceGlobalGetSingleton _globalGetSingleton;
    private readonly GDExtensionInterfaceObjectGetInstanceBinding _objectGetInstanceBinding;
    private readonly GDExtensionInterfaceObjectSetInstanceBinding _objectSetInstanceBinding;
    private readonly GDExtensionInterfaceObjectFreeInstanceBinding _objectFreeInstanceBinding;
    private readonly GDExtensionInterfaceObjectSetInstance _objectSetInstance;
    private readonly GDExtensionInterfaceObjectGetClassName _objectGetClassName;
    private readonly GDExtensionInterfaceObjectCastTo _objectCastTo;
    private readonly GDExtensionInterfaceObjectGetInstanceFromId _objectGetInstanceFromId;
    private readonly GDExtensionInterfaceObjectGetInstanceId _objectGetInstanceId;
    private readonly GDExtensionInterfaceObjectHasScriptMethod _objectHasScriptMethod;
    private readonly GDExtensionInterfaceObjectCallScriptMethod _objectCallScriptMethod;
    private readonly GDExtensionInterfaceRefGetObject _refGetObject;
    private readonly GDExtensionInterfaceRefSetObject _refSetObject;
    private readonly GDExtensionInterfaceScriptInstanceCreate _scriptInstanceCreate;
    private readonly GDExtensionInterfaceScriptInstanceCreate2 _scriptInstanceCreate2;
    private readonly GDExtensionInterfaceScriptInstanceCreate3 _scriptInstanceCreate3;
    private readonly GDExtensionInterfacePlaceholderScriptInstanceCreate _placeholderScriptInstanceCreate;
    private readonly GDExtensionInterfacePlaceholderScriptInstanceUpdate _placeholderScriptInstanceUpdate;
    private readonly GDExtensionInterfaceObjectGetScriptInstance _objectGetScriptInstance;
    private readonly GDExtensionInterfaceObjectSetScriptInstance _objectSetScriptInstance;
    private readonly GDExtensionInterfaceCallableCustomCreate _callableCustomCreate;
    private readonly GDExtensionInterfaceCallableCustomCreate2 _callableCustomCreate2;
    private readonly GDExtensionInterfaceCallableCustomGetUserdata _callableCustomGetUserdata;
    private readonly GDExtensionInterfaceClassdbConstructObject _classdbConstructObject;
    private readonly GDExtensionInterfaceClassdbConstructObject2 _classdbConstructObject2;
    private readonly GDExtensionInterfaceClassdbConstructObject3 _classdbConstructObject3;
    private readonly GDExtensionInterfaceClassdbGetMethodBind _classdbGetMethodBind;
    private readonly GDExtensionInterfaceClassdbGetClassTag _classdbGetClassTag;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClass _classdbRegisterExtensionClass;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClass2 _classdbRegisterExtensionClass2;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClass3 _classdbRegisterExtensionClass3;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClass4 _classdbRegisterExtensionClass4;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClass5 _classdbRegisterExtensionClass5;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClass6 _classdbRegisterExtensionClass6;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClassMethod _classdbRegisterExtensionClassMethod;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod _classdbRegisterExtensionClassVirtualMethod;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant _classdbRegisterExtensionClassIntegerConstant;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClassProperty _classdbRegisterExtensionClassProperty;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed _classdbRegisterExtensionClassPropertyIndexed;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup _classdbRegisterExtensionClassPropertyGroup;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClassPropertySubgroup _classdbRegisterExtensionClassPropertySubgroup;
    private readonly GDExtensionInterfaceClassdbRegisterExtensionClassSignal _classdbRegisterExtensionClassSignal;
    private readonly GDExtensionInterfaceClassdbUnregisterExtensionClass _classdbUnregisterExtensionClass;
    private readonly GDExtensionInterfaceGetLibraryPath _getLibraryPath;
    private readonly GDExtensionInterfaceEditorAddPlugin _editorAddPlugin;
    private readonly GDExtensionInterfaceEditorRemovePlugin _editorRemovePlugin;
    private readonly GDExtensionInterfaceEditorHelpLoadXmlFromUtf8Chars _editorHelpLoadXmlFromUtf8Chars;
    private readonly GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen _editorHelpLoadXmlFromUtf8CharsAndLen;
    private readonly GDExtensionInterfaceEditorRegisterGetClassesUsedCallback _editorRegisterGetClassesUsedCallback;
    private readonly GDExtensionInterfaceRegisterMainLoopCallbacks _registerMainLoopCallbacks;

    public GDExtensionInterface(GDExtensionInterfaceGetProcAddress getProcAddress)
    {
        ArgumentNullException.ThrowIfNull(getProcAddress.Method, nameof(getProcAddress));
        _getGodotVersion = (GDExtensionInterfaceGetGodotVersion)Load(getProcAddress, "get_godot_version"u8);
        _getGodotVersion2 = (GDExtensionInterfaceGetGodotVersion2)Load(getProcAddress, "get_godot_version2"u8);
        _memAlloc = (GDExtensionInterfaceMemAlloc)Load(getProcAddress, "mem_alloc"u8);
        _memRealloc = (GDExtensionInterfaceMemRealloc)Load(getProcAddress, "mem_realloc"u8);
        _memFree = (GDExtensionInterfaceMemFree)Load(getProcAddress, "mem_free"u8);
        _memAlloc2 = (GDExtensionInterfaceMemAlloc2)Load(getProcAddress, "mem_alloc2"u8);
        _memRealloc2 = (GDExtensionInterfaceMemRealloc2)Load(getProcAddress, "mem_realloc2"u8);
        _memFree2 = (GDExtensionInterfaceMemFree2)Load(getProcAddress, "mem_free2"u8);
        _printError = (GDExtensionInterfacePrintError)Load(getProcAddress, "print_error"u8);
        _printErrorWithMessage = (GDExtensionInterfacePrintErrorWithMessage)Load(getProcAddress, "print_error_with_message"u8);
        _printWarning = (GDExtensionInterfacePrintWarning)Load(getProcAddress, "print_warning"u8);
        _printWarningWithMessage = (GDExtensionInterfacePrintWarningWithMessage)Load(getProcAddress, "print_warning_with_message"u8);
        _printScriptError = (GDExtensionInterfacePrintScriptError)Load(getProcAddress, "print_script_error"u8);
        _printScriptErrorWithMessage = (GDExtensionInterfacePrintScriptErrorWithMessage)Load(getProcAddress, "print_script_error_with_message"u8);
        _getNativeStructSize = (GDExtensionInterfaceGetNativeStructSize)Load(getProcAddress, "get_native_struct_size"u8);
        _variantNewCopy = (GDExtensionInterfaceVariantNewCopy)Load(getProcAddress, "variant_new_copy"u8);
        _variantNewNil = (GDExtensionInterfaceVariantNewNil)Load(getProcAddress, "variant_new_nil"u8);
        _variantDestroy = (GDExtensionInterfaceVariantDestroy)Load(getProcAddress, "variant_destroy"u8);
        _variantCall = (GDExtensionInterfaceVariantCall)Load(getProcAddress, "variant_call"u8);
        _variantCallStatic = (GDExtensionInterfaceVariantCallStatic)Load(getProcAddress, "variant_call_static"u8);
        _variantEvaluate = (GDExtensionInterfaceVariantEvaluate)Load(getProcAddress, "variant_evaluate"u8);
        _variantSet = (GDExtensionInterfaceVariantSet)Load(getProcAddress, "variant_set"u8);
        _variantSetNamed = (GDExtensionInterfaceVariantSetNamed)Load(getProcAddress, "variant_set_named"u8);
        _variantSetKeyed = (GDExtensionInterfaceVariantSetKeyed)Load(getProcAddress, "variant_set_keyed"u8);
        _variantSetIndexed = (GDExtensionInterfaceVariantSetIndexed)Load(getProcAddress, "variant_set_indexed"u8);
        _variantGet = (GDExtensionInterfaceVariantGet)Load(getProcAddress, "variant_get"u8);
        _variantGetNamed = (GDExtensionInterfaceVariantGetNamed)Load(getProcAddress, "variant_get_named"u8);
        _variantGetKeyed = (GDExtensionInterfaceVariantGetKeyed)Load(getProcAddress, "variant_get_keyed"u8);
        _variantGetIndexed = (GDExtensionInterfaceVariantGetIndexed)Load(getProcAddress, "variant_get_indexed"u8);
        _variantIterInit = (GDExtensionInterfaceVariantIterInit)Load(getProcAddress, "variant_iter_init"u8);
        _variantIterNext = (GDExtensionInterfaceVariantIterNext)Load(getProcAddress, "variant_iter_next"u8);
        _variantIterGet = (GDExtensionInterfaceVariantIterGet)Load(getProcAddress, "variant_iter_get"u8);
        _variantHash = (GDExtensionInterfaceVariantHash)Load(getProcAddress, "variant_hash"u8);
        _variantRecursiveHash = (GDExtensionInterfaceVariantRecursiveHash)Load(getProcAddress, "variant_recursive_hash"u8);
        _variantHashCompare = (GDExtensionInterfaceVariantHashCompare)Load(getProcAddress, "variant_hash_compare"u8);
        _variantBooleanize = (GDExtensionInterfaceVariantBooleanize)Load(getProcAddress, "variant_booleanize"u8);
        _variantDuplicate = (GDExtensionInterfaceVariantDuplicate)Load(getProcAddress, "variant_duplicate"u8);
        _variantStringify = (GDExtensionInterfaceVariantStringify)Load(getProcAddress, "variant_stringify"u8);
        _variantGetType = (GDExtensionInterfaceVariantGetType)Load(getProcAddress, "variant_get_type"u8);
        _variantHasMethod = (GDExtensionInterfaceVariantHasMethod)Load(getProcAddress, "variant_has_method"u8);
        _variantHasMember = (GDExtensionInterfaceVariantHasMember)Load(getProcAddress, "variant_has_member"u8);
        _variantHasKey = (GDExtensionInterfaceVariantHasKey)Load(getProcAddress, "variant_has_key"u8);
        _variantGetObjectInstanceId = (GDExtensionInterfaceVariantGetObjectInstanceId)Load(getProcAddress, "variant_get_object_instance_id"u8);
        _variantGetTypeName = (GDExtensionInterfaceVariantGetTypeName)Load(getProcAddress, "variant_get_type_name"u8);
        _variantGetTypeByName = (GDExtensionInterfaceVariantGetTypeByName)Load(getProcAddress, "variant_get_type_by_name"u8);
        _variantCanConvert = (GDExtensionInterfaceVariantCanConvert)Load(getProcAddress, "variant_can_convert"u8);
        _variantCanConvertStrict = (GDExtensionInterfaceVariantCanConvertStrict)Load(getProcAddress, "variant_can_convert_strict"u8);
        _getVariantFromTypeConstructor = (GDExtensionInterfaceGetVariantFromTypeConstructor)Load(getProcAddress, "get_variant_from_type_constructor"u8);
        _getVariantToTypeConstructor = (GDExtensionInterfaceGetVariantToTypeConstructor)Load(getProcAddress, "get_variant_to_type_constructor"u8);
        _variantGetPtrInternalGetter = (GDExtensionInterfaceVariantGetPtrInternalGetter)Load(getProcAddress, "variant_get_ptr_internal_getter"u8);
        _variantGetPtrOperatorEvaluator = (GDExtensionInterfaceVariantGetPtrOperatorEvaluator)Load(getProcAddress, "variant_get_ptr_operator_evaluator"u8);
        _variantGetPtrBuiltinMethod = (GDExtensionInterfaceVariantGetPtrBuiltinMethod)Load(getProcAddress, "variant_get_ptr_builtin_method"u8);
        _variantGetPtrConstructor = (GDExtensionInterfaceVariantGetPtrConstructor)Load(getProcAddress, "variant_get_ptr_constructor"u8);
        _variantGetPtrDestructor = (GDExtensionInterfaceVariantGetPtrDestructor)Load(getProcAddress, "variant_get_ptr_destructor"u8);
        _variantConstruct = (GDExtensionInterfaceVariantConstruct)Load(getProcAddress, "variant_construct"u8);
        _variantGetPtrSetter = (GDExtensionInterfaceVariantGetPtrSetter)Load(getProcAddress, "variant_get_ptr_setter"u8);
        _variantGetPtrGetter = (GDExtensionInterfaceVariantGetPtrGetter)Load(getProcAddress, "variant_get_ptr_getter"u8);
        _variantGetPtrIndexedSetter = (GDExtensionInterfaceVariantGetPtrIndexedSetter)Load(getProcAddress, "variant_get_ptr_indexed_setter"u8);
        _variantGetPtrIndexedGetter = (GDExtensionInterfaceVariantGetPtrIndexedGetter)Load(getProcAddress, "variant_get_ptr_indexed_getter"u8);
        _variantGetPtrKeyedSetter = (GDExtensionInterfaceVariantGetPtrKeyedSetter)Load(getProcAddress, "variant_get_ptr_keyed_setter"u8);
        _variantGetPtrKeyedGetter = (GDExtensionInterfaceVariantGetPtrKeyedGetter)Load(getProcAddress, "variant_get_ptr_keyed_getter"u8);
        _variantGetPtrKeyedChecker = (GDExtensionInterfaceVariantGetPtrKeyedChecker)Load(getProcAddress, "variant_get_ptr_keyed_checker"u8);
        _variantGetConstantValue = (GDExtensionInterfaceVariantGetConstantValue)Load(getProcAddress, "variant_get_constant_value"u8);
        _variantGetPtrUtilityFunction = (GDExtensionInterfaceVariantGetPtrUtilityFunction)Load(getProcAddress, "variant_get_ptr_utility_function"u8);
        _stringNewWithLatin1Chars = (GDExtensionInterfaceStringNewWithLatin1Chars)Load(getProcAddress, "string_new_with_latin1_chars"u8);
        _stringNewWithUtf8Chars = (GDExtensionInterfaceStringNewWithUtf8Chars)Load(getProcAddress, "string_new_with_utf8_chars"u8);
        _stringNewWithUtf16Chars = (GDExtensionInterfaceStringNewWithUtf16Chars)Load(getProcAddress, "string_new_with_utf16_chars"u8);
        _stringNewWithUtf32Chars = (GDExtensionInterfaceStringNewWithUtf32Chars)Load(getProcAddress, "string_new_with_utf32_chars"u8);
        _stringNewWithWideChars = (GDExtensionInterfaceStringNewWithWideChars)Load(getProcAddress, "string_new_with_wide_chars"u8);
        _stringNewWithLatin1CharsAndLen = (GDExtensionInterfaceStringNewWithLatin1CharsAndLen)Load(getProcAddress, "string_new_with_latin1_chars_and_len"u8);
        _stringNewWithUtf8CharsAndLen = (GDExtensionInterfaceStringNewWithUtf8CharsAndLen)Load(getProcAddress, "string_new_with_utf8_chars_and_len"u8);
        _stringNewWithUtf8CharsAndLen2 = (GDExtensionInterfaceStringNewWithUtf8CharsAndLen2)Load(getProcAddress, "string_new_with_utf8_chars_and_len2"u8);
        _stringNewWithUtf16CharsAndLen = (GDExtensionInterfaceStringNewWithUtf16CharsAndLen)Load(getProcAddress, "string_new_with_utf16_chars_and_len"u8);
        _stringNewWithUtf16CharsAndLen2 = (GDExtensionInterfaceStringNewWithUtf16CharsAndLen2)Load(getProcAddress, "string_new_with_utf16_chars_and_len2"u8);
        _stringNewWithUtf32CharsAndLen = (GDExtensionInterfaceStringNewWithUtf32CharsAndLen)Load(getProcAddress, "string_new_with_utf32_chars_and_len"u8);
        _stringNewWithWideCharsAndLen = (GDExtensionInterfaceStringNewWithWideCharsAndLen)Load(getProcAddress, "string_new_with_wide_chars_and_len"u8);
        _stringToLatin1Chars = (GDExtensionInterfaceStringToLatin1Chars)Load(getProcAddress, "string_to_latin1_chars"u8);
        _stringToUtf8Chars = (GDExtensionInterfaceStringToUtf8Chars)Load(getProcAddress, "string_to_utf8_chars"u8);
        _stringToUtf16Chars = (GDExtensionInterfaceStringToUtf16Chars)Load(getProcAddress, "string_to_utf16_chars"u8);
        _stringToUtf32Chars = (GDExtensionInterfaceStringToUtf32Chars)Load(getProcAddress, "string_to_utf32_chars"u8);
        _stringToWideChars = (GDExtensionInterfaceStringToWideChars)Load(getProcAddress, "string_to_wide_chars"u8);
        _stringOperatorIndex = (GDExtensionInterfaceStringOperatorIndex)Load(getProcAddress, "string_operator_index"u8);
        _stringOperatorIndexConst = (GDExtensionInterfaceStringOperatorIndexConst)Load(getProcAddress, "string_operator_index_const"u8);
        _stringOperatorPlusEqString = (GDExtensionInterfaceStringOperatorPlusEqString)Load(getProcAddress, "string_operator_plus_eq_string"u8);
        _stringOperatorPlusEqChar = (GDExtensionInterfaceStringOperatorPlusEqChar)Load(getProcAddress, "string_operator_plus_eq_char"u8);
        _stringOperatorPlusEqCstr = (GDExtensionInterfaceStringOperatorPlusEqCstr)Load(getProcAddress, "string_operator_plus_eq_cstr"u8);
        _stringOperatorPlusEqWcstr = (GDExtensionInterfaceStringOperatorPlusEqWcstr)Load(getProcAddress, "string_operator_plus_eq_wcstr"u8);
        _stringOperatorPlusEqC32Str = (GDExtensionInterfaceStringOperatorPlusEqC32Str)Load(getProcAddress, "string_operator_plus_eq_c32str"u8);
        _stringResize = (GDExtensionInterfaceStringResize)Load(getProcAddress, "string_resize"u8);
        _stringNameNewWithLatin1Chars = (GDExtensionInterfaceStringNameNewWithLatin1Chars)Load(getProcAddress, "string_name_new_with_latin1_chars"u8);
        _stringNameNewWithUtf8Chars = (GDExtensionInterfaceStringNameNewWithUtf8Chars)Load(getProcAddress, "string_name_new_with_utf8_chars"u8);
        _stringNameNewWithUtf8CharsAndLen = (GDExtensionInterfaceStringNameNewWithUtf8CharsAndLen)Load(getProcAddress, "string_name_new_with_utf8_chars_and_len"u8);
        _xmlParserOpenBuffer = (GDExtensionInterfaceXmlParserOpenBuffer)Load(getProcAddress, "xml_parser_open_buffer"u8);
        _fileAccessStoreBuffer = (GDExtensionInterfaceFileAccessStoreBuffer)Load(getProcAddress, "file_access_store_buffer"u8);
        _fileAccessGetBuffer = (GDExtensionInterfaceFileAccessGetBuffer)Load(getProcAddress, "file_access_get_buffer"u8);
        _imagePtrw = (GDExtensionInterfaceImagePtrw)Load(getProcAddress, "image_ptrw"u8);
        _imagePtr = (GDExtensionInterfaceImagePtr)Load(getProcAddress, "image_ptr"u8);
        _workerThreadPoolAddNativeGroupTask = (GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask)Load(getProcAddress, "worker_thread_pool_add_native_group_task"u8);
        _workerThreadPoolAddNativeTask = (GDExtensionInterfaceWorkerThreadPoolAddNativeTask)Load(getProcAddress, "worker_thread_pool_add_native_task"u8);
        _packedByteArrayOperatorIndex = (GDExtensionInterfacePackedByteArrayOperatorIndex)Load(getProcAddress, "packed_byte_array_operator_index"u8);
        _packedByteArrayOperatorIndexConst = (GDExtensionInterfacePackedByteArrayOperatorIndexConst)Load(getProcAddress, "packed_byte_array_operator_index_const"u8);
        _packedFloat32ArrayOperatorIndex = (GDExtensionInterfacePackedFloat32ArrayOperatorIndex)Load(getProcAddress, "packed_float32_array_operator_index"u8);
        _packedFloat32ArrayOperatorIndexConst = (GDExtensionInterfacePackedFloat32ArrayOperatorIndexConst)Load(getProcAddress, "packed_float32_array_operator_index_const"u8);
        _packedFloat64ArrayOperatorIndex = (GDExtensionInterfacePackedFloat64ArrayOperatorIndex)Load(getProcAddress, "packed_float64_array_operator_index"u8);
        _packedFloat64ArrayOperatorIndexConst = (GDExtensionInterfacePackedFloat64ArrayOperatorIndexConst)Load(getProcAddress, "packed_float64_array_operator_index_const"u8);
        _packedInt32ArrayOperatorIndex = (GDExtensionInterfacePackedInt32ArrayOperatorIndex)Load(getProcAddress, "packed_int32_array_operator_index"u8);
        _packedInt32ArrayOperatorIndexConst = (GDExtensionInterfacePackedInt32ArrayOperatorIndexConst)Load(getProcAddress, "packed_int32_array_operator_index_const"u8);
        _packedInt64ArrayOperatorIndex = (GDExtensionInterfacePackedInt64ArrayOperatorIndex)Load(getProcAddress, "packed_int64_array_operator_index"u8);
        _packedInt64ArrayOperatorIndexConst = (GDExtensionInterfacePackedInt64ArrayOperatorIndexConst)Load(getProcAddress, "packed_int64_array_operator_index_const"u8);
        _packedStringArrayOperatorIndex = (GDExtensionInterfacePackedStringArrayOperatorIndex)Load(getProcAddress, "packed_string_array_operator_index"u8);
        _packedStringArrayOperatorIndexConst = (GDExtensionInterfacePackedStringArrayOperatorIndexConst)Load(getProcAddress, "packed_string_array_operator_index_const"u8);
        _packedVector2ArrayOperatorIndex = (GDExtensionInterfacePackedVector2ArrayOperatorIndex)Load(getProcAddress, "packed_vector2_array_operator_index"u8);
        _packedVector2ArrayOperatorIndexConst = (GDExtensionInterfacePackedVector2ArrayOperatorIndexConst)Load(getProcAddress, "packed_vector2_array_operator_index_const"u8);
        _packedVector3ArrayOperatorIndex = (GDExtensionInterfacePackedVector3ArrayOperatorIndex)Load(getProcAddress, "packed_vector3_array_operator_index"u8);
        _packedVector3ArrayOperatorIndexConst = (GDExtensionInterfacePackedVector3ArrayOperatorIndexConst)Load(getProcAddress, "packed_vector3_array_operator_index_const"u8);
        _packedVector4ArrayOperatorIndex = (GDExtensionInterfacePackedVector4ArrayOperatorIndex)Load(getProcAddress, "packed_vector4_array_operator_index"u8);
        _packedVector4ArrayOperatorIndexConst = (GDExtensionInterfacePackedVector4ArrayOperatorIndexConst)Load(getProcAddress, "packed_vector4_array_operator_index_const"u8);
        _packedColorArrayOperatorIndex = (GDExtensionInterfacePackedColorArrayOperatorIndex)Load(getProcAddress, "packed_color_array_operator_index"u8);
        _packedColorArrayOperatorIndexConst = (GDExtensionInterfacePackedColorArrayOperatorIndexConst)Load(getProcAddress, "packed_color_array_operator_index_const"u8);
        _arrayOperatorIndex = (GDExtensionInterfaceArrayOperatorIndex)Load(getProcAddress, "array_operator_index"u8);
        _arrayOperatorIndexConst = (GDExtensionInterfaceArrayOperatorIndexConst)Load(getProcAddress, "array_operator_index_const"u8);
        _arrayRef = (GDExtensionInterfaceArrayRef)Load(getProcAddress, "array_ref"u8);
        _arraySetTyped = (GDExtensionInterfaceArraySetTyped)Load(getProcAddress, "array_set_typed"u8);
        _dictionaryOperatorIndex = (GDExtensionInterfaceDictionaryOperatorIndex)Load(getProcAddress, "dictionary_operator_index"u8);
        _dictionaryOperatorIndexConst = (GDExtensionInterfaceDictionaryOperatorIndexConst)Load(getProcAddress, "dictionary_operator_index_const"u8);
        _dictionarySetTyped = (GDExtensionInterfaceDictionarySetTyped)Load(getProcAddress, "dictionary_set_typed"u8);
        _objectMethodBindCall = (GDExtensionInterfaceObjectMethodBindCall)Load(getProcAddress, "object_method_bind_call"u8);
        _objectMethodBindPtrcall = (GDExtensionInterfaceObjectMethodBindPtrcall)Load(getProcAddress, "object_method_bind_ptrcall"u8);
        _objectDestroy = (GDExtensionInterfaceObjectDestroy)Load(getProcAddress, "object_destroy"u8);
        _globalGetSingleton = (GDExtensionInterfaceGlobalGetSingleton)Load(getProcAddress, "global_get_singleton"u8);
        _objectGetInstanceBinding = (GDExtensionInterfaceObjectGetInstanceBinding)Load(getProcAddress, "object_get_instance_binding"u8);
        _objectSetInstanceBinding = (GDExtensionInterfaceObjectSetInstanceBinding)Load(getProcAddress, "object_set_instance_binding"u8);
        _objectFreeInstanceBinding = (GDExtensionInterfaceObjectFreeInstanceBinding)Load(getProcAddress, "object_free_instance_binding"u8);
        _objectSetInstance = (GDExtensionInterfaceObjectSetInstance)Load(getProcAddress, "object_set_instance"u8);
        _objectGetClassName = (GDExtensionInterfaceObjectGetClassName)Load(getProcAddress, "object_get_class_name"u8);
        _objectCastTo = (GDExtensionInterfaceObjectCastTo)Load(getProcAddress, "object_cast_to"u8);
        _objectGetInstanceFromId = (GDExtensionInterfaceObjectGetInstanceFromId)Load(getProcAddress, "object_get_instance_from_id"u8);
        _objectGetInstanceId = (GDExtensionInterfaceObjectGetInstanceId)Load(getProcAddress, "object_get_instance_id"u8);
        _objectHasScriptMethod = (GDExtensionInterfaceObjectHasScriptMethod)Load(getProcAddress, "object_has_script_method"u8);
        _objectCallScriptMethod = (GDExtensionInterfaceObjectCallScriptMethod)Load(getProcAddress, "object_call_script_method"u8);
        _refGetObject = (GDExtensionInterfaceRefGetObject)Load(getProcAddress, "ref_get_object"u8);
        _refSetObject = (GDExtensionInterfaceRefSetObject)Load(getProcAddress, "ref_set_object"u8);
        _scriptInstanceCreate = (GDExtensionInterfaceScriptInstanceCreate)Load(getProcAddress, "script_instance_create"u8);
        _scriptInstanceCreate2 = (GDExtensionInterfaceScriptInstanceCreate2)Load(getProcAddress, "script_instance_create2"u8);
        _scriptInstanceCreate3 = (GDExtensionInterfaceScriptInstanceCreate3)Load(getProcAddress, "script_instance_create3"u8);
        _placeholderScriptInstanceCreate = (GDExtensionInterfacePlaceholderScriptInstanceCreate)Load(getProcAddress, "placeholder_script_instance_create"u8);
        _placeholderScriptInstanceUpdate = (GDExtensionInterfacePlaceholderScriptInstanceUpdate)Load(getProcAddress, "placeholder_script_instance_update"u8);
        _objectGetScriptInstance = (GDExtensionInterfaceObjectGetScriptInstance)Load(getProcAddress, "object_get_script_instance"u8);
        _objectSetScriptInstance = (GDExtensionInterfaceObjectSetScriptInstance)Load(getProcAddress, "object_set_script_instance"u8);
        _callableCustomCreate = (GDExtensionInterfaceCallableCustomCreate)Load(getProcAddress, "callable_custom_create"u8);
        _callableCustomCreate2 = (GDExtensionInterfaceCallableCustomCreate2)Load(getProcAddress, "callable_custom_create2"u8);
        _callableCustomGetUserdata = (GDExtensionInterfaceCallableCustomGetUserdata)Load(getProcAddress, "callable_custom_get_userdata"u8);
        _classdbConstructObject = (GDExtensionInterfaceClassdbConstructObject)Load(getProcAddress, "classdb_construct_object"u8);
        _classdbConstructObject2 = (GDExtensionInterfaceClassdbConstructObject2)Load(getProcAddress, "classdb_construct_object2"u8);
        _classdbConstructObject3 = (GDExtensionInterfaceClassdbConstructObject3)Load(getProcAddress, "classdb_construct_object3"u8);
        _classdbGetMethodBind = (GDExtensionInterfaceClassdbGetMethodBind)Load(getProcAddress, "classdb_get_method_bind"u8);
        _classdbGetClassTag = (GDExtensionInterfaceClassdbGetClassTag)Load(getProcAddress, "classdb_get_class_tag"u8);
        _classdbRegisterExtensionClass = (GDExtensionInterfaceClassdbRegisterExtensionClass)Load(getProcAddress, "classdb_register_extension_class"u8);
        _classdbRegisterExtensionClass2 = (GDExtensionInterfaceClassdbRegisterExtensionClass2)Load(getProcAddress, "classdb_register_extension_class2"u8);
        _classdbRegisterExtensionClass3 = (GDExtensionInterfaceClassdbRegisterExtensionClass3)Load(getProcAddress, "classdb_register_extension_class3"u8);
        _classdbRegisterExtensionClass4 = (GDExtensionInterfaceClassdbRegisterExtensionClass4)Load(getProcAddress, "classdb_register_extension_class4"u8);
        _classdbRegisterExtensionClass5 = (GDExtensionInterfaceClassdbRegisterExtensionClass5)Load(getProcAddress, "classdb_register_extension_class5"u8);
        _classdbRegisterExtensionClass6 = (GDExtensionInterfaceClassdbRegisterExtensionClass6)Load(getProcAddress, "classdb_register_extension_class6"u8);
        _classdbRegisterExtensionClassMethod = (GDExtensionInterfaceClassdbRegisterExtensionClassMethod)Load(getProcAddress, "classdb_register_extension_class_method"u8);
        _classdbRegisterExtensionClassVirtualMethod = (GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod)Load(getProcAddress, "classdb_register_extension_class_virtual_method"u8);
        _classdbRegisterExtensionClassIntegerConstant = (GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant)Load(getProcAddress, "classdb_register_extension_class_integer_constant"u8);
        _classdbRegisterExtensionClassProperty = (GDExtensionInterfaceClassdbRegisterExtensionClassProperty)Load(getProcAddress, "classdb_register_extension_class_property"u8);
        _classdbRegisterExtensionClassPropertyIndexed = (GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed)Load(getProcAddress, "classdb_register_extension_class_property_indexed"u8);
        _classdbRegisterExtensionClassPropertyGroup = (GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup)Load(getProcAddress, "classdb_register_extension_class_property_group"u8);
        _classdbRegisterExtensionClassPropertySubgroup = (GDExtensionInterfaceClassdbRegisterExtensionClassPropertySubgroup)Load(getProcAddress, "classdb_register_extension_class_property_subgroup"u8);
        _classdbRegisterExtensionClassSignal = (GDExtensionInterfaceClassdbRegisterExtensionClassSignal)Load(getProcAddress, "classdb_register_extension_class_signal"u8);
        _classdbUnregisterExtensionClass = (GDExtensionInterfaceClassdbUnregisterExtensionClass)Load(getProcAddress, "classdb_unregister_extension_class"u8);
        _getLibraryPath = (GDExtensionInterfaceGetLibraryPath)Load(getProcAddress, "get_library_path"u8);
        _editorAddPlugin = (GDExtensionInterfaceEditorAddPlugin)Load(getProcAddress, "editor_add_plugin"u8);
        _editorRemovePlugin = (GDExtensionInterfaceEditorRemovePlugin)Load(getProcAddress, "editor_remove_plugin"u8);
        _editorHelpLoadXmlFromUtf8Chars = (GDExtensionInterfaceEditorHelpLoadXmlFromUtf8Chars)Load(getProcAddress, "editor_help_load_xml_from_utf8_chars"u8);
        _editorHelpLoadXmlFromUtf8CharsAndLen = (GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen)Load(getProcAddress, "editor_help_load_xml_from_utf8_chars_and_len"u8);
        _editorRegisterGetClassesUsedCallback = (GDExtensionInterfaceEditorRegisterGetClassesUsedCallback)Load(getProcAddress, "editor_register_get_classes_used_callback"u8);
        _registerMainLoopCallbacks = (GDExtensionInterfaceRegisterMainLoopCallbacks)Load(getProcAddress, "register_main_loop_callbacks"u8);
    }

    public GDExtensionInterfaceGetGodotVersion GetGodotVersion
    {
        get => _getGodotVersion;
    }

    public GDExtensionInterfaceGetGodotVersion2 GetGodotVersion2
    {
        get => _getGodotVersion2;
    }

    public GDExtensionInterfaceMemAlloc MemAlloc
    {
        get => _memAlloc;
    }

    public GDExtensionInterfaceMemRealloc MemRealloc
    {
        get => _memRealloc;
    }

    public GDExtensionInterfaceMemFree MemFree
    {
        get => _memFree;
    }

    public GDExtensionInterfaceMemAlloc2 MemAlloc2
    {
        get => _memAlloc2;
    }

    public GDExtensionInterfaceMemRealloc2 MemRealloc2
    {
        get => _memRealloc2;
    }

    public GDExtensionInterfaceMemFree2 MemFree2
    {
        get => _memFree2;
    }

    public GDExtensionInterfacePrintError PrintError
    {
        get => _printError;
    }

    public GDExtensionInterfacePrintErrorWithMessage PrintErrorWithMessage
    {
        get => _printErrorWithMessage;
    }

    public GDExtensionInterfacePrintWarning PrintWarning
    {
        get => _printWarning;
    }

    public GDExtensionInterfacePrintWarningWithMessage PrintWarningWithMessage
    {
        get => _printWarningWithMessage;
    }

    public GDExtensionInterfacePrintScriptError PrintScriptError
    {
        get => _printScriptError;
    }

    public GDExtensionInterfacePrintScriptErrorWithMessage PrintScriptErrorWithMessage
    {
        get => _printScriptErrorWithMessage;
    }

    public GDExtensionInterfaceGetNativeStructSize GetNativeStructSize
    {
        get => _getNativeStructSize;
    }

    public GDExtensionInterfaceVariantNewCopy VariantNewCopy
    {
        get => _variantNewCopy;
    }

    public GDExtensionInterfaceVariantNewNil VariantNewNil
    {
        get => _variantNewNil;
    }

    public GDExtensionInterfaceVariantDestroy VariantDestroy
    {
        get => _variantDestroy;
    }

    public GDExtensionInterfaceVariantCall VariantCall
    {
        get => _variantCall;
    }

    public GDExtensionInterfaceVariantCallStatic VariantCallStatic
    {
        get => _variantCallStatic;
    }

    public GDExtensionInterfaceVariantEvaluate VariantEvaluate
    {
        get => _variantEvaluate;
    }

    public GDExtensionInterfaceVariantSet VariantSet
    {
        get => _variantSet;
    }

    public GDExtensionInterfaceVariantSetNamed VariantSetNamed
    {
        get => _variantSetNamed;
    }

    public GDExtensionInterfaceVariantSetKeyed VariantSetKeyed
    {
        get => _variantSetKeyed;
    }

    public GDExtensionInterfaceVariantSetIndexed VariantSetIndexed
    {
        get => _variantSetIndexed;
    }

    public GDExtensionInterfaceVariantGet VariantGet
    {
        get => _variantGet;
    }

    public GDExtensionInterfaceVariantGetNamed VariantGetNamed
    {
        get => _variantGetNamed;
    }

    public GDExtensionInterfaceVariantGetKeyed VariantGetKeyed
    {
        get => _variantGetKeyed;
    }

    public GDExtensionInterfaceVariantGetIndexed VariantGetIndexed
    {
        get => _variantGetIndexed;
    }

    public GDExtensionInterfaceVariantIterInit VariantIterInit
    {
        get => _variantIterInit;
    }

    public GDExtensionInterfaceVariantIterNext VariantIterNext
    {
        get => _variantIterNext;
    }

    public GDExtensionInterfaceVariantIterGet VariantIterGet
    {
        get => _variantIterGet;
    }

    public GDExtensionInterfaceVariantHash VariantHash
    {
        get => _variantHash;
    }

    public GDExtensionInterfaceVariantRecursiveHash VariantRecursiveHash
    {
        get => _variantRecursiveHash;
    }

    public GDExtensionInterfaceVariantHashCompare VariantHashCompare
    {
        get => _variantHashCompare;
    }

    public GDExtensionInterfaceVariantBooleanize VariantBooleanize
    {
        get => _variantBooleanize;
    }

    public GDExtensionInterfaceVariantDuplicate VariantDuplicate
    {
        get => _variantDuplicate;
    }

    public GDExtensionInterfaceVariantStringify VariantStringify
    {
        get => _variantStringify;
    }

    public GDExtensionInterfaceVariantGetType VariantGetType
    {
        get => _variantGetType;
    }

    public GDExtensionInterfaceVariantHasMethod VariantHasMethod
    {
        get => _variantHasMethod;
    }

    public GDExtensionInterfaceVariantHasMember VariantHasMember
    {
        get => _variantHasMember;
    }

    public GDExtensionInterfaceVariantHasKey VariantHasKey
    {
        get => _variantHasKey;
    }

    public GDExtensionInterfaceVariantGetObjectInstanceId VariantGetObjectInstanceId
    {
        get => _variantGetObjectInstanceId;
    }

    public GDExtensionInterfaceVariantGetTypeName VariantGetTypeName
    {
        get => _variantGetTypeName;
    }

    public GDExtensionInterfaceVariantGetTypeByName VariantGetTypeByName
    {
        get => _variantGetTypeByName;
    }

    public GDExtensionInterfaceVariantCanConvert VariantCanConvert
    {
        get => _variantCanConvert;
    }

    public GDExtensionInterfaceVariantCanConvertStrict VariantCanConvertStrict
    {
        get => _variantCanConvertStrict;
    }

    public GDExtensionInterfaceGetVariantFromTypeConstructor GetVariantFromTypeConstructor
    {
        get => _getVariantFromTypeConstructor;
    }

    public GDExtensionInterfaceGetVariantToTypeConstructor GetVariantToTypeConstructor
    {
        get => _getVariantToTypeConstructor;
    }

    public GDExtensionInterfaceVariantGetPtrInternalGetter VariantGetPtrInternalGetter
    {
        get => _variantGetPtrInternalGetter;
    }

    public GDExtensionInterfaceVariantGetPtrOperatorEvaluator VariantGetPtrOperatorEvaluator
    {
        get => _variantGetPtrOperatorEvaluator;
    }

    public GDExtensionInterfaceVariantGetPtrBuiltinMethod VariantGetPtrBuiltinMethod
    {
        get => _variantGetPtrBuiltinMethod;
    }

    public GDExtensionInterfaceVariantGetPtrConstructor VariantGetPtrConstructor
    {
        get => _variantGetPtrConstructor;
    }

    public GDExtensionInterfaceVariantGetPtrDestructor VariantGetPtrDestructor
    {
        get => _variantGetPtrDestructor;
    }

    public GDExtensionInterfaceVariantConstruct VariantConstruct
    {
        get => _variantConstruct;
    }

    public GDExtensionInterfaceVariantGetPtrSetter VariantGetPtrSetter
    {
        get => _variantGetPtrSetter;
    }

    public GDExtensionInterfaceVariantGetPtrGetter VariantGetPtrGetter
    {
        get => _variantGetPtrGetter;
    }

    public GDExtensionInterfaceVariantGetPtrIndexedSetter VariantGetPtrIndexedSetter
    {
        get => _variantGetPtrIndexedSetter;
    }

    public GDExtensionInterfaceVariantGetPtrIndexedGetter VariantGetPtrIndexedGetter
    {
        get => _variantGetPtrIndexedGetter;
    }

    public GDExtensionInterfaceVariantGetPtrKeyedSetter VariantGetPtrKeyedSetter
    {
        get => _variantGetPtrKeyedSetter;
    }

    public GDExtensionInterfaceVariantGetPtrKeyedGetter VariantGetPtrKeyedGetter
    {
        get => _variantGetPtrKeyedGetter;
    }

    public GDExtensionInterfaceVariantGetPtrKeyedChecker VariantGetPtrKeyedChecker
    {
        get => _variantGetPtrKeyedChecker;
    }

    public GDExtensionInterfaceVariantGetConstantValue VariantGetConstantValue
    {
        get => _variantGetConstantValue;
    }

    public GDExtensionInterfaceVariantGetPtrUtilityFunction VariantGetPtrUtilityFunction
    {
        get => _variantGetPtrUtilityFunction;
    }

    public GDExtensionInterfaceStringNewWithLatin1Chars StringNewWithLatin1Chars
    {
        get => _stringNewWithLatin1Chars;
    }

    public GDExtensionInterfaceStringNewWithUtf8Chars StringNewWithUtf8Chars
    {
        get => _stringNewWithUtf8Chars;
    }

    public GDExtensionInterfaceStringNewWithUtf16Chars StringNewWithUtf16Chars
    {
        get => _stringNewWithUtf16Chars;
    }

    public GDExtensionInterfaceStringNewWithUtf32Chars StringNewWithUtf32Chars
    {
        get => _stringNewWithUtf32Chars;
    }

    public GDExtensionInterfaceStringNewWithWideChars StringNewWithWideChars
    {
        get => _stringNewWithWideChars;
    }

    public GDExtensionInterfaceStringNewWithLatin1CharsAndLen StringNewWithLatin1CharsAndLen
    {
        get => _stringNewWithLatin1CharsAndLen;
    }

    public GDExtensionInterfaceStringNewWithUtf8CharsAndLen StringNewWithUtf8CharsAndLen
    {
        get => _stringNewWithUtf8CharsAndLen;
    }

    public GDExtensionInterfaceStringNewWithUtf8CharsAndLen2 StringNewWithUtf8CharsAndLen2
    {
        get => _stringNewWithUtf8CharsAndLen2;
    }

    public GDExtensionInterfaceStringNewWithUtf16CharsAndLen StringNewWithUtf16CharsAndLen
    {
        get => _stringNewWithUtf16CharsAndLen;
    }

    public GDExtensionInterfaceStringNewWithUtf16CharsAndLen2 StringNewWithUtf16CharsAndLen2
    {
        get => _stringNewWithUtf16CharsAndLen2;
    }

    public GDExtensionInterfaceStringNewWithUtf32CharsAndLen StringNewWithUtf32CharsAndLen
    {
        get => _stringNewWithUtf32CharsAndLen;
    }

    public GDExtensionInterfaceStringNewWithWideCharsAndLen StringNewWithWideCharsAndLen
    {
        get => _stringNewWithWideCharsAndLen;
    }

    public GDExtensionInterfaceStringToLatin1Chars StringToLatin1Chars
    {
        get => _stringToLatin1Chars;
    }

    public GDExtensionInterfaceStringToUtf8Chars StringToUtf8Chars
    {
        get => _stringToUtf8Chars;
    }

    public GDExtensionInterfaceStringToUtf16Chars StringToUtf16Chars
    {
        get => _stringToUtf16Chars;
    }

    public GDExtensionInterfaceStringToUtf32Chars StringToUtf32Chars
    {
        get => _stringToUtf32Chars;
    }

    public GDExtensionInterfaceStringToWideChars StringToWideChars
    {
        get => _stringToWideChars;
    }

    public GDExtensionInterfaceStringOperatorIndex StringOperatorIndex
    {
        get => _stringOperatorIndex;
    }

    public GDExtensionInterfaceStringOperatorIndexConst StringOperatorIndexConst
    {
        get => _stringOperatorIndexConst;
    }

    public GDExtensionInterfaceStringOperatorPlusEqString StringOperatorPlusEqString
    {
        get => _stringOperatorPlusEqString;
    }

    public GDExtensionInterfaceStringOperatorPlusEqChar StringOperatorPlusEqChar
    {
        get => _stringOperatorPlusEqChar;
    }

    public GDExtensionInterfaceStringOperatorPlusEqCstr StringOperatorPlusEqCstr
    {
        get => _stringOperatorPlusEqCstr;
    }

    public GDExtensionInterfaceStringOperatorPlusEqWcstr StringOperatorPlusEqWcstr
    {
        get => _stringOperatorPlusEqWcstr;
    }

    public GDExtensionInterfaceStringOperatorPlusEqC32Str StringOperatorPlusEqC32Str
    {
        get => _stringOperatorPlusEqC32Str;
    }

    public GDExtensionInterfaceStringResize StringResize
    {
        get => _stringResize;
    }

    public GDExtensionInterfaceStringNameNewWithLatin1Chars StringNameNewWithLatin1Chars
    {
        get => _stringNameNewWithLatin1Chars;
    }

    public GDExtensionInterfaceStringNameNewWithUtf8Chars StringNameNewWithUtf8Chars
    {
        get => _stringNameNewWithUtf8Chars;
    }

    public GDExtensionInterfaceStringNameNewWithUtf8CharsAndLen StringNameNewWithUtf8CharsAndLen
    {
        get => _stringNameNewWithUtf8CharsAndLen;
    }

    public GDExtensionInterfaceXmlParserOpenBuffer XmlParserOpenBuffer
    {
        get => _xmlParserOpenBuffer;
    }

    public GDExtensionInterfaceFileAccessStoreBuffer FileAccessStoreBuffer
    {
        get => _fileAccessStoreBuffer;
    }

    public GDExtensionInterfaceFileAccessGetBuffer FileAccessGetBuffer
    {
        get => _fileAccessGetBuffer;
    }

    public GDExtensionInterfaceImagePtrw ImagePtrw
    {
        get => _imagePtrw;
    }

    public GDExtensionInterfaceImagePtr ImagePtr
    {
        get => _imagePtr;
    }

    public GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask WorkerThreadPoolAddNativeGroupTask
    {
        get => _workerThreadPoolAddNativeGroupTask;
    }

    public GDExtensionInterfaceWorkerThreadPoolAddNativeTask WorkerThreadPoolAddNativeTask
    {
        get => _workerThreadPoolAddNativeTask;
    }

    public GDExtensionInterfacePackedByteArrayOperatorIndex PackedByteArrayOperatorIndex
    {
        get => _packedByteArrayOperatorIndex;
    }

    public GDExtensionInterfacePackedByteArrayOperatorIndexConst PackedByteArrayOperatorIndexConst
    {
        get => _packedByteArrayOperatorIndexConst;
    }

    public GDExtensionInterfacePackedFloat32ArrayOperatorIndex PackedFloat32ArrayOperatorIndex
    {
        get => _packedFloat32ArrayOperatorIndex;
    }

    public GDExtensionInterfacePackedFloat32ArrayOperatorIndexConst PackedFloat32ArrayOperatorIndexConst
    {
        get => _packedFloat32ArrayOperatorIndexConst;
    }

    public GDExtensionInterfacePackedFloat64ArrayOperatorIndex PackedFloat64ArrayOperatorIndex
    {
        get => _packedFloat64ArrayOperatorIndex;
    }

    public GDExtensionInterfacePackedFloat64ArrayOperatorIndexConst PackedFloat64ArrayOperatorIndexConst
    {
        get => _packedFloat64ArrayOperatorIndexConst;
    }

    public GDExtensionInterfacePackedInt32ArrayOperatorIndex PackedInt32ArrayOperatorIndex
    {
        get => _packedInt32ArrayOperatorIndex;
    }

    public GDExtensionInterfacePackedInt32ArrayOperatorIndexConst PackedInt32ArrayOperatorIndexConst
    {
        get => _packedInt32ArrayOperatorIndexConst;
    }

    public GDExtensionInterfacePackedInt64ArrayOperatorIndex PackedInt64ArrayOperatorIndex
    {
        get => _packedInt64ArrayOperatorIndex;
    }

    public GDExtensionInterfacePackedInt64ArrayOperatorIndexConst PackedInt64ArrayOperatorIndexConst
    {
        get => _packedInt64ArrayOperatorIndexConst;
    }

    public GDExtensionInterfacePackedStringArrayOperatorIndex PackedStringArrayOperatorIndex
    {
        get => _packedStringArrayOperatorIndex;
    }

    public GDExtensionInterfacePackedStringArrayOperatorIndexConst PackedStringArrayOperatorIndexConst
    {
        get => _packedStringArrayOperatorIndexConst;
    }

    public GDExtensionInterfacePackedVector2ArrayOperatorIndex PackedVector2ArrayOperatorIndex
    {
        get => _packedVector2ArrayOperatorIndex;
    }

    public GDExtensionInterfacePackedVector2ArrayOperatorIndexConst PackedVector2ArrayOperatorIndexConst
    {
        get => _packedVector2ArrayOperatorIndexConst;
    }

    public GDExtensionInterfacePackedVector3ArrayOperatorIndex PackedVector3ArrayOperatorIndex
    {
        get => _packedVector3ArrayOperatorIndex;
    }

    public GDExtensionInterfacePackedVector3ArrayOperatorIndexConst PackedVector3ArrayOperatorIndexConst
    {
        get => _packedVector3ArrayOperatorIndexConst;
    }

    public GDExtensionInterfacePackedVector4ArrayOperatorIndex PackedVector4ArrayOperatorIndex
    {
        get => _packedVector4ArrayOperatorIndex;
    }

    public GDExtensionInterfacePackedVector4ArrayOperatorIndexConst PackedVector4ArrayOperatorIndexConst
    {
        get => _packedVector4ArrayOperatorIndexConst;
    }

    public GDExtensionInterfacePackedColorArrayOperatorIndex PackedColorArrayOperatorIndex
    {
        get => _packedColorArrayOperatorIndex;
    }

    public GDExtensionInterfacePackedColorArrayOperatorIndexConst PackedColorArrayOperatorIndexConst
    {
        get => _packedColorArrayOperatorIndexConst;
    }

    public GDExtensionInterfaceArrayOperatorIndex ArrayOperatorIndex
    {
        get => _arrayOperatorIndex;
    }

    public GDExtensionInterfaceArrayOperatorIndexConst ArrayOperatorIndexConst
    {
        get => _arrayOperatorIndexConst;
    }

    public GDExtensionInterfaceArrayRef ArrayRef
    {
        get => _arrayRef;
    }

    public GDExtensionInterfaceArraySetTyped ArraySetTyped
    {
        get => _arraySetTyped;
    }

    public GDExtensionInterfaceDictionaryOperatorIndex DictionaryOperatorIndex
    {
        get => _dictionaryOperatorIndex;
    }

    public GDExtensionInterfaceDictionaryOperatorIndexConst DictionaryOperatorIndexConst
    {
        get => _dictionaryOperatorIndexConst;
    }

    public GDExtensionInterfaceDictionarySetTyped DictionarySetTyped
    {
        get => _dictionarySetTyped;
    }

    public GDExtensionInterfaceObjectMethodBindCall ObjectMethodBindCall
    {
        get => _objectMethodBindCall;
    }

    public GDExtensionInterfaceObjectMethodBindPtrcall ObjectMethodBindPtrcall
    {
        get => _objectMethodBindPtrcall;
    }

    public GDExtensionInterfaceObjectDestroy ObjectDestroy
    {
        get => _objectDestroy;
    }

    public GDExtensionInterfaceGlobalGetSingleton GlobalGetSingleton
    {
        get => _globalGetSingleton;
    }

    public GDExtensionInterfaceObjectGetInstanceBinding ObjectGetInstanceBinding
    {
        get => _objectGetInstanceBinding;
    }

    public GDExtensionInterfaceObjectSetInstanceBinding ObjectSetInstanceBinding
    {
        get => _objectSetInstanceBinding;
    }

    public GDExtensionInterfaceObjectFreeInstanceBinding ObjectFreeInstanceBinding
    {
        get => _objectFreeInstanceBinding;
    }

    public GDExtensionInterfaceObjectSetInstance ObjectSetInstance
    {
        get => _objectSetInstance;
    }

    public GDExtensionInterfaceObjectGetClassName ObjectGetClassName
    {
        get => _objectGetClassName;
    }

    public GDExtensionInterfaceObjectCastTo ObjectCastTo
    {
        get => _objectCastTo;
    }

    public GDExtensionInterfaceObjectGetInstanceFromId ObjectGetInstanceFromId
    {
        get => _objectGetInstanceFromId;
    }

    public GDExtensionInterfaceObjectGetInstanceId ObjectGetInstanceId
    {
        get => _objectGetInstanceId;
    }

    public GDExtensionInterfaceObjectHasScriptMethod ObjectHasScriptMethod
    {
        get => _objectHasScriptMethod;
    }

    public GDExtensionInterfaceObjectCallScriptMethod ObjectCallScriptMethod
    {
        get => _objectCallScriptMethod;
    }

    public GDExtensionInterfaceRefGetObject RefGetObject
    {
        get => _refGetObject;
    }

    public GDExtensionInterfaceRefSetObject RefSetObject
    {
        get => _refSetObject;
    }

    public GDExtensionInterfaceScriptInstanceCreate ScriptInstanceCreate
    {
        get => _scriptInstanceCreate;
    }

    public GDExtensionInterfaceScriptInstanceCreate2 ScriptInstanceCreate2
    {
        get => _scriptInstanceCreate2;
    }

    public GDExtensionInterfaceScriptInstanceCreate3 ScriptInstanceCreate3
    {
        get => _scriptInstanceCreate3;
    }

    public GDExtensionInterfacePlaceholderScriptInstanceCreate PlaceholderScriptInstanceCreate
    {
        get => _placeholderScriptInstanceCreate;
    }

    public GDExtensionInterfacePlaceholderScriptInstanceUpdate PlaceholderScriptInstanceUpdate
    {
        get => _placeholderScriptInstanceUpdate;
    }

    public GDExtensionInterfaceObjectGetScriptInstance ObjectGetScriptInstance
    {
        get => _objectGetScriptInstance;
    }

    public GDExtensionInterfaceObjectSetScriptInstance ObjectSetScriptInstance
    {
        get => _objectSetScriptInstance;
    }

    public GDExtensionInterfaceCallableCustomCreate CallableCustomCreate
    {
        get => _callableCustomCreate;
    }

    public GDExtensionInterfaceCallableCustomCreate2 CallableCustomCreate2
    {
        get => _callableCustomCreate2;
    }

    public GDExtensionInterfaceCallableCustomGetUserdata CallableCustomGetUserdata
    {
        get => _callableCustomGetUserdata;
    }

    public GDExtensionInterfaceClassdbConstructObject ClassdbConstructObject
    {
        get => _classdbConstructObject;
    }

    public GDExtensionInterfaceClassdbConstructObject2 ClassdbConstructObject2
    {
        get => _classdbConstructObject2;
    }

    public GDExtensionInterfaceClassdbConstructObject3 ClassdbConstructObject3
    {
        get => _classdbConstructObject3;
    }

    public GDExtensionInterfaceClassdbGetMethodBind ClassdbGetMethodBind
    {
        get => _classdbGetMethodBind;
    }

    public GDExtensionInterfaceClassdbGetClassTag ClassdbGetClassTag
    {
        get => _classdbGetClassTag;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClass ClassdbRegisterExtensionClass
    {
        get => _classdbRegisterExtensionClass;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClass2 ClassdbRegisterExtensionClass2
    {
        get => _classdbRegisterExtensionClass2;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClass3 ClassdbRegisterExtensionClass3
    {
        get => _classdbRegisterExtensionClass3;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClass4 ClassdbRegisterExtensionClass4
    {
        get => _classdbRegisterExtensionClass4;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClass5 ClassdbRegisterExtensionClass5
    {
        get => _classdbRegisterExtensionClass5;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClass6 ClassdbRegisterExtensionClass6
    {
        get => _classdbRegisterExtensionClass6;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClassMethod ClassdbRegisterExtensionClassMethod
    {
        get => _classdbRegisterExtensionClassMethod;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod ClassdbRegisterExtensionClassVirtualMethod
    {
        get => _classdbRegisterExtensionClassVirtualMethod;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant ClassdbRegisterExtensionClassIntegerConstant
    {
        get => _classdbRegisterExtensionClassIntegerConstant;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClassProperty ClassdbRegisterExtensionClassProperty
    {
        get => _classdbRegisterExtensionClassProperty;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed ClassdbRegisterExtensionClassPropertyIndexed
    {
        get => _classdbRegisterExtensionClassPropertyIndexed;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup ClassdbRegisterExtensionClassPropertyGroup
    {
        get => _classdbRegisterExtensionClassPropertyGroup;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClassPropertySubgroup ClassdbRegisterExtensionClassPropertySubgroup
    {
        get => _classdbRegisterExtensionClassPropertySubgroup;
    }

    public GDExtensionInterfaceClassdbRegisterExtensionClassSignal ClassdbRegisterExtensionClassSignal
    {
        get => _classdbRegisterExtensionClassSignal;
    }

    public GDExtensionInterfaceClassdbUnregisterExtensionClass ClassdbUnregisterExtensionClass
    {
        get => _classdbUnregisterExtensionClass;
    }

    public GDExtensionInterfaceGetLibraryPath GetLibraryPath
    {
        get => _getLibraryPath;
    }

    public GDExtensionInterfaceEditorAddPlugin EditorAddPlugin
    {
        get => _editorAddPlugin;
    }

    public GDExtensionInterfaceEditorRemovePlugin EditorRemovePlugin
    {
        get => _editorRemovePlugin;
    }

    public GDExtensionInterfaceEditorHelpLoadXmlFromUtf8Chars EditorHelpLoadXmlFromUtf8Chars
    {
        get => _editorHelpLoadXmlFromUtf8Chars;
    }

    public GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen EditorHelpLoadXmlFromUtf8CharsAndLen
    {
        get => _editorHelpLoadXmlFromUtf8CharsAndLen;
    }

    public GDExtensionInterfaceEditorRegisterGetClassesUsedCallback EditorRegisterGetClassesUsedCallback
    {
        get => _editorRegisterGetClassesUsedCallback;
    }

    public GDExtensionInterfaceRegisterMainLoopCallbacks RegisterMainLoopCallbacks
    {
        get => _registerMainLoopCallbacks;
    }

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
#pragma warning restore CS0618 // Deprecated functions are loaded to maintain backwards compatibility.
