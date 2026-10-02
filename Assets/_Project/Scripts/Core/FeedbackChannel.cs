using System;

public static class FeedbackChannel
{
    public static event Action<string> MessageRaised;

    public static void Show(string message)
    {
        MessageRaised?.Invoke(message);
    }
}