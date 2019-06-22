namespace AlgorithmsAndDataStructures
{
    public class InsertionSort
    {
        public void Sort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                int key = nums[i];
                int j = i - 1;
                while (j >= 0 && nums[j] > key) { nums[j + 1] = nums[j]; j--; }

                nums[j + 1] = key;
            }
        }

        public void SortByRecursion(int[] nums, int end)
        {
            if (end > 0)
            {
                SortByRecursion(nums, end - 1);

                int key = nums[end];
                int i = end - 1;
                while (i >= 0 && nums[i] > key) { nums[i + 1] = nums[i]; i--; }
                nums[i + 1] = key;
            }
        }
    }
}