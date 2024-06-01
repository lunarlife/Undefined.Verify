using System.Numerics;

namespace Undefined.Verify;

public static class Verifying
{
    public static void RangeArray(Array array, int index, string? message = null)
    {
        if (!TryClamp(index, 0, array.Length - 1))
            throw new ArgumentOutOfRangeException(message);
    }

    public static T NotNull<T>(T? obj, string? message = null) =>
        obj is null ? throw new NullReferenceException(message ?? "Object cant be null.") : obj;

    public static void Argument(bool value, string? message = null)
    {
        if (!value)
            throw new ArgumentException(message);
    }

    public static void Argument(bool value, Action action, string message)
    {
        if (value) return;
        action();
        throw new ArgumentException(message);
    }

    public static void Argument(bool value, Action action)
    {
        if (!value)
            action();
    }

    public static void Argument(bool value, Func<bool> func, string message)
    {
        if (!value && !func())
            throw new ArgumentException(message);
    }

    public static void Argument(Func<bool> action, string message)
    {
        if (!action())
            throw new ArgumentException(message);
    }


    private static bool TryClamp(int value, int min, int max) =>
        value == (value < min ? min : value > max ? max : value);

    private static bool TryClamp(float value, float min, float max) =>
        value.Equals(value < min ? min : value > max ? max : value);

