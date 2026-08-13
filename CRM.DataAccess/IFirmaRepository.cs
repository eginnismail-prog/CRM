using CRM.Entities;

namespace CRM.DataAccess
{
    public interface IFirmaRepository
    {
        Task<List<Firma>> GetAllAsync();
        Task<Firma?> GetByIdAsync(int id);
        Task AddAsync(Firma firma);
        Task UpdateAsync(Firma firma);
        Task DeleteAsync(int id);
    }
}