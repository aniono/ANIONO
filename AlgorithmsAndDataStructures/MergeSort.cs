namespace AlgorithmsAndDataStructures
{
    public class MergeSort
    {
        public void Sort(int[] nums, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                Sort(nums, start, middle);
                Sort(nums, middle + 1, end);
                Merge(nums, start, middle, end);
            }
        }

        private void Merge(int[] nums, int start, int middle, int end)
        {
            int[] left = new int[(middle - start + 1) + 1];
            int[] right = new int[(end - middle) + 1];
            int indexOfLeftGuard = left.Length - 1;
            int indexOfRightGuard = right.Length - 1;
            left[indexOfLeftGuard] = int.MaxValue;
            right[indexOfRightGuard] = int.MaxValue;

            for (int i = 0; i < indexOfLeftGuard; i++)
            {
                left[i] = nums[start + i];
            }

            for (int j = 0; j < indexOfRightGuard; j++)
            {
                right[j] = nums[middle + j + 1];
            }

            for (int i = 0, j = 0, k = start; k <= end; k++)
            {
                nums[k] = left[i] <= right[j] ? left[i++] : right[j++];
            }
        }
    }
}