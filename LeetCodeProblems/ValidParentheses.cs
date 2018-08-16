using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    /// An input string is valid if:
    /// Open brackets must be closed by the same type of brackets.
    /// Open brackets must be closed in the correct order.
    /// Note that an empty string is also considered valid.
    /// Example 1:
    ///     Input: "()"
    ///     Output: true
    /// Example 2:
    ///     Input: "()[]{}"
    ///     Output: true
    /// Example 3:
    ///     Input: "(]"
    ///     Output: false
    /// Example 4:
    ///     Input: "([)]"
    ///     Output: false
    /// Example 5:
    ///     Input: "{[]}"
    ///     Output: true
    /// </summary>
    public class ValidParentheses
    {
        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            if (s.Length % 2 != 0)
                return false;

            var left2right = new Dictionary<char, char>
            {
                { '[', ']' },
                { '{', '}' },
                { '(', ')' }
            };
            var right2left = new Dictionary<char, char>
            {
                { ']', '[' },
                { '}', '{' },
                { ')', '(' }
            };

            if (right2left.ContainsKey(s[0]))
                return false;

            if (left2right.ContainsKey(s[s.Length - 1]))
                return false;

            var leftStack = new Stack<char>();
            var rightStack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (left2right.ContainsKey(s[i]))
                    leftStack.Push(s[i]);
                else if (right2left.ContainsKey(s[i]))
                    rightStack.Push(s[i]);
                else return false;

                if (leftStack.Count != 0 && rightStack.Count != 0
                    && left2right[leftStack.Peek()] == rightStack.Peek())
                {
                    leftStack.Pop();
                    rightStack.Pop();
                }
            }

            return leftStack.Count == 0 && rightStack.Count == 0;
        }
    }
}
