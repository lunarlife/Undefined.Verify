namespace Undefined.Verifying.Exceptions;

public class MinimumValueException : Exception
{
    public MinimumValueException(object value, object min, string? message) : base(
        $"Value {value} is out of range (Minimum: {min}). {message}")
    {
    }
}