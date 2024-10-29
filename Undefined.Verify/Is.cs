using Undefined.Verifying.Exceptions;

namespace Undefined.Verifying;

public static partial class Verify
{
    public static void Is<T>(this object value, string? message = null) => Is(value, typeof(T), message);

    public static void Is(this object value, Type type, string? message = null)
    {
        if (value.GetType() != type) throw new IsNotException(value.GetType(), type, message);
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

    public static void InstanceOf<T>(this object value, string? message = null) =>
        InstanceOf(value, typeof(T), message);

    public static void InstanceOf(this object value, Type type, string? message = null)
    {
        if (type.IsInstanceOfType(value)) throw new NotInstanceOfException(value.GetType(), type, message);
    }
}