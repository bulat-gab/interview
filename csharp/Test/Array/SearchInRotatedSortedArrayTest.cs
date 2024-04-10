using Arrays;
using NUnit.Framework;

namespace Test.Array
{
    [TestFixture]
    public class SearchInRotatedSortedArrayTest
    {
        SearchInRotatedSortedArray underTest = new SearchInRotatedSortedArray();
        [Test]
        public void Test1()
        {
            var arr = new int[] {5, 6, 7, 8, 9, 10, 1, 2, 3};
            var key = 3;
            var actual = underTest.Search(arr, key);
            
            Assert.Equals(8, actual);
        }
    }
}