using System;

namespace Tasks
{
    public class PassingMethodArguments
    {

        ~PassingMethodArguments()
        {
            Console.WriteLine("Destructor call");
        }

        public int Method1()
        {
            int a = 5;

            int newA = Method2(ref a);
            return newA;
        }

        public int Method2(ref int arg)
        {
            arg = 6;
            return arg;
        }
    }
}