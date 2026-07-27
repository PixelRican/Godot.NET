using System;
using Godot.Interop;

namespace Godot.Tests;

public static unsafe class GDExtensionClassDB
{
    private const uint PropertyUsageStorage = 2;
    private const uint PropertyUsageEditor = 4;
    private const uint PropertyUsageDefault = PropertyUsageStorage | PropertyUsageEditor;

    public static void RegisterClass(
        GDExtensionClassLibraryPtr library,
        ReadOnlySpan<byte> className,
        ReadOnlySpan<byte> parentClassName,
        delegate* unmanaged[Cdecl]<void*, GDExtensionObjectPtr> createInstanceFunc,
        delegate* unmanaged[Cdecl]<void*, GDExtensionClassInstancePtr, void> freeInstanceFunc,
        delegate* unmanaged[Cdecl]<void*, GDExtensionConstStringNamePtr, GDExtensionClassCallVirtual> getVirtualFunc)
    {
        using StringName classStringName = new StringName(className);
        using StringName parentClassStringName = new StringName(parentClassName);
        GDExtensionClassCreationInfo classInfo = new GDExtensionClassCreationInfo
        {
            class_userdata = library.Pointer,
            create_instance_func = new GDExtensionClassCreateInstance(createInstanceFunc),
            free_instance_func = new GDExtensionClassFreeInstance(freeInstanceFunc),
            get_virtual_func = new GDExtensionClassGetVirtual(getVirtualFunc)
        };
        GodotBridge.GDExtensionInterface.ClassdbRegisterExtensionClass.Invoke(
            library,
            new GDExtensionConstStringNamePtr(&classStringName),
            new GDExtensionConstStringNamePtr(&parentClassStringName),
            &classInfo);
    }

    public static void RegisterPropertyGetter(
        GDExtensionClassLibraryPtr library,
        ReadOnlySpan<byte> className,
        ReadOnlySpan<byte> methodName,
        delegate* unmanaged[Cdecl]<void*, GDExtensionClassInstancePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionVariantPtr, GDExtensionCallError*, void> callFunc,
        delegate* unmanaged[Cdecl]<void*, GDExtensionClassInstancePtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void> ptrcallFunc,
        GDExtensionVariantType type)
    {
        using StringName classStringName = new StringName(className);
        using StringName methodStringName = new StringName(methodName);
        using StringName emptyStringName = new StringName(default);
        using String emptyString = new String(default);
        GDExtensionPropertyInfo returnInfo = new GDExtensionPropertyInfo
        {
            name = new GDExtensionStringNamePtr(&emptyStringName),
            type = type,
            hint_string = new GDExtensionStringPtr(&emptyString),
            class_name = new GDExtensionStringNamePtr(&emptyStringName),
            usage = PropertyUsageDefault
        };
        GDExtensionClassMethodInfo methodInfo = new GDExtensionClassMethodInfo
        {
            name = new GDExtensionStringNamePtr(&methodStringName),
            call_func = new GDExtensionClassMethodCall(callFunc),
            ptrcall_func = new GDExtensionClassMethodPtrCall(ptrcallFunc),
            method_flags = (uint)GDEXTENSION_METHOD_FLAGS_DEFAULT,
            has_return_value = new GDExtensionBool(true),
            return_value_info = &returnInfo
        };
        GodotBridge.GDExtensionInterface.ClassdbRegisterExtensionClassMethod.Invoke(
            library,
            new GDExtensionConstStringNamePtr(&classStringName),
            &methodInfo);
    }

