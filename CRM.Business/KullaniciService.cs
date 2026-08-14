using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class KullaniciService : IKullaniciService
    {
        private readonly IKullaniciRepository _repository;

        public KullaniciService(IKullaniciRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<KullaniciDto>> GetAllAsync()
        {
            var kullanicilar = await _repository.GetAllAsync();

            return kullanicilar.Select(k => new KullaniciDto
            {
                KullaniciId = k.KullaniciId,
                Ad = k.Ad,
                Soyad = k.Soyad,
                Email = k.Email,
                RolId = k.RolId,
                AktifMi = k.AktifMi
            }).ToList();
        }

        public async Task<KullaniciDto?> GetByIdAsync(int id)
        {
            var kullanici = await _repository.GetByIdAsync(id);
            if (kullanici == null)
            {
                return null;
            }

            return new KullaniciDto
            {
                KullaniciId = kullanici.KullaniciId,
                Ad = kullanici.Ad,
                Soyad = kullanici.Soyad,
                Email = kullanici.Email,
                RolId = kullanici.RolId,
                AktifMi = kullanici.AktifMi
            };
        }

        public async Task AddAsync(KullaniciDto kullaniciDto)
        {
            var kullanici = new Kullanici
            {
                Ad = kullaniciDto.Ad,
                Soyad = kullaniciDto.Soyad,
                Email = kullaniciDto.Email,
                RolId = kullaniciDto.RolId,
                AktifMi = kullaniciDto.AktifMi,
                SifreHash = "GECICI_SIFRE_" + Guid.NewGuid(),
                OlusturmaTarihi = DateTime.Now
            };

            await _repository.AddAsync(kullanici);
        }

        public async Task UpdateAsync(KullaniciDto kullaniciDto)
        {
            var kullanici = await _repository.GetByIdAsync(kullaniciDto.KullaniciId);
            if (kullanici == null)
            {
                return;
            }

            kullanici.Ad = kullaniciDto.Ad;
            kullanici.Soyad = kullaniciDto.Soyad;
            kullanici.Email = kullaniciDto.Email;
            kullanici.RolId = kullaniciDto.RolId;
            kullanici.AktifMi = kullaniciDto.AktifMi;

            await _repository.UpdateAsync(kullanici);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}