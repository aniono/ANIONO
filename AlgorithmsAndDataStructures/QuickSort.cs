using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures
{
    public class QuickSort
    {
        public void Sort(int[] a, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(a, p, r);
                Sort(a, p, q - 1);
                Sort(a, q + 1, r);
            }
        }

        private int Partition(int[] a, int p, int r)
        {
            int t;
            int x = a[r];
            int i = p - 1;

            for (int j = p; j < r; j++)
            {
                if (a[j] <= x)
                {
                    ++i;
                    t = a[i]; a[i] = a[j]; a[j] = t;
                }
            }

            t = a[i + 1]; a[i + 1] = a[r]; a[r] = t;

            return i + 1;
        }
    }
}
