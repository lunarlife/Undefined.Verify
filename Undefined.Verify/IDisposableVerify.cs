namespace Undefined.Verifying;

public interface IDisposableVerify : IDisposable
{
    public bool IsDisposed { get; }
}