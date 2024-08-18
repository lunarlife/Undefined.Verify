using System.Numerics;

namespace Undefined.Verifying.Results;

public struct MinResult<T> : IResult where T : struct
#if NET7_0_OR_GREATER
    , INumber<T>
#endif
{
    public bool IsPassed { get; }
    public T Value { get; }
    public T Min { get; }

    public MinResult(bool isPassed, T value, T min)
    {
        IsPassed = isPassed;
        Value = value;
        Min = min;
    }
}