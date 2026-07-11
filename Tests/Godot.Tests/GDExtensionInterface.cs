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
        Load("classdb_construct_object"u8, out s_classdbConstructObject);
        Load("classdb_get_method_bind"u8, out s_classdbGetMethodBind);
        Load("classdb_register_extension_class"u8, out s_classdbRegisterExtensionClass);
        Load("classdb_register_extension_class_method"u8, out s_classdbRegisterExtensionClassMethod);
        Load("classdb_register_extension_class_property"u8, out s_classdbRegisterExtensionClassProperty);
        Load("classdb_register_extension_class_signal"u8, out s_classdbRegisterExtensionClassSignal);
        Load("get_variant_from_type_constructor"u8, out s_getVariantFromTypeConstructor);
        Load("get_variant_to_type_constructor"u8, out s_getVariantToTypeConstructor);
        Load("object_method_bind_call"u8, out s_objectMethodBindCall);
        Load("object_method_bind_ptrcall"u8, out s_objectMethodBindPtrcall);
        Load("object_set_instance"u8, out s_objectSetInstance);
        Load("object_set_instance_binding"u8, out s_objectSetInstanceBinding);
        Load("string_new_with_utf8_chars_and_len"u8, out s_stringNewWithUtf8CharsAndLen);
        Load("string_name_new_with_utf8_chars_and_len"u8, out s_stringNameNewWithUtf8CharsAndLen);
        Load("variant_destroy"u8, out s_variantDestroy);
        Load("variant_get_ptr_destructor"u8, out s_variantGetPtrDestructor);
        Load("variant_get_ptr_operator_evaluator"u8, out s_variantGetPtrOperatorEvaluator);
        Load("variant_get_type"u8, out s_variantGetType);
        initialization->MinimumInitializationLevel = GDExtensionInitializationScene;
        initialization->Userdata = library.Pointer;
        initialization->Initialize = new GDExtensionInitializeCallback(&InitializeLevel);
        initialization->Deinitialize = new GDExtensionDeinitializeCallback(&DeinitializeLevel);
        return new GDExtensionBool(true);

        void Load<TFunction>(ReadOnlySpan<byte> name, out TFunction result) where TFunction : unmanaged
        {
            fixed (byte* reference = name)
            {
                result = Unsafe.BitCast<GDExtensionInterfaceFunctionPtr, TFunction>(getProcAddress.Invoke(reference));
            }
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void InitializeLevel(void* token, GDExtensionInitializationLevel level)
    {
        if (level != GDExtensionInitializationScene)
        {
            return;
        }

        VariantBridge.Initialize();
        StringNameBridge.Initialize();
        GDExampleBridge.RegisterClass(new GDExtensionClassLibraryPtr(token));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DeinitializeLevel(void* token, GDExtensionInitializationLevel level)
    {
    }
}
