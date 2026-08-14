using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class TeklifKalemiRepository : ITeklifKalemiRepository
    {
        private readonly AppDbContext _context;

        public TeklifKalemiRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeklifKalemi>> GetAllAsync()
        {
            return await _context.TeklifKalemleri.ToListAsync();
        }

        public async Task<TeklifKalemi?> GetByIdAsync(int id)
        {
            return await _context.TeklifKalemleri.FindAsync(id);
        }

        public async Task AddAsync(TeklifKalemi kalem)
        {
            _context.TeklifKalemleri.Add(kalem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TeklifKalemi kalem)
        {
            _context.TeklifKalemleri.Update(kalem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var kalem = await _context.TeklifKalemleri.FindAsync(id);
            if (kalem != null)
            {
                _context.TeklifKalemleri.Remove(kalem);
                await _context.SaveChangesAsync();
            }
        }
    }
}