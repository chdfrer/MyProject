using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Areas.Categories.Models;

namespace MyBlog.Views.Shared.Components.CategorySideBar
{
    public class CategorySidebar : ViewComponent
    {
        public class CategorySidebarData
        {
            public List<CategoryModel> categories { set; get; }
            public int level { set; get; } = 0;
            public string slugCategory { set; get; }
        }

        public const string COMPONENTNAME = "CategorySidebar";
        public CategorySidebar() { }
        public IViewComponentResult Invoke(CategorySidebarData data)
        {
            return View(data);
        }
    }
}
