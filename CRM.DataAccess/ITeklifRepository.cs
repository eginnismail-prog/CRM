using CRM.Entities;

namespace CRM.DataAccess
{
    public interface ITeklifRepository
    {
        Task<List<Teklif>> GetAllAsync();
        Task<Teklif?> GetByIdAsync(int id);
        Task AddAsync(Teklif teklif);
        Task UpdateAsync(Teklif teklif);
        Task DeleteAsync(int id);
    }
}