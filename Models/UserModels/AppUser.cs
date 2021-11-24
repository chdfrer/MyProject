using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models.UserModels
{
    public class AppUser : IdentityUser
    {
        [MaxLength(50, ErrorMessage ="Maximum length is {1}")]
        public string Name { set; get; }

        [MaxLength(255, ErrorMessage = "Maximum length is {1}")]
        public string Address { set; get; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { set; get; }
    }
}
