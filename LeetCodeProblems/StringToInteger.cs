using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// Implement atoi which converts a string to an integer. 
    /// The function first discards as many whitespace characters as necessary until the first non-whitespace character is found.
    /// Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, 
    /// and interprets them as a numerical value.
    /// The string can contain additional characters after those that form the integral number, 
    /// which are ignored and have no effect on the behavior of this function.
    /// If the first sequence of non-whitespace characters in str is not a valid integral number, 
    /// or if no such sequence exists because either str is empty or it contains only whitespace characters, 
    /// no conversion is performed. If no valid conversion could be performed, a zero value is returned.
    /// Note:
    /// Only the space character ' ' is considered as whitespace character.
    /// Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. 
    /// If the numerical value is out of the range of representable values, INT_MAX (231 − 1) or INT_MIN (−231) is returned.
    /// </summary>
    public class StringToInteger
    {
        public int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            if (!(str[0] == ' ' || str[0] == '-' || str[0] == '+' || char.IsDigit(str[0])))
                return 0;

            long result = 0;
            bool isNegative = false;
            int minusSignCount = 0;
            int plusSignCount = 0;
            int maxNumOfDigits = 10;
            long[] nums = new long[maxNumOfDigits]; // int.MaxValue(2147483647)

            // find index of first digit.
            int i = 0;
            for (; i < str.Length && !char.IsDigit(str[i]); i++)
            {
                if (str[i] == ' ')
                    continue;

                if (str[i] == '+')
                    plusSignCount++;

                if (str[i] == '-')
                    minusSignCount++;

                if (plusSignCount > 0 && minusSignCount > 0)
                    return 0;

                if ((i + 1) < str.Length)
                {
                    // plus sign or minus sign should following digit.
                    if ((str[i] == '+' || str[i] == '-') && !char.IsDigit(str[i + 1]))
                        return 0;

                    // digit should start with non-white space, plus sign or minus sign.
                    if (!(str[i] == ' ' || str[i] == '+' || str[i] == '-') && char.IsDigit(str[i + 1]))
                        return 0;
                }
            }

            isNegative = minusSignCount > 0;

            // remove leading 0.
            while (i < str.Length && str[i] == '0') { i++; }

            // find digit chars and convert to digit.
            int j = 0;
            while (i < str.Length && char.IsDigit(str[i]))
            {
                if (j >= maxNumOfDigits)
                    return !isNegative ? int.MaxValue : int.MinValue;

                nums[j] = str[i] - '0';
                j++; i++;
            }

            // calculate number.
            j -= 1; // point to last digit.
            for (int d = 1; j >= 0; j--)
            {
                result += nums[j] * d;
                d *= 10;

                if (result > int.MaxValue)
                    return !isNegative ? int.MaxValue : int.MinValue;
            }

            return !isNegative ? (int)result : -(int)result;
        }
    }
}
