using CRM.DTO;

namespace CRM.Business
{
    public interface IKategoriService
    {
        Task<List<KategoriDto>> GetAllAsync();
        Task<KategoriDto?> GetByIdAsync(int id);
        Task AddAsync(KategoriDto kategoriDto);
        Task UpdateAsync(KategoriDto kategoriDto);
        Task DeleteAsync(int id);
    }
}