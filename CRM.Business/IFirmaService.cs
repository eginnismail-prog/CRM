using CRM.DTO;

namespace CRM.Business
{
    public interface IFirmaService
    {
        Task<List<FirmaDto>> GetAllAsync();
        Task<FirmaDto?> GetByIdAsync(int id);
        Task AddAsync(FirmaDto firmaDto);
        Task UpdateAsync(FirmaDto firmaDto);
        Task DeleteAsync(int id);
    }
}