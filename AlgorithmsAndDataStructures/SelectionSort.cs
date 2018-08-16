using System;

namespace AlgorithmsAndDataStructures
{
    public class SelectionSort
    {
        public void Sort(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return;

            for (int i = 0, minNumIndex; i < nums.Length; i++)
            {
                minNumIndex = IndexOfMinNum(nums, i, nums.Length - 1);
                int t = nums[i];
                nums[i] = nums[minNumIndex];
                nums[minNumIndex] = t;
            }
        }

        public int IndexOfMinNum(int[] nums, int startIndex, int endIndex)
        {
            if (startIndex < 0 || nums.Length <= endIndex)
                return -1;

            int minNumIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (nums[minNumIndex] > nums[i])
                    minNumIndex = i;
            }

            return minNumIndex;
        }
    }
}
