using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class DestekTalebiRepository : IDestekTalebiRepository
    {
        private readonly AppDbContext _context;

        public DestekTalebiRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DestekTalebi>> GetAllAsync()
        {
            return await _context.DestekTalepleri.ToListAsync();
        }

        public async Task<DestekTalebi?> GetByIdAsync(int id)
        {
            return await _context.DestekTalepleri.FindAsync(id);
        }

        public async Task AddAsync(DestekTalebi talep)
        {
            _context.DestekTalepleri.Add(talep);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DestekTalebi talep)
        {
            _context.DestekTalepleri.Update(talep);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var talep = await _context.DestekTalepleri.FindAsync(id);
            if (talep != null)
            {
                _context.DestekTalepleri.Remove(talep);
                await _context.SaveChangesAsync();
            }
        }
    }
}