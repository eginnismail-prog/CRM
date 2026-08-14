using CRM.DTO;

namespace CRM.Business
{
    public interface ITeklifService
    {
        Task<List<TeklifDto>> GetAllAsync();
        Task<TeklifDto?> GetByIdAsync(int id);
        Task AddAsync(TeklifDto teklifDto);
        Task UpdateAsync(TeklifDto teklifDto);
        Task DeleteAsync(int id);
    }
}