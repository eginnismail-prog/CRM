using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class KategoriService : IKategoriService
    {
        private readonly IKategoriRepository _repository;

        public KategoriService(IKategoriRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<KategoriDto>> GetAllAsync()
        {
            var kategoriler = await _repository.GetAllAsync();

            return kategoriler.Select(k => new KategoriDto
            {
                KategoriId = k.KategoriId,
                KategoriAdi = k.KategoriAdi,
                Aciklama = k.Aciklama,
                AktifMi = k.AktifMi
            }).ToList();
        }

        public async Task<KategoriDto?> GetByIdAsync(int id)
        {
            var kategori = await _repository.GetByIdAsync(id);
            if (kategori == null)
            {
                return null;
            }

            return new KategoriDto
            {
                KategoriId = kategori.KategoriId,
                KategoriAdi = kategori.KategoriAdi,
                Aciklama = kategori.Aciklama,
                AktifMi = kategori.AktifMi
            };
        }

        public async Task AddAsync(KategoriDto kategoriDto)
        {
            var kategori = new Kategori
            {
                KategoriAdi = kategoriDto.KategoriAdi,
                Aciklama = kategoriDto.Aciklama,
                AktifMi = kategoriDto.AktifMi
            };

            await _repository.AddAsync(kategori);
        }

        public async Task UpdateAsync(KategoriDto kategoriDto)
        {
            var kategori = await _repository.GetByIdAsync(kategoriDto.KategoriId);
            if (kategori == null)
            {
                return;
            }

            kategori.KategoriAdi = kategoriDto.KategoriAdi;
            kategori.Aciklama = kategoriDto.Aciklama;
            kategori.AktifMi = kategoriDto.AktifMi;

            await _repository.UpdateAsync(kategori);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}