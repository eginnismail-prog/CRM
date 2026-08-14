using CRM.Entities;

namespace CRM.DataAccess
{
    public interface IKullaniciRepository
    {
        Task<List<Kullanici>> GetAllAsync();
        Task<Kullanici?> GetByIdAsync(int id);
        Task AddAsync(Kullanici kullanici);
        Task UpdateAsync(Kullanici kullanici);
        Task DeleteAsync(int id);
    }
}