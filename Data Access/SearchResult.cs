using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWizard.DataAccess
{
    public class SearchResult<T>
    {
        public ICollection<T> Items { get; set; }
        public long NumberOfItems { get; set; }
    }
}
