namespace Undefined.Verifying.Results;

public struct ArrayIndexResult : IResult
{
    public bool IsPassed { get; }
    public int Index { get; }
    public int ArrayLength { get; }

    public ArrayIndexResult(bool isPassed, int index, int arrayLength)
    {
        IsPassed = isPassed;
        Index = index;
        ArrayLength = arrayLength;
    }
}