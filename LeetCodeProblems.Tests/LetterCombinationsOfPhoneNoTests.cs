using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class LetterCombinationsOfPhoneNoTests
    {
        private readonly LetterCombinationsOfPhoneNo _objUnderTest;

        public LetterCombinationsOfPhoneNoTests()
        {
            _objUnderTest = new LetterCombinationsOfPhoneNo();
        }

        [Theory]
        [InlineData("", null)]
        [InlineData("1", null)]
        [InlineData("11", null)]
        [InlineData("1111111", null)]
        public void Test_LetterCombinations_ReturnEmpty(string input, params string[] output)
        {
            var actual = _objUnderTest.LetterCombinations(input);
            Assert.Equal(output, actual);
        }

        [Theory]
        [InlineData("23", "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf")]
        public void Test_LetterCombinations(string input, params string[] output)
        {
            var actual = _objUnderTest.LetterCombinations(input);
            Assert.Equal(output.Length, actual.Count);
        }
    }
}
