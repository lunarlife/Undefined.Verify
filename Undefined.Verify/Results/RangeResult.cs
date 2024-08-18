using System.Numerics;

namespace Undefined.Verifying.Results;

public struct RangeResult<T> : IResult where T : struct
#if NET7_0_OR_GREATER
    , INumber<T>
#endif
{
    public bool IsPassed { get; }
    public T Value { get; }
    public T Min { get; }
    public T Max { get; }

    public RangeResult(bool isPassed, T value, T min, T max)
    {
        IsPassed = isPassed;
        Value = value;
        Max = max;
        Min = min;
    }
}