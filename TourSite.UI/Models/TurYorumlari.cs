using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TourSite.UI.Models
{
    public class TurYorumlari
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(30, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Adı Soyadı")]
        public string adsoyad { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-Posta Adresi")]
        public string eposta { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Yorum")]
        public string yorum { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Tarih")]
        public DateTime tarih { get; set; }
        [Display(Name = "Onay")]
        public bool onay { get; set; }
        [ForeignKey("Tur")]
        public int? tur_id { get; set; }
        public virtual Tur Tur { get; set; }
    }

}