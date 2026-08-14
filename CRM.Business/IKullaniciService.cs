using CRM.DTO;

namespace CRM.Business
{
    public interface IKullaniciService
    {
        Task<List<KullaniciDto>> GetAllAsync();
        Task<KullaniciDto?> GetByIdAsync(int id);
        Task AddAsync(KullaniciDto kullaniciDto);
        Task UpdateAsync(KullaniciDto kullaniciDto);
        Task DeleteAsync(int id);
    }
}