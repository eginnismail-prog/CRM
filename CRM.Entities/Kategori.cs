namespace CRM.Entities
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string? Aciklama { get; set; }
        public bool AktifMi { get; set; }
    }
}