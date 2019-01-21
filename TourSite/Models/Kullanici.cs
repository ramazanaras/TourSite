using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace TourSite.Models
{
    public class Kullanici
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }
        [StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Adı")]
        public string adi { get; set; }
        [StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Soyadı")]
        public string soyadi { get; set; }
        [Remote("KullaniciVarmi", "Kullanici", ErrorMessage = "Bu {0} zaten kayıtlı. Lütfen başka bir kullanıcı adı giriniz.", AdditionalFields = "eski_kadi")]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]

[Display(Name = "Kullanıcı Adı")]
        public string kadi { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Şifre en az {2}, en fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Şifre")]
        public string sifre { get; set; }
    }
}


