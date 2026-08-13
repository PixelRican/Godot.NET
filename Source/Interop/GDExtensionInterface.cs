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
/*              This file is generated. Edits will be lost.               */
/**************************************************************************/

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Godot.Interop;

/// <summary>
/// Exposes functions from the GDExtension API.
/// </summary>
public static unsafe class GDExtensionInterface
{
    private static delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void> s_getGodotVersion;
    private static delegate* unmanaged[Cdecl]<GDExtensionGodotVersion2*, void> s_getGodotVersion2;
    private static delegate* unmanaged[Cdecl]<nuint, void*> s_memAlloc;
    private static delegate* unmanaged[Cdecl]<void*, nuint, void*> s_memRealloc;
    private static delegate* unmanaged[Cdecl]<void*, void> s_memFree;
    private static delegate* unmanaged[Cdecl]<nuint, bool, void*> s_memAlloc2;
    private static delegate* unmanaged[Cdecl]<void*, nuint, bool, void*> s_memRealloc2;
    private static delegate* unmanaged[Cdecl]<void*, bool, void> s_memFree2;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, bool, void> s_printError;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, bool, void> s_printErrorWithMessage;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, bool, void> s_printWarning;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, bool, void> s_printWarningWithMessage;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, bool, void> s_printScriptError;
    private static delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, bool, void> s_printScriptErrorWithMessage;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, ulong> s_getNativeStructSize;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, void> s_variantNewCopy;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, void> s_variantNewNil;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, void> s_variantDestroy;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> s_variantCall;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> s_variantCallStatic;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> s_variantEvaluate;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> s_variantSet;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, GDExtensionVariant*, bool*, void> s_variantSetNamed;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> s_variantSetKeyed;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, long, GDExtensionVariant*, bool*, bool*, void> s_variantSetIndexed;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> s_variantGet;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, GDExtensionVariant*, bool*, void> s_variantGetNamed;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> s_variantGetKeyed;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, long, GDExtensionVariant*, bool*, bool*, void> s_variantGetIndexed;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool*, bool> s_variantIterInit;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool*, bool> s_variantIterNext;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> s_variantIterGet;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, long> s_variantHash;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, long, long> s_variantRecursiveHash;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool> s_variantHashCompare;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, bool> s_variantBooleanize;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool, void> s_variantDuplicate;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionString*, void> s_variantStringify;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariantType> s_variantGetType;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, bool> s_variantHasMethod;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, bool> s_variantHasMember;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool*, bool> s_variantHasKey;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariant*, ulong> s_variantGetObjectInstanceId;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionString*, void> s_variantGetTypeName;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, GDExtensionVariantType> s_variantGetTypeByName;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, bool> s_variantCanConvert;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, bool> s_variantCanConvertStrict;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<GDExtensionVariant*, void*, void>> s_getVariantFromTypeConstructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, GDExtensionVariant*, void>> s_getVariantToTypeConstructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<GDExtensionVariant*, void*>> s_variantGetPtrInternalGetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>> s_variantGetPtrOperatorEvaluator;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, long, delegate* unmanaged[Cdecl]<void*, void**, void*, int, void>> s_variantGetPtrBuiltinMethod;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, int, delegate* unmanaged[Cdecl]<void*, void**, void>> s_variantGetPtrConstructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void>> s_variantGetPtrDestructor;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariant*, GDExtensionVariant**, int, GDExtensionCallError*, void> s_variantConstruct;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, delegate* unmanaged[Cdecl]<void*, void*, void>> s_variantGetPtrSetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, delegate* unmanaged[Cdecl]<void*, void*, void>> s_variantGetPtrGetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, long, void*, void>> s_variantGetPtrIndexedSetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, long, void*, void>> s_variantGetPtrIndexedGetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>> s_variantGetPtrKeyedSetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>> s_variantGetPtrKeyedGetter;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, uint>> s_variantGetPtrKeyedChecker;
    private static delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, void> s_variantGetConstantValue;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, long, delegate* unmanaged[Cdecl]<void*, void**, int, void>> s_variantGetPtrUtilityFunction;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, void> s_stringNewWithLatin1Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, void> s_stringNewWithUtf8Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, char*, void> s_stringNewWithUtf16Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, void> s_stringNewWithUtf32Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, void*, void> s_stringNewWithWideChars;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, void> s_stringNewWithLatin1CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, void> s_stringNewWithUtf8CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, long> s_stringNewWithUtf8CharsAndLen2;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, char*, long, void> s_stringNewWithUtf16CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, char*, long, bool, long> s_stringNewWithUtf16CharsAndLen2;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, long, void> s_stringNewWithUtf32CharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, void*, long, void> s_stringNewWithWideCharsAndLen;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, long> s_stringToLatin1Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, long> s_stringToUtf8Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, char*, long, long> s_stringToUtf16Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, long, long> s_stringToUtf32Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, void*, long, long> s_stringToWideChars;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, long, uint*> s_stringOperatorIndex;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, long, uint*> s_stringOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, GDExtensionString*, void> s_stringOperatorPlusEqString;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, uint, void> s_stringOperatorPlusEqChar;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, void> s_stringOperatorPlusEqCstr;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, void*, void> s_stringOperatorPlusEqWcstr;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, void> s_stringOperatorPlusEqC32Str;
    private static delegate* unmanaged[Cdecl]<GDExtensionString*, long, long> s_stringResize;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, byte*, bool, void> s_stringNameNewWithLatin1Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, byte*, void> s_stringNameNewWithUtf8Chars;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, byte*, long, void> s_stringNameNewWithUtf8CharsAndLen;
    private static delegate* unmanaged[Cdecl]<void*, byte*, nuint, long> s_xmlParserOpenBuffer;
    private static delegate* unmanaged[Cdecl]<void*, byte*, ulong, void> s_fileAccessStoreBuffer;
    private static delegate* unmanaged[Cdecl]<void*, byte*, ulong, ulong> s_fileAccessGetBuffer;
    private static delegate* unmanaged[Cdecl]<void*, byte*> s_imagePtrw;
    private static delegate* unmanaged[Cdecl]<void*, byte*> s_imagePtr;
    private static delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, uint, void>, void*, int, int, bool, GDExtensionString*, long> s_workerThreadPoolAddNativeGroupTask;
    private static delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void>, void*, bool, GDExtensionString*, long> s_workerThreadPoolAddNativeTask;
    private static delegate* unmanaged[Cdecl]<void*, long, byte*> s_packedByteArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, long, byte*> s_packedByteArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, long, float*> s_packedFloat32ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, long, float*> s_packedFloat32ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, long, double*> s_packedFloat64ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, long, double*> s_packedFloat64ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, long, int*> s_packedInt32ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, long, int*> s_packedInt32ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, long, long*> s_packedInt64ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, long, long*> s_packedInt64ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, long, GDExtensionString*> s_packedStringArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, long, GDExtensionString*> s_packedStringArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, long, void*> s_packedVector2ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, long, void*> s_packedVector2ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, long, void*> s_packedVector3ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, long, void*> s_packedVector3ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, long, void*> s_packedVector4ArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, long, void*> s_packedVector4ArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, long, void*> s_packedColorArrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, long, void*> s_packedColorArrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, long, GDExtensionVariant*> s_arrayOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, long, GDExtensionVariant*> s_arrayOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, void*, void> s_arrayRef;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, void> s_arraySetTyped;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionVariant*, GDExtensionVariant*> s_dictionaryOperatorIndex;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionVariant*, GDExtensionVariant*> s_dictionaryOperatorIndexConst;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, void> s_dictionarySetTyped;
    private static delegate* unmanaged[Cdecl]<void*, void*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> s_objectMethodBindCall;
    private static delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void> s_objectMethodBindPtrCall;
    private static delegate* unmanaged[Cdecl]<void*, void> s_objectDestroy;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*> s_globalGetSingleton;
    private static delegate* unmanaged[Cdecl]<void*, void*, GDExtensionInstanceBindingCallbacks*, void*> s_objectGetInstanceBinding;
    private static delegate* unmanaged[Cdecl]<void*, void*, void*, GDExtensionInstanceBindingCallbacks*, void> s_objectSetInstanceBinding;
    private static delegate* unmanaged[Cdecl]<void*, void*, void> s_objectFreeInstanceBinding;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, void*, void> s_objectSetInstance;
    private static delegate* unmanaged[Cdecl]<void*, void*, GDExtensionStringName*, bool> s_objectGetClassName;
    private static delegate* unmanaged[Cdecl]<void*, void*, void*> s_objectCastTo;
    private static delegate* unmanaged[Cdecl]<ulong, void*> s_objectGetInstanceFromId;
    private static delegate* unmanaged[Cdecl]<void*, ulong> s_objectGetInstanceId;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, bool> s_objectHasScriptMethod;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> s_objectCallScriptMethod;
    private static delegate* unmanaged[Cdecl]<void*, void*> s_refGetObject;
    private static delegate* unmanaged[Cdecl]<void*, void*, void> s_refSetObject;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, void*, void*> s_scriptInstanceCreate;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, void*, void*> s_scriptInstanceCreate2;
    private static delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo3*, void*, void*> s_scriptInstanceCreate3;
    private static delegate* unmanaged[Cdecl]<void*, void*, void*, void*> s_placeholderScriptInstanceCreate;
    private static delegate* unmanaged[Cdecl]<void*, void*, void*, void> s_placeholderScriptInstanceUpdate;
    private static delegate* unmanaged[Cdecl]<void*, void*, void*> s_objectGetScriptInstance;
    private static delegate* unmanaged[Cdecl]<void*, void*, void> s_objectSetScriptInstance;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionCallableCustomInfo*, void> s_callableCustomCreate;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionCallableCustomInfo2*, void> s_callableCustomCreate2;
    private static delegate* unmanaged[Cdecl]<void*, void*, void*> s_callableCustomGetUserData;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*> s_classDBConstructObject;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*> s_classDBConstructObject2;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*> s_classDBConstructObject3;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, GDExtensionStringName*, long, void*> s_classDBGetMethodBind;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*> s_classDBGetClassTag;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo*, void> s_classDBRegisterExtensionClass;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo2*, void> s_classDBRegisterExtensionClass2;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo3*, void> s_classDBRegisterExtensionClass3;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo4*, void> s_classDBRegisterExtensionClass4;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo4*, void> s_classDBRegisterExtensionClass5;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo6*, void> s_classDBRegisterExtensionClass6;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionClassMethodInfo*, void> s_classDBRegisterExtensionClassMethod;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionClassVirtualMethodInfo*, void> s_classDBRegisterExtensionClassVirtualMethod;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionStringName*, long, bool, void> s_classDBRegisterExtensionClassIntegerConstant;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionPropertyInfo*, GDExtensionStringName*, GDExtensionStringName*, void> s_classDBRegisterExtensionClassProperty;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionPropertyInfo*, GDExtensionStringName*, GDExtensionStringName*, long, void> s_classDBRegisterExtensionClassPropertyIndexed;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionString*, GDExtensionString*, void> s_classDBRegisterExtensionClassPropertyGroup;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionString*, GDExtensionString*, void> s_classDBRegisterExtensionClassPropertySubgroup;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionPropertyInfo*, long, void> s_classDBRegisterExtensionClassSignal;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, void> s_classDBUnregisterExtensionClass;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionString*, void> s_getLibraryPath;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, void> s_editorAddPlugin;
    private static delegate* unmanaged[Cdecl]<GDExtensionStringName*, void> s_editorRemovePlugin;
    private static delegate* unmanaged[Cdecl]<byte*, void> s_editorHelpLoadXmlFromUtf8Chars;
    private static delegate* unmanaged[Cdecl]<byte*, long, void> s_editorHelpLoadXmlFromUtf8CharsAndLen;
    private static delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void>, void> s_editorRegisterGetClassesUsedCallback;
    private static delegate* unmanaged[Cdecl]<void*, GDExtensionMainLoopCallbacks*, void> s_registerMainLoopCallbacks;

