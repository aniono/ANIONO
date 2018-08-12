using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class ReverseIntegerTests
    {
        private readonly TestsVerifier _testsVerifier;
        private readonly ReverseInteger _objUnderTest;

        public ReverseIntegerTests()
        {
            _testsVerifier = new TestsVerifier();
            _objUnderTest = new ReverseInteger();
        }

        [Fact]
        public void Test_Reverse()
        {
            var testNumbers = new Dictionary<int, int>()
            {
                { 123456 , 654321 },
                { -123456, -654321 },
                { 1234560, 654321 },
                { -12390, -9321 },
                { 9984593, 3954899 },
                { 230943054, 450349032 },
                { int.MaxValue, 0 },
                { int.MinValue, 0 }
            };

            _testsVerifier.Verify(testNumbers, _objUnderTest.Reverse);
        }
    }
}
