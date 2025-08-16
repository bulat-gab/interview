using System;

namespace Tasks.ArrayTasks
{
    class MissingNumber
    {
        static void MissingNumberExample(string[] args)
        {
            const int N = 10;
            int[] C = { 1, 2, 3, 4, 5, 6, 7, 8, 10 };

            Console.WriteLine(FindMissingNumber(N, C));

        }

        private static int FindMissingNumber(int N, int[] C)
        {
            int S = N / 2 * (1 + N);
            int actualSum = 0;
            foreach (var i in C)
            {
                actualSum += i;
            }

            return S - actualSum;
        }
    }
}