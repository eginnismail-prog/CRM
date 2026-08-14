using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class AktiviteRepository : IAktiviteRepository
    {
        private readonly AppDbContext _context;

        public AktiviteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Aktivite>> GetAllAsync()
        {
            return await _context.Aktiviteler.ToListAsync();
        }

        public async Task<Aktivite?> GetByIdAsync(int id)
        {
            return await _context.Aktiviteler.FindAsync(id);
        }

        public async Task AddAsync(Aktivite aktivite)
        {
            _context.Aktiviteler.Add(aktivite);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Aktivite aktivite)
        {
            _context.Aktiviteler.Update(aktivite);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var aktivite = await _context.Aktiviteler.FindAsync(id);
            if (aktivite != null)
            {
                _context.Aktiviteler.Remove(aktivite);
                await _context.SaveChangesAsync();
            }
        }
    }
}