using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class TeklifService : ITeklifService
    {
        private readonly ITeklifRepository _repository;

        public TeklifService(ITeklifRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TeklifDto>> GetAllAsync()
        {
            var teklifler = await _repository.GetAllAsync();

            return teklifler.Select(t => new TeklifDto
            {
                TeklifId = t.TeklifId,
                MusteriId = t.MusteriId,
                FirsatId = t.FirsatId,
                TeklifNo = t.TeklifNo,
                TeklifTarihi = t.TeklifTarihi,
                GecerlilikTarihi = t.GecerlilikTarihi,
                ToplamTutar = t.ToplamTutar,
                TeklifDurumu = t.TeklifDurumu
            }).ToList();
        }

        public async Task<TeklifDto?> GetByIdAsync(int id)
        {
            var teklif = await _repository.GetByIdAsync(id);
            if (teklif == null)
            {
                return null;
            }

            return new TeklifDto
            {
                TeklifId = teklif.TeklifId,
                MusteriId = teklif.MusteriId,
                FirsatId = teklif.FirsatId,
                TeklifNo = teklif.TeklifNo,
                TeklifTarihi = teklif.TeklifTarihi,
                GecerlilikTarihi = teklif.GecerlilikTarihi,
                ToplamTutar = teklif.ToplamTutar,
                TeklifDurumu = teklif.TeklifDurumu
            };
        }

        public async Task AddAsync(TeklifDto teklifDto)
        {
            var teklif = new Teklif
            {
                MusteriId = teklifDto.MusteriId,
                FirsatId = teklifDto.FirsatId,
                TeklifNo = teklifDto.TeklifNo,
                TeklifTarihi = teklifDto.TeklifTarihi,
                GecerlilikTarihi = teklifDto.GecerlilikTarihi,
                ToplamTutar = teklifDto.ToplamTutar,
                TeklifDurumu = teklifDto.TeklifDurumu
            };

            await _repository.AddAsync(teklif);
        }

        public async Task UpdateAsync(TeklifDto teklifDto)
        {
            var teklif = await _repository.GetByIdAsync(teklifDto.TeklifId);
            if (teklif == null)
            {
                return;
            }

            teklif.MusteriId = teklifDto.MusteriId;
            teklif.FirsatId = teklifDto.FirsatId;
            teklif.TeklifNo = teklifDto.TeklifNo;
            teklif.TeklifTarihi = teklifDto.TeklifTarihi;
            teklif.GecerlilikTarihi = teklifDto.GecerlilikTarihi;
            teklif.ToplamTutar = teklifDto.ToplamTutar;
            teklif.TeklifDurumu = teklifDto.TeklifDurumu;

            await _repository.UpdateAsync(teklif);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}