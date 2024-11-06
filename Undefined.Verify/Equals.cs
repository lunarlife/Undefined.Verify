using Undefined.Verifying.Exceptions;

namespace Undefined.Verifying;

using NullReferenceException = Exceptions.NullReferenceException;

public static partial class Verify
{
    public static T NotNull<T>(T? value, string? message = null) =>
        value is null ? throw new NullReferenceException(message) : value;

    public static T NotNull<T>(T? value, string? message = null) where T : struct
    {
        if (value is null)
            throw new NullReferenceException(message);
        return value.Value;
    }

    public static object NotNull(object? value, string? message = null) =>
        value ?? throw new NullReferenceException(message);

    public static void MustBeNull<T>(T? value, string? message = null)
    {
        if (value is null)
            return;
        throw new NonNullReferenceException(message);
    }

    public static void MustBeNull<T>(T? value, string? message = null) where T : struct
    {
        if (value is null)
            return;
        throw new NonNullReferenceException(message);
    }

    public static void MustBeNull(object? value, string? message = null)
    {
        if (value is null)
            return;
        throw new NonNullReferenceException(message);
    }

    public static void Equals(object? value1, object? value2, string? message = null)
    {
        if (ReferenceEquals(value1, value2)) return;
        if (value1 is not null && value1.Equals(value2)) return;
        throw new NotEqualsException(value1, value2, message);
    }

    public static void Equals<T>(T? value1, T? value2, string? message = null) =>
        Equals((object?)value1, value2, message);
    
    public static void EqualsOrNull(object? value1, object? value2, string? message = null)
    {
        if(value1 is null || value2 is null) return;
        if (ReferenceEquals(value1, value2)) return;
        if (value1.Equals(value2)) return;
        throw new NotEqualsException(value1, value2, message);
    }

    public static void EqualsOrNull<T>(T? value1, T? value2, string? message = null) =>
        Equals((object?)value1, value2, message);

    public static void Equals<T>(T? value1, T? value2, string? message = null) where T : struct
    {
        if (value1.HasValue == value2.HasValue) return;
        if (value1 is not null && value1.Equals(value2)) return;
        throw new NotEqualsException(value1, value2, message);
    }

    public static void NotEquals(object? value1, object? value2, string? message = null)
    {
        if (!ReferenceEquals(value1, value2)) return;
        if (value1 is null || !value1.Equals(value2)) return;
        throw new EqualsException(value1, value2, message);
    }

    public static void NotEquals<T>(T? value1, T? value2, string? message = null) =>
        NotEquals((object?)value1, value2, message);

    public static void NotEquals<T>(T? value1, T? value2, string? message = null) where T : struct
    {
        if (value1.HasValue != value2.HasValue) return;
        if (value1 is null || !value1.Equals(value2)) return;
        throw new EqualsException(value1, value2, message);
    }

    public static void VerifyEquals<T, T1>(this T? value1, T1? value2, string? message = null) =>
        Equals(value1, value2, message);

    public static void VerifyEquals<T>(this T? value1, T? value2, string? message = null) where T : struct =>
        Equals(value1, value2, message);

    public static void VerifyEqualsOrNull<T, T1>(this T? value1, T1? value2, string? message = null) =>
        Equals(value1, value2, message);

    public static void VerifyEqualsOrNull<T>(this T? value1, T? value2, string? message = null) where T : struct =>
        Equals(value1, value2, message);

    public static void VerifyNotEquals<T, T1>(this T? value1, T1? value2, string? message = null) =>
        NotEquals(value1, value2, message);

    public static void VerifyNotEquals<T, T1>(this T? value1, T1? value2, string? message = null) where T : struct =>
        NotEquals(value1, value2, message);
}