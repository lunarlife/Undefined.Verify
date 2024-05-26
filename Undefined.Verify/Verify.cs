using System.Numerics;

namespace Undefined.Verify;

public static class Verify
{
    public static void RangeArray(Array array, int index, string? arg = null)
    {
        if (!TryClamp(index, 0, array.Length - 1))
            throw new ArgumentOutOfRangeException(arg);
    }

    public static T NotNull<T>(T? obj, string? message = null) =>
        obj is null ? throw new NullReferenceException(message ?? "Object cant be null.") : obj;

    public static void Argument(bool value, string? message = null)
    {
        if (!value)
            throw new ArgumentException(message);
    }

#if NET7_0_OR_GREATER
    public static void Range<T>(T value, T min, T max, Action<T> action, string? message = null) where T : INumber<T>
    {
        if (!TryClamp(value, min, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range<T>(T value, T max, Action<T> action, string? message = null) where T : INumber<T>
    {
        if (!TryClamp(value, T.Zero, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void RangeArray<T>(T value, T max, Action<T> action, string? message = null) where T : INumber<T>
    {
        if (!TryClamp(value, T.Zero, max - T.One))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Min<T>(T value, T min, Action<T> action, string? message = null) where T : INumber<T>
    {
        if (value < min)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Max<T>(T value, T min, Action<T> action, string? message = null) where T : INumber<T>
    {
        if (value > min)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void MoreThanZero<T>(T value, Action<T> action, string? message = null) where T : INumber<T>
    {
        if (value < T.Zero)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }


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

    public static void Max<T>(T value, T min, string? arg = null) where T : INumber<T>
    {
        if (value > min)
            throw new ArgumentOutOfRangeException(arg ?? $"Value cant be less than {min}.");
    }

    public static void MoreThanZero<T>(T value, string? arg = null) where T : INumber<T>
    {
        if (value < T.Zero)
            throw new ArgumentOutOfRangeException(arg ?? "Value cant be less than zero.");
    }


    private static bool TryClamp<T>(T value, T min, T max) where T : INumber<T> =>
        value == (value < min ? min : value > max ? max : value);
#endif

    #region Exceptions6.0

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

    public static void Max(int value, int max, string? arg = null)
    {
        if (value > max)
            throw new ArgumentOutOfRangeException(arg ?? $"Value cant be less than {max}.");
    }

    public static void Max(float value, float max, string? arg = null)
    {
        if (value > max)
            throw new ArgumentOutOfRangeException(arg ?? $"Value cant be less than {max}.");
    }

    public static void Max(double value, double max, string? arg = null)
    {
        if (value > max)
            throw new ArgumentOutOfRangeException(arg ?? $"Value cant be less than {max}.");
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

    #endregion

    #region Actions6.0

    public static void Range(int value, int min, int max, Action<int> action, string? message = null)
    {
        if (!TryClamp(value, min, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range(float value, float min, float max, Action<float> action, string? message = null)
    {
        if (!TryClamp(value, min, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range(double value, double min, double max, Action<double> action, string? message = null)
    {
        if (!TryClamp(value, min, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range(int value, int max, Action<int> action, string? message = null)
    {
        if (!TryClamp(value, 0, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range(double value, double max, Action<double> action, string? message = null)
    {
        if (!TryClamp(value, 0, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range(float value, float max, Action<float> action, string? message = null)
    {
        if (!TryClamp(value, 0, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void RangeArray(int value, int max, Action<int> action, string? message = null)
    {
        if (!TryClamp(value, 0, max - 1))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Min(int value, int min, Action<int> action, string? message = null)
    {
        if (value < min)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Min(float value, float min, Action<float> action, string? message = null)
    {
        if (value < min)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Min(double value, double min, Action<double> action, string? message = null)
    {
        if (value < min)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Max(int value, int max, Action<int> action, string? message = null)
    {
        if (value > max)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Max(float value, float max, Action<float> action, string? message = null)
    {
        if (value > max)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Max(double value, double max, Action<double> action, string? message = null)
    {
        if (value > max)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void MoreThanZero(int value, Action<int> action, string? message = null)
    {
        if (value < 0)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void MoreThanZero(float value, Action<float> action, string? message = null)
    {
        if (value < 0)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void MoreThanZero(double value, Action<double> action, string? message = null)
    {
        if (value < 0)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    #endregion


    private static bool TryClamp(int value, int min, int max) =>
        value == (value < min ? min : value > max ? max : value);

    private static bool TryClamp(float value, float min, float max) =>
        value.Equals(value < min ? min : value > max ? max : value);

    private static bool TryClamp(double value, double min, double max) =>
        value.Equals(value < min ? min : value > max ? max : value);
}