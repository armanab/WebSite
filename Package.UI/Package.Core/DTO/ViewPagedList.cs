using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Package.Core.DTO
{
    public class ViewPagedList<T>
    {
        public ViewPagedList()
        {
            if (Items==null)
            {
                Items = new List<T>();
            }
        }

        /// <summary>
        /// Gets the index start value.
        /// </summary>
        /// <value>The index start value.</value>
        public int IndexFrom { get; }
        /// <summary>
        /// Gets the page index (current).
        /// </summary>
        public int PageIndex { get; }
        /// <summary>
        /// Gets the page size.
        /// </summary>
        public int PageSize { get; }
        /// <summary>
        /// Gets the total count of the list of type <typeparamref name="T"/>
        /// </summary>
        public int TotalCount { get; }
        /// <summary>
        /// Gets the total pages.
        /// </summary>
        public int TotalPages { get; }
        /// <summary>
        /// Gets the current page items.
        /// </summary>
        public IList<T> Items { get; }



        /// <summary>
        /// Gets the has previous page.
        /// </summary>
        /// <value>The has previous page.</value>
        public bool HasPreviousPage { get; }

        /// <summary>
        /// Gets the has next page.
        /// </summary>
        /// <value>The has next page.</value>
        public bool HasNextPage { get; }
    }
}
