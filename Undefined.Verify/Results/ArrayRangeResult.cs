namespace Undefined.Verifying.Results;

public struct ArrayRangeResult : IResult
{
    public bool IsPassed { get; }
    public int Index { get; }
    public int Max { get; }

    public ArrayRangeResult(bool isPassed, int index, int max)
    {
        IsPassed = isPassed;
        Index = index;
        Max = max;
    }
}