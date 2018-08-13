using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? 
    /// Find all unique triplets in the array which gives the sum of zero.
    /// Note:
    /// The solution set must not contain duplicate triplets.
    /// Example:
    ///     Given array nums = [-1, 0, 1, 2, -1, -4],
    /// 
    /// A solution set is:
    /// [
    ///   [-1, 0, 1],
    ///   [-1, -1, 2]
    /// ]
    /// </summary>
    public class ThreeSum
    {
        /// <summary>
        /// This is a C# version based on: https://leetcode.com/problems/3sum/discuss/7392/Python-easy-to-understand-solution-(O(n*n)-time).
        /// Origin Python version author: https://leetcode.com/caikehe
        /// Thanks caikehe.
        /// </summary>
        public IList<IList<int>> FindThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
                return res;
                        
            Array.Sort(nums);
            res.Capacity = nums.Length; // to reduce times of reszie.

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue; // avoid check duplicate set again.

                for (int j = i + 1, k = nums.Length - 1; j < k;)
                {
                    int s = nums[i] + nums[j] + nums[k];

                    if (s < 0) j++; // find forward
                    else if (s > 0) k--; // find backward
                    else
                    {
                        res.Add(new List<int> { nums[i], nums[j], nums[k] });

                        while (j < k && nums[j] == nums[j + 1]) { j++; } // bypass adjacent numbers that are equals.
                        while (j < k && nums[k] == nums[k - 1]) { k--; }

                        j++; k--; // find forward, backward
                    }
                }
            }

            return res;
        }
    }
}
