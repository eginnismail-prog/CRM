using CRM.Entities;

namespace CRM.DataAccess
{
    public interface ISatisRepository
    {
        Task<List<Satis>> GetAllAsync();
        Task<Satis?> GetByIdAsync(int id);
        Task AddAsync(Satis satis);
        Task UpdateAsync(Satis satis);
        Task DeleteAsync(int id);
    }
}