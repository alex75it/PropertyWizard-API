using System;

namespace PropertyWizard.Core
{
    public class RequestPagingInfo
    {
        /// <summary>
        /// Number of riems for page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Page number (1-based).
        /// </summary>
        public int PageNumber { get; set; }
                
        public static RequestPagingInfo Create(int pageSize, int pageNumber)
        {
            return new RequestPagingInfo()
            {
                PageSize = pageSize,
                PageNumber = pageNumber
            };
        }
    }
}
