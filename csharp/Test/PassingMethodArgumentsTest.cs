using NUnit.Framework;
using System;
using Tasks;

namespace Test
{
    [TestFixture]
    public class PassingMethodArgumentsTest
    {
        PassingMethodArguments underTest = new PassingMethodArguments();

        [Test]
        public void Test1()
        {
            var actual = underTest.Method1();
            Console.WriteLine(actual);

        }
    }
}