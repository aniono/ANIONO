using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// Write a function to find the longest common prefix string amongst an array of strings.
    /// If there is no common prefix, return an empty string "".
    /// Example 1:
    /// Input: ["flower","flow","flight"]
    /// Output: "fl"
    /// Example 2:
    /// Input: ["dog","racecar","car"]
    /// Output: ""
    /// Explanation: There is no common prefix among the input strings.
    /// Note:
    /// All given inputs are in lowercase letters a-z.
    /// </summary>
    public class LongestCommonPrefix
    {
        public string FindLongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return string.Empty;

            // find the shortest string.
            int indexOfShortestStr = 0;
            for (int i = 1; i < strs.Length; i++)
            {
                if (strs[i].Length < strs[indexOfShortestStr].Length)
                {
                    indexOfShortestStr = i;
                }
            }

            for (int i = 0; i < strs[indexOfShortestStr].Length; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j][i] != strs[0][i])
                        return strs[0].Substring(0, i);
                }
            }

            return strs[indexOfShortestStr];
        }
    }
}
