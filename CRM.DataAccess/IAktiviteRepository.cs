using CRM.Entities;

namespace CRM.DataAccess
{
    public interface IAktiviteRepository
    {
        Task<List<Aktivite>> GetAllAsync();
        Task<Aktivite?> GetByIdAsync(int id);
        Task AddAsync(Aktivite aktivite);
        Task UpdateAsync(Aktivite aktivite);
        Task DeleteAsync(int id);
    }
}