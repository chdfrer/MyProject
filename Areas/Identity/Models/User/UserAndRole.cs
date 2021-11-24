using MyBlog.Models.UserModels;

namespace MyBlog.Areas.Identity.Models.UserViewModels
{
    public class UserAndRole : AppUser
        {
            public string RoleNames { get; set; }
        }


}