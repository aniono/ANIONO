using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeProblems
{
    public class LetterCombinationsOfPhoneNo
    {
        public IList<string> LetterCombinations(string digits)
        {
            var charsExcludeOne = digits.Where(c => c != '1').ToArray();
            if (charsExcludeOne.Length == 0)
                return null;

            var result = new List<string>(2 * charsExcludeOne.Length);
            var noCharsMapping = new Dictionary<char, string>
            {
                { '0', " " },
                { '1', "" },
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" },
            };

            for(int i = 0; i < charsExcludeOne.Length; i++)
            {
                int Si = i;
                
            }

            return result;
        }
    }
}
