using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
