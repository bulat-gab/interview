using System;

namespace Arrays
{
    public class LongestDistanceProblem
    {
        public int Run(int[] arr)
        {
            var n = arr.Length;
            
            var r = new int[n];
            r[n - 1] = n - 1;
            for (int i = n - 2; i >= 0; i--)
            {
                r[i] = i;
                if (arr[i + 1] >= arr[i])
                    r[i] = r[i + 1];
            }

            var l = new int [n];
            l[0] = 0;
            for (int i = 1; i < n; i++)
            {
                l[i] = i;
                if (arr[i] <= arr[i - 1])
                    l[i] = l[i - 1];
            }
            
            var maxDistance = 1;
            for (int i = 0; i < n; i++)
            {
                maxDistance = Math.Max(maxDistance, r[i] - l[i] + 1);
            }
            
            return maxDistance;
        }
        
        // O(n^2) solution
        //
        // public int Run(int[] arr)
        // {
        //     var n = arr.Length;
        //     var maxDistance = 1;
        //     
        //     for (int i = 0; i < n; i++)
        //     {
        //         var right = 0;
        //         for (int j = i; j < n - 1; j++)
        //         {
        //             if (arr[j] <= arr[j + 1])
        //             {
        //                 right++;
        //             }
        //         }
        //
        //         var left = 0;
        //         for (int j = i; j > 0; j--)
        //         {
        //             if (arr[j] <= arr[j - 1])
        //             {
        //                 left++;
        //             }
        //         }
        //
        //         maxDistance = Math.Max(maxDistance, 1 + left + right);
        //     }
        //
        //     return maxDistance;
        // }
    }
}