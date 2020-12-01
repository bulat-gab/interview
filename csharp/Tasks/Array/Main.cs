using System;
using System.Collections.Generic;

namespace Arrays
{
    public class Main
    {
        /// Largest K such that both K and -K exist in array
        public int LargestK(int[] arr)
        {
            var set = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    set.Add(arr[i]);
                }
            }

            var maxK = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= 0)
                {
                    continue;
                }

                if (set.Contains(-1 * arr[i]))
                {
                    maxK = Math.Max(maxK, arr[i]);
                }
            }

            return maxK;
        }

        public bool TwoElementsDifferBy1(int[] arr)
        {
            var n = arr.Length;
            if (n <= 1)
            {
                return false;
            }

            Array.Sort(arr);
            for (int i = 0; i < n - 1; i++)
            {
                if (Math.Abs(arr[i] - arr[i + 1]) == 1)
                {
                    return true;
                }
            }

            return false;
        }

        // Time: O(N*logN)
        // 
        // public int LargestXOccuringXTimes(int[] arr)
        // {
        //     Array.Sort(arr);
        //
        //     var occurence = 0;
        //     int? cur = null;
        //     for (int i = arr.Length - 1; i > 0; i--)
        //     {
        //         if (cur == null)
        //         {
        //             cur = arr[i];
        //             occurence = 1;
        //         }
        //         else if (cur == arr[i])
        //         {
        //             occurence += 1;
        //         }
        //         else if (occurence == cur)
        //         {
        //             return cur.Value;
        //         }
        //         else
        //         {
        //             cur = arr[i];
        //             occurence = 1;
        //         }
        //     }
        //
        //     return 0;
        // }
        
        // Time: O(N), Space: O(N)
        public int LargestXOccuringXTimes(int[] arr)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                var value = dict.GetValueOrDefault(arr[i], 0);
                dict[arr[i]] = value + 1;
            }

            var max = 0;
            foreach (var (number, occurence) in dict)
            {
                if (number == occurence)
                {
                    max = Math.Max(max, number);
                }
            }
            
            return max;
        }
    }
}