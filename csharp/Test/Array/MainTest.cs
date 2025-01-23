using Arrays;
using NUnit.Framework;

namespace Test.Array
{
    [TestFixture]
    public class MainTest
    {
        private Main _underTest = new Main();

        [Test]
        public void LargestKTest()
        {
            var arr = new int[] { 3, 2, -2, 5, -3 };

            var actual = _underTest.LargestK(arr);

            Assert.Equals(3, actual);
        }

        [Test]
        public void TwoElementsDifferBy1Test()
        {
            var arr = new int[] { 11, 1, 8, 12, 14 };

            var actual = _underTest.TwoElementsDifferBy1(arr);

            Assert.Equals(true, actual);
        }

        [Test]
        public void LargestXOccuringXTimesTest()
        {
            var arr = new int[] { 3, 8, 2, 3, 3, 2 };

            var actual = _underTest.LargestXOccuringXTimes(arr);

            Assert.Equals(3, actual);
        }
    }
}