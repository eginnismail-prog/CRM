using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class SatisRepository : ISatisRepository
    {
        private readonly AppDbContext _context;

        public SatisRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Satis>> GetAllAsync()
        {
            return await _context.Satislar.ToListAsync();
        }

        public async Task<Satis?> GetByIdAsync(int id)
        {
            return await _context.Satislar.FindAsync(id);
        }

        public async Task AddAsync(Satis satis)
        {
            _context.Satislar.Add(satis);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Satis satis)
        {
            _context.Satislar.Update(satis);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var satis = await _context.Satislar.FindAsync(id);
            if (satis != null)
            {
                _context.Satislar.Remove(satis);
                await _context.SaveChangesAsync();
            }
        }
    }
}