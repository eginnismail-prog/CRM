namespace CRM.DTO
{
    public class DestekTalebiDto
    {
        public int TalepId { get; set; }
        public int MusteriId { get; set; }
        public string Konu { get; set; }
        public string Aciklama { get; set; }
        public string Oncelik { get; set; }
        public string Durum { get; set; }
        public int? AtananKullaniciId { get; set; }
    }
}