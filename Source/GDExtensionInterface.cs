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

namespace Godot.NET;

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
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, ushort*, void> s_stringNewWithUtf16Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, void> s_stringNewWithUtf32Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, void> s_stringNewWithWideChars;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> s_stringNewWithLatin1CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void> s_stringNewWithUtf8CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, GDExtensionInt> s_stringNewWithUtf8CharsAndLen2;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, ushort*, GDExtensionInt, void> s_stringNewWithUtf16CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, ushort*, GDExtensionInt, GDExtensionBool, GDExtensionInt> s_stringNewWithUtf16CharsAndLen2;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, GDExtensionInt, void> s_stringNewWithUtf32CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void> s_stringNewWithWideCharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt> s_stringToLatin1Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt> s_stringToUtf8Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, ushort*, GDExtensionInt, GDExtensionInt> s_stringToUtf16Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt> s_stringToUtf32Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, char*, GDExtensionInt, GDExtensionInt> s_stringToWideChars;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*> s_stringOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*> s_stringOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionConstStringPtr, void> s_stringOperatorPlusEqString;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint, void> s_stringOperatorPlusEqChar;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, byte*, void> s_stringOperatorPlusEqCstr;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringPtr, char*, void> s_stringOperatorPlusEqWcstr;
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
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionMethodBindPtr> s_classdbGetMethodBind;
    private static delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void*> s_classdbGetClassTag;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo*, void> s_classdbRegisterExtensionClass;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo2*, void> s_classdbRegisterExtensionClass2;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo3*, void> s_classdbRegisterExtensionClass3;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo4*, void> s_classdbRegisterExtensionClass4;
    private static delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo5*, void> s_classdbRegisterExtensionClass5;
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

    public static void Initialize(GDExtensionInterfaceGetProcAddress getProcAddress)
    {
        if (getProcAddress.Method == null)
        {
            throw new ArgumentNullException(nameof(getProcAddress));
        }

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
        s_stringNewWithUtf16Chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, ushort*, void>)Load(getProcAddress, "string_new_with_utf16_chars"u8);
        s_stringNewWithUtf32Chars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, void>)Load(getProcAddress, "string_new_with_utf32_chars"u8);
        s_stringNewWithWideChars = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, void>)Load(getProcAddress, "string_new_with_wide_chars"u8);
        s_stringNewWithLatin1CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_latin1_chars_and_len"u8);
        s_stringNewWithUtf8CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_utf8_chars_and_len"u8);
        s_stringNewWithUtf8CharsAndLen2 = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, byte*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_new_with_utf8_chars_and_len2"u8);
        s_stringNewWithUtf16CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, ushort*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_utf16_chars_and_len"u8);
        s_stringNewWithUtf16CharsAndLen2 = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, ushort*, GDExtensionInt, GDExtensionBool, GDExtensionInt>)Load(getProcAddress, "string_new_with_utf16_chars_and_len2"u8);
        s_stringNewWithUtf32CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, uint*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_utf32_chars_and_len"u8);
        s_stringNewWithWideCharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionUninitializedStringPtr, char*, GDExtensionInt, void>)Load(getProcAddress, "string_new_with_wide_chars_and_len"u8);
        s_stringToLatin1Chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_latin1_chars"u8);
        s_stringToUtf8Chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, byte*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_utf8_chars"u8);
        s_stringToUtf16Chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, ushort*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_utf16_chars"u8);
        s_stringToUtf32Chars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, uint*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_utf32_chars"u8);
        s_stringToWideChars = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, char*, GDExtensionInt, GDExtensionInt>)Load(getProcAddress, "string_to_wide_chars"u8);
        s_stringOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionInt, uint*>)Load(getProcAddress, "string_operator_index"u8);
        s_stringOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionConstStringPtr, GDExtensionInt, uint*>)Load(getProcAddress, "string_operator_index_const"u8);
        s_stringOperatorPlusEqString = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, GDExtensionConstStringPtr, void>)Load(getProcAddress, "string_operator_plus_eq_string"u8);
        s_stringOperatorPlusEqChar = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, uint, void>)Load(getProcAddress, "string_operator_plus_eq_char"u8);
        s_stringOperatorPlusEqCstr = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, byte*, void>)Load(getProcAddress, "string_operator_plus_eq_cstr"u8);
        s_stringOperatorPlusEqWcstr = (delegate* unmanaged[Cdecl]<GDExtensionStringPtr, char*, void>)Load(getProcAddress, "string_operator_plus_eq_wcstr"u8);
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
        s_classdbGetMethodBind = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionInt, GDExtensionMethodBindPtr>)Load(getProcAddress, "classdb_get_method_bind"u8);
        s_classdbGetClassTag = (delegate* unmanaged[Cdecl]<GDExtensionConstStringNamePtr, void*>)Load(getProcAddress, "classdb_get_class_tag"u8);
        s_classdbRegisterExtensionClass = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo*, void>)Load(getProcAddress, "classdb_register_extension_class"u8);
        s_classdbRegisterExtensionClass2 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo2*, void>)Load(getProcAddress, "classdb_register_extension_class2"u8);
        s_classdbRegisterExtensionClass3 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo3*, void>)Load(getProcAddress, "classdb_register_extension_class3"u8);
        s_classdbRegisterExtensionClass4 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo4*, void>)Load(getProcAddress, "classdb_register_extension_class4"u8);
        s_classdbRegisterExtensionClass5 = (delegate* unmanaged[Cdecl]<GDExtensionClassLibraryPtr, GDExtensionConstStringNamePtr, GDExtensionConstStringNamePtr, GDExtensionClassCreationInfo5*, void>)Load(getProcAddress, "classdb_register_extension_class5"u8);
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

    private static void* Load(GDExtensionInterfaceGetProcAddress getProcAddress, ReadOnlySpan<byte> name)
    {
        fixed (byte* reference = name)
        {
            GDExtensionInterfaceFunctionPtr function = getProcAddress.Method(reference);
            return function.Method;
        }
    }
}
