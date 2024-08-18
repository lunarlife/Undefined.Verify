namespace Undefined.Verifying.Exceptions;

public class PositiveException : Exception
{
    public PositiveException(object value, string? message) : base($"Value {value} is not positive. {message}")
    {
    }
}