using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.DotNet
{
    public class RangeOfIntegers : IEnumerable<int>, ICollection<int>
    {
        private int[] numArr;

        public RangeOfIntegers(int capacity)
        {
            numArr = new int[capacity];
        }

        public int Count => numArr.Length;

        public bool IsReadOnly => false;

        public void Add(int item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            numArr = Array.Empty<int>();
        }

        public bool Contains(int item)
        {
            return Array.Exists(numArr, n => n == item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var n in numArr)
                yield return n;
        }

        public bool Remove(int item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return numArr.GetEnumerator();
        }
    }
}
