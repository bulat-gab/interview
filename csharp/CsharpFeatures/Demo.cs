using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
