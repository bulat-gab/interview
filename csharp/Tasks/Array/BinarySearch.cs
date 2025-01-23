namespace Tasks.Array
{
    public class BinarySearch
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;


            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                    return mid;

                else if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }
    }
}
