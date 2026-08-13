using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DTO
{
    public class MusteriDto
    {
        public int MusteriId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string? Email { get; set; }
        public string MusteriDurumu { get; set; }
    }
}
