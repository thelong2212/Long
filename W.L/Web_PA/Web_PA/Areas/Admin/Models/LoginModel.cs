using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_PA.Areas.Admin.Models
{
    public class LoginModel
    {
        [Key]

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Mời nhập user name")]
        public string UserName { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mời nhập password")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}