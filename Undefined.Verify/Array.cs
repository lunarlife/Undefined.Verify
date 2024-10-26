using System.Collections;
using Undefined.Verifying.Exceptions;
using Undefined.Verifying.Results;

namespace Undefined.Verifying;

public delegate void ArrayIndexVerifyAction(ArrayIndexResult result);

public delegate void ArrayRangeVerifyAction(ArrayRangeResult result);

public static partial class Verify
{
    public static void Array(int index, int arrayLength, string? message = null,
        ArrayIndexVerifyAction? resultAction = null)
    {
        Positive(arrayLength);
        var isPassed = TryClamp(index, 0, arrayLength - 1);
        resultAction?.Invoke(new ArrayIndexResult(isPassed, index, arrayLength));
        if (isPassed) return;
        ThrowArrayIndex(index, arrayLength, message);
    }

    public static void Array(int index, int length, int arrayLength, string? message = null,
        ArrayRangeVerifyAction? resultAction = null) =>
        Array(new Range(index, index + length), arrayLength, message, resultAction);

    public static void Array(Range range, int arrayLength, string? message = null,
        ArrayRangeVerifyAction? resultAction = null)
    {
        var start = range.Start.Value;
        var end = range.End.Equals(Index.End) ? arrayLength : range.End.Value;
        if (arrayLength < 1)
        {
            resultAction?.Invoke(new ArrayRangeResult(false, start, end, arrayLength));
            throw new ArrayRangeException($"Array length cant be less than 0. {message}");
        }

        if (!TryClamp(start, 0, arrayLength - 1))
        {
            resultAction?.Invoke(new ArrayRangeResult(false, start, end, arrayLength));
            throw new ArrayRangeException(
                $"Start index {start} is out of array length (Length: {arrayLength}). {message}");
        }

        if (!TryClamp(end, 0, arrayLength))
        {
            resultAction?.Invoke(new ArrayRangeResult(false, start, end, arrayLength));
            throw new ArrayRangeException(
                $"End index {end} is out of array length (Length: {arrayLength}). {message}");
        }

        resultAction?.Invoke(new ArrayRangeResult(true, start, end, arrayLength));
    }

    public static void Array(IList list, int index, string? message = null,
        ArrayIndexVerifyAction? resultAction = null) =>
        Array(index, list.Count, message, resultAction);

    public static void Array(IList list, Range range, string? message = null,
        ArrayRangeVerifyAction? resultAction = null) =>
        Array(range, list.Count, message, resultAction);

    public static void Array(IList list, int start, int length, string? message = null,
        ArrayRangeVerifyAction? resultAction = null) =>
        Array(start, length, list.Count, message, resultAction);

    public static void VerifyArray(this IList list, int index, string? message = null,
        ArrayIndexVerifyAction? exceptionAction = null) => Array(list, index, message, exceptionAction);

    public static void VerifyArray(this IList list, Range range, string? message = null,
        ArrayRangeVerifyAction? exceptionAction = null) => Array(list, range, message, exceptionAction);

    public static void VerifyArray(this IList list, int start, int length, string? message = null,
        ArrayRangeVerifyAction? exceptionAction = null) => Array(list, start, length, message, exceptionAction);

    public static void ThrowArrayIndex(int index, int arrayLength, string? message) =>
        throw new ArrayIndexException(index, arrayLength, message);

    public static void ThrowArrayRange(int start, int end, int arrayLength, string? message) =>
        throw new ArrayRangeException(start, end, arrayLength, message);

    public static void ThrowArrayRange(Range range, int arrayLength, string? message) =>
        throw new ArrayRangeException(range.Start.Value, range.End.Value, arrayLength, message);
}