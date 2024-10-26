using Undefined.Verifying.Exceptions;

namespace Undefined.Verifying;

public delegate void ArgumentVerifyAction(bool isPassed);

public static partial class Verify
{
#if NEW_FEATURES
    [StackTraceHidden]
#endif
    private static void ArgumentInternal(bool value, string? message, Func<bool>? additionalTest, Action? passedAction,
        Action? notPassedAction)
    {
        if (value || (additionalTest?.Invoke() ?? false))
            passedAction?.Invoke();
        else
        {
            notPassedAction?.Invoke();
            ThrowArgumentNotPassed(message);
        }
    }

    public static void ThrowArgumentNotPassed(string? message) => throw new ArgumentNotPassedException(message);


    public static void Argument(bool value, string? message = null, ArgumentVerifyAction? resultAction = null)
    {
        resultAction?.Invoke(value);
        if (!value)
            throw new ArgumentNotPassedException(message);
    }

    public static void Argument(bool value, string message, Action passedAction,
        Action notPassedAction) =>
        ArgumentInternal(value, message, null, passedAction, notPassedAction);

    public static void ArgumentFunc(bool value, Func<bool> additionalTest) =>
        ArgumentInternal(value, null, additionalTest, null, null);

    public static void ArgumentFunc(bool value, string message, Func<bool> additionalTest) =>
        ArgumentInternal(value, message, additionalTest, null, null);

    public static void ArgumentFunc(bool value, string message, Func<bool> additionalTest, Action passedAction,
        Action notPassedAction) =>
        ArgumentInternal(value, message, additionalTest, passedAction, notPassedAction);
}