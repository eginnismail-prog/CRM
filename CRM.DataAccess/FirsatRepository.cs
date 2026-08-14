using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class FirsatRepository : IFirsatRepository
    {
        private readonly AppDbContext _context;

        public FirsatRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Firsat>> GetAllAsync()
        {
            return await _context.Firsatlar.ToListAsync();
        }

        public async Task<Firsat?> GetByIdAsync(int id)
        {
            return await _context.Firsatlar.FindAsync(id);
        }

        public async Task AddAsync(Firsat firsat)
        {
            _context.Firsatlar.Add(firsat);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Firsat firsat)
        {
            _context.Firsatlar.Update(firsat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var firsat = await _context.Firsatlar.FindAsync(id);
            if (firsat != null)
            {
                _context.Firsatlar.Remove(firsat);
                await _context.SaveChangesAsync();
            }
        }
    }
}