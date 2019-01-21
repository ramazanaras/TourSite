using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TourSite.Models
{
    public enum konum_bilgisi { Ust, Alt, Sol }
    public class Sayfa
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Başlık")]
        public string baslik { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "Link")]
        public string link { get; set; }
        [AllowHtml]
        [DataType(DataType.Html)]
        [Display(Name = "İçerik")]
        public string icerik { get; set; }
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Keyword")]
        public string keyword { get; set; }
        [Display(Name = "Konum")]
        public konum_bilgisi konum { get; set; }
        [Display(Name = "Onay")]
        public bool onay { get; set; }
        public virtual ICollection<SayfaResimleri> SayfaResimleri { get; set; }

    }

}

/*
 NOT: konum alanını açılır liste kutusu şeklinde oluşturmak için bu alana enum yapısıyla hazır değerler atadık. title, description ve keyword alanları SEO yönetimi için oluşturuldu.     


    NOT: CKEditor kullandığımızda kayıt eklemede içerik (icerik) alanına girilen bilgi, zararlı içerik olarak algılanıp hata oluşmaktadır. Bunu önlemek ve HTML veri girişine izin vermek için Sayfa.cs sınıfında HTML türünde bilgi girişine izin vermek istediğimiz alanın tanımından önce [AllowHtml] filtresini eklemeliyiz. Fakat daha önce using System.Web.Mvc; komutu ile Mvc kütüphanesini sınıfa eklemeliyiz.


    [AllowHtml] filtresine alternatif olarak ekle() metodununun başındaki [HttpPost] ifadesinden sonra ValidateInput(false) filtresi de kullanılabilir. ([HttpPost, ValidateInput(false)] şeklinde)


     */
