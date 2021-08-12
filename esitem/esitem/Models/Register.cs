using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace esitem.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız ")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadınız ")]
        public string Surname { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı ")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Email Adresi ")]
        [EmailAddress(ErrorMessage ="Geçersiz Email Adresi..")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Şifre ")]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage ="Lütfen Şifrenizi Aynı Giriniz..")]
        [DisplayName("Şifre Tekrarı ")]
        public string RePassword { get; set; }
    }
}