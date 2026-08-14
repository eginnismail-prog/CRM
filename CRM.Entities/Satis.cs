namespace CRM.Entities
{
    public class Satis
    {
        public int SatisId { get; set; }
        public int TeklifId { get; set; }
        public int MusteriId { get; set; }
        public DateTime SatisTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public string OdemeDurumu { get; set; }
        public string? Aciklama { get; set; }
    }
}