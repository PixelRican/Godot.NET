using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Godot.GDExtension;

namespace Godot.Tests;

public static unsafe class GDExtensionInterface
{
    private static GDExtensionInterfaceClassdbConstructObject s_classdbConstructObject;
    private static GDExtensionInterfaceClassdbGetMethodBind s_classdbGetMethodBind;
    private static GDExtensionInterfaceClassdbRegisterExtensionClass s_classdbRegisterExtensionClass;
    private static GDExtensionInterfaceClassdbRegisterExtensionClassMethod s_classdbRegisterExtensionClassMethod;
    private static GDExtensionInterfaceClassdbRegisterExtensionClassProperty s_classdbRegisterExtensionClassProperty;
    private static GDExtensionInterfaceClassdbRegisterExtensionClassSignal s_classdbRegisterExtensionClassSignal;
    private static GDExtensionInterfaceGetVariantFromTypeConstructor s_getVariantFromTypeConstructor;
    private static GDExtensionInterfaceGetVariantToTypeConstructor s_getVariantToTypeConstructor;
    private static GDExtensionInterfaceObjectMethodBindCall s_objectMethodBindCall;
    private static GDExtensionInterfaceObjectMethodBindPtrcall s_objectMethodBindPtrcall;
    private static GDExtensionInterfaceObjectSetInstance s_objectSetInstance;
    private static GDExtensionInterfaceObjectSetInstanceBinding s_objectSetInstanceBinding;
    private static GDExtensionInterfaceStringNewWithUtf8CharsAndLen s_stringNewWithUtf8CharsAndLen;
    private static GDExtensionInterfaceStringNameNewWithUtf8CharsAndLen s_stringNameNewWithUtf8CharsAndLen;
    private static GDExtensionInterfaceVariantDestroy s_variantDestroy;
    private static GDExtensionInterfaceVariantGetPtrDestructor s_variantGetPtrDestructor;
    private static GDExtensionInterfaceVariantGetPtrOperatorEvaluator s_variantGetPtrOperatorEvaluator;
    private static GDExtensionInterfaceVariantGetType s_variantGetType;

    public static GDExtensionInterfaceClassdbConstructObject ClassdbConstructObject
    {
        get => s_classdbConstructObject;
    }

    public static GDExtensionInterfaceClassdbGetMethodBind ClassdbGetMethodBind
    {
        get => s_classdbGetMethodBind;
    }

    public static GDExtensionInterfaceClassdbRegisterExtensionClass ClassdbRegisterExtensionClass
    {
        get => s_classdbRegisterExtensionClass;
    }

    public static GDExtensionInterfaceClassdbRegisterExtensionClassMethod ClassdbRegisterExtensionClassMethod
    {
        get => s_classdbRegisterExtensionClassMethod;
    }

    public static GDExtensionInterfaceClassdbRegisterExtensionClassProperty ClassdbRegisterExtensionClassProperty
    {
        get => s_classdbRegisterExtensionClassProperty;
    }

    public static GDExtensionInterfaceClassdbRegisterExtensionClassSignal ClassdbRegisterExtensionClassSignal
    {
        get => s_classdbRegisterExtensionClassSignal;
    }

    public static GDExtensionInterfaceGetVariantFromTypeConstructor GetVariantFromTypeConstructor
    {
        get => s_getVariantFromTypeConstructor;
    }

    public static GDExtensionInterfaceGetVariantToTypeConstructor GetVariantToTypeConstructor
    {
        get => s_getVariantToTypeConstructor;
    }

    public static GDExtensionInterfaceObjectMethodBindCall ObjectMethodBindCall
    {
        get => s_objectMethodBindCall;
    }

    public static GDExtensionInterfaceObjectMethodBindPtrcall ObjectMethodBindPtrcall
    {
        get => s_objectMethodBindPtrcall;
    }

    public static GDExtensionInterfaceObjectSetInstance ObjectSetInstance
    {
        get => s_objectSetInstance;
    }

    public static GDExtensionInterfaceObjectSetInstanceBinding ObjectSetInstanceBinding
    {
        get => s_objectSetInstanceBinding;
    }

    public static GDExtensionInterfaceStringNewWithUtf8CharsAndLen StringNewWithUtf8CharsAndLen
    {
        get => s_stringNewWithUtf8CharsAndLen;
    }

    public static GDExtensionInterfaceStringNameNewWithUtf8CharsAndLen StringNameNewWithUtf8CharsAndLen
    {
        get => s_stringNameNewWithUtf8CharsAndLen;
    }

    public static GDExtensionInterfaceVariantDestroy VariantDestroy
    {
        get => s_variantDestroy;
    }

