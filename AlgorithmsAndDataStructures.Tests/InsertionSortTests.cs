using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class InsertionSortTests
    {
        private readonly InsertionSort _objUnderTest;

        public InsertionSortTests()
        {
            _objUnderTest = new InsertionSort();
        }

        [Fact]
        public void Test_Sort()
        {
            const int NumberOfTestCase = 3;
            var testCases = new int[NumberOfTestCase][]
            {
                new int[]{ 0, 1, 2, 3 },
                new int[] { 0, 0, 1, 2, 1 },
                new int[] {5, 4, 3, 2, 1 },
            };

            var expected = new int[NumberOfTestCase][]
            {
                testCases[0].OrderBy(x=>x).ToArray(),
                testCases[1].OrderBy(x=>x).ToArray(),
                testCases[2].OrderBy(x=>x).ToArray(),
            };

            for (int i = 0; i < NumberOfTestCase; i++)
            {
                _objUnderTest.Sort(testCases[i]);
                for(int j = 0; j < testCases[i].Length; j++)
                {
                    Assert.Equal(expected[i][j], testCases[i][j]);
                }
            }
        }
    }
}
