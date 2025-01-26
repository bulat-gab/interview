using System;

namespace Tasks.SDG;

// Task 1
class A
{
    public string Property { get; set; }
}

class B
{
    void Do()
    {
        // Won't compile, A must implement IDisposable
        /*
        using (var a = new A() { Property = "A" })
        {
            Console.WriteLine(a.Property);
        }
        */
    }
}


// Task 2
abstract class AbstractClass2 // default access modifier within namespace is 'internal'
{
    public abstract int Prop { get; set; }
}

// Won't compile Derived is public while AbstractClass2 is internal
// public class Derived : AbstractClass2
// {
// }