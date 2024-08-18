namespace Undefined.Verifying.Exceptions;

public class EqualsException : Exception
{
    public EqualsException(string? message) : base($"Objects must not be equal. {message}")
    {
    }
}