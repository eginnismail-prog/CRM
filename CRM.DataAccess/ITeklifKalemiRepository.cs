using CRM.Entities;

namespace CRM.DataAccess
{
    public interface ITeklifKalemiRepository
    {
        Task<List<TeklifKalemi>> GetAllAsync();
        Task<TeklifKalemi?> GetByIdAsync(int id);
        Task AddAsync(TeklifKalemi kalem);
        Task UpdateAsync(TeklifKalemi kalem);
        Task DeleteAsync(int id);
    }
}