using Undefined.Verifying.Exceptions;

namespace Undefined.Verifying;

public static partial class Verify
{
    public static T Is<T>(this object value, string? message = null)
    {
        return (T)Is(value, typeof(T), message);
    }

    public static object Is(this object value, Type type, string? message = null)
    {
        if (value.GetType() != type) throw new IsNotException(value.GetType(), type, message);
        return value;
    }


    public static void IsNot(this object value, params Type[] types)
    {
        for (var i = 0; i < types.Length; i++)
            if (value.GetType() == types[i])
                throw new IsException(value.GetType(), types, null);
    }

    public static void IsNot(this object value, string message, params Type[] types)
    {
        for (var i = 0; i < types.Length; i++)
            if (value.GetType() == types[i])
                throw new IsException(value.GetType(), types, message);
    }

    public static void IsNot<T>(this object value, string? message = null) => IsNot(value, typeof(T), message);

    public static void IsNot(this object value, Type type, string? message = null)
    {
        if (value.GetType() == type) throw new IsException(type, message);
    }

    public static T InstanceOf<T>(this object value, string? message = null) =>
        (T)InstanceOf(value, typeof(T), message);

    public static object InstanceOf(this object value, Type type, string? message = null)
    {
        if (type.IsInstanceOfType(value)) throw new NotInstanceOfException(value.GetType(), type, message);
        return value;
    }
}