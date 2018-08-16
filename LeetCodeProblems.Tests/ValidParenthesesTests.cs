using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class ValidParenthesesTests
    {
        private readonly ValidParentheses _objUnderTest;
        private readonly TestsVerifier _testsVerifier;

        public ValidParenthesesTests()
        {
            _objUnderTest = new ValidParentheses();
            _testsVerifier = new TestsVerifier();
        }

        [Fact]
        public void Test_IsValid()
        {
            var testCases = new Dictionary<string, bool>
            {
                { "", true },
                { "()", true },
                { "()[]{}", true },
                { "(]", false },
                { "([)]", false },
                { "{[]}", true },
                { "()()", true },
                { "((()))", true },
                { "((()[]))", true },
                { "((()[]))[]", true },
            };

            _testsVerifier.Verify(testCases, _objUnderTest.IsValid);
        }
    }
}
