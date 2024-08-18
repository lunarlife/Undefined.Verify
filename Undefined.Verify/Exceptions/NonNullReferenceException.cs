namespace Undefined.Verifying.Exceptions;

public class NonNullReferenceException : Exception
{
    public NonNullReferenceException(string? message) : base($"Reference must be null. {message}")
    {
    }
}