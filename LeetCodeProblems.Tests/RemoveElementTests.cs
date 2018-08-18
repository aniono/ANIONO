using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class RemoveElementTests
    {
        private readonly RemoveElement _objUnderTest;

        public RemoveElementTests()
        {
            _objUnderTest = new RemoveElement();
        }

        [Fact]
        public void Test_Remove()
        {
            const int NumOfTestCases = 9;
            var testCases = new int[NumOfTestCases][]
            {
                null,
                new int[] { },
                new int[] { 3, 2, 2, 3 },
                new int[] { 0, 1, 2, 2, 3, 0, 4, 2 },
                new int[] { 3, 3 },
                new int[] { 3, 3, 3, 3, 3 },
                new int[] { 0, 1, 2, 2, 3, 0, 2, 2 },
                new int[] { 4, 5 },
                new int[] { 5 },
            };

            var valuesToRemove = new int[NumOfTestCases] { 0, 0, 3, 2, 3, 3, 2, 5, 4 };
            var expectedLength = new int[NumOfTestCases] { 0, 0, 2, 5, 0, 0, 4, 1, 1 };
            var expectedNums = new int[NumOfTestCases][]
            {
                null,
                new int[] { },
                new int[] { 2, 2, 3, 3 },
                new int[] { 0, 1, 3, 0, 4, 2, 2, 2 },
                new int[] { },
                new int[] { },
                new int[] { 0, 1, 3, 0 },
                new int[] { 4 },
                new int[] { 5 },
            };

            var actual = _objUnderTest.Remove(testCases[0], valuesToRemove[0]);
            Assert.Null(testCases[0]);
            Assert.Equal(expectedLength[0], actual);

            var actual2 = _objUnderTest.Remove(testCases[1], valuesToRemove[1]);
            Assert.NotNull(testCases[1]);
            Assert.Equal(expectedLength[1], actual2);

            for (int i = 2; i < NumOfTestCases; i++)
            {
                var actual3 = _objUnderTest.Remove(testCases[i], valuesToRemove[i]);
                Assert.NotNull(testCases[i]);
                Assert.Equal(expectedLength[i], actual3);

                for (int j = 0; j < actual3; j++)
                {
                    Assert.Contains(testCases[i][j], expectedNums[i]);
                }
            }
        }
    }
}
