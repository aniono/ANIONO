using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public class LinearSearch
    {
        /// <summary>
        /// Search target number in input numbers. 
        /// If find it, then return the index of target number.
        /// Otherwise return -1.
        /// </summary>
        /// <param name="target">The target number to be find.</param>
        /// <param name="nums">Input numbers.</param>
        /// <returns>The index of target number in the input numbers.</returns>
        public int Search01(int target, int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target) return i;
            }

            return -1;
        }

        public Node Search02(int target, Node nums)
        {
            var cur = nums;

            while (cur != null)
            {
                if (cur.Data == target)
                    return cur;

                cur = cur.Next;
            }

            return cur;
        }

        public int Search03(int target, int index, int[] nums)
        {
            if (nums == null || index == nums.Length) return -1;
            else if (target != nums[index]) return Search03(target, index + 1, nums);
            else return index;
        }

        public Node Search04(int target, Node nums)
        {
            if (nums == null || nums.Data == target) return nums;
            else return Search04(target, nums.Next);
        }

        /// <summary>
        /// Find the target number, and move it to the fist position.
        /// </summary>
        /// <param name="target">The target number to be search.</param>
        /// <param name="nums">Input numbers.</param>
        /// <returns>If found, return 0, otherwise return -1.</returns>
        public int Search05(int target, int[] nums)
        {
            int index = Search01(target, nums);

            if (index > 0)
            {
                int t = nums[0];
                nums[0] = nums[index];
                nums[index] = t;

                return 0;
            }

            return index;
        }

        /// <summary>
        /// Find the target number, and move it to previous position.
        /// </summary>
        /// <param name="target">The target number to be search.</param>
        /// <param name="nums">Input number.</param>
        /// <returns>The new index of target number.</returns>
        public int Search06(int target, int[] nums)
        {
            int index = Search01(target, nums);

            if(index > 0)
            {
                int t = nums[index - 1];
                nums[index - 1] = nums[index];
                nums[index] = t;

                return index - 1;
            }

            return index;
        }

        /// <summary>
        /// Linked List implimentation of <see cref="Search06(int, int[])"/>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="nums"></param>
        /// <returns>The new node of target number.</returns>
        public Node Search07(int target, Node nums)
        {
            Node pre = null;
            Node cur = nums;

            while(cur != null)
            {
                if (cur.Data != target) { pre = cur; cur = cur.Next; }
                else
                {
                    if (cur == nums) return cur;
                    else
                    {
                        pre.Next = cur.Next;
                        cur.Next = pre;

                        return cur;
                    }
                }
            }

            return cur;
        }

        public int Search08(int target, int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int first = 0;
            int last = nums.Length - 1;

            while (first < last)
            {
                int i = first + ((target - nums[first]) / (nums[last] - nums[first])) * nums.Length;
                if (target < nums[i]) last = i - 1;
                else if (target > nums[i]) first = i + 1;
                else return i;
            }

            return -1;
        }
    }

    public class Node
    {
        public Node(int data)
        {
            Data = data;
        }

        public int Data { get; }

        public Node Next { get; set; }    
    }
}