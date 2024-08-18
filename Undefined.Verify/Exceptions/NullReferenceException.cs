namespace Undefined.Verifying.Exceptions;

public class NullReferenceException : Exception
{
    public NullReferenceException(string? message) : base($"Reference missing. {message}")
    {
    }
}