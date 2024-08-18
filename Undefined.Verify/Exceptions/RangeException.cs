namespace Undefined.Verifying.Exceptions;

public class RangeException : Exception
{
    public RangeException(object value, object min, object max, string? message) : base(
        $"Value {value} is out of range (Range: {min}..{max}). {message}")
    {
    }
}