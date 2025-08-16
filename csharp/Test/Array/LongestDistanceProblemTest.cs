using Tasks.ArrayTasks;
using NUnit.Framework;

namespace Test.Array
{
    [TestFixture]
    public class LongestDistanceProblemTest
    {
        [TestCase(3, new[] { 2, 6, 8, 5 })]
        [TestCase(4, new[] { 1, 5, 5, 2, 6 })]
        [TestCase(2, new[] { 1, 1 })]
        public void Test1(int expected, int[] input)
        {
            var underTest = new LongestDistanceProblem();

            var actual = underTest.Run(input);

            Assert.Equals(expected, actual);
        }
    }
}