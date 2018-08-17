using Xunit;

namespace LeetCodeProblems.Tests
{
    public class FindFirstAndLastPositionTests
    {
        private readonly FindFirstAndLastPosition _objUnderTest;

        public FindFirstAndLastPositionTests()
        {
            _objUnderTest = new FindFirstAndLastPosition();
        }

        [Fact]
        public void Test_SearchRange()
        {
            const int NumOfTestCases = 4;
            var testCases = new int[NumOfTestCases][]
            {
                null,
                new int[] { },
                new int[] { 5, 7, 7, 8, 8, 10 },
                new int[] { 5, 7, 7, 8, 8, 10 },
            };

            var targets = new int[NumOfTestCases] { 0, 0, 8, 6 };
            var expecteds = new int[NumOfTestCases][]
            {
                new int[] { -1, -1 },
                new int[] { -1, -1 },
                new int[] { 3, 4 },
                new int[] { -1, -1 },
            };

            for (int i = 0; i < NumOfTestCases; i++)
            {
                var actual = _objUnderTest.SearchRange(testCases[i], targets[i]);
                Assert.NotNull(actual);
                Assert.Equal(expecteds[i][0], actual[0]);
                Assert.Equal(expecteds[i][1], actual[1]);
            }
        }
    }
}
