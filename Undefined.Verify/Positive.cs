using System.Numerics;
using Undefined.Verifying.Exceptions;
using Undefined.Verifying.Results;

namespace Undefined.Verifying;

public delegate void PositiveVerifyAction<T>(PositiveResult<T> resultAction) where T : struct
#if NET7_0_OR_GREATER
    , INumber<T>
#endif
;

public static partial class Verify
{
#if NEW_FEATURES
    [StackTraceHidden]
#endif
    private static void PositiveInternal<T>(T value, string? message, PositiveVerifyAction<T>? resultAction,
        bool isPassed) where T : struct
#if NET7_0_OR_GREATER
        , INumber<T>
#endif
    {
        resultAction?.Invoke(new PositiveResult<T>(isPassed, value));
        if (!isPassed)
            throw new PositiveException(value, message);
    }

    public static void Positive(int value, string? message = null,
        PositiveVerifyAction<int>? resultAction = null) =>
        PositiveInternal(value, message, resultAction, value > 0);

    public static void Positive(uint value, string? message = null,
        PositiveVerifyAction<uint>? resultAction = null) =>
        PositiveInternal(value, message, resultAction, value > 0u);

    public static void Positive(long value, string? message = null,
        PositiveVerifyAction<long>? resultAction = null) =>
        PositiveInternal(value, message, resultAction, value > 0L);

    public static void Positive(ulong value, string? message = null,
        PositiveVerifyAction<ulong>? resultAction = null) =>
        PositiveInternal(value, message, resultAction, value > 0ul);

    public static void Positive(float value, string? message = null,
        PositiveVerifyAction<float>? resultAction = null) =>
        PositiveInternal(value, message, resultAction, value > 0f);

    public static void Positive(double value, string? message = null,
        PositiveVerifyAction<double>? resultAction = null) =>
        PositiveInternal(value, message, resultAction, value > 0d);

    public static void ThrowPositive(int value, string? message = null) =>
        throw new PositiveException(value, message);

    public static void ThrowPositive(uint value, string? message = null) =>
        throw new PositiveException(value, message);

    public static void ThrowPositive(long value, string? message = null) =>
        throw new PositiveException(value, message);

    public static void ThrowPositive(ulong value, string? message = null) =>
        throw new PositiveException(value, message);

    public static void ThrowPositive(float value, string? message = null) =>
        throw new PositiveException(value, message);

    public static void ThrowPositive(double value, string? message = null) =>
        throw new PositiveException(value, message);


#if NET7_0_OR_GREATER
    public static void Positive<T>(T value, string? message = null,
        PositiveVerifyAction<T>? resultAction = null) where T : struct, INumber<T> =>
        PositiveInternal(value, message, resultAction, value > T.Zero);

    public static void ThrowPositive<T>(double value, string? message = null) where T : struct, INumber<T> =>
        throw new PositiveException(value, message);

#endif
}