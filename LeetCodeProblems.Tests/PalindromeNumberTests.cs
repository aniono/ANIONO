using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class PalindromeNumberTests
    {
        private readonly TestsVerifier _testsVerifier;
        private readonly PalindromeNumber _objUnderTest;

        public PalindromeNumberTests()
        {
            _testsVerifier = new TestsVerifier();
            _objUnderTest = new PalindromeNumber();
        }

        [Fact]
        public void Test_IsPalindromeNumber()
        {
            var testNumbers = new Dictionary<int, bool>
            {
                { 121, true },
                { -121, false },
                { 10, false },
                { 1, true },
                { 123456, false },
                { 1223221, true },
                { int.MaxValue, false },
                { int.MinValue, false }
            };

            _testsVerifier.Verify(testNumbers, _objUnderTest.IsPalindrome);
        }
    }
}
