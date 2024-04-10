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
            
            Assert.That(actual, Is.Not.Null);
            Assert.Equals(input.Length, actual.Length);
            for (int i = 0; i < input.Length - 1; i++)
            {
                Assert.That(actual[i], Is.Not.EqualTo(actual[i + 1]));
                Assert.That(_alphabet, Has.Member(actual[i]));

            }
        }
    }
}