namespace Undefined.Verifying.Exceptions;

public class ArrayRangeException : Exception
{
    public ArrayRangeException(int start, int end, int arrayLength, string? message) : base($"Range ({start}..{end}) is out of array (Length: {arrayLength}). {message}")
    {
    }

    public ArrayRangeException(string message) : base(message)
    {
        
    }
}