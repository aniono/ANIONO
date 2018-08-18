﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// Given an array nums and a value val, remove all instances of that value in-place and return the new length.
    /// Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
    /// The order of elements can be changed. It doesn't matter what you leave beyond the new length.
    /// Example 1:
    ///     Given nums = [3,2,2,3], val = 3,
    /// 
    /// Your function should return length = 2, with the first two elements of nums being 2.
    /// It doesn't matter what you leave beyond the returned length.
    /// Example 2:
    ///     Given nums = [0,1,2,2,3,0,4,2], val = 2,
    /// 
    /// Your function should return length = 5, with the first five elements of nums containing 0, 1, 3, 0, and 4.
    /// Note that the order of those five elements can be arbitrary. 
    /// It doesn't matter what values are set beyond the returned length.
    /// </summary>
    public class RemoveElement
    {
        public int Remove(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int i = 0;

            for (int j = nums.Length - 1; i <= j; i++)
            {
                if (val == nums[i])
                {
                    while (j > i && val == nums[j]) { j--; }

                    if (j > i) { nums[i] = nums[j]; j--; }
                }
            }
           
            if (nums[0] == val) { nums = new int[] { }; return 0; }
            else if (nums[i - 1] == val) return i - 1;
            else return i;
        }
    }
}