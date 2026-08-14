namespace CRM.DTO
{
    public class NotDto
    {
        public int NotId { get; set; }
        public int? MusteriId { get; set; }
        public int? FirmaId { get; set; }
        public int? FirsatId { get; set; }
        public string? NotBasligi { get; set; }
        public string NotIcerigi { get; set; }
        public int OlusturanKullaniciId { get; set; }
    }
}