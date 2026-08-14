using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class NotService : INotService
    {
        private readonly INotRepository _repository;

        public NotService(INotRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<NotDto>> GetAllAsync()
        {
            var notlar = await _repository.GetAllAsync();

            return notlar.Select(n => new NotDto
            {
                NotId = n.NotId,
                MusteriId = n.MusteriId,
                FirmaId = n.FirmaId,
                FirsatId = n.FirsatId,
                NotBasligi = n.NotBasligi,
                NotIcerigi = n.NotIcerigi,
                OlusturanKullaniciId = n.OlusturanKullaniciId
            }).ToList();
        }

        public async Task<NotDto?> GetByIdAsync(int id)
        {
            var not = await _repository.GetByIdAsync(id);
            if (not == null)
            {
                return null;
            }

            return new NotDto
            {
                NotId = not.NotId,
                MusteriId = not.MusteriId,
                FirmaId = not.FirmaId,
                FirsatId = not.FirsatId,
                NotBasligi = not.NotBasligi,
                NotIcerigi = not.NotIcerigi,
                OlusturanKullaniciId = not.OlusturanKullaniciId
            };
        }

        public async Task AddAsync(NotDto notDto)
        {
            var not = new Not
            {
                MusteriId = notDto.MusteriId,
                FirmaId = notDto.FirmaId,
                FirsatId = notDto.FirsatId,
                NotBasligi = notDto.NotBasligi,
                NotIcerigi = notDto.NotIcerigi,
                OlusturanKullaniciId = notDto.OlusturanKullaniciId,
                OlusturmaTarihi = DateTime.Now
            };

            await _repository.AddAsync(not);
        }

        public async Task UpdateAsync(NotDto notDto)
        {
            var not = await _repository.GetByIdAsync(notDto.NotId);
            if (not == null)
            {
                return;
            }

            not.MusteriId = notDto.MusteriId;
            not.FirmaId = notDto.FirmaId;
            not.FirsatId = notDto.FirsatId;
            not.NotBasligi = notDto.NotBasligi;
            not.NotIcerigi = notDto.NotIcerigi;
            not.OlusturanKullaniciId = notDto.OlusturanKullaniciId;

            await _repository.UpdateAsync(not);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}