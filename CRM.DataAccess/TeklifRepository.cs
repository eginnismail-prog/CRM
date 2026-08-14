using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class TeklifRepository : ITeklifRepository
    {
        private readonly AppDbContext _context;

        public TeklifRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teklif>> GetAllAsync()
        {
            return await _context.Teklifler.ToListAsync();
        }

        public async Task<Teklif?> GetByIdAsync(int id)
        {
            return await _context.Teklifler.FindAsync(id);
        }

        public async Task AddAsync(Teklif teklif)
        {
            _context.Teklifler.Add(teklif);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Teklif teklif)
        {
            _context.Teklifler.Update(teklif);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teklif = await _context.Teklifler.FindAsync(id);
            if (teklif != null)
            {
                _context.Teklifler.Remove(teklif);
                await _context.SaveChangesAsync();
            }
        }
    }
}