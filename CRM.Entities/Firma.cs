namespace CRM.Entities
{
    public class Firma
    {
        public int FirmaId { get; set; }
        public string FirmaAdi { get; set; }
        public string? VergiNo { get; set; }
        public string? VergiDairesi { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public string? Sehir { get; set; }
        public string? Adres { get; set; }
        public bool AktifMi { get; set; }
    }
}