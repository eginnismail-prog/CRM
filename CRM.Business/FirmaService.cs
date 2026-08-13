using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class FirmaService : IFirmaService
    {
        private readonly IFirmaRepository _repository;

        public FirmaService(IFirmaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FirmaDto>> GetAllAsync()
        {
            var firmalar = await _repository.GetAllAsync();

            return firmalar.Select(f => new FirmaDto
            {
                FirmaId = f.FirmaId,
                FirmaAdi = f.FirmaAdi,
                VergiNo = f.VergiNo,
                Telefon = f.Telefon,
                Email = f.Email,
                Sehir = f.Sehir,
                AktifMi = f.AktifMi
            }).ToList();
        }

        public async Task<FirmaDto?> GetByIdAsync(int id)
        {
            var firma = await _repository.GetByIdAsync(id);
            if (firma == null)
            {
                return null;
            }

            return new FirmaDto
            {
                FirmaId = firma.FirmaId,
                FirmaAdi = firma.FirmaAdi,
                VergiNo = firma.VergiNo,
                Telefon = firma.Telefon,
                Email = firma.Email,
                Sehir = firma.Sehir,
                AktifMi = firma.AktifMi
            };
        }

        public async Task AddAsync(FirmaDto firmaDto)
        {
            var firma = new Firma
            {
                FirmaAdi = firmaDto.FirmaAdi,
                VergiNo = firmaDto.VergiNo,
                Telefon = firmaDto.Telefon,
                Email = firmaDto.Email,
                Sehir = firmaDto.Sehir,
                AktifMi = firmaDto.AktifMi
            };

            await _repository.AddAsync(firma);
        }

        public async Task UpdateAsync(FirmaDto firmaDto)
        {
            var firma = await _repository.GetByIdAsync(firmaDto.FirmaId);
            if (firma == null)
            {
                return;
            }

            firma.FirmaAdi = firmaDto.FirmaAdi;
            firma.VergiNo = firmaDto.VergiNo;
            firma.Telefon = firmaDto.Telefon;
            firma.Email = firmaDto.Email;
            firma.Sehir = firmaDto.Sehir;
            firma.AktifMi = firmaDto.AktifMi;

            await _repository.UpdateAsync(firma);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}