using CRM.DTO;

namespace CRM.Business
{
    public interface INotService
    {
        Task<List<NotDto>> GetAllAsync();
        Task<NotDto?> GetByIdAsync(int id);
        Task AddAsync(NotDto notDto);
        Task UpdateAsync(NotDto notDto);
        Task DeleteAsync(int id);
    }
}