using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class MedianOfTwoSortedArraysTests
    {
        private readonly MedianOfTwoSortedArrays _objUnderTest;

        public MedianOfTwoSortedArraysTests()
        {
            _objUnderTest = new MedianOfTwoSortedArrays();
        }

        [Fact]
        public void Test_FindMedianSortedArrays()
        {
            int[] nums1 = new int[] { 1, 3 };
            int[] nums2 = new int[] { 2 };

            var expected = 2.0;
            var actual = _objUnderTest.FindMedianSortedArrays(nums1, nums2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_FindMedianSortedArrays2()
        {
            int[] nums1 = new int[] { 1, 2 };
            int[] nums2 = new int[] { 3, 4 };

            var expected = 2.5;
            var actual = _objUnderTest.FindMedianSortedArrays(nums1, nums2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_FindMedianSortedArrays3()
        {
            int[] nums1 = new int[] { 0, 0 };
            int[] nums2 = new int[] { 0, 0 };

            var expected = 0.0;
            var actual = _objUnderTest.FindMedianSortedArrays(nums1, nums2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_FindMedianSortedArrays4()
        {
            int[] nums1 = new int[] { };
            int[] nums2 = new int[] { 1 };

            var expected = 1.0;
            var actual = _objUnderTest.FindMedianSortedArrays(nums1, nums2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_FindMedianSortedArrays5()
        {
            int[] nums1 = new int[] { 2 };
            int[] nums2 = new int[] { };

            var expected = 2.0;
            var actual = _objUnderTest.FindMedianSortedArrays(nums1, nums2);

            Assert.Equal(expected, actual);
        }
    }
}
