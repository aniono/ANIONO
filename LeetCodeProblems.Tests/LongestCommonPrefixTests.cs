using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class LongestCommonPrefixTests
    {
        private readonly TestsVerifier _testsVerifier;
        private readonly LongestCommonPrefix _objUnderTest;

        public LongestCommonPrefixTests()
        {
            _testsVerifier = new TestsVerifier();
            _objUnderTest = new LongestCommonPrefix();
        }

        [Fact]
        public void Test_FindLongestCommonPrefix()
        {
            var testStrings = new Dictionary<string, string[]>
            {
                { "fl", new string[] { "flower", "flow", "flight"  } },
                { "", new string[] { "dog", "racecar", "car"  } },
                { "a", new string[] { "apple", "air", "ask" } },
                { "go", new string[] { "good", "god", "go" } },
                { "some", new string[] { "sometime", "someone", "somebody" } },
                { "at", new string[] { "at", "at", "at" } },
            };

            foreach(var kvp in testStrings)
            {
                var input = kvp.Value;
                var actual = _objUnderTest.FindLongestCommonPrefix(input);
                var expected = kvp.Key;

                Assert.Equal(expected, actual);
            }
        }
    }
}
