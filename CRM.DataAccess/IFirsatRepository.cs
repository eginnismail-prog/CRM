using CRM.Entities;

namespace CRM.DataAccess
{
    public interface IFirsatRepository
    {
        Task<List<Firsat>> GetAllAsync();
        Task<Firsat?> GetByIdAsync(int id);
        Task AddAsync(Firsat firsat);
        Task UpdateAsync(Firsat firsat);
        Task DeleteAsync(int id);
    }
}