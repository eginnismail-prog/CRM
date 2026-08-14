using CRM.DTO;

namespace CRM.Business
{
    public interface IAktiviteService
    {
        Task<List<AktiviteDto>> GetAllAsync();
        Task<AktiviteDto?> GetByIdAsync(int id);
        Task AddAsync(AktiviteDto aktiviteDto);
        Task UpdateAsync(AktiviteDto aktiviteDto);
        Task DeleteAsync(int id);
    }
}