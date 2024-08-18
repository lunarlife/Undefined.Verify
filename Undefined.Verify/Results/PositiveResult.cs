using System.Numerics;

namespace Undefined.Verifying.Results;

public struct PositiveResult<T> : IResult where T : struct
#if NET7_0_OR_GREATER
    , INumber<T>
#endif
{
    public bool IsPassed { get; }
    public T Value { get; }

    public PositiveResult(bool isPassed, T value)
    {
        IsPassed = isPassed;
        Value = value;
    }
}