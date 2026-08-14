namespace CRM.DTO
{
    public class AktiviteDto
    {
        public int AktiviteId { get; set; }
        public int? MusteriId { get; set; }
        public int? FirsatId { get; set; }
        public string AktiviteTipi { get; set; }
        public string Konu { get; set; }
        public string? Aciklama { get; set; }
        public string AktiviteDurumu { get; set; }
        public DateTime AktiviteTarihi { get; set; }
        public int OlusturanKullaniciId { get; set; }
    }
}