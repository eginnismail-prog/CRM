namespace CRM.DTO
{
    public class KullaniciDto
    {
        public int KullaniciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
        public bool AktifMi { get; set; }
    }
}