    public static void RegisterPropertySetter(
        GDExtensionClassLibraryPtr library,
        ReadOnlySpan<byte> className,
        ReadOnlySpan<byte> methodName,
        delegate* unmanaged[Cdecl]<void*, GDExtensionClassInstancePtr, GDExtensionConstVariantPtr*, GDExtensionInt, GDExtensionVariantPtr, GDExtensionCallError*, void> callFunc,
        delegate* unmanaged[Cdecl]<void*, GDExtensionClassInstancePtr, GDExtensionConstTypePtr*, GDExtensionTypePtr, void> ptrcallFunc,
        GDExtensionVariantType type)
    {
        using StringName classStringName = new StringName(className);
        using StringName methodStringName = new StringName(methodName);
        using StringName argumentStringName = new StringName("value"u8);
        using StringName emptyStringName = new StringName(default);
        using String emptyString = new String(default);
        GDExtensionPropertyInfo argumentInfo = new GDExtensionPropertyInfo
        {
            name = new GDExtensionStringNamePtr(&argumentStringName),
            type = type,
            hint_string = new GDExtensionStringPtr(&emptyString),
            class_name = new GDExtensionStringNamePtr(&emptyStringName),
            usage = PropertyUsageDefault
        };
        GDExtensionClassMethodArgumentMetadata argsMetadata = GDEXTENSION_METHOD_ARGUMENT_METADATA_NONE;
        GDExtensionClassMethodInfo methodInfo = new GDExtensionClassMethodInfo
        {
            name = new GDExtensionStringNamePtr(&methodStringName),
            call_func = new GDExtensionClassMethodCall(callFunc),
            ptrcall_func = new GDExtensionClassMethodPtrCall(ptrcallFunc),
            method_flags = (uint)GDEXTENSION_METHOD_FLAGS_DEFAULT,
            argument_count = 1,
            arguments_info = &argumentInfo,
            arguments_metadata = &argsMetadata,
        };
        GodotBridge.GDExtensionInterface.ClassdbRegisterExtensionClassMethod.Invoke(
            library,
            new GDExtensionConstStringNamePtr(&classStringName),
            &methodInfo);
    }

    public static void RegisterProperty(
        GDExtensionClassLibraryPtr library,
        ReadOnlySpan<byte> className,
        ReadOnlySpan<byte> propertyName,
        ReadOnlySpan<byte> propertyGetterName,
        ReadOnlySpan<byte> propertySetterName,
        GDExtensionVariantType type)
    {
        using StringName classStringName = new StringName(className);
        using StringName propertyStringName = new StringName(propertyName);
        using StringName propertyGetterStringName = new StringName(propertyGetterName);
        using StringName propertySetterStringName = new StringName(propertySetterName);
        using StringName emptyStringName = new StringName(default);
        using String emptyString = new String(default);
        GDExtensionPropertyInfo info = new GDExtensionPropertyInfo
        {
            name = new GDExtensionStringNamePtr(&propertyStringName),
            type = type,
            hint_string = new GDExtensionStringPtr(&emptyString),
            class_name = new GDExtensionStringNamePtr(&emptyStringName),
            usage = PropertyUsageDefault
        };
        GodotBridge.GDExtensionInterface.ClassdbRegisterExtensionClassProperty.Invoke(
            library,
            new GDExtensionConstStringNamePtr(&classStringName),
            &info,
            new GDExtensionConstStringNamePtr(&propertySetterStringName),
            new GDExtensionConstStringNamePtr(&propertyGetterStringName));
    }

    public static void RegisterSignal(
        GDExtensionClassLibraryPtr library,
        ReadOnlySpan<byte> className,
        ReadOnlySpan<byte> signalName,
        ReadOnlySpan<byte> argumentName,
        GDExtensionVariantType argumentType)
    {
        using StringName classStringName = new StringName(className);
        using StringName signalStringName = new StringName(signalName);
        using StringName argumentStringName = new StringName(argumentName);
        using StringName emptyStringName = new StringName(default);
        using String emptyString = new String(default);
        GDExtensionPropertyInfo argumentInfo = new GDExtensionPropertyInfo
        {
            name = new GDExtensionStringNamePtr(&argumentStringName),
            type = argumentType,
            hint_string = new GDExtensionStringPtr(&emptyString),
            class_name = new GDExtensionStringNamePtr(&emptyStringName),
            usage = PropertyUsageDefault
        };
        GodotBridge.GDExtensionInterface.ClassdbRegisterExtensionClassSignal.Invoke(
            library,
            new GDExtensionConstStringNamePtr(&classStringName),
            new GDExtensionConstStringNamePtr(&signalStringName),
            &argumentInfo,
            new GDExtensionInt(1));
    }
}
