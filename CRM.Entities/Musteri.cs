using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Entities
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string? Email { get; set; }
        public int? FirmaId { get; set; }
        public string MusteriDurumu { get; set; }
        public string? Kaynak { get; set; }
        public int? SorumluKullaniciId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }
}
