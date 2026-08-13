using CRM.Entities;

namespace CRM.DataAccess
{
    public interface IMusteriRepository
    {
        Task<List<Musteri>> GetAllAsync();
        Task<Musteri?> GetByIdAsync(int id);
        Task AddAsync(Musteri musteri);
        Task UpdateAsync(Musteri musteri);
        Task DeleteAsync(int id);
    }
}