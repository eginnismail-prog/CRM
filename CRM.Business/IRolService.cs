using CRM.DTO;

namespace CRM.Business
{
    public interface IRolService
    {
        Task<List<RolDto>> GetAllAsync();
        Task<RolDto?> GetByIdAsync(int id);
        Task AddAsync(RolDto rolDto);
        Task UpdateAsync(RolDto rolDto);
        Task DeleteAsync(int id);
    }
}