namespace CRM.DTO
{
    public class TeklifDto
    {
        public int TeklifId { get; set; }
        public int MusteriId { get; set; }
        public int? FirsatId { get; set; }
        public string TeklifNo { get; set; }
        public DateTime TeklifTarihi { get; set; }
        public DateTime? GecerlilikTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public string TeklifDurumu { get; set; }
    }
}