using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tasks.NumberComparison
{
    /* Задача:

    Даны два целых неотрицательных числа, записанных следующим образом. Каждая цифра записывается её 
    английским названием, первая буква цифры большая, остальные - маленькие.

    Например, число 1293 записывается как "OneTwoNineThree", число 135 как "OneThreeFive", число 0 
    как "Zero".

    Нужно сравнить эти два числа (сравнивать их нужно как числа) и вернуть:
    -1, если первое число меньше, 
    0, если значения чисел совпадают, 
    1, если первое число больше.

    Пример использования:
    var result = new NumberStringsComparer().Compare("OneTwoNineThree", "OneThreeFive");
 
    Для проверки решения необходимо запустить тесты.

    Подсказка:
    При использовании класса System.Numerics.BigInteger не пройдут тесты TestBig (числа из 200 тысяч цифр).
    */

    public class NumberStringsComparer
    {
        private static readonly Dictionary<string, int> digits = new Dictionary<string, int>
        {
            ["Zero"] = 0,
            ["One"] = 1,
            ["Two"] = 2,
            ["Three"] = 3,
            ["Four"] = 4,
            ["Five"] = 5,
            ["Six"] = 6,
            ["Seven"] = 7,
            ["Eight"] = 8,
            ["Nine"] = 9,
        };

        public int Compare(string first, string second)
        {
            var firstDigits = ConvertToDigits(first);
            var secondDigits = ConvertToDigits(second);
            return CompareListsOfDigits(firstDigits.ToList(), secondDigits.ToList());
        }

        private IEnumerable<int> ConvertToDigits(string s)
        {
            var splitted = Regex.Split(s, @"(?<!^)(?=[A-Z])");
            foreach (var stringNumber in splitted)
            {
                yield return digits[stringNumber];
            }
        }

        private int CompareListsOfDigits(List<int> first, List<int> second)
        {
            int firstDigit = 0;
            while (firstDigit < first.Count && first[firstDigit] == 0)
            {
                firstDigit++;
            }

            int secondDigit = 0;
            while (secondDigit < second.Count && second[secondDigit] == 0)
            {
                secondDigit++;
            }

            if (first.Count - firstDigit < second.Count - secondDigit)
            {
                return -1;
            }
            else if (first.Count - firstDigit > second.Count - secondDigit)
            {
                return 1;
            }

            for (int i = firstDigit; i < first.Count; i++)
            {
                if (first[i] < second[i])
                {
                    return -1;
                }
                else if (first[i] > second[i])
                {
                    return 1;
                }
            }

            return 0;


        }
    }
}