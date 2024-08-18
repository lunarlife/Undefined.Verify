using System.Diagnostics;
using System.Numerics;
using Undefined.Verifying.Exceptions;
using Undefined.Verifying.Results;

namespace Undefined.Verifying;

public delegate void NonNegativeVerifyAction<T>(NonNegativeResult<T> resultAction) where T : struct
#if NET7_0_OR_GREATER
    , INumber<T>
#endif
;

public static partial class Verify
{
#if !NETSTANDARD
    [StackTraceHidden]
#endif
    private static void NonNegativeInternal<T>(T value, string? message, NonNegativeVerifyAction<T>? resultAction,
        bool isPassed) where T : struct
#if NET7_0_OR_GREATER
        , INumber<T>
#endif
    {
        resultAction?.Invoke(new NonNegativeResult<T>(isPassed, value));
        if (!isPassed)
            throw new NonNegativeException(value, message);
    }

    public static void NonNegative(int value, string? message = null,
        NonNegativeVerifyAction<int>? resultAction = null) =>
        NonNegativeInternal(value, message, resultAction, value >= 0);

    public static void NonNegative(long value, string? message = null,
        NonNegativeVerifyAction<long>? resultAction = null) =>
        NonNegativeInternal(value, message, resultAction, value >= 0);


    public static void
        NonNegative(float value, string? message = null, NonNegativeVerifyAction<float>? resultAction = null) =>
        NonNegativeInternal(value, message, resultAction, value >= 0);

    public static void NonNegative(double value, string? message = null,
        NonNegativeVerifyAction<double>? resultAction = null) =>
        NonNegativeInternal(value, message, resultAction, value >= 0);

    public static void ThrowNonNegative(int value, string? message = null) =>
        throw new NonNegativeException(value, message);

    public static void ThrowNonNegative(long value, string? message = null) =>
        throw new NonNegativeException(value, message);

    public static void ThrowNonNegative(float value, string? message = null) =>
        throw new NonNegativeException(value, message);

    public static void ThrowNonNegative(double value, string? message = null) =>
        throw new NonNegativeException(value, message);


#if NET7_0_OR_GREATER
    public static void NonNegative<T>(T value, string? message = null,
        NonNegativeVerifyAction<T>? resultAction = null) where T : struct, INumber<T> =>
        NonNegativeInternal(value, message, resultAction, value >= T.Zero);

    public static void ThrowNonNegative<T>(T value, string? message = null) where T : struct, INumber<T> =>
        throw new NonNegativeException(value, message);

#endif
}