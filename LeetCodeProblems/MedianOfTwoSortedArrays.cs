using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// Given two sorted arrays nums1 and nums2 of size m and n respectively, 
    /// return the median of the two sorted arrays.
    /// Follow up: The overall run time complexity should be O(log (m+n)).
    /// </summary>
    public class MedianOfTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0 && nums2.Length == 0)
                return 0.0;

            if (nums1.Length == 0)
                return FindMdedian(nums2);

            if (nums2.Length == 0)
                return FindMdedian(nums1);

            int[] mergedArray = new int[nums1.Length + nums2.Length];

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                    mergedArray[k++] = nums1[i++];

                else if (nums1[i] > nums2[j])
                    mergedArray[k++] = nums2[j++];

                else
                {
                    mergedArray[k++] = nums1[i++];
                    mergedArray[k++] = nums2[j++];
                }
            }

            while (i < nums1.Length)
            {
                mergedArray[k++] = nums1[i++];
            }

            while (j < nums2.Length)
            {
                mergedArray[k++] = nums2[j++];
            }

            return FindMdedian(mergedArray);
        }

        private double FindMdedian(int[] nums)
        {
            int mid = nums.Length / 2;

            if (nums.Length % 2 != 0)
                return nums[mid];

            else
                return (nums[mid - 1] + nums[mid]) / 2.0;
        }
    }
}
