namespace DesignPatterns.AbstractFactory;


// Abstract Products
public interface IButton
{
    void Render();
}

public interface ICheckbox
{
    void Check();
}

// Concrete Products
public class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows style button");
    }
}

public class MacOsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Mac OS style button");
    }
}

public class WindowsCheckbox : ICheckbox
{
    public void Check()
    {
        Console.WriteLine("Checking Windows style checkbox");
    }
}

public class MasOsCheckbox : ICheckbox
{
    public void Check()
    {
        Console.WriteLine("Checking Mass OS style checkbox");
    }
}

// Abstract Factory
public interface IUiFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete Factories
public class WindowsUiFactory : IUiFactory
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new WindowsCheckbox();
    }
}

public class MacOsUiFactory : IUiFactory
{
    public IButton CreateButton()
    {
        return new MacOsButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MasOsCheckbox();
    }
}

// Application code does not depend on concrete factory
public class AbstractFactoryUiLibraryExample
{
    private readonly IButton _button;
    private readonly ICheckbox _checkbox;

    public AbstractFactoryUiLibraryExample(IUiFactory factory)
    {
        _button = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void RenderUi()
    {
        _button.Render();
        _checkbox.Check();
    }

    // Static method to demonstract an example
    public static void RunAbstractFactoryUiLibraryExample()
    {
        IUiFactory factory;
        
        string os = Environment.OSVersion.ToString();
        if (os.Contains("Win"))
            factory = new WindowsUiFactory();
        else
            factory = new MacOsUiFactory();
        
        var demoApp = new AbstractFactoryUiLibraryExample(factory);
        demoApp.RenderUi();
    }
}
/*
 * Output:
 * 
Rendering Windows style button
Checking Windows style checkbox
*/