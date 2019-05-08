using System.Collections;
using System.Collections.Generic;
using System.Text;
using NumberComparison;
using NUnit.Framework;

namespace Interview
{
    public class Tests
    {
        [TestCase("Zero", "Zero", ExpectedResult = 0)]
        [TestCase("One", "Zero", ExpectedResult = 1)]
        [TestCase("Zero", "One", ExpectedResult = -1)]
        public int TestsMethod(string first, string second)
        {
            return new NumberStringsComparer().Compare(first, second);
        }

//        public static IEnumerable<object[]> TestCasesBig()
//        {
//            yield return new object[] { 0, 1, -1 };
//            yield return new object[] { 5, 4, 1 };
//            yield return new object[] { 7, 7, 0 };
//        }

//        [Timeout(1000)]
//        [Test]
////        [DynamicData(nameof(TestCasesBig), DynamicDataSourceType.Method)]
//        public void TestBig(int lastDigit1, int lastDigit2, int expected)
//        {
//            int len = 200000;
//            var builder = new StringBuilder(5 * len);
//            for (int i = 0; i < len; i++)
//                builder.Append(digits[(i + 1) % 10]);
//            var s = builder.ToString();
//            var first = s + digits[lastDigit1];
//            var second = s + digits[lastDigit2];
//            var actual = new NumberStringsComparer().Compare(first, second);
//            Assert.AreEqual(expected, actual);
//        }

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
            "Nine",
        };
    }

    public class DataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("Zero", "Zero").Returns(0);
                yield return new TestCaseData("One", "Zero").Returns(1);
                yield return new TestCaseData("Zero", "One").Returns(-1);
//            yield return new TestCaseData("One", "Two", -1};
//            yield return new TestCaseData("One", "One", 0};
//            yield return new TestCaseData("OneTwo", "TwoOne", -1};
//            yield return new TestCaseData("OneZero", "One", 1};
//            yield return new TestCaseData("OneEight", "Nine", 1};
//            yield return new TestCaseData("OneNine", "TwoEight", -1};
//            yield return new TestCaseData("SixNine", "TwoNine", 1};
//            yield return new TestCaseData("FiveSixOne", "SixFourOne", -1};
//            yield return new TestCaseData("OneZero", "OneOne", -1};
//            yield return new TestCaseData("ThreeTwo", "Four", 1};
//            yield return new TestCaseData("OneZeroSeven", "OneZeroSix", 1};
//            yield return new TestCaseData("Eight", "Nine", -1};
//            yield return new TestCaseData("Four", "Five", -1};
//            yield return new TestCaseData("Eight", "Seven", 1};
//            yield return new TestCaseData("OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZero", "OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZero", -1};
//            yield return new TestCaseData("OneThreeTwoFourNineZeroSixFiveEightNine", "OneFourThreeTwoNineZeroSixFiveEightNine", -1};
//            yield return new TestCaseData("ThreeThreeThree", "TwoTwoTwo", 1};
//            yield return new TestCaseData("OneThreeTwoFourNineZeroSixFiveEightNine", "OneThreeTwoFourNineZeroSixFiveEightNine", 0};
//            yield return new TestCaseData("NineOneThreeTwoFourNineSixFiveEight", "OneThreeTwoFourNineZeroSixFiveEightNine", -1};
//            yield return new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOne", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", -1};
//            yield return new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneTwo", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoOne", -1};
//            yield return new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOne", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", 1};
//            yield return new TestCaseData("OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneThree", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoZero", 1};
//            yield return new TestCaseData("TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", "ThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThree", 1};
//            yield return new TestCaseData("ThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThree", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", -1};
            }
            
        }
    }
}