    private static bool TryClamp(double value, double min, double max) =>
        value.Equals(value < min ? min : value > max ? max : value);

#if NET7_0_OR_GREATER
    public static void Range<T>(T value, T min, T max, Action<T> action, string message) where T : INumber<T>
    {
        if (!TryClamp(value, min, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range<T>(T value, T max, Action<T> action, string message) where T : INumber<T>
    {
        if (!TryClamp(value, T.Zero, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void RangeArray<T>(T value, T max, Action<T> action, string message) where T : INumber<T>
    {
        if (!TryClamp(value, T.Zero, max - T.One))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Min<T>(T value, T min, Action<T> action, string message) where T : INumber<T>
    {
        if (value < min)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Max<T>(T value, T min, Action<T> action, string message) where T : INumber<T>
    {
        if (value > min)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void MoreThanZero<T>(T value, Action<T> action, string message) where T : INumber<T>
    {
        if (value < T.Zero)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range<T>(T value, T min, T max, Action<T> action) where T : INumber<T>
    {
        if (!TryClamp(value, min, max)) action(value);
    }

    public static void Range<T>(T value, T max, Action<T> action) where T : INumber<T>
    {
        if (!TryClamp(value, T.Zero, max)) action(value);
    }

    public static void RangeArray<T>(T value, T max, Action<T> action) where T : INumber<T>
    {
        if (!TryClamp(value, T.Zero, max - T.One)) action(value);
    }

    public static void Min<T>(T value, T min, Action<T> action) where T : INumber<T>
    {
        if (value < min) action(value);
    }

    public static void Max<T>(T value, T min, Action<T> action) where T : INumber<T>
    {
        if (value > min) action(value);
    }

    public static void MoreThanZero<T>(T value, Action<T> action) where T : INumber<T>
    {
        if (value < T.Zero) action(value);
    }

    public static void Range<T>(T value, T min, T max, string? message = null) where T : INumber<T>
    {
        if (!TryClamp(value, min, max))
            throw new ArgumentOutOfRangeException(message);
    }

    public static void Range<T>(T value, T max, string? message = null) where T : INumber<T>
    {
        if (!TryClamp(value, T.Zero, max))
            throw new ArgumentOutOfRangeException(message);
    }

    public static void RangeArray<T>(T value, T max, string? message = null) where T : INumber<T>
    {
        if (!TryClamp(value, T.Zero, max - T.One))
            throw new ArgumentOutOfRangeException(message);
    }

    public static void Min<T>(T value, T min, string? message = null) where T : INumber<T>
    {
        if (value < min)
            throw new ArgumentOutOfRangeException(message ?? $"Value cant be less than {min}.");
    }

    public static void Max<T>(T value, T min, string? message = null) where T : INumber<T>
    {
        if (value > min)
            throw new ArgumentOutOfRangeException(message ?? $"Value cant be less than {min}.");
    }

    public static void MoreThanZero<T>(T value, string? message = null) where T : INumber<T>
    {
        if (value < T.Zero)
            throw new ArgumentOutOfRangeException(message ?? "Value cant be less than zero.");
    }


    private static bool TryClamp<T>(T value, T min, T max) where T : INumber<T> =>
        value == (value < min ? min : value > max ? max : value);
#endif

    #region Exceptions6.0

    public static void Range(int value, int min, int max, string? message = null)
    {
        if (!TryClamp(value, min, max))
            throw new ArgumentOutOfRangeException(message);
    }

    public static void Range(float value, float min, float max, string? message = null)
    {
        if (!TryClamp(value, min, max))
            throw new ArgumentOutOfRangeException(message);
    }

    public static void Range(double value, double min, double max, string? message = null)
    {
        if (!TryClamp(value, min, max))
            throw new ArgumentOutOfRangeException(message);
    }

    public static void Range(int value, int max, string? message = null)
    {
        if (!TryClamp(value, 0, max))
            throw new ArgumentOutOfRangeException(message);
    }

    public static void Range(double value, double max, string? message = null)
    {
        if (!TryClamp(value, 0, max))
            throw new ArgumentOutOfRangeException(message);
    }

    public static void Range(float value, float max, string? message = null)
    {
        if (!TryClamp(value, 0, max))
            throw new ArgumentOutOfRangeException(message);
    }

    public static void RangeArray(int value, int max, string? message = null)
    {
        if (!TryClamp(value, 0, max - 1))
            throw new ArgumentOutOfRangeException(message);
    }

    public static void Min(int value, int min, string? message = null)
    {
        if (value < min)
            throw new ArgumentOutOfRangeException(message ?? $"Value cant be less than {min}.");
    }

    public static void Min(float value, float min, string? message = null)
    {
        if (value < min)
            throw new ArgumentOutOfRangeException(message ?? $"Value cant be less than {min}.");
    }

    public static void Min(double value, double min, string? message = null)
    {
        if (value < min)
            throw new ArgumentOutOfRangeException(message ?? $"Value cant be less than {min}.");
    }

    public static void Max(int value, int max, string? message = null)
    {
        if (value > max)
            throw new ArgumentOutOfRangeException(message ?? $"Value cant be less than {max}.");
    }

    public static void Max(float value, float max, string? message = null)
    {
        if (value > max)
            throw new ArgumentOutOfRangeException(message ?? $"Value cant be less than {max}.");
    }

    public static void Max(double value, double max, string? message = null)
    {
        if (value > max)
            throw new ArgumentOutOfRangeException(message ?? $"Value cant be less than {max}.");
    }

    public static void MoreThanZero(int value, string? message = null)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(message ?? "Value cant be less than zero.");
    }

    public static void MoreThanZero(float value, string? message = null)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(message ?? "Value cant be less than zero.");
    }

    public static void MoreThanZero(double value, string? message = null)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(message ?? "Value cant be less than zero.");
    }

    #endregion

    #region Actions6.0

    public static void Range(int value, int min, int max, Action<int> action, string message)
    {
        if (!TryClamp(value, min, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range(float value, float min, float max, Action<float> action, string message)
    {
        if (!TryClamp(value, min, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range(double value, double min, double max, Action<double> action, string message)
    {
        if (!TryClamp(value, min, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range(int value, int max, Action<int> action, string message)
    {
        if (!TryClamp(value, 0, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range(double value, double max, Action<double> action, string message)
    {
        if (!TryClamp(value, 0, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range(float value, float max, Action<float> action, string message)
    {
        if (!TryClamp(value, 0, max))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void RangeArray(int value, int max, Action<int> action, string message)
    {
        if (!TryClamp(value, 0, max - 1))
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Min(int value, int min, Action<int> action, string message)
    {
        if (value < min)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Min(float value, float min, Action<float> action, string message)
    {
        if (value < min)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Min(double value, double min, Action<double> action, string message)
    {
        if (value < min)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Max(int value, int max, Action<int> action, string message)
    {
        if (value > max)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Max(float value, float max, Action<float> action, string message)
    {
        if (value > max)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Max(double value, double max, Action<double> action, string message)
    {
        if (value > max)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void MoreThanZero(int value, Action<int> action, string message)
    {
        if (value < 0)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void MoreThanZero(float value, Action<float> action, string message)
    {
        if (value < 0)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void MoreThanZero(double value, Action<double> action, string message)
    {
        if (value < 0)
        {
            action(value);
            throw new ArgumentException(message);
        }
    }

    public static void Range(int value, int min, int max, Action<int> action)
    {
        if (!TryClamp(value, min, max))
            action(value);
    }

    public static void Range(float value, float min, float max, Action<float> action)
    {
        if (!TryClamp(value, min, max))
            action(value);
    }

    public static void Range(double value, double min, double max, Action<double> action)
    {
        if (!TryClamp(value, min, max))
            action(value);
    }

    public static void Range(int value, int max, Action<int> action)
    {
        if (!TryClamp(value, 0, max))
            action(value);
    }

    public static void Range(double value, double max, Action<double> action)
    {
        if (!TryClamp(value, 0, max))
            action(value);
    }

    public static void Range(float value, float max, Action<float> action)
    {
        if (!TryClamp(value, 0, max))
            action(value);
    }

    public static void RangeArray(int value, int max, Action<int> action)
    {
        if (!TryClamp(value, 0, max - 1))
            action(value);
    }

    public static void Min(int value, int min, Action<int> action)
    {
        if (value < min)
            action(value);
    }

    public static void Min(float value, float min, Action<float> action)
    {
        if (value < min)
            action(value);
    }

    public static void Min(double value, double min, Action<double> action)
    {
        if (value < min)
            action(value);
    }

    public static void Max(int value, int max, Action<int> action)
    {
        if (value > max)
            action(value);
    }

    public static void Max(float value, float max, Action<float> action)
    {
        if (value > max)
            action(value);
    }

    public static void Max(double value, double max, Action<double> action)
    {
        if (value > max)
            action(value);
    }

    public static void MoreThanZero(int value, Action<int> action)
    {
        if (value < 0)
            action(value);
    }

    public static void MoreThanZero(float value, Action<float> action)
    {
        if (value < 0)
            action(value);
    }

    public static void MoreThanZero(double value, Action<double> action)
    {
        if (value < 0)
            action(value);
    }

    #endregion
}