using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class FirmaRepository : IFirmaRepository
    {
        private readonly AppDbContext _context;

        public FirmaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Firma>> GetAllAsync()
        {
            return await _context.Firmalar.ToListAsync();
        }

        public async Task<Firma?> GetByIdAsync(int id)
        {
            return await _context.Firmalar.FindAsync(id);
        }

        public async Task AddAsync(Firma firma)
        {
            _context.Firmalar.Add(firma);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Firma firma)
        {
            _context.Firmalar.Update(firma);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var firma = await _context.Firmalar.FindAsync(id);
            if (firma != null)
            {
                _context.Firmalar.Remove(firma);
                await _context.SaveChangesAsync();
            }
        }
    }
}