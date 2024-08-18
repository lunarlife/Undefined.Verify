using System.Diagnostics;
using System.Numerics;
using Undefined.Verifying.Exceptions;
using Undefined.Verifying.Results;

namespace Undefined.Verifying;

public delegate void MaxVerifyAction<T>(MaxResult<T> resultAction) where T : struct
#if NET7_0_OR_GREATER
    , INumber<T>
#endif
;

public static partial class Verify
{
#if !NETSTANDARD
    [StackTraceHidden]
#endif
    private static void MaxInternal<T>(T value, T max, string? message, MaxVerifyAction<T>? resultAction,
        bool isPassed) where T : struct
#if NET7_0_OR_GREATER
        , INumber<T>
#endif
    {
        var maxResult = new MaxResult<T>(isPassed, value, max);
        resultAction?.Invoke(maxResult);
        if (!isPassed)
            throw new MaximumValueException(value, max, message);
    }

    public static void Max(int value, int max, string? message = null, MaxVerifyAction<int>? resultAction = null) =>
        MaxInternal(value, max, message, resultAction, value > max);

    public static void Max(uint value, uint max, string? message = null, MaxVerifyAction<uint>? resultAction = null) =>
        MaxInternal(value, max, message, resultAction, value > max);

    public static void Max(long value, long max, string? message = null, MaxVerifyAction<long>? resultAction = null) =>
        MaxInternal(value, max, message, resultAction, value > max);

    public static void
        Max(ulong value, ulong max, string? message = null, MaxVerifyAction<ulong>? resultAction = null) =>
        MaxInternal(value, max, message, resultAction, value > max);

    public static void
        Max(float value, float max, string? message = null, MaxVerifyAction<float>? resultAction = null) =>
        MaxInternal(value, max, message, resultAction, value > max);

    public static void Max(double value, double max, string? message = null,
        MaxVerifyAction<double>? resultAction = null) =>
        MaxInternal(value, max, message, resultAction, value > max);

    public static void ThrowMax(int value, int max, string? message = null) =>
        throw new MaximumValueException(value, max, message);

    public static void ThrowMax(uint value, uint max, string? message = null) =>
        throw new MaximumValueException(value, max, message);

    public static void ThrowMax(long value, long max, string? message = null) =>
        throw new MaximumValueException(value, max, message);

    public static void ThrowMax(ulong value, ulong max, string? message = null) =>
        throw new MaximumValueException(value, max, message);

    public static void ThrowMax(float value, float max, string? message = null) =>
        throw new MaximumValueException(value, max, message);

    public static void ThrowMax(double value, double max, string? message = null) =>
        throw new MaximumValueException(value, max, message);

#if NET7_0_OR_GREATER
    public static void ThrowMax<T>(T value, T max, string? message = null) where T : struct, INumber<T> =>
        throw new MaximumValueException(value, max, message);

    public static void Max<T>(T value, T max, string? message = null, MaxVerifyAction<T>? resultAction = null)
        where T : struct, INumber<T> =>
        MaxInternal(value, max, message, resultAction, value > max);
#endif
}