using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures.DataStructure
{
    public class MyStack<T>
    {
        private readonly T[] _items;
        private int topIndex = -1;

        public MyStack(int capacity)
        {
            _items = new T[capacity];
        }

        public bool IsEmpty()
        {
            return topIndex == -1;
        }

        public void Push(T item)
        {
            if (topIndex >= _items.Length - 1)
                throw new Exception("excceed max capacity of stack.");

            _items[++topIndex] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new Exception("stack already empty.");

            return _items[topIndex--];
        }

        public T Peek()
        {
            return _items[topIndex];
        }

        public int Count { get { return topIndex + 1; } }
    }
}
