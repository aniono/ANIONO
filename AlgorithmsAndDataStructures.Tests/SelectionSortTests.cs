using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class SelectionSortTests
    {
        private readonly SelectionSort _objUnderTest;

        public SelectionSortTests()
        {
            _objUnderTest = new SelectionSort();
        }

        [Fact]
        public void Test_Sort()
        {
            var testCases = new int[][]
            {
               null,
               new int[] { },
               new int[] { 2, 1, 3 },
               new int[] { 1, 2, 3 },
               new int[] { 3, 2, 1 }
            };

            _objUnderTest.Sort(testCases[0]);
            Assert.Null(testCases[0]);

            _objUnderTest.Sort(testCases[1]);
            Assert.NotNull(testCases[1]);
            Assert.Empty(testCases[1]);

            var expected3 = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 1, 2, 3 },
                new int[] { 1, 2, 3 }
            };

            for (int i = 2; i < expected3.Length; i++)
            {
                _objUnderTest.Sort(testCases[i]);

                Assert.NotNull(testCases[i]);
                Assert.NotEmpty(testCases[i]);
                Assert.Equal(expected3[i].Length, testCases[i].Length);

                for (int j = 0; j < expected3.Length; j++)
                    Assert.Equal(expected3[i][j], testCases[i][j]);
            }
        }

        [Fact]
        public void Test_IndexOfMinNum()
        {
            var testCases = new int[][]
            {
                new int[] { 3, 2, 0, -1, 5, 9 },
                new int[] { 0, 0, 0, 5, -1, 5 },
                new int[] { -1, 0, 3 },
                new int[] { 1, 2, 3, 0 }
            };

            var expected = new int[] { 3, 4 , 0, 3};
            var actual = _objUnderTest.IndexOfMinNum(testCases[0], 0, testCases[0].Length - 1);
            var actual2 = _objUnderTest.IndexOfMinNum(testCases[1], 0, testCases[1].Length - 1);
            var actual3 = _objUnderTest.IndexOfMinNum(testCases[2], 0, testCases[2].Length - 1);
            var actual4 = _objUnderTest.IndexOfMinNum(testCases[3], 0, testCases[3].Length - 1);

            Assert.Equal(expected[0], actual);
            Assert.Equal(expected[1], actual2);
            Assert.Equal(expected[2], actual3);
            Assert.Equal(expected[3], actual4);
        }
    }
}
