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
global using unsafe GDExtensionRefPtr = void*;
global using unsafe GDExtensionConstRefPtr = void*;
global using static Godot.NET.GDExtensionCallErrorType;
global using unsafe GDExtensionVariantFromTypeConstructorFunc = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionTypeFromVariantConstructorFunc = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionVariantGetInternalPtrFunc = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionPtrOperatorEvaluator = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionPtrBuiltInMethod = delegate* unmanaged[Cdecl]<void*, void**, void*, int, void>;
global using unsafe GDExtensionPtrConstructor = delegate* unmanaged[Cdecl]<void*, void**, void>;
global using unsafe GDExtensionPtrDestructor = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionPtrSetter = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionPtrGetter = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionPtrIndexedSetter = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionInt, void*, void>;
global using unsafe GDExtensionPtrIndexedGetter = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionInt, void*, void>;
global using unsafe GDExtensionPtrKeyedSetter = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionPtrKeyedGetter = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionPtrKeyedChecker = delegate* unmanaged[Cdecl]<void*, void*, uint>;
global using unsafe GDExtensionPtrUtilityFunction = delegate* unmanaged[Cdecl]<void*, void**, int, void>;
global using unsafe GDExtensionClassConstructor = delegate* unmanaged[Cdecl]<void*>;
global using unsafe GDExtensionInstanceBindingCreateCallback = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionInstanceBindingFreeCallback = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionInstanceBindingReferenceCallback = delegate* unmanaged[Cdecl]<void*, void*, Godot.NET.GDExtensionBool, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassInstancePtr = void*;
global using unsafe GDExtensionClassSet = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassGet = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassGetRID = delegate* unmanaged[Cdecl]<void*, ulong>;
global using unsafe GDExtensionClassGetPropertyList = delegate* unmanaged[Cdecl]<void*, uint*, Godot.NET.GDExtensionPropertyInfo*>;
global using unsafe GDExtensionClassFreePropertyList = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionPropertyInfo*, void>;
global using unsafe GDExtensionClassFreePropertyList2 = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionPropertyInfo*, uint, void>;
global using unsafe GDExtensionClassPropertyCanRevert = delegate* unmanaged[Cdecl]<void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassPropertyGetRevert = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassValidateProperty = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionPropertyInfo*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionClassNotification = delegate* unmanaged[Cdecl]<void*, int, void>;
global using unsafe GDExtensionClassNotification2 = delegate* unmanaged[Cdecl]<void*, int, Godot.NET.GDExtensionBool, void>;
global using unsafe GDExtensionClassToString = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool*, void*, void>;
global using unsafe GDExtensionClassReference = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionClassUnreference = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionClassCallVirtual = delegate* unmanaged[Cdecl]<void*, void**, void*, void>;
global using unsafe GDExtensionClassCreateInstance = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionClassCreateInstance2 = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool, void*>;
global using unsafe GDExtensionClassFreeInstance = delegate* unmanaged[Cdecl]<void*, void*, void>;
global using unsafe GDExtensionClassRecreateInstance = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionClassGetVirtual = delegate* unmanaged[Cdecl]<void*, void*, delegate* unmanaged[Cdecl]<void*, void**, void*, void>>;
global using unsafe GDExtensionClassGetVirtual2 = delegate* unmanaged[Cdecl]<void*, void*, uint, delegate* unmanaged[Cdecl]<void*, void**, void*, void>>;
global using unsafe GDExtensionClassGetVirtualCallData = delegate* unmanaged[Cdecl]<void*, void*, void*>;
global using unsafe GDExtensionClassGetVirtualCallData2 = delegate* unmanaged[Cdecl]<void*, void*, uint, void*>;
global using unsafe GDExtensionClassCallVirtualWithData = delegate* unmanaged[Cdecl]<void*, void*, void*, void**, void*, void>;
global using unsafe GDExtensionClassLibraryPtr = void*;
global using unsafe GDExtensionEditorGetClassesUsedCallback = delegate* unmanaged[Cdecl]<void*, void>;
global using static Godot.NET.GDExtensionClassMethodFlags;
global using static Godot.NET.GDExtensionClassMethodArgumentMetadata;
global using unsafe GDExtensionClassMethodCall = delegate* unmanaged[Cdecl]<void*, void*, void**, Godot.NET.GDExtensionInt, void*, Godot.NET.GDExtensionCallError*, void>;
global using unsafe GDExtensionClassMethodValidatedCall = delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void>;
global using unsafe GDExtensionClassMethodPtrCall = delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void>;
global using unsafe GDExtensionCallableCustomCall = delegate* unmanaged[Cdecl]<void*, void**, Godot.NET.GDExtensionInt, void*, Godot.NET.GDExtensionCallError*, void>;
global using unsafe GDExtensionCallableCustomIsValid = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionCallableCustomFree = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionCallableCustomHash = delegate* unmanaged[Cdecl]<void*, uint>;
global using unsafe GDExtensionCallableCustomEqual = delegate* unmanaged[Cdecl]<void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionCallableCustomLessThan = delegate* unmanaged[Cdecl]<void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionCallableCustomToString = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool*, void*, void>;
global using unsafe GDExtensionCallableCustomGetArgumentCount = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool*, Godot.NET.GDExtensionInt>;
global using unsafe GDExtensionScriptInstanceDataPtr = void*;
global using unsafe GDExtensionScriptInstanceSet = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGet = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGetPropertyList = delegate* unmanaged[Cdecl]<void*, uint*, Godot.NET.GDExtensionPropertyInfo*>;
global using unsafe GDExtensionScriptInstanceFreePropertyList = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionPropertyInfo*, void>;
global using unsafe GDExtensionScriptInstanceFreePropertyList2 = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionPropertyInfo*, uint, void>;
global using unsafe GDExtensionScriptInstanceGetClassCategory = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionPropertyInfo*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGetPropertyType = delegate* unmanaged[Cdecl]<void*, void*, Godot.NET.GDExtensionBool*, Godot.NET.GDExtensionVariantType>;
global using unsafe GDExtensionScriptInstanceValidateProperty = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionPropertyInfo*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstancePropertyCanRevert = delegate* unmanaged[Cdecl]<void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstancePropertyGetRevert = delegate* unmanaged[Cdecl]<void*, void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGetOwner = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionScriptInstancePropertyStateAdd = delegate* unmanaged[Cdecl]<void*, void*, void*, void>;
global using unsafe GDExtensionScriptInstanceGetPropertyState = delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, void*, void>, void*, void>;
global using unsafe GDExtensionScriptInstanceGetMethodList = delegate* unmanaged[Cdecl]<void*, uint*, Godot.NET.GDExtensionMethodInfo*>;
global using unsafe GDExtensionScriptInstanceFreeMethodList = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionMethodInfo*, void>;
global using unsafe GDExtensionScriptInstanceFreeMethodList2 = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionMethodInfo*, uint, void>;
global using unsafe GDExtensionScriptInstanceHasMethod = delegate* unmanaged[Cdecl]<void*, void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGetMethodArgumentCount = delegate* unmanaged[Cdecl]<void*, void*, Godot.NET.GDExtensionBool*, Godot.NET.GDExtensionInt>;
global using unsafe GDExtensionScriptInstanceCall = delegate* unmanaged[Cdecl]<void*, void*, void**, Godot.NET.GDExtensionInt, void*, Godot.NET.GDExtensionCallError*, void>;
global using unsafe GDExtensionScriptInstanceNotification = delegate* unmanaged[Cdecl]<void*, int, void>;
global using unsafe GDExtensionScriptInstanceNotification2 = delegate* unmanaged[Cdecl]<void*, int, Godot.NET.GDExtensionBool, void>;
global using unsafe GDExtensionScriptInstanceToString = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool*, void*, void>;
global using unsafe GDExtensionScriptInstanceRefCountIncremented = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionScriptInstanceRefCountDecremented = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptInstanceGetScript = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionScriptInstanceIsPlaceholder = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionScriptLanguagePtr = void*;
global using unsafe GDExtensionScriptInstanceGetLanguage = delegate* unmanaged[Cdecl]<void*, void*>;
global using unsafe GDExtensionScriptInstanceFree = delegate* unmanaged[Cdecl]<void*, void>;
global using unsafe GDExtensionScriptInstancePtr = void*;
global using unsafe GDExtensionWorkerThreadPoolGroupTask = delegate* unmanaged[Cdecl]<void*, uint, void>;
global using unsafe GDExtensionWorkerThreadPoolTask = delegate* unmanaged[Cdecl]<void*, void>;
global using static Godot.NET.GDExtensionInitializationLevel;
global using unsafe GDExtensionInitializeCallback = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionInitializationLevel, void>;
global using unsafe GDExtensionDeinitializeCallback = delegate* unmanaged[Cdecl]<void*, Godot.NET.GDExtensionInitializationLevel, void>;
global using unsafe GDExtensionInterfaceFunctionPtr = delegate* unmanaged[Cdecl]<void>;
global using unsafe GDExtensionInterfaceGetProcAddress = delegate* unmanaged[Cdecl]<byte*, delegate* unmanaged[Cdecl]<void>>;
global using unsafe GDExtensionInitializationFunction = delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<byte*, delegate* unmanaged[Cdecl]<void>>, void*, Godot.NET.GDExtensionInitialization*, Godot.NET.GDExtensionBool>;
global using unsafe GDExtensionMainLoopStartupCallback = delegate* unmanaged[Cdecl]<void>;
global using unsafe GDExtensionMainLoopShutdownCallback = delegate* unmanaged[Cdecl]<void>;
global using unsafe GDExtensionMainLoopFrameCallback = delegate* unmanaged[Cdecl]<void>;
