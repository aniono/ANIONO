using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    /// Symbol       Value
    /// I             1
    /// V             5
    /// X             10
    /// L             50
    /// C             100
    /// D             500
    /// M             1000
    /// For example, two is written as II in Roman numeral, just two one's added together. 
    /// Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.
    /// Roman numerals are usually written largest to smallest from left to right.However, the numeral for four is not IIII. 
    /// Instead, the number four is written as IV.Because the one is before the five we subtract it making four. 
    /// The same principle applies to the number nine, which is written as IX.There are six instances where subtraction is used:
    /// I can be placed before V (5) and X(10) to make 4 and 9. 
    /// X can be placed before L(50) and C(100) to make 40 and 90. 
    /// C can be placed before D(500) and M(1000) to make 400 and 900.
    /// Given a roman numeral, convert it to an integer.Input is guaranteed to be within the range from 1 to 3999.
    /// </summary>
    public class RomanToInteger
    {
        public int RomanToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int n = 0;
            var romanNums = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };
            var principles = new Dictionary<string, int>
            {
                { "IV", 4 },
                { "IX", 9 },
                { "XL", 40 },
                { "XC", 90 },
                { "CD", 400 },
                { "CM", 900 },
            };

            for (int i = 0; i < s.Length; i++)
            {
                if (!romanNums.ContainsKey(s[i]))
                    return 0;

                if (s[i] == 'V' || s[i] == 'L' || s[i] == 'D' || s[i] == 'M' || i == s.Length - 1)
                {
                    n += romanNums[s[i]];
                }
                else if (s[i] == 'I' || s[i] == 'X' || s[i] == 'C')
                {
                    string key = char.ToString(s[i]) + char.ToString(s[i + 1]);
                    bool containPrinciples = principles.ContainsKey(key);
                    n += (!containPrinciples ? romanNums[s[i]] : principles[key]);
                    i += (!containPrinciples ? 0 : 1);
                }
            }

            return n;
        }

        public string IntToRoman(int num)
        {
            int maxRoman = 3999;

            if (num > maxRoman || num < 1)
                return string.Empty;

            string numStr = num.ToString();
            int[] nums = new int[numStr.Length];
            int[] pows = new int[numStr.Length];
            int maxRepeatTimes = 3; // for example, I(1),II(2),III(3),IV,V
            var principles = new Dictionary<int, string>
            {
                { 1, "I" },
                { 5, "V" },
                { 10, "X" },
                { 50, "L" },
                { 100, "C" },
                { 500, "D" },
                { 1000, "M" },
                { 4, "IV" },
                { 9, "IX" },
                { 40, "XL" },
                { 90, "XC" },
                { 400, "CD" },
                { 900, "CM" },
            };
            StringBuilder romanBuilder = new StringBuilder();

            // for example: 1994
            // index      : 0    | 1   | 2  | 3
            // pows vlaue : 1000 | 100 | 10 | 1
            // nums value : 1    | 9   | 9  | 4
            for (int d = 1, i = numStr.Length - 1; i >= 0; i--)
            {
                pows[i] = d;
                nums[i] = pows[i] * (numStr[i] - '0');
                d *= 10;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (principles.ContainsKey(nums[i]))
                {
                    romanBuilder.Append(principles[nums[i]]);
                }
                else if (nums[i] > 0)
                {
                    int repeatTimes = nums[i] / pows[i];
                    if (repeatTimes > maxRepeatTimes)
                    {
                        romanBuilder.Append(principles[5 * pows[i]]);// V(5),L(50) and D(500)
                        repeatTimes -= 5;
                    }

                    for (int j = 0; j < repeatTimes; j++)
                    {
                        romanBuilder.Append(principles[pows[i]]);
                    }
                }
            }

            return romanBuilder.ToString();
        }
    }
}
