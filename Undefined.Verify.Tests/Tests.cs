using NUnit.Framework;
using Undefined.Verifying.Exceptions;
using NullReferenceException = Undefined.Verifying.Exceptions.NullReferenceException;

namespace Undefined.Verifying.Tests;

public class Tests
{
    public const int ARGUMENT_VALUE = 10;
    public const string EQUALS_VALUE = "Hello!";
    
    [Test]
    public void ArgumentTest()
    {
        Assert.Catch<NullReferenceException>(() => TryArgument(null));
        Assert.Catch<ArgumentNotPassedException>(() => TryArgument([1, 0, 5]));
        TryArgument([1, ARGUMENT_VALUE, 5]);
        Assert.Pass();
    }

    [Test]
    public void EqualsTest()
    {
        Assert.Catch<NotEqualsException>(() => TreEquals("Hey"));
        TreEquals(EQUALS_VALUE);
        Assert.Pass();
    }

    [Test]
    public void RangeTest()
    {
        Assert.Catch<RangeException>(() => TryRange(1.44));
        Assert.Catch<RangeException>(() => TryRange(3.15));
        TryRange(1.5);
        TryRange(3);
        TryRange(1.98);
        Assert.Pass();
    }

    [Test]
    public void ArrayTest()
    {
        float[] array = [1, 2, 3, 4, 5, 6];
        Assert.Catch<ArrayRangeException>(() => TryArray(array, 6));
        Assert.Catch<ArrayRangeException>(() => TryArray(array, -1));
        TryArray(array, 0);
        TryArray(array, 3);
        TryArray(array, array.Length - 1);
        Assert.Pass();
    }

    public void TreEquals(string other)
    {
        Verify.Equals(other, EQUALS_VALUE, "You are not friendly :(");
        other.VerifyEquals(EQUALS_VALUE, "I was offended");
    }

    public void TryArgument(IReadOnlyList<int>? list)
    {
        Verify.NotNull(list);
        Verify.Argument(list!.Contains(ARGUMENT_VALUE), "Nope");
    }

    public float TryArray(float[] array, int i)
    {
        array.VerifyArray(i);
        return array[i];
    }

    public void TryRange(double value)
    {
        Verify.Range(value, 1.5, 3);
    }
}