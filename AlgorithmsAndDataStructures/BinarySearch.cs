namespace AlgorithmsAndDataStructures
{
    public class BinarySearch
    {
        public int Search(int target, int[] nums)
        {
            int first = 0;
            int last = nums.Length - 1;

            while (first <= last)
            {
                int i = (first + last) / 2;

                if (target < nums[i]) last = i - 1;
                else if (target > nums[i]) first = i + 1;
                else return i;
            }

            return -1;
        }

        public int SearchByRecursion(int target, int first, int last, int[] nums)
        {
            if (first < last)
            {
                int i = (first + last) / 2;

                if (target < nums[i]) return SearchByRecursion(target, first, i - 1, nums);
                else if (target > nums[i]) return SearchByRecursion(target, i + 1, last, nums);
                else return i;
            }
            else if (first == last) return nums[first] == target ? first : -1;
            else return -1;
        }
    }
}