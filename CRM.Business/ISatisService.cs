using CRM.DTO;

namespace CRM.Business
{
    public interface ISatisService
    {
        Task<List<SatisDto>> GetAllAsync();
        Task<SatisDto?> GetByIdAsync(int id);
        Task AddAsync(SatisDto satisDto);
        Task UpdateAsync(SatisDto satisDto);
        Task DeleteAsync(int id);
    }
}