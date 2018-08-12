using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FeatureSharp.Models
{
    public class Page<T>
    {
        public Page() : this(0, 0)
        { }

        public Page(int index, int size)
        {
            Index = index;
            Size = size;
        }

        public Page(int index, int size, int total, IEnumerable<T> items)
            : this(index, size)
        {
            Total = total;
            TotalPages = (total % size == 0) ? (total / size) : (total / size + 1);
            Items = items;
        }

        public int Index { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
