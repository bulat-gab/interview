namespace CsharpFeatures;

public class SemaphoreSlimExample
{
    private int _count = 0;

    private readonly SemaphoreSlim _semaphore = new(2);

    public async Task RunExample()
    {
        var t1 = DoWorkAsync("one");
        var t2 = DoWorkAsync("two");

        await Task.WhenAll(t1, t2);
    }

    public async Task DoWorkAsync(string taskName, CancellationToken cancellationToken = default)
    {
        await _semaphore.WaitAsync(cancellationToken);
        try
        {
            _count++;

            await Task.Delay(1000, cancellationToken);

            Console.WriteLine($"DoWorkAsync '{taskName}' completed. Count: {_count}");
        }
        finally
        {
            _semaphore.Release();
        }

    }
}