using CRM.Entities;

namespace CRM.DataAccess
{
    public interface INotRepository
    {
        Task<List<Not>> GetAllAsync();
        Task<Not?> GetByIdAsync(int id);
        Task AddAsync(Not not);
        Task UpdateAsync(Not not);
        Task DeleteAsync(int id);
    }
}