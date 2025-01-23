using System.Runtime.CompilerServices;

namespace CsharpFeatures;

public class CustomAwaitable : INotifyCompletion
{
    private bool _isCompleted = false;
    public bool IsCompleted => _isCompleted;

    public CustomAwaitable GetAwaiter() => this;

    public void OnCompleted(Action continuation)
    {
        Task.Delay(1000).ContinueWith(t =>
        {
            _isCompleted = true;
            continuation?.Invoke();
        });
    }

    public int GetResult() => 42;
}
