using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class FirsatService : IFirsatService
    {
        private readonly IFirsatRepository _repository;

        public FirsatService(IFirsatRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FirsatDto>> GetAllAsync()
        {
            var firsatlar = await _repository.GetAllAsync();

            return firsatlar.Select(f => new FirsatDto
            {
                FirsatId = f.FirsatId,
                MusteriId = f.MusteriId,
                FirsatBasligi = f.FirsatBasligi,
                Aciklama = f.Aciklama,
                TahminiTutar = f.TahminiTutar,
                FirsatDurumu = f.FirsatDurumu,
                Kaynak = f.Kaynak,
                SorumluKullaniciId = f.SorumluKullaniciId,
                BeklenenKapanisTarihi = f.BeklenenKapanisTarihi
            }).ToList();
        }

        public async Task<FirsatDto?> GetByIdAsync(int id)
        {
            var firsat = await _repository.GetByIdAsync(id);
            if (firsat == null)
            {
                return null;
            }

            return new FirsatDto
            {
                FirsatId = firsat.FirsatId,
                MusteriId = firsat.MusteriId,
                FirsatBasligi = firsat.FirsatBasligi,
                Aciklama = firsat.Aciklama,
                TahminiTutar = firsat.TahminiTutar,
                FirsatDurumu = firsat.FirsatDurumu,
                Kaynak = firsat.Kaynak,
                SorumluKullaniciId = firsat.SorumluKullaniciId,
                BeklenenKapanisTarihi = firsat.BeklenenKapanisTarihi
            };
        }

        public async Task AddAsync(FirsatDto firsatDto)
        {
            var firsat = new Firsat
            {
                MusteriId = firsatDto.MusteriId,
                FirsatBasligi = firsatDto.FirsatBasligi,
                Aciklama = firsatDto.Aciklama,
                TahminiTutar = firsatDto.TahminiTutar,
                FirsatDurumu = firsatDto.FirsatDurumu,
                Kaynak = firsatDto.Kaynak,
                SorumluKullaniciId = firsatDto.SorumluKullaniciId,
                BeklenenKapanisTarihi = firsatDto.BeklenenKapanisTarihi,
                OlusturmaTarihi = DateTime.Now
            };

            await _repository.AddAsync(firsat);
        }

        public async Task UpdateAsync(FirsatDto firsatDto)
        {
            var firsat = await _repository.GetByIdAsync(firsatDto.FirsatId);
            if (firsat == null)
            {
                return;
            }

            firsat.MusteriId = firsatDto.MusteriId;
            firsat.FirsatBasligi = firsatDto.FirsatBasligi;
            firsat.Aciklama = firsatDto.Aciklama;
            firsat.TahminiTutar = firsatDto.TahminiTutar;
            firsat.FirsatDurumu = firsatDto.FirsatDurumu;
            firsat.Kaynak = firsatDto.Kaynak;
            firsat.SorumluKullaniciId = firsatDto.SorumluKullaniciId;
            firsat.BeklenenKapanisTarihi = firsatDto.BeklenenKapanisTarihi;

            await _repository.UpdateAsync(firsat);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}