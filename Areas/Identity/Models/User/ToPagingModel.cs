using MyBlog.Models;
using System.Collections.Generic;

namespace MyBlog.Areas.Identity.Models.UserViewModels
{
    public class ToPagingModel :PagingModel
        {
            public List<UserAndRole> listUserAndRoles { get; set; }
        }
}