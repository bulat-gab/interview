namespace DesignPatterns.Adapter;

public interface ITarget
{
    string GetRequest();
}


// Contains functionality that our code need to use, but its interface is incompatible
public class Adaptee
{
    public string GetSpecificRequest()
    {
        return $"Specific request.";
    }
}

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public string GetRequest()
    {
        return $"This is '{_adaptee.GetSpecificRequest()}'";
    }
}

public class ApplicationCode
{
    public static void RunAdapterExample()
    {
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);

        var result = target.GetRequest();
        Console.WriteLine(result);
    }
}