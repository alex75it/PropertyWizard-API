using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWizard.Core
{
    public class PagedResult<T>
    {
        /// <summary>
        /// Number of items for page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Page number (1-based).
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Number of items in this apge.
        /// </summary>
        public int ItemsNumber { get; set; }
        /// <summary>
        /// Flase if there are more pages
        /// </summary>
        public bool IsLastPage { get; set; }

        public ICollection<T> Items { get; set; }


        public static PagedResult<T> Create(RequestPagingInfo paging, ICollection<T> items, bool isLastPage = false)
        {
            return
            new PagedResult<T>() {
                Items = items,
                PageSize = paging.PageSize,
                PageNumber = paging.PageNumber,
                ItemsNumber = items.Count,
                IsLastPage = isLastPage
            };
        }

    }
}
