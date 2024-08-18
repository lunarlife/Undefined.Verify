namespace Undefined.Verifying.Results;

public struct ArrayRangeResult : IResult
{
    public bool IsPassed { get; }
    public int Start { get; }
    public int End { get; }
    public int ArrayLength { get; }

    public ArrayRangeResult(bool isPassed, int start, int end, int arrayLength)
    {
        IsPassed = isPassed;
        Start = start;
        End = end;
        ArrayLength = arrayLength;
    }
}