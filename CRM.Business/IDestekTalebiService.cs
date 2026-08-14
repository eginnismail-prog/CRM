using CRM.DTO;

namespace CRM.Business
{
    public interface IDestekTalebiService
    {
        Task<List<DestekTalebiDto>> GetAllAsync();
        Task<DestekTalebiDto?> GetByIdAsync(int id);
        Task AddAsync(DestekTalebiDto talepDto);
        Task UpdateAsync(DestekTalebiDto talepDto);
        Task DeleteAsync(int id);
    }
}