    /// <summary>
    /// Loads the GDExtensionInterface functions from the specified address loader.
    /// </summary>
    /// <param name="pGetProcAddress">
    /// The address loader provided by the Godot Engine.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="pGetProcAddress"/> is <see langword="null"/>.
    /// </exception>
    public static void Initialize(delegate* unmanaged[Cdecl]<byte*, void*> pGetProcAddress)
    {
        ArgumentNullException.ThrowIfNull(pGetProcAddress);
        s_getGodotVersion = (delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void>)Load(pGetProcAddress, "get_godot_version"u8);
        s_getGodotVersion2 = (delegate* unmanaged[Cdecl]<GDExtensionGodotVersion2*, void>)Load(pGetProcAddress, "get_godot_version2"u8);
        s_memAlloc = (delegate* unmanaged[Cdecl]<nuint, void*>)Load(pGetProcAddress, "mem_alloc"u8);
        s_memRealloc = (delegate* unmanaged[Cdecl]<void*, nuint, void*>)Load(pGetProcAddress, "mem_realloc"u8);
        s_memFree = (delegate* unmanaged[Cdecl]<void*, void>)Load(pGetProcAddress, "mem_free"u8);
        s_memAlloc2 = (delegate* unmanaged[Cdecl]<nuint, bool, void*>)Load(pGetProcAddress, "mem_alloc2"u8);
        s_memRealloc2 = (delegate* unmanaged[Cdecl]<void*, nuint, bool, void*>)Load(pGetProcAddress, "mem_realloc2"u8);
        s_memFree2 = (delegate* unmanaged[Cdecl]<void*, bool, void>)Load(pGetProcAddress, "mem_free2"u8);
        s_printError = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, bool, void>)Load(pGetProcAddress, "print_error"u8);
        s_printErrorWithMessage = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, bool, void>)Load(pGetProcAddress, "print_error_with_message"u8);
        s_printWarning = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, bool, void>)Load(pGetProcAddress, "print_warning"u8);
        s_printWarningWithMessage = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, bool, void>)Load(pGetProcAddress, "print_warning_with_message"u8);
        s_printScriptError = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, bool, void>)Load(pGetProcAddress, "print_script_error"u8);
        s_printScriptErrorWithMessage = (delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, bool, void>)Load(pGetProcAddress, "print_script_error_with_message"u8);
        s_getNativeStructSize = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, ulong>)Load(pGetProcAddress, "get_native_struct_size"u8);
        s_variantNewCopy = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, void>)Load(pGetProcAddress, "variant_new_copy"u8);
        s_variantNewNil = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, void>)Load(pGetProcAddress, "variant_new_nil"u8);
        s_variantDestroy = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, void>)Load(pGetProcAddress, "variant_destroy"u8);
        s_variantCall = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void>)Load(pGetProcAddress, "variant_call"u8);
        s_variantCallStatic = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void>)Load(pGetProcAddress, "variant_call_static"u8);
        s_variantEvaluate = (delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void>)Load(pGetProcAddress, "variant_evaluate"u8);
        s_variantSet = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void>)Load(pGetProcAddress, "variant_set"u8);
        s_variantSetNamed = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, GDExtensionVariant*, bool*, void>)Load(pGetProcAddress, "variant_set_named"u8);
        s_variantSetKeyed = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void>)Load(pGetProcAddress, "variant_set_keyed"u8);
        s_variantSetIndexed = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, long, GDExtensionVariant*, bool*, bool*, void>)Load(pGetProcAddress, "variant_set_indexed"u8);
        s_variantGet = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void>)Load(pGetProcAddress, "variant_get"u8);
        s_variantGetNamed = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, GDExtensionVariant*, bool*, void>)Load(pGetProcAddress, "variant_get_named"u8);
        s_variantGetKeyed = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void>)Load(pGetProcAddress, "variant_get_keyed"u8);
        s_variantGetIndexed = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, long, GDExtensionVariant*, bool*, bool*, void>)Load(pGetProcAddress, "variant_get_indexed"u8);
        s_variantIterInit = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool*, bool>)Load(pGetProcAddress, "variant_iter_init"u8);
        s_variantIterNext = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool*, bool>)Load(pGetProcAddress, "variant_iter_next"u8);
        s_variantIterGet = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void>)Load(pGetProcAddress, "variant_iter_get"u8);
        s_variantHash = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, long>)Load(pGetProcAddress, "variant_hash"u8);
        s_variantRecursiveHash = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, long, long>)Load(pGetProcAddress, "variant_recursive_hash"u8);
        s_variantHashCompare = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool>)Load(pGetProcAddress, "variant_hash_compare"u8);
        s_variantBooleanize = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, bool>)Load(pGetProcAddress, "variant_booleanize"u8);
        s_variantDuplicate = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool, void>)Load(pGetProcAddress, "variant_duplicate"u8);
        s_variantStringify = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionString*, void>)Load(pGetProcAddress, "variant_stringify"u8);
        s_variantGetType = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariantType>)Load(pGetProcAddress, "variant_get_type"u8);
        s_variantHasMethod = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, bool>)Load(pGetProcAddress, "variant_has_method"u8);
        s_variantHasMember = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, bool>)Load(pGetProcAddress, "variant_has_member"u8);
        s_variantHasKey = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool*, bool>)Load(pGetProcAddress, "variant_has_key"u8);
        s_variantGetObjectInstanceId = (delegate* unmanaged[Cdecl]<GDExtensionVariant*, ulong>)Load(pGetProcAddress, "variant_get_object_instance_id"u8);
        s_variantGetTypeName = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionString*, void>)Load(pGetProcAddress, "variant_get_type_name"u8);
        s_variantGetTypeByName = (delegate* unmanaged[Cdecl]<GDExtensionString*, GDExtensionVariantType>)Load(pGetProcAddress, "variant_get_type_by_name"u8);
        s_variantCanConvert = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, bool>)Load(pGetProcAddress, "variant_can_convert"u8);
        s_variantCanConvertStrict = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, bool>)Load(pGetProcAddress, "variant_can_convert_strict"u8);
        s_getVariantFromTypeConstructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<GDExtensionVariant*, void*, void>>)Load(pGetProcAddress, "get_variant_from_type_constructor"u8);
        s_getVariantToTypeConstructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, GDExtensionVariant*, void>>)Load(pGetProcAddress, "get_variant_to_type_constructor"u8);
        s_variantGetPtrInternalGetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<GDExtensionVariant*, void*>>)Load(pGetProcAddress, "variant_get_ptr_internal_getter"u8);
        s_variantGetPtrOperatorEvaluator = (delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>>)Load(pGetProcAddress, "variant_get_ptr_operator_evaluator"u8);
        s_variantGetPtrBuiltinMethod = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, long, delegate* unmanaged[Cdecl]<void*, void**, void*, int, void>>)Load(pGetProcAddress, "variant_get_ptr_builtin_method"u8);
        s_variantGetPtrConstructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, int, delegate* unmanaged[Cdecl]<void*, void**, void>>)Load(pGetProcAddress, "variant_get_ptr_constructor"u8);
        s_variantGetPtrDestructor = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void>>)Load(pGetProcAddress, "variant_get_ptr_destructor"u8);
        s_variantConstruct = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariant*, GDExtensionVariant**, int, GDExtensionCallError*, void>)Load(pGetProcAddress, "variant_construct"u8);
        s_variantGetPtrSetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, delegate* unmanaged[Cdecl]<void*, void*, void>>)Load(pGetProcAddress, "variant_get_ptr_setter"u8);
        s_variantGetPtrGetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, delegate* unmanaged[Cdecl]<void*, void*, void>>)Load(pGetProcAddress, "variant_get_ptr_getter"u8);
        s_variantGetPtrIndexedSetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, long, void*, void>>)Load(pGetProcAddress, "variant_get_ptr_indexed_setter"u8);
        s_variantGetPtrIndexedGetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, long, void*, void>>)Load(pGetProcAddress, "variant_get_ptr_indexed_getter"u8);
        s_variantGetPtrKeyedSetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>>)Load(pGetProcAddress, "variant_get_ptr_keyed_setter"u8);
        s_variantGetPtrKeyedGetter = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>>)Load(pGetProcAddress, "variant_get_ptr_keyed_getter"u8);
        s_variantGetPtrKeyedChecker = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, uint>>)Load(pGetProcAddress, "variant_get_ptr_keyed_checker"u8);
        s_variantGetConstantValue = (delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, void>)Load(pGetProcAddress, "variant_get_constant_value"u8);
        s_variantGetPtrUtilityFunction = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, long, delegate* unmanaged[Cdecl]<void*, void**, int, void>>)Load(pGetProcAddress, "variant_get_ptr_utility_function"u8);
        s_stringNewWithLatin1Chars = (delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, void>)Load(pGetProcAddress, "string_new_with_latin1_chars"u8);
        s_stringNewWithUtf8Chars = (delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, void>)Load(pGetProcAddress, "string_new_with_utf8_chars"u8);
        s_stringNewWithUtf16Chars = (delegate* unmanaged[Cdecl]<GDExtensionString*, char*, void>)Load(pGetProcAddress, "string_new_with_utf16_chars"u8);
        s_stringNewWithUtf32Chars = (delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, void>)Load(pGetProcAddress, "string_new_with_utf32_chars"u8);
        s_stringNewWithWideChars = (delegate* unmanaged[Cdecl]<GDExtensionString*, void*, void>)Load(pGetProcAddress, "string_new_with_wide_chars"u8);
        s_stringNewWithLatin1CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, void>)Load(pGetProcAddress, "string_new_with_latin1_chars_and_len"u8);
        s_stringNewWithUtf8CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, void>)Load(pGetProcAddress, "string_new_with_utf8_chars_and_len"u8);
        s_stringNewWithUtf8CharsAndLen2 = (delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, long>)Load(pGetProcAddress, "string_new_with_utf8_chars_and_len2"u8);
        s_stringNewWithUtf16CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionString*, char*, long, void>)Load(pGetProcAddress, "string_new_with_utf16_chars_and_len"u8);
        s_stringNewWithUtf16CharsAndLen2 = (delegate* unmanaged[Cdecl]<GDExtensionString*, char*, long, bool, long>)Load(pGetProcAddress, "string_new_with_utf16_chars_and_len2"u8);
        s_stringNewWithUtf32CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, long, void>)Load(pGetProcAddress, "string_new_with_utf32_chars_and_len"u8);
        s_stringNewWithWideCharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionString*, void*, long, void>)Load(pGetProcAddress, "string_new_with_wide_chars_and_len"u8);
        s_stringToLatin1Chars = (delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, long>)Load(pGetProcAddress, "string_to_latin1_chars"u8);
        s_stringToUtf8Chars = (delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, long>)Load(pGetProcAddress, "string_to_utf8_chars"u8);
        s_stringToUtf16Chars = (delegate* unmanaged[Cdecl]<GDExtensionString*, char*, long, long>)Load(pGetProcAddress, "string_to_utf16_chars"u8);
        s_stringToUtf32Chars = (delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, long, long>)Load(pGetProcAddress, "string_to_utf32_chars"u8);
        s_stringToWideChars = (delegate* unmanaged[Cdecl]<GDExtensionString*, void*, long, long>)Load(pGetProcAddress, "string_to_wide_chars"u8);
        s_stringOperatorIndex = (delegate* unmanaged[Cdecl]<GDExtensionString*, long, uint*>)Load(pGetProcAddress, "string_operator_index"u8);
        s_stringOperatorIndexConst = (delegate* unmanaged[Cdecl]<GDExtensionString*, long, uint*>)Load(pGetProcAddress, "string_operator_index_const"u8);
        s_stringOperatorPlusEqString = (delegate* unmanaged[Cdecl]<GDExtensionString*, GDExtensionString*, void>)Load(pGetProcAddress, "string_operator_plus_eq_string"u8);
        s_stringOperatorPlusEqChar = (delegate* unmanaged[Cdecl]<GDExtensionString*, uint, void>)Load(pGetProcAddress, "string_operator_plus_eq_char"u8);
        s_stringOperatorPlusEqCstr = (delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, void>)Load(pGetProcAddress, "string_operator_plus_eq_cstr"u8);
        s_stringOperatorPlusEqWcstr = (delegate* unmanaged[Cdecl]<GDExtensionString*, void*, void>)Load(pGetProcAddress, "string_operator_plus_eq_wcstr"u8);
        s_stringOperatorPlusEqC32Str = (delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, void>)Load(pGetProcAddress, "string_operator_plus_eq_c32str"u8);
        s_stringResize = (delegate* unmanaged[Cdecl]<GDExtensionString*, long, long>)Load(pGetProcAddress, "string_resize"u8);
        s_stringNameNewWithLatin1Chars = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, byte*, bool, void>)Load(pGetProcAddress, "string_name_new_with_latin1_chars"u8);
        s_stringNameNewWithUtf8Chars = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, byte*, void>)Load(pGetProcAddress, "string_name_new_with_utf8_chars"u8);
        s_stringNameNewWithUtf8CharsAndLen = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, byte*, long, void>)Load(pGetProcAddress, "string_name_new_with_utf8_chars_and_len"u8);
        s_xmlParserOpenBuffer = (delegate* unmanaged[Cdecl]<void*, byte*, nuint, long>)Load(pGetProcAddress, "xml_parser_open_buffer"u8);
        s_fileAccessStoreBuffer = (delegate* unmanaged[Cdecl]<void*, byte*, ulong, void>)Load(pGetProcAddress, "file_access_store_buffer"u8);
        s_fileAccessGetBuffer = (delegate* unmanaged[Cdecl]<void*, byte*, ulong, ulong>)Load(pGetProcAddress, "file_access_get_buffer"u8);
        s_imagePtrw = (delegate* unmanaged[Cdecl]<void*, byte*>)Load(pGetProcAddress, "image_ptrw"u8);
        s_imagePtr = (delegate* unmanaged[Cdecl]<void*, byte*>)Load(pGetProcAddress, "image_ptr"u8);
        s_workerThreadPoolAddNativeGroupTask = (delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, uint, void>, void*, int, int, bool, GDExtensionString*, long>)Load(pGetProcAddress, "worker_thread_pool_add_native_group_task"u8);
        s_workerThreadPoolAddNativeTask = (delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void>, void*, bool, GDExtensionString*, long>)Load(pGetProcAddress, "worker_thread_pool_add_native_task"u8);
        s_packedByteArrayOperatorIndex = (delegate* unmanaged[Cdecl]<void*, long, byte*>)Load(pGetProcAddress, "packed_byte_array_operator_index"u8);
        s_packedByteArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, long, byte*>)Load(pGetProcAddress, "packed_byte_array_operator_index_const"u8);
        s_packedFloat32ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<void*, long, float*>)Load(pGetProcAddress, "packed_float32_array_operator_index"u8);
        s_packedFloat32ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, long, float*>)Load(pGetProcAddress, "packed_float32_array_operator_index_const"u8);
        s_packedFloat64ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<void*, long, double*>)Load(pGetProcAddress, "packed_float64_array_operator_index"u8);
        s_packedFloat64ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, long, double*>)Load(pGetProcAddress, "packed_float64_array_operator_index_const"u8);
        s_packedInt32ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<void*, long, int*>)Load(pGetProcAddress, "packed_int32_array_operator_index"u8);
        s_packedInt32ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, long, int*>)Load(pGetProcAddress, "packed_int32_array_operator_index_const"u8);
        s_packedInt64ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<void*, long, long*>)Load(pGetProcAddress, "packed_int64_array_operator_index"u8);
        s_packedInt64ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, long, long*>)Load(pGetProcAddress, "packed_int64_array_operator_index_const"u8);
        s_packedStringArrayOperatorIndex = (delegate* unmanaged[Cdecl]<void*, long, GDExtensionString*>)Load(pGetProcAddress, "packed_string_array_operator_index"u8);
        s_packedStringArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, long, GDExtensionString*>)Load(pGetProcAddress, "packed_string_array_operator_index_const"u8);
        s_packedVector2ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<void*, long, void*>)Load(pGetProcAddress, "packed_vector2_array_operator_index"u8);
        s_packedVector2ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, long, void*>)Load(pGetProcAddress, "packed_vector2_array_operator_index_const"u8);
        s_packedVector3ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<void*, long, void*>)Load(pGetProcAddress, "packed_vector3_array_operator_index"u8);
        s_packedVector3ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, long, void*>)Load(pGetProcAddress, "packed_vector3_array_operator_index_const"u8);
        s_packedVector4ArrayOperatorIndex = (delegate* unmanaged[Cdecl]<void*, long, void*>)Load(pGetProcAddress, "packed_vector4_array_operator_index"u8);
        s_packedVector4ArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, long, void*>)Load(pGetProcAddress, "packed_vector4_array_operator_index_const"u8);
        s_packedColorArrayOperatorIndex = (delegate* unmanaged[Cdecl]<void*, long, void*>)Load(pGetProcAddress, "packed_color_array_operator_index"u8);
        s_packedColorArrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, long, void*>)Load(pGetProcAddress, "packed_color_array_operator_index_const"u8);
        s_arrayOperatorIndex = (delegate* unmanaged[Cdecl]<void*, long, GDExtensionVariant*>)Load(pGetProcAddress, "array_operator_index"u8);
        s_arrayOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, long, GDExtensionVariant*>)Load(pGetProcAddress, "array_operator_index_const"u8);
        s_arrayRef = (delegate* unmanaged[Cdecl]<void*, void*, void>)Load(pGetProcAddress, "array_ref"u8);
        s_arraySetTyped = (delegate* unmanaged[Cdecl]<void*, GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, void>)Load(pGetProcAddress, "array_set_typed"u8);
        s_dictionaryOperatorIndex = (delegate* unmanaged[Cdecl]<void*, GDExtensionVariant*, GDExtensionVariant*>)Load(pGetProcAddress, "dictionary_operator_index"u8);
        s_dictionaryOperatorIndexConst = (delegate* unmanaged[Cdecl]<void*, GDExtensionVariant*, GDExtensionVariant*>)Load(pGetProcAddress, "dictionary_operator_index_const"u8);
        s_dictionarySetTyped = (delegate* unmanaged[Cdecl]<void*, GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, void>)Load(pGetProcAddress, "dictionary_set_typed"u8);
        s_objectMethodBindCall = (delegate* unmanaged[Cdecl]<void*, void*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void>)Load(pGetProcAddress, "object_method_bind_call"u8);
        s_objectMethodBindPtrCall = (delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void>)Load(pGetProcAddress, "object_method_bind_ptrcall"u8);
        s_objectDestroy = (delegate* unmanaged[Cdecl]<void*, void>)Load(pGetProcAddress, "object_destroy"u8);
        s_globalGetSingleton = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*>)Load(pGetProcAddress, "global_get_singleton"u8);
        s_objectGetInstanceBinding = (delegate* unmanaged[Cdecl]<void*, void*, GDExtensionInstanceBindingCallbacks*, void*>)Load(pGetProcAddress, "object_get_instance_binding"u8);
        s_objectSetInstanceBinding = (delegate* unmanaged[Cdecl]<void*, void*, void*, GDExtensionInstanceBindingCallbacks*, void>)Load(pGetProcAddress, "object_set_instance_binding"u8);
        s_objectFreeInstanceBinding = (delegate* unmanaged[Cdecl]<void*, void*, void>)Load(pGetProcAddress, "object_free_instance_binding"u8);
        s_objectSetInstance = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, void*, void>)Load(pGetProcAddress, "object_set_instance"u8);
        s_objectGetClassName = (delegate* unmanaged[Cdecl]<void*, void*, GDExtensionStringName*, bool>)Load(pGetProcAddress, "object_get_class_name"u8);
        s_objectCastTo = (delegate* unmanaged[Cdecl]<void*, void*, void*>)Load(pGetProcAddress, "object_cast_to"u8);
        s_objectGetInstanceFromId = (delegate* unmanaged[Cdecl]<ulong, void*>)Load(pGetProcAddress, "object_get_instance_from_id"u8);
        s_objectGetInstanceId = (delegate* unmanaged[Cdecl]<void*, ulong>)Load(pGetProcAddress, "object_get_instance_id"u8);
        s_objectHasScriptMethod = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, bool>)Load(pGetProcAddress, "object_has_script_method"u8);
        s_objectCallScriptMethod = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void>)Load(pGetProcAddress, "object_call_script_method"u8);
        s_refGetObject = (delegate* unmanaged[Cdecl]<void*, void*>)Load(pGetProcAddress, "ref_get_object"u8);
        s_refSetObject = (delegate* unmanaged[Cdecl]<void*, void*, void>)Load(pGetProcAddress, "ref_set_object"u8);
        s_scriptInstanceCreate = (delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, void*, void*>)Load(pGetProcAddress, "script_instance_create"u8);
        s_scriptInstanceCreate2 = (delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, void*, void*>)Load(pGetProcAddress, "script_instance_create2"u8);
        s_scriptInstanceCreate3 = (delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo3*, void*, void*>)Load(pGetProcAddress, "script_instance_create3"u8);
        s_placeholderScriptInstanceCreate = (delegate* unmanaged[Cdecl]<void*, void*, void*, void*>)Load(pGetProcAddress, "placeholder_script_instance_create"u8);
        s_placeholderScriptInstanceUpdate = (delegate* unmanaged[Cdecl]<void*, void*, void*, void>)Load(pGetProcAddress, "placeholder_script_instance_update"u8);
        s_objectGetScriptInstance = (delegate* unmanaged[Cdecl]<void*, void*, void*>)Load(pGetProcAddress, "object_get_script_instance"u8);
        s_objectSetScriptInstance = (delegate* unmanaged[Cdecl]<void*, void*, void>)Load(pGetProcAddress, "object_set_script_instance"u8);
        s_callableCustomCreate = (delegate* unmanaged[Cdecl]<void*, GDExtensionCallableCustomInfo*, void>)Load(pGetProcAddress, "callable_custom_create"u8);
        s_callableCustomCreate2 = (delegate* unmanaged[Cdecl]<void*, GDExtensionCallableCustomInfo2*, void>)Load(pGetProcAddress, "callable_custom_create2"u8);
        s_callableCustomGetUserData = (delegate* unmanaged[Cdecl]<void*, void*, void*>)Load(pGetProcAddress, "callable_custom_get_userdata"u8);
        s_classDBConstructObject = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*>)Load(pGetProcAddress, "classdb_construct_object"u8);
        s_classDBConstructObject2 = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*>)Load(pGetProcAddress, "classdb_construct_object2"u8);
        s_classDBConstructObject3 = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*>)Load(pGetProcAddress, "classdb_construct_object3"u8);
        s_classDBGetMethodBind = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, GDExtensionStringName*, long, void*>)Load(pGetProcAddress, "classdb_get_method_bind"u8);
        s_classDBGetClassTag = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*>)Load(pGetProcAddress, "classdb_get_class_tag"u8);
        s_classDBRegisterExtensionClass = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo*, void>)Load(pGetProcAddress, "classdb_register_extension_class"u8);
        s_classDBRegisterExtensionClass2 = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo2*, void>)Load(pGetProcAddress, "classdb_register_extension_class2"u8);
        s_classDBRegisterExtensionClass3 = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo3*, void>)Load(pGetProcAddress, "classdb_register_extension_class3"u8);
        s_classDBRegisterExtensionClass4 = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo4*, void>)Load(pGetProcAddress, "classdb_register_extension_class4"u8);
        s_classDBRegisterExtensionClass5 = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo4*, void>)Load(pGetProcAddress, "classdb_register_extension_class5"u8);
        s_classDBRegisterExtensionClass6 = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo6*, void>)Load(pGetProcAddress, "classdb_register_extension_class6"u8);
        s_classDBRegisterExtensionClassMethod = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionClassMethodInfo*, void>)Load(pGetProcAddress, "classdb_register_extension_class_method"u8);
        s_classDBRegisterExtensionClassVirtualMethod = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionClassVirtualMethodInfo*, void>)Load(pGetProcAddress, "classdb_register_extension_class_virtual_method"u8);
        s_classDBRegisterExtensionClassIntegerConstant = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionStringName*, long, bool, void>)Load(pGetProcAddress, "classdb_register_extension_class_integer_constant"u8);
        s_classDBRegisterExtensionClassProperty = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionPropertyInfo*, GDExtensionStringName*, GDExtensionStringName*, void>)Load(pGetProcAddress, "classdb_register_extension_class_property"u8);
        s_classDBRegisterExtensionClassPropertyIndexed = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionPropertyInfo*, GDExtensionStringName*, GDExtensionStringName*, long, void>)Load(pGetProcAddress, "classdb_register_extension_class_property_indexed"u8);
        s_classDBRegisterExtensionClassPropertyGroup = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionString*, GDExtensionString*, void>)Load(pGetProcAddress, "classdb_register_extension_class_property_group"u8);
        s_classDBRegisterExtensionClassPropertySubgroup = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionString*, GDExtensionString*, void>)Load(pGetProcAddress, "classdb_register_extension_class_property_subgroup"u8);
        s_classDBRegisterExtensionClassSignal = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionPropertyInfo*, long, void>)Load(pGetProcAddress, "classdb_register_extension_class_signal"u8);
        s_classDBUnregisterExtensionClass = (delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, void>)Load(pGetProcAddress, "classdb_unregister_extension_class"u8);
        s_getLibraryPath = (delegate* unmanaged[Cdecl]<void*, GDExtensionString*, void>)Load(pGetProcAddress, "get_library_path"u8);
        s_editorAddPlugin = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, void>)Load(pGetProcAddress, "editor_add_plugin"u8);
        s_editorRemovePlugin = (delegate* unmanaged[Cdecl]<GDExtensionStringName*, void>)Load(pGetProcAddress, "editor_remove_plugin"u8);
        s_editorHelpLoadXmlFromUtf8Chars = (delegate* unmanaged[Cdecl]<byte*, void>)Load(pGetProcAddress, "editor_help_load_xml_from_utf8_chars"u8);
        s_editorHelpLoadXmlFromUtf8CharsAndLen = (delegate* unmanaged[Cdecl]<byte*, long, void>)Load(pGetProcAddress, "editor_help_load_xml_from_utf8_chars_and_len"u8);
        s_editorRegisterGetClassesUsedCallback = (delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void>, void>)Load(pGetProcAddress, "editor_register_get_classes_used_callback"u8);
        s_registerMainLoopCallbacks = (delegate* unmanaged[Cdecl]<void*, GDExtensionMainLoopCallbacks*, void>)Load(pGetProcAddress, "register_main_loop_callbacks"u8);
    }

    /// <summary>
    /// Gets the Godot version that the GDExtension was loaded into.
    /// </summary>
    /// <param name="rGodotVersion">
    /// A pointer to the structure to write the version information into.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.5. Use `GetGodotVersion2` instead.")]
    public static void GetGodotVersion(GDExtensionGodotVersion* rGodotVersion)
    {
        delegate* unmanaged[Cdecl]<GDExtensionGodotVersion*, void> function = s_getGodotVersion;
        ThrowIfInvalid(function);
        function(rGodotVersion);
    }

    /// <summary>
    /// Gets the Godot version that the GDExtension was loaded into.
    /// </summary>
    /// <param name="rGodotVersion">
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
    /// <param name="pBytes">
    /// The amount of memory to allocate in bytes.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or null if unsuccessful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.6. Does not allow explicitly requesting padding. Use `MemAlloc2` instead.")]
    public static void* MemAlloc(nuint pBytes)
    {
        delegate* unmanaged[Cdecl]<nuint, void*> function = s_memAlloc;
        ThrowIfInvalid(function);
        return function(pBytes);
    }

    /// <summary>
    /// Reallocates memory.
    /// </summary>
    /// <param name="pPtr">
    /// A pointer to the previously allocated memory.
    /// </param>
    /// <param name="pBytes">
    /// The number of bytes to resize the memory block to.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or null if unsuccessful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.6. Does not allow explicitly requesting padding. Use `MemRealloc2` instead.")]
    public static void* MemRealloc(void* pPtr, nuint pBytes)
    {
        delegate* unmanaged[Cdecl]<void*, nuint, void*> function = s_memRealloc;
        ThrowIfInvalid(function);
        return function(pPtr, pBytes);
    }

    /// <summary>
    /// Frees memory.
    /// </summary>
    /// <param name="pPtr">
    /// A pointer to the previously allocated memory.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.6. Does not allow explicitly requesting padding. Use `MemFree2` instead.")]
    public static void MemFree(void* pPtr)
    {
        delegate* unmanaged[Cdecl]<void*, void> function = s_memFree;
        ThrowIfInvalid(function);
        function(pPtr);
    }

    /// <summary>
    /// Allocates memory.
    /// </summary>
    /// <param name="pBytes">
    /// The amount of memory to allocate in bytes.
    /// </param>
    /// <param name="pPadAlign">
    /// If true, the returned memory will have prepadding of at least 8 bytes.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or null if unsuccessful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* MemAlloc2(nuint pBytes, bool pPadAlign)
    {
        delegate* unmanaged[Cdecl]<nuint, bool, void*> function = s_memAlloc2;
        ThrowIfInvalid(function);
        return function(pBytes, pPadAlign);
    }

    /// <summary>
    /// Reallocates memory.
    /// </summary>
    /// <param name="pPtr">
    /// A pointer to the previously allocated memory.
    /// </param>
    /// <param name="pBytes">
    /// The number of bytes to resize the memory block to.
    /// </param>
    /// <param name="pPadAlign">
    /// If true, the returned memory will have prepadding of at least 8 bytes.
    /// </param>
    /// <returns>
    /// A pointer to the allocated memory, or null if unsuccessful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* MemRealloc2(void* pPtr, nuint pBytes, bool pPadAlign)
    {
        delegate* unmanaged[Cdecl]<void*, nuint, bool, void*> function = s_memRealloc2;
        ThrowIfInvalid(function);
        return function(pPtr, pBytes, pPadAlign);
    }

    /// <summary>
    /// Frees memory.
    /// </summary>
    /// <param name="pPtr">
    /// A pointer to the previously allocated memory.
    /// </param>
    /// <param name="pPadAlign">
    /// If true, the given memory was allocated with prepadding.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MemFree2(void* pPtr, bool pPadAlign)
    {
        delegate* unmanaged[Cdecl]<void*, bool, void> function = s_memFree2;
        ThrowIfInvalid(function);
        function(pPtr, pPadAlign);
    }

    /// <summary>
    /// Logs an error to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="pDescription">
    /// The code triggering the error.
    /// </param>
    /// <param name="pFunction">
    /// The function name where the error occurred.
    /// </param>
    /// <param name="pFile">
    /// The file where the error occurred.
    /// </param>
    /// <param name="pLine">
    /// The line where the error occurred.
    /// </param>
    /// <param name="pEditorNotify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PrintError(byte* pDescription, byte* pFunction, byte* pFile, int pLine, bool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, bool, void> function = s_printError;
        ThrowIfInvalid(function);
        function(pDescription, pFunction, pFile, pLine, pEditorNotify);
    }

    /// <summary>
    /// Logs an error with a message to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="pDescription">
    /// The code triggering the error.
    /// </param>
    /// <param name="pMessage">
    /// The message to show along with the error.
    /// </param>
    /// <param name="pFunction">
    /// The function name where the error occurred.
    /// </param>
    /// <param name="pFile">
    /// The file where the error occurred.
    /// </param>
    /// <param name="pLine">
    /// The line where the error occurred.
    /// </param>
    /// <param name="pEditorNotify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PrintErrorWithMessage(byte* pDescription, byte* pMessage, byte* pFunction, byte* pFile, int pLine, bool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, bool, void> function = s_printErrorWithMessage;
        ThrowIfInvalid(function);
        function(pDescription, pMessage, pFunction, pFile, pLine, pEditorNotify);
    }

    /// <summary>
    /// Logs a warning to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="pDescription">
    /// The code triggering the warning.
    /// </param>
    /// <param name="pFunction">
    /// The function name where the warning occurred.
    /// </param>
    /// <param name="pFile">
    /// The file where the warning occurred.
    /// </param>
    /// <param name="pLine">
    /// The line where the warning occurred.
    /// </param>
    /// <param name="pEditorNotify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PrintWarning(byte* pDescription, byte* pFunction, byte* pFile, int pLine, bool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, bool, void> function = s_printWarning;
        ThrowIfInvalid(function);
        function(pDescription, pFunction, pFile, pLine, pEditorNotify);
    }

    /// <summary>
    /// Logs a warning with a message to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="pDescription">
    /// The code triggering the warning.
    /// </param>
    /// <param name="pMessage">
    /// The message to show along with the warning.
    /// </param>
    /// <param name="pFunction">
    /// The function name where the warning occurred.
    /// </param>
    /// <param name="pFile">
    /// The file where the warning occurred.
    /// </param>
    /// <param name="pLine">
    /// The line where the warning occurred.
    /// </param>
    /// <param name="pEditorNotify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PrintWarningWithMessage(byte* pDescription, byte* pMessage, byte* pFunction, byte* pFile, int pLine, bool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, bool, void> function = s_printWarningWithMessage;
        ThrowIfInvalid(function);
        function(pDescription, pMessage, pFunction, pFile, pLine, pEditorNotify);
    }

    /// <summary>
    /// Logs a script error to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="pDescription">
    /// The code triggering the error.
    /// </param>
    /// <param name="pFunction">
    /// The function name where the error occurred.
    /// </param>
    /// <param name="pFile">
    /// The file where the error occurred.
    /// </param>
    /// <param name="pLine">
    /// The line where the error occurred.
    /// </param>
    /// <param name="pEditorNotify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PrintScriptError(byte* pDescription, byte* pFunction, byte* pFile, int pLine, bool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, bool, void> function = s_printScriptError;
        ThrowIfInvalid(function);
        function(pDescription, pFunction, pFile, pLine, pEditorNotify);
    }

    /// <summary>
    /// Logs a script error with a message to Godot's built-in debugger and to the OS terminal.
    /// </summary>
    /// <param name="pDescription">
    /// The code triggering the error.
    /// </param>
    /// <param name="pMessage">
    /// The message to show along with the error.
    /// </param>
    /// <param name="pFunction">
    /// The function name where the error occurred.
    /// </param>
    /// <param name="pFile">
    /// The file where the error occurred.
    /// </param>
    /// <param name="pLine">
    /// The line where the error occurred.
    /// </param>
    /// <param name="pEditorNotify">
    /// Whether or not to notify the editor.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PrintScriptErrorWithMessage(byte* pDescription, byte* pMessage, byte* pFunction, byte* pFile, int pLine, bool pEditorNotify)
    {
        delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, bool, void> function = s_printScriptErrorWithMessage;
        ThrowIfInvalid(function);
        function(pDescription, pMessage, pFunction, pFile, pLine, pEditorNotify);
    }

    /// <summary>
    /// Gets the size of a native struct (ex. ObjectID) in bytes.
    /// </summary>
    /// <param name="pName">
    /// A pointer to a StringName identifying the struct name.
    /// </param>
    /// <returns>
    /// The size in bytes.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong GetNativeStructSize(GDExtensionStringName* pName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, ulong> function = s_getNativeStructSize;
        ThrowIfInvalid(function);
        return function(pName);
    }

    /// <summary>
    /// Copies one Variant into a another.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to the destination Variant.
    /// </param>
    /// <param name="pSrc">
    /// A pointer to the source Variant.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantNewCopy(GDExtensionVariant* rDest, GDExtensionVariant* pSrc)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, void> function = s_variantNewCopy;
        ThrowIfInvalid(function);
        function(rDest, pSrc);
    }

    /// <summary>
    /// Creates a new Variant containing nil.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to the destination Variant.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantNewNil(GDExtensionVariant* rDest)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, void> function = s_variantNewNil;
        ThrowIfInvalid(function);
        function(rDest);
    }

    /// <summary>
    /// Destroys a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant to destroy.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantDestroy(GDExtensionVariant* pSelf)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, void> function = s_variantDestroy;
        ThrowIfInvalid(function);
        function(pSelf);
    }

    /// <summary>
    /// Calls a method on a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pMethod">
    /// A pointer to a StringName identifying the method.
    /// </param>
    /// <param name="pArgs">
    /// A pointer to a C array of Variant.
    /// </param>
    /// <param name="pArgumentCount">
    /// The number of arguments.
    /// </param>
    /// <param name="rReturn">
    /// A pointer a Variant which will be assigned the return value.
    /// </param>
    /// <param name="rError">
    /// A pointer the structure which will hold error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantCall(GDExtensionVariant* pSelf, GDExtensionStringName* pMethod, GDExtensionVariant** pArgs, long pArgumentCount, GDExtensionVariant* rReturn, GDExtensionCallError* rError)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> function = s_variantCall;
        ThrowIfInvalid(function);
        function(pSelf, pMethod, pArgs, pArgumentCount, rReturn, rError);
    }

    /// <summary>
    /// Calls a static method on a Variant.
    /// </summary>
    /// <param name="pType">
    /// The variant type.
    /// </param>
    /// <param name="pMethod">
    /// A pointer to a StringName identifying the method.
    /// </param>
    /// <param name="pArgs">
    /// A pointer to a C array of Variant.
    /// </param>
    /// <param name="pArgumentCount">
    /// The number of arguments.
    /// </param>
    /// <param name="rReturn">
    /// A pointer a Variant which will be assigned the return value.
    /// </param>
    /// <param name="rError">
    /// A pointer the structure which will be updated with error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantCallStatic(GDExtensionVariantType pType, GDExtensionStringName* pMethod, GDExtensionVariant** pArgs, long pArgumentCount, GDExtensionVariant* rReturn, GDExtensionCallError* rError)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> function = s_variantCallStatic;
        ThrowIfInvalid(function);
        function(pType, pMethod, pArgs, pArgumentCount, rReturn, rError);
    }

    /// <summary>
    /// Evaluate an operator on two Variants.
    /// </summary>
    /// <param name="pOp">
    /// The operator to evaluate.
    /// </param>
    /// <param name="pA">
    /// The first Variant.
    /// </param>
    /// <param name="pB">
    /// The second Variant.
    /// </param>
    /// <param name="rReturn">
    /// A pointer a Variant which will be assigned the return value.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantEvaluate(GDExtensionVariantOperator pOp, GDExtensionVariant* pA, GDExtensionVariant* pB, GDExtensionVariant* rReturn, bool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> function = s_variantEvaluate;
        ThrowIfInvalid(function);
        function(pOp, pA, pB, rReturn, rValid);
    }

    /// <summary>
    /// Sets a key on a Variant to a value.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pKey">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <param name="pValue">
    /// A pointer to a Variant representing the value.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantSet(GDExtensionVariant* pSelf, GDExtensionVariant* pKey, GDExtensionVariant* pValue, bool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> function = s_variantSet;
        ThrowIfInvalid(function);
        function(pSelf, pKey, pValue, rValid);
    }

    /// <summary>
    /// Sets a named key on a Variant to a value.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pKey">
    /// A pointer to a StringName representing the key.
    /// </param>
    /// <param name="pValue">
    /// A pointer to a Variant representing the value.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantSetNamed(GDExtensionVariant* pSelf, GDExtensionStringName* pKey, GDExtensionVariant* pValue, bool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, GDExtensionVariant*, bool*, void> function = s_variantSetNamed;
        ThrowIfInvalid(function);
        function(pSelf, pKey, pValue, rValid);
    }

    /// <summary>
    /// Sets a keyed property on a Variant to a value.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pKey">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <param name="pValue">
    /// A pointer to a Variant representing the value.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantSetKeyed(GDExtensionVariant* pSelf, GDExtensionVariant* pKey, GDExtensionVariant* pValue, bool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> function = s_variantSetKeyed;
        ThrowIfInvalid(function);
        function(pSelf, pKey, pValue, rValid);
    }

    /// <summary>
    /// Sets an index on a Variant to a value.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pIndex">
    /// The index.
    /// </param>
    /// <param name="pValue">
    /// A pointer to a Variant representing the value.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    /// <param name="rOob">
    /// A pointer to a boolean which will be set to true if the index is out of bounds.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantSetIndexed(GDExtensionVariant* pSelf, long pIndex, GDExtensionVariant* pValue, bool* rValid, bool* rOob)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, long, GDExtensionVariant*, bool*, bool*, void> function = s_variantSetIndexed;
        ThrowIfInvalid(function);
        function(pSelf, pIndex, pValue, rValid, rOob);
    }

    /// <summary>
    /// Gets the value of a key from a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pKey">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <param name="rRet">
    /// A pointer to a Variant which will be assigned the value.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantGet(GDExtensionVariant* pSelf, GDExtensionVariant* pKey, GDExtensionVariant* rRet, bool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> function = s_variantGet;
        ThrowIfInvalid(function);
        function(pSelf, pKey, rRet, rValid);
    }

    /// <summary>
    /// Gets the value of a named key from a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pKey">
    /// A pointer to a StringName representing the key.
    /// </param>
    /// <param name="rRet">
    /// A pointer to a Variant which will be assigned the value.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantGetNamed(GDExtensionVariant* pSelf, GDExtensionStringName* pKey, GDExtensionVariant* rRet, bool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, GDExtensionVariant*, bool*, void> function = s_variantGetNamed;
        ThrowIfInvalid(function);
        function(pSelf, pKey, rRet, rValid);
    }

    /// <summary>
    /// Gets the value of a keyed property from a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pKey">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <param name="rRet">
    /// A pointer to a Variant which will be assigned the value.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantGetKeyed(GDExtensionVariant* pSelf, GDExtensionVariant* pKey, GDExtensionVariant* rRet, bool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> function = s_variantGetKeyed;
        ThrowIfInvalid(function);
        function(pSelf, pKey, rRet, rValid);
    }

    /// <summary>
    /// Gets the value of an index from a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pIndex">
    /// The index.
    /// </param>
    /// <param name="rRet">
    /// A pointer to a Variant which will be assigned the value.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    /// <param name="rOob">
    /// A pointer to a boolean which will be set to true if the index is out of bounds.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantGetIndexed(GDExtensionVariant* pSelf, long pIndex, GDExtensionVariant* rRet, bool* rValid, bool* rOob)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, long, GDExtensionVariant*, bool*, bool*, void> function = s_variantGetIndexed;
        ThrowIfInvalid(function);
        function(pSelf, pIndex, rRet, rValid, rOob);
    }

    /// <summary>
    /// Initializes an iterator over a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="rIter">
    /// A pointer to a Variant which will be assigned the iterator.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    /// <returns>
    /// true if the operation is valid; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool VariantIterInit(GDExtensionVariant* pSelf, GDExtensionVariant* rIter, bool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool*, bool> function = s_variantIterInit;
        ThrowIfInvalid(function);
        return function(pSelf, rIter, rValid);
    }

    /// <summary>
    /// Gets the next value for an iterator over a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="rIter">
    /// A pointer to a Variant which will be assigned the iterator.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    /// <returns>
    /// true if the operation is valid; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool VariantIterNext(GDExtensionVariant* pSelf, GDExtensionVariant* rIter, bool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool*, bool> function = s_variantIterNext;
        ThrowIfInvalid(function);
        return function(pSelf, rIter, rValid);
    }

    /// <summary>
    /// Gets the next value for an iterator over a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="rIter">
    /// A pointer to a Variant which will be assigned the iterator.
    /// </param>
    /// <param name="rRet">
    /// A pointer to a Variant which will be assigned false if the operation is invalid.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the operation is invalid.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantIterGet(GDExtensionVariant* pSelf, GDExtensionVariant* rIter, GDExtensionVariant* rRet, bool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, GDExtensionVariant*, bool*, void> function = s_variantIterGet;
        ThrowIfInvalid(function);
        function(pSelf, rIter, rRet, rValid);
    }

    /// <summary>
    /// Gets the hash of a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <returns>
    /// The hash value.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long VariantHash(GDExtensionVariant* pSelf)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, long> function = s_variantHash;
        ThrowIfInvalid(function);
        return function(pSelf);
    }

    /// <summary>
    /// Gets the recursive hash of a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pRecursionCount">
    /// The number of recursive loops so far.
    /// </param>
    /// <returns>
    /// The hash value.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long VariantRecursiveHash(GDExtensionVariant* pSelf, long pRecursionCount)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, long, long> function = s_variantRecursiveHash;
        ThrowIfInvalid(function);
        return function(pSelf, pRecursionCount);
    }

    /// <summary>
    /// Compares two Variants by their hash.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pOther">
    /// A pointer to the other Variant to compare it to.
    /// </param>
    /// <returns>
    /// The hash value.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool VariantHashCompare(GDExtensionVariant* pSelf, GDExtensionVariant* pOther)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool> function = s_variantHashCompare;
        ThrowIfInvalid(function);
        return function(pSelf, pOther);
    }

    /// <summary>
    /// Converts a Variant to a boolean.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <returns>
    /// The boolean value of the Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool VariantBooleanize(GDExtensionVariant* pSelf)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, bool> function = s_variantBooleanize;
        ThrowIfInvalid(function);
        return function(pSelf);
    }

    /// <summary>
    /// Duplicates a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="rRet">
    /// A pointer to a Variant to store the duplicated value.
    /// </param>
    /// <param name="pDeep">
    /// Whether or not to duplicate deeply (when supported by the Variant type).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantDuplicate(GDExtensionVariant* pSelf, GDExtensionVariant* rRet, bool pDeep)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool, void> function = s_variantDuplicate;
        ThrowIfInvalid(function);
        function(pSelf, rRet, pDeep);
    }

    /// <summary>
    /// Converts a Variant to a string.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="rRet">
    /// A pointer to a String to store the resulting value.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantStringify(GDExtensionVariant* pSelf, GDExtensionString* rRet)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionString*, void> function = s_variantStringify;
        ThrowIfInvalid(function);
        function(pSelf, rRet);
    }

    /// <summary>
    /// Gets the type of a Variant.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <returns>
    /// The variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariantType VariantGetType(GDExtensionVariant* pSelf)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariantType> function = s_variantGetType;
        ThrowIfInvalid(function);
        return function(pSelf);
    }

    /// <summary>
    /// Checks if a Variant has the given method.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pMethod">
    /// A pointer to a StringName with the method name.
    /// </param>
    /// <returns>
    /// true if the variant has the given method; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool VariantHasMethod(GDExtensionVariant* pSelf, GDExtensionStringName* pMethod)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionStringName*, bool> function = s_variantHasMethod;
        ThrowIfInvalid(function);
        return function(pSelf, pMethod);
    }

    /// <summary>
    /// Checks if a type of Variant has the given member.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <param name="pMember">
    /// A pointer to a StringName with the member name.
    /// </param>
    /// <returns>
    /// true if the variant has the given method; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool VariantHasMember(GDExtensionVariantType pType, GDExtensionStringName* pMember)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, bool> function = s_variantHasMember;
        ThrowIfInvalid(function);
        return function(pType, pMember);
    }

    /// <summary>
    /// Checks if a Variant has a key.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <param name="pKey">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <param name="rValid">
    /// A pointer to a boolean which will be set to false if the key doesn't exist.
    /// </param>
    /// <returns>
    /// true if the key exists; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool VariantHasKey(GDExtensionVariant* pSelf, GDExtensionVariant* pKey, bool* rValid)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, bool*, bool> function = s_variantHasKey;
        ThrowIfInvalid(function);
        return function(pSelf, pKey, rValid);
    }

    /// <summary>
    /// Gets the object instance ID from a variant of type Object.<br/>
    /// If the variant isn't of type Object, then zero will be returned.<br/>
    /// The instance ID will be returned even if the object is no longer valid - use `object_get_instance_by_id()` to check if the object is still valid.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Variant.
    /// </param>
    /// <returns>
    /// The instance ID for the contained object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong VariantGetObjectInstanceId(GDExtensionVariant* pSelf)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariant*, ulong> function = s_variantGetObjectInstanceId;
        ThrowIfInvalid(function);
        return function(pSelf);
    }

    /// <summary>
    /// Gets the name of a Variant type.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <param name="rName">
    /// A pointer to a String to store the Variant type name.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantGetTypeName(GDExtensionVariantType pType, GDExtensionString* rName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionString*, void> function = s_variantGetTypeName;
        ThrowIfInvalid(function);
        function(pType, rName);
    }

    /// <summary>
    /// Gets the Variant type by name.
    /// </summary>
    /// <param name="pTypeName">
    /// The variant type name.
    /// </param>
    /// <returns>
    /// The variant type for the given name; otherwise VARIANT_MAX if name is invalid.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariantType VariantGetTypeByName(GDExtensionString* pTypeName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, GDExtensionVariantType> function = s_variantGetTypeByName;
        ThrowIfInvalid(function);
        return function(pTypeName);
    }

    /// <summary>
    /// Checks if Variants can be converted from one type to another.
    /// </summary>
    /// <param name="pFrom">
    /// The Variant type to convert from.
    /// </param>
    /// <param name="pTo">
    /// The Variant type to convert to.
    /// </param>
    /// <returns>
    /// true if the conversion is possible; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool VariantCanConvert(GDExtensionVariantType pFrom, GDExtensionVariantType pTo)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, bool> function = s_variantCanConvert;
        ThrowIfInvalid(function);
        return function(pFrom, pTo);
    }

    /// <summary>
    /// Checks if Variant can be converted from one type to another using stricter rules.
    /// </summary>
    /// <param name="pFrom">
    /// The Variant type to convert from.
    /// </param>
    /// <param name="pTo">
    /// The Variant type to convert to.
    /// </param>
    /// <returns>
    /// true if the conversion is possible; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool VariantCanConvertStrict(GDExtensionVariantType pFrom, GDExtensionVariantType pTo)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariantType, bool> function = s_variantCanConvertStrict;
        ThrowIfInvalid(function);
        return function(pFrom, pTo);
    }

    /// <summary>
    /// Gets a pointer to a function that can create a Variant of the given type from a raw value.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can create a Variant of the given type from a raw value.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<GDExtensionVariant*, void*, void> GetVariantFromTypeConstructor(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<GDExtensionVariant*, void*, void>> function = s_getVariantFromTypeConstructor;
        ThrowIfInvalid(function);
        return function(pType);
    }

    /// <summary>
    /// Gets a pointer to a function that can get the raw value from a Variant of the given type.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can get the raw value from a Variant of the given type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, GDExtensionVariant*, void> GetVariantToTypeConstructor(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, GDExtensionVariant*, void>> function = s_getVariantToTypeConstructor;
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
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a type-specific function that returns a pointer to the internal value of a variant. Check the implementation of this function (gdextension_variant_get_ptr_internal_getter) for pointee type info of each variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<GDExtensionVariant*, void*> VariantGetPtrInternalGetter(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<GDExtensionVariant*, void*>> function = s_variantGetPtrInternalGetter;
        ThrowIfInvalid(function);
        return function(pType);
    }

    /// <summary>
    /// Gets a pointer to a function that can evaluate the given Variant operator on the given Variant types.
    /// </summary>
    /// <param name="pOperator">
    /// The variant operator.
    /// </param>
    /// <param name="pTypeA">
    /// The type of the first Variant.
    /// </param>
    /// <param name="pTypeB">
    /// The type of the second Variant.
    /// </param>
    /// <returns>
    /// A pointer to a function that can evaluate the given Variant operator on the given Variant types.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, void*, void*, void> VariantGetPtrOperatorEvaluator(GDExtensionVariantOperator pOperator, GDExtensionVariantType pTypeA, GDExtensionVariantType pTypeB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantOperator, GDExtensionVariantType, GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>> function = s_variantGetPtrOperatorEvaluator;
        ThrowIfInvalid(function);
        return function(pOperator, pTypeA, pTypeB);
    }

    /// <summary>
    /// Gets a pointer to a function that can call a builtin method on a type of Variant.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <param name="pMethod">
    /// A pointer to a StringName with the method name.
    /// </param>
    /// <param name="pHash">
    /// A hash representing the method signature.
    /// </param>
    /// <returns>
    /// A pointer to a function that can call a builtin method on a type of Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, void**, void*, int, void> VariantGetPtrBuiltinMethod(GDExtensionVariantType pType, GDExtensionStringName* pMethod, long pHash)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, long, delegate* unmanaged[Cdecl]<void*, void**, void*, int, void>> function = s_variantGetPtrBuiltinMethod;
        ThrowIfInvalid(function);
        return function(pType, pMethod, pHash);
    }

    /// <summary>
    /// Gets a pointer to a function that can call one of the constructors for a type of Variant.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <param name="pConstructor">
    /// The index of the constructor.
    /// </param>
    /// <returns>
    /// A pointer to a function that can call one of the constructors for a type of Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, void**, void> VariantGetPtrConstructor(GDExtensionVariantType pType, int pConstructor)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, int, delegate* unmanaged[Cdecl]<void*, void**, void>> function = s_variantGetPtrConstructor;
        ThrowIfInvalid(function);
        return function(pType, pConstructor);
    }

    /// <summary>
    /// Gets a pointer to a function than can call the destructor for a type of Variant.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function than can call the destructor for a type of Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, void> VariantGetPtrDestructor(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void>> function = s_variantGetPtrDestructor;
        ThrowIfInvalid(function);
        return function(pType);
    }

    /// <summary>
    /// Constructs a Variant of the given type, using the first constructor that matches the given arguments.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <param name="rBase">
    /// A pointer to a Variant to store the constructed value.
    /// </param>
    /// <param name="pArgs">
    /// A pointer to a C array of Variant pointers representing the arguments for the constructor.
    /// </param>
    /// <param name="pArgumentCount">
    /// The number of arguments to pass to the constructor.
    /// </param>
    /// <param name="rError">
    /// A pointer the structure which will be updated with error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantConstruct(GDExtensionVariantType pType, GDExtensionVariant* rBase, GDExtensionVariant** pArgs, int pArgumentCount, GDExtensionCallError* rError)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionVariant*, GDExtensionVariant**, int, GDExtensionCallError*, void> function = s_variantConstruct;
        ThrowIfInvalid(function);
        function(pType, rBase, pArgs, pArgumentCount, rError);
    }

    /// <summary>
    /// Gets a pointer to a function that can call a member's setter on the given Variant type.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <param name="pMember">
    /// A pointer to a StringName with the member name.
    /// </param>
    /// <returns>
    /// A pointer to a function that can call a member's setter on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, void*, void> VariantGetPtrSetter(GDExtensionVariantType pType, GDExtensionStringName* pMember)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, delegate* unmanaged[Cdecl]<void*, void*, void>> function = s_variantGetPtrSetter;
        ThrowIfInvalid(function);
        return function(pType, pMember);
    }

    /// <summary>
    /// Gets a pointer to a function that can call a member's getter on the given Variant type.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <param name="pMember">
    /// A pointer to a StringName with the member name.
    /// </param>
    /// <returns>
    /// A pointer to a function that can call a member's getter on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, void*, void> VariantGetPtrGetter(GDExtensionVariantType pType, GDExtensionStringName* pMember)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, delegate* unmanaged[Cdecl]<void*, void*, void>> function = s_variantGetPtrGetter;
        ThrowIfInvalid(function);
        return function(pType, pMember);
    }

    /// <summary>
    /// Gets a pointer to a function that can set an index on the given Variant type.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can set an index on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, long, void*, void> VariantGetPtrIndexedSetter(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, long, void*, void>> function = s_variantGetPtrIndexedSetter;
        ThrowIfInvalid(function);
        return function(pType);
    }

    /// <summary>
    /// Gets a pointer to a function that can get an index on the given Variant type.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can get an index on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, long, void*, void> VariantGetPtrIndexedGetter(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, long, void*, void>> function = s_variantGetPtrIndexedGetter;
        ThrowIfInvalid(function);
        return function(pType);
    }

    /// <summary>
    /// Gets a pointer to a function that can set a key on the given Variant type.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can set a key on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, void*, void*, void> VariantGetPtrKeyedSetter(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>> function = s_variantGetPtrKeyedSetter;
        ThrowIfInvalid(function);
        return function(pType);
    }

    /// <summary>
    /// Gets a pointer to a function that can get a key on the given Variant type.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can get a key on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, void*, void*, void> VariantGetPtrKeyedGetter(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>> function = s_variantGetPtrKeyedGetter;
        ThrowIfInvalid(function);
        return function(pType);
    }

    /// <summary>
    /// Gets a pointer to a function that can check a key on the given Variant type.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <returns>
    /// A pointer to a function that can check a key on the given Variant type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, uint> VariantGetPtrKeyedChecker(GDExtensionVariantType pType)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, delegate* unmanaged[Cdecl]<GDExtensionVariant*, GDExtensionVariant*, uint>> function = s_variantGetPtrKeyedChecker;
        ThrowIfInvalid(function);
        return function(pType);
    }

    /// <summary>
    /// Gets the value of a constant from the given Variant type.
    /// </summary>
    /// <param name="pType">
    /// The Variant type.
    /// </param>
    /// <param name="pConstant">
    /// A pointer to a StringName with the constant name.
    /// </param>
    /// <param name="rRet">
    /// A pointer to a Variant to store the value.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void VariantGetConstantValue(GDExtensionVariantType pType, GDExtensionStringName* pConstant, GDExtensionVariant* rRet)
    {
        delegate* unmanaged[Cdecl]<GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, void> function = s_variantGetConstantValue;
        ThrowIfInvalid(function);
        function(pType, pConstant, rRet);
    }

    /// <summary>
    /// Gets a pointer to a function that can call a Variant utility function.
    /// </summary>
    /// <param name="pFunction">
    /// A pointer to a StringName with the function name.
    /// </param>
    /// <param name="pHash">
    /// A hash representing the function signature.
    /// </param>
    /// <returns>
    /// A pointer to a function that can call a Variant utility function.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static delegate* unmanaged[Cdecl]<void*, void**, int, void> VariantGetPtrUtilityFunction(GDExtensionStringName* pFunction, long pHash)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, long, delegate* unmanaged[Cdecl]<void*, void**, int, void>> function = s_variantGetPtrUtilityFunction;
        ThrowIfInvalid(function);
        return function(pFunction, pHash);
    }

    /// <summary>
    /// Creates a String from a Latin-1 encoded C string.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a Latin-1 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithLatin1Chars(GDExtensionString* rDest, byte* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, void> function = s_stringNewWithLatin1Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
    }

    /// <summary>
    /// Creates a String from a UTF-8 encoded C string.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a UTF-8 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithUtf8Chars(GDExtensionString* rDest, byte* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, void> function = s_stringNewWithUtf8Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
    }

    /// <summary>
    /// Creates a String from a UTF-16 encoded C string.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a UTF-16 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithUtf16Chars(GDExtensionString* rDest, char* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, char*, void> function = s_stringNewWithUtf16Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
    }

    /// <summary>
    /// Creates a String from a UTF-32 encoded C string.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a UTF-32 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithUtf32Chars(GDExtensionString* rDest, uint* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, void> function = s_stringNewWithUtf32Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
    }

    /// <summary>
    /// Creates a String from a wide C string.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a wide C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithWideChars(GDExtensionString* rDest, void* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, void*, void> function = s_stringNewWithWideChars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
    }

    /// <summary>
    /// Creates a String from a Latin-1 encoded C string with the given length.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a Latin-1 encoded C string.
    /// </param>
    /// <param name="pSize">
    /// The number of characters (= number of bytes).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithLatin1CharsAndLen(GDExtensionString* rDest, byte* pContents, long pSize)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, void> function = s_stringNewWithLatin1CharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pSize);
    }

    /// <summary>
    /// Creates a String from a UTF-8 encoded C string with the given length.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a UTF-8 encoded C string.
    /// </param>
    /// <param name="pSize">
    /// The number of bytes (not code units).
    /// </param>
    [Obsolete("Deprecated since Godot 4.3. Use `StringNewWithUtf8CharsAndLen2` instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithUtf8CharsAndLen(GDExtensionString* rDest, byte* pContents, long pSize)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, void> function = s_stringNewWithUtf8CharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pSize);
    }

    /// <summary>
    /// Creates a String from a UTF-8 encoded C string with the given length.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a UTF-8 encoded C string.
    /// </param>
    /// <param name="pSize">
    /// The number of bytes (not code units).
    /// </param>
    /// <returns>
    /// Error code signifying if the operation successful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long StringNewWithUtf8CharsAndLen2(GDExtensionString* rDest, byte* pContents, long pSize)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, long> function = s_stringNewWithUtf8CharsAndLen2;
        ThrowIfInvalid(function);
        return function(rDest, pContents, pSize);
    }

    /// <summary>
    /// Creates a String from a UTF-16 encoded C string with the given length.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a UTF-16 encoded C string.
    /// </param>
    /// <param name="pCharCount">
    /// The number of characters (not bytes).
    /// </param>
    [Obsolete("Deprecated since Godot 4.3. Use `StringNewWithUtf16CharsAndLen2` instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithUtf16CharsAndLen(GDExtensionString* rDest, char* pContents, long pCharCount)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, char*, long, void> function = s_stringNewWithUtf16CharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pCharCount);
    }

    /// <summary>
    /// Creates a String from a UTF-16 encoded C string with the given length.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a UTF-16 encoded C string.
    /// </param>
    /// <param name="pCharCount">
    /// The number of characters (not bytes).
    /// </param>
    /// <param name="pDefaultLittleEndian">
    /// If true, UTF-16 use little endian.
    /// </param>
    /// <returns>
    /// Error code signifying if the operation successful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long StringNewWithUtf16CharsAndLen2(GDExtensionString* rDest, char* pContents, long pCharCount, bool pDefaultLittleEndian)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, char*, long, bool, long> function = s_stringNewWithUtf16CharsAndLen2;
        ThrowIfInvalid(function);
        return function(rDest, pContents, pCharCount, pDefaultLittleEndian);
    }

    /// <summary>
    /// Creates a String from a UTF-32 encoded C string with the given length.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a UTF-32 encoded C string.
    /// </param>
    /// <param name="pCharCount">
    /// The number of characters (not bytes).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithUtf32CharsAndLen(GDExtensionString* rDest, uint* pContents, long pCharCount)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, long, void> function = s_stringNewWithUtf32CharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pCharCount);
    }

    /// <summary>
    /// Creates a String from a wide C string with the given length.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to a Variant to hold the newly created String.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a wide C string.
    /// </param>
    /// <param name="pCharCount">
    /// The number of characters (not bytes).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNewWithWideCharsAndLen(GDExtensionString* rDest, void* pContents, long pCharCount)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, void*, long, void> function = s_stringNewWithWideCharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pCharCount);
    }

    /// <summary>
    /// Converts a String to a Latin-1 encoded C string.<br/>
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="rText">
    /// A pointer to the buffer to hold the resulting data. If null is passed in, only the length will be computed.
    /// </param>
    /// <param name="pMaxWriteLength">
    /// The maximum number of characters that can be written to rText. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in characters, not including a null terminator. Characters that cannot be converted to Latin-1 are replaced with a space.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long StringToLatin1Chars(GDExtensionString* pSelf, byte* rText, long pMaxWriteLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, long> function = s_stringToLatin1Chars;
        ThrowIfInvalid(function);
        return function(pSelf, rText, pMaxWriteLength);
    }

    /// <summary>
    /// Converts a String to a UTF-8 encoded C string.<br/>
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="rText">
    /// A pointer to the buffer to hold the resulting data. If null is passed in, only the length will be computed.
    /// </param>
    /// <param name="pMaxWriteLength">
    /// The maximum number of characters that can be written to rText. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in bytes (not characters), not including a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long StringToUtf8Chars(GDExtensionString* pSelf, byte* rText, long pMaxWriteLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, long, long> function = s_stringToUtf8Chars;
        ThrowIfInvalid(function);
        return function(pSelf, rText, pMaxWriteLength);
    }

    /// <summary>
    /// Converts a String to a UTF-16 encoded C string.<br/>
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="rText">
    /// A pointer to the buffer to hold the resulting data. If null is passed in, only the length will be computed.
    /// </param>
    /// <param name="pMaxWriteLength">
    /// The maximum number of characters that can be written to rText. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in 16-bit code units (not bytes or characters), not including a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long StringToUtf16Chars(GDExtensionString* pSelf, char* rText, long pMaxWriteLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, char*, long, long> function = s_stringToUtf16Chars;
        ThrowIfInvalid(function);
        return function(pSelf, rText, pMaxWriteLength);
    }

    /// <summary>
    /// Converts a String to a UTF-32 encoded C string.<br/>
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="rText">
    /// A pointer to the buffer to hold the resulting data. If null is passed in, only the length will be computed.
    /// </param>
    /// <param name="pMaxWriteLength">
    /// The maximum number of characters that can be written to rText. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in characters (not bytes), not including a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long StringToUtf32Chars(GDExtensionString* pSelf, uint* rText, long pMaxWriteLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, long, long> function = s_stringToUtf32Chars;
        ThrowIfInvalid(function);
        return function(pSelf, rText, pMaxWriteLength);
    }

    /// <summary>
    /// Converts a String to a wide C string.<br/>
    /// It doesn't write a null terminator.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="rText">
    /// A pointer to the buffer to hold the resulting data. If null is passed in, only the length will be computed.
    /// </param>
    /// <param name="pMaxWriteLength">
    /// The maximum number of characters that can be written to rText. It has no affect on the return value.
    /// </param>
    /// <returns>
    /// The resulting encoded string length in characters (for UTF-32) or 16-bit code units (for UTF-16), depending on the wchar_t representation. Does not include a null terminator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long StringToWideChars(GDExtensionString* pSelf, void* rText, long pMaxWriteLength)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, void*, long, long> function = s_stringToWideChars;
        ThrowIfInvalid(function);
        return function(pSelf, rText, pMaxWriteLength);
    }

    /// <summary>
    /// Gets a pointer to the character at the given index from a String.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="pIndex">
    /// The index.
    /// </param>
    /// <returns>
    /// A pointer to the requested character.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint* StringOperatorIndex(GDExtensionString* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, long, uint*> function = s_stringOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to the character at the given index from a String.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="pIndex">
    /// The index.
    /// </param>
    /// <returns>
    /// A const pointer to the requested character.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint* StringOperatorIndexConst(GDExtensionString* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, long, uint*> function = s_stringOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Appends another String to a String.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="pB">
    /// A pointer to the other String to append.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringOperatorPlusEqString(GDExtensionString* pSelf, GDExtensionString* pB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, GDExtensionString*, void> function = s_stringOperatorPlusEqString;
        ThrowIfInvalid(function);
        function(pSelf, pB);
    }

    /// <summary>
    /// Appends a character to a String.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="pB">
    /// A pointer to the character to append.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringOperatorPlusEqChar(GDExtensionString* pSelf, uint pB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, uint, void> function = s_stringOperatorPlusEqChar;
        ThrowIfInvalid(function);
        function(pSelf, pB);
    }

    /// <summary>
    /// Appends a Latin-1 encoded C string to a String.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="pB">
    /// A pointer to a Latin-1 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringOperatorPlusEqCstr(GDExtensionString* pSelf, byte* pB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, byte*, void> function = s_stringOperatorPlusEqCstr;
        ThrowIfInvalid(function);
        function(pSelf, pB);
    }

    /// <summary>
    /// Appends a wide C string to a String.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="pB">
    /// A pointer to a wide C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringOperatorPlusEqWcstr(GDExtensionString* pSelf, void* pB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, void*, void> function = s_stringOperatorPlusEqWcstr;
        ThrowIfInvalid(function);
        function(pSelf, pB);
    }

    /// <summary>
    /// Appends a UTF-32 encoded C string to a String.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="pB">
    /// A pointer to a UTF-32 encoded C string (null terminated).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringOperatorPlusEqC32Str(GDExtensionString* pSelf, uint* pB)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, uint*, void> function = s_stringOperatorPlusEqC32Str;
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
    /// <param name="pSelf">
    /// A pointer to the String.
    /// </param>
    /// <param name="pResize">
    /// The new length for the String.
    /// </param>
    /// <returns>
    /// Error code signifying if the operation successful.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long StringResize(GDExtensionString* pSelf, long pResize)
    {
        delegate* unmanaged[Cdecl]<GDExtensionString*, long, long> function = s_stringResize;
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
    /// <param name="rDest">
    /// A pointer to uninitialized storage, into which the newly created StringName is constructed.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a C string (null terminated and Latin-1 or ASCII encoded).
    /// </param>
    /// <param name="pIsStatic">
    /// Whether the StringName reuses the buffer directly (see above).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNameNewWithLatin1Chars(GDExtensionStringName* rDest, byte* pContents, bool pIsStatic)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, byte*, bool, void> function = s_stringNameNewWithLatin1Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents, pIsStatic);
    }

    /// <summary>
    /// Creates a StringName from a UTF-8 encoded C string.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to uninitialized storage, into which the newly created StringName is constructed.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a C string (null terminated and UTF-8 encoded).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNameNewWithUtf8Chars(GDExtensionStringName* rDest, byte* pContents)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, byte*, void> function = s_stringNameNewWithUtf8Chars;
        ThrowIfInvalid(function);
        function(rDest, pContents);
    }

    /// <summary>
    /// Creates a StringName from a UTF-8 encoded string with a given number of characters.
    /// </summary>
    /// <param name="rDest">
    /// A pointer to uninitialized storage, into which the newly created StringName is constructed.
    /// </param>
    /// <param name="pContents">
    /// A pointer to a C string (null terminated and UTF-8 encoded).
    /// </param>
    /// <param name="pSize">
    /// The number of bytes (not UTF-8 code points).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void StringNameNewWithUtf8CharsAndLen(GDExtensionStringName* rDest, byte* pContents, long pSize)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, byte*, long, void> function = s_stringNameNewWithUtf8CharsAndLen;
        ThrowIfInvalid(function);
        function(rDest, pContents, pSize);
    }

    /// <summary>
    /// Opens a raw XML buffer on an XMLParser instance.
    /// </summary>
    /// <param name="pInstance">
    /// A pointer to an XMLParser object.
    /// </param>
    /// <param name="pBuffer">
    /// A pointer to the buffer.
    /// </param>
    /// <param name="pSize">
    /// The size of the buffer.
    /// </param>
    /// <returns>
    /// A Godot error code (ex. OK, ERR_INVALID_DATA, etc).
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long XmlParserOpenBuffer(void* pInstance, byte* pBuffer, nuint pSize)
    {
        delegate* unmanaged[Cdecl]<void*, byte*, nuint, long> function = s_xmlParserOpenBuffer;
        ThrowIfInvalid(function);
        return function(pInstance, pBuffer, pSize);
    }

    /// <summary>
    /// Stores the given buffer using an instance of FileAccess.
    /// </summary>
    /// <param name="pInstance">
    /// A pointer to a FileAccess object.
    /// </param>
    /// <param name="pSrc">
    /// A pointer to the buffer.
    /// </param>
    /// <param name="pLength">
    /// The size of the buffer.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void FileAccessStoreBuffer(void* pInstance, byte* pSrc, ulong pLength)
    {
        delegate* unmanaged[Cdecl]<void*, byte*, ulong, void> function = s_fileAccessStoreBuffer;
        ThrowIfInvalid(function);
        function(pInstance, pSrc, pLength);
    }

    /// <summary>
    /// Reads the next pLength bytes into the given buffer using an instance of FileAccess.
    /// </summary>
    /// <param name="pInstance">
    /// A pointer to a FileAccess object.
    /// </param>
    /// <param name="pDst">
    /// A pointer to the buffer to store the data.
    /// </param>
    /// <param name="pLength">
    /// The requested number of bytes to read.
    /// </param>
    /// <returns>
    /// The actual number of bytes read (may be less than requested).
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong FileAccessGetBuffer(void* pInstance, byte* pDst, ulong pLength)
    {
        delegate* unmanaged[Cdecl]<void*, byte*, ulong, ulong> function = s_fileAccessGetBuffer;
        ThrowIfInvalid(function);
        return function(pInstance, pDst, pLength);
    }

    /// <summary>
    /// Returns writable pointer to internal Image buffer.
    /// </summary>
    /// <param name="pInstance">
    /// A pointer to a Image object.
    /// </param>
    /// <returns>
    /// Pointer to internal Image buffer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte* ImagePtrw(void* pInstance)
    {
        delegate* unmanaged[Cdecl]<void*, byte*> function = s_imagePtrw;
        ThrowIfInvalid(function);
        return function(pInstance);
    }

    /// <summary>
    /// Returns read only pointer to internal Image buffer.
    /// </summary>
    /// <param name="pInstance">
    /// A pointer to a Image object.
    /// </param>
    /// <returns>
    /// Pointer to internal Image buffer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte* ImagePtr(void* pInstance)
    {
        delegate* unmanaged[Cdecl]<void*, byte*> function = s_imagePtr;
        ThrowIfInvalid(function);
        return function(pInstance);
    }

    /// <summary>
    /// Adds a group task to an instance of WorkerThreadPool.
    /// </summary>
    /// <param name="pInstance">
    /// A pointer to a WorkerThreadPool object.
    /// </param>
    /// <param name="pFunc">
    /// A pointer to a function to run in the thread pool.
    /// </param>
    /// <param name="pUserData">
    /// A pointer to arbitrary data which will be passed to pFunc.
    /// </param>
    /// <param name="pElements">
    /// The number of element needed in the group.
    /// </param>
    /// <param name="pTasks">
    /// The number of tasks needed in the group.
    /// </param>
    /// <param name="pHighPriority">
    /// Whether or not this is a high priority task.
    /// </param>
    /// <param name="pDescription">
    /// A pointer to a String with the task description.
    /// </param>
    /// <returns>
    /// The task group ID.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long WorkerThreadPoolAddNativeGroupTask(void* pInstance, delegate* unmanaged[Cdecl]<void*, uint, void> pFunc, void* pUserData, int pElements, int pTasks, bool pHighPriority, GDExtensionString* pDescription)
    {
        delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, uint, void>, void*, int, int, bool, GDExtensionString*, long> function = s_workerThreadPoolAddNativeGroupTask;
        ThrowIfInvalid(function);
        return function(pInstance, pFunc, pUserData, pElements, pTasks, pHighPriority, pDescription);
    }

    /// <summary>
    /// Adds a task to an instance of WorkerThreadPool.
    /// </summary>
    /// <param name="pInstance">
    /// A pointer to a WorkerThreadPool object.
    /// </param>
    /// <param name="pFunc">
    /// A pointer to a function to run in the thread pool.
    /// </param>
    /// <param name="pUserData">
    /// A pointer to arbitrary data which will be passed to pFunc.
    /// </param>
    /// <param name="pHighPriority">
    /// Whether or not this is a high priority task.
    /// </param>
    /// <param name="pDescription">
    /// A pointer to a String with the task description.
    /// </param>
    /// <returns>
    /// The task ID.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long WorkerThreadPoolAddNativeTask(void* pInstance, delegate* unmanaged[Cdecl]<void*, void> pFunc, void* pUserData, bool pHighPriority, GDExtensionString* pDescription)
    {
        delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void>, void*, bool, GDExtensionString*, long> function = s_workerThreadPoolAddNativeTask;
        ThrowIfInvalid(function);
        return function(pInstance, pFunc, pUserData, pHighPriority, pDescription);
    }

    /// <summary>
    /// Gets a pointer to a byte in a PackedByteArray.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to a PackedByteArray object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the byte to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested byte.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte* PackedByteArrayOperatorIndex(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, byte*> function = s_packedByteArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to a byte in a PackedByteArray.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to a PackedByteArray object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the byte to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested byte.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte* PackedByteArrayOperatorIndexConst(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, byte*> function = s_packedByteArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a pointer to a 32-bit float in a PackedFloat32Array.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to a PackedFloat32Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the float to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested 32-bit float.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float* PackedFloat32ArrayOperatorIndex(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, float*> function = s_packedFloat32ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to a 32-bit float in a PackedFloat32Array.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to a PackedFloat32Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the float to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested 32-bit float.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float* PackedFloat32ArrayOperatorIndexConst(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, float*> function = s_packedFloat32ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a pointer to a 64-bit float in a PackedFloat64Array.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to a PackedFloat64Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the float to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested 64-bit float.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double* PackedFloat64ArrayOperatorIndex(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, double*> function = s_packedFloat64ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to a 64-bit float in a PackedFloat64Array.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to a PackedFloat64Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the float to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested 64-bit float.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double* PackedFloat64ArrayOperatorIndexConst(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, double*> function = s_packedFloat64ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a pointer to a 32-bit integer in a PackedInt32Array.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to a PackedInt32Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the integer to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested 32-bit integer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int* PackedInt32ArrayOperatorIndex(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, int*> function = s_packedInt32ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to a 32-bit integer in a PackedInt32Array.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to a PackedInt32Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the integer to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested 32-bit integer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int* PackedInt32ArrayOperatorIndexConst(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, int*> function = s_packedInt32ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a pointer to a 64-bit integer in a PackedInt64Array.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to a PackedInt64Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the integer to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested 64-bit integer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long* PackedInt64ArrayOperatorIndex(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, long*> function = s_packedInt64ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to a 64-bit integer in a PackedInt64Array.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to a PackedInt64Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the integer to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested 64-bit integer.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long* PackedInt64ArrayOperatorIndexConst(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, long*> function = s_packedInt64ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a pointer to a string in a PackedStringArray.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to a PackedStringArray object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the String to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested String.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionString* PackedStringArrayOperatorIndex(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, GDExtensionString*> function = s_packedStringArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to a string in a PackedStringArray.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to a PackedStringArray object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the String to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested String.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionString* PackedStringArrayOperatorIndexConst(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, GDExtensionString*> function = s_packedStringArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a pointer to a Vector2 in a PackedVector2Array.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to a PackedVector2Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the Vector2 to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested Vector2.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* PackedVector2ArrayOperatorIndex(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, void*> function = s_packedVector2ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to a Vector2 in a PackedVector2Array.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to a PackedVector2Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the Vector2 to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested Vector2.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* PackedVector2ArrayOperatorIndexConst(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, void*> function = s_packedVector2ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a pointer to a Vector3 in a PackedVector3Array.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to a PackedVector3Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the Vector3 to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested Vector3.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* PackedVector3ArrayOperatorIndex(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, void*> function = s_packedVector3ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to a Vector3 in a PackedVector3Array.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to a PackedVector3Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the Vector3 to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested Vector3.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* PackedVector3ArrayOperatorIndexConst(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, void*> function = s_packedVector3ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a pointer to a Vector4 in a PackedVector4Array.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to a PackedVector4Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the Vector4 to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested Vector4.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* PackedVector4ArrayOperatorIndex(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, void*> function = s_packedVector4ArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to a Vector4 in a PackedVector4Array.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to a PackedVector4Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the Vector4 to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested Vector4.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* PackedVector4ArrayOperatorIndexConst(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, void*> function = s_packedVector4ArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a pointer to a color in a PackedColorArray.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to a PackedColorArray object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the Color to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested Color.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* PackedColorArrayOperatorIndex(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, void*> function = s_packedColorArrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to a color in a PackedColorArray.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to a PackedColorArray object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the Color to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested Color.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* PackedColorArrayOperatorIndexConst(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, void*> function = s_packedColorArrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a pointer to a Variant in an Array.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to an Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the Variant to get.
    /// </param>
    /// <returns>
    /// A pointer to the requested Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariant* ArrayOperatorIndex(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, GDExtensionVariant*> function = s_arrayOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Gets a const pointer to a Variant in an Array.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to an Array object.
    /// </param>
    /// <param name="pIndex">
    /// The index of the Variant to get.
    /// </param>
    /// <returns>
    /// A const pointer to the requested Variant.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariant* ArrayOperatorIndexConst(void* pSelf, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, long, GDExtensionVariant*> function = s_arrayOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pIndex);
    }

    /// <summary>
    /// Sets an Array to be a reference to another Array object.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Array object to update.
    /// </param>
    /// <param name="pFrom">
    /// A pointer to the Array object to reference.
    /// </param>
    [Obsolete("Deprecated since Godot 4.5. Removed from interface. Use copy constructor instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArrayRef(void* pSelf, void* pFrom)
    {
        delegate* unmanaged[Cdecl]<void*, void*, void> function = s_arrayRef;
        ThrowIfInvalid(function);
        function(pSelf, pFrom);
    }

    /// <summary>
    /// Makes an Array into a typed Array.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Array.
    /// </param>
    /// <param name="pType">
    /// The type of Variant the Array will store.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the name of the object (if pType is Object).
    /// </param>
    /// <param name="pScript">
    /// A pointer to a Script object (if pType is Object and the base class is extended by a script).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ArraySetTyped(void* pSelf, GDExtensionVariantType pType, GDExtensionStringName* pClassName, GDExtensionVariant* pScript)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, void> function = s_arraySetTyped;
        ThrowIfInvalid(function);
        function(pSelf, pType, pClassName, pScript);
    }

    /// <summary>
    /// Gets a pointer to a Variant in a Dictionary with the given key.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to a Dictionary object.
    /// </param>
    /// <param name="pKey">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <returns>
    /// A pointer to a Variant representing the value at the given key.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariant* DictionaryOperatorIndex(void* pSelf, GDExtensionVariant* pKey)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionVariant*, GDExtensionVariant*> function = s_dictionaryOperatorIndex;
        ThrowIfInvalid(function);
        return function(pSelf, pKey);
    }

    /// <summary>
    /// Gets a const pointer to a Variant in a Dictionary with the given key.
    /// </summary>
    /// <param name="pSelf">
    /// A const pointer to a Dictionary object.
    /// </param>
    /// <param name="pKey">
    /// A pointer to a Variant representing the key.
    /// </param>
    /// <returns>
    /// A const pointer to a Variant representing the value at the given key.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GDExtensionVariant* DictionaryOperatorIndexConst(void* pSelf, GDExtensionVariant* pKey)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionVariant*, GDExtensionVariant*> function = s_dictionaryOperatorIndexConst;
        ThrowIfInvalid(function);
        return function(pSelf, pKey);
    }

    /// <summary>
    /// Makes a Dictionary into a typed Dictionary.
    /// </summary>
    /// <param name="pSelf">
    /// A pointer to the Dictionary.
    /// </param>
    /// <param name="pKeyType">
    /// The type of Variant the Dictionary key will store.
    /// </param>
    /// <param name="pKeyClassName">
    /// A pointer to a StringName with the name of the object (if pKeyType is Object).
    /// </param>
    /// <param name="pKeyScript">
    /// A pointer to a Script object (if pKeyType is Object and the base class is extended by a script).
    /// </param>
    /// <param name="pValueType">
    /// The type of Variant the Dictionary value will store.
    /// </param>
    /// <param name="pValueClassName">
    /// A pointer to a StringName with the name of the object (if pValueType is Object).
    /// </param>
    /// <param name="pValueScript">
    /// A pointer to a Script object (if pValueType is Object and the base class is extended by a script).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DictionarySetTyped(void* pSelf, GDExtensionVariantType pKeyType, GDExtensionStringName* pKeyClassName, GDExtensionVariant* pKeyScript, GDExtensionVariantType pValueType, GDExtensionStringName* pValueClassName, GDExtensionVariant* pValueScript)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, GDExtensionVariantType, GDExtensionStringName*, GDExtensionVariant*, void> function = s_dictionarySetTyped;
        ThrowIfInvalid(function);
        function(pSelf, pKeyType, pKeyClassName, pKeyScript, pValueType, pValueClassName, pValueScript);
    }

    /// <summary>
    /// Calls a method on an Object.
    /// </summary>
    /// <param name="pMethodBind">
    /// A pointer to the MethodBind representing the method on the Object's class.
    /// </param>
    /// <param name="pInstance">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pArgs">
    /// A pointer to a C array of Variants representing the arguments.
    /// </param>
    /// <param name="pArgCount">
    /// The number of arguments.
    /// </param>
    /// <param name="rRet">
    /// A pointer to Variant which will receive the return value.
    /// </param>
    /// <param name="rError">
    /// A pointer to a GDExtensionCallError struct that will receive error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ObjectMethodBindCall(void* pMethodBind, void* pInstance, GDExtensionVariant** pArgs, long pArgCount, GDExtensionVariant* rRet, GDExtensionCallError* rError)
    {
        delegate* unmanaged[Cdecl]<void*, void*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> function = s_objectMethodBindCall;
        ThrowIfInvalid(function);
        function(pMethodBind, pInstance, pArgs, pArgCount, rRet, rError);
    }

    /// <summary>
    /// Calls a method on an Object (using a "ptrcall").
    /// </summary>
    /// <param name="pMethodBind">
    /// A pointer to the MethodBind representing the method on the Object's class.
    /// </param>
    /// <param name="pInstance">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pArgs">
    /// A pointer to a C array representing the arguments.
    /// </param>
    /// <param name="rRet">
    /// A pointer to the Object that will receive the return value.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ObjectMethodBindPtrCall(void* pMethodBind, void* pInstance, void** pArgs, void* rRet)
    {
        delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void> function = s_objectMethodBindPtrCall;
        ThrowIfInvalid(function);
        function(pMethodBind, pInstance, pArgs, rRet);
    }

    /// <summary>
    /// Destroys an Object.
    /// </summary>
    /// <param name="pO">
    /// A pointer to the Object.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ObjectDestroy(void* pO)
    {
        delegate* unmanaged[Cdecl]<void*, void> function = s_objectDestroy;
        ThrowIfInvalid(function);
        function(pO);
    }

    /// <summary>
    /// Gets a global singleton by name.
    /// </summary>
    /// <param name="pName">
    /// A pointer to a StringName with the singleton name.
    /// </param>
    /// <returns>
    /// A pointer to the singleton Object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* GlobalGetSingleton(GDExtensionStringName* pName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*> function = s_globalGetSingleton;
        ThrowIfInvalid(function);
        return function(pName);
    }

    /// <summary>
    /// Gets a pointer representing an Object's instance binding.
    /// </summary>
    /// <param name="pO">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pToken">
    /// A token the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pCallbacks">
    /// A pointer to a GDExtensionInstanceBindingCallbacks struct.
    /// </param>
    /// <returns>
    /// A pointer to the instance binding.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* ObjectGetInstanceBinding(void* pO, void* pToken, GDExtensionInstanceBindingCallbacks* pCallbacks)
    {
        delegate* unmanaged[Cdecl]<void*, void*, GDExtensionInstanceBindingCallbacks*, void*> function = s_objectGetInstanceBinding;
        ThrowIfInvalid(function);
        return function(pO, pToken, pCallbacks);
    }

    /// <summary>
    /// Sets an Object's instance binding.
    /// </summary>
    /// <param name="pO">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pToken">
    /// A token the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pBinding">
    /// A pointer to the instance binding.
    /// </param>
    /// <param name="pCallbacks">
    /// A pointer to a GDExtensionInstanceBindingCallbacks struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ObjectSetInstanceBinding(void* pO, void* pToken, void* pBinding, GDExtensionInstanceBindingCallbacks* pCallbacks)
    {
        delegate* unmanaged[Cdecl]<void*, void*, void*, GDExtensionInstanceBindingCallbacks*, void> function = s_objectSetInstanceBinding;
        ThrowIfInvalid(function);
        function(pO, pToken, pBinding, pCallbacks);
    }

    /// <summary>
    /// Free an Object's instance binding.
    /// </summary>
    /// <param name="pO">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pToken">
    /// A token the library received by the GDExtension's entry point function.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ObjectFreeInstanceBinding(void* pO, void* pToken)
    {
        delegate* unmanaged[Cdecl]<void*, void*, void> function = s_objectFreeInstanceBinding;
        ThrowIfInvalid(function);
        function(pO, pToken);
    }

    /// <summary>
    /// Sets an extension class instance on a Object.<br/>
    /// `pClassName` should be a registered extension class and should extend the `pO` Object's class.
    /// </summary>
    /// <param name="pO">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the registered extension class's name.
    /// </param>
    /// <param name="pInstance">
    /// A pointer to the extension class instance.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ObjectSetInstance(void* pO, GDExtensionStringName* pClassName, void* pInstance)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, void*, void> function = s_objectSetInstance;
        ThrowIfInvalid(function);
        function(pO, pClassName, pInstance);
    }

    /// <summary>
    /// Gets the class name of an Object.<br/>
    /// If the GDExtension wraps the Godot object in an abstraction specific to its class, this is the<br/>
    /// function that should be used to determine which wrapper to use.
    /// </summary>
    /// <param name="pObject">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="rClassName">
    /// A pointer to a String to receive the class name.
    /// </param>
    /// <returns>
    /// true if successful in getting the class name; otherwise false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ObjectGetClassName(void* pObject, void* pLibrary, GDExtensionStringName* rClassName)
    {
        delegate* unmanaged[Cdecl]<void*, void*, GDExtensionStringName*, bool> function = s_objectGetClassName;
        ThrowIfInvalid(function);
        return function(pObject, pLibrary, rClassName);
    }

    /// <summary>
    /// Casts an Object to a different type.
    /// </summary>
    /// <param name="pObject">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pClassTag">
    /// A pointer uniquely identifying a built-in class in the ClassDB.
    /// </param>
    /// <returns>
    /// Returns a pointer to the Object, or null if it can't be cast to the requested type.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.7. Use the `is_class` method on `Object` to check if an object can be cast instead. If true, the previous pointer can be reinterpreted as a pointer to the target type.")]
    public static void* ObjectCastTo(void* pObject, void* pClassTag)
    {
        delegate* unmanaged[Cdecl]<void*, void*, void*> function = s_objectCastTo;
        ThrowIfInvalid(function);
        return function(pObject, pClassTag);
    }

    /// <summary>
    /// Gets an Object by its instance ID.
    /// </summary>
    /// <param name="pInstanceId">
    /// The instance ID.
    /// </param>
    /// <returns>
    /// A pointer to the Object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* ObjectGetInstanceFromId(ulong pInstanceId)
    {
        delegate* unmanaged[Cdecl]<ulong, void*> function = s_objectGetInstanceFromId;
        ThrowIfInvalid(function);
        return function(pInstanceId);
    }

    /// <summary>
    /// Gets the instance ID from an Object.
    /// </summary>
    /// <param name="pObject">
    /// A pointer to the Object.
    /// </param>
    /// <returns>
    /// The instance ID.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong ObjectGetInstanceId(void* pObject)
    {
        delegate* unmanaged[Cdecl]<void*, ulong> function = s_objectGetInstanceId;
        ThrowIfInvalid(function);
        return function(pObject);
    }

    /// <summary>
    /// Checks if this object has a script with the given method.
    /// </summary>
    /// <param name="pObject">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pMethod">
    /// A pointer to a StringName identifying the method.
    /// </param>
    /// <returns>
    /// true if the object has a script and that script has a method with the given name. Returns false if the object has no script.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ObjectHasScriptMethod(void* pObject, GDExtensionStringName* pMethod)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, bool> function = s_objectHasScriptMethod;
        ThrowIfInvalid(function);
        return function(pObject, pMethod);
    }

    /// <summary>
    /// Call the given script method on this object.
    /// </summary>
    /// <param name="pObject">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pMethod">
    /// A pointer to a StringName identifying the method.
    /// </param>
    /// <param name="pArgs">
    /// A pointer to a C array of Variant.
    /// </param>
    /// <param name="pArgumentCount">
    /// The number of arguments.
    /// </param>
    /// <param name="rReturn">
    /// A pointer a Variant which will be assigned the return value.
    /// </param>
    /// <param name="rError">
    /// A pointer the structure which will hold error information.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ObjectCallScriptMethod(void* pObject, GDExtensionStringName* pMethod, GDExtensionVariant** pArgs, long pArgumentCount, GDExtensionVariant* rReturn, GDExtensionCallError* rError)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> function = s_objectCallScriptMethod;
        ThrowIfInvalid(function);
        function(pObject, pMethod, pArgs, pArgumentCount, rReturn, rError);
    }

    /// <summary>
    /// Gets the Object from a reference.
    /// </summary>
    /// <param name="pRef">
    /// A pointer to the reference.
    /// </param>
    /// <returns>
    /// A pointer to the Object from the reference or null.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* RefGetObject(void* pRef)
    {
        delegate* unmanaged[Cdecl]<void*, void*> function = s_refGetObject;
        ThrowIfInvalid(function);
        return function(pRef);
    }

    /// <summary>
    /// Sets the Object referred to by a reference.
    /// </summary>
    /// <param name="pRef">
    /// A pointer to the reference.
    /// </param>
    /// <param name="pObject">
    /// A pointer to the Object to refer to.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RefSetObject(void* pRef, void* pObject)
    {
        delegate* unmanaged[Cdecl]<void*, void*, void> function = s_refSetObject;
        ThrowIfInvalid(function);
        function(pRef, pObject);
    }

    /// <summary>
    /// Creates a script instance that contains the given info and instance data.
    /// </summary>
    /// <param name="pInfo">
    /// A pointer to a GDExtensionScriptInstanceInfo struct.
    /// </param>
    /// <param name="pInstanceData">
    /// A pointer to a data representing the script instance in the GDExtension. This will be passed to all the function pointers on pInfo.
    /// </param>
    /// <returns>
    /// A pointer to a ScriptInstanceExtension object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.2. Use `ScriptInstanceCreate3` instead.")]
    public static void* ScriptInstanceCreate(GDExtensionScriptInstanceInfo* pInfo, void* pInstanceData)
    {
        delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo*, void*, void*> function = s_scriptInstanceCreate;
        ThrowIfInvalid(function);
        return function(pInfo, pInstanceData);
    }

    /// <summary>
    /// Creates a script instance that contains the given info and instance data.
    /// </summary>
    /// <param name="pInfo">
    /// A pointer to a GDExtensionScriptInstanceInfo2 struct.
    /// </param>
    /// <param name="pInstanceData">
    /// A pointer to a data representing the script instance in the GDExtension. This will be passed to all the function pointers on pInfo.
    /// </param>
    /// <returns>
    /// A pointer to a ScriptInstanceExtension object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.3. Use `ScriptInstanceCreate3` instead.")]
    public static void* ScriptInstanceCreate2(GDExtensionScriptInstanceInfo2* pInfo, void* pInstanceData)
    {
        delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo2*, void*, void*> function = s_scriptInstanceCreate2;
        ThrowIfInvalid(function);
        return function(pInfo, pInstanceData);
    }

    /// <summary>
    /// Creates a script instance that contains the given info and instance data.
    /// </summary>
    /// <param name="pInfo">
    /// A pointer to a GDExtensionScriptInstanceInfo3 struct.
    /// </param>
    /// <param name="pInstanceData">
    /// A pointer to a data representing the script instance in the GDExtension. This will be passed to all the function pointers on pInfo.
    /// </param>
    /// <returns>
    /// A pointer to a ScriptInstanceExtension object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* ScriptInstanceCreate3(GDExtensionScriptInstanceInfo3* pInfo, void* pInstanceData)
    {
        delegate* unmanaged[Cdecl]<GDExtensionScriptInstanceInfo3*, void*, void*> function = s_scriptInstanceCreate3;
        ThrowIfInvalid(function);
        return function(pInfo, pInstanceData);
    }

    /// <summary>
    /// Creates a placeholder script instance for a given script and instance.<br/>
    /// This interface is optional as a custom placeholder could also be created with ScriptInstanceCreate().
    /// </summary>
    /// <param name="pLanguage">
    /// A pointer to a ScriptLanguage.
    /// </param>
    /// <param name="pScript">
    /// A pointer to a Script.
    /// </param>
    /// <param name="pOwner">
    /// A pointer to an Object.
    /// </param>
    /// <returns>
    /// A pointer to a PlaceHolderScriptInstance object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* PlaceholderScriptInstanceCreate(void* pLanguage, void* pScript, void* pOwner)
    {
        delegate* unmanaged[Cdecl]<void*, void*, void*, void*> function = s_placeholderScriptInstanceCreate;
        ThrowIfInvalid(function);
        return function(pLanguage, pScript, pOwner);
    }

    /// <summary>
    /// Updates a placeholder script instance with the given properties and values.<br/>
    /// The passed in placeholder must be an instance of PlaceHolderScriptInstance<br/>
    /// such as the one returned by PlaceholderScriptInstanceCreate().
    /// </summary>
    /// <param name="pPlaceholder">
    /// A pointer to a PlaceHolderScriptInstance.
    /// </param>
    /// <param name="pProperties">
    /// A pointer to an Array of Dictionary representing PropertyInfo.
    /// </param>
    /// <param name="pValues">
    /// A pointer to a Dictionary mapping StringName to Variant values.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void PlaceholderScriptInstanceUpdate(void* pPlaceholder, void* pProperties, void* pValues)
    {
        delegate* unmanaged[Cdecl]<void*, void*, void*, void> function = s_placeholderScriptInstanceUpdate;
        ThrowIfInvalid(function);
        function(pPlaceholder, pProperties, pValues);
    }

    /// <summary>
    /// Get the script instance data attached to this object.
    /// </summary>
    /// <param name="pObject">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pLanguage">
    /// A pointer to the language expected for this script instance.
    /// </param>
    /// <returns>
    /// A GDExtensionScriptInstanceDataPtr that was attached to this object as part of ScriptInstanceCreate.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* ObjectGetScriptInstance(void* pObject, void* pLanguage)
    {
        delegate* unmanaged[Cdecl]<void*, void*, void*> function = s_objectGetScriptInstance;
        ThrowIfInvalid(function);
        return function(pObject, pLanguage);
    }

    /// <summary>
    /// Set the script instance data attached to this object.
    /// </summary>
    /// <param name="pObject">
    /// A pointer to the Object.
    /// </param>
    /// <param name="pScriptInstance">
    /// A pointer to the script instance data to attach to this object.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ObjectSetScriptInstance(void* pObject, void* pScriptInstance)
    {
        delegate* unmanaged[Cdecl]<void*, void*, void> function = s_objectSetScriptInstance;
        ThrowIfInvalid(function);
        function(pObject, pScriptInstance);
    }

    /// <summary>
    /// Creates a custom Callable object from a function pointer.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="rCallable">
    /// A pointer that will receive the new Callable.
    /// </param>
    /// <param name="pCallableCustomInfo">
    /// The info required to construct a Callable.
    /// </param>
    [Obsolete("Deprecated since Godot 4.3. Use `CallableCustomCreate2` instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void CallableCustomCreate(void* rCallable, GDExtensionCallableCustomInfo* pCallableCustomInfo)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionCallableCustomInfo*, void> function = s_callableCustomCreate;
        ThrowIfInvalid(function);
        function(rCallable, pCallableCustomInfo);
    }

    /// <summary>
    /// Creates a custom Callable object from a function pointer.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="rCallable">
    /// A pointer that will receive the new Callable.
    /// </param>
    /// <param name="pCallableCustomInfo">
    /// The info required to construct a Callable.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void CallableCustomCreate2(void* rCallable, GDExtensionCallableCustomInfo2* pCallableCustomInfo)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionCallableCustomInfo2*, void> function = s_callableCustomCreate2;
        ThrowIfInvalid(function);
        function(rCallable, pCallableCustomInfo);
    }

    /// <summary>
    /// Retrieves the userdata pointer from a custom Callable.<br/>
    /// If the Callable is not a custom Callable or the token does not match the one provided to CallableCustomCreate() via GDExtensionCallableCustomInfo then null will be returned.
    /// </summary>
    /// <param name="pCallable">
    /// A pointer to a Callable.
    /// </param>
    /// <param name="pToken">
    /// A pointer to an address that uniquely identifies the GDExtension.
    /// </param>
    /// <returns>
    /// The userdata pointer given when creating this custom Callable.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* CallableCustomGetUserData(void* pCallable, void* pToken)
    {
        delegate* unmanaged[Cdecl]<void*, void*, void*> function = s_callableCustomGetUserData;
        ThrowIfInvalid(function);
        return function(pCallable, pToken);
    }

    /// <summary>
    /// Constructs an Object of the requested class.<br/>
    /// The passed class must be a built-in godot class, or an already-registered extension class. In both cases, ObjectSetInstance() should be called to fully initialize the object.
    /// </summary>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer to the newly created Object.
    /// </returns>
    [Obsolete("Deprecated since Godot 4.4. Use `ClassDBConstructObject3` instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* ClassDBConstructObject(GDExtensionStringName* pClassName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*> function = s_classDBConstructObject;
        ThrowIfInvalid(function);
        return function(pClassName);
    }

    /// <summary>
    /// Constructs an Object of the requested class.<br/>
    /// The passed class must be a built-in godot class, or an already-registered extension class. In both cases, ObjectSetInstance() should be called to fully initialize the object.<br/>
    /// <br/>
    /// "NOTIFICATION_POSTINITIALIZE" must be sent after construction.
    /// </summary>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer to the newly created Object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.7. Use `ClassDBConstructObject3` instead.")]
    public static void* ClassDBConstructObject2(GDExtensionStringName* pClassName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*> function = s_classDBConstructObject2;
        ThrowIfInvalid(function);
        return function(pClassName);
    }

    /// <summary>
    /// Constructs an Object of the requested class.<br/>
    /// The passed class must be a built-in godot class, or an already-registered extension class. In both cases, ObjectSetInstance() should be called to fully initialize the object.<br/>
    /// If the type is a subtype of RefCounted, it already has a refcount of 1. The caller must take ownership the refcount and is responsible for decrementing it again when the object is no longer needed.<br/>
    /// <br/>
    /// "NOTIFICATION_POSTINITIALIZE" must be sent after construction.
    /// </summary>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer to the newly created Object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* ClassDBConstructObject3(GDExtensionStringName* pClassName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*> function = s_classDBConstructObject3;
        ThrowIfInvalid(function);
        return function(pClassName);
    }

    /// <summary>
    /// Gets a pointer to the MethodBind in ClassDB for the given class, method and hash.
    /// </summary>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pMethodName">
    /// A pointer to a StringName with the method name.
    /// </param>
    /// <param name="pHash">
    /// A hash representing the function signature.
    /// </param>
    /// <returns>
    /// A pointer to the MethodBind from ClassDB.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* ClassDBGetMethodBind(GDExtensionStringName* pClassName, GDExtensionStringName* pMethodName, long pHash)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, GDExtensionStringName*, long, void*> function = s_classDBGetMethodBind;
        ThrowIfInvalid(function);
        return function(pClassName, pMethodName, pHash);
    }

    /// <summary>
    /// Gets a pointer uniquely identifying the given built-in class in the ClassDB.
    /// </summary>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <returns>
    /// A pointer uniquely identifying the built-in class in the ClassDB.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.7. No longer needed. Use the `is_class` method on `Object` instead.")]
    public static void* ClassDBGetClassTag(GDExtensionStringName* pClassName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, void*> function = s_classDBGetClassTag;
        ThrowIfInvalid(function);
        return function(pClassName);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pParentClassName">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="pExtensionFuncs">
    /// A pointer to a GDExtensionClassCreationInfo struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.2. Use `ClassDBRegisterExtensionClass6` instead.")]
    public static void ClassDBRegisterExtensionClass(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionStringName* pParentClassName, GDExtensionClassCreationInfo* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo*, void> function = s_classDBRegisterExtensionClass;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pParentClassName">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="pExtensionFuncs">
    /// A pointer to a GDExtensionClassCreationInfo2 struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.3. Use `ClassDBRegisterExtensionClass6` instead.")]
    public static void ClassDBRegisterExtensionClass2(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionStringName* pParentClassName, GDExtensionClassCreationInfo2* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo2*, void> function = s_classDBRegisterExtensionClass2;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pParentClassName">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="pExtensionFuncs">
    /// A pointer to a GDExtensionClassCreationInfo3 struct.
    /// </param>
    [Obsolete("Deprecated since Godot 4.4. Use `ClassDBRegisterExtensionClass6` instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClass3(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionStringName* pParentClassName, GDExtensionClassCreationInfo3* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo3*, void> function = s_classDBRegisterExtensionClass3;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pParentClassName">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="pExtensionFuncs">
    /// A pointer to a GDExtensionClassCreationInfo4 struct.
    /// </param>
    [Obsolete("Deprecated since Godot 4.5. Use `ClassDBRegisterExtensionClass6` instead.")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClass4(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionStringName* pParentClassName, GDExtensionClassCreationInfo4* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo4*, void> function = s_classDBRegisterExtensionClass4;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pParentClassName">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="pExtensionFuncs">
    /// A pointer to a GDExtensionClassCreationInfo5 struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Deprecated since Godot 4.7. Use `ClassDBRegisterExtensionClass6` instead.")]
    public static void ClassDBRegisterExtensionClass5(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionStringName* pParentClassName, GDExtensionClassCreationInfo4* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo4*, void> function = s_classDBRegisterExtensionClass5;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers an extension class in the ClassDB.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pParentClassName">
    /// A pointer to a StringName with the parent class name.
    /// </param>
    /// <param name="pExtensionFuncs">
    /// A pointer to a GDExtensionClassCreationInfo6 struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClass6(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionStringName* pParentClassName, GDExtensionClassCreationInfo6* pExtensionFuncs)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionClassCreationInfo6*, void> function = s_classDBRegisterExtensionClass6;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pParentClassName, pExtensionFuncs);
    }

    /// <summary>
    /// Registers a method on an extension class in the ClassDB.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pMethodInfo">
    /// A pointer to a GDExtensionClassMethodInfo struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClassMethod(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionClassMethodInfo* pMethodInfo)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionClassMethodInfo*, void> function = s_classDBRegisterExtensionClassMethod;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pMethodInfo);
    }

    /// <summary>
    /// Registers a virtual method on an extension class in ClassDB, that can be implemented by scripts or other extensions.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pMethodInfo">
    /// A pointer to a GDExtensionClassMethodInfo struct.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClassVirtualMethod(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionClassVirtualMethodInfo* pMethodInfo)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionClassVirtualMethodInfo*, void> function = s_classDBRegisterExtensionClassVirtualMethod;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pMethodInfo);
    }

    /// <summary>
    /// Registers an integer constant on an extension class in the ClassDB.<br/>
    /// Note about registering bitfield values (if pIsBitfield is true): even though pConstantValue is signed, language bindings are<br/>
    /// advised to treat bitfields as uint64_t, since this is generally clearer and can prevent mistakes like using -1 for setting all bits.<br/>
    /// Language APIs should thus provide an abstraction that registers bitfields (uint64_t) separately from regular constants (int64_t).
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pEnumName">
    /// A pointer to a StringName with the enum name.
    /// </param>
    /// <param name="pConstantName">
    /// A pointer to a StringName with the constant name.
    /// </param>
    /// <param name="pConstantValue">
    /// The constant value.
    /// </param>
    /// <param name="pIsBitfield">
    /// Whether or not this constant is part of a bitfield.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClassIntegerConstant(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionStringName* pEnumName, GDExtensionStringName* pConstantName, long pConstantValue, bool pIsBitfield)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionStringName*, long, bool, void> function = s_classDBRegisterExtensionClassIntegerConstant;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pEnumName, pConstantName, pConstantValue, pIsBitfield);
    }

    /// <summary>
    /// Registers a property on an extension class in the ClassDB.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pInfo">
    /// A pointer to a GDExtensionPropertyInfo struct.
    /// </param>
    /// <param name="pSetter">
    /// A pointer to a StringName with the name of the setter method.
    /// </param>
    /// <param name="pGetter">
    /// A pointer to a StringName with the name of the getter method.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClassProperty(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionPropertyInfo* pInfo, GDExtensionStringName* pSetter, GDExtensionStringName* pGetter)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionPropertyInfo*, GDExtensionStringName*, GDExtensionStringName*, void> function = s_classDBRegisterExtensionClassProperty;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pInfo, pSetter, pGetter);
    }

    /// <summary>
    /// Registers an indexed property on an extension class in the ClassDB.<br/>
    /// Provided struct can be safely freed once the function returns.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pInfo">
    /// A pointer to a GDExtensionPropertyInfo struct.
    /// </param>
    /// <param name="pSetter">
    /// A pointer to a StringName with the name of the setter method.
    /// </param>
    /// <param name="pGetter">
    /// A pointer to a StringName with the name of the getter method.
    /// </param>
    /// <param name="pIndex">
    /// The index to pass as the first argument to the getter and setter methods.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClassPropertyIndexed(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionPropertyInfo* pInfo, GDExtensionStringName* pSetter, GDExtensionStringName* pGetter, long pIndex)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionPropertyInfo*, GDExtensionStringName*, GDExtensionStringName*, long, void> function = s_classDBRegisterExtensionClassPropertyIndexed;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pInfo, pSetter, pGetter, pIndex);
    }

    /// <summary>
    /// Registers a property group on an extension class in the ClassDB.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pGroupName">
    /// A pointer to a String with the group name.
    /// </param>
    /// <param name="pPrefix">
    /// A pointer to a String with the prefix used by properties in this group.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClassPropertyGroup(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionString* pGroupName, GDExtensionString* pPrefix)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionString*, GDExtensionString*, void> function = s_classDBRegisterExtensionClassPropertyGroup;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pGroupName, pPrefix);
    }

    /// <summary>
    /// Registers a property subgroup on an extension class in the ClassDB.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pSubgroupName">
    /// A pointer to a String with the subgroup name.
    /// </param>
    /// <param name="pPrefix">
    /// A pointer to a String with the prefix used by properties in this subgroup.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClassPropertySubgroup(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionString* pSubgroupName, GDExtensionString* pPrefix)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionString*, GDExtensionString*, void> function = s_classDBRegisterExtensionClassPropertySubgroup;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pSubgroupName, pPrefix);
    }

    /// <summary>
    /// Registers a signal on an extension class in the ClassDB.<br/>
    /// Provided structs can be safely freed once the function returns.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    /// <param name="pSignalName">
    /// A pointer to a StringName with the signal name.
    /// </param>
    /// <param name="pArgumentInfo">
    /// A pointer to a GDExtensionPropertyInfo struct.
    /// </param>
    /// <param name="pArgumentCount">
    /// The number of arguments the signal receives.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBRegisterExtensionClassSignal(void* pLibrary, GDExtensionStringName* pClassName, GDExtensionStringName* pSignalName, GDExtensionPropertyInfo* pArgumentInfo, long pArgumentCount)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, GDExtensionStringName*, GDExtensionPropertyInfo*, long, void> function = s_classDBRegisterExtensionClassSignal;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName, pSignalName, pArgumentInfo, pArgumentCount);
    }

    /// <summary>
    /// Unregisters an extension class in the ClassDB.<br/>
    /// Unregistering a parent class before a class that inherits it will result in failure. Inheritors must be unregistered first.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pClassName">
    /// A pointer to a StringName with the class name.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ClassDBUnregisterExtensionClass(void* pLibrary, GDExtensionStringName* pClassName)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, void> function = s_classDBUnregisterExtensionClass;
        ThrowIfInvalid(function);
        function(pLibrary, pClassName);
    }

    /// <summary>
    /// Gets the path to the current GDExtension library.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="rPath">
    /// A pointer to a String which will receive the path.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void GetLibraryPath(void* pLibrary, GDExtensionString* rPath)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionString*, void> function = s_getLibraryPath;
        ThrowIfInvalid(function);
        function(pLibrary, rPath);
    }

    /// <summary>
    /// Adds an editor plugin.<br/>
    /// It's safe to call during initialization.
    /// </summary>
    /// <param name="pClassName">
    /// A pointer to a StringName with the name of a class (descending from EditorPlugin) which is already registered with ClassDB.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void EditorAddPlugin(GDExtensionStringName* pClassName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, void> function = s_editorAddPlugin;
        ThrowIfInvalid(function);
        function(pClassName);
    }

    /// <summary>
    /// Removes an editor plugin.
    /// </summary>
    /// <param name="pClassName">
    /// A pointer to a StringName with the name of a class that was previously added as an editor plugin.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void EditorRemovePlugin(GDExtensionStringName* pClassName)
    {
        delegate* unmanaged[Cdecl]<GDExtensionStringName*, void> function = s_editorRemovePlugin;
        ThrowIfInvalid(function);
        function(pClassName);
    }

    /// <summary>
    /// Loads new XML-formatted documentation data in the editor.<br/>
    /// The provided pointer can be immediately freed once the function returns.
    /// </summary>
    /// <param name="pData">
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
    /// <param name="pData">
    /// A pointer to a UTF-8 encoded C string.
    /// </param>
    /// <param name="pSize">
    /// The number of bytes (not code units).
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void EditorHelpLoadXmlFromUtf8CharsAndLen(byte* pData, long pSize)
    {
        delegate* unmanaged[Cdecl]<byte*, long, void> function = s_editorHelpLoadXmlFromUtf8CharsAndLen;
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
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pCallback">
    /// The callback to retrieve the list of classes used.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void EditorRegisterGetClassesUsedCallback(void* pLibrary, delegate* unmanaged[Cdecl]<void*, void> pCallback)
    {
        delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void>, void> function = s_editorRegisterGetClassesUsedCallback;
        ThrowIfInvalid(function);
        function(pLibrary, pCallback);
    }

    /// <summary>
    /// Registers callbacks to be called at different phases of the main loop.
    /// </summary>
    /// <param name="pLibrary">
    /// A pointer the library received by the GDExtension's entry point function.
    /// </param>
    /// <param name="pCallbacks">
    /// A pointer to the structure that contains the callbacks.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RegisterMainLoopCallbacks(void* pLibrary, GDExtensionMainLoopCallbacks* pCallbacks)
    {
        delegate* unmanaged[Cdecl]<void*, GDExtensionMainLoopCallbacks*, void> function = s_registerMainLoopCallbacks;
        ThrowIfInvalid(function);
        function(pLibrary, pCallbacks);
    }

    private static void* Load(delegate* unmanaged[Cdecl]<byte*, void*> pGetProcAddress, ReadOnlySpan<byte> pFunctionName)
    {
        fixed (byte* functionName = pFunctionName)
        {
            return pGetProcAddress(functionName);
        }
    }

    private static void ThrowIfInvalid(void* pFunction)
    {
        if (pFunction == null)
        {
            ThrowForInvalidFunction();
        }
    }

    private static void ThrowForInvalidFunction()
    {
        throw new InvalidOperationException("Unable to call the specified function.");
    }
}
