namespace Undefined.Verifying.Exceptions;

public class ArgumentNotPassedException : Exception
{
    public ArgumentNotPassedException(string? message) : base(message ?? "Argument failed.")
    {
    }
}