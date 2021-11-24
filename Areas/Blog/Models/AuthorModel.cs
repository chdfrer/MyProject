using MyBlog.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Areas.Blog.Models
{
    public class AuthorModel
    {
        //[Required]
        [Display(Name = "Tác giả")]
        public string AuthorId { set; get; }

        [ForeignKey("AuthorId")]
        [Display(Name = "Tác giả")]
        public AppUser Author { set; get; }

        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { set; get; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime DateUpdated { set; get; }
    }
}
