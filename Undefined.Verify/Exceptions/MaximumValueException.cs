namespace Undefined.Verifying.Exceptions;

public class MaximumValueException : Exception
{
    public MaximumValueException(object value, object max, string? message) : base(
        $"Value {value} is out of range (Maximum: {max}). {message}")
    {
    }
}