namespace CsharpFeatures;

internal class Demo
{
    public static void CheckObject()
    {
        dynamic x = 10;
        x = x + 10;

        Console.WriteLine($"First: {x}");

        x = "hello";
        Console.WriteLine($"Second: {x}");
    }
}
