using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class BinarySearchTests
    {
        private readonly BinarySearch _objUnderTest;

        public BinarySearchTests()
        {
            _objUnderTest = new BinarySearch();
        }

        [Fact]
        public void Test_Search()
        {
            const int NumOfTestCases = 4;
            var inputs = new int[NumOfTestCases][]
            {
                new int[] { 1, 2, 4, 8, 10 },
                new int[] { -1, 2, 4, 5, 8, 20, 10 },
                new int[] { 1, 4, 50, 68, 80 },
                new int[] { 1, 3, 4, 5, 28, 90 },
            };

            var targets = new int[NumOfTestCases] { 8, 5, 4, 20 };
            var expected = new int[NumOfTestCases] { 3, 3, 1, -1 };

            for (int i = 0; i < NumOfTestCases; i++)
            {
                var actual = _objUnderTest.Search(targets[i], inputs[i]);
                Assert.Equal(expected[i], actual);
            }
        }
    }
}
