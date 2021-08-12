using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace esitem.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DisplayName("Eski Şifreniz ")]
        public string  OldPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifreniz ")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifreniz ")]
        public string ConNewPassword { get; set; }
    }
}