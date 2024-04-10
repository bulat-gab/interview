using Arrays;
using NUnit.Framework;

namespace Test.Array
{
    public class MaxSumPairTest
    {
        
        [Test]
        public void Test1()
        {
            var underTest = new MaxSumPair();
            var input = new []  {55, 23, 32, 46, 88};

            var actual = underTest.Run(input);
            
            Assert.Equals(101, actual);
        }
    }
}