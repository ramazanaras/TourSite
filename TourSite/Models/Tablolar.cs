using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TourSite.Models
{
    public class Tablolar : DbContext
    {
        public DbSet<Kullanici> kullanici { get; set; }
        public DbSet<Sayfa> sayfa { get; set; }
        public DbSet<SayfaResimleri> sayfaresimleri { get; set; }
        public DbSet<Tur> tur { get; set; }
        public DbSet<TurResimleri> turresimleri { get; set; }
        public DbSet<TurYorumlari> turyorumlari { get; set; }
        public DbSet<Rezervasyon> rezervasyon { get; set; }

    }
}
