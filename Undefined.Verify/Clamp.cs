using System.Numerics;

namespace Undefined.Verifying;

public static partial class Verify
{
    private static bool TryClamp(int value, int min, int max) =>
        value == (value < min ? min : value > max ? max : value);

    private static bool TryClamp(uint value, uint min, uint max) =>
        value == (value < min ? min : value > max ? max : value);

    private static bool TryClamp(long value, long min, long max) =>
        value == (value < min ? min : value > max ? max : value);

    private static bool TryClamp(ulong value, ulong min, ulong max) =>
        value == (value < min ? min : value > max ? max : value);

    private static bool TryClamp(float value, float min, float max) =>
        value.Equals(value < min ? min : value > max ? max : value);

    private static bool TryClamp(double value, double min, double max) =>
        value.Equals(value < min ? min : value > max ? max : value);

#if NET7_0_OR_GREATER

    private static bool TryClamp<T>(T value, T min, T max) where T : INumber<T> =>
        value == (value < min ? min : value > max ? max : value);
#endif
}