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

global using unsafe GDExtensionVariantPtr = void*;
global using unsafe GDExtensionConstVariantPtr = void*;
global using unsafe GDExtensionUninitializedVariantPtr = void*;
global using unsafe GDExtensionStringNamePtr = void*;
global using unsafe GDExtensionConstStringNamePtr = void*;
global using unsafe GDExtensionUninitializedStringNamePtr = void*;
global using unsafe GDExtensionStringPtr = void*;
global using unsafe GDExtensionConstStringPtr = void*;
global using unsafe GDExtensionUninitializedStringPtr = void*;
global using unsafe GDExtensionObjectPtr = void*;
global using unsafe GDExtensionConstObjectPtr = void*;
global using unsafe GDExtensionUninitializedObjectPtr = void*;
global using unsafe GDExtensionTypePtr = void*;
global using unsafe GDExtensionConstTypePtr = void*;
global using unsafe GDExtensionUninitializedTypePtr = void*;
global using unsafe GDExtensionMethodBindPtr = void*;
global using GDExtensionInt = long;
global using GDExtensionBool = byte;
global using GDObjectInstanceID = ulong;
global using unsafe GDExtensionRefPtr = void*;
global using unsafe GDExtensionConstRefPtr = void*;
global using unsafe GDExtensionVariantFromTypeConstructorFunc = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionTypeFromVariantConstructorFunc = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionVariantGetInternalPtrFunc = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionPtrOperatorEvaluator = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionPtrBuiltInMethod = delegate* unmanaged[Cdecl]<void*, void**, void*, int, void>;
global using unsafe GDExtensionPtrConstructor = delegate* unmanaged[Cdecl]<void*, void**, void>;
global using unsafe GDExtensionPtrDestructor = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionPtrSetter = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionPtrGetter = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionPtrIndexedSetter = delegate* unmanaged[Cdecl]<void*, long, void*, void>;
global using unsafe GDExtensionPtrIndexedGetter = delegate* unmanaged[Cdecl]<void*, long, void*, void>;
global using unsafe GDExtensionPtrKeyedSetter = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionPtrKeyedGetter = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionPtrKeyedChecker = delegate* unmanaged[Cdecl]<void*, void*, uint>;
global using unsafe GDExtensionPtrUtilityFunction = delegate* unmanaged[Cdecl]<void*, void**, int, void>;
global using unsafe GDExtensionClassConstructor = delegate* unmanaged[Cdecl]<void*>;
global using unsafe GDExtensionInstanceBindingCreateCallback = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionInstanceBindingFreeCallback = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionInstanceBindingReferenceCallback = delegate* unmanaged[Cdecl]<void*, void*, byte, byte>;
global using unsafe GDExtensionClassInstancePtr = void*;
global using unsafe GDExtensionClassSet = delegate* unmanaged[Cdecl]<void*, void*, void*, byte>;
global using unsafe GDExtensionClassGet = delegate* unmanaged[Cdecl]<void*, void*, void*, byte>;
global using unsafe GDExtensionClassGetRID = delegate* unmanaged[Cdecl]<void*, ulong>;
global using unsafe GDExtensionClassGetPropertyList = delegate* unmanaged[Cdecl]<void*, uint*, Godot.GDExtensionPropertyInfo*>;
global using unsafe GDExtensionClassFreePropertyList = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionPropertyInfo*, void>;
global using unsafe GDExtensionClassFreePropertyList2 = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionPropertyInfo*, uint, void>;
global using unsafe GDExtensionClassPropertyCanRevert = delegate* unmanaged[Cdecl]<void*, void*, byte>;
global using unsafe GDExtensionClassPropertyGetRevert = delegate* unmanaged[Cdecl]<void*, void*, void*, byte>;
global using unsafe GDExtensionClassValidateProperty = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionPropertyInfo*, byte>;
global using unsafe GDExtensionClassNotification = delegate* unmanaged[Cdecl]<void*, int, void>;
global using unsafe GDExtensionClassNotification2 = delegate* unmanaged[Cdecl]<void*, int, byte, void>;
global using unsafe GDExtensionClassToString = delegate* unmanaged[Cdecl]<void*, byte*, void*, void>;
global using unsafe GDExtensionClassReference = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionClassUnreference = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionClassCallVirtual = delegate* unmanaged[Cdecl]<void*, void**, void*, void>;
global using unsafe GDExtensionClassCreateInstance = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionClassCreateInstance2 = delegate* unmanaged[Cdecl]<void*, byte, void*>;
global using unsafe GDExtensionClassFreeInstance = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionClassRecreateInstance = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionClassGetVirtual = delegate* unmanaged[Cdecl]<void*, void*, delegate* unmanaged[Cdecl]<void*, void**, void*, void>>;
global using unsafe GDExtensionClassGetVirtual2 = delegate* unmanaged[Cdecl]<void*, void*, uint, delegate* unmanaged[Cdecl]<void*, void**, void*, void>>;
global using unsafe GDExtensionClassGetVirtualCallData = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionClassGetVirtualCallData2 = delegate* unmanaged[Cdecl]<void*, void*, uint, void*>;
global using unsafe GDExtensionClassCallVirtualWithData = delegate* unmanaged[Cdecl]<void*, void*, void*, void**, void*, void>;
global using GDExtensionClassCreationInfo5 = Godot.GDExtensionClassCreationInfo4;
global using unsafe GDExtensionClassLibraryPtr = void*;
global using unsafe GDExtensionEditorGetClassesUsedCallback = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionClassMethodCall = delegate* unmanaged[Cdecl]<void*, void*, void**, long, void*, Godot.GDExtensionCallError*, void>;
global using unsafe GDExtensionClassMethodValidatedCall = delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void>;
global using unsafe GDExtensionClassMethodPtrCall = delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void>;
global using unsafe GDExtensionCallableCustomCall = delegate* unmanaged[Cdecl]<void*, void**, long, void*, Godot.GDExtensionCallError*, void>;
global using unsafe GDExtensionCallableCustomIsValid = delegate* unmanaged[Cdecl]<void*, byte>;
global using unsafe GDExtensionCallableCustomFree = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionCallableCustomHash = delegate* unmanaged[Cdecl]<void*, uint>;
global using unsafe GDExtensionCallableCustomEqual = delegate* unmanaged[Cdecl]<void*, void*, byte>;
global using unsafe GDExtensionCallableCustomLessThan = delegate* unmanaged[Cdecl]<void*, void*, byte>;
global using unsafe GDExtensionCallableCustomToString = delegate* unmanaged[Cdecl]<void*, byte*, void*, void>;
global using unsafe GDExtensionCallableCustomGetArgumentCount = delegate* unmanaged[Cdecl]<void*, byte*, long>;
global using unsafe GDExtensionScriptInstanceDataPtr = void*;
global using unsafe GDExtensionScriptInstanceSet = delegate* unmanaged[Cdecl]<void*, void*, void*, byte>;
global using unsafe GDExtensionScriptInstanceGet = delegate* unmanaged[Cdecl]<void*, void*, void*, byte>;
global using unsafe GDExtensionScriptInstanceGetPropertyList = delegate* unmanaged[Cdecl]<void*, uint*, Godot.GDExtensionPropertyInfo*>;
global using unsafe GDExtensionScriptInstanceFreePropertyList = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionPropertyInfo*, void>;
global using unsafe GDExtensionScriptInstanceFreePropertyList2 = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionPropertyInfo*, uint, void>;
global using unsafe GDExtensionScriptInstanceGetClassCategory = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionPropertyInfo*, byte>;
global using unsafe GDExtensionScriptInstanceGetPropertyType = delegate* unmanaged[Cdecl]<void*, void*, byte*, Godot.GDExtensionVariantType>;
global using unsafe GDExtensionScriptInstanceValidateProperty = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionPropertyInfo*, byte>;
global using unsafe GDExtensionScriptInstancePropertyCanRevert = delegate* unmanaged[Cdecl]<void*, void*, byte>;
global using unsafe GDExtensionScriptInstancePropertyGetRevert = delegate* unmanaged[Cdecl]<void*, void*, void*, byte>;
global using unsafe GDExtensionScriptInstanceGetOwner = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionScriptInstancePropertyStateAdd = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionScriptInstanceGetPropertyState = delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, void*, void>, void*, void>;
global using unsafe GDExtensionScriptInstanceGetMethodList = delegate* unmanaged[Cdecl]<void*, uint*, Godot.GDExtensionMethodInfo*>;
global using unsafe GDExtensionScriptInstanceFreeMethodList = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionMethodInfo*, void>;
global using unsafe GDExtensionScriptInstanceFreeMethodList2 = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionMethodInfo*, uint, void>;
global using unsafe GDExtensionScriptInstanceHasMethod = delegate* unmanaged[Cdecl]<void*, void*, byte>;
global using unsafe GDExtensionScriptInstanceGetMethodArgumentCount = delegate* unmanaged[Cdecl]<void*, void*, byte*, long>;
global using unsafe GDExtensionScriptInstanceCall = delegate* unmanaged[Cdecl]<void*, void*, void**, long, void*, Godot.GDExtensionCallError*, void>;
global using unsafe GDExtensionScriptInstanceNotification = delegate* unmanaged[Cdecl]<void*, int, void>;
global using unsafe GDExtensionScriptInstanceNotification2 = delegate* unmanaged[Cdecl]<void*, int, byte, void>;
global using unsafe GDExtensionScriptInstanceToString = delegate* unmanaged[Cdecl]<void*, byte*, void*, void>;
global using unsafe GDExtensionScriptInstanceRefCountIncremented = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionScriptInstanceRefCountDecremented = delegate* unmanaged[Cdecl]<void*, byte>;
global using unsafe GDExtensionScriptInstanceGetScript = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionScriptInstanceIsPlaceholder = delegate* unmanaged[Cdecl]<void*, byte>;
global using unsafe GDExtensionScriptLanguagePtr = void*;
global using unsafe GDExtensionScriptInstanceGetLanguage = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionScriptInstanceFree = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionScriptInstancePtr = void*;
global using unsafe GDExtensionWorkerThreadPoolGroupTask = delegate* unmanaged[Cdecl]<void*, uint, void>;
global using unsafe GDExtensionWorkerThreadPoolTask = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionInitializeCallback = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionInitializationLevel, void>;
global using unsafe GDExtensionDeinitializeCallback = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionInitializationLevel, void>;
global using unsafe GDExtensionInterfaceFunctionPtr = delegate* unmanaged[Cdecl]<void>;
global using unsafe GDExtensionInterfaceGetProcAddress = delegate* unmanaged[Cdecl]<byte*, delegate* unmanaged[Cdecl]<void>>;
global using unsafe GDExtensionInitializationFunction = delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<byte*, delegate* unmanaged[Cdecl]<void>>, void*, Godot.GDExtensionInitialization*, byte>;
global using unsafe GDExtensionMainLoopStartupCallback = delegate* unmanaged[Cdecl]<void>;
global using unsafe GDExtensionMainLoopShutdownCallback = delegate* unmanaged[Cdecl]<void>;
global using unsafe GDExtensionMainLoopFrameCallback = delegate* unmanaged[Cdecl]<void>;
global using unsafe GDExtensionInterfaceGetGodotVersion = delegate* unmanaged[Cdecl]<Godot.GDExtensionGodotVersion*, void>;
global using unsafe GDExtensionInterfaceGetGodotVersion2 = delegate* unmanaged[Cdecl]<Godot.GDExtensionGodotVersion2*, void>;
global using unsafe GDExtensionInterfaceMemAlloc = delegate* unmanaged[Cdecl]<nuint, void*>;
global using unsafe GDExtensionInterfaceMemRealloc = delegate* unmanaged[Cdecl]<void*, nuint, void*>;
global using unsafe GDExtensionInterfaceMemFree = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionInterfaceMemAlloc2 = delegate* unmanaged[Cdecl]<nuint, byte, void*>;
global using unsafe GDExtensionInterfaceMemRealloc2 = delegate* unmanaged[Cdecl]<void*, nuint, byte, void*>;
global using unsafe GDExtensionInterfaceMemFree2 = delegate* unmanaged[Cdecl]<void*, byte, void>;
global using unsafe GDExtensionInterfacePrintError = delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, byte, void>;
global using unsafe GDExtensionInterfacePrintErrorWithMessage = delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, byte, void>;
global using unsafe GDExtensionInterfacePrintWarning = delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, byte, void>;
global using unsafe GDExtensionInterfacePrintWarningWithMessage = delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, byte, void>;
global using unsafe GDExtensionInterfacePrintScriptError = delegate* unmanaged[Cdecl]<byte*, byte*, byte*, int, byte, void>;
global using unsafe GDExtensionInterfacePrintScriptErrorWithMessage = delegate* unmanaged[Cdecl]<byte*, byte*, byte*, byte*, int, byte, void>;
global using unsafe GDExtensionInterfaceGetNativeStructSize = delegate* unmanaged[Cdecl]<void*, ulong>;
global using unsafe GDExtensionInterfaceVariantNewCopy = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionInterfaceVariantNewNil = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionInterfaceVariantDestroy = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionInterfaceVariantCall = delegate* unmanaged[Cdecl]<void*, void*, void**, long, void*, Godot.GDExtensionCallError*, void>;
global using unsafe GDExtensionInterfaceVariantCallStatic = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, void*, void**, long, void*, Godot.GDExtensionCallError*, void>;
global using unsafe GDExtensionInterfaceVariantEvaluate = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantOperator, void*, void*, void*, byte*, void>;
global using unsafe GDExtensionInterfaceVariantSet = delegate* unmanaged[Cdecl]<void*, void*, void*, byte*, void>;
global using unsafe GDExtensionInterfaceVariantSetNamed = delegate* unmanaged[Cdecl]<void*, void*, void*, byte*, void>;
global using unsafe GDExtensionInterfaceVariantSetKeyed = delegate* unmanaged[Cdecl]<void*, void*, void*, byte*, void>;
global using unsafe GDExtensionInterfaceVariantSetIndexed = delegate* unmanaged[Cdecl]<void*, long, void*, byte*, byte*, void>;
global using unsafe GDExtensionInterfaceVariantGet = delegate* unmanaged[Cdecl]<void*, void*, void*, byte*, void>;
global using unsafe GDExtensionInterfaceVariantGetNamed = delegate* unmanaged[Cdecl]<void*, void*, void*, byte*, void>;
global using unsafe GDExtensionInterfaceVariantGetKeyed = delegate* unmanaged[Cdecl]<void*, void*, void*, byte*, void>;
global using unsafe GDExtensionInterfaceVariantGetIndexed = delegate* unmanaged[Cdecl]<void*, long, void*, byte*, byte*, void>;
global using unsafe GDExtensionInterfaceVariantIterInit = delegate* unmanaged[Cdecl]<void*, void*, byte*, byte>;
global using unsafe GDExtensionInterfaceVariantIterNext = delegate* unmanaged[Cdecl]<void*, void*, byte*, byte>;
global using unsafe GDExtensionInterfaceVariantIterGet = delegate* unmanaged[Cdecl]<void*, void*, void*, byte*, void>;
global using unsafe GDExtensionInterfaceVariantHash = delegate* unmanaged[Cdecl]<void*, long>;
global using unsafe GDExtensionInterfaceVariantRecursiveHash = delegate* unmanaged[Cdecl]<void*, long, long>;
global using unsafe GDExtensionInterfaceVariantHashCompare = delegate* unmanaged[Cdecl]<void*, void*, byte>;
global using unsafe GDExtensionInterfaceVariantBooleanize = delegate* unmanaged[Cdecl]<void*, byte>;
global using unsafe GDExtensionInterfaceVariantDuplicate = delegate* unmanaged[Cdecl]<void*, void*, byte, void>;
global using unsafe GDExtensionInterfaceVariantStringify = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionInterfaceVariantGetType = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionVariantType>;
global using unsafe GDExtensionInterfaceVariantHasMethod = delegate* unmanaged[Cdecl]<void*, void*, byte>;
global using unsafe GDExtensionInterfaceVariantHasMember = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, void*, byte>;
global using unsafe GDExtensionInterfaceVariantHasKey = delegate* unmanaged[Cdecl]<void*, void*, byte*, byte>;
global using unsafe GDExtensionInterfaceVariantGetObjectInstanceId = delegate* unmanaged[Cdecl]<void*, ulong>;
global using unsafe GDExtensionInterfaceVariantGetTypeName = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, void*, void>;
global using unsafe GDExtensionInterfaceVariantCanConvert = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, Godot.GDExtensionVariantType, byte>;
global using unsafe GDExtensionInterfaceVariantCanConvertStrict = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, Godot.GDExtensionVariantType, byte>;
global using unsafe GDExtensionInterfaceGetVariantFromTypeConstructor = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void>>;
global using unsafe GDExtensionInterfaceGetVariantToTypeConstructor = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void>>;
global using unsafe GDExtensionInterfaceVariantGetPtrInternalGetter = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*>>;
global using unsafe GDExtensionInterfaceVariantGetPtrOperatorEvaluator = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantOperator, Godot.GDExtensionVariantType, Godot.GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>>;
global using unsafe GDExtensionInterfaceVariantGetPtrBuiltinMethod = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, void*, long, delegate* unmanaged[Cdecl]<void*, void**, void*, int, void>>;
global using unsafe GDExtensionInterfaceVariantGetPtrConstructor = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, int, delegate* unmanaged[Cdecl]<void*, void**, void>>;
global using unsafe GDExtensionInterfaceVariantGetPtrDestructor = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void>>;
global using unsafe GDExtensionInterfaceVariantConstruct = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, void*, void**, int, Godot.GDExtensionCallError*, void>;
global using unsafe GDExtensionInterfaceVariantGetPtrSetter = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, void*, delegate* unmanaged[Cdecl]<void*, void*, void>>;
global using unsafe GDExtensionInterfaceVariantGetPtrGetter = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, void*, delegate* unmanaged[Cdecl]<void*, void*, void>>;
global using unsafe GDExtensionInterfaceVariantGetPtrIndexedSetter = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, long, void*, void>>;
global using unsafe GDExtensionInterfaceVariantGetPtrIndexedGetter = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, long, void*, void>>;
global using unsafe GDExtensionInterfaceVariantGetPtrKeyedSetter = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>>;
global using unsafe GDExtensionInterfaceVariantGetPtrKeyedGetter = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, void*, void>>;
global using unsafe GDExtensionInterfaceVariantGetPtrKeyedChecker = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, delegate* unmanaged[Cdecl]<void*, void*, uint>>;
global using unsafe GDExtensionInterfaceVariantGetConstantValue = delegate* unmanaged[Cdecl]<Godot.GDExtensionVariantType, void*, void*, void>;
global using unsafe GDExtensionInterfaceVariantGetPtrUtilityFunction = delegate* unmanaged[Cdecl]<void*, long, delegate* unmanaged[Cdecl]<void*, void**, int, void>>;
global using unsafe GDExtensionInterfaceStringNewWithLatin1Chars = delegate* unmanaged[Cdecl]<void*, byte*, void>;
global using unsafe GDExtensionInterfaceStringNewWithUtf8Chars = delegate* unmanaged[Cdecl]<void*, byte*, void>;
global using unsafe GDExtensionInterfaceStringNewWithUtf16Chars = delegate* unmanaged[Cdecl]<void*, ushort*, void>;
global using unsafe GDExtensionInterfaceStringNewWithUtf32Chars = delegate* unmanaged[Cdecl]<void*, uint*, void>;
global using unsafe GDExtensionInterfaceStringNewWithWideChars = delegate* unmanaged[Cdecl]<void*, char*, void>;
global using unsafe GDExtensionInterfaceStringNewWithLatin1CharsAndLen = delegate* unmanaged[Cdecl]<void*, byte*, long, void>;
global using unsafe GDExtensionInterfaceStringNewWithUtf8CharsAndLen = delegate* unmanaged[Cdecl]<void*, byte*, long, void>;
global using unsafe GDExtensionInterfaceStringNewWithUtf8CharsAndLen2 = delegate* unmanaged[Cdecl]<void*, byte*, long, long>;
global using unsafe GDExtensionInterfaceStringNewWithUtf16CharsAndLen = delegate* unmanaged[Cdecl]<void*, ushort*, long, void>;
global using unsafe GDExtensionInterfaceStringNewWithUtf16CharsAndLen2 = delegate* unmanaged[Cdecl]<void*, ushort*, long, byte, long>;
global using unsafe GDExtensionInterfaceStringNewWithUtf32CharsAndLen = delegate* unmanaged[Cdecl]<void*, uint*, long, void>;
global using unsafe GDExtensionInterfaceStringNewWithWideCharsAndLen = delegate* unmanaged[Cdecl]<void*, char*, long, void>;
global using unsafe GDExtensionInterfaceStringToLatin1Chars = delegate* unmanaged[Cdecl]<void*, byte*, long, long>;
global using unsafe GDExtensionInterfaceStringToUtf8Chars = delegate* unmanaged[Cdecl]<void*, byte*, long, long>;
global using unsafe GDExtensionInterfaceStringToUtf16Chars = delegate* unmanaged[Cdecl]<void*, ushort*, long, long>;
global using unsafe GDExtensionInterfaceStringToUtf32Chars = delegate* unmanaged[Cdecl]<void*, uint*, long, long>;
global using unsafe GDExtensionInterfaceStringToWideChars = delegate* unmanaged[Cdecl]<void*, char*, long, long>;
global using unsafe GDExtensionInterfaceStringOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, uint*>;
global using unsafe GDExtensionInterfaceStringOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, uint*>;
global using unsafe GDExtensionInterfaceStringOperatorPlusEqString = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionInterfaceStringOperatorPlusEqChar = delegate* unmanaged[Cdecl]<void*, uint, void>;
global using unsafe GDExtensionInterfaceStringOperatorPlusEqCstr = delegate* unmanaged[Cdecl]<void*, byte*, void>;
global using unsafe GDExtensionInterfaceStringOperatorPlusEqWcstr = delegate* unmanaged[Cdecl]<void*, char*, void>;
global using unsafe GDExtensionInterfaceStringOperatorPlusEqC32Str = delegate* unmanaged[Cdecl]<void*, uint*, void>;
global using unsafe GDExtensionInterfaceStringResize = delegate* unmanaged[Cdecl]<void*, long, long>;
global using unsafe GDExtensionInterfaceStringNameNewWithLatin1Chars = delegate* unmanaged[Cdecl]<void*, byte*, byte, void>;
global using unsafe GDExtensionInterfaceStringNameNewWithUtf8Chars = delegate* unmanaged[Cdecl]<void*, byte*, void>;
global using unsafe GDExtensionInterfaceStringNameNewWithUtf8CharsAndLen = delegate* unmanaged[Cdecl]<void*, byte*, long, void>;
global using unsafe GDExtensionInterfaceXmlParserOpenBuffer = delegate* unmanaged[Cdecl]<void*, byte*, nuint, long>;
global using unsafe GDExtensionInterfaceFileAccessStoreBuffer = delegate* unmanaged[Cdecl]<void*, byte*, ulong, void>;
global using unsafe GDExtensionInterfaceFileAccessGetBuffer = delegate* unmanaged[Cdecl]<void*, byte*, ulong, ulong>;
global using unsafe GDExtensionInterfaceImagePtrw = delegate* unmanaged[Cdecl]<void*, byte*>;
global using unsafe GDExtensionInterfaceImagePtr = delegate* unmanaged[Cdecl]<void*, byte*>;
global using unsafe GDExtensionInterfaceWorkerThreadPoolAddNativeGroupTask = delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, uint, void>, void*, int, int, byte, void*, long>;
global using unsafe GDExtensionInterfaceWorkerThreadPoolAddNativeTask = delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void>, void*, byte, void*, long>;
global using unsafe GDExtensionInterfacePackedByteArrayOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, byte*>;
global using unsafe GDExtensionInterfacePackedByteArrayOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, byte*>;
global using unsafe GDExtensionInterfacePackedFloat32ArrayOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, float*>;
global using unsafe GDExtensionInterfacePackedFloat32ArrayOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, float*>;
global using unsafe GDExtensionInterfacePackedFloat64ArrayOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, double*>;
global using unsafe GDExtensionInterfacePackedFloat64ArrayOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, double*>;
global using unsafe GDExtensionInterfacePackedInt32ArrayOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, int*>;
global using unsafe GDExtensionInterfacePackedInt32ArrayOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, int*>;
global using unsafe GDExtensionInterfacePackedInt64ArrayOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, long*>;
global using unsafe GDExtensionInterfacePackedInt64ArrayOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, long*>;
global using unsafe GDExtensionInterfacePackedStringArrayOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfacePackedStringArrayOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfacePackedVector2ArrayOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfacePackedVector2ArrayOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfacePackedVector3ArrayOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfacePackedVector3ArrayOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfacePackedVector4ArrayOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfacePackedVector4ArrayOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfacePackedColorArrayOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfacePackedColorArrayOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfaceArrayOperatorIndex = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfaceArrayOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, long, void*>;
global using unsafe GDExtensionInterfaceArrayRef = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionInterfaceArraySetTyped = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionVariantType, void*, void*, void>;
global using unsafe GDExtensionInterfaceDictionaryOperatorIndex = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionInterfaceDictionaryOperatorIndexConst = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionInterfaceDictionarySetTyped = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionVariantType, void*, void*, Godot.GDExtensionVariantType, void*, void*, void>;
global using unsafe GDExtensionInterfaceObjectMethodBindCall = delegate* unmanaged[Cdecl]<void*, void*, void**, long, void*, Godot.GDExtensionCallError*, void>;
global using unsafe GDExtensionInterfaceObjectMethodBindPtrcall = delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void>;
global using unsafe GDExtensionInterfaceObjectDestroy = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionInterfaceGlobalGetSingleton = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionInterfaceObjectGetInstanceBinding = delegate* unmanaged[Cdecl]<void*, void*, Godot.GDExtensionInstanceBindingCallbacks*, void*>;
global using unsafe GDExtensionInterfaceObjectSetInstanceBinding = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.GDExtensionInstanceBindingCallbacks*, void>;
global using unsafe GDExtensionInterfaceObjectFreeInstanceBinding = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionInterfaceObjectSetInstance = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionInterfaceObjectGetClassName = delegate* unmanaged[Cdecl]<void*, void*, void*, byte>;
global using unsafe GDExtensionInterfaceObjectCastTo = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionInterfaceObjectGetInstanceFromId = delegate* unmanaged[Cdecl]<ulong, void*>;
global using unsafe GDExtensionInterfaceObjectGetInstanceId = delegate* unmanaged[Cdecl]<void*, ulong>;
global using unsafe GDExtensionInterfaceObjectHasScriptMethod = delegate* unmanaged[Cdecl]<void*, void*, byte>;
global using unsafe GDExtensionInterfaceObjectCallScriptMethod = delegate* unmanaged[Cdecl]<void*, void*, void**, long, void*, Godot.GDExtensionCallError*, void>;
global using unsafe GDExtensionInterfaceRefGetObject = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionInterfaceRefSetObject = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionInterfaceScriptInstanceCreate = delegate* unmanaged[Cdecl]<Godot.GDExtensionScriptInstanceInfo*, void*, void*>;
global using unsafe GDExtensionInterfaceScriptInstanceCreate2 = delegate* unmanaged[Cdecl]<Godot.GDExtensionScriptInstanceInfo2*, void*, void*>;
global using unsafe GDExtensionInterfaceScriptInstanceCreate3 = delegate* unmanaged[Cdecl]<Godot.GDExtensionScriptInstanceInfo3*, void*, void*>;
global using unsafe GDExtensionInterfacePlaceholderScriptInstanceCreate = delegate* unmanaged[Cdecl]<void*, void*, void*, void*>;
global using unsafe GDExtensionInterfacePlaceholderScriptInstanceUpdate = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionInterfaceObjectGetScriptInstance = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionInterfaceObjectSetScriptInstance = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionInterfaceCallableCustomCreate = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionCallableCustomInfo*, void>;
global using unsafe GDExtensionInterfaceCallableCustomCreate2 = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionCallableCustomInfo2*, void>;
global using unsafe GDExtensionInterfaceCallableCustomGetUserdata = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionInterfaceClassdbConstructObject = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionInterfaceClassdbConstructObject2 = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionInterfaceClassdbGetMethodBind = delegate* unmanaged[Cdecl]<void*, void*, long, void*>;
global using unsafe GDExtensionInterfaceClassdbGetClassTag = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClass = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.GDExtensionClassCreationInfo*, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClass2 = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.GDExtensionClassCreationInfo2*, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClass3 = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.GDExtensionClassCreationInfo3*, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClass4 = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.GDExtensionClassCreationInfo4*, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClass5 = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.GDExtensionClassCreationInfo4*, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClassMethod = delegate* unmanaged[Cdecl]<void*, void*, Godot.GDExtensionClassMethodInfo*, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClassVirtualMethod = delegate* unmanaged[Cdecl]<void*, void*, Godot.GDExtensionClassVirtualMethodInfo*, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClassIntegerConstant = delegate* unmanaged[Cdecl]<void*, void*, void*, void*, long, byte, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClassProperty = delegate* unmanaged[Cdecl]<void*, void*, Godot.GDExtensionPropertyInfo*, void*, void*, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClassPropertyIndexed = delegate* unmanaged[Cdecl]<void*, void*, Godot.GDExtensionPropertyInfo*, void*, void*, long, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClassPropertyGroup = delegate* unmanaged[Cdecl]<void*, void*, void*, void*, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClassPropertySubgroup = delegate* unmanaged[Cdecl]<void*, void*, void*, void*, void>;
global using unsafe GDExtensionInterfaceClassdbRegisterExtensionClassSignal = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.GDExtensionPropertyInfo*, long, void>;
global using unsafe GDExtensionInterfaceClassdbUnregisterExtensionClass = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionInterfaceGetLibraryPath = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionInterfaceEditorAddPlugin = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionInterfaceEditorRemovePlugin = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionInterfaceEditorHelpLoadXmlFromUtf8Chars = delegate* unmanaged[Cdecl]<byte*, void>;
global using unsafe GDExtensionInterfaceEditorHelpLoadXmlFromUtf8CharsAndLen = delegate* unmanaged[Cdecl]<byte*, long, void>;
global using unsafe GDExtensionInterfaceEditorRegisterGetClassesUsedCallback = delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void>, void>;
global using unsafe GDExtensionInterfaceRegisterMainLoopCallbacks = delegate* unmanaged[Cdecl]<void*, Godot.GDExtensionMainLoopCallbacks*, void>;

