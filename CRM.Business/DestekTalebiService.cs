using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class DestekTalebiService : IDestekTalebiService
    {
        private readonly IDestekTalebiRepository _repository;

        public DestekTalebiService(IDestekTalebiRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DestekTalebiDto>> GetAllAsync()
        {
            var talepler = await _repository.GetAllAsync();

            return talepler.Select(t => new DestekTalebiDto
            {
                TalepId = t.TalepId,
                MusteriId = t.MusteriId,
                Konu = t.Konu,
                Aciklama = t.Aciklama,
                Oncelik = t.Oncelik,
                Durum = t.Durum,
                AtananKullaniciId = t.AtananKullaniciId
            }).ToList();
        }

        public async Task<DestekTalebiDto?> GetByIdAsync(int id)
        {
            var talep = await _repository.GetByIdAsync(id);
            if (talep == null)
            {
                return null;
            }

            return new DestekTalebiDto
            {
                TalepId = talep.TalepId,
                MusteriId = talep.MusteriId,
                Konu = talep.Konu,
                Aciklama = talep.Aciklama,
                Oncelik = talep.Oncelik,
                Durum = talep.Durum,
                AtananKullaniciId = talep.AtananKullaniciId
            };
        }

        public async Task AddAsync(DestekTalebiDto talepDto)
        {
            var talep = new DestekTalebi
            {
                MusteriId = talepDto.MusteriId,
                Konu = talepDto.Konu,
                Aciklama = talepDto.Aciklama,
                Oncelik = talepDto.Oncelik,
                Durum = talepDto.Durum,
                AtananKullaniciId = talepDto.AtananKullaniciId,
                OlusturmaTarihi = DateTime.Now
            };

            await _repository.AddAsync(talep);
        }

        public async Task UpdateAsync(DestekTalebiDto talepDto)
        {
            var talep = await _repository.GetByIdAsync(talepDto.TalepId);
            if (talep == null)
            {
                return;
            }

            talep.MusteriId = talepDto.MusteriId;
            talep.Konu = talepDto.Konu;
            talep.Aciklama = talepDto.Aciklama;
            talep.Oncelik = talepDto.Oncelik;
            talep.Durum = talepDto.Durum;
            talep.AtananKullaniciId = talepDto.AtananKullaniciId;

            await _repository.UpdateAsync(talep);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}