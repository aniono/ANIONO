using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class LongestSubstringTests
    {
        private readonly TestsVerifier _testsVerifier;
        private readonly LongestSubstring _objUnderTest;

        public LongestSubstringTests()
        {
            _testsVerifier = new TestsVerifier();
            _objUnderTest = new LongestSubstring();
        }

        [Fact]
        public void Test_LengthOfLongestSubstring()
        {
            var testStrings = new Dictionary<string, int>
            {
                { "abcabcbb", 3 }, // abc
                { "bbbbb", 1 }, // b
                { "pwwkew", 3 } // wke
            };            
        }
    }
}
