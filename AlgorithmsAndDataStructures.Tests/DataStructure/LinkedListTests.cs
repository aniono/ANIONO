using AlgorithmsAndDataStructures.DataStructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructure
{
    public class LinkedListTests
    {
        [Fact]
        public void Test_LinkedList()
        {
            // Arrange
            var linkedList = new MyLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            var expected = new int[] { 1, 2, 3, 4, 5 };

            // Act
            var actual = new List<int>();
            var current = linkedList.Head.Next;
            while (current != null)
            {
                actual.Add(current.Key);
                current = current.Next;
            }

            // Assert
            Assert.Equal(5, linkedList.Count);
            for(int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }

        [Fact]
        public void Test_LinkedList_Remove()
        {
            // Arrange
            var linkedList = new MyLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);

            var expected = new int[] { 1, 2, 4, 5 };

            // Act
            linkedList.Remove(3);

            var actual = new List<int>();
            var current = linkedList.Head.Next;
            while (current != null)
            {
                actual.Add(current.Key);
                current = current.Next;
            }

            // Assert
            Assert.Equal(4, linkedList.Count);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }
    }
}
