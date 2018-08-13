using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// Given a string, find the length of the longest substring without repeating characters.
    /// Examples:
    /// Given "abcabcbb", the answer is "abc", which the length is 3.
    /// Given "bbbbb", the answer is "b", with the length of 1.
    /// Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
    /// </summary>
    public class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            int longestLength = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    for(int k = j+1; k < i; k++)
                    {
                        if (s[j] == s[k]) continue;
                    }
                }
            }

            return longestLength;
        }
    }
}
