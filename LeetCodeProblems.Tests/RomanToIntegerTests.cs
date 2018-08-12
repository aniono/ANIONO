using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class RomanToIntegerTests
    {
        private readonly TestsVerifier _testsVerifier;
        private readonly RomanToInteger _objUnderTest;

        public RomanToIntegerTests()
        {
            _testsVerifier = new TestsVerifier();
            _objUnderTest = new RomanToInteger();
        }

        [Fact]
        public void Test_RomanToInt()
        {
            var testStrings = new Dictionary<string, int>
            {
                { "III", 3 },
                { "IV", 4 },
                { "IX", 9 },
                { "LVIII", 58 }, // L = 50, V = 5 and III = 3
                { "MCMXCIV", 1994 }, // M = 1000, CM = 900, XC = 90 and IV = 4.
                { "A", 0 },
                { "AXI", 0 }
            };

            _testsVerifier.Verify(testStrings, _objUnderTest.RomanToInt);
        }

        [Fact]
        public void Test_IntToRoman()
        {
            var testNumbers = new Dictionary<int, string>
            {
                { 1994, "MCMXCIV" },
                { 3, "III" },
                { 4, "IV" },
                { 9, "IX" },
                { 58, "LVIII" },
                { 59, "LIX" },
                { 1010, "MX" },
                { 6, "VI" }
            };

            _testsVerifier.Verify(testNumbers, _objUnderTest.IntToRoman);
        }
    }
}
