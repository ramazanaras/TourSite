using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TourSite.Models
{
    public class Tur
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(30, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Tur Adı")]
        public string turadi { get; set; }
        [AllowHtml]
        [DataType(DataType.Html)]
        [Display(Name = "İçerik")]
        public string icerik { get; set; }
        [Display(Name = "Tur Zamanı")]
        public string turzamani { get; set; }
        [Display(Name = "Kısa Bilgi")]
        public string kisabilgi { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Display(Name = "Fiyat")]
        public decimal fiyat { get; set; }
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Keyword")]
        public string keyword { get; set; }
        [Display(Name = "Onay")]
        public bool onay { get; set; }
        public virtual ICollection<TurResimleri> TurResimleri { get; set; }
        public virtual ICollection<TurYorumlari> TurYorumlari { get; set; }
        public virtual ICollection<Rezervasyon> Rezervasyon { get; set; }
    }

}