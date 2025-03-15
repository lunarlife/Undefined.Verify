using System.Numerics;
using Undefined.Verifying.Exceptions;
using Undefined.Verifying.Results;

namespace Undefined.Verifying;

public delegate void MinVerifyAction<T>(MinResult<T> resultAction) where T : struct
#if NET7_0_OR_GREATER
    , INumber<T>
#endif
;

public static partial class Verify
{
#if NEW_FEATURES
    [StackTraceHidden]
#endif
    private static void MinInternal<T>(T value, T min, string? message, MinVerifyAction<T>? resultAction,
        bool isPassed) where T : struct
#if NET7_0_OR_GREATER
        , INumber<T>
#endif
    {
        resultAction?.Invoke(new MinResult<T>(isPassed, value, min));
        if (!isPassed)
            throw new MinimumValueException(value, min, message);
    }

    public static void Min(int value, int min, string? message = null,
        MinVerifyAction<int>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value >= min);

    public static void Min(uint value, uint min, string? message = null,
        MinVerifyAction<uint>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value >= min);

    public static void Min(long value, long min, string? message = null,
        MinVerifyAction<long>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value >= min);

    public static void Min(ulong value, ulong min, string? message = null,
        MinVerifyAction<ulong>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value >= min);

    public static void Min(float value, float min, string? message = null,
        MinVerifyAction<float>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value >= min);

    public static void Min(double value, double min, string? message = null,
        MinVerifyAction<double>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value >= min);


    public static void ThrowMin(int value, int min, string? message = null) =>
        throw new MinimumValueException(value, min, message);

    public static void ThrowMin(uint value, uint min, string? message = null) =>
        throw new MinimumValueException(value, min, message);

    public static void ThrowMin(long value, long min, string? message = null) =>
        throw new MinimumValueException(value, min, message);

    public static void ThrowMin(ulong value, ulong min, string? message = null) =>
        throw new MinimumValueException(value, min, message);

    public static void ThrowMin(float value, float min, string? message = null) =>
        throw new MinimumValueException(value, min, message);

    public static void ThrowMin(double value, double min, string? message = null) =>
        throw new MinimumValueException(value, min, message);


#if NET7_0_OR_GREATER
    public static void ThrowMin<T>(T value, T min, string? message = null) where T : struct, INumber<T> =>
        throw new MinimumValueException(value, min, message);

    public static void Min<T>(T value, T min, string? message = null, MinVerifyAction<T>? resultAction = null)
        where T : struct, INumber<T> =>
        MinInternal(value, min, message, resultAction, value >= min);
#endif
}