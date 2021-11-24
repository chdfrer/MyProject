using System.ComponentModel.DataAnnotations;


namespace MyBlog.Areas.Blog.Models
{
    public class CreateBlogModel : BlogModel
    {
        [Display(Name = "Danh mục")]
        [Required(ErrorMessage ="Phải chọn {0}")]
        public int[] CategoryIds { set; get; }
    }
}