    public static GDExtensionInterfaceVariantGetPtrDestructor VariantGetPtrDestructor
    {
        get => s_variantGetPtrDestructor;
    }

    public static GDExtensionInterfaceVariantGetPtrOperatorEvaluator VariantGetPtrOperatorEvaluator
    {
        get => s_variantGetPtrOperatorEvaluator;
    }

    public static GDExtensionInterfaceVariantGetType VariantGetType
    {
        get => s_variantGetType;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)], EntryPoint = "GDExample_Initialize")]
    private static GDExtensionBool Initialize(GDExtensionInterfaceGetProcAddress getProcAddress, GDExtensionClassLibraryPtr library, GDExtensionInitialization* initialization)
    {
        s_classdbConstructObject = (GDExtensionInterfaceClassdbConstructObject)Load("classdb_construct_object"u8);
        s_classdbGetMethodBind = (GDExtensionInterfaceClassdbGetMethodBind)Load("classdb_get_method_bind"u8);
        s_classdbRegisterExtensionClass = (GDExtensionInterfaceClassdbRegisterExtensionClass)Load("classdb_register_extension_class"u8);
        s_classdbRegisterExtensionClassMethod = (GDExtensionInterfaceClassdbRegisterExtensionClassMethod)Load("classdb_register_extension_class_method"u8);
        s_classdbRegisterExtensionClassProperty = (GDExtensionInterfaceClassdbRegisterExtensionClassProperty)Load("classdb_register_extension_class_property"u8);
        s_classdbRegisterExtensionClassSignal = (GDExtensionInterfaceClassdbRegisterExtensionClassSignal)Load("classdb_register_extension_class_signal"u8);
        s_getVariantFromTypeConstructor = (GDExtensionInterfaceGetVariantFromTypeConstructor)Load("get_variant_from_type_constructor"u8);
        s_getVariantToTypeConstructor = (GDExtensionInterfaceGetVariantToTypeConstructor)Load("get_variant_to_type_constructor"u8);
        s_objectMethodBindCall = (GDExtensionInterfaceObjectMethodBindCall)Load("object_method_bind_call"u8);
        s_objectMethodBindPtrcall = (GDExtensionInterfaceObjectMethodBindPtrcall)Load("object_method_bind_ptrcall"u8);
        s_objectSetInstance = (GDExtensionInterfaceObjectSetInstance)Load("object_set_instance"u8);
        s_objectSetInstanceBinding = (GDExtensionInterfaceObjectSetInstanceBinding)Load("object_set_instance_binding"u8);
        s_stringNewWithUtf8CharsAndLen = (GDExtensionInterfaceStringNewWithUtf8CharsAndLen)Load("string_new_with_utf8_chars_and_len"u8);
        s_stringNameNewWithUtf8CharsAndLen = (GDExtensionInterfaceStringNameNewWithUtf8CharsAndLen)Load("string_name_new_with_utf8_chars_and_len"u8);
        s_variantDestroy = (GDExtensionInterfaceVariantDestroy)Load("variant_destroy"u8);
        s_variantGetPtrDestructor = (GDExtensionInterfaceVariantGetPtrDestructor)Load("variant_get_ptr_destructor"u8);
        s_variantGetPtrOperatorEvaluator = (GDExtensionInterfaceVariantGetPtrOperatorEvaluator)Load("variant_get_ptr_operator_evaluator"u8);
        s_variantGetType = (GDExtensionInterfaceVariantGetType)Load("variant_get_type"u8);
        initialization->minimum_initialization_level = GDEXTENSION_INITIALIZATION_SCENE;
        initialization->userdata = library.Pointer;
        initialization->initialize = new GDExtensionInitializeCallback(&InitializeLevel);
        initialization->deinitialize = new GDExtensionDeinitializeCallback(&DeinitializeLevel);
        return new GDExtensionBool(true);

        GDExtensionInterfaceFunctionPtr Load(ReadOnlySpan<byte> functionName)
        {
            fixed (byte* reference = functionName)
            {
                return getProcAddress.Invoke(reference);
            }
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void InitializeLevel(void* token, GDExtensionInitializationLevel level)
    {
        if (level != GDEXTENSION_INITIALIZATION_SCENE)
        {
            return;
        }

        VariantBridge.Initialize();
        StringBridge.Initialize();
        StringNameBridge.Initialize();
        ObjectBridge.Initialize();
        Sprite2DBridge.Initialize();
        GDExampleBridge.RegisterClass(new GDExtensionClassLibraryPtr(token));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DeinitializeLevel(void* token, GDExtensionInitializationLevel level)
    {
    }
}
