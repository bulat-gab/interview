using System;
using NUnit.Framework;
using Tasks.Microsoft;

namespace Test.Microsoft
{
    [TestFixture]
    public class MainTest
    {
        private Codility _underTest;
        private CodilityOptimized _codilityOptimized;

        [SetUp]
        public void SetUp()
        {
            _underTest = new Codility();
            _codilityOptimized = new CodilityOptimized();
        }
        
        // [TestCase(1, new int[] { })]
        // [TestCase(1, new int[] {  } )]
        // public void Test1(int expected, int[] input)
        // {
        //     var actual = _underTest.FindCheese(input);
        //
        //     Assert.AreEqual(expected, actual);
        // }

        [Test]
        public void Test2()
        {
            _codilityOptimized.FindCheese(new Maze());
        }

        [Test]
        public void Test3()
        {
            var values = Enum.GetValues(typeof(Direction));
        }
    }
}