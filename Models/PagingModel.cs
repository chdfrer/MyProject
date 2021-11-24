using System;

namespace MyBlog.Models
{
    public class PagingModel
    {
        private int countPage;
        private int currentPage;
        private int totalItem;

        public int TotalItem
        {
            get => totalItem;
            set
            {
                totalItem = value;
                if (ItemPerPage > 0) countPage = (int)Math.Ceiling((double)TotalItem / ItemPerPage);
            }
        }

        public int ItemPerPage { get; set; } = 10;

        public int CurrentPage
        {
            set { currentPage = value; }
            get
            {
                if (currentPage < 1) return 1;
                if (currentPage > countPage && countPage > 0) return countPage;
                return currentPage;
            }
        }

        public int CountPages
        {
            get
            {
                return (int)Math.Ceiling((double)TotalItem / ItemPerPage);
            }
        }

        public Func<int?, string> generateUrl { get; set; }
        
    }
}