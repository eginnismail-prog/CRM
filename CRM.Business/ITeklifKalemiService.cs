using CRM.DTO;

namespace CRM.Business
{
    public interface ITeklifKalemiService
    {
        Task<List<TeklifKalemiDto>> GetAllAsync();
        Task<TeklifKalemiDto?> GetByIdAsync(int id);
        Task AddAsync(TeklifKalemiDto kalemDto);
        Task UpdateAsync(TeklifKalemiDto kalemDto);
        Task DeleteAsync(int id);
    }
}