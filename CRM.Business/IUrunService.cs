using CRM.DTO;

namespace CRM.Business
{
    public interface IUrunService
    {
        Task<List<UrunDto>> GetAllAsync();
        Task<UrunDto?> GetByIdAsync(int id);
        Task AddAsync(UrunDto urunDto);
        Task UpdateAsync(UrunDto urunDto);
        Task DeleteAsync(int id);
    }
}