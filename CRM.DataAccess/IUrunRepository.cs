using CRM.Entities;

namespace CRM.DataAccess
{
    public interface IUrunRepository
    {
        Task<List<Urun>> GetAllAsync();
        Task<Urun?> GetByIdAsync(int id);
        Task AddAsync(Urun urun);
        Task UpdateAsync(Urun urun);
        Task DeleteAsync(int id);
    }
}