using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    public class ReverseInteger
    {
        public int Reverse(int x)
        {
            long result = 0;
            bool isNagative = false;
            int numOfDigits = 0;
            long[] nums = new long[16];

            if (x < 0)
            {
                isNagative = true;
                x = -x;
            }

            for (numOfDigits = 0; x > 0; numOfDigits++)
            {
                nums[numOfDigits] = x % 10;

                for (int i = 0; i < numOfDigits; i++)
                {
                    nums[i] *= 10;
                }

                if (nums[0] > int.MaxValue)
                    return 0;

                x /= 10;
            }

            for (int i = 0; i < numOfDigits; i++)
            {
                result += nums[i];

                if (result > int.MaxValue)
                    return 0;
            }
            
            return !isNagative ? (int)result : -(int)result;
        }
    }
}
