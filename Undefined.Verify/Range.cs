using System.Numerics;
using Undefined.Verifying.Exceptions;
using Undefined.Verifying.Results;

namespace Undefined.Verifying;

public delegate void RangeVerifyAction<T>(RangeResult<T> result) where T : struct
#if NET7_0_OR_GREATER
    , INumber<T>
#endif
;

public static partial class Verify
{
#if NEW_FEATURES
    [StackTraceHidden]
#endif
    private static void RangeInternal<T>(bool isPassed, T value, T min, T max, string? message,
        RangeVerifyAction<T>? action) where T : struct
#if NET7_0_OR_GREATER
        , INumber<T>
#endif
    {
        action?.Invoke(new RangeResult<T>(isPassed, value, min, max));
        if (isPassed) return;
        throw new RangeException(value, min, max, message);
    }


    public static void Range(int value, int min, int max, string? message = null,
        RangeVerifyAction<int>? action = null) =>
        RangeInternal(TryClamp(value, min, max), value, min, max, message, action);

    public static void Range(uint value, uint min, uint max, string? message = null, RangeVerifyAction<uint>? action = null) =>
        RangeInternal(TryClamp(value, min, max), value, min, max, message, action);

    public static void Range(long value, long min, long max, string? message = null, RangeVerifyAction<long>? action = null) =>
        RangeInternal(TryClamp(value, min, max), value, min, max, message, action);

    public static void Range(ulong value, ulong min, ulong max, string? message = null, RangeVerifyAction<ulong>? action = null) =>
        RangeInternal(TryClamp(value, min, max), value, min, max, message, action);

    public static void Range(float value, float min, float max, string? message = null,
        RangeVerifyAction<float>? action = null) =>
        RangeInternal(TryClamp(value, min, max), value, min, max, message, action);

    public static void Range(double value, double min, double max, string? message = null,
        RangeVerifyAction<double>? action = null) =>
        RangeInternal(TryClamp(value, min, max), value, min, max, message, action);


    public static void Range(int value, int max, string? message = null, RangeVerifyAction<int>? action = null) =>
        Range(value, 0, max, message, action);

    public static void Range(uint value, uint max, string? message = null, RangeVerifyAction<uint>? action = null) =>
        Range(value, 0, max, message, action);

    public static void Range(long value, long max, string? message = null, RangeVerifyAction<long>? action = null) =>
        Range(value, 0, max, message, action);

    public static void Range(ulong value, ulong max, string? message = null, RangeVerifyAction<ulong>? action = null) =>
        Range(value, 0, max, message, action);

    public static void
        Range(double value, double max, string? message = null, RangeVerifyAction<double>? action = null) =>
        Range(value, 0d, max, message, action);

    public static void Range(float value, float max, string? message = null, RangeVerifyAction<float>? action = null) =>
        Range(value, 0f, max, message, action);

    public static void ThrowRange(int value, int min, int max, string? message = null) =>
        throw new RangeException(value, min, max, message);

    public static void ThrowRange(uint value, uint min, uint max, string? message = null) =>
        throw new RangeException(value, min, max, message);

    public static void ThrowRange(long value, long min, long max, string? message = null) =>
        throw new RangeException(value, min, max, message);

    public static void ThrowRange(ulong value, ulong min, ulong max, string? message = null) =>
        throw new RangeException(value, min, max, message);

    public static void ThrowRange(float value, float min, float max, string? message = null) =>
        throw new RangeException(value, min, max, message);

    public static void ThrowRange(double value, double min, double max, string? message = null) =>
        throw new RangeException(value, min, max, message);


#if NET7_0_OR_GREATER
    public static void Range<T>(T value, T min, T max, string? message = null, RangeVerifyAction<T>? action =
        null) where T : struct, INumber<T> =>
        RangeInternal(TryClamp(value, min, max), value, min, max, message, action);

    public static void ThrowRange<T>(T value, T min, T max, string? message = null) where T : struct,
        INumber<T> =>
        throw new RangeException(value, min, max, message);
#endif
}