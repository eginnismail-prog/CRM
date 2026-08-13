using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class MusteriService : IMusteriService
    {
        private readonly IMusteriRepository _repository;

        public MusteriService(IMusteriRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MusteriDto>> GetAllAsync()
        {
            var musteriler = await _repository.GetAllAsync();

            return musteriler.Select(m => new MusteriDto
            {
                MusteriId = m.MusteriId,
                Ad = m.Ad,
                Soyad = m.Soyad,
                Telefon = m.Telefon,
                Email = m.Email,
                MusteriDurumu = m.MusteriDurumu
            }).ToList();
        }

        public async Task<MusteriDto?> GetByIdAsync(int id)
        {
            var musteri = await _repository.GetByIdAsync(id);
            if (musteri == null)
            {
                return null;
            }

            return new MusteriDto
            {
                MusteriId = musteri.MusteriId,
                Ad = musteri.Ad,
                Soyad = musteri.Soyad,
                Telefon = musteri.Telefon,
                Email = musteri.Email,
                MusteriDurumu = musteri.MusteriDurumu
            };
        }

        public async Task AddAsync(MusteriDto musteriDto)
        {
            var musteri = new Musteri
            {
                Ad = musteriDto.Ad,
                Soyad = musteriDto.Soyad,
                Telefon = musteriDto.Telefon,
                Email = musteriDto.Email,
                MusteriDurumu = musteriDto.MusteriDurumu,
                OlusturmaTarihi = DateTime.Now
            };

            await _repository.AddAsync(musteri);
        }

        public async Task UpdateAsync(MusteriDto musteriDto)
        {
            var musteri = await _repository.GetByIdAsync(musteriDto.MusteriId);
            if (musteri == null)
            {
                return;
            }

            musteri.Ad = musteriDto.Ad;
            musteri.Soyad = musteriDto.Soyad;
            musteri.Telefon = musteriDto.Telefon;
            musteri.Email = musteriDto.Email;
            musteri.MusteriDurumu = musteriDto.MusteriDurumu;

            await _repository.UpdateAsync(musteri);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}