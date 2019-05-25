using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: 
    /// (you may want to display this pattern in a fixed font for better legibility)
    /// 
    /// P   A   H   N
    /// A P L S I I G
    /// Y   I   R
    /// 
    /// And then read line by line: "PAHNAPLSIIGYIR"
    /// Write the code that will take a string and make this conversion given a number of rows:
    /// string convert(string s, int numRows);
    /// 
    /// Example 1:
    /// Input: s = "PAYPALISHIRING", numRows = 3
    /// Output: "PAHNAPLSIIGYIR"
    /// 
    /// Example 2:
    /// Input: s = "PAYPALISHIRING", numRows = 4
    /// Output: "PINALSIGYAHRPI"
    /// Explanation:
    /// 
    /// P     I    N
    /// A   L S  I G
    /// Y A   H R
    /// P     I
    /// </summary>
    public class ZigZagConversion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert(string s, int numRows)
        {
            if (numRows <= 1)
                return s;

            var maxRowIndex = numRows - 1;
            var delta = 2 * maxRowIndex;
            var numCols = 1;
            var x = numRows;
            while (s.Length > x)
            {
                x += delta;
                numCols += maxRowIndex;
            }

            var arr = new char[numRows, numCols];
            for (int i = 0, p = 0; p < s.Length; i += maxRowIndex)
            {
                for (int j = 0; j < numRows && p < s.Length; j++)
                    arr[j, i] = s[p++];

                for (int j = maxRowIndex - 1, k = i + 1; j > 0 && p < s.Length; j--, k++)
                    arr[j, k] = s[p++];
            }

            var sb = new StringBuilder(s.Length);
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (arr[i, j] == '\0')
                        continue;

                    sb.Append(arr[i, j]);
                }
            }

            var result = sb.ToString();

            return result;
        }
    }
}
