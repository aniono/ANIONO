using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// Merge two sorted linked lists and return it as a new list. 
    /// The new list should be made by splicing together the nodes of the first two lists.
    /// Example:
    /// Output: 1->1->2->3->4->4
    /// Input: 1->2->4, 1->3->4
    /// </summary>
    public class MergeTwoSortedLists
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null) return null;
            else if (l2 == null) return l1;
            else if (l1 == null) return l2;

            var res = new ListNode(0);
            var cur = res;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    cur.next = l1;
                    cur = cur.next;
                    l1 = l1.next;
                }
                else
                {
                    cur.next = l2;
                    cur = cur.next;
                    l2 = l2.next;
                }
            }

            if (l1 != null) cur.next = l1;
            else if (l2 != null) cur.next = l2;

            return res.next;
        }
    }

    /// <summary>
    /// Definition for singly-linked list.
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
