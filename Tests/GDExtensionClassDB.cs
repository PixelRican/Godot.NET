using System;

namespace Godot.NET.Tests;

public static unsafe class GDExtensionClassDB
{
    private const uint PropertyUsageStorage = 2;
    private const uint PropertyUsageEditor = 4;
    private const uint PropertyUsageDefault = PropertyUsageStorage | PropertyUsageEditor;

    public static GDExtensionObjectPtr ConstructObject(ReadOnlySpan<byte> className)
    {
        using GDStringName classStringName = new GDStringName(className);
        return GDExtensionInterface.ClassdbConstructObject(new GDExtensionConstStringNamePtr(&classStringName));
    }

    public static void RegisterClass(GDExtensionClassLibraryPtr library,
                                     ReadOnlySpan<byte> className,
                                     ReadOnlySpan<byte> parentClassName,
                                     GDExtensionClassCreateInstance createCallback,
                                     GDExtensionClassFreeInstance freeCallback)
    {
        using GDStringName classStringName = new GDStringName(className);
        using GDStringName parentClassStringName = new GDStringName(parentClassName);
        GDExtensionClassCreationInfo classInfo = new GDExtensionClassCreationInfo
        {
            ClassUserdata = library.Pointer,
            CreateInstanceFunc = createCallback,
            FreeInstanceFunc = freeCallback,
        };
        GDExtensionInterface.ClassdbRegisterExtensionClass(library,
            new GDExtensionConstStringNamePtr(&classStringName),
            new GDExtensionConstStringNamePtr(&parentClassStringName),
            &classInfo);
    }

    public static void RegisterPropertyGetter(GDExtensionClassLibraryPtr library,
                                              ReadOnlySpan<byte> className,
                                              ReadOnlySpan<byte> methodName,
                                              GDExtensionClassMethodCall methodCall,
                                              GDExtensionClassMethodPtrCall methodPtrcall,
                                              GDExtensionVariantType type)
    {
        using GDStringName classStringName = new GDStringName(className);
        using GDStringName methodStringName = new GDStringName(methodName);
        using GDStringName emptyStringName = new GDStringName(default);
        using GDString emptyString = new GDString(default);
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
            CallFunc = methodCall,
            PtrcallFunc = methodPtrcall,
            MethodFlags = (uint)GDExtensionMethodFlagsDefault,
            HasReturnValue = new GDExtensionBool(true),
            ReturnValueInfo = &returnInfo
        };
        GDExtensionInterface.ClassdbRegisterExtensionClassMethod(library,
                                                                 new GDExtensionConstStringNamePtr(&classStringName),
                                                                 &methodInfo);
    }

    public static void RegisterPropertySetter(GDExtensionClassLibraryPtr library,
                                              ReadOnlySpan<byte> className,
                                              ReadOnlySpan<byte> methodName,
                                              GDExtensionClassMethodCall methodCall,
                                              GDExtensionClassMethodPtrCall methodPtrcall,
                                              GDExtensionVariantType type)
    {
        using GDStringName classNameString = new GDStringName(className);
        using GDStringName methodNameString = new GDStringName(methodName);
        using GDStringName argumentName = new GDStringName("value"u8);
        using GDStringName emptyStringName = new GDStringName(default);
        using GDString emptyString = new GDString(default);
        GDExtensionPropertyInfo argumentInfo = new GDExtensionPropertyInfo
        {
            Name = new GDExtensionStringNamePtr(&argumentName),
            Type = type,
            HintString = new GDExtensionStringPtr(&emptyString),
            ClassName = new GDExtensionStringNamePtr(&emptyStringName),
            Usage = PropertyUsageDefault
        };
        GDExtensionClassMethodArgumentMetadata argsMetadata = GDExtensionMethodArgumentMetadataNone;
        GDExtensionClassMethodInfo methodInfo = new GDExtensionClassMethodInfo
        {
            Name = new GDExtensionStringNamePtr(&methodNameString),
            CallFunc = methodCall,
            PtrcallFunc = methodPtrcall,
            MethodFlags = (uint)GDExtensionMethodFlagsDefault,
            ArgumentCount = 1,
            ArgumentsInfo = &argumentInfo,
            ArgumentsMetadata = &argsMetadata,
        };
        GDExtensionInterface.ClassdbRegisterExtensionClassMethod(library,
                                                                 new GDExtensionConstStringNamePtr(&classNameString),
                                                                 &methodInfo);
    }

    public static void RegisterProperty(GDExtensionClassLibraryPtr library,
                                        ReadOnlySpan<byte> className,
                                        ReadOnlySpan<byte> propertyName,
                                        GDExtensionVariantType type,
                                        ReadOnlySpan<byte> propertyGetterName,
                                        ReadOnlySpan<byte> propertySetterName)
    {
        using GDStringName classStringName = new GDStringName(className);
        using GDStringName propertyStringName = new GDStringName(propertyName);
        using GDStringName propertyGetterStringName = new GDStringName(propertyGetterName);
        using GDStringName propertySetterStringName = new GDStringName(propertySetterName);
        using GDStringName emptyStringName = new GDStringName(default);
        using GDString emptyString = new GDString(default);
        GDExtensionPropertyInfo info = new GDExtensionPropertyInfo
        {
            Name = new GDExtensionStringNamePtr(&propertyStringName),
            Type = type,
            HintString = new GDExtensionStringPtr(&emptyString),
            ClassName = new GDExtensionStringNamePtr(&emptyStringName),
            Usage = PropertyUsageDefault
        };
        GDExtensionInterface.ClassdbRegisterExtensionClassProperty(library,
                                                                   new GDExtensionConstStringNamePtr(&classStringName),
                                                                   &info,
                                                                   new GDExtensionConstStringNamePtr(&propertySetterStringName),
                                                                   new GDExtensionConstStringNamePtr(&propertyGetterStringName));
    }
}
