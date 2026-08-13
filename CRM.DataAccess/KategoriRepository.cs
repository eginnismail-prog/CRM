using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class KategoriRepository : IKategoriRepository
    {
        private readonly AppDbContext _context;

        public KategoriRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Kategori>> GetAllAsync()
        {
            return await _context.Kategoriler.ToListAsync();
        }

        public async Task<Kategori?> GetByIdAsync(int id)
        {
            return await _context.Kategoriler.FindAsync(id);
        }

        public async Task AddAsync(Kategori kategori)
        {
            _context.Kategoriler.Add(kategori);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Kategori kategori)
        {
            _context.Kategoriler.Update(kategori);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var kategori = await _context.Kategoriler.FindAsync(id);
            if (kategori != null)
            {
                _context.Kategoriler.Remove(kategori);
                await _context.SaveChangesAsync();
            }
        }
    }
}