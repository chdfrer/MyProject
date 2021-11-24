using MyBlog.Areas.Categories.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Areas.Blog.Models
{
    public class BlogCategory
    {
        public int BlogId { set; get; }

        public int CategoryId { get; set; }

        [ForeignKey("BlogId")]
        public BlogModel Blog { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryModel Category { get; set; }
    }
}