using System;
using System.Runtime.InteropServices;

namespace Godot;

public enum GDExtensionVariantType
{
    GDExtensionVariantTypeNil = 0,
    GDExtensionVariantTypeBool = 1,
    GDExtensionVariantTypeInt = 2,
    GDExtensionVariantTypeFloat = 3,
    GDExtensionVariantTypeString = 4,
    GDExtensionVariantTypeVector2 = 5,
    GDExtensionVariantTypeVector2I = 6,
    GDExtensionVariantTypeRect2 = 7,
    GDExtensionVariantTypeRect2I = 8,
    GDExtensionVariantTypeVector3 = 9,
    GDExtensionVariantTypeVector3I = 10,
    GDExtensionVariantTypeTransform2D = 11,
    GDExtensionVariantTypeVector4 = 12,
    GDExtensionVariantTypeVector4I = 13,
    GDExtensionVariantTypePlane = 14,
    GDExtensionVariantTypeQuaternion = 15,
    GDExtensionVariantTypeAabb = 16,
    GDExtensionVariantTypeBasis = 17,
    GDExtensionVariantTypeTransform3D = 18,
    GDExtensionVariantTypeProjection = 19,
    GDExtensionVariantTypeColor = 20,
    GDExtensionVariantTypeStringName = 21,
    GDExtensionVariantTypeNodePath = 22,
    GDExtensionVariantTypeRid = 23,
    GDExtensionVariantTypeObject = 24,
    GDExtensionVariantTypeCallable = 25,
    GDExtensionVariantTypeSignal = 26,
    GDExtensionVariantTypeDictionary = 27,
    GDExtensionVariantTypeArray = 28,
    GDExtensionVariantTypePackedByteArray = 29,
    GDExtensionVariantTypePackedInt32Array = 30,
    GDExtensionVariantTypePackedInt64Array = 31,
    GDExtensionVariantTypePackedFloat32Array = 32,
    GDExtensionVariantTypePackedFloat64Array = 33,
    GDExtensionVariantTypePackedStringArray = 34,
    GDExtensionVariantTypePackedVector2Array = 35,
    GDExtensionVariantTypePackedVector3Array = 36,
    GDExtensionVariantTypePackedColorArray = 37,
    GDExtensionVariantTypePackedVector4Array = 38,
    GDExtensionVariantTypeVariantMax = 39,
}

public enum GDExtensionVariantOperator
{
    GDExtensionVariantOpEqual = 0,
    GDExtensionVariantOpNotEqual = 1,
    GDExtensionVariantOpLess = 2,
    GDExtensionVariantOpLessEqual = 3,
    GDExtensionVariantOpGreater = 4,
    GDExtensionVariantOpGreaterEqual = 5,
    GDExtensionVariantOpAdd = 6,
    GDExtensionVariantOpSubtract = 7,
    GDExtensionVariantOpMultiply = 8,
    GDExtensionVariantOpDivide = 9,
    GDExtensionVariantOpNegate = 10,
    GDExtensionVariantOpPositive = 11,
    GDExtensionVariantOpModule = 12,
    GDExtensionVariantOpPower = 13,
    GDExtensionVariantOpShiftLeft = 14,
    GDExtensionVariantOpShiftRight = 15,
    GDExtensionVariantOpBitAnd = 16,
    GDExtensionVariantOpBitOr = 17,
    GDExtensionVariantOpBitXor = 18,
    GDExtensionVariantOpBitNegate = 19,
    GDExtensionVariantOpAnd = 20,
    GDExtensionVariantOpOr = 21,
    GDExtensionVariantOpXor = 22,
    GDExtensionVariantOpNot = 23,
    GDExtensionVariantOpIn = 24,
    GDExtensionVariantOpMax = 25,
}

