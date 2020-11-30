using System;
using System.Linq;
using NUnit.Framework;
using Tasks.String;

namespace Test.String
{
    [TestFixture]
    public class ReplaceQuestionMarksTest
    {
        private readonly ReplaceQuestionMarks underTest = new ReplaceQuestionMarks();
        private char[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();

        [TestCase("xy?xz")]
        [TestCase("ab?e?mr??")]
        [TestCase("??????")]
        [TestCase("?z?")]
        public void Test1(string input)
        {
            var actual = underTest.Run(input);
            Console.WriteLine(actual);
            
            Assert.NotNull(actual);
            Assert.AreEqual(input.Length, actual.Length);
            for (int i = 0; i < input.Length - 1; i++)
            {
                Assert.AreNotEqual(actual[i], actual[i + 1]);
                CollectionAssert.Contains(_alphabet, actual[i]);
            }
        }
    }
}