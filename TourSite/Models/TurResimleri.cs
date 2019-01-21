using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace TourSite.Models
{
    public class TurResimleri
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Resim Adı")]
        public string resimadi { get; set; }
        [ForeignKey("Tur")]
        public int? tur_id { get; set; }
        public virtual Tur Tur { get; set; }
    }
}

/*
 TurResimleri ile Tur tablosu arasındaki ilişkiyi belirtmemiz gerekiyor. Bunun için TurResimleri.cs sınıfında tur_id alanından önce [ForeignKey("Tur")] tanımını, alandan sonra da public virtual Tur Tur { get; set; } tanımını yazıyoruz. (int? şeklindeki ifade alana null bilgi girilebileceğini ifade eder.)
NOT: ForeignKey ifadesini sınıfta tanımlamak için mavi çizgi altındaki menüden using System.ComponentModel.DataAnnotations.Schema seçeneğini tıklayınız.
Ayrıca TurResimleri tablosu ile Tur tablosu arasındaki ilişki tanımını Tur.cs sınıfında da belirtmemiz gerekiyor. Bunun için Tur.cs sınıfında alan tanımlarından sonra public virtual ICollection<TurResimleri> TurResimleri { get; set; } tanımını yazıyoruz.
     
     */
