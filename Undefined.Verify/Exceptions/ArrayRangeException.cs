namespace Undefined.Verifying.Exceptions;

public class ArrayRangeException : Exception
{
    public ArrayRangeException(int index, int arraySize, string? message) : base(index < 0
        ? $"Array index cant be less than 0. {message}"
        : $"Index {index} is out of array (Size: {arraySize}). {message}")
    {
    }
}