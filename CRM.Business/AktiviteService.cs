using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class AktiviteService : IAktiviteService
    {
        private readonly IAktiviteRepository _repository;

        public AktiviteService(IAktiviteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AktiviteDto>> GetAllAsync()
        {
            var aktiviteler = await _repository.GetAllAsync();

            return aktiviteler.Select(a => new AktiviteDto
            {
                AktiviteId = a.AktiviteId,
                MusteriId = a.MusteriId,
                FirsatId = a.FirsatId,
                AktiviteTipi = a.AktiviteTipi,
                Konu = a.Konu,
                Aciklama = a.Aciklama,
                AktiviteDurumu = a.AktiviteDurumu,
                AktiviteTarihi = a.AktiviteTarihi,
                OlusturanKullaniciId = a.OlusturanKullaniciId
            }).ToList();
        }

        public async Task<AktiviteDto?> GetByIdAsync(int id)
        {
            var aktivite = await _repository.GetByIdAsync(id);
            if (aktivite == null)
            {
                return null;
            }

            return new AktiviteDto
            {
                AktiviteId = aktivite.AktiviteId,
                MusteriId = aktivite.MusteriId,
                FirsatId = aktivite.FirsatId,
                AktiviteTipi = aktivite.AktiviteTipi,
                Konu = aktivite.Konu,
                Aciklama = aktivite.Aciklama,
                AktiviteDurumu = aktivite.AktiviteDurumu,
                AktiviteTarihi = aktivite.AktiviteTarihi,
                OlusturanKullaniciId = aktivite.OlusturanKullaniciId
            };
        }

        public async Task AddAsync(AktiviteDto aktiviteDto)
        {
            var aktivite = new Aktivite
            {
                MusteriId = aktiviteDto.MusteriId,
                FirsatId = aktiviteDto.FirsatId,
                AktiviteTipi = aktiviteDto.AktiviteTipi,
                Konu = aktiviteDto.Konu,
                Aciklama = aktiviteDto.Aciklama,
                AktiviteDurumu = aktiviteDto.AktiviteDurumu,
                AktiviteTarihi = aktiviteDto.AktiviteTarihi,
                OlusturanKullaniciId = aktiviteDto.OlusturanKullaniciId
            };

            await _repository.AddAsync(aktivite);
        }

        public async Task UpdateAsync(AktiviteDto aktiviteDto)
        {
            var aktivite = await _repository.GetByIdAsync(aktiviteDto.AktiviteId);
            if (aktivite == null)
            {
                return;
            }

            aktivite.MusteriId = aktiviteDto.MusteriId;
            aktivite.FirsatId = aktiviteDto.FirsatId;
            aktivite.AktiviteTipi = aktiviteDto.AktiviteTipi;
            aktivite.Konu = aktiviteDto.Konu;
            aktivite.Aciklama = aktiviteDto.Aciklama;
            aktivite.AktiviteDurumu = aktiviteDto.AktiviteDurumu;
            aktivite.AktiviteTarihi = aktiviteDto.AktiviteTarihi;
            aktivite.OlusturanKullaniciId = aktiviteDto.OlusturanKullaniciId;

            await _repository.UpdateAsync(aktivite);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}