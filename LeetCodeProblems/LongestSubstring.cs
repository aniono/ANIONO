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
            if (string.IsNullOrEmpty(s))
                return 0;

            int longest = 1, MAX = 95;
            int i, j, k, i2, j2;

            for (i = 0; i < s.Length - longest; i++)
            {
                if (s[i] == s[i + 1]) continue;

                for (j = s.Length - 1; (j - i + 1) > longest; j--)
                {
                    if (s[j] == s[i]) continue;

                    if (s[j] == s[j - 1]) continue;

                    k = i;
                    while (k < j && s[k] != s[j]) { k++; }

                    if (j == k)
                    {
                        for (i2 = i; i2 < j - 1; i2++)
                        {
                            j2 = i2 + 1;

                            while (j2 < j && s[j2] != s[i2]) { j2++; }

                            if (j2 != j) break;
                        }

                        if (i2 == j - 1)
                        {
                            longest = j - i + 1;

                            if (longest == MAX) return longest;

                            break;
                        }
                    }
                }
            }

            return longest;
        }
    }
}
