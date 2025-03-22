namespace Undefined.Verifying;

public static partial class Verify
{
    public static void CheckDisposed(bool isDisposed)
    {
        if (isDisposed)
            throw new ObjectDisposedException("Object has been disposed.");
    }

    public static void CheckDisposed(IDisposableVerify disposable)
    {
        if (disposable.IsDisposed)
            throw new ObjectDisposedException($"{disposable.GetType().FullName} has been disposed.");
    }
}