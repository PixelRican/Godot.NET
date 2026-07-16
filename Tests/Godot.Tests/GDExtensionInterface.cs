using System;
using System.Text;
using Godot.GDExtension;

namespace Godot.Tests;

public sealed unsafe class GDExtensionInterface
{
    public GDExtensionInterface(GDExtensionInterfaceGetProcAddress getProcAddress)
    {
        ArgumentNullException.ThrowIfNull(getProcAddress.Method, nameof(getProcAddress));
        ClassdbConstructObject = (GDExtensionInterfaceClassdbConstructObject)Load(getProcAddress, "classdb_construct_object"u8);
        ClassdbGetMethodBind = (GDExtensionInterfaceClassdbGetMethodBind)Load(getProcAddress, "classdb_get_method_bind"u8);
        ClassdbRegisterExtensionClass = (GDExtensionInterfaceClassdbRegisterExtensionClass)Load(getProcAddress, "classdb_register_extension_class"u8);
        ClassdbRegisterExtensionClassMethod = (GDExtensionInterfaceClassdbRegisterExtensionClassMethod)Load(getProcAddress, "classdb_register_extension_class_method"u8);
        ClassdbRegisterExtensionClassProperty = (GDExtensionInterfaceClassdbRegisterExtensionClassProperty)Load(getProcAddress, "classdb_register_extension_class_property"u8);
        ClassdbRegisterExtensionClassSignal = (GDExtensionInterfaceClassdbRegisterExtensionClassSignal)Load(getProcAddress, "classdb_register_extension_class_signal"u8);
        GetVariantFromTypeConstructor = (GDExtensionInterfaceGetVariantFromTypeConstructor)Load(getProcAddress, "get_variant_from_type_constructor"u8);
        GetVariantToTypeConstructor = (GDExtensionInterfaceGetVariantToTypeConstructor)Load(getProcAddress, "get_variant_to_type_constructor"u8);
        ObjectMethodBindCall = (GDExtensionInterfaceObjectMethodBindCall)Load(getProcAddress, "object_method_bind_call"u8);
        ObjectMethodBindPtrcall = (GDExtensionInterfaceObjectMethodBindPtrcall)Load(getProcAddress, "object_method_bind_ptrcall"u8);
        ObjectSetInstance = (GDExtensionInterfaceObjectSetInstance)Load(getProcAddress, "object_set_instance"u8);
        ObjectSetInstanceBinding = (GDExtensionInterfaceObjectSetInstanceBinding)Load(getProcAddress, "object_set_instance_binding"u8);
        StringNewWithUtf8CharsAndLen = (GDExtensionInterfaceStringNewWithUtf8CharsAndLen)Load(getProcAddress, "string_new_with_utf8_chars_and_len"u8);
        StringNameNewWithUtf8CharsAndLen = (GDExtensionInterfaceStringNameNewWithUtf8CharsAndLen)Load(getProcAddress, "string_name_new_with_utf8_chars_and_len"u8);
        VariantDestroy = (GDExtensionInterfaceVariantDestroy)Load(getProcAddress, "variant_destroy"u8);
        VariantGetPtrDestructor = (GDExtensionInterfaceVariantGetPtrDestructor)Load(getProcAddress, "variant_get_ptr_destructor"u8);
        VariantGetPtrOperatorEvaluator = (GDExtensionInterfaceVariantGetPtrOperatorEvaluator)Load(getProcAddress, "variant_get_ptr_operator_evaluator"u8);
        VariantGetType = (GDExtensionInterfaceVariantGetType)Load(getProcAddress, "variant_get_type"u8);
    }

    public GDExtensionInterfaceClassdbConstructObject ClassdbConstructObject { get; }

    public GDExtensionInterfaceClassdbGetMethodBind ClassdbGetMethodBind { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClass ClassdbRegisterExtensionClass { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClassMethod ClassdbRegisterExtensionClassMethod { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClassProperty ClassdbRegisterExtensionClassProperty { get; }

    public GDExtensionInterfaceClassdbRegisterExtensionClassSignal ClassdbRegisterExtensionClassSignal { get; }

    public GDExtensionInterfaceGetVariantFromTypeConstructor GetVariantFromTypeConstructor { get; }

    public GDExtensionInterfaceGetVariantToTypeConstructor GetVariantToTypeConstructor { get; }

    public GDExtensionInterfaceObjectMethodBindCall ObjectMethodBindCall { get; }

    public GDExtensionInterfaceObjectMethodBindPtrcall ObjectMethodBindPtrcall { get; }

    public GDExtensionInterfaceObjectSetInstance ObjectSetInstance { get; }

    public GDExtensionInterfaceObjectSetInstanceBinding ObjectSetInstanceBinding { get; }

    public GDExtensionInterfaceStringNewWithUtf8CharsAndLen StringNewWithUtf8CharsAndLen { get; }

    public GDExtensionInterfaceStringNameNewWithUtf8CharsAndLen StringNameNewWithUtf8CharsAndLen { get; }

    public GDExtensionInterfaceVariantDestroy VariantDestroy { get; }

    public GDExtensionInterfaceVariantGetPtrDestructor VariantGetPtrDestructor { get; }

    public GDExtensionInterfaceVariantGetPtrOperatorEvaluator VariantGetPtrOperatorEvaluator { get; }

    public GDExtensionInterfaceVariantGetType VariantGetType { get; }

    private static GDExtensionInterfaceFunctionPtr Load(GDExtensionInterfaceGetProcAddress getProcAddress, ReadOnlySpan<byte> functionName)
    {
        GDExtensionInterfaceFunctionPtr function;

        fixed (byte* p_function_name = functionName)
        {
            function = getProcAddress.Invoke(p_function_name);
        }

        if (function.Method == null)
        {
            throw new ArgumentException($"Could not load \"{Encoding.UTF8.GetString(functionName)}\" from the specified function.");
        }

        return function;
    }
}
