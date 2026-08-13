using CRM.Entities;

namespace CRM.DataAccess
{
    public interface IKategoriRepository
    {
        Task<List<Kategori>> GetAllAsync();
        Task<Kategori?> GetByIdAsync(int id);
        Task AddAsync(Kategori kategori);
        Task UpdateAsync(Kategori kategori);
        Task DeleteAsync(int id);
    }
}