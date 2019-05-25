using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class ZigZagConversionTests
    {
        private readonly ZigZagConversion _objUnderTest;

        public ZigZagConversionTests()
        {
            _objUnderTest = new ZigZagConversion();
        }

        [Theory]
        [InlineData("AB", 1, "AB")]
        [InlineData("AB", 2, "AB")]
        [InlineData("AB", 3, "AB")]
        [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
        public void Test_Convert(string inputStr, int inputNo, string output)
        {
            var actual = _objUnderTest.Convert(inputStr, inputNo);

            Assert.Equal(output, actual);
        }
    }
}