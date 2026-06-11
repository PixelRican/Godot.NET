using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Godot.NET.Tests;

public static unsafe class GDMarshal
{
    private const uint PropertyUsageNone = 0;
    private const uint PropertyUsageStorage = 2;
    private const uint PropertyUsageEditor = 4;
    private const uint PropertyUsageDefault = PropertyUsageStorage | PropertyUsageEditor;

    public static ref T AsRef<T>(GDExtensionTypePtr handle) where T : unmanaged
    {
        return ref *(T*)handle.Pointer;
    }

    public static ref readonly T AsRef<T>(GDExtensionConstTypePtr handle) where T : unmanaged
    {
        return ref *(T*)handle.Pointer;
    }

    public static GDExtensionClassInstancePtr ToPointer<T>(GCHandle<T> handle) where T : class
    {
        return new GDExtensionClassInstancePtr(GCHandle<T>.ToIntPtr(handle).ToPointer());
    }

    public static GCHandle<T> ToGCHandle<T>(GDExtensionClassInstancePtr instance) where T : class
    {
        return GCHandle<T>.FromIntPtr((nint)instance.Pointer);
    }

    public static void BindMethod(GDExtensionClassLibraryPtr library, ReadOnlySpan<byte> className, ReadOnlySpan<byte> methodName, void* function, GDExtensionVariantType returnType)
    {
        using GDStringName methodNameString = new GDStringName(methodName);
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
        using GDStringName classNameString = new GDStringName(className);
        GDExtensionInterface.ClassdbRegisterExtensionClassMethod(library, new GDExtensionConstStringNamePtr(&classNameString), &methodInfo);
        DestructProperty(&returnInfo);
    }

    public static void BindMethod(GDExtensionClassLibraryPtr library, ReadOnlySpan<byte> className, ReadOnlySpan<byte> methodName, void* function, ReadOnlySpan<byte> arg1Name, GDExtensionVariantType arg1Type)
    {
        using GDStringName methodNameString = new GDStringName(methodName);
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
        using GDStringName classNameString = new GDStringName(className);
        GDExtensionInterface.ClassdbRegisterExtensionClassMethod(library, new GDExtensionConstStringNamePtr(&classNameString), &methodInfo);
        DestructProperty(&argsInfo);
    }

    public static void BindProperty(GDExtensionClassLibraryPtr library, ReadOnlySpan<byte> className, ReadOnlySpan<byte> name, GDExtensionVariantType type, ReadOnlySpan<byte> getter, ReadOnlySpan<byte> setter)
    {
        using GDStringName classStringName = new GDStringName(className);
        GDExtensionPropertyInfo info = MakeProperty(type, name);
        using GDStringName getterName = new GDStringName(getter);
        using GDStringName setterName = new GDStringName(setter);
        GDExtensionInterface.ClassdbRegisterExtensionClassProperty(library, new GDExtensionConstStringNamePtr(&classStringName), &info, new GDExtensionConstStringNamePtr(&setterName), new GDExtensionConstStringNamePtr(&getterName));
        DestructProperty(&info);
    }

    private static GDExtensionPropertyInfo MakeProperty(GDExtensionVariantType type, ReadOnlySpan<byte> name)
    {
        return MakeProperty(type, name, PropertyUsageNone, ""u8, ""u8, PropertyUsageDefault);
    }

    private static GDExtensionPropertyInfo MakeProperty(GDExtensionVariantType type, ReadOnlySpan<byte> name, uint hint, ReadOnlySpan<byte> hintString, ReadOnlySpan<byte> className, uint usageFlags)
    {
        GDStringName* propName = (GDStringName*)GDExtensionInterface.MemAlloc((nuint)sizeof(GDStringName));
        *propName = new GDStringName(name);
        GDString* propHintString = (GDString*)GDExtensionInterface.MemAlloc((nuint)sizeof(GDString));
        *propHintString = new GDString(hintString);
        GDStringName* propClassName = (GDStringName*)GDExtensionInterface.MemAlloc((nuint)sizeof(GDStringName));
        *propClassName = new GDStringName(className);
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

    private static void DestructProperty(GDExtensionPropertyInfo* info)
    {
        ((GDStringName*)info->Name.Pointer)->Dispose();
        ((GDString*)info->HintString.Pointer)->Dispose();
        ((GDStringName*)info->ClassName.Pointer)->Dispose();
        GDExtensionInterface.MemFree(info->Name.Pointer);
        GDExtensionInterface.MemFree(info->HintString.Pointer);
        GDExtensionInterface.MemFree(info->ClassName.Pointer);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PtrCallPassFloatReturnVoid(void* methodUserdata, GDExtensionClassInstancePtr instance, GDExtensionConstTypePtr* args, GDExtensionTypePtr ret)
    {
        var function = (delegate*<GDExtensionClassInstancePtr, double, void>)methodUserdata;
        function(instance, AsRef<double>(args[0]));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void PtrCallPassVoidReturnFloat(void* methodUserdata, GDExtensionClassInstancePtr instance, GDExtensionConstTypePtr* args, GDExtensionTypePtr ret)
    {
        var function = (delegate*<GDExtensionClassInstancePtr, double>)methodUserdata;
        AsRef<double>(ret) = function(instance);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void CallPassFloatReturnVoid(void* methodUserdata, GDExtensionClassInstancePtr instance, GDExtensionConstVariantPtr* args, GDExtensionInt argumentCount, GDExtensionVariantPtr @return, GDExtensionCallError* error)
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
        var function = (delegate*<GDExtensionClassInstancePtr, double, void>)methodUserdata;
        function(instance, arg1);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void CallPassVoidReturnFloat(void* methodUserdata, GDExtensionClassInstancePtr instance, GDExtensionConstVariantPtr* args, GDExtensionInt argumentCount, GDExtensionVariantPtr @return, GDExtensionCallError* error)
    {
        if (argumentCount.Value != 0)
        {
            error->Error = GDExtensionCallErrorTooManyArguments;
            error->Expected = 0;
        }

        var function = (delegate*<GDExtensionClassInstancePtr, double>)methodUserdata;
        double result = function(instance);
        GDExtensionInterface.GetVariantFromTypeConstructor(GDExtensionVariantTypeFloat).Method(@return, new GDExtensionTypePtr(&result));
    }
}
