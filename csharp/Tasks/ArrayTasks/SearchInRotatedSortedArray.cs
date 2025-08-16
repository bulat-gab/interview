namespace Tasks.ArrayTasks
{
    public class SearchInRotatedSortedArray
    {
        // {3, 4, 5, 1, 2}
        public int Search(int[] array, int key)
        {
            int pivot = FindPivot(array, 0, array.Length - 1);

            var result1 = BinarySearch(array, 0, pivot, key);
            var result2 = BinarySearch(array, pivot + 1, array.Length - 1, key);


            return result1 == -1 ? result2 : result1;
        }

        private int FindPivot(int[] array, int low, int high)
        {
            if (high < low)
            {
                return -1;
            }
            if (high == low)
            {
                return low;
            }

            var mid = (low + high) / 2;

            if (array[mid] > array[mid + 1] && mid < high)
            {
                return mid;
            }

            if (array[mid] < array[mid - 1] && mid > low)
            {
                return (mid - 1);
            }

            if (array[low] >= array[mid])
            {
                return FindPivot(array, low, mid - 1);
            }

            return FindPivot(array, mid + 1, high);
        }

        private int BinarySearch(int[] array, int low, int high, int key)
        {
            if (low > high)
            {
                return -1;
            }

            var mid = (low + high) / 2;
            if (array[mid] == key)
            {
                return mid;
            }
            else if (array[mid] > key)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }

            return BinarySearch(array, low, high, key);
        }
    }
}