public enum GDExtensionCallErrorType
{
    GDExtensionCallOk = 0,
    GDExtensionCallErrorInvalidMethod = 1,
    GDExtensionCallErrorInvalidArgument = 2,
    GDExtensionCallErrorTooManyArguments = 3,
    GDExtensionCallErrorTooFewArguments = 4,
    GDExtensionCallErrorInstanceIsNull = 5,
    GDExtensionCallErrorMethodNotConst = 6,
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionCallError
{
    public GDExtensionCallErrorType Error;
    public int Argument;
    public int Expected;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionInstanceBindingCallbacks
{
    public unsafe GDExtensionInstanceBindingCreateCallback CreateCallback;
    public unsafe GDExtensionInstanceBindingFreeCallback FreeCallback;
    public unsafe GDExtensionInstanceBindingReferenceCallback ReferenceCallback;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionPropertyInfo
{
    public GDExtensionVariantType Type;
    public unsafe GDExtensionStringNamePtr Name;
    public unsafe GDExtensionStringNamePtr ClassName;
    public uint Hint;
    public unsafe GDExtensionStringPtr HintString;
    public uint Usage;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionMethodInfo
{
    public unsafe GDExtensionStringNamePtr Name;
    public GDExtensionPropertyInfo ReturnValue;
    public uint Flags;
    public int Id;
    public uint ArgumentCount;
    public unsafe GDExtensionPropertyInfo* Arguments;
    public uint DefaultArgumentCount;
    public unsafe GDExtensionVariantPtr* DefaultArguments;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassCreationInfo
{
    public GDExtensionBool IsVirtual;
    public GDExtensionBool IsAbstract;
    public unsafe GDExtensionClassSet SetFunc;
    public unsafe GDExtensionClassGet GetFunc;
    public unsafe GDExtensionClassGetPropertyList GetPropertyListFunc;
    public unsafe GDExtensionClassFreePropertyList FreePropertyListFunc;
    public unsafe GDExtensionClassPropertyCanRevert PropertyCanRevertFunc;
    public unsafe GDExtensionClassPropertyGetRevert PropertyGetRevertFunc;
    public unsafe GDExtensionClassNotification NotificationFunc;
    public unsafe GDExtensionClassToString ToStringFunc;
    public unsafe GDExtensionClassReference ReferenceFunc;
    public unsafe GDExtensionClassUnreference UnreferenceFunc;
    public unsafe GDExtensionClassCreateInstance CreateInstanceFunc;
    public unsafe GDExtensionClassFreeInstance FreeInstanceFunc;
    public unsafe GDExtensionClassGetVirtual GetVirtualFunc;
    public unsafe GDExtensionClassGetRID GetRidFunc;
    public unsafe void* ClassUserdata;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassCreationInfo2
{
    public GDExtensionBool IsVirtual;
    public GDExtensionBool IsAbstract;
    public GDExtensionBool IsExposed;
    public unsafe GDExtensionClassSet SetFunc;
    public unsafe GDExtensionClassGet GetFunc;
    public unsafe GDExtensionClassGetPropertyList GetPropertyListFunc;
    public unsafe GDExtensionClassFreePropertyList FreePropertyListFunc;
    public unsafe GDExtensionClassPropertyCanRevert PropertyCanRevertFunc;
    public unsafe GDExtensionClassPropertyGetRevert PropertyGetRevertFunc;
    public unsafe GDExtensionClassValidateProperty ValidatePropertyFunc;
    public unsafe GDExtensionClassNotification2 NotificationFunc;
    public unsafe GDExtensionClassToString ToStringFunc;
    public unsafe GDExtensionClassReference ReferenceFunc;
    public unsafe GDExtensionClassUnreference UnreferenceFunc;
    public unsafe GDExtensionClassCreateInstance CreateInstanceFunc;
    public unsafe GDExtensionClassFreeInstance FreeInstanceFunc;
    public unsafe GDExtensionClassRecreateInstance RecreateInstanceFunc;
    public unsafe GDExtensionClassGetVirtual GetVirtualFunc;
    public unsafe GDExtensionClassGetVirtualCallData GetVirtualCallDataFunc;
    public unsafe GDExtensionClassCallVirtualWithData CallVirtualWithDataFunc;
    public unsafe GDExtensionClassGetRID GetRidFunc;
    public unsafe void* ClassUserdata;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassCreationInfo3
{
    public GDExtensionBool IsVirtual;
    public GDExtensionBool IsAbstract;
    public GDExtensionBool IsExposed;
    public GDExtensionBool IsRuntime;
    public unsafe GDExtensionClassSet SetFunc;
    public unsafe GDExtensionClassGet GetFunc;
    public unsafe GDExtensionClassGetPropertyList GetPropertyListFunc;
    public unsafe GDExtensionClassFreePropertyList2 FreePropertyListFunc;
    public unsafe GDExtensionClassPropertyCanRevert PropertyCanRevertFunc;
    public unsafe GDExtensionClassPropertyGetRevert PropertyGetRevertFunc;
    public unsafe GDExtensionClassValidateProperty ValidatePropertyFunc;
    public unsafe GDExtensionClassNotification2 NotificationFunc;
    public unsafe GDExtensionClassToString ToStringFunc;
    public unsafe GDExtensionClassReference ReferenceFunc;
    public unsafe GDExtensionClassUnreference UnreferenceFunc;
    public unsafe GDExtensionClassCreateInstance CreateInstanceFunc;
    public unsafe GDExtensionClassFreeInstance FreeInstanceFunc;
    public unsafe GDExtensionClassRecreateInstance RecreateInstanceFunc;
    public unsafe GDExtensionClassGetVirtual GetVirtualFunc;
    public unsafe GDExtensionClassGetVirtualCallData GetVirtualCallDataFunc;
    public unsafe GDExtensionClassCallVirtualWithData CallVirtualWithDataFunc;
    public unsafe GDExtensionClassGetRID GetRidFunc;
    public unsafe void* ClassUserdata;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassCreationInfo4
{
    public GDExtensionBool IsVirtual;
    public GDExtensionBool IsAbstract;
    public GDExtensionBool IsExposed;
    public GDExtensionBool IsRuntime;
    public unsafe GDExtensionConstStringPtr IconPath;
    public unsafe GDExtensionClassSet SetFunc;
    public unsafe GDExtensionClassGet GetFunc;
    public unsafe GDExtensionClassGetPropertyList GetPropertyListFunc;
    public unsafe GDExtensionClassFreePropertyList2 FreePropertyListFunc;
    public unsafe GDExtensionClassPropertyCanRevert PropertyCanRevertFunc;
    public unsafe GDExtensionClassPropertyGetRevert PropertyGetRevertFunc;
    public unsafe GDExtensionClassValidateProperty ValidatePropertyFunc;
    public unsafe GDExtensionClassNotification2 NotificationFunc;
    public unsafe GDExtensionClassToString ToStringFunc;
    public unsafe GDExtensionClassReference ReferenceFunc;
    public unsafe GDExtensionClassUnreference UnreferenceFunc;
    public unsafe GDExtensionClassCreateInstance2 CreateInstanceFunc;
    public unsafe GDExtensionClassFreeInstance FreeInstanceFunc;
    public unsafe GDExtensionClassRecreateInstance RecreateInstanceFunc;
    public unsafe GDExtensionClassGetVirtual2 GetVirtualFunc;
    public unsafe GDExtensionClassGetVirtualCallData2 GetVirtualCallDataFunc;
    public unsafe GDExtensionClassCallVirtualWithData CallVirtualWithDataFunc;
    public unsafe void* ClassUserdata;
}

[Flags]
public enum GDExtensionClassMethodFlags
{
    GDExtensionMethodFlagNormal = 1,
    GDExtensionMethodFlagEditor = 2,
    GDExtensionMethodFlagConst = 4,
    GDExtensionMethodFlagVirtual = 8,
    GDExtensionMethodFlagVararg = 16,
    GDExtensionMethodFlagStatic = 32,
    GDExtensionMethodFlagVirtualRequired = 128,
    GDExtensionMethodFlagsDefault = 1,
}

public enum GDExtensionClassMethodArgumentMetadata
{
    GDExtensionMethodArgumentMetadataNone = 0,
    GDExtensionMethodArgumentMetadataIntIsInt8 = 1,
    GDExtensionMethodArgumentMetadataIntIsInt16 = 2,
    GDExtensionMethodArgumentMetadataIntIsInt32 = 3,
    GDExtensionMethodArgumentMetadataIntIsInt64 = 4,
    GDExtensionMethodArgumentMetadataIntIsUint8 = 5,
    GDExtensionMethodArgumentMetadataIntIsUint16 = 6,
    GDExtensionMethodArgumentMetadataIntIsUint32 = 7,
    GDExtensionMethodArgumentMetadataIntIsUint64 = 8,
    GDExtensionMethodArgumentMetadataRealIsFloat = 9,
    GDExtensionMethodArgumentMetadataRealIsDouble = 10,
    GDExtensionMethodArgumentMetadataIntIsChar16 = 11,
    GDExtensionMethodArgumentMetadataIntIsChar32 = 12,
    GDExtensionMethodArgumentMetadataObjectIsRequired = 13,
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassMethodInfo
{
    public unsafe GDExtensionStringNamePtr Name;
    public unsafe void* MethodUserdata;
    public unsafe GDExtensionClassMethodCall CallFunc;
    public unsafe GDExtensionClassMethodPtrCall PtrcallFunc;
    public uint MethodFlags;
    public GDExtensionBool HasReturnValue;
    public unsafe GDExtensionPropertyInfo* ReturnValueInfo;
    public GDExtensionClassMethodArgumentMetadata ReturnValueMetadata;
    public uint ArgumentCount;
    public unsafe GDExtensionPropertyInfo* ArgumentsInfo;
    public unsafe GDExtensionClassMethodArgumentMetadata* ArgumentsMetadata;
    public uint DefaultArgumentCount;
    public unsafe GDExtensionVariantPtr* DefaultArguments;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionClassVirtualMethodInfo
{
    public unsafe GDExtensionStringNamePtr Name;
    public uint MethodFlags;
    public GDExtensionPropertyInfo ReturnValue;
    public GDExtensionClassMethodArgumentMetadata ReturnValueMetadata;
    public uint ArgumentCount;
    public unsafe GDExtensionPropertyInfo* Arguments;
    public unsafe GDExtensionClassMethodArgumentMetadata* ArgumentsMetadata;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionCallableCustomInfo
{
    public unsafe void* CallableUserdata;
    public unsafe void* Token;
    public GDObjectInstanceID ObjectId;
    public unsafe GDExtensionCallableCustomCall CallFunc;
    public unsafe GDExtensionCallableCustomIsValid IsValidFunc;
    public unsafe GDExtensionCallableCustomFree FreeFunc;
    public unsafe GDExtensionCallableCustomHash HashFunc;
    public unsafe GDExtensionCallableCustomEqual EqualFunc;
    public unsafe GDExtensionCallableCustomLessThan LessThanFunc;
    public unsafe GDExtensionCallableCustomToString ToStringFunc;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionCallableCustomInfo2
{
    public unsafe void* CallableUserdata;
    public unsafe void* Token;
    public GDObjectInstanceID ObjectId;
    public unsafe GDExtensionCallableCustomCall CallFunc;
    public unsafe GDExtensionCallableCustomIsValid IsValidFunc;
    public unsafe GDExtensionCallableCustomFree FreeFunc;
    public unsafe GDExtensionCallableCustomHash HashFunc;
    public unsafe GDExtensionCallableCustomEqual EqualFunc;
    public unsafe GDExtensionCallableCustomLessThan LessThanFunc;
    public unsafe GDExtensionCallableCustomToString ToStringFunc;
    public unsafe GDExtensionCallableCustomGetArgumentCount GetArgumentCountFunc;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionScriptInstanceInfo
{
    public unsafe GDExtensionScriptInstanceSet SetFunc;
    public unsafe GDExtensionScriptInstanceGet GetFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyList GetPropertyListFunc;
    public unsafe GDExtensionScriptInstanceFreePropertyList FreePropertyListFunc;
    public unsafe GDExtensionScriptInstancePropertyCanRevert PropertyCanRevertFunc;
    public unsafe GDExtensionScriptInstancePropertyGetRevert PropertyGetRevertFunc;
    public unsafe GDExtensionScriptInstanceGetOwner GetOwnerFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyState GetPropertyStateFunc;
    public unsafe GDExtensionScriptInstanceGetMethodList GetMethodListFunc;
    public unsafe GDExtensionScriptInstanceFreeMethodList FreeMethodListFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyType GetPropertyTypeFunc;
    public unsafe GDExtensionScriptInstanceHasMethod HasMethodFunc;
    public unsafe GDExtensionScriptInstanceCall CallFunc;
    public unsafe GDExtensionScriptInstanceNotification NotificationFunc;
    public unsafe GDExtensionScriptInstanceToString ToStringFunc;
    public unsafe GDExtensionScriptInstanceRefCountIncremented RefcountIncrementedFunc;
    public unsafe GDExtensionScriptInstanceRefCountDecremented RefcountDecrementedFunc;
    public unsafe GDExtensionScriptInstanceGetScript GetScriptFunc;
    public unsafe GDExtensionScriptInstanceIsPlaceholder IsPlaceholderFunc;
    public unsafe GDExtensionScriptInstanceSet SetFallbackFunc;
    public unsafe GDExtensionScriptInstanceGet GetFallbackFunc;
    public unsafe GDExtensionScriptInstanceGetLanguage GetLanguageFunc;
    public unsafe GDExtensionScriptInstanceFree FreeFunc;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionScriptInstanceInfo2
{
    public unsafe GDExtensionScriptInstanceSet SetFunc;
    public unsafe GDExtensionScriptInstanceGet GetFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyList GetPropertyListFunc;
    public unsafe GDExtensionScriptInstanceFreePropertyList FreePropertyListFunc;
    public unsafe GDExtensionScriptInstanceGetClassCategory GetClassCategoryFunc;
    public unsafe GDExtensionScriptInstancePropertyCanRevert PropertyCanRevertFunc;
    public unsafe GDExtensionScriptInstancePropertyGetRevert PropertyGetRevertFunc;
    public unsafe GDExtensionScriptInstanceGetOwner GetOwnerFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyState GetPropertyStateFunc;
    public unsafe GDExtensionScriptInstanceGetMethodList GetMethodListFunc;
    public unsafe GDExtensionScriptInstanceFreeMethodList FreeMethodListFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyType GetPropertyTypeFunc;
    public unsafe GDExtensionScriptInstanceValidateProperty ValidatePropertyFunc;
    public unsafe GDExtensionScriptInstanceHasMethod HasMethodFunc;
    public unsafe GDExtensionScriptInstanceCall CallFunc;
    public unsafe GDExtensionScriptInstanceNotification2 NotificationFunc;
    public unsafe GDExtensionScriptInstanceToString ToStringFunc;
    public unsafe GDExtensionScriptInstanceRefCountIncremented RefcountIncrementedFunc;
    public unsafe GDExtensionScriptInstanceRefCountDecremented RefcountDecrementedFunc;
    public unsafe GDExtensionScriptInstanceGetScript GetScriptFunc;
    public unsafe GDExtensionScriptInstanceIsPlaceholder IsPlaceholderFunc;
    public unsafe GDExtensionScriptInstanceSet SetFallbackFunc;
    public unsafe GDExtensionScriptInstanceGet GetFallbackFunc;
    public unsafe GDExtensionScriptInstanceGetLanguage GetLanguageFunc;
    public unsafe GDExtensionScriptInstanceFree FreeFunc;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionScriptInstanceInfo3
{
    public unsafe GDExtensionScriptInstanceSet SetFunc;
    public unsafe GDExtensionScriptInstanceGet GetFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyList GetPropertyListFunc;
    public unsafe GDExtensionScriptInstanceFreePropertyList2 FreePropertyListFunc;
    public unsafe GDExtensionScriptInstanceGetClassCategory GetClassCategoryFunc;
    public unsafe GDExtensionScriptInstancePropertyCanRevert PropertyCanRevertFunc;
    public unsafe GDExtensionScriptInstancePropertyGetRevert PropertyGetRevertFunc;
    public unsafe GDExtensionScriptInstanceGetOwner GetOwnerFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyState GetPropertyStateFunc;
    public unsafe GDExtensionScriptInstanceGetMethodList GetMethodListFunc;
    public unsafe GDExtensionScriptInstanceFreeMethodList2 FreeMethodListFunc;
    public unsafe GDExtensionScriptInstanceGetPropertyType GetPropertyTypeFunc;
    public unsafe GDExtensionScriptInstanceValidateProperty ValidatePropertyFunc;
    public unsafe GDExtensionScriptInstanceHasMethod HasMethodFunc;
    public unsafe GDExtensionScriptInstanceGetMethodArgumentCount GetMethodArgumentCountFunc;
    public unsafe GDExtensionScriptInstanceCall CallFunc;
    public unsafe GDExtensionScriptInstanceNotification2 NotificationFunc;
    public unsafe GDExtensionScriptInstanceToString ToStringFunc;
    public unsafe GDExtensionScriptInstanceRefCountIncremented RefcountIncrementedFunc;
    public unsafe GDExtensionScriptInstanceRefCountDecremented RefcountDecrementedFunc;
    public unsafe GDExtensionScriptInstanceGetScript GetScriptFunc;
    public unsafe GDExtensionScriptInstanceIsPlaceholder IsPlaceholderFunc;
    public unsafe GDExtensionScriptInstanceSet SetFallbackFunc;
    public unsafe GDExtensionScriptInstanceGet GetFallbackFunc;
    public unsafe GDExtensionScriptInstanceGetLanguage GetLanguageFunc;
    public unsafe GDExtensionScriptInstanceFree FreeFunc;
}

public enum GDExtensionInitializationLevel
{
    GDExtensionInitializationCore = 0,
    GDExtensionInitializationServers = 1,
    GDExtensionInitializationScene = 2,
    GDExtensionInitializationEditor = 3,
    GDExtensionMaxInitializationLevel = 4,
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionInitialization
{
    public GDExtensionInitializationLevel MinimumInitializationLevel;
    public unsafe void* Userdata;
    public unsafe GDExtensionInitializeCallback Initialize;
    public unsafe GDExtensionDeinitializeCallback Deinitialize;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionGodotVersion
{
    public uint Major;
    public uint Minor;
    public uint Patch;
    public readonly unsafe byte* String;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionGodotVersion2
{
    public uint Major;
    public uint Minor;
    public uint Patch;
    public uint Hex;
    public readonly unsafe byte* Status;
    public readonly unsafe byte* Build;
    public readonly unsafe byte* Hash;
    public ulong Timestamp;
    public readonly unsafe byte* String;
}

[StructLayout(LayoutKind.Sequential)]
public struct GDExtensionMainLoopCallbacks
{
    public unsafe GDExtensionMainLoopStartupCallback StartupFunc;
    public unsafe GDExtensionMainLoopShutdownCallback ShutdownFunc;
    public unsafe GDExtensionMainLoopFrameCallback FrameFunc;
}
