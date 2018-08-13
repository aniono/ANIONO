using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class MergeTwoSortedListsTests
    {
        private readonly MergeTwoSortedLists _objUnderTest;

        public MergeTwoSortedListsTests()
        {
            _objUnderTest = new MergeTwoSortedLists();
        }

        [Fact]
        public void Test_MergeTwoLists()
        {
            var l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);

            var l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);

            var expected = new int[] { 1, 1, 2, 3, 4, 4 };
            var actual = _objUnderTest.MergeTwoLists(l1, l2);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], actual.val);
                actual = actual.next;
            }
        }
    }
}
