using CRM.DTO;

namespace CRM.Business
{
    public interface IMusteriService
    {
        Task<List<MusteriDto>> GetAllAsync();
        Task<MusteriDto?> GetByIdAsync(int id);
        Task AddAsync(MusteriDto musteriDto);
        Task UpdateAsync(MusteriDto musteriDto);
        Task DeleteAsync(int id);
    }
}