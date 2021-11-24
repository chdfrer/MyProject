using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models.Contacts
{
    public class ContactModel
    {
        [Key]
        public int Id { set; get; }

        [Column(TypeName ="nvarchar")]
        [Required(ErrorMessage ="Phải nhập {0}")]
        [Display(Name ="Tên người gửi")]
        [MaxLength(50)]
        public string SenderName { set; get; }

        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Vui lòng nhập đúng định dạng email!")]
        public string Email { set; get; }

        [Display(Name = "Nội dung liên hệ")]
        public string Message { set; get; }

        [Display(Name = "Ngày gửi")]
        [DataType(DataType.Date)]
        public DateTime SendTime { set; get; }

        [Display(Name ="Số Điện Thoại")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { set; get; }
    }
}
