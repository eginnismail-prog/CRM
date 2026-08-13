using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class UrunService : IUrunService
    {
        private readonly IUrunRepository _repository;

        public UrunService(IUrunRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UrunDto>> GetAllAsync()
        {
            var urunler = await _repository.GetAllAsync();

            return urunler.Select(u => new UrunDto
            {
                UrunId = u.UrunId,
                KategoriId = u.KategoriId,
                UrunAdi = u.UrunAdi,
                Aciklama = u.Aciklama,
                BirimFiyat = u.BirimFiyat,
                KdvOrani = u.KdvOrani,
                AktifMi = u.AktifMi
            }).ToList();
        }

        public async Task<UrunDto?> GetByIdAsync(int id)
        {
            var urun = await _repository.GetByIdAsync(id);
            if (urun == null)
            {
                return null;
            }

            return new UrunDto
            {
                UrunId = urun.UrunId,
                KategoriId = urun.KategoriId,
                UrunAdi = urun.UrunAdi,
                Aciklama = urun.Aciklama,
                BirimFiyat = urun.BirimFiyat,
                KdvOrani = urun.KdvOrani,
                AktifMi = urun.AktifMi
            };
        }

        public async Task AddAsync(UrunDto urunDto)
        {
            var urun = new Urun
            {
                KategoriId = urunDto.KategoriId,
                UrunAdi = urunDto.UrunAdi,
                Aciklama = urunDto.Aciklama,
                BirimFiyat = urunDto.BirimFiyat,
                KdvOrani = urunDto.KdvOrani,
                AktifMi = urunDto.AktifMi,
                OlusturmaTarihi = DateTime.Now
            };

            await _repository.AddAsync(urun);
        }

        public async Task UpdateAsync(UrunDto urunDto)
        {
            var urun = await _repository.GetByIdAsync(urunDto.UrunId);
            if (urun == null)
            {
                return;
            }

            urun.KategoriId = urunDto.KategoriId;
            urun.UrunAdi = urunDto.UrunAdi;
            urun.Aciklama = urunDto.Aciklama;
            urun.BirimFiyat = urunDto.BirimFiyat;
            urun.KdvOrani = urunDto.KdvOrani;
            urun.AktifMi = urunDto.AktifMi;

            await _repository.UpdateAsync(urun);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}