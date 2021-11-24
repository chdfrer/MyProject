using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Areas.Database.Models
{
    public class CreateSampleDataModel
    {
        [Display(Name ="Số lượng User")]
        public int NumberOfUser { get; set; } = 100;

        [Display(Name = "Số lượng Category")]
        public int NumberOfCategory { get; set; } = 6;

        [Display(Name = "Số lượng Blog")]
        public int NumberOfBlog { get; set; } = 25;
    }
}
