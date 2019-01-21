using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
namespace TourSite.UI.Models
{
    public class SayfaResimleri
    {
        public int id { get; set; }
        public string resimadi { get; set; }
        [ForeignKey("Sayfa")]
        public int? sayfa_id { get; set; }
        public virtual Sayfa Sayfa { get; set; }
    }

}


/*
 SayfaResimleri ile Sayfa tablosu arasındaki ilişkiyi belirtmemiz gerekiyor. Bunun için SayfaResimleri.cs sınıfında sayfa_id alanından önce [ForeignKey("Sayfa")] tanımını, alandan sonra da public virtual Sayfa Sayfa { get; set; } tanımını yazıyoruz. (int? şeklindeki ifade alana null bilgi girilebileceğini ifade eder.)
     
     */
