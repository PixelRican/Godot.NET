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
    private static delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void> s_getGodotVersion;
    private static delegate* unmanaged[Cdecl]<GDExtensionGodotVersion2*, void> s_getGodotVersion2;
    private static delegate* unmanaged[Cdecl]<nuint, void*> s_memAlloc;
    private static delegate* unmanaged[Cdecl]<void*, nuint, void*> s_memRealloc;
    private static delegate* unmanaged[Cdecl]<void*, void> s_memFree;
    private static delegate* unmanaged[Cdecl]<nuint, GDExtensionBool, void*> s_memAlloc2;
    private static delegate* unmanaged[Cdecl]<void*, nuint, GDExtensionBool, void*> s_memRealloc2;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionBool, void> s_memFree2;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> s_printError;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> s_printErrorWithMessage;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> s_printWarning;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> s_printWarningWithMessage;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> s_printScriptError;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> s_printScriptErrorWithMessage;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, ulong> s_getNativeStructSize;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr, void> s_variantNewCopy;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, void> s_variantNewNil;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, void> s_variantDestroy;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> s_variantCall;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> s_variantCallStatic;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> s_variantEvaluate;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> s_variantSet;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> s_variantSetNamed;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> s_variantSetKeyed;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionInt, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool*, void> s_variantSetIndexed;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> s_variantGet;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> s_variantGetNamed;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> s_variantGetKeyed;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool*, void> s_variantGetIndexed;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool> s_variantIterInit;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool*, GDExtensionBool> s_variantIterNext;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> s_variantIterGet;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt> s_variantHash;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionInt> s_variantRecursiveHash;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool> s_variantHashCompare;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionBool> s_variantBooleanize;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool, void> s_variantDuplicate;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionStringPtr, void> s_variantStringify;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantType> s_variantGetType;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionBool> s_variantHasMethod;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionBool> s_variantHasMember;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool> s_variantHasKey;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDObjectInstanceID> s_variantGetObjectInstanceId;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedStringPtr, void> s_variantGetTypeName;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionVariantType> s_variantGetTypeByName;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool> s_variantCanConvert;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool> s_variantCanConvertStrict;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantFromTypeConstructorFunc> s_getVariantFromTypeConstructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionTypeFromVariantConstructorFunc> s_getVariantToTypeConstructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantGetInternalPtrFunc> s_variantGetPtrInternalGetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, GDExtensionPtrOperatorEvaluator> s_variantGetPtrOperatorEvaluator;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrBuiltInMethod> s_variantGetPtrBuiltinMethod;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, int, GDExtensionPtrConstructor> s_variantGetPtrConstructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrDestructor> s_variantGetPtrDestructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr*, int, GDExtensionCallError*, void> s_variantConstruct;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrSetter> s_variantGetPtrSetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrGetter> s_variantGetPtrGetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedSetter> s_variantGetPtrIndexedSetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedGetter> s_variantGetPtrIndexedGetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedSetter> s_variantGetPtrKeyedSetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedGetter> s_variantGetPtrKeyedGetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedChecker> s_variantGetPtrKeyedChecker;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, void> s_variantGetConstantValue;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrUtilityFunction> s_variantGetPtrUtilityFunction;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void> s_stringNewWithLatin1Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void> s_stringNewWithUtf8Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, void> s_stringNewWithUtf16Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, void> s_stringNewWithUtf32Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, void> s_stringNewWithWideChars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> s_stringNewWithLatin1CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> s_stringNewWithUtf8CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, GDExtensionInt> s_stringNewWithUtf8CharsAndLen2;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void> s_stringNewWithUtf16CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, GDExtensionBool, GDExtensionInt> s_stringNewWithUtf16CharsAndLen2;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, GDExtensionInt, void> s_stringNewWithUtf32CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, GDExtensionInt, void> s_stringNewWithWideCharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt> s_stringToLatin1Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt> s_stringToUtf8Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, char*, GDExtensionInt, GDExtensionInt> s_stringToUtf16Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt> s_stringToUtf32Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, void*, GDExtensionInt, GDExtensionInt> s_stringToWideChars;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*> s_stringOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*> s_stringOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionConstStringPtr, void> s_stringOperatorPlusEqString;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint, void> s_stringOperatorPlusEqChar;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, byte*, void> s_stringOperatorPlusEqCstr;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, void*, void> s_stringOperatorPlusEqWcstr;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint*, void> s_stringOperatorPlusEqC32Str;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, GDExtensionInt> s_stringResize;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionBool, void> s_stringNameNewWithLatin1Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, void> s_stringNameNewWithUtf8Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionInt, void> s_stringNameNewWithUtf8CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, nuint, GDExtensionInt> s_xmlParserOpenBuffer;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, ulong, void> s_fileAccessStoreBuffer;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, byte*, ulong, ulong> s_fileAccessGetBuffer;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*> s_imagePtrw;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*> s_imagePtr;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolGroupTask, void*, int, int, GDExtensionBool, GDExtensionConstStringPtr, long> s_workerThreadPoolAddNativeGroupTask;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolTask, void*, GDExtensionBool, GDExtensionConstStringPtr, long> s_workerThreadPoolAddNativeTask;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, byte*> s_packedByteArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, byte*> s_packedByteArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, float*> s_packedFloat32ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, float*> s_packedFloat32ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, double*> s_packedFloat64ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, double*> s_packedFloat64ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, int*> s_packedInt32ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, int*> s_packedInt32ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, long*> s_packedInt64ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, long*> s_packedInt64ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionStringPtr> s_packedStringArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionStringPtr> s_packedStringArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packedVector2ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packedVector2ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packedVector3ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packedVector3ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packedVector4ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packedVector4ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packedColorArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> s_packedColorArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionVariantPtr> s_arrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionVariantPtr> s_arrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstTypePtr, void> s_arrayRef;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void> s_arraySetTyped;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr> s_dictionaryOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr> s_dictionaryOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void> s_dictionarySetTyped;
    private static delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> s_objectMethodBindCall;
    private static delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void> s_objectMethodBindPtrcall;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void> s_objectDestroy;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> s_globalGetSingleton;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, GDExtensionInstanceBindingCallbacks*, void*> s_objectGetInstanceBinding;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void*, GDExtensionInstanceBindingCallbacks*, void> s_objectSetInstanceBinding;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void> s_objectFreeInstanceBinding;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionClassInstancePtr, void> s_objectSetInstance;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionClassLibraryPtr, GDExtensionUninitializedStringNamePtr, GDExtensionBool> s_objectGetClassName;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, void*, GDExtensionObjectPtr> s_objectCastTo;
    private static delegate* unmanaged[Cdecl]<GDObjectInstanceID, GDExtensionObjectPtr> s_objectGetInstanceFromId;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDObjectInstanceID> s_objectGetInstanceId;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionConstStringNamePtr, GDExtensionBool> s_objectHasScriptMethod;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> s_objectCallScriptMethod;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstRefPtr, GDExtensionObjectPtr> s_refGetObject;
    private static delegate* unmanaged[Cdecl]<GDExtensionRefPtr, GDExtensionObjectPtr, void> s_refSetObject;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> s_scriptInstanceCreate;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> s_scriptInstanceCreate2;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo3*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> s_scriptInstanceCreate3;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstancePtr> s_placeholderScriptInstanceCreate;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstancePtr, GDExtensionConstTypePtr, GDExtensionConstTypePtr, void> s_placeholderScriptInstanceUpdate;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr> s_objectGetScriptInstance;
    private static delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr, void> s_objectSetScriptInstance;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo*, void> s_callableCustomCreate;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo2*, void> s_callableCustomCreate2;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, void*, void*> s_callableCustomGetUserdata;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> s_classdbConstructObject;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> s_classdbConstructObject2;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> s_classdbConstructObject3;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionMethodBindPtr> s_classdbGetMethodBind;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void*> s_classdbGetClassTag;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo*, void> s_classdbRegisterExtensionClass;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo2*, void> s_classdbRegisterExtensionClass2;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo3*, void> s_classdbRegisterExtensionClass3;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo4*, void> s_classdbRegisterExtensionClass4;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo5*, void> s_classdbRegisterExtensionClass5;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo6*, void> s_classdbRegisterExtensionClass6;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassMethodInfo*, void> s_classdbRegisterExtensionClassMethod;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassVirtualMethodInfo*, void> s_classdbRegisterExtensionClassVirtualMethod;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionBool, void> s_classdbRegisterExtensionClassIntegerConstant;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, void> s_classdbRegisterExtensionClassProperty;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, void> s_classdbRegisterExtensionClassPropertyIndexed;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void> s_classdbRegisterExtensionClassPropertyGroup;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void> s_classdbRegisterExtensionClassPropertySubgroup;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionInt, void> s_classdbRegisterExtensionClassSignal;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, void> s_classdbUnregisterExtensionClass;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionUninitializedStringPtr, void> s_getLibraryPath;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void> s_editorAddPlugin;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void> s_editorRemovePlugin;
    private static delegate* unmanaged[Cdecl]<byte*, void> s_editorHelpLoadXmlFromUtf8Chars;
    private static delegate* unmanaged[Cdecl]<byte*, GDExtensionInt, void> s_editorHelpLoadXmlFromUtf8CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionEditorGetClassesUsedCallback, void> s_editorRegisterGetClassesUsedCallback;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionMainLoopCallbacks*, void> s_registerMainLoopCallbacks;

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
        s_getGodotVersion = (delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void>)Load(getProcAddress, "get_godot_version"u8);
        s_getGodotVersion2 = (delegate* unmanaged[Cdecl]<GDExtensionGodotVersion2*, void>)Load(getProcAddress, "get_godot_version2"u8);
        s_memAlloc = (delegate* unmanaged[Cdecl]<nuint, void*>)Load(getProcAddress, "mem_alloc"u8);
        s_memRealloc = (delegate* unmanaged[Cdecl]<void*, nuint, void*>)Load(getProcAddress, "mem_realloc"u8);
        s_memFree = (delegate* unmanaged[Cdecl]<void*, void>)Load(getProcAddress, "mem_free"u8);
        s_memAlloc2 = (delegate* unmanaged[Cdecl]<nuint, GDExtensionBool, void*>)Load(getProcAddress, "mem_alloc2"u8);
        s_memRealloc2 = (delegate* unmanaged[Cdecl]<void*, nuint, GDExtensionBool, void*>)Load(getProcAddress, "mem_realloc2"u8);
        s_memFree2 = (delegate* unmanaged[Cdecl]<void*, GDExtensionBool, void>)Load(getProcAddress, "mem_free2"u8);
        s_printError = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_error"u8);
        s_printErrorWithMessage = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_error_with_message"u8);
        s_printWarning = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_warning"u8);
        s_printWarningWithMessage = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_warning_with_message"u8);
        s_printScriptError = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_script_error"u8);
        s_printScriptErrorWithMessage = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void>)Load(getProcAddress, "print_script_error_with_message"u8);
        s_getNativeStructSize = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, ulong>)Load(getProcAddress, "get_native_struct_size"u8);
        s_variantNewCopy = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr, void>)Load(getProcAddress, "variant_new_copy"u8);
        s_variantNewNil = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, void>)Load(getProcAddress, "variant_new_nil"u8);
        s_variantDestroy = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, void>)Load(getProcAddress, "variant_destroy"u8);
        s_variantCall = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void>)Load(getProcAddress, "variant_call"u8);
        s_variantCallStatic = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void>)Load(getProcAddress, "variant_call_static"u8);
        s_variantEvaluate = (delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_evaluate"u8);
        s_variantSet = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_set"u8);
        s_variantSetNamed = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_set_named"u8);
        s_variantSetKeyed = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_set_keyed"u8);
        s_variantSetIndexed = (delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionInt, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool*, void>)Load(getProcAddress, "variant_set_indexed"u8);
        s_variantGet = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_get"u8);
        s_variantGetNamed = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_get_named"u8);
        s_variantGetKeyed = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_get_keyed"u8);
        s_variantGetIndexed = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool*, void>)Load(getProcAddress, "variant_get_indexed"u8);
        s_variantIterInit = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool>)Load(getProcAddress, "variant_iter_init"u8);
        s_variantIterNext = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool*, GDExtensionBool>)Load(getProcAddress, "variant_iter_next"u8);
        s_variantIterGet = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void>)Load(getProcAddress, "variant_iter_get"u8);
        s_variantHash = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt>)Load(getProcAddress, "variant_hash"u8);
        s_variantRecursiveHash = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "variant_recursive_hash"u8);
        s_variantHashCompare = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool>)Load(getProcAddress, "variant_hash_compare"u8);
        s_variantBooleanize = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionBool>)Load(getProcAddress, "variant_booleanize"u8);
        s_variantDuplicate = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool, void>)Load(getProcAddress, "variant_duplicate"u8);
        s_variantStringify = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionStringPtr, void>)Load(getProcAddress, "variant_stringify"u8);
        s_variantGetType = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantType>)Load(getProcAddress, "variant_get_type"u8);
        s_variantHasMethod = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionBool>)Load(getProcAddress, "variant_has_method"u8);
        s_variantHasMember = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionBool>)Load(getProcAddress, "variant_has_member"u8);
        s_variantHasKey = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool>)Load(getProcAddress, "variant_has_key"u8);
        s_variantGetObjectInstanceId = (delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDObjectInstanceID>)Load(getProcAddress, "variant_get_object_instance_id"u8);
        s_variantGetTypeName = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedStringPtr, void>)Load(getProcAddress, "variant_get_type_name"u8);
        s_variantGetTypeByName = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionVariantType>)Load(getProcAddress, "variant_get_type_by_name"u8);
        s_variantCanConvert = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool>)Load(getProcAddress, "variant_can_convert"u8);
        s_variantCanConvertStrict = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool>)Load(getProcAddress, "variant_can_convert_strict"u8);
        s_getVariantFromTypeConstructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantFromTypeConstructorFunc>)Load(getProcAddress, "get_variant_from_type_constructor"u8);
        s_getVariantToTypeConstructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionTypeFromVariantConstructorFunc>)Load(getProcAddress, "get_variant_to_type_constructor"u8);
        s_variantGetPtrInternalGetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantGetInternalPtrFunc>)Load(getProcAddress, "variant_get_ptr_internal_getter"u8);
        s_variantGetPtrOperatorEvaluator = (delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, GDExtensionPtrOperatorEvaluator>)Load(getProcAddress, "variant_get_ptr_operator_evaluator"u8);
        s_variantGetPtrBuiltinMethod = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrBuiltInMethod>)Load(getProcAddress, "variant_get_ptr_builtin_method"u8);
        s_variantGetPtrConstructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, int, GDExtensionPtrConstructor>)Load(getProcAddress, "variant_get_ptr_constructor"u8);
        s_variantGetPtrDestructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrDestructor>)Load(getProcAddress, "variant_get_ptr_destructor"u8);
        s_variantConstruct = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr*, int, GDExtensionCallError*, void>)Load(getProcAddress, "variant_construct"u8);
        s_variantGetPtrSetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrSetter>)Load(getProcAddress, "variant_get_ptr_setter"u8);
        s_variantGetPtrGetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrGetter>)Load(getProcAddress, "variant_get_ptr_getter"u8);
        s_variantGetPtrIndexedSetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedSetter>)Load(getProcAddress, "variant_get_ptr_indexed_setter"u8);
        s_variantGetPtrIndexedGetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedGetter>)Load(getProcAddress, "variant_get_ptr_indexed_getter"u8);
        s_variantGetPtrKeyedSetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedSetter>)Load(getProcAddress, "variant_get_ptr_keyed_setter"u8);
        s_variantGetPtrKeyedGetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedGetter>)Load(getProcAddress, "variant_get_ptr_keyed_getter"u8);
        s_variantGetPtrKeyedChecker = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedChecker>)Load(getProcAddress, "variant_get_ptr_keyed_checker"u8);
        s_variantGetConstantValue = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, void>)Load(getProcAddress, "variant_get_constant_value"u8);
        s_variantGetPtrUtilityFunction = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrUtilityFunction>)Load(getProcAddress, "variant_get_ptr_utility_function"u8);
        s_stringNewWithLatin1Chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void>)Load(getProcAddress, "string_new_with_latin1_chars"u8);
        s_stringNewWithUtf8Chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void>)Load(getProcAddress, "string_new_with_utf8_chars"u8);
        s_stringNewWithUtf16Chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, void>)Load(getProcAddress, "string_new_with_utf16_chars"u8);
        s_stringNewWithUtf32Chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, void>)Load(getProcAddress, "string_new_with_utf32_chars"u8);
        s_stringNewWithWideChars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, void>)Load(getProcAddress, "string_new_with_wide_chars"u8);
        s_stringNewWithLatin1CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_latin1_chars_and_len"u8);
        s_stringNewWithUtf8CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_utf8_chars_and_len"u8);
        s_stringNewWithUtf8CharsAndLen2 = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_new_with_utf8_chars_and_len2"u8);
        s_stringNewWithUtf16CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_utf16_chars_and_len"u8);
        s_stringNewWithUtf16CharsAndLen2 = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, GDExtensionBool, GDExtensionInt>)Load(getProcAddress, "string_new_with_utf16_chars_and_len2"u8);
        s_stringNewWithUtf32CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_utf32_chars_and_len"u8);
        s_stringNewWithWideCharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_wide_chars_and_len"u8);
        s_stringToLatin1Chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_latin1_chars"u8);
        s_stringToUtf8Chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_utf8_chars"u8);
        s_stringToUtf16Chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, char*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_utf16_chars"u8);
        s_stringToUtf32Chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_utf32_chars"u8);
        s_stringToWideChars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, void*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_wide_chars"u8);
        s_stringOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*>)Load(getProcAddress, "string_operator_index"u8);
        s_stringOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*>)Load(getProcAddress, "string_operator_index_const"u8);
        s_stringOperatorPlusEqString = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionConstStringPtr, void>)Load(getProcAddress, "string_operator_plus_eq_string"u8);
        s_stringOperatorPlusEqChar = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint, void>)Load(getProcAddress, "string_operator_plus_eq_char"u8);
        s_stringOperatorPlusEqCstr = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, byte*, void>)Load(getProcAddress, "string_operator_plus_eq_cstr"u8);
        s_stringOperatorPlusEqWcstr = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, void*, void>)Load(getProcAddress, "string_operator_plus_eq_wcstr"u8);
        s_stringOperatorPlusEqC32Str = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint*, void>)Load(getProcAddress, "string_operator_plus_eq_c32str"u8);
        s_stringResize = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_resize"u8);
        s_stringNameNewWithLatin1Chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionBool, void>)Load(getProcAddress, "string_name_new_with_latin1_chars"u8);
        s_stringNameNewWithUtf8Chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, void>)Load(getProcAddress, "string_name_new_with_utf8_chars"u8);
        s_stringNameNewWithUtf8CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionInt, void>)Load(getProcAddress, "string_name_new_with_utf8_chars_and_len"u8);
        s_xmlParserOpenBuffer = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, nuint, GDExtensionInt>)Load(getProcAddress, "xml_parser_open_buffer"u8);
        s_fileAccessStoreBuffer = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, ulong, void>)Load(getProcAddress, "file_access_store_buffer"u8);
        s_fileAccessGetBuffer = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, byte*, ulong, ulong>)Load(getProcAddress, "file_access_get_buffer"u8);
        s_imagePtrw = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*>)Load(getProcAddress, "image_ptrw"u8);
        s_imagePtr = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*>)Load(getProcAddress, "image_ptr"u8);
        s_workerThreadPoolAddNativeGroupTask = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolGroupTask, void*, int, int, GDExtensionBool, GDExtensionConstStringPtr, long>)Load(getProcAddress, "worker_thread_pool_add_native_group_task"u8);
        s_workerThreadPoolAddNativeTask = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolTask, void*, GDExtensionBool, GDExtensionConstStringPtr, long>)Load(getProcAddress, "worker_thread_pool_add_native_task"u8);
        s_packedByteArrayOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, byte*>)Load(getProcAddress, "packed_byte_array_operator_index"u8);
        s_packedByteArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, byte*>)Load(getProcAddress, "packed_byte_array_operator_index_const"u8);
        s_packedFloat32ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, float*>)Load(getProcAddress, "packed_float32_array_operator_index"u8);
        s_packedFloat32ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, float*>)Load(getProcAddress, "packed_float32_array_operator_index_const"u8);
        s_packedFloat64ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, double*>)Load(getProcAddress, "packed_float64_array_operator_index"u8);
        s_packedFloat64ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, double*>)Load(getProcAddress, "packed_float64_array_operator_index_const"u8);
        s_packedInt32ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, int*>)Load(getProcAddress, "packed_int32_array_operator_index"u8);
        s_packedInt32ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, int*>)Load(getProcAddress, "packed_int32_array_operator_index_const"u8);
        s_packedInt64ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, long*>)Load(getProcAddress, "packed_int64_array_operator_index"u8);
        s_packedInt64ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, long*>)Load(getProcAddress, "packed_int64_array_operator_index_const"u8);
        s_packedStringArrayOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionStringPtr>)Load(getProcAddress, "packed_string_array_operator_index"u8);
        s_packedStringArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionStringPtr>)Load(getProcAddress, "packed_string_array_operator_index_const"u8);
        s_packedVector2ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector2_array_operator_index"u8);
        s_packedVector2ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector2_array_operator_index_const"u8);
        s_packedVector3ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector3_array_operator_index"u8);
        s_packedVector3ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector3_array_operator_index_const"u8);
        s_packedVector4ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector4_array_operator_index"u8);
        s_packedVector4ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_vector4_array_operator_index_const"u8);
        s_packedColorArrayOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_color_array_operator_index"u8);
        s_packedColorArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr>)Load(getProcAddress, "packed_color_array_operator_index_const"u8);
        s_arrayOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionVariantPtr>)Load(getProcAddress, "array_operator_index"u8);
        s_arrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionVariantPtr>)Load(getProcAddress, "array_operator_index_const"u8);
        s_arrayRef = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstTypePtr, void>)Load(getProcAddress, "array_ref"u8);
        s_arraySetTyped = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void>)Load(getProcAddress, "array_set_typed"u8);
        s_dictionaryOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr>)Load(getProcAddress, "dictionary_operator_index"u8);
        s_dictionaryOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr>)Load(getProcAddress, "dictionary_operator_index_const"u8);
        s_dictionarySetTyped = (delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void>)Load(getProcAddress, "dictionary_set_typed"u8);
        s_objectMethodBindCall = (delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void>)Load(getProcAddress, "object_method_bind_call"u8);
        s_objectMethodBindPtrcall = (delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void>)Load(getProcAddress, "object_method_bind_ptrcall"u8);
        s_objectDestroy = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void>)Load(getProcAddress, "object_destroy"u8);
        s_globalGetSingleton = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr>)Load(getProcAddress, "global_get_singleton"u8);
        s_objectGetInstanceBinding = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, GDExtensionInstanceBindingCallbacks*, void*>)Load(getProcAddress, "object_get_instance_binding"u8);
        s_objectSetInstanceBinding = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void*, GDExtensionInstanceBindingCallbacks*, void>)Load(getProcAddress, "object_set_instance_binding"u8);
        s_objectFreeInstanceBinding = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void>)Load(getProcAddress, "object_free_instance_binding"u8);
        s_objectSetInstance = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionClassInstancePtr, void>)Load(getProcAddress, "object_set_instance"u8);
        s_objectGetClassName = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionClassLibraryPtr, GDExtensionUninitializedStringNamePtr, GDExtensionBool>)Load(getProcAddress, "object_get_class_name"u8);
        s_objectCastTo = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, void*, GDExtensionObjectPtr>)Load(getProcAddress, "object_cast_to"u8);
        s_objectGetInstanceFromId = (delegate* unmanaged[Cdecl]<GDObjectInstanceID, GDExtensionObjectPtr>)Load(getProcAddress, "object_get_instance_from_id"u8);
        s_objectGetInstanceId = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDObjectInstanceID>)Load(getProcAddress, "object_get_instance_id"u8);
        s_objectHasScriptMethod = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionConstStringNamePtr, GDExtensionBool>)Load(getProcAddress, "object_has_script_method"u8);
        s_objectCallScriptMethod = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void>)Load(getProcAddress, "object_call_script_method"u8);
        s_refGetObject = (delegate* unmanaged[Cdecl]<GDExtensionConstRefPtr, GDExtensionObjectPtr>)Load(getProcAddress, "ref_get_object"u8);
        s_refSetObject = (delegate* unmanaged[Cdecl]<GDExtensionRefPtr, GDExtensionObjectPtr, void>)Load(getProcAddress, "ref_set_object"u8);
        s_scriptInstanceCreate = (delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr>)Load(getProcAddress, "script_instance_create"u8);
        s_scriptInstanceCreate2 = (delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr>)Load(getProcAddress, "script_instance_create2"u8);
        s_scriptInstanceCreate3 = (delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo3*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr>)Load(getProcAddress, "script_instance_create3"u8);
        s_placeholderScriptInstanceCreate = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstancePtr>)Load(getProcAddress, "placeholder_script_instance_create"u8);
        s_placeholderScriptInstanceUpdate = (delegate* unmanaged[Cdecl]<GDExtensionScriptInstancePtr, GDExtensionConstTypePtr, GDExtensionConstTypePtr, void>)Load(getProcAddress, "placeholder_script_instance_update"u8);
        s_objectGetScriptInstance = (delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr>)Load(getProcAddress, "object_get_script_instance"u8);
        s_objectSetScriptInstance = (delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr, void>)Load(getProcAddress, "object_set_script_instance"u8);
        s_callableCustomCreate = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo*, void>)Load(getProcAddress, "callable_custom_create"u8);
        s_callableCustomCreate2 = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo2*, void>)Load(getProcAddress, "callable_custom_create2"u8);
        s_callableCustomGetUserdata = (delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, void*, void*>)Load(getProcAddress, "callable_custom_get_userdata"u8);
        s_classdbConstructObject = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr>)Load(getProcAddress, "classdb_construct_object"u8);
        s_classdbConstructObject2 = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr>)Load(getProcAddress, "classdb_construct_object2"u8);
        s_classdbConstructObject3 = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr>)Load(getProcAddress, "classdb_construct_object3"u8);
        s_classdbGetMethodBind = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionMethodBindPtr>)Load(getProcAddress, "classdb_get_method_bind"u8);
        s_classdbGetClassTag = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void*>)Load(getProcAddress, "classdb_get_class_tag"u8);
        s_classdbRegisterExtensionClass = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo*, void>)Load(getProcAddress, "classdb_register_extension_class"u8);
        s_classdbRegisterExtensionClass2 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo2*, void>)Load(getProcAddress, "classdb_register_extension_class2"u8);
        s_classdbRegisterExtensionClass3 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo3*, void>)Load(getProcAddress, "classdb_register_extension_class3"u8);
        s_classdbRegisterExtensionClass4 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo4*, void>)Load(getProcAddress, "classdb_register_extension_class4"u8);
        s_classdbRegisterExtensionClass5 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo5*, void>)Load(getProcAddress, "classdb_register_extension_class5"u8);
        s_classdbRegisterExtensionClass6 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo6*, void>)Load(getProcAddress, "classdb_register_extension_class6"u8);
        s_classdbRegisterExtensionClassMethod = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassMethodInfo*, void>)Load(getProcAddress, "classdb_register_extension_class_method"u8);
        s_classdbRegisterExtensionClassVirtualMethod = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassVirtualMethodInfo*, void>)Load(getProcAddress, "classdb_register_extension_class_virtual_method"u8);
        s_classdbRegisterExtensionClassIntegerConstant = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionBool, void>)Load(getProcAddress, "classdb_register_extension_class_integer_constant"u8);
        s_classdbRegisterExtensionClassProperty = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, void>)Load(getProcAddress, "classdb_register_extension_class_property"u8);
        s_classdbRegisterExtensionClassPropertyIndexed = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, void>)Load(getProcAddress, "classdb_register_extension_class_property_indexed"u8);
        s_classdbRegisterExtensionClassPropertyGroup = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void>)Load(getProcAddress, "classdb_register_extension_class_property_group"u8);
        s_classdbRegisterExtensionClassPropertySubgroup = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void>)Load(getProcAddress, "classdb_register_extension_class_property_subgroup"u8);
        s_classdbRegisterExtensionClassSignal = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionInt, void>)Load(getProcAddress, "classdb_register_extension_class_signal"u8);
        s_classdbUnregisterExtensionClass = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, void>)Load(getProcAddress, "classdb_unregister_extension_class"u8);
        s_getLibraryPath = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionUninitializedStringPtr, void>)Load(getProcAddress, "get_library_path"u8);
        s_editorAddPlugin = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void>)Load(getProcAddress, "editor_add_plugin"u8);
        s_editorRemovePlugin = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void>)Load(getProcAddress, "editor_remove_plugin"u8);
        s_editorHelpLoadXmlFromUtf8Chars = (delegate* unmanaged[Cdecl]<byte*, void>)Load(getProcAddress, "editor_help_load_xml_from_utf8_chars"u8);
        s_editorHelpLoadXmlFromUtf8CharsAndLen = (delegate* unmanaged[Cdecl]<byte*, GDExtensionInt, void>)Load(getProcAddress, "editor_help_load_xml_from_utf8_chars_and_len"u8);
        s_editorRegisterGetClassesUsedCallback = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionEditorGetClassesUsedCallback, void>)Load(getProcAddress, "editor_register_get_classes_used_callback"u8);
        s_registerMainLoopCallbacks = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionMainLoopCallbacks*, void>)Load(getProcAddress, "register_main_loop_callbacks"u8);
    }

    /// <summary>
    /// Gets the Godot version that the GDExtension was loaded into.
    /// </summary>
    /// <param name="r_godot_version">
    /// A pointer to the structure to write the version information into.
    /// </param>
    [Obsolete("Deprecated since Godot 4.5. Use GetGodotVersion2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GetGodotVersion(GDExtensionGodotVersion* rGodotVersion)
    {
        delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void> function = s_getGodotVersion;
        ThrowIfInvalid(function);
        function(rGodotVersion);
    }

    /// <summary>
    /// Gets the Godot version that the GDExtension was loaded into.
    /// </summary>
    /// <param name="r_godot_version">
    /// A pointer to the structure to write the version information into.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GetGodotVersion2(GDExtensionGodotVersion2* rGodotVersion)
    {
        delegate* unmanaged[Cdecl]<GDExtensionGodotVersion2*, void> function = s_getGodotVersion2;
        ThrowIfInvalid(function);
        function(rGodotVersion);
    }

    /// <summary>
    /// Allocates memory.
    /// </summary>
    /// <param name="p_bytes">
    /// The amount of memory to allocate in bytes.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or null if unsuccessful.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.6. Does not allow explicitly requesting padding. Use MemAlloc2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* MemAlloc(nuint pBytes)
    {
        delegate* unmanaged[Cdecl]<nuint, void*> function = s_memAlloc;
        ThrowIfInvalid(function);
        return function(pBytes);
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
    /// A pointer to the allocated memory, or null if unsuccessful.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.6. Does not allow explicitly requesting padding. Use MemRealloc2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* MemRealloc(void* pPtr, nuint pBytes)
    {
        delegate* unmanaged[Cdecl]<void*, nuint, void*> function = s_memRealloc;
        ThrowIfInvalid(function);
        return function(pPtr, pBytes);
    }

    /// <summary>
    /// Frees memory.
    /// </summary>
    /// <param name="p_ptr">
    /// A pointer to the previously allocated memory.
    /// </param>
    [Obsolete("Deprecated since Godot 4.6. Does not allow explicitly requesting padding. Use MemFree2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MemFree(void* pPtr)
    {
        delegate* unmanaged[Cdecl]<void*, void> function = s_memFree;
        ThrowIfInvalid(function);
        function(pPtr);
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
    /// A pointer to the allocated memory, or null if unsuccessful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* MemAlloc2(nuint pBytes, GDExtensionBool pPadAlign)
    {
        delegate* unmanaged[Cdecl]<nuint, GDExtensionBool, void*> function = s_memAlloc2;
        ThrowIfInvalid(function);
        return function(pBytes, pPadAlign);
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
    /// A pointer to the allocated memory, or null if unsuccessful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* MemRealloc2(void* pPtr, nuint pBytes, GDExtensionBool pPadAlign)
    {
        delegate* unmanaged[Cdecl]<void*, nuint, GDExtensionBool, void*> function = s_memRealloc2;
        ThrowIfInvalid(function);
        return function(pPtr, pBytes, pPadAlign);
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
    public static void MemFree2(void* pPtr, GDExtensionBool pPadAlign)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionBool, void> function = s_memFree2;
        ThrowIfInvalid(function);
        function(pPtr, pPadAlign);
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
    public static void PrintError(byte* pDescription, byte* pFunction, byte* pFile, int pLine, GDExtensionBool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> function = s_printError;
        ThrowIfInvalid(function);
        function(pDescription, pFunction, pFile, pLine, pEditorNotify);
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
    public static void PrintErrorWithMessage(byte* pDescription, byte* pMessage, byte* pFunction, byte* pFile, int pLine, GDExtensionBool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> function = s_printErrorWithMessage;
        ThrowIfInvalid(function);
        function(pDescription, pMessage, pFunction, pFile, pLine, pEditorNotify);
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
    public static void PrintWarning(byte* pDescription, byte* pFunction, byte* pFile, int pLine, GDExtensionBool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> function = s_printWarning;
        ThrowIfInvalid(function);
        function(pDescription, pFunction, pFile, pLine, pEditorNotify);
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
    public static void PrintWarningWithMessage(byte* pDescription, byte* pMessage, byte* pFunction, byte* pFile, int pLine, GDExtensionBool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> function = s_printWarningWithMessage;
        ThrowIfInvalid(function);
        function(pDescription, pMessage, pFunction, pFile, pLine, pEditorNotify);
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
    public static void PrintScriptError(byte* pDescription, byte* pFunction, byte* pFile, int pLine, GDExtensionBool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, GDExtensionBool, void> function = s_printScriptError;
        ThrowIfInvalid(function);
        function(pDescription, pFunction, pFile, pLine, pEditorNotify);
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
    public static void PrintScriptErrorWithMessage(byte* pDescription, byte* pMessage, byte* pFunction, byte* pFile, int pLine, GDExtensionBool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, GDExtensionBool, void> function = s_printScriptErrorWithMessage;
        ThrowIfInvalid(function);
        function(pDescription, pMessage, pFunction, pFile, pLine, pEditorNotify);
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
    public static ulong GetNativeStructSize(GDExtensionConstStringNamePtr pName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, ulong> function = s_getNativeStructSize;
        ThrowIfInvalid(function);
        return function(pName);
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
    public static void VariantNewCopy(GDExtensionUninitializedVariantPtr rDest, GDExtensionConstVariantPtr pSrc)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr, void> function = s_variantNewCopy;
        ThrowIfInvalid(function);
        function(rDest, pSrc);
    }

    /// <summary>
    /// Creates a new Variant containing nil.
    /// </summary>
    /// <param name="r_dest">
    /// A pointer to the destination Variant.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantNewNil(GDExtensionUninitializedVariantPtr rDest)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedVariantPtr, void> function = s_variantNewNil;
        ThrowIfInvalid(function);
        function(rDest);
    }

    /// <summary>
    /// Destroys a Variant.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant to destroy.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantDestroy(GDExtensionVariantPtr pSelf)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, void> function = s_variantDestroy;
        ThrowIfInvalid(function);
        function(pSelf);
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
    public static void VariantCall(GDExtensionVariantPtr pSelf, GDExtensionConstStringNamePtr pMethod, GDExtensionConstVariantPtr* pArgs, GDExtensionInt pArgumentCount, GDExtensionUninitializedVariantPtr rReturn, GDExtensionCallError* rError)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> function = s_variantCall;
        ThrowIfInvalid(function);
        function(pSelf, pMethod, pArgs, pArgumentCount, rReturn, rError);
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
    public static void VariantCallStatic(GDExtensionVariantType pType, GDExtensionConstStringNamePtr pMethod, GDExtensionConstVariantPtr* pArgs, GDExtensionInt pArgumentCount, GDExtensionUninitializedVariantPtr rReturn, GDExtensionCallError* rError)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> function = s_variantCallStatic;
        ThrowIfInvalid(function);
        function(pType, pMethod, pArgs, pArgumentCount, rReturn, rError);
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
    public static void VariantEvaluate(GDExtensionVariantOperator pOp, GDExtensionConstVariantPtr pA, GDExtensionConstVariantPtr pB, GDExtensionUninitializedVariantPtr rReturn, GDExtensionBool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> function = s_variantEvaluate;
        ThrowIfInvalid(function);
        function(pOp, pA, pB, rReturn, rValid);
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
    public static void VariantSet(GDExtensionVariantPtr pSelf, GDExtensionConstVariantPtr pKey, GDExtensionConstVariantPtr pValue, GDExtensionBool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> function = s_variantSet;
        ThrowIfInvalid(function);
        function(pSelf, pKey, pValue, rValid);
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
    public static void VariantSetNamed(GDExtensionVariantPtr pSelf, GDExtensionConstStringNamePtr pKey, GDExtensionConstVariantPtr pValue, GDExtensionBool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> function = s_variantSetNamed;
        ThrowIfInvalid(function);
        function(pSelf, pKey, pValue, rValid);
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
    public static void VariantSetKeyed(GDExtensionVariantPtr pSelf, GDExtensionConstVariantPtr pKey, GDExtensionConstVariantPtr pValue, GDExtensionBool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, void> function = s_variantSetKeyed;
        ThrowIfInvalid(function);
        function(pSelf, pKey, pValue, rValid);
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
    public static void VariantSetIndexed(GDExtensionVariantPtr pSelf, GDExtensionInt pIndex, GDExtensionConstVariantPtr pValue, GDExtensionBool* rValid, GDExtensionBool* rOob)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantPtr, GDExtensionInt, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool*, void> function = s_variantSetIndexed;
        ThrowIfInvalid(function);
        function(pSelf, pIndex, pValue, rValid, rOob);
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
    public static void VariantGet(GDExtensionConstVariantPtr pSelf, GDExtensionConstVariantPtr pKey, GDExtensionUninitializedVariantPtr rRet, GDExtensionBool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> function = s_variantGet;
        ThrowIfInvalid(function);
        function(pSelf, pKey, rRet, rValid);
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
    public static void VariantGetNamed(GDExtensionConstVariantPtr pSelf, GDExtensionConstStringNamePtr pKey, GDExtensionUninitializedVariantPtr rRet, GDExtensionBool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> function = s_variantGetNamed;
        ThrowIfInvalid(function);
        function(pSelf, pKey, rRet, rValid);
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
    public static void VariantGetKeyed(GDExtensionConstVariantPtr pSelf, GDExtensionConstVariantPtr pKey, GDExtensionUninitializedVariantPtr rRet, GDExtensionBool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> function = s_variantGetKeyed;
        ThrowIfInvalid(function);
        function(pSelf, pKey, rRet, rValid);
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
    public static void VariantGetIndexed(GDExtensionConstVariantPtr pSelf, GDExtensionInt pIndex, GDExtensionUninitializedVariantPtr rRet, GDExtensionBool* rValid, GDExtensionBool* rOob)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool*, void> function = s_variantGetIndexed;
        ThrowIfInvalid(function);
        function(pSelf, pIndex, rRet, rValid, rOob);
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
    public static GDExtensionBool VariantIterInit(GDExtensionConstVariantPtr pSelf, GDExtensionUninitializedVariantPtr rIter, GDExtensionBool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, GDExtensionBool> function = s_variantIterInit;
        ThrowIfInvalid(function);
        return function(pSelf, rIter, rValid);
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
    public static GDExtensionBool VariantIterNext(GDExtensionConstVariantPtr pSelf, GDExtensionVariantPtr rIter, GDExtensionBool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool*, GDExtensionBool> function = s_variantIterNext;
        ThrowIfInvalid(function);
        return function(pSelf, rIter, rValid);
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
    public static void VariantIterGet(GDExtensionConstVariantPtr pSelf, GDExtensionVariantPtr rIter, GDExtensionUninitializedVariantPtr rRet, GDExtensionBool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionUninitializedVariantPtr, GDExtensionBool*, void> function = s_variantIterGet;
        ThrowIfInvalid(function);
        function(pSelf, rIter, rRet, rValid);
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
    public static GDExtensionInt VariantHash(GDExtensionConstVariantPtr pSelf)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt> function = s_variantHash;
        ThrowIfInvalid(function);
        return function(pSelf);
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
    public static GDExtensionInt VariantRecursiveHash(GDExtensionConstVariantPtr pSelf, GDExtensionInt pRecursionCount)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionInt, GDExtensionInt> function = s_variantRecursiveHash;
        ThrowIfInvalid(function);
        return function(pSelf, pRecursionCount);
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
    public static GDExtensionBool VariantHashCompare(GDExtensionConstVariantPtr pSelf, GDExtensionConstVariantPtr pOther)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool> function = s_variantHashCompare;
        ThrowIfInvalid(function);
        return function(pSelf, pOther);
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
    public static GDExtensionBool VariantBooleanize(GDExtensionConstVariantPtr pSelf)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionBool> function = s_variantBooleanize;
        ThrowIfInvalid(function);
        return function(pSelf);
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
    public static void VariantDuplicate(GDExtensionConstVariantPtr pSelf, GDExtensionVariantPtr rRet, GDExtensionBool pDeep)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantPtr, GDExtensionBool, void> function = s_variantDuplicate;
        ThrowIfInvalid(function);
        function(pSelf, rRet, pDeep);
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
    public static void VariantStringify(GDExtensionConstVariantPtr pSelf, GDExtensionStringPtr rRet)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionStringPtr, void> function = s_variantStringify;
        ThrowIfInvalid(function);
        function(pSelf, rRet);
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
    public static GDExtensionVariantType VariantGetType(GDExtensionConstVariantPtr pSelf)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionVariantType> function = s_variantGetType;
        ThrowIfInvalid(function);
        return function(pSelf);
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
    public static GDExtensionBool VariantHasMethod(GDExtensionConstVariantPtr pSelf, GDExtensionConstStringNamePtr pMethod)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstStringNamePtr, GDExtensionBool> function = s_variantHasMethod;
        ThrowIfInvalid(function);
        return function(pSelf, pMethod);
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
    public static GDExtensionBool VariantHasMember(GDExtensionVariantType pType, GDExtensionConstStringNamePtr pMember)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionBool> function = s_variantHasMember;
        ThrowIfInvalid(function);
        return function(pType, pMember);
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
    public static GDExtensionBool VariantHasKey(GDExtensionConstVariantPtr pSelf, GDExtensionConstVariantPtr pKey, GDExtensionBool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDExtensionConstVariantPtr, GDExtensionBool*, GDExtensionBool> function = s_variantHasKey;
        ThrowIfInvalid(function);
        return function(pSelf, pKey, rValid);
    }

    /// <summary>
    /// Gets the object instance ID from a variant of type GDEXTENSION_VARIANT_TYPE_OBJECT.<br/>
    /// If the variant isn't of type GDEXTENSION_VARIANT_TYPE_OBJECT, then zero will be returned.<br/>
    /// The instance ID will be returned even if the object is no longer valid - use `object_get_instance_by_id()` to check if the object is still valid.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the Variant.
    /// </param>
    /// <returns>
    /// The instance ID for the contained object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDObjectInstanceID VariantGetObjectInstanceId(GDExtensionConstVariantPtr pSelf)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstVariantPtr, GDObjectInstanceID> function = s_variantGetObjectInstanceId;
        ThrowIfInvalid(function);
        return function(pSelf);
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
    public static void VariantGetTypeName(GDExtensionVariantType pType, GDExtensionUninitializedStringPtr rName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedStringPtr, void> function = s_variantGetTypeName;
        ThrowIfInvalid(function);
        function(pType, rName);
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
    public static GDExtensionVariantType VariantGetTypeByName(GDExtensionConstStringPtr pTypeName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionVariantType> function = s_variantGetTypeByName;
        ThrowIfInvalid(function);
        return function(pTypeName);
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
    public static GDExtensionBool VariantCanConvert(GDExtensionVariantType pFrom, GDExtensionVariantType pTo)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool> function = s_variantCanConvert;
        ThrowIfInvalid(function);
        return function(pFrom, pTo);
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
    public static GDExtensionBool VariantCanConvertStrict(GDExtensionVariantType pFrom, GDExtensionVariantType pTo)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, GDExtensionBool> function = s_variantCanConvertStrict;
        ThrowIfInvalid(function);
        return function(pFrom, pTo);
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
    public static GDExtensionVariantFromTypeConstructorFunc GetVariantFromTypeConstructor(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantFromTypeConstructorFunc> function = s_getVariantFromTypeConstructor;
        ThrowIfInvalid(function);
        return function(pType);
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
    public static GDExtensionTypeFromVariantConstructorFunc GetVariantToTypeConstructor(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionTypeFromVariantConstructorFunc> function = s_getVariantToTypeConstructor;
        ThrowIfInvalid(function);
        return function(pType);
    }

    /// <summary>
    /// Provides a function pointer for retrieving a pointer to a variant's internal value.<br/>
    /// Access to a variant's internal value can be used to modify it in-place, or to retrieve its value without the overhead of variant conversion functions.<br/>
    /// It is recommended to cache the getter for all variant types in a function table to avoid retrieval overhead upon use.<br/>
    /// <br/>
    /// Each function assumes the variant's type has already been determined and matches the function.<br/>
    /// Invoking the function with a variant of a mismatched type has undefined behavior, and may lead to a segmentation fault.
    /// </summary>
    /// <param name="p_type">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a type-specific function that returns a pointer to the internal value of a variant. Check the implementation of this function (gdextension_variant_get_ptr_internal_getter) for pointee type info of each variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariantGetInternalPtrFunc VariantGetPtrInternalGetter(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantGetInternalPtrFunc> function = s_variantGetPtrInternalGetter;
        ThrowIfInvalid(function);
        return function(pType);
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
    public static GDExtensionPtrOperatorEvaluator VariantGetPtrOperatorEvaluator(GDExtensionVariantOperator pOperator, GDExtensionVariantType pTypeA, GDExtensionVariantType pTypeB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, GDExtensionPtrOperatorEvaluator> function = s_variantGetPtrOperatorEvaluator;
        ThrowIfInvalid(function);
        return function(pOperator, pTypeA, pTypeB);
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
    public static GDExtensionPtrBuiltInMethod VariantGetPtrBuiltinMethod(GDExtensionVariantType pType, GDExtensionConstStringNamePtr pMethod, GDExtensionInt pHash)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrBuiltInMethod> function = s_variantGetPtrBuiltinMethod;
        ThrowIfInvalid(function);
        return function(pType, pMethod, pHash);
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
    public static GDExtensionPtrConstructor VariantGetPtrConstructor(GDExtensionVariantType pType, int pConstructor)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, int, GDExtensionPtrConstructor> function = s_variantGetPtrConstructor;
        ThrowIfInvalid(function);
        return function(pType, pConstructor);
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
    public static GDExtensionPtrDestructor VariantGetPtrDestructor(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrDestructor> function = s_variantGetPtrDestructor;
        ThrowIfInvalid(function);
        return function(pType);
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
    public static void VariantConstruct(GDExtensionVariantType pType, GDExtensionUninitializedVariantPtr rBase, GDExtensionConstVariantPtr* pArgs, int pArgumentCount, GDExtensionCallError* rError)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionUninitializedVariantPtr, GDExtensionConstVariantPtr*, int, GDExtensionCallError*, void> function = s_variantConstruct;
        ThrowIfInvalid(function);
        function(pType, rBase, pArgs, pArgumentCount, rError);
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
    public static GDExtensionPtrSetter VariantGetPtrSetter(GDExtensionVariantType pType, GDExtensionConstStringNamePtr pMember)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrSetter> function = s_variantGetPtrSetter;
        ThrowIfInvalid(function);
        return function(pType, pMember);
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
    public static GDExtensionPtrGetter VariantGetPtrGetter(GDExtensionVariantType pType, GDExtensionConstStringNamePtr pMember)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionPtrGetter> function = s_variantGetPtrGetter;
        ThrowIfInvalid(function);
        return function(pType, pMember);
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
    public static GDExtensionPtrIndexedSetter VariantGetPtrIndexedSetter(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedSetter> function = s_variantGetPtrIndexedSetter;
        ThrowIfInvalid(function);
        return function(pType);
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
    public static GDExtensionPtrIndexedGetter VariantGetPtrIndexedGetter(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrIndexedGetter> function = s_variantGetPtrIndexedGetter;
        ThrowIfInvalid(function);
        return function(pType);
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
    public static GDExtensionPtrKeyedSetter VariantGetPtrKeyedSetter(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedSetter> function = s_variantGetPtrKeyedSetter;
        ThrowIfInvalid(function);
        return function(pType);
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
    public static GDExtensionPtrKeyedGetter VariantGetPtrKeyedGetter(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedGetter> function = s_variantGetPtrKeyedGetter;
        ThrowIfInvalid(function);
        return function(pType);
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
    public static GDExtensionPtrKeyedChecker VariantGetPtrKeyedChecker(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionPtrKeyedChecker> function = s_variantGetPtrKeyedChecker;
        ThrowIfInvalid(function);
        return function(pType);
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
    public static void VariantGetConstantValue(GDExtensionVariantType pType, GDExtensionConstStringNamePtr pConstant, GDExtensionUninitializedVariantPtr rRet)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionUninitializedVariantPtr, void> function = s_variantGetConstantValue;
        ThrowIfInvalid(function);
        function(pType, pConstant, rRet);
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
    public static GDExtensionPtrUtilityFunction VariantGetPtrUtilityFunction(GDExtensionConstStringNamePtr pFunction, GDExtensionInt pHash)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionPtrUtilityFunction> function = s_variantGetPtrUtilityFunction;
        ThrowIfInvalid(function);
        return function(pFunction, pHash);
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
    public static void StringNewWithLatin1Chars(GDExtensionUninitializedStringPtr rDest, byte* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void> function = s_stringNewWithLatin1Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
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
    public static void StringNewWithUtf8Chars(GDExtensionUninitializedStringPtr rDest, byte* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, void> function = s_stringNewWithUtf8Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
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
    public static void StringNewWithUtf16Chars(GDExtensionUninitializedStringPtr rDest, char* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, void> function = s_stringNewWithUtf16Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
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
    public static void StringNewWithUtf32Chars(GDExtensionUninitializedStringPtr rDest, uint* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, void> function = s_stringNewWithUtf32Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
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
    public static void StringNewWithWideChars(GDExtensionUninitializedStringPtr rDest, void* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, void> function = s_stringNewWithWideChars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
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
    public static void StringNewWithLatin1CharsAndLen(GDExtensionUninitializedStringPtr rDest, byte* pContents, GDExtensionInt pSize)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> function = s_stringNewWithLatin1CharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pSize);
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
    [Obsolete("Deprecated since Godot 4.3. Use StringNewWithUtf8CharsAndLen2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithUtf8CharsAndLen(GDExtensionUninitializedStringPtr rDest, byte* pContents, GDExtensionInt pSize)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> function = s_stringNewWithUtf8CharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pSize);
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
    public static GDExtensionInt StringNewWithUtf8CharsAndLen2(GDExtensionUninitializedStringPtr rDest, byte* pContents, GDExtensionInt pSize)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, GDExtensionInt> function = s_stringNewWithUtf8CharsAndLen2;
        ThrowIfInvalid(function);
        return function(rDest, pContents, pSize);
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
    [Obsolete("Deprecated since Godot 4.3. Use StringNewWithUtf16CharsAndLen2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithUtf16CharsAndLen(GDExtensionUninitializedStringPtr rDest, char* pContents, GDExtensionInt pCharCount)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void> function = s_stringNewWithUtf16CharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pCharCount);
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
    public static GDExtensionInt StringNewWithUtf16CharsAndLen2(GDExtensionUninitializedStringPtr rDest, char* pContents, GDExtensionInt pCharCount, GDExtensionBool pDefaultLittleEndian)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, GDExtensionBool, GDExtensionInt> function = s_stringNewWithUtf16CharsAndLen2;
        ThrowIfInvalid(function);
        return function(rDest, pContents, pCharCount, pDefaultLittleEndian);
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
    public static void StringNewWithUtf32CharsAndLen(GDExtensionUninitializedStringPtr rDest, uint* pContents, GDExtensionInt pCharCount)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, GDExtensionInt, void> function = s_stringNewWithUtf32CharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pCharCount);
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
    public static void StringNewWithWideCharsAndLen(GDExtensionUninitializedStringPtr rDest, void* pContents, GDExtensionInt pCharCount)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, void*, GDExtensionInt, void> function = s_stringNewWithWideCharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pCharCount);
    }

    /// <summary>
    /// Converts a String to a Latin-1 encoded C string.<br/>
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="r_text">
    /// A pointer to the buffer to hold the resulting data. If null is passed in, only the length will be computed.
    /// </param>
    /// <param name="p_max_write_length">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in characters, not including a null terminator. Characters that cannot be converted to Latin-1 are replaced with a space.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt StringToLatin1Chars(GDExtensionConstStringPtr pSelf, byte* rText, GDExtensionInt pMaxWriteLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt> function = s_stringToLatin1Chars;
        ThrowIfInvalid(function);
        return function(pSelf, rText, pMaxWriteLength);
    }

    /// <summary>
    /// Converts a String to a UTF-8 encoded C string.<br/>
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="r_text">
    /// A pointer to the buffer to hold the resulting data. If null is passed in, only the length will be computed.
    /// </param>
    /// <param name="p_max_write_length">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in bytes (not characters), not including a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt StringToUtf8Chars(GDExtensionConstStringPtr pSelf, byte* rText, GDExtensionInt pMaxWriteLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt> function = s_stringToUtf8Chars;
        ThrowIfInvalid(function);
        return function(pSelf, rText, pMaxWriteLength);
    }

    /// <summary>
    /// Converts a String to a UTF-16 encoded C string.<br/>
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="r_text">
    /// A pointer to the buffer to hold the resulting data. If null is passed in, only the length will be computed.
    /// </param>
    /// <param name="p_max_write_length">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in 16-bit code units (not bytes or characters), not including a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt StringToUtf16Chars(GDExtensionConstStringPtr pSelf, char* rText, GDExtensionInt pMaxWriteLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, char*, GDExtensionInt, GDExtensionInt> function = s_stringToUtf16Chars;
        ThrowIfInvalid(function);
        return function(pSelf, rText, pMaxWriteLength);
    }

    /// <summary>
    /// Converts a String to a UTF-32 encoded C string.<br/>
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="r_text">
    /// A pointer to the buffer to hold the resulting data. If null is passed in, only the length will be computed.
    /// </param>
    /// <param name="p_max_write_length">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in characters (not bytes), not including a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt StringToUtf32Chars(GDExtensionConstStringPtr pSelf, uint* rText, GDExtensionInt pMaxWriteLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt> function = s_stringToUtf32Chars;
        ThrowIfInvalid(function);
        return function(pSelf, rText, pMaxWriteLength);
    }

    /// <summary>
    /// Converts a String to a wide C string.<br/>
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="p_self">
    /// A pointer to the String.
    /// </param>
    /// <param name="r_text">
    /// A pointer to the buffer to hold the resulting data. If null is passed in, only the length will be computed.
    /// </param>
    /// <param name="p_max_write_length">
    /// The maximum number of characters that can be written to r_text. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in characters (for UTF-32) or 16-bit code units (for UTF-16), depending on the wchar_t representation. Does not include a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionInt StringToWideChars(GDExtensionConstStringPtr pSelf, void* rText, GDExtensionInt pMaxWriteLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, void*, GDExtensionInt, GDExtensionInt> function = s_stringToWideChars;
        ThrowIfInvalid(function);
        return function(pSelf, rText, pMaxWriteLength);
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
    public static uint* StringOperatorIndex(GDExtensionStringPtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*> function = s_stringOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static uint* StringOperatorIndexConst(GDExtensionConstStringPtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*> function = s_stringOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static void StringOperatorPlusEqString(GDExtensionStringPtr pSelf, GDExtensionConstStringPtr pB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionConstStringPtr, void> function = s_stringOperatorPlusEqString;
        ThrowIfInvalid(function);
        function(pSelf, pB);
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
    public static void StringOperatorPlusEqChar(GDExtensionStringPtr pSelf, uint pB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint, void> function = s_stringOperatorPlusEqChar;
        ThrowIfInvalid(function);
        function(pSelf, pB);
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
    public static void StringOperatorPlusEqCstr(GDExtensionStringPtr pSelf, byte* pB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringPtr, byte*, void> function = s_stringOperatorPlusEqCstr;
        ThrowIfInvalid(function);
        function(pSelf, pB);
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
    public static void StringOperatorPlusEqWcstr(GDExtensionStringPtr pSelf, void* pB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringPtr, void*, void> function = s_stringOperatorPlusEqWcstr;
        ThrowIfInvalid(function);
        function(pSelf, pB);
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
    public static void StringOperatorPlusEqC32Str(GDExtensionStringPtr pSelf, uint* pB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint*, void> function = s_stringOperatorPlusEqC32Str;
        ThrowIfInvalid(function);
        function(pSelf, pB);
    }

    /// <summary>
    /// Resizes the underlying string data to the given number of characters.<br/>
    /// Space needs to be allocated for the null terminating character ('\0') which<br/>
    /// also must be added manually, in order for all string functions to work correctly.<br/>
    /// <br/>
    /// Warning: This is an error-prone operation - only use it if there's no other<br/>
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
    public static GDExtensionInt StringResize(GDExtensionStringPtr pSelf, GDExtensionInt pResize)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, GDExtensionInt> function = s_stringResize;
        ThrowIfInvalid(function);
        return function(pSelf, pResize);
    }

    /// <summary>
    /// Creates a StringName from a Latin-1 encoded C string.<br/>
    /// If `pIsStatic` is true, then:<br/>
    /// - The StringName will reuse the `pContents` buffer instead of copying it.<br/>
    /// - You must guarantee that the buffer remains valid for the duration of the application (e.g. string literal).<br/>
    /// - You must not call a destructor for this StringName. Incrementing the initial reference once should achieve this.<br/>
    /// <br/>
    /// `pIsStatic` is purely an optimization and can easily introduce undefined behavior if used wrong. In case of doubt, set it to false.
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
    public static void StringNameNewWithLatin1Chars(GDExtensionUninitializedStringNamePtr rDest, byte* pContents, GDExtensionBool pIsStatic)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionBool, void> function = s_stringNameNewWithLatin1Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents, pIsStatic);
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
    public static void StringNameNewWithUtf8Chars(GDExtensionUninitializedStringNamePtr rDest, byte* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, void> function = s_stringNameNewWithUtf8Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
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
    public static void StringNameNewWithUtf8CharsAndLen(GDExtensionUninitializedStringNamePtr rDest, byte* pContents, GDExtensionInt pSize)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringNamePtr, byte*, GDExtensionInt, void> function = s_stringNameNewWithUtf8CharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pSize);
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
    public static GDExtensionInt XmlParserOpenBuffer(GDExtensionObjectPtr pInstance, byte* pBuffer, nuint pSize)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, nuint, GDExtensionInt> function = s_xmlParserOpenBuffer;
        ThrowIfInvalid(function);
        return function(pInstance, pBuffer, pSize);
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
    public static void FileAccessStoreBuffer(GDExtensionObjectPtr pInstance, byte* pSrc, ulong pLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*, ulong, void> function = s_fileAccessStoreBuffer;
        ThrowIfInvalid(function);
        function(pInstance, pSrc, pLength);
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
    public static ulong FileAccessGetBuffer(GDExtensionConstObjectPtr pInstance, byte* pDst, ulong pLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, byte*, ulong, ulong> function = s_fileAccessGetBuffer;
        ThrowIfInvalid(function);
        return function(pInstance, pDst, pLength);
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
    public static byte* ImagePtrw(GDExtensionObjectPtr pInstance)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*> function = s_imagePtrw;
        ThrowIfInvalid(function);
        return function(pInstance);
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
    public static byte* ImagePtr(GDExtensionObjectPtr pInstance)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, byte*> function = s_imagePtr;
        ThrowIfInvalid(function);
        return function(pInstance);
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
    public static long WorkerThreadPoolAddNativeGroupTask(GDExtensionObjectPtr pInstance, GDExtensionWorkerThreadPoolGroupTask pFunc, void* pUserdata, int pElements, int pTasks, GDExtensionBool pHighPriority, GDExtensionConstStringPtr pDescription)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolGroupTask, void*, int, int, GDExtensionBool, GDExtensionConstStringPtr, long> function = s_workerThreadPoolAddNativeGroupTask;
        ThrowIfInvalid(function);
        return function(pInstance, pFunc, pUserdata, pElements, pTasks, pHighPriority, pDescription);
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
    public static long WorkerThreadPoolAddNativeTask(GDExtensionObjectPtr pInstance, GDExtensionWorkerThreadPoolTask pFunc, void* pUserdata, GDExtensionBool pHighPriority, GDExtensionConstStringPtr pDescription)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionWorkerThreadPoolTask, void*, GDExtensionBool, GDExtensionConstStringPtr, long> function = s_workerThreadPoolAddNativeTask;
        ThrowIfInvalid(function);
        return function(pInstance, pFunc, pUserdata, pHighPriority, pDescription);
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
    public static byte* PackedByteArrayOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, byte*> function = s_packedByteArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static byte* PackedByteArrayOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, byte*> function = s_packedByteArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static float* PackedFloat32ArrayOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, float*> function = s_packedFloat32ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static float* PackedFloat32ArrayOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, float*> function = s_packedFloat32ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static double* PackedFloat64ArrayOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, double*> function = s_packedFloat64ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static double* PackedFloat64ArrayOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, double*> function = s_packedFloat64ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static int* PackedInt32ArrayOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, int*> function = s_packedInt32ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static int* PackedInt32ArrayOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, int*> function = s_packedInt32ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static long* PackedInt64ArrayOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, long*> function = s_packedInt64ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static long* PackedInt64ArrayOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, long*> function = s_packedInt64ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionStringPtr PackedStringArrayOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionStringPtr> function = s_packedStringArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionStringPtr PackedStringArrayOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionStringPtr> function = s_packedStringArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionTypePtr PackedVector2ArrayOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> function = s_packedVector2ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionTypePtr PackedVector2ArrayOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> function = s_packedVector2ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionTypePtr PackedVector3ArrayOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> function = s_packedVector3ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionTypePtr PackedVector3ArrayOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> function = s_packedVector3ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionTypePtr PackedVector4ArrayOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> function = s_packedVector4ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionTypePtr PackedVector4ArrayOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> function = s_packedVector4ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionTypePtr PackedColorArrayOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionTypePtr> function = s_packedColorArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionTypePtr PackedColorArrayOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionTypePtr> function = s_packedColorArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionVariantPtr ArrayOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionInt, GDExtensionVariantPtr> function = s_arrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static GDExtensionVariantPtr ArrayOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionInt, GDExtensionVariantPtr> function = s_arrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
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
    public static void ArrayRef(GDExtensionTypePtr pSelf, GDExtensionConstTypePtr pFrom)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstTypePtr, void> function = s_arrayRef;
        ThrowIfInvalid(function);
        function(pSelf, pFrom);
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
    public static void ArraySetTyped(GDExtensionTypePtr pSelf, GDExtensionVariantType pType, GDExtensionConstStringNamePtr pClassName, GDExtensionConstVariantPtr pScript)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void> function = s_arraySetTyped;
        ThrowIfInvalid(function);
        function(pSelf, pType, pClassName, pScript);
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
    public static GDExtensionVariantPtr DictionaryOperatorIndex(GDExtensionTypePtr pSelf, GDExtensionConstVariantPtr pKey)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr> function = s_dictionaryOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pKey);
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
    public static GDExtensionVariantPtr DictionaryOperatorIndexConst(GDExtensionConstTypePtr pSelf, GDExtensionConstVariantPtr pKey)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, GDExtensionConstVariantPtr, GDExtensionVariantPtr> function = s_dictionaryOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pKey);
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
    public static void DictionarySetTyped(GDExtensionTypePtr pSelf, GDExtensionVariantType pKeyType, GDExtensionConstStringNamePtr pKeyClassName, GDExtensionConstVariantPtr pKeyScript, GDExtensionVariantType pValueType, GDExtensionConstStringNamePtr pValueClassName, GDExtensionConstVariantPtr pValueScript)
    {
        delegate* unmanaged[Cdecl]<GDExtensionTypePtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, GDExtensionVariantType, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr, void> function = s_dictionarySetTyped;
        ThrowIfInvalid(function);
        function(pSelf, pKeyType, pKeyClassName, pKeyScript, pValueType, pValueClassName, pValueScript);
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
    public static void ObjectMethodBindCall(GDExtensionMethodBindPtr pMethodBind, GDExtensionObjectPtr pInstance, GDExtensionConstVariantPtr* pArgs, GDExtensionInt pArgCount, GDExtensionUninitializedVariantPtr rRet, GDExtensionCallError* rError)
    {
        delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> function = s_objectMethodBindCall;
        ThrowIfInvalid(function);
        function(pMethodBind, pInstance, pArgs, pArgCount, rRet, rError);
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
    public static void ObjectMethodBindPtrcall(GDExtensionMethodBindPtr pMethodBind, GDExtensionObjectPtr pInstance, GDExtensionConstTypePtr* pArgs, GDExtensionTypePtr rRet)
    {
        delegate* unmanaged[Cdecl]<GDExtensionMethodBindPtr, GDExtensionObjectPtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void> function = s_objectMethodBindPtrcall;
        ThrowIfInvalid(function);
        function(pMethodBind, pInstance, pArgs, rRet);
    }

    /// <summary>
    /// Destroys an Object.
    /// </summary>
    /// <param name="p_o">
    /// A pointer to the Object.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ObjectDestroy(GDExtensionObjectPtr pO)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void> function = s_objectDestroy;
        ThrowIfInvalid(function);
        function(pO);
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
    public static GDExtensionObjectPtr GlobalGetSingleton(GDExtensionConstStringNamePtr pName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> function = s_globalGetSingleton;
        ThrowIfInvalid(function);
        return function(pName);
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
    public static void* ObjectGetInstanceBinding(GDExtensionObjectPtr pO, void* pToken, GDExtensionInstanceBindingCallbacks* pCallbacks)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, GDExtensionInstanceBindingCallbacks*, void*> function = s_objectGetInstanceBinding;
        ThrowIfInvalid(function);
        return function(pO, pToken, pCallbacks);
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
    public static void ObjectSetInstanceBinding(GDExtensionObjectPtr pO, void* pToken, void* pBinding, GDExtensionInstanceBindingCallbacks* pCallbacks)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void*, GDExtensionInstanceBindingCallbacks*, void> function = s_objectSetInstanceBinding;
        ThrowIfInvalid(function);
        function(pO, pToken, pBinding, pCallbacks);
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
    public static void ObjectFreeInstanceBinding(GDExtensionObjectPtr pO, void* pToken)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, void*, void> function = s_objectFreeInstanceBinding;
        ThrowIfInvalid(function);
        function(pO, pToken);
    }

    /// <summary>
    /// Sets an extension class instance on a Object.<br/>
    /// `pClassname` should be a registered extension class and should extend the `pO` Object's class.
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
    public static void ObjectSetInstance(GDExtensionObjectPtr pO, GDExtensionConstStringNamePtr pClassname, GDExtensionClassInstancePtr pInstance)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionClassInstancePtr, void> function = s_objectSetInstance;
        ThrowIfInvalid(function);
        function(pO, pClassname, pInstance);
    }

    /// <summary>
    /// Gets the class name of an Object.<br/>
    /// If the GDExtension wraps the Godot object in an abstraction specific to its class, this is the<br/>
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
    public static GDExtensionBool ObjectGetClassName(GDExtensionConstObjectPtr pObject, GDExtensionClassLibraryPtr pLibrary, GDExtensionUninitializedStringNamePtr rClassName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionClassLibraryPtr, GDExtensionUninitializedStringNamePtr, GDExtensionBool> function = s_objectGetClassName;
        ThrowIfInvalid(function);
        return function(pObject, pLibrary, rClassName);
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
    /// Returns a pointer to the Object, or null if it can't be cast to the requested type.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.7. Use the `is_class` method on `Object` to check if an object can be cast instead. If true, the previous pointer can be reinterpreted as a pointer to the target type.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr ObjectCastTo(GDExtensionConstObjectPtr pObject, void* pClassTag)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, void*, GDExtensionObjectPtr> function = s_objectCastTo;
        ThrowIfInvalid(function);
        return function(pObject, pClassTag);
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
    public static GDExtensionObjectPtr ObjectGetInstanceFromId(GDObjectInstanceID pInstanceId)
    {
        delegate* unmanaged[Cdecl]<GDObjectInstanceID, GDExtensionObjectPtr> function = s_objectGetInstanceFromId;
        ThrowIfInvalid(function);
        return function(pInstanceId);
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
    public static GDObjectInstanceID ObjectGetInstanceId(GDExtensionConstObjectPtr pObject)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDObjectInstanceID> function = s_objectGetInstanceId;
        ThrowIfInvalid(function);
        return function(pObject);
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
    public static GDExtensionBool ObjectHasScriptMethod(GDExtensionConstObjectPtr pObject, GDExtensionConstStringNamePtr pMethod)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionConstStringNamePtr, GDExtensionBool> function = s_objectHasScriptMethod;
        ThrowIfInvalid(function);
        return function(pObject, pMethod);
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
    public static void ObjectCallScriptMethod(GDExtensionObjectPtr pObject, GDExtensionConstStringNamePtr pMethod, GDExtensionConstVariantPtr* pArgs, GDExtensionInt pArgumentCount, GDExtensionUninitializedVariantPtr rReturn, GDExtensionCallError* rError)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionConstStringNamePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionUninitializedVariantPtr, GDExtensionCallError*, void> function = s_objectCallScriptMethod;
        ThrowIfInvalid(function);
        function(pObject, pMethod, pArgs, pArgumentCount, rReturn, rError);
    }

    /// <summary>
    /// Gets the Object from a reference.
    /// </summary>
    /// <param name="p_ref">
    /// A pointer to the reference.
    /// </param>
    /// <returns>
    /// A pointer to the Object from the reference or null.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr RefGetObject(GDExtensionConstRefPtr pRef)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstRefPtr, GDExtensionObjectPtr> function = s_refGetObject;
        ThrowIfInvalid(function);
        return function(pRef);
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
    public static void RefSetObject(GDExtensionRefPtr pRef, GDExtensionObjectPtr pObject)
    {
        delegate* unmanaged[Cdecl]<GDExtensionRefPtr, GDExtensionObjectPtr, void> function = s_refSetObject;
        ThrowIfInvalid(function);
        function(pRef, pObject);
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
    [Obsolete("Deprecated since Godot 4.2. Use ScriptInstanceCreate3 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionScriptInstancePtr ScriptInstanceCreate(GDExtensionScriptInstanceInfo* pInfo, GDExtensionScriptInstanceDataPtr pInstanceData)
    {
        delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> function = s_scriptInstanceCreate;
        ThrowIfInvalid(function);
        return function(pInfo, pInstanceData);
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
    [Obsolete("Deprecated since Godot 4.3. Use ScriptInstanceCreate3 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionScriptInstancePtr ScriptInstanceCreate2(GDExtensionScriptInstanceInfo2* pInfo, GDExtensionScriptInstanceDataPtr pInstanceData)
    {
        delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> function = s_scriptInstanceCreate2;
        ThrowIfInvalid(function);
        return function(pInfo, pInstanceData);
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
    public static GDExtensionScriptInstancePtr ScriptInstanceCreate3(GDExtensionScriptInstanceInfo3* pInfo, GDExtensionScriptInstanceDataPtr pInstanceData)
    {
        delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo3*, GDExtensionScriptInstanceDataPtr, GDExtensionScriptInstancePtr> function = s_scriptInstanceCreate3;
        ThrowIfInvalid(function);
        return function(pInfo, pInstanceData);
    }

    /// <summary>
    /// Creates a placeholder script instance for a given script and instance.<br/>
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
    public static GDExtensionScriptInstancePtr PlaceholderScriptInstanceCreate(GDExtensionObjectPtr pLanguage, GDExtensionObjectPtr pScript, GDExtensionObjectPtr pOwner)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstancePtr> function = s_placeholderScriptInstanceCreate;
        ThrowIfInvalid(function);
        return function(pLanguage, pScript, pOwner);
    }

    /// <summary>
    /// Updates a placeholder script instance with the given properties and values.<br/>
    /// The passed in placeholder must be an instance of PlaceHolderScriptInstance<br/>
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
    public static void PlaceholderScriptInstanceUpdate(GDExtensionScriptInstancePtr pPlaceholder, GDExtensionConstTypePtr pProperties, GDExtensionConstTypePtr pValues)
    {
        delegate* unmanaged[Cdecl]<GDExtensionScriptInstancePtr, GDExtensionConstTypePtr, GDExtensionConstTypePtr, void> function = s_placeholderScriptInstanceUpdate;
        ThrowIfInvalid(function);
        function(pPlaceholder, pProperties, pValues);
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
    public static GDExtensionScriptInstanceDataPtr ObjectGetScriptInstance(GDExtensionConstObjectPtr pObject, GDExtensionObjectPtr pLanguage)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstObjectPtr, GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr> function = s_objectGetScriptInstance;
        ThrowIfInvalid(function);
        return function(pObject, pLanguage);
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
    public static void ObjectSetScriptInstance(GDExtensionObjectPtr pObject, GDExtensionScriptInstanceDataPtr pScriptInstance)
    {
        delegate* unmanaged[Cdecl]<GDExtensionObjectPtr, GDExtensionScriptInstanceDataPtr, void> function = s_objectSetScriptInstance;
        ThrowIfInvalid(function);
        function(pObject, pScriptInstance);
    }

    /// <summary>
    /// Creates a custom Callable object from a function pointer.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="r_callable">
    /// A pointer that will receive the new Callable.
    /// </param>
    /// <param name="p_callable_custom_info">
    /// The info required to construct a Callable.
    /// </param>
    [Obsolete("Deprecated since Godot 4.3. Use CallableCustomCreate2 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void CallableCustomCreate(GDExtensionUninitializedTypePtr rCallable, GDExtensionCallableCustomInfo* pCallableCustomInfo)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo*, void> function = s_callableCustomCreate;
        ThrowIfInvalid(function);
        function(rCallable, pCallableCustomInfo);
    }

    /// <summary>
    /// Creates a custom Callable object from a function pointer.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="r_callable">
    /// A pointer that will receive the new Callable.
    /// </param>
    /// <param name="p_callable_custom_info">
    /// The info required to construct a Callable.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void CallableCustomCreate2(GDExtensionUninitializedTypePtr rCallable, GDExtensionCallableCustomInfo2* pCallableCustomInfo)
    {
        delegate* unmanaged[Cdecl]<GDExtensionUninitializedTypePtr, GDExtensionCallableCustomInfo2*, void> function = s_callableCustomCreate2;
        ThrowIfInvalid(function);
        function(rCallable, pCallableCustomInfo);
    }

    /// <summary>
    /// Retrieves the userdata pointer from a custom Callable.<br/>
    /// If the Callable is not a custom Callable or the token does not match the one provided to callable_custom_create() via GDExtensionCallableCustomInfo then null will be returned.
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
    public static void* CallableCustomGetUserdata(GDExtensionConstTypePtr pCallable, void* pToken)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstTypePtr, void*, void*> function = s_callableCustomGetUserdata;
        ThrowIfInvalid(function);
        return function(pCallable, pToken);
    }

    /// <summary>
    /// Constructs an Object of the requested class.<br/>
    /// The passed class must be a built-in godot class, or an already-registered extension class. In both cases, object_set_instance() should be called to fully initialize the object.
    /// </summary>
    /// <param name="p_classname">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer to the newly created Object.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.4. Use ClassDBConstructObject3 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr ClassDBConstructObject(GDExtensionConstStringNamePtr pClassname)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> function = s_classdbConstructObject;
        ThrowIfInvalid(function);
        return function(pClassname);
    }

    /// <summary>
    /// Constructs an Object of the requested class.<br/>
    /// The passed class must be a built-in godot class, or an already-registered extension class. In both cases, object_set_instance() should be called to fully initialize the object.<br/>
    /// <br/>
    /// "NOTIFICATION_POSTINITIALIZE" must be sent after construction.
    /// </summary>
    /// <param name="p_classname">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer to the newly created Object.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.7. Use ClassDBConstructObject3 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr ClassDBConstructObject2(GDExtensionConstStringNamePtr pClassname)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> function = s_classdbConstructObject2;
        ThrowIfInvalid(function);
        return function(pClassname);
    }

    /// <summary>
    /// Constructs an Object of the requested class.<br/>
    /// The passed class must be a built-in godot class, or an already-registered extension class. In both cases, object_set_instance() should be called to fully initialize the object.<br/>
    /// If the type is a subtype of RefCounted, it already has a refcount of 1. The caller must take ownership the refcount and is responsible for decrementing it again when the object is no longer needed.<br/>
    /// <br/>
    /// "NOTIFICATION_POSTINITIALIZE" must be sent after construction.
    /// </summary>
    /// <param name="p_classname">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer to the newly created Object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionObjectPtr ClassDBConstructObject3(GDExtensionConstStringNamePtr pClassname)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionObjectPtr> function = s_classdbConstructObject3;
        ThrowIfInvalid(function);
        return function(pClassname);
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
    public static GDExtensionMethodBindPtr ClassDBGetMethodBind(GDExtensionConstStringNamePtr pClassname, GDExtensionConstStringNamePtr pMethodname, GDExtensionInt pHash)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionMethodBindPtr> function = s_classdbGetMethodBind;
        ThrowIfInvalid(function);
        return function(pClassname, pMethodname, pHash);
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
    public static void* ClassDBGetClassTag(GDExtensionConstStringNamePtr pClassname)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void*> function = s_classdbGetClassTag;
        ThrowIfInvalid(function);
        return function(pClassname);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
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
    [Obsolete("Deprecated since Godot 4.2. Use ClassDBRegisterExtensionClass6 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClass(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionConstStringNamePtr pParentClassName, GDExtensionClassCreationInfo* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo*, void> function = s_classdbRegisterExtensionClass;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
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
    [Obsolete("Deprecated since Godot 4.3. Use ClassDBRegisterExtensionClass6 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClass2(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionConstStringNamePtr pParentClassName, GDExtensionClassCreationInfo2* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo2*, void> function = s_classdbRegisterExtensionClass2;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
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
    [Obsolete("Deprecated since Godot 4.4. Use ClassDBRegisterExtensionClass6 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClass3(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionConstStringNamePtr pParentClassName, GDExtensionClassCreationInfo3* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo3*, void> function = s_classdbRegisterExtensionClass3;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
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
    [Obsolete("Deprecated since Godot 4.5. Use ClassDBRegisterExtensionClass6 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClass4(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionConstStringNamePtr pParentClassName, GDExtensionClassCreationInfo4* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo4*, void> function = s_classdbRegisterExtensionClass4;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
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
    [Obsolete("Deprecated since Godot 4.7. Use ClassDBRegisterExtensionClass6 instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClass5(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionConstStringNamePtr pParentClassName, GDExtensionClassCreationInfo5* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo5*, void> function = s_classdbRegisterExtensionClass5;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
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
    public static void ClassDBRegisterExtensionClass6(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionConstStringNamePtr pParentClassName, GDExtensionClassCreationInfo6* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo6*, void> function = s_classdbRegisterExtensionClass6;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers a method on an extension class in the ClassDB.<br/>
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
    public static void ClassDBRegisterExtensionClassMethod(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionClassMethodInfo* pMethodInfo)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassMethodInfo*, void> function = s_classdbRegisterExtensionClassMethod;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pMethodInfo);
    }

    /// <summary>
    /// Registers a virtual method on an extension class in ClassDB, that can be implemented by scripts or other extensions.<br/>
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
    public static void ClassDBRegisterExtensionClassVirtualMethod(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionClassVirtualMethodInfo* pMethodInfo)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionClassVirtualMethodInfo*, void> function = s_classdbRegisterExtensionClassVirtualMethod;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pMethodInfo);
    }

    /// <summary>
    /// Registers an integer constant on an extension class in the ClassDB.<br/>
    /// Note about registering bitfield values (if p_is_bitfield is true): even though p_constant_value is signed, language bindings are<br/>
    /// advised to treat bitfields as uint64_t, since this is generally clearer and can prevent mistakes like using -1 for setting all bits.<br/>
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
    public static void ClassDBRegisterExtensionClassIntegerConstant(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionConstStringNamePtr pEnumName, GDExtensionConstStringNamePtr pConstantName, GDExtensionInt pConstantValue, GDExtensionBool pIsBitfield)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionBool, void> function = s_classdbRegisterExtensionClassIntegerConstant;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pEnumName, pConstantName, pConstantValue, pIsBitfield);
    }

    /// <summary>
    /// Registers a property on an extension class in the ClassDB.<br/>
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
    public static void ClassDBRegisterExtensionClassProperty(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionPropertyInfo* pInfo, GDExtensionConstStringNamePtr pSetter, GDExtensionConstStringNamePtr pGetter)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, void> function = s_classdbRegisterExtensionClassProperty;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pInfo, pSetter, pGetter);
    }

    /// <summary>
    /// Registers an indexed property on an extension class in the ClassDB.<br/>
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
    public static void ClassDBRegisterExtensionClassPropertyIndexed(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionPropertyInfo* pInfo, GDExtensionConstStringNamePtr pSetter, GDExtensionConstStringNamePtr pGetter, GDExtensionInt pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, void> function = s_classdbRegisterExtensionClassPropertyIndexed;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pInfo, pSetter, pGetter, pIndex);
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
    public static void ClassDBRegisterExtensionClassPropertyGroup(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionConstStringPtr pGroupName, GDExtensionConstStringPtr pPrefix)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void> function = s_classdbRegisterExtensionClassPropertyGroup;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pGroupName, pPrefix);
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
    public static void ClassDBRegisterExtensionClassPropertySubgroup(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionConstStringPtr pSubgroupName, GDExtensionConstStringPtr pPrefix)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringPtr, GDExtensionConstStringPtr, void> function = s_classdbRegisterExtensionClassPropertySubgroup;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pSubgroupName, pPrefix);
    }

    /// <summary>
    /// Registers a signal on an extension class in the ClassDB.<br/>
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
    public static void ClassDBRegisterExtensionClassSignal(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName, GDExtensionConstStringNamePtr pSignalName, GDExtensionPropertyInfo* pArgumentInfo, GDExtensionInt pArgumentCount)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionPropertyInfo*, GDExtensionInt, void> function = s_classdbRegisterExtensionClassSignal;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pSignalName, pArgumentInfo, pArgumentCount);
    }

    /// <summary>
    /// Unregisters an extension class in the ClassDB.<br/>
    /// Unregistering a parent class before a class that inherits it will result in failure. Inheritors must be unregistered first.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the class name.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBUnregisterExtensionClass(GDExtensionClassLibraryPtr pLibrary, GDExtensionConstStringNamePtr pClassName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, void> function = s_classdbUnregisterExtensionClass;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName);
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
    public static void GetLibraryPath(GDExtensionClassLibraryPtr pLibrary, GDExtensionUninitializedStringPtr rPath)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionUninitializedStringPtr, void> function = s_getLibraryPath;
        ThrowIfInvalid(function);
        function(pLibrary, rPath);
    }

    /// <summary>
    /// Adds an editor plugin.<br/>
    /// It's safe to call during initialization.
    /// </summary>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the name of a class (descending from EditorPlugin) which is already registered with ClassDB.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void EditorAddPlugin(GDExtensionConstStringNamePtr pClassName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void> function = s_editorAddPlugin;
        ThrowIfInvalid(function);
        function(pClassName);
    }

    /// <summary>
    /// Removes an editor plugin.
    /// </summary>
    /// <param name="p_class_name">
    /// A pointer to a StringName with the name of a class that was previously added as an editor plugin.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void EditorRemovePlugin(GDExtensionConstStringNamePtr pClassName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void> function = s_editorRemovePlugin;
        ThrowIfInvalid(function);
        function(pClassName);
    }

    /// <summary>
    /// Loads new XML-formatted documentation data in the editor.<br/>
    /// The provided pointer can be immediately freed once the function returns.
    /// </summary>
    /// <param name="p_data">
    /// A pointer to a UTF-8 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void EditorHelpLoadXmlFromUtf8Chars(byte* pData)
    {
        delegate* unmanaged[Cdecl]<byte*, void> function = s_editorHelpLoadXmlFromUtf8Chars;
        ThrowIfInvalid(function);
        function(pData);
    }

    /// <summary>
    /// Loads new XML-formatted documentation data in the editor.<br/>
    /// The provided pointer can be immediately freed once the function returns.
    /// </summary>
    /// <param name="p_data">
    /// A pointer to a UTF-8 encoded C string.
    /// </param>
    /// <param name="p_size">
    /// The number of bytes (not code units).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void EditorHelpLoadXmlFromUtf8CharsAndLen(byte* pData, GDExtensionInt pSize)
    {
        delegate* unmanaged[Cdecl]<byte*, GDExtensionInt, void> function = s_editorHelpLoadXmlFromUtf8CharsAndLen;
        ThrowIfInvalid(function);
        function(pData, pSize);
    }

    /// <summary>
    /// Registers a callback that Godot can call to get the list of all classes (from ClassDB) that may be used by the calling GDExtension.<br/>
    /// This is used by the editor to generate a build profile (in "Tools" > "Engine Compilation Configuration Editor..." > "Detect from project"),<br/>
    /// in order to recompile Godot with only the classes used.<br/>
    /// In the provided callback, the GDExtension should provide the list of classes that _may_ be used statically, thus the time of invocation shouldn't matter.<br/>
    /// If a GDExtension doesn't register a callback, Godot will assume that it could be using any classes.
    /// </summary>
    /// <param name="p_library">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="p_callback">
    /// The callback to retrieve the list of classes used.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void EditorRegisterGetClassesUsedCallback(GDExtensionClassLibraryPtr pLibrary, GDExtensionEditorGetClassesUsedCallback pCallback)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionEditorGetClassesUsedCallback, void> function = s_editorRegisterGetClassesUsedCallback;
        ThrowIfInvalid(function);
        function(pLibrary, pCallback);
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
    public static void RegisterMainLoopCallbacks(GDExtensionClassLibraryPtr pLibrary, GDExtensionMainLoopCallbacks* pCallbacks)
    {
        delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionMainLoopCallbacks*, void> function = s_registerMainLoopCallbacks;
        ThrowIfInvalid(function);
        function(pLibrary, pCallbacks);
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
