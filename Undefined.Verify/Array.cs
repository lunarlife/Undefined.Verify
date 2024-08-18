using System.Collections;
using Undefined.Verifying.Exceptions;
using Undefined.Verifying.Results;

namespace Undefined.Verifying;
    
public delegate void ArrayRangeVerifyAction(ArrayRangeResult result);

public static partial class Verify
{
    public static void Array(int index, int max, string? message = null, ArrayRangeVerifyAction? resultAction = null)
    {
        var isPassed = TryClamp(index, 0, max - 1);
        resultAction?.Invoke(new ArrayRangeResult(isPassed, index, max));
        if (isPassed) return;
        ThrowArrayRange(index, max, message);
    }

    public static void Array(int index, IList list, string? message = null,
        ArrayRangeVerifyAction? resultAction = null) =>
        Array(index, list.Count, message, resultAction);

    public static void VerifyArray(this IList list, int index, string? message = null,
        ArrayRangeVerifyAction? exceptionAction = null) => Array(index, list, message, exceptionAction);

    public static void ThrowArrayRange(int index, int max, string? message) =>
        throw new ArrayRangeException(index, max, message);
}