using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

public static unsafe class GDExtensionMarshal
{
    private const uint PropertyUsageNone = 0;
    private const uint PropertyUsageStorage = 2;
    private const uint PropertyUsageEditor = 4;
    private const uint PropertyUsageDefault = PropertyUsageStorage | PropertyUsageEditor;

    public static void BindMethod(GDExtensionClassLibraryPtr library, ReadOnlySpan<byte> className, ReadOnlySpan<byte> methodName, void* function, GDExtensionVariantType returnType)
    {
        using GDExtensionStringName methodNameString = new GDExtensionStringName(methodName);
        GDExtensionPropertyInfo returnInfo = MakeProperty(returnType, ""u8);
        GDExtensionClassMethodInfo methodInfo = new GDExtensionClassMethodInfo
        {
            Name = new GDExtensionStringNamePtr(&methodNameString),
            MethodUserdata = function,
            CallFunc = new GDExtensionClassMethodCall(&CallPassVoidReturnFloat),
            PtrcallFunc = new GDExtensionClassMethodPtrCall(&PtrCallPassVoidReturnFloat),
            MethodFlags = (uint)GDExtensionMethodFlagsDefault,
            HasReturnValue = new GDExtensionBool(true),
            ReturnValueInfo = &returnInfo,
            ReturnValueMetadata = GDExtensionMethodArgumentMetadataNone,
            ArgumentCount = 0,
        };

        using GDExtensionStringName classNameString = new GDExtensionStringName(className);
        GDExtensionInterface.ClassdbRegisterExtensionClassMethod(library, new GDExtensionConstStringNamePtr(&classNameString), &methodInfo);
        DestructProperty(&returnInfo);
    }

    public static void BindMethod(GDExtensionClassLibraryPtr library, ReadOnlySpan<byte> className, ReadOnlySpan<byte> methodName, void* function, ReadOnlySpan<byte> arg1Name, GDExtensionVariantType arg1Type)
    {
        using GDExtensionStringName methodNameString = new GDExtensionStringName(methodName);
        GDExtensionPropertyInfo argsInfo = MakeProperty(arg1Type, arg1Name);
        GDExtensionClassMethodArgumentMetadata argsMetadata = GDExtensionMethodArgumentMetadataNone;
        GDExtensionClassMethodInfo methodInfo = new GDExtensionClassMethodInfo
        {
            Name = new GDExtensionStringNamePtr(&methodNameString),
            MethodUserdata = function,
            CallFunc = new GDExtensionClassMethodCall(&CallPassFloatReturnVoid),
            PtrcallFunc = new GDExtensionClassMethodPtrCall(&PtrCallPassFloatReturnVoid),
            MethodFlags = (uint)GDExtensionMethodFlagsDefault,
            HasReturnValue = new GDExtensionBool(false),
            ArgumentCount = 1,
            ArgumentsInfo = &argsInfo,
            ArgumentsMetadata = &argsMetadata,
        };
        using GDExtensionStringName classNameString = new GDExtensionStringName(className);
        GDExtensionInterface.ClassdbRegisterExtensionClassMethod(library, new GDExtensionConstStringNamePtr(&classNameString), &methodInfo);
        DestructProperty(&argsInfo);
    }

    public static void BindProperty(GDExtensionClassLibraryPtr library, ReadOnlySpan<byte> className, ReadOnlySpan<byte> name, GDExtensionVariantType type, ReadOnlySpan<byte> getter, ReadOnlySpan<byte> setter)
    {
        using GDExtensionStringName classStringName = new GDExtensionStringName(className);
        GDExtensionPropertyInfo info = MakeProperty(type, name);
        using GDExtensionStringName getterName = new GDExtensionStringName(getter);
        using GDExtensionStringName setterName = new GDExtensionStringName(setter);
        GDExtensionInterface.ClassdbRegisterExtensionClassProperty(library, new GDExtensionConstStringNamePtr(&classStringName), &info, new GDExtensionConstStringNamePtr(&setterName), new GDExtensionConstStringNamePtr(&getterName));
        DestructProperty(&info);
    }

    public static GDExtensionPropertyInfo MakeProperty(GDExtensionVariantType type, ReadOnlySpan<byte> name)
    {
        return MakeProperty(type, name, PropertyUsageNone, ""u8, ""u8, PropertyUsageDefault);
    }

    public static GDExtensionPropertyInfo MakeProperty(GDExtensionVariantType type, ReadOnlySpan<byte> name, uint hint, ReadOnlySpan<byte> hintString, ReadOnlySpan<byte> className, uint usageFlags)
    {
        GDExtensionStringName* propName = (GDExtensionStringName*)GDExtensionInterface.MemAlloc((nuint)sizeof(GDExtensionStringName));
        *propName = new GDExtensionStringName(name);
        GDExtensionString* propHintString = (GDExtensionString*)GDExtensionInterface.MemAlloc((nuint)sizeof(GDExtensionString));
        *propHintString = new GDExtensionString(hintString);
        GDExtensionStringName* propClassName = (GDExtensionStringName*)GDExtensionInterface.MemAlloc((nuint)sizeof(GDExtensionStringName));
        *propClassName = new GDExtensionStringName(className);
        return new GDExtensionPropertyInfo
        {
            Name = new GDExtensionStringNamePtr(propName),
            Type = type,
            Hint = hint,
            HintString = new GDExtensionStringPtr(propHintString),
            ClassName = new GDExtensionStringNamePtr(propClassName),
            Usage = usageFlags
        };
    }

    public static void DestructProperty(GDExtensionPropertyInfo* info)
    {
        ((GDExtensionStringName*)info->Name.Pointer)->Dispose();
        ((GDExtensionString*)info->HintString.Pointer)->Dispose();
        ((GDExtensionStringName*)info->ClassName.Pointer)->Dispose();
        GDExtensionInterface.MemFree(info->Name.Pointer);
        GDExtensionInterface.MemFree(info->HintString.Pointer);
        GDExtensionInterface.MemFree(info->ClassName.Pointer);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void PtrCallPassFloatReturnVoid(void* methodUserdata, GDExtensionClassInstancePtr instance, GDExtensionConstTypePtr* args, GDExtensionTypePtr ret)
    {
        var function = (delegate* unmanaged[Cdecl]<GDExtensionClassInstancePtr, double, void>)methodUserdata;
        function(instance, Cast<double>(args[0]));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void PtrCallPassVoidReturnFloat(void* methodUserdata, GDExtensionClassInstancePtr instance, GDExtensionConstTypePtr* args, GDExtensionTypePtr ret)
    {
        var function = (delegate* unmanaged[Cdecl]<GDExtensionClassInstancePtr, double>)methodUserdata;
        Cast<double>(ret) = function(instance);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void CallPassFloatReturnVoid(void* methodUserdata, GDExtensionClassInstancePtr instance, GDExtensionConstVariantPtr* args, GDExtensionInt argumentCount, GDExtensionVariantPtr @return, GDExtensionCallError* error)
    {
        switch (argumentCount.Value)
        {
            case < 1:
                error->Error = GDExtensionCallErrorTooFewArguments;
                error->Expected = 1;
                return;
            case > 1:
                error->Error = GDExtensionCallErrorTooManyArguments;
                error->Expected = 1;
                return;
        }

        if (GDExtensionInterface.VariantGetType(args[0]) != GDExtensionVariantTypeFloat)
        {
            error->Error = GDExtensionCallErrorInvalidArgument;
            error->Expected = (int)GDExtensionVariantTypeFloat;
            error->Argument = 0;
            return;
        }

        double arg1;
        GDExtensionInterface.GetVariantToTypeConstructor(GDExtensionVariantTypeFloat).Method(new GDExtensionUninitializedTypePtr(&arg1), new GDExtensionVariantPtr(args[0].Pointer));
        var function = (delegate* unmanaged[Cdecl]<GDExtensionClassInstancePtr, double, void>)methodUserdata;
        function(instance, arg1);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void CallPassVoidReturnFloat(void* methodUserdata, GDExtensionClassInstancePtr instance, GDExtensionConstVariantPtr* args, GDExtensionInt argumentCount, GDExtensionVariantPtr @return, GDExtensionCallError* error)
    {
        if (argumentCount.Value != 0)
        {
            error->Error = GDExtensionCallErrorTooManyArguments;
            error->Expected = 0;
        }

        var function = (delegate* unmanaged[Cdecl]<GDExtensionClassInstancePtr, double>)methodUserdata;
        double result = function(instance);
        GDExtensionInterface.GetVariantFromTypeConstructor(GDExtensionVariantTypeFloat).Method(@return, new GDExtensionTypePtr(&result));
    }

    private static ref T Cast<T>(GDExtensionTypePtr handle) where T : unmanaged
    {
        return ref *(T*)handle.Pointer;
    }

    private static ref readonly T Cast<T>(GDExtensionConstTypePtr handle) where T : unmanaged
    {
        return ref *(T*)handle.Pointer;
    }
}
