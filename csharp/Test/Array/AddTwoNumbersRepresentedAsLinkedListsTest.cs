using System.Collections.Generic;
using Arrays;
using NUnit.Framework;

namespace Test.Array
{
    [TestFixture]
    public class AddTwoNumbersRepresentedAsLinkedListsTest
    {
        [Test]
        public void Test1()
        {
            var first = new Arrays.LinkedListNode<int>(5)
            {
                Next = new Arrays.LinkedListNode<int>(6)
                {
                    Next = new Arrays.LinkedListNode<int>(3)
                }
            };
            
            var second = new Arrays.LinkedListNode<int>(8)
            {
                Next = new Arrays.LinkedListNode<int>(4)
                {
                    Next = new Arrays.LinkedListNode<int>(2)
                }
            };
            
            // var expected = new Arrays.LinkedListNode<int>(1)
            // {
            //     Next = new Arrays.LinkedListNode<int>(4)
            //     {
            //         Next = new Arrays.LinkedListNode<int>(0)
            //         {
            //             Next = new Arrays.LinkedListNode<int>(5)
            //         }
            //     }
            // };
            var underTest = new AddTwoNumbersRepresentedAsLinkedLists();

            var actual = underTest.Sum(first, second);
            Assert.AreEqual(1, actual.Value);
            Assert.AreEqual(4, actual.Next.Value);
            Assert.AreEqual(0, actual.Next.Next.Value);
            Assert.AreEqual(5, actual.Next.Next.Next.Value);
        }
    }
}