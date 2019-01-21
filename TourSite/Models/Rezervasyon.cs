using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TourSite.Models
{
    public class Rezervasyon
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Adı")]
        public string ad { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Soyadı")]
        public string soyad { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-Posta Adresi")]
        public string eposta { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "Telefon No")]
        public string telefon { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Tur Tarihi")]
        public DateTime turtarihi { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Rez. Tarihi")]
        public DateTime reztarihi { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama")]
        public string aciklama { get; set; }
        [Display(Name = "Onay")]
        public bool onay { get; set; }
        [ForeignKey("Tur")]
        public int? tur_id { get; set; }
        public virtual Tur Tur { get; set; }
    }
}