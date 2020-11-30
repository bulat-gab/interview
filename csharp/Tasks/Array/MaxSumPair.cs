using System;
using System.Collections.Generic;

namespace Arrays
{
    /// <summary>
    /// дан лист чисел. надо найти максимальную из сумм пар чисел, имеющих одинаковую сумму цифр. Return sum of the pair
    /// </summary>
    public class MaxSumPair
    {
        public int Run(int[] arr)
        {
            var n = arr.Length;
            var maxSum = -1;
            var dict = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                var sum = GetSumOfDigits(num);
                if (dict.TryGetValue(sum, out var valueInDictionary))
                {
                    if (num > valueInDictionary)
                    {
                        dict[sum] = num;
                    }
                }
                dict[sum] = num;
            }

            foreach (var num in arr)
            {
                var sum = GetSumOfDigits(num);
                if (dict[sum] == num)
                {
                    continue;
                }

                maxSum = Math.Max(maxSum, dict[sum] + num);
            }
            
            return maxSum;
        }

        private int GetSumOfDigits(int a)
        {
            var sum1 = 0;
            while (a > 0)
            {
                sum1 += a % 10;
                a /= 10;
            }

            return sum1;
        }
    }
}