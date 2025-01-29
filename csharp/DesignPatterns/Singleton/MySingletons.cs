using NUnit.Framework;

namespace DesignPatterns.Singleton;

public class LazySingleton
{
    private static readonly Lazy<LazySingleton> _instance = new(() => new LazySingleton());
    private LazySingleton() { }
    
    public static LazySingleton Instance => _instance.Value;
    
    public void BusinessLogic() {
        Console.WriteLine($"{GetType().Name} BusinessLogic() called");
    }
}

public class ThreadSafeSingleton
{
    private static readonly object _lock = new();
    private static ThreadSafeSingleton _instance;

    public static ThreadSafeSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ThreadSafeSingleton();
                    }
                }
            }
            return _instance;
        }
    }
}




[TestFixture]
public class SingletonTests
{
    [Test]
    public void TestLazySingleton()
    {
        LazySingleton ls1 = LazySingleton.Instance;
        LazySingleton ls2 = LazySingleton.Instance;
        
        Assert.That(ls1 == ls2);
    }

    [Test]
    public void TestThreadSafeSingleton()
    {
        ThreadSafeSingleton ts1 = ThreadSafeSingleton.Instance;
        ThreadSafeSingleton ts2 = ThreadSafeSingleton.Instance;
        
        Assert.That(ts1 == ts2);
    }
}