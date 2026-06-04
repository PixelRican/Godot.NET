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

global using static Godot.NET.GDExtensionVariantType;
global using static Godot.NET.GDExtensionVariantOperator;
global using static Godot.NET.GDExtensionCallErrorType;
global using unsafe GDExtensionVariantFromTypeConstructorFunc = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionUninitializedVariantPtr, Godot.NET.GDExtensionTypePtr, void>;
global using unsafe GDExtensionTypeFromVariantConstructorFunc = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionUninitializedTypePtr, Godot.NET.GDExtensionVariantPtr, void>;
global using unsafe GDExtensionVariantGetInternalPtrFunc = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionVariantPtr, void*>;
global using unsafe GDExtensionPtrOperatorEvaluator = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionConstTypePtr, Godot.NET.GDExtensionConstTypePtr, Godot.NET.GDExtensionTypePtr, void>;
global using unsafe GDExtensionPtrBuiltInMethod = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionTypePtr, Godot.NET.GDExtensionConstTypePtr*, Godot.NET.GDExtensionTypePtr, int, void>;
global using unsafe GDExtensionPtrConstructor = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionUninitializedTypePtr, Godot.NET.GDExtensionConstTypePtr*, void>;
global using unsafe GDExtensionPtrDestructor = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionTypePtr, void>;
global using unsafe GDExtensionPtrSetter = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionTypePtr, Godot.NET.GDExtensionConstTypePtr, void>;
global using unsafe GDExtensionPtrGetter = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionConstTypePtr, Godot.NET.GDExtensionTypePtr, void>;
global using unsafe GDExtensionPtrIndexedSetter = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionTypePtr, Godot.NET.GDExtensionInt, Godot.NET.GDExtensionConstTypePtr, void>;
global using unsafe GDExtensionPtrIndexedGetter = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionConstTypePtr, Godot.NET.GDExtensionInt, Godot.NET.GDExtensionTypePtr, void>;
global using unsafe GDExtensionPtrKeyedSetter = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionTypePtr, Godot.NET.GDExtensionConstTypePtr, Godot.NET.GDExtensionConstTypePtr, void>;
global using unsafe GDExtensionPtrKeyedGetter = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionConstTypePtr, Godot.NET.GDExtensionConstTypePtr, Godot.NET.GDExtensionTypePtr, void>;
global using unsafe GDExtensionPtrKeyedChecker = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionConstVariantPtr, Godot.NET.GDExtensionConstVariantPtr, uint>;
global using unsafe GDExtensionPtrUtilityFunction = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionTypePtr, Godot.NET.GDExtensionConstTypePtr*, int, void>;
global using unsafe GDExtensionClassConstructor = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionObjectPtr>;
global using unsafe GDExtensionInstanceBindingCreateCallback = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionInstanceBindingFreeCallback = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionInstanceBindingReferenceCallback = delegate* unmanaged[Cdecl]<void*, void*, Godot.NET.GDExtensionBool, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassSet = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionConstVariantPtr, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassGet = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionVariantPtr, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassGetRID = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, ulong>;
global using unsafe GDExtensionClassGetPropertyList = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, uint*, Godot.NET.GDExtensionPropertyInfo*>;
global using unsafe GDExtensionClassFreePropertyList = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionPropertyInfo*, void>;
global using unsafe GDExtensionClassFreePropertyList2 = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionPropertyInfo*, uint, void>;
global using unsafe GDExtensionClassPropertyCanRevert = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassPropertyGetRevert = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionVariantPtr, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassValidateProperty = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionPropertyInfo*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassNotification = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, int, void>;
global using unsafe GDExtensionClassNotification2 = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, int, Godot.NET.GDExtensionBool, void>;
global using unsafe GDExtensionClassToString = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionBool*, Godot.NET.GDExtensionStringPtr, void>;
global using unsafe GDExtensionClassReference = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, void>;
global using unsafe GDExtensionClassUnreference = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, void>;
global using unsafe GDExtensionClassCallVirtual = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionConstTypePtr*, Godot.NET.GDExtensionTypePtr, void>;
global using unsafe GDExtensionClassCreateInstance = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionObjectPtr>;
global using unsafe GDExtensionClassCreateInstance2 = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool, Godot.NET.GDExtensionObjectPtr>;
global using unsafe GDExtensionClassFreeInstance = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionClassInstancePtr, void>;
global using unsafe GDExtensionClassRecreateInstance = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionObjectPtr, Godot.NET.GDExtensionClassInstancePtr>;
global using unsafe GDExtensionClassGetVirtual = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionConstStringNamePtr, delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionConstTypePtr*, Godot.NET.GDExtensionTypePtr, void>>;
global using unsafe GDExtensionClassGetVirtual2 = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionConstStringNamePtr, uint, delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionConstTypePtr*, Godot.NET.GDExtensionTypePtr, void>>;
global using unsafe GDExtensionClassGetVirtualCallData = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionConstStringNamePtr, void*>;
global using unsafe GDExtensionClassGetVirtualCallData2 = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionConstStringNamePtr, uint, void*>;
global using unsafe GDExtensionClassCallVirtualWithData = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionConstStringNamePtr, void*, Godot.NET.GDExtensionConstTypePtr*, Godot.NET.GDExtensionTypePtr, void>;
global using unsafe GDExtensionEditorGetClassesUsedCallback = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionTypePtr, void>;
global using static Godot.NET.GDExtensionClassMethodFlags;
global using static Godot.NET.GDExtensionClassMethodArgumentMetadata;
global using unsafe GDExtensionClassMethodCall = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionConstVariantPtr*, Godot.NET.GDExtensionInt, Godot.NET.GDExtensionVariantPtr, Godot.NET.GDExtensionCallError*, void>;
global using unsafe GDExtensionClassMethodValidatedCall = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionConstVariantPtr*, Godot.NET.GDExtensionVariantPtr, void>;
global using unsafe GDExtensionClassMethodPtrCall = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionClassInstancePtr, Godot.NET.GDExtensionConstTypePtr*, Godot.NET.GDExtensionTypePtr, void>;
global using unsafe GDExtensionCallableCustomCall = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionConstVariantPtr*, Godot.NET.GDExtensionInt, Godot.NET.GDExtensionVariantPtr, Godot.NET.GDExtensionCallError*, void>;
global using unsafe GDExtensionCallableCustomIsValid = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionCallableCustomFree = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionCallableCustomHash = delegate* unmanaged[Cdecl]<void*, uint>;
global using unsafe GDExtensionCallableCustomEqual = delegate* unmanaged[Cdecl]<void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionCallableCustomLessThan = delegate* unmanaged[Cdecl]<void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionCallableCustomToString = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool*, Godot.NET.GDExtensionStringPtr, void>;
global using unsafe GDExtensionCallableCustomGetArgumentCount = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool*, Godot.NET.GDExtensionInt>;
global using unsafe GDExtensionScriptInstanceSet = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionConstVariantPtr, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGet = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionVariantPtr, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGetPropertyList = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, uint*, Godot.NET.GDExtensionPropertyInfo*>;
global using unsafe GDExtensionScriptInstanceFreePropertyList = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionPropertyInfo*, void>;
global using unsafe GDExtensionScriptInstanceFreePropertyList2 = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionPropertyInfo*, uint, void>;
global using unsafe GDExtensionScriptInstanceGetClassCategory = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionPropertyInfo*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGetPropertyType = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionBool*, Godot.NET.GDExtensionVariantType>;
global using unsafe GDExtensionScriptInstanceValidateProperty = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionPropertyInfo*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstancePropertyCanRevert = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstancePropertyGetRevert = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionVariantPtr, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGetOwner = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionObjectPtr>;
global using unsafe GDExtensionScriptInstancePropertyStateAdd = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionConstVariantPtr, void*, void>;
global using unsafe GDExtensionScriptInstanceGetPropertyState = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionConstVariantPtr, void*, void>, void*, void>;
global using unsafe GDExtensionScriptInstanceGetMethodList = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, uint*, Godot.NET.GDExtensionMethodInfo*>;
global using unsafe GDExtensionScriptInstanceFreeMethodList = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionMethodInfo*, void>;
global using unsafe GDExtensionScriptInstanceFreeMethodList2 = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionMethodInfo*, uint, void>;
global using unsafe GDExtensionScriptInstanceHasMethod = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGetMethodArgumentCount = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionBool*, Godot.NET.GDExtensionInt>;
global using unsafe GDExtensionScriptInstanceCall = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionConstStringNamePtr, Godot.NET.GDExtensionConstVariantPtr*, Godot.NET.GDExtensionInt, Godot.NET.GDExtensionVariantPtr, Godot.NET.GDExtensionCallError*, void>;
global using unsafe GDExtensionScriptInstanceNotification = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, int, void>;
global using unsafe GDExtensionScriptInstanceNotification2 = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, int, Godot.NET.GDExtensionBool, void>;
global using unsafe GDExtensionScriptInstanceToString = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionBool*, Godot.NET.GDExtensionStringPtr, void>;
global using unsafe GDExtensionScriptInstanceRefCountIncremented = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, void>;
global using unsafe GDExtensionScriptInstanceRefCountDecremented = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGetScript = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionObjectPtr>;
global using unsafe GDExtensionScriptInstanceIsPlaceholder = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGetLanguage = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, Godot.NET.GDExtensionScriptLanguagePtr>;
global using unsafe GDExtensionScriptInstanceFree = delegate* unmanaged[Cdecl]<Godot.NET.GDExtensionScriptInstanceDataPtr, void>;
global using unsafe GDExtensionWorkerThreadPoolGroupTask = delegate* unmanaged[Cdecl]<void*, uint, void>;
global using unsafe GDExtensionWorkerThreadPoolTask = delegate* unmanaged[Cdecl]<void*, void>;
global using static Godot.NET.GDExtensionInitializationLevel;
global using unsafe GDExtensionInitializeCallback = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionInitializationLevel, void>;
global using unsafe GDExtensionDeinitializeCallback = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionInitializationLevel, void>;
global using unsafe GDExtensionInterfaceFunctionPtr = delegate* unmanaged[Cdecl]<void>;
global using unsafe GDExtensionInterfaceGetProcAddress = delegate* unmanaged[Cdecl]<byte*, delegate* unmanaged[Cdecl]<void>>;
global using unsafe GDExtensionInitializationFunction = delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<byte*, delegate* unmanaged[Cdecl]<void>>, Godot.NET.GDExtensionClassLibraryPtr, Godot.NET.GDExtensionInitialization*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionMainLoopStartupCallback = delegate* unmanaged[Cdecl]<void>;
global using unsafe GDExtensionMainLoopShutdownCallback = delegate* unmanaged[Cdecl]<void>;
global using unsafe GDExtensionMainLoopFrameCallback = delegate* unmanaged[Cdecl]<void>;
