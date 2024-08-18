using System.Numerics;

namespace Undefined.Verifying.Results;

public struct MaxResult<T> : IResult where T : struct
#if NET7_0_OR_GREATER
    , INumber<T>
#endif
{
    public bool IsPassed { get; }
    public T Value { get; }
    public T Max { get; }

    public MaxResult(bool isPassed, T value, T max)
    {
        IsPassed = isPassed;
        Value = value;
        Max = max;
    }
}