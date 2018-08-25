using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class RemoveDuplicatesFromSortedArrayTests
    {
        private readonly RemoveDuplicatesFromSortedArray _objUnderTest;

        public RemoveDuplicatesFromSortedArrayTests()
        {
            _objUnderTest = new RemoveDuplicatesFromSortedArray();
        }

        [Fact]
        public void Test_RemoveDuplicates()
        {
            const int NumOfCases = 5;
            var testCases = new int[NumOfCases][]
            {
                new int[] { 1, 1, 2 },
                new int[] { 0,0,1,1,1,2,2,3,3,4 },
                new int[] { 0, 0, 0 },
                new int[] { 0,0,1,1,1,1,3,3,3,3,3 },
                new int[] { 1,2 },
            };

            var expectedLens = new int[NumOfCases] { 2, 5, 1, 3, 2 };
            var expectedNums = new int[NumOfCases][]
            {
                new int[] { 1, 2 },
                new int[] { 0, 1, 2, 3, 4 },
                new int[] { 0 },
                new int[] { 0, 1, 3},
                new int[] { 1, 2,},
            };

            var actual = _objUnderTest.RemoveDuplicates(testCases[0]);
            var actual2 = _objUnderTest.RemoveDuplicates(testCases[1]);
            var actual3 = _objUnderTest.RemoveDuplicates(testCases[2]);
            var actual4 = _objUnderTest.RemoveDuplicates(testCases[3]);
            var actual5 = _objUnderTest.RemoveDuplicates(testCases[4]);
            Assert.Equal(expectedLens[0], actual);
            Assert.Equal(expectedLens[1], actual2);
            Assert.Equal(expectedLens[2], actual3);
            Assert.Equal(expectedLens[3], actual4);
            Assert.Equal(expectedLens[4], actual5);

            for (int i = 0; i < NumOfCases; i++)
            {
                for (int j = 0; j < expectedNums[i].Length; j++)
                {
                    Assert.Equal(expectedNums[i][j], testCases[i][j]);
                }
            }
        }
    }
}
