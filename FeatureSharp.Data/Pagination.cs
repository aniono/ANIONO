using FeatureSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace FeatureSharp.Data
{
    public class Pagination<T> : IEnumerable<Page<T>>
    {
        private Page<T> first;
        private Page<T> previous;
        private Page<T> current;
        private Page<T> next;
        private Page<T> last;

        public Page<T> Page { get; private set; }

        public IEnumerable<T> Items { get; private set; }

        public Page<T> First
        {
            get
            {
                if (first == null)
                    Paging();

                return first;
            }
        }

        public Page<T> Previouse
        {
            get
            {
                if (previous == null)
                    Paging();

                return previous;
            }
        }

        public Page<T> Current
        {
            get
            {
                if (current == null)
                    Paging();

                return current;
            }
        }

        public Page<T> Next
        {
            get
            {
                if (next == null)
                    Paging();

                return next;
            }
        }

        public Page<T> Last
        {
            get
            {
                if (last == null)
                    Paging();

                return last;
            }
        }

        public Pagination() { }

        public Pagination(Page<T> page, IEnumerable<T> items)
        {
            if (page == null || items == null)
                throw new ArgumentNullException(nameof(page) + " or " + nameof(items));

            Page = page;
            Page.Total = items.Count();
            Items = items;
        }

        public Page<T> GetPage(int pageIndex)
        {
            var query = Items.AsQueryable();
            var queryPage = query.Skip((pageIndex) * Page.Size).Take(Page.Size);

            return new Page<T>(pageIndex, Page.Size, Page.Total, queryPage);
        }

        private void Paging()
        {
            var query = Items.AsQueryable();
            int skipCountForPrevious = (Page.Index - 1) * Page.Size;
            int skipCountForCurrent = Page.Index * Page.Size;
            int skipCountForNext = (Page.Index + 1) * Page.Size;
            var queryFirst = query.Take(Page.Size);
            var queryPrevious = Page.Index == 0 ? null : query.Skip(skipCountForPrevious).Take(Page.Size);
            var queryCurrent = query.Skip(skipCountForCurrent).Take(Page.Size);
            var queryNext = query.Skip(skipCountForNext).Take(Page.Size);
            first = new Page<T>(0, Page.Size, Page.Total, queryFirst);
            current = new Page<T>(Page.Index, Page.Size, Page.Total, queryCurrent);
            previous = new Page<T>(Page.Index - 1, Page.Size, Page.Total, queryPrevious);
            next = new Page<T>(Page.Index + 1, Page.Size, Page.Total, queryNext);

            Page.Total = query.Count();
            int lastPageIndex = (Page.Total % Page.Size == 0)
                ? (Page.Total / Page.Size - 1)
                : (Page.Total / Page.Size);
            int lastPageSize = (Page.Total % Page.Size == 0)
                ? Page.Size
                : Page.Total % Page.Size;

            var queryLast = query.Reverse().Take(lastPageSize);
            last = new Page<T>(lastPageIndex, lastPageSize, Page.Total, queryLast);
        }

        public IEnumerator<Page<T>> GetEnumerator()
        {
            return new PageEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
