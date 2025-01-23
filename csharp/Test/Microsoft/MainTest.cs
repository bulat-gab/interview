using NUnit.Framework;
using System;
using Tasks.Microsoft;

namespace Test.Microsoft
{
    [TestFixture]
    public class MainTest
    {
        private Codility _underTest;
        private Tasks.Microsoft.Solution _solution;

        [SetUp]
        public void SetUp()
        {
            _underTest = new Codility();
            _solution = new Tasks.Microsoft.Solution();
        }

        // [TestCase(1, new int[] { })]
        // [TestCase(1, new int[] {  } )]
        // public void Test1(int expected, int[] input)
        // {
        //     var actual = _underTest.FindCheese(input);
        //
        //     Assert.Equals(expected, actual);
        // }


        [Test]
        public void Test3()
        {
            var values = Enum.GetValues(typeof(Direction));
        }
    }
}