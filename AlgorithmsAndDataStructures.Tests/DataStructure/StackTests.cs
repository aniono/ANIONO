using AlgorithmsAndDataStructures.DataStructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructure
{
    public class StackTests
    {
        [Fact]
        public void Test_IsEmpty_Returned_True()
        {
            // Arrange
            var stack = new MyStack<int>(3);

            // Act
            var isEmpty = stack.IsEmpty();

            // Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void Test_IsEmpty_Returned_False()
        {
            // Arrange
            var stack = new MyStack<int>(3);
            stack.Push(1);

            // Act
            var isEmpty = stack.IsEmpty();

            // Assert
            Assert.False(isEmpty);
        }

        [Fact]
        public void Test_Push()
        {
            // Arrange
            var stack = new MyStack<int>(3);
            stack.Push(1);
            stack.Push(2);

            // Act
            var topItem = stack.Peek();

            // Assert
            Assert.False(stack.IsEmpty());
            Assert.Equal(2, stack.Count);
            Assert.Equal(2, topItem);
        }

        [Fact]
        public void Test_ExcceedCapacity()
        {
            // Arrange
            var stack = new MyStack<int>(2);
            stack.Push(1);
            stack.Push(2);

            // Act & Assert
            Assert.Throws<Exception>(() =>
            {
                stack.Push(3);
            });
        }

        [Fact]
        public void Test_PopEmptyStack()
        {
            // Arrange
            var stack = new MyStack<int>(3);

            // Act & Assert
            Assert.Throws<Exception>(() =>
            {
                stack.Pop();
            });
        }
    }
}
