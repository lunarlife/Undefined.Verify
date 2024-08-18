using System.Diagnostics;
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
#if !NETSTANDARD
    [StackTraceHidden]
#endif
    private static void MinInternal<T>(T value, T min, string? message, MinVerifyAction<T>? resultAction,
        bool isPassed) where T : struct
#if NET7_0_OR_GREATER
        , INumber<T>
#endif
    {
        var minResult = new MinResult<T>(isPassed, value, min);
        resultAction?.Invoke(minResult);
        if (!isPassed)
            throw new MinimumValueException(value, min, message);
    }

    public static void Min(int value, int min, string? message = null,
        MinVerifyAction<int>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value < min);

    public static void Min(uint value, uint min, string? message = null,
        MinVerifyAction<uint>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value < min);

    public static void Min(long value, long min, string? message = null,
        MinVerifyAction<long>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value < min);

    public static void Min(ulong value, ulong min, string? message = null,
        MinVerifyAction<ulong>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value < min);

    public static void Min(float value, float min, string? message = null,
        MinVerifyAction<float>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value < min);

    public static void Min(double value, double min, string? message = null,
        MinVerifyAction<double>? resultAction = null) =>
        MinInternal(value, min, message, resultAction, value < min);


    public static void MinOne(int value, string? message = null,
        MinVerifyAction<int>? resultAction = null) =>
        MinInternal(value, 1, message, resultAction, value < 1);

    public static void MinOne(uint value, string? message = null,
        MinVerifyAction<uint>? resultAction = null) =>
        MinInternal(value, 1u, message, resultAction, value < 1u);

    public static void MinOne(long value, string? message = null,
        MinVerifyAction<long>? resultAction = null) =>
        MinInternal(value, 1L, message, resultAction, value < 1L);

    public static void MinOne(ulong value, string? message = null,
        MinVerifyAction<ulong>? resultAction = null) =>
        MinInternal(value, 1ul, message, resultAction, value < 1ul);

    public static void MinOne(float value, string? message = null,
        MinVerifyAction<float>? resultAction = null) =>
        MinInternal(value, 1f, message, resultAction, value < 1f);

    public static void MinOne(double value, string? message = null,
        MinVerifyAction<double>? resultAction = null) =>
        MinInternal(value, 1d, message, resultAction, value < 1d);


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
        MinInternal(value, min, message, resultAction, value < min);
#endif
}