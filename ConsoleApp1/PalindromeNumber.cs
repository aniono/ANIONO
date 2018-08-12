using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    public class PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0 || x >= int.MaxValue)
                return false;

            if (x < 10)
                return true;

            bool isPalindrome = true;
            int maxNumOfDigits = 10; // int.MaxValue
            int[] nums = new int[maxNumOfDigits];
            int numOfDigits = 0;

            // store digits to array.
            for (int i = 0; x != 0; i++)
            {
                nums[i] = x % 10;
                x /= 10;
                numOfDigits++;
            }

            // comparing.
            for (int i = 0, j = numOfDigits - 1; i < numOfDigits / 2; i++, j--)
            {
                if (nums[i] != nums[j])
                    return false;
            }

            return isPalindrome;
        }
    }
}
