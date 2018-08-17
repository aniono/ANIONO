namespace LeetCodeProblems
{
    /// <summary>
    /// Given an array of integers nums sorted in ascending order, 
    /// find the starting and ending position of a given target value.
    /// Your algorithm's runtime complexity must be in the order of O(log n).
    /// If the target is not found in the array, return [-1, -1].
    /// Example 1:
    ///     Input: nums = [5,7,7,8,8,10], target = 8
    ///     Output: [3,4]
    /// Example 2:
    ///     Input: nums = [5,7,7,8,8,10], target = 6
    ///     Output: [-1,-1]
    /// </summary>
    public class FindFirstAndLastPosition
    {
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { -1, -1 };

            int first = 0;
            int last = nums.Length - 1;

            while (first <= last)
            {
                int i = (first + last) / 2;

                if (target < nums[i]) last = i - 1;
                else if (target > nums[i]) first = i + 1;
                else
                {
                    first = i - 1;
                    last = i + 1;

                    while (first >= 0 && target == nums[first]) first--;
                    while (last <= nums.Length - 1 && target == nums[last]) last++;

                    return new int[] { first + 1, last - 1 };
                }
            }

            return new int[] { -1, -1 };
        }
    }
}
