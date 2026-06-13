using System;

namespace Godot.NET.Tests;

public static unsafe class GDExtensionClassDB
{
    private const uint PropertyUsageStorage = 2;
    private const uint PropertyUsageEditor = 4;
    private const uint PropertyUsageDefault = PropertyUsageStorage | PropertyUsageEditor;

    public static GDExtensionObjectPtr ConstructObject(ReadOnlySpan<byte> className)
    {
        nint classStringName = ConstructStringName(className);
        GDExtensionConstStringNamePtr classStringNamePointer = new GDExtensionConstStringNamePtr(&classStringName);
        GDExtensionObjectPtr result = GDExtensionInterface.ClassdbConstructObject(classStringNamePointer);
        DestructStringName(classStringName);
        return result;
    }

    public static nint ConstructString(ReadOnlySpan<byte> contents)
    {
        nint pointer;
        GDExtensionUninitializedStringPtr destination = new GDExtensionUninitializedStringPtr(&pointer);
        GDExtensionInt size = new GDExtensionInt(contents.Length);

        fixed (byte* reference = contents)
        {
            GDExtensionInterface.StringNewWithUtf8CharsAndLen(destination, reference, size);
        }

        return pointer;
    }

    public static nint ConstructStringName(ReadOnlySpan<byte> contents)
    {
        nint pointer;
        GDExtensionUninitializedStringNamePtr destination = new GDExtensionUninitializedStringNamePtr(&pointer);
        GDExtensionInt size = new GDExtensionInt(contents.Length);

        fixed (byte* reference = contents)
        {
            GDExtensionInterface.StringNameNewWithUtf8CharsAndLen(destination, reference, size);
        }

        return pointer;
    }

    public static void DestructString(nint pointer)
    {
        GDExtensionTypePtr @base = new GDExtensionTypePtr(&pointer);
        GDExtensionPtrDestructor destructor = GDExtensionInterface.VariantGetPtrDestructor(GDExtensionVariantTypeString);
        destructor.Method(@base);
    }

    public static void DestructStringName(nint pointer)
    {
        GDExtensionTypePtr @base = new GDExtensionTypePtr(&pointer);
        GDExtensionPtrDestructor destructor = GDExtensionInterface.VariantGetPtrDestructor(GDExtensionVariantTypeStringName);
        destructor.Method(@base);
    }

    public static void RegisterClass(GDExtensionClassLibraryPtr library,
                                     ReadOnlySpan<byte> className,
                                     ReadOnlySpan<byte> parentClassName,
                                     GDExtensionClassCreateInstance createCallback,
                                     GDExtensionClassFreeInstance freeCallback)
    {
        nint classStringName = ConstructStringName(className);
        nint parentClassStringName = ConstructStringName(parentClassName);
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
        DestructStringName(classStringName);
        DestructStringName(parentClassStringName);
    }

    public static void RegisterPropertyGetter(GDExtensionClassLibraryPtr library,
                                              ReadOnlySpan<byte> className,
                                              ReadOnlySpan<byte> methodName,
                                              GDExtensionClassMethodCall methodCall,
                                              GDExtensionClassMethodPtrCall methodPtrcall,
                                              GDExtensionVariantType type)
    {
        nint classStringName = ConstructStringName(className);
        nint methodStringName = ConstructStringName(methodName);
        nint emptyStringName = ConstructStringName(default);
        nint emptyString = ConstructString(default);
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
        DestructStringName(classStringName);
        DestructStringName(methodStringName);
        DestructStringName(emptyStringName);
        DestructString(emptyString);
    }

    public static void RegisterPropertySetter(GDExtensionClassLibraryPtr library,
                                              ReadOnlySpan<byte> className,
                                              ReadOnlySpan<byte> methodName,
                                              GDExtensionClassMethodCall methodCall,
                                              GDExtensionClassMethodPtrCall methodPtrcall,
                                              GDExtensionVariantType type)
    {
        nint classStringName = ConstructStringName(className);
        nint methodStringName = ConstructStringName(methodName);
        nint argumentStringName = ConstructStringName("value"u8);
        nint emptyStringName = ConstructStringName(default);
        nint emptyString = ConstructString(default);
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
            CallFunc = methodCall,
            PtrcallFunc = methodPtrcall,
            MethodFlags = (uint)GDExtensionMethodFlagsDefault,
            ArgumentCount = 1,
            ArgumentsInfo = &argumentInfo,
            ArgumentsMetadata = &argsMetadata,
        };
        GDExtensionInterface.ClassdbRegisterExtensionClassMethod(library,
                                                                 new GDExtensionConstStringNamePtr(&classStringName),
                                                                 &methodInfo);
        DestructStringName(classStringName);
        DestructStringName(methodStringName);
        DestructStringName(argumentStringName);
        DestructStringName(emptyStringName);
        DestructString(emptyString);
    }

    public static void RegisterProperty(GDExtensionClassLibraryPtr library,
                                        ReadOnlySpan<byte> className,
                                        ReadOnlySpan<byte> propertyName,
                                        GDExtensionVariantType type,
                                        ReadOnlySpan<byte> propertyGetterName,
                                        ReadOnlySpan<byte> propertySetterName)
    {
        nint classStringName = ConstructStringName(className);
        nint propertyStringName = ConstructStringName(propertyName);
        nint propertyGetterStringName = ConstructStringName(propertyGetterName);
        nint propertySetterStringName = ConstructStringName(propertySetterName);
        nint emptyStringName = ConstructStringName(default);
        nint emptyString = ConstructString(default);
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
        DestructStringName(classStringName);
        DestructStringName(propertyStringName);
        DestructStringName(propertyGetterStringName);
        DestructStringName(propertySetterStringName);
        DestructStringName(emptyStringName);
        DestructString(emptyString);
    }
}
