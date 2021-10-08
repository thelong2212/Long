using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhucAnh_done.Models
{
    public class RegisterModels
    {
        [Key]
        public long ID { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]

        public string UserName { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { set; get; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string Name { set; get; }

        [Display(Name = "Địa chỉ")]
        public string Address { set; get; }

        [Required(ErrorMessage = "Email không được để trống")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail không hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Điện thoại")]
        public int Phone { set; get; }

        public string DistrictID { set; get; }
        [Display(Name = "Địa chỉ chi tiết")]
        public string DiaChiChiTiet { set; get; }
    }
}