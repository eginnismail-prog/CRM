using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class NotRepository : INotRepository
    {
        private readonly AppDbContext _context;

        public NotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Not>> GetAllAsync()
        {
            return await _context.Notlar.ToListAsync();
        }

        public async Task<Not?> GetByIdAsync(int id)
        {
            return await _context.Notlar.FindAsync(id);
        }

        public async Task AddAsync(Not not)
        {
            _context.Notlar.Add(not);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Not not)
        {
            _context.Notlar.Update(not);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var not = await _context.Notlar.FindAsync(id);
            if (not != null)
            {
                _context.Notlar.Remove(not);
                await _context.SaveChangesAsync();
            }
        }
    }
}