using System;
using System.Numerics;
using Godot.GDExtension;

namespace Godot.Tests;

public static unsafe class GDExtensionClassDB
{
    private const uint PropertyUsageStorage = 2;
    private const uint PropertyUsageEditor = 4;
    private const uint PropertyUsageDefault = PropertyUsageStorage | PropertyUsageEditor;

    public static void RegisterClass(GDExtensionClassLibraryPtr library,
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
            ClassUserdata = library.Pointer,
            CreateInstanceFunc = new GDExtensionClassCreateInstance(createInstanceFunc),
            FreeInstanceFunc = new GDExtensionClassFreeInstance(freeInstanceFunc),
            GetVirtualFunc = new GDExtensionClassGetVirtual(getVirtualFunc)
        };
        GDExtensionInterface.ClassdbRegisterExtensionClass.Invoke(library,
                                                                  new GDExtensionConstStringNamePtr(&classStringName),
                                                                  new GDExtensionConstStringNamePtr(&parentClassStringName),
                                                                  &classInfo);
    }

    public static void RegisterPropertyGetter(GDExtensionClassLibraryPtr library,
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
            Name = new GDExtensionStringNamePtr(&emptyStringName),
            Type = type,
            HintString = new GDExtensionStringPtr(&emptyString),
            ClassName = new GDExtensionStringNamePtr(&emptyStringName),
            Usage = PropertyUsageDefault
        };
        GDExtensionClassMethodInfo methodInfo = new GDExtensionClassMethodInfo
        {
            Name = new GDExtensionStringNamePtr(&methodStringName),
            CallFunc = new GDExtensionClassMethodCall(callFunc),
            PtrcallFunc = new GDExtensionClassMethodPtrCall(ptrcallFunc),
            MethodFlags = (uint)GDExtensionMethodFlagsDefault,
            HasReturnValue = new GDExtensionBool(true),
            ReturnValueInfo = &returnInfo
        };
        GDExtensionInterface.ClassdbRegisterExtensionClassMethod.Invoke(library,
                                                                        new GDExtensionConstStringNamePtr(&classStringName),
                                                                        &methodInfo);
    }

    public static void RegisterPropertySetter(GDExtensionClassLibraryPtr library,
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
            Name = new GDExtensionStringNamePtr(&argumentStringName),
            Type = type,
            HintString = new GDExtensionStringPtr(&emptyString),
            ClassName = new GDExtensionStringNamePtr(&emptyStringName),
            Usage = PropertyUsageDefault
        };
        GDExtensionClassMethodArgumentMetadata argsMetadata = GDExtensionMethodArgumentMetadataNone;
        GDExtensionClassMethodInfo methodInfo = new GDExtensionClassMethodInfo
        {
            Name = new GDExtensionStringNamePtr(&methodStringName),
            CallFunc = new GDExtensionClassMethodCall(callFunc),
            PtrcallFunc = new GDExtensionClassMethodPtrCall(ptrcallFunc),
            MethodFlags = (uint)GDExtensionMethodFlagsDefault,
            ArgumentCount = 1,
            ArgumentsInfo = &argumentInfo,
            ArgumentsMetadata = &argsMetadata,
        };
        GDExtensionInterface.ClassdbRegisterExtensionClassMethod.Invoke(library,
                                                                        new GDExtensionConstStringNamePtr(&classStringName),
                                                                        &methodInfo);
    }

    public static void RegisterProperty(GDExtensionClassLibraryPtr library,
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
            Name = new GDExtensionStringNamePtr(&propertyStringName),
            Type = type,
            HintString = new GDExtensionStringPtr(&emptyString),
            ClassName = new GDExtensionStringNamePtr(&emptyStringName),
            Usage = PropertyUsageDefault
        };
        GDExtensionInterface.ClassdbRegisterExtensionClassProperty.Invoke(library,
                                                                          new GDExtensionConstStringNamePtr(&classStringName),
                                                                          &info,
                                                                          new GDExtensionConstStringNamePtr(&propertySetterStringName),
                                                                          new GDExtensionConstStringNamePtr(&propertyGetterStringName));
    }

    public static void RegisterSignal(GDExtensionClassLibraryPtr library,
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
            Name = new GDExtensionStringNamePtr(&argumentStringName),
            Type = argumentType,
            HintString = new GDExtensionStringPtr(&emptyString),
            ClassName = new GDExtensionStringNamePtr(&emptyStringName),
            Usage = PropertyUsageDefault
        };
        GDExtensionInterface.ClassdbRegisterExtensionClassSignal.Invoke(library,
                                                                        new GDExtensionConstStringNamePtr(&classStringName),
                                                                        new GDExtensionConstStringNamePtr(&signalStringName),
                                                                        &argumentInfo,
                                                                        new GDExtensionInt(1));
    }

    public static void EmitSignal(GDExtensionObjectPtr instance, StringName argument1, Vector2 argument2)
    {
        using StringName classStringName = new StringName("Object"u8);
        using StringName methodStringName = new StringName("emit_signal"u8);
        GDExtensionMethodBindPtr methodBind = GDExtensionInterface.ClassdbGetMethodBind.Invoke(new GDExtensionConstStringNamePtr(&classStringName),
                                                                                               new GDExtensionConstStringNamePtr(&methodStringName),
                                                                                               new GDExtensionInt(4047867050));
        using Variant variantArgument1 = new Variant(argument1);
        using Variant variantArgument2 = new Variant(argument2);
        using Variant variantResult = default;
        GDExtensionConstVariantPtr* arguments = stackalloc GDExtensionConstVariantPtr[]
        {
            new GDExtensionConstVariantPtr(&variantArgument1),
            new GDExtensionConstVariantPtr(&variantArgument2),
        };
        GDExtensionUninitializedVariantPtr result = new GDExtensionUninitializedVariantPtr(&variantResult);
        GDExtensionInterface.ObjectMethodBindCall.Invoke(methodBind, instance, arguments, new GDExtensionInt(2), result, null);
    }

    public static void SetPosition(GDExtensionObjectPtr obj, Vector2 value)
    {
        using StringName classStringName = new StringName("Node2D"u8);
        using StringName methodStringName = new StringName("set_position"u8);
        GDExtensionMethodBindPtr method = GDExtensionInterface.ClassdbGetMethodBind.Invoke(new GDExtensionConstStringNamePtr(&classStringName),
                                                                                           new GDExtensionConstStringNamePtr(&methodStringName),
                                                                                           new GDExtensionInt(743155724));
        GDExtensionConstTypePtr argument = new GDExtensionConstTypePtr(&value);
        GDExtensionInterface.ObjectMethodBindPtrcall.Invoke(method, obj, &argument, default);
    }
}
