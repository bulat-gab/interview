using System;

namespace hackerrank
{
    /*
1 1 1 0 0 0
0 1 0 0 0 0
1 1 1 0 0 0
0 0 2 4 4 0
0 0 0 2 0 0
0 0 1 2 4 0
     */


    public class Hourglass
    {
        public static int hourglassSum(int[][] arr)
        {
            if (arr.Length < 3)
            {
                throw new ArgumentException();
            }

            var max = Int32.MinValue;
            for (int x = 1; x < arr.Length - 1; x++)
            {
                for (int y = 1; y < arr[x].Length - 1; y++)
                {
                    var hourGlass = CalculateHourGlass(arr, x, y);
                    if (hourGlass > max)
                    {
                        max = hourGlass;
                    }
                }
            }

            return max;
        }

        private static int CalculateHourGlass(int[][] arr, int x, int y)
        {
            return arr[x + 1][y - 1] + arr[x + 1][y] + arr[x + 1][y + 1] +
                                   arr[x][y] +
                   arr[x - 1][y - 1] + arr[x - 1][y] + arr[x - 1][y + 1];
        }
    }
}