using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace Interview
{
    public class DataClass
    {
        public static IEnumerable SimpleTestCases
        {
            get
            {
                yield return new TestCaseData("Zero", "Zero").Returns(0);
                yield return new TestCaseData("One", "Zero").Returns(1);
                yield return new TestCaseData("Zero", "One").Returns(-1);
                yield return new TestCaseData("One", "Two").Returns(-1);
                yield return new TestCaseData("One", "One").Returns(0);
                yield return new TestCaseData("OneTwo", "TwoOne").Returns(-1);
                yield return new TestCaseData("OneZero", "One").Returns(1);
                yield return new TestCaseData("OneEight", "Nine").Returns(1);
                yield return new TestCaseData("OneNine", "TwoEight").Returns(-1);
                yield return new TestCaseData("SixNine", "TwoNine").Returns(1);
                yield return new TestCaseData("FiveSixOne", "SixFourOne").Returns(-1);
                yield return new TestCaseData("OneZero", "OneOne").Returns(-1);
                yield return new TestCaseData("ThreeTwo", "Four").Returns(1);
                yield return new TestCaseData("OneZeroSeven", "OneZeroSix").Returns(1);
                yield return new TestCaseData("Eight", "Nine").Returns(-1);
                yield return new TestCaseData("Four", "Five").Returns(-1);
                yield return new TestCaseData("Eight", "Seven").Returns(1);
                yield return new TestCaseData(
                        "OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZero",
                        "OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZero")
                    .Returns(-1);
                yield return new TestCaseData("OneThreeTwoFourNineZeroSixFiveEightNine", "OneFourThreeTwoNineZeroSixFiveEightNine").Returns(-1);
                yield return new TestCaseData("ThreeThreeThree", "TwoTwoTwo").Returns(1);
                yield return new TestCaseData("OneThreeTwoFourNineZeroSixFiveEightNine", "OneThreeTwoFourNineZeroSixFiveEightNine").Returns(0);
                yield return new TestCaseData("NineOneThreeTwoFourNineSixFiveEight", "OneThreeTwoFourNineZeroSixFiveEightNine").Returns(-1);
                yield return new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOne", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo").Returns(-1);
                yield return new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneTwo", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoOne").Returns(-1);
                yield return new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOne", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo").Returns(1);
                yield return new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneThree", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoZero").Returns(1);
                yield return new TestCaseData("TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", "ThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThree").Returns(1);
                yield return new TestCaseData("ThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThree", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo").Returns(-1);
            }
        }

        public static IEnumerable BigTestCases()
        {
            yield return new TestCaseData(0, 1).Returns(-1);
            yield return new TestCaseData(5, 4).Returns(1);
            yield return new TestCaseData(7, 7).Returns(0);
        }
    }
    
    [TestFixture]
    public class Tests
    {
        private static readonly string[] digits =
        {
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine"
        };
        
        [TestCaseSource(typeof(DataClass), "SimpleTestCases")]
        public int TestSimple(string first, string second) =>
            new NumberStringsComparer().Compare(first, second);
            
        [Timeout(1000)]
        [TestCaseSource(typeof(DataClass), "BigTestCases")]
        public int TestBig(int lastDigit1, int lastDigit2)
        {
            var len = 200000;
            var builder = new StringBuilder(5 * len);
            for (var i = 0; i < len; i++)
            {
                builder.Append(digits[(i + 1) % 10]);
            }

            var s = builder.ToString();
            var first = s + digits[lastDigit1];
            var second = s + digits[lastDigit2];
            
            var stopwatch = Stopwatch.StartNew();
            var actual = new NumberStringsComparer().Compare(first, second);
            Console.WriteLine("Elapsed ms: " + stopwatch.ElapsedMilliseconds);
            
            return actual;
        }
    }
}