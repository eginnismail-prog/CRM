namespace CRM.DTO
{
    public class TeklifKalemiDto
    {
        public int TeklifKalemiId { get; set; }
        public int TeklifId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal? IskontoOrani { get; set; }
        public decimal KdvOrani { get; set; }
        public decimal SatirToplami { get; set; }
    }
}