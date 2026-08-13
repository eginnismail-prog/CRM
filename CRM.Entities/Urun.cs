namespace CRM.Entities
{
    public class Urun
    {
        public int UrunId { get; set; }
        public int KategoriId { get; set; }
        public string UrunAdi { get; set; }
        public string? Aciklama { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal KdvOrani { get; set; }
        public bool AktifMi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }
}