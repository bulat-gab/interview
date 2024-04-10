using NUnit.Framework;
using Tasks.Graph;

namespace Test.Graph
{
    [TestFixture]
    public class MainTest
    {
        private readonly Main _underTest = new Main();

        [TestCase(true, "eat")]
        [TestCase(false, "eattt")]
        [TestCase(true, "oath")]
        public void METHOD(bool expected, string word)
        {
            var grid = new[]
            {
                new[] {'o', 'a', 'a', 'n'},
                new[] {'e', 't', 'a', 'e'},
                new[] {'i', 'h', 'k', 'r'},
                new[] {'i', 'f', 'l', 'v'}
            };

            var actual = _underTest.FindWordOnTheGrid(grid, word);
            Assert.Equals(expected, actual);
        }
    }
}