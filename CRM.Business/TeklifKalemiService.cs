using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class TeklifKalemiService : ITeklifKalemiService
    {
        private readonly ITeklifKalemiRepository _repository;

        public TeklifKalemiService(ITeklifKalemiRepository repository)
        {
            _repository = repository;
        }

        private decimal SatirToplamiHesapla(int adet, decimal birimFiyat, decimal? iskontoOrani, decimal kdvOrani)
        {
            decimal araToplam = adet * birimFiyat;

            if (iskontoOrani.HasValue)
            {
                araToplam = araToplam - (araToplam * iskontoOrani.Value / 100);
            }

            decimal kdvTutari = araToplam * kdvOrani / 100;

            return araToplam + kdvTutari;
        }

        public async Task<List<TeklifKalemiDto>> GetAllAsync()
        {
            var kalemler = await _repository.GetAllAsync();

            return kalemler.Select(k => new TeklifKalemiDto
            {
                TeklifKalemiId = k.TeklifKalemiId,
                TeklifId = k.TeklifId,
                UrunId = k.UrunId,
                Adet = k.Adet,
                BirimFiyat = k.BirimFiyat,
                IskontoOrani = k.IskontoOrani,
                KdvOrani = k.KdvOrani,
                SatirToplami = k.SatirToplami
            }).ToList();
        }

        public async Task<TeklifKalemiDto?> GetByIdAsync(int id)
        {
            var kalem = await _repository.GetByIdAsync(id);
            if (kalem == null)
            {
                return null;
            }

            return new TeklifKalemiDto
            {
                TeklifKalemiId = kalem.TeklifKalemiId,
                TeklifId = kalem.TeklifId,
                UrunId = kalem.UrunId,
                Adet = kalem.Adet,
                BirimFiyat = kalem.BirimFiyat,
                IskontoOrani = kalem.IskontoOrani,
                KdvOrani = kalem.KdvOrani,
                SatirToplami = kalem.SatirToplami
            };
        }

        public async Task AddAsync(TeklifKalemiDto kalemDto)
        {
            var kalem = new TeklifKalemi
            {
                TeklifId = kalemDto.TeklifId,
                UrunId = kalemDto.UrunId,
                Adet = kalemDto.Adet,
                BirimFiyat = kalemDto.BirimFiyat,
                IskontoOrani = kalemDto.IskontoOrani,
                KdvOrani = kalemDto.KdvOrani,
                SatirToplami = SatirToplamiHesapla(kalemDto.Adet, kalemDto.BirimFiyat, kalemDto.IskontoOrani, kalemDto.KdvOrani)
            };

            await _repository.AddAsync(kalem);
        }

        public async Task UpdateAsync(TeklifKalemiDto kalemDto)
        {
            var kalem = await _repository.GetByIdAsync(kalemDto.TeklifKalemiId);
            if (kalem == null)
            {
                return;
            }

            kalem.TeklifId = kalemDto.TeklifId;
            kalem.UrunId = kalemDto.UrunId;
            kalem.Adet = kalemDto.Adet;
            kalem.BirimFiyat = kalemDto.BirimFiyat;
            kalem.IskontoOrani = kalemDto.IskontoOrani;
            kalem.KdvOrani = kalemDto.KdvOrani;
            kalem.SatirToplami = SatirToplamiHesapla(kalemDto.Adet, kalemDto.BirimFiyat, kalemDto.IskontoOrani, kalemDto.KdvOrani);

            await _repository.UpdateAsync(kalem);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}