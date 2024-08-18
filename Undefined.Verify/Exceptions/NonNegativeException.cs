namespace Undefined.Verifying.Exceptions;

public class NonNegativeException : Exception
{
    public NonNegativeException(object value, string? message) : base(
        $"Value {value} must be non-negative. {message}")
    {
    }
}