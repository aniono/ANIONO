using FeatureSharp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Data
{
    public class PageEnumerator<T> : IEnumerator<Page<T>>
    {
        private Page<T> current;
        private Pagination<T> pagination;

        public PageEnumerator(Pagination<T> pagination)
        {
            current = pagination.Previouse;
            this.pagination = pagination;
        }

        public Page<T> Current => current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            current = null;
        }

        public bool MoveNext()
        {
            int sizeOfLastPage = current.Total % current.Size == 0
                ? current.Size
                : current.Total % current.Size;

            if (sizeOfLastPage == current.Size)
            {
                if (current.Size * (current.Index + 2) > current.Total)
                    return false;
            }
            else
            {
                if (current.Size * (current.Index + 2) > (current.Total - sizeOfLastPage + current.Size))
                    return false;
            }

            current = pagination.GetPage(current.Index + 1);

            return true;
        }

        public void Reset()
        {
            current.Index = -1;      
        }
    }
}
