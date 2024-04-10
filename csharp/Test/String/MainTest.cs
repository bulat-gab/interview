using NUnit.Framework;
using Tasks.String;

namespace Test.String
{
    [TestFixture]
    public class MainTest
    {
        private readonly Main _underTest = new Main();
        
        [TestCase("blue is sky the", "the sky is blue")]
        [TestCase("world hello", "  hello world  ")]
        [TestCase("example good a", "a good   example")]
        [TestCase("Alice Loves Bob", "  Bob    Loves  Alice   ")]
        public void ReverseWordsTest(string expected, string input)
        {
            var actual = _underTest.ReverseWords(input);
            
            Assert.Equals(expected, actual);
        }
        
        // [TestCase("the sky is blue", "the sky is blue")]
        // [TestCase("hello world", "  hello world  ")]
        // [TestCase("a good example", "a good   example")]
        // [TestCase("Bob Loves Alice", "  Bob    Loves  Alice   ")]
        // public void ReverseWordsTest(string expected, string input)
        // {
        //     var actual = _underTest.ReverseWords(input);
        //     
        //     Assert.Equals(expected, actual);
        // }
    }
}