using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FysEtt.Models
{
    public class Pager
    {
        public int CurrentPage { get; set; }
        public int ItemsCount { get; set; }
        public int PageSize { get; set; }
        public int Pages { get; set; }

        public Pager(int page, int itemsCount, int pageSize)
        {
            CurrentPage = page;
            ItemsCount = itemsCount;
            PageSize = pageSize;
            Pages = (int)Math.Ceiling((double)itemsCount / pageSize);
        }
    }
}