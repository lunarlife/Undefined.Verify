using System.Numerics;

namespace Undefined.Verify;

public static class Verify
{
    public static void RangeArray(Array array, int index, string? arg = null)
    {
        if (!TryClamp(index, 0, array.Length - 1))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static void NotNull(object? obj, string? message = null)
    {
        if (obj is not null) return;
        throw new NullReferenceException(message ?? "Object cant be null.");
    }

    public static void Argument(bool value, string? message = null)
    {
        if (!value)
            throw new ArgumentException(message);
    }
#if NET7_0_OR_GREATER

    public static void Range<T>(T value, T min, T max, string? arg = null) where T : INumber<T>
    {
        if (!TryClamp(value, min, max))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static void Range<T>(T value, T max, string? arg = null) where T : INumber<T>
    {
        if (!TryClamp(value, T.Zero, max))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static void RangeArray<T>(T value, T max, string? arg = null) where T : INumber<T>
    {
        if (!TryClamp(value, T.Zero, max - T.One))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static void Min<T>(T value, T min, string? arg = null) where T : INumber<T>
    {
        if (value < min)
            throw new ArgumentOutOfRangeException(arg ?? $"Value cant be less than {min}.");
    }

    public static void MoreThanZero<T>(T value, string? arg = null) where T : INumber<T>
    {
        if (value < T.Zero)
            throw new ArgumentOutOfRangeException(arg ?? "Value cant be less than zero.");
    }


    private static bool TryClamp<T>(T value, T min, T max) where T : INumber<T> =>
        value == (value < min ? min : value > max ? max : value);
#else
    public static void Range(int value, int min, int max, string? arg = null)
    {
        if (!TryClamp(value, min, max))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static void Range(float value, float min, float max, string? arg = null)
    {
        if (!TryClamp(value, min, max))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static void Range(double value, double min, double max, string? arg = null)
    {
        if (!TryClamp(value, min, max))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static void Range(int value, int max, string? arg = null)
    {
        if (!TryClamp(value, 0, max))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static void Range(double value, double max, string? arg = null)
    {
        if (!TryClamp(value, 0, max))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static void Range(float value, float max, string? arg = null)
    {
        if (!TryClamp(value, 0, max))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static void RangeArray(int value, int max, string? arg = null)
    {
        if (!TryClamp(value, 0, max - 1))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static void Min(int value, int min, string? arg = null)
    {
        if (value < min)
            throw new ArgumentOutOfRangeException(arg ?? $"Value cant be less than {min}.");
    }

    public static void Min(float value, float min, string? arg = null)
    {
        if (value < min)
            throw new ArgumentOutOfRangeException(arg ?? $"Value cant be less than {min}.");
    }

    public static void Min(double value, double min, string? arg = null)
    {
        if (value < min)
            throw new ArgumentOutOfRangeException(arg ?? $"Value cant be less than {min}.");
    }

    public static void MoreThanZero(int value, string? arg = null)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(arg ?? "Value cant be less than zero.");
    }

    public static void MoreThanZero(float value, string? arg = null)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(arg ?? "Value cant be less than zero.");
    }

    public static void MoreThanZero(double value, string? arg = null)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(arg ?? "Value cant be less than zero.");
    }

    private static bool TryClamp(int value, int min, int max) =>
        value == (value < min ? min : value > max ? max : value);

    private static bool TryClamp(float value, float min, float max) =>
        value.Equals(value < min ? min : value > max ? max : value);

    private static bool TryClamp(double value, double min, double max) =>
        value.Equals(value < min ? min : value > max ? max : value);
#endif
}