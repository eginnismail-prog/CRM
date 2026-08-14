using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class SatisService : ISatisService
    {
        private readonly ISatisRepository _repository;

        public SatisService(ISatisRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SatisDto>> GetAllAsync()
        {
            var satislar = await _repository.GetAllAsync();

            return satislar.Select(s => new SatisDto
            {
                SatisId = s.SatisId,
                TeklifId = s.TeklifId,
                MusteriId = s.MusteriId,
                SatisTarihi = s.SatisTarihi,
                ToplamTutar = s.ToplamTutar,
                OdemeDurumu = s.OdemeDurumu,
                Aciklama = s.Aciklama
            }).ToList();
        }

        public async Task<SatisDto?> GetByIdAsync(int id)
        {
            var satis = await _repository.GetByIdAsync(id);
            if (satis == null)
            {
                return null;
            }

            return new SatisDto
            {
                SatisId = satis.SatisId,
                TeklifId = satis.TeklifId,
                MusteriId = satis.MusteriId,
                SatisTarihi = satis.SatisTarihi,
                ToplamTutar = satis.ToplamTutar,
                OdemeDurumu = satis.OdemeDurumu,
                Aciklama = satis.Aciklama
            };
        }

        public async Task AddAsync(SatisDto satisDto)
        {
            var satis = new Satis
            {
                TeklifId = satisDto.TeklifId,
                MusteriId = satisDto.MusteriId,
                SatisTarihi = satisDto.SatisTarihi,
                ToplamTutar = satisDto.ToplamTutar,
                OdemeDurumu = satisDto.OdemeDurumu,
                Aciklama = satisDto.Aciklama
            };

            await _repository.AddAsync(satis);
        }

        public async Task UpdateAsync(SatisDto satisDto)
        {
            var satis = await _repository.GetByIdAsync(satisDto.SatisId);
            if (satis == null)
            {
                return;
            }

            satis.TeklifId = satisDto.TeklifId;
            satis.MusteriId = satisDto.MusteriId;
            satis.SatisTarihi = satisDto.SatisTarihi;
            satis.ToplamTutar = satisDto.ToplamTutar;
            satis.OdemeDurumu = satisDto.OdemeDurumu;
            satis.Aciklama = satisDto.Aciklama;

            await _repository.UpdateAsync(satis);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}