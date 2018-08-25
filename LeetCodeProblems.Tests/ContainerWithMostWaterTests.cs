using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class ContainerWithMostWaterTests
    {
        private readonly ContainerWithMostWater _objUnderTest;

        public ContainerWithMostWaterTests()
        {
            _objUnderTest = new ContainerWithMostWater();
        }

        [Fact]
        public void Test_MaxArea()
        {
            var testCases = new int[][]
            {
                new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 },
            };

            var expected = new int[] { 49 };
            var actual = _objUnderTest.MaxArea(testCases[0]);
            Assert.Equal(expected[0], actual);
        }
    }
}
