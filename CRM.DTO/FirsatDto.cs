namespace CRM.DTO
{
    public class FirsatDto
    {
        public int FirsatId { get; set; }
        public int MusteriId { get; set; }
        public string FirsatBasligi { get; set; }
        public string? Aciklama { get; set; }
        public decimal? TahminiTutar { get; set; }
        public string FirsatDurumu { get; set; }
        public string? Kaynak { get; set; }
        public int SorumluKullaniciId { get; set; }
        public DateTime? BeklenenKapanisTarihi { get; set; }
    }
}
