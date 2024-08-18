namespace Undefined.Verifying.Exceptions;

public class ArrayIndexException : Exception
{
    public ArrayIndexException(int index, int arraySize, string? message) : base(index < 0
        ? $"Array index cant be less than 0. {message}"
        : $"Index {index} is out of array (Length: {arraySize}). {message}")
    {
    }
}