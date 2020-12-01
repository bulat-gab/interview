using FluentAssertions;
using NUnit.Framework;
using Tasks.Tree;

namespace Test.String
{
    [TestFixture]
    public class TrieTest
    {
        private Trie _trie;

        [SetUp]
        public void SetUp()
        {
            _trie = new Trie();
        }

        [Test]
        public void Test1()
        {
            _trie.Insert("apple");
            _trie.Search("apple").Should().BeTrue();
            _trie.Search("app").Should().BeFalse();
            _trie.StartsWith("app"); // returns true
            _trie.Insert("app");
            _trie.Search("app").Should().BeTrue();
        }
    }
}