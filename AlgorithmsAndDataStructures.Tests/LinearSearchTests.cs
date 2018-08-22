using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class LinearSearchTests
    {
        private readonly LinearSearch _objectUnderTest;

        public LinearSearchTests()
        {
            _objectUnderTest = new LinearSearch();
        }

        [Fact]
        public void Test_Search01()
        {
            const int SizeOfTestCases = 4;
            var testCases = new int[SizeOfTestCases][]
            {
                null,
                new int[] {},
                new int[] { 1, 2, 3, 5 },
                new int[] { 1, 2, 3, 5 },
            };

            var target = new int[] { 0, 0, 5, 1 };
            var expected = new int[SizeOfTestCases] { -1, -1, 3, 0 };

            for (int i = 0; i < SizeOfTestCases; i++)
            {
                int actual = _objectUnderTest.Search01(target[i], testCases[i]);
                Assert.Equal(expected[i], actual);
            }
        }

        [Fact]
        public void Test_Search02()
        {
            const int SizeOfTestCases = 4;
            Node nums = new Node(0);
            Node t = nums;

            for (int i = 1; i < SizeOfTestCases; i++)
            {
                t.Next = new Node(i);
                t = t.Next;
            }

            var actual = _objectUnderTest.Search02(-1, nums);
            Assert.Null(actual);

            for (int i = 0; i < SizeOfTestCases; i++)
            {
                var actual1 = _objectUnderTest.Search02(i, nums);
                Assert.NotNull(actual1);
                Assert.Equal(i, actual1.Data);
            }
        }

        [Fact]
        public void Test_Search03()
        {
            const int SizeOfTestCases = 4;
            var testCases = new int[SizeOfTestCases][]
            {
                null,
                new int[] {},
                new int[] { 1, 2, 3, 5 },
                new int[] { 1, 2, 3, 5 },
            };

            var target = new int[] { 0, 0, 5, 1 };
            var expected = new int[SizeOfTestCases] { -1, -1, 3, 0 };

            for (int i = 0; i < SizeOfTestCases; i++)
            {
                int actual = _objectUnderTest.Search03(target[i], 0, testCases[i]);
                Assert.Equal(expected[i], actual);
            }
        }

        [Fact]
        public void Test_Search04()
        {
            const int SizeOfTestCases = 4;
            Node nums = new Node(0);
            Node t = nums;

            for (int i = 1; i < SizeOfTestCases; i++)
            {
                t.Next = new Node(i);
                t = t.Next;
            }

            var actual = _objectUnderTest.Search04(-1, nums);
            Assert.Null(actual);

            for (int i = 0; i < SizeOfTestCases; i++)
            {
                var actual1 = _objectUnderTest.Search04(i, nums);
                Assert.NotNull(actual1);
                Assert.Equal(i, actual1.Data);
            }
        }

        [Fact]
        public void Test_Search05()
        {
            const int SizeOfTestCases = 4;
            var testCases = new int[SizeOfTestCases][]
            {
                null,
                new int[] {},
                new int[] { 1, 2, 3, 5 },
                new int[] { 1, 2, 3, 5 },
            };

            var target = new int[] { 0, 0, 5, 1 };
            var expected = new int[SizeOfTestCases] { -1, -1, 0, 0 };

            for (int i = 0; i < SizeOfTestCases; i++)
            {
                int actual = _objectUnderTest.Search05(target[i], testCases[i]);

                Assert.Equal(expected[i], actual);
            }
        }

        [Fact]
        public void Test_Search06()
        {
            const int SizeOfTestCases = 4;
            var testCases = new int[SizeOfTestCases][]
            {
                null,
                new int[] {},
                new int[] { 1, 2, 3, 5 },
                new int[] { 1, 2, 3, 5 },
            };

            var target = new int[] { 0, 0, 5, 1 };
            var expected = new int[SizeOfTestCases] { -1, -1, 2, 0 };

            for (int i = 0; i < SizeOfTestCases; i++)
            {
                int actual = _objectUnderTest.Search06(target[i], testCases[i]);

                Assert.Equal(expected[i], actual);
            }
        }

        [Fact]
        public void Test_Search07()
        {
            const int SizeOfTestCases = 4;
            Node nums = new Node(0);
            Node t = nums;

            for (int i = 1; i < SizeOfTestCases; i++)
            {
                t.Next = new Node(i);
                t = t.Next;
            }

            var actual = _objectUnderTest.Search02(-1, nums);
            Assert.Null(actual);

            for (int i = 0; i < SizeOfTestCases; i++)
            {
                var actual1 = _objectUnderTest.Search07(i, nums);
                Assert.NotNull(actual1);
                Assert.Equal(i, actual1.Data);
            }
        }
    }
}