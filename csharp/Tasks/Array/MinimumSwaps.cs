using NUnit.Framework;

namespace hackerrank
{
    public class MinimumSwaps
    {
        private static int swaps = 0;

        public static int minimumSwaps(int[] arr)
        {
            var sorted = false;
            while (!sorted)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 1; j < arr.Length; j++)
                    {
                        if (arr[i] >= arr[j])
                        {
                            continue;
                        }

                        Swap(arr, arr[i], arr[j]);
                    }
                }
            }

            return swaps;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            swaps++;
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

    public class MinimumSwapsTests
    {
        [Test]
        public void Test1()
        {
            var arr = new int[] { 7, 1, 3, 2, 4, 5, 6 };
            var expected = 5;

            var actual = MinimumSwaps.minimumSwaps(arr);

            Assert.Equals(expected, actual);
        }
    }
}