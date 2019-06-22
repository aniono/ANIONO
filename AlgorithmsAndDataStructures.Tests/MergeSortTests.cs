using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class MergeSortTests
    {
        private readonly MergeSort _objUnderTest;

        public MergeSortTests()
        {
            _objUnderTest = new MergeSort();
        }

        [Fact]
        public void Test_Sort()
        {
            // Arrange
            const int NumberOfTestCases = 3;
            var testCases = new int[NumberOfTestCases][]
            {
                new int[] { 3, 2, 4, 5, 3, 6, 9 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 5, 4, 3, 2, 1 },
            };
            var expected = new int[NumberOfTestCases][];
            for(int i = 0; i < NumberOfTestCases; i++)
            {
                expected[i] = testCases[i].OrderBy(x => x).ToArray();                
            }
            
            // Act
            for(int i = 0; i < NumberOfTestCases; i++)
            {
                _objUnderTest.Sort(testCases[i], 0, testCases[i].Length - 1);
            }

            // Assert
            for(int i=0;i<NumberOfTestCases;i++)
            {
                for(int j = 0; j < testCases[i].Length; j++)
                {
                    Assert.Equal(expected[i][j], testCases[i][j]);
                }
            }
        }
    }
}
