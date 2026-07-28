using System;
using Godot.Interop;

namespace Godot.Tests;

public static unsafe class GDExtensionClassDB
{
    private const uint PropertyUsageStorage = 2;
    private const uint PropertyUsageEditor = 4;
    private const uint PropertyUsageDefault = PropertyUsageStorage | PropertyUsageEditor;

    public static void RegisterClass(
        void* pLibrary,
        ReadOnlySpan<byte> pClassName,
        ReadOnlySpan<byte> pParentClassName,
        delegate* unmanaged[Cdecl]<void*, void*> pCreateInstanceFunc,
        delegate* unmanaged[Cdecl]<void*, void*, void> pFreeInstanceFunc,
        delegate* unmanaged[Cdecl]<void*, GDExtensionStringName*, delegate* unmanaged[Cdecl]<void*, void**, void*, void>> pGetVirtualFunc)
    {
        using StringName classStringName = new StringName(pClassName);
        using StringName parentClassStringName = new StringName(pParentClassName);
        GDExtensionClassCreationInfo classInfo = new GDExtensionClassCreationInfo
        {
            ClassUserData = pLibrary,
            CreateInstanceFunc = pCreateInstanceFunc,
            FreeInstanceFunc = pFreeInstanceFunc,
            GetVirtualFunc = pGetVirtualFunc
        };
        GDExtensionInterface.ClassDBRegisterExtensionClass(
            pLibrary,
            (GDExtensionStringName*)&classStringName,
            (GDExtensionStringName*)&parentClassStringName,
            &classInfo);
    }

    public static void RegisterPropertyGetter(
        void* pLibrary,
        ReadOnlySpan<byte> pClassName,
        ReadOnlySpan<byte> pMethodName,
        delegate* unmanaged[Cdecl]<void*, void*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> pCallFunc,
        delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void> pPtrCallFunc,
        GDExtensionVariantType type)
    {
        using StringName classStringName = new StringName(pClassName);
        using StringName methodStringName = new StringName(pMethodName);
        using StringName emptyStringName = new StringName(default);
        using String emptyString = new String(default);
        GDExtensionPropertyInfo returnInfo = new GDExtensionPropertyInfo
        {
            Name = (GDExtensionStringName*)&emptyStringName,
            Type = type,
            HintString = (GDExtensionString*)&emptyString,
            ClassName = (GDExtensionStringName*)&emptyStringName,
            Usage = PropertyUsageDefault
        };
        GDExtensionClassMethodInfo methodInfo = new GDExtensionClassMethodInfo
        {
            Name = (GDExtensionStringName*)&methodStringName,
            CallFunc = pCallFunc,
            PtrCallFunc = pPtrCallFunc,
            MethodFlags = GDExtensionClassMethodFlags.Default,
            HasReturnValue = true,
            ReturnValueInfo = &returnInfo
        };
        GDExtensionInterface.ClassDBRegisterExtensionClassMethod(
            pLibrary,
            (GDExtensionStringName*)&classStringName,
            &methodInfo);
    }

    public static void RegisterPropertySetter(
        void* pLibrary,
        ReadOnlySpan<byte> pClassName,
        ReadOnlySpan<byte> pMethodName,
        delegate* unmanaged[Cdecl]<void*, void*, GDExtensionVariant**, long, GDExtensionVariant*, GDExtensionCallError*, void> pCallFunc,
        delegate* unmanaged[Cdecl]<void*, void*, void**, void*, void> pPtrCallFunc,
        GDExtensionVariantType type)
    {
        using StringName classStringName = new StringName(pClassName);
        using StringName methodStringName = new StringName(pMethodName);
        using StringName argumentStringName = new StringName("value"u8);
        using StringName emptyStringName = new StringName(default);
        using String emptyString = new String(default);
        GDExtensionPropertyInfo argumentInfo = new GDExtensionPropertyInfo
        {
            Name = (GDExtensionStringName*)(&argumentStringName),
            Type = type,
            HintString = (GDExtensionString*)(&emptyString),
            ClassName = (GDExtensionStringName*)(&emptyStringName),
            Usage = PropertyUsageDefault
        };
        GDExtensionClassMethodArgumentMetadata argsMetadata = GDExtensionClassMethodArgumentMetadata.None;
        GDExtensionClassMethodInfo methodInfo = new GDExtensionClassMethodInfo
        {
            Name = (GDExtensionStringName*)(&methodStringName),
            CallFunc = pCallFunc,
            PtrCallFunc = pPtrCallFunc,
            MethodFlags = GDExtensionClassMethodFlags.Default,
            ArgumentCount = 1,
            ArgumentsInfo = &argumentInfo,
            ArgumentsMetadata = &argsMetadata,
        };
        GDExtensionInterface.ClassDBRegisterExtensionClassMethod(
            pLibrary,
            (GDExtensionStringName*)(&classStringName),
            &methodInfo);
    }

    public static void RegisterProperty(
        void* pLibrary,
        ReadOnlySpan<byte> pClassName,
        ReadOnlySpan<byte> propertyName,
        ReadOnlySpan<byte> propertyGetterName,
        ReadOnlySpan<byte> propertySetterName,
        GDExtensionVariantType type)
    {
        using StringName classStringName = new StringName(pClassName);
        using StringName propertyStringName = new StringName(propertyName);
        using StringName propertyGetterStringName = new StringName(propertyGetterName);
        using StringName propertySetterStringName = new StringName(propertySetterName);
        using StringName emptyStringName = new StringName(default);
        using String emptyString = new String(default);
        GDExtensionPropertyInfo info = new GDExtensionPropertyInfo
        {
            Name = (GDExtensionStringName*)&propertyStringName,
            Type = type,
            HintString = (GDExtensionString*)&emptyString,
            ClassName = (GDExtensionStringName*)&emptyStringName,
            Usage = PropertyUsageDefault
        };
        GDExtensionInterface.ClassDBRegisterExtensionClassProperty(
            pLibrary,
            (GDExtensionStringName*)(&classStringName),
            &info,
            (GDExtensionStringName*)&propertySetterStringName,
            (GDExtensionStringName*)&propertyGetterStringName);
    }

    public static void RegisterSignal(
        void* pLibrary,
        ReadOnlySpan<byte> pClassName,
        ReadOnlySpan<byte> pSignalName,
        ReadOnlySpan<byte> pArgumentName,
        GDExtensionVariantType pArgumentType)
    {
        using StringName classStringName = new StringName(pClassName);
        using StringName signalStringName = new StringName(pSignalName);
        using StringName argumentStringName = new StringName(pArgumentName);
        using StringName emptyStringName = new StringName(default);
        using String emptyString = new String(default);
        GDExtensionPropertyInfo argumentInfo = new GDExtensionPropertyInfo
        {
            Name = (GDExtensionStringName*)&argumentStringName,
            Type = pArgumentType,
            HintString = (GDExtensionString*)&emptyString,
            ClassName = (GDExtensionStringName*)&emptyStringName,
            Usage = PropertyUsageDefault
        };
        GDExtensionInterface.ClassDBRegisterExtensionClassSignal(
            pLibrary,
            (GDExtensionStringName*)&classStringName,
            (GDExtensionStringName*)&signalStringName,
            &argumentInfo,
            1);
    }
}
