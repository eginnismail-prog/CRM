using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CRM.Entities;

namespace CRM.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<Firsat> Firsatlar { get; set; }
        public DbSet<Aktivite> Aktiviteler { get; set; }
        public DbSet<Teklif> Teklifler { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<DestekTalebi> DestekTalepleri { get; set; }
        public DbSet<Not> Notlar { get; set; }
    }


}
