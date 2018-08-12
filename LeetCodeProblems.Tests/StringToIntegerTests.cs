using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class StringToIntegerTests
    {
        private readonly TestsVerifier _testsVerifier;
        private readonly StringToInteger _objUnderTest;

        public StringToIntegerTests()
        {
            _testsVerifier = new TestsVerifier();
            _objUnderTest = new StringToInteger();
        }

        [Fact]
        public void Test_MyAtoi()
        {
            var testStrings = new Dictionary<string, int>
            {
                { "42", 42 },
                { "    -42", -42 },
                { "4193 with words", 4193 },
                { "words and 987", 0 },
                { "-91283472332", int.MinValue },
                { "91283472332", int.MaxValue },
                { "1234567890", 1234567890 },
                { "+1234567890", 1234567890 },
                { "  0000000000012345678", 12345678 },
                { "", 0 },
                { "---", 0 },
                { "+-2", 0 },
                { "+  -2", 0 },
                { "+  -   2", 0 },
                { "-   234", 0 },
                { "-0002", -2 },
                { " b11228552307", 0 }

            };

            _testsVerifier.Verify(testStrings, _objUnderTest.MyAtoi);
        }
    }
}
