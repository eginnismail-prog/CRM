using CRM.DTO;

namespace CRM.Business
{
    public interface IFirsatService
    {
        Task<List<FirsatDto>> GetAllAsync();
        Task<FirsatDto?> GetByIdAsync(int id);
        Task AddAsync(FirsatDto firsatDto);
        Task UpdateAsync(FirsatDto firsatDto);
        Task DeleteAsync(int id);
    }
}