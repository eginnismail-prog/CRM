using CRM.Entities;

namespace CRM.DataAccess
{
    public interface IDestekTalebiRepository
    {
        Task<List<DestekTalebi>> GetAllAsync();
        Task<DestekTalebi?> GetByIdAsync(int id);
        Task AddAsync(DestekTalebi talep);
        Task UpdateAsync(DestekTalebi talep);
        Task DeleteAsync(int id);
    }
}