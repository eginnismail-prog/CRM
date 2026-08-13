using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class MusteriRepository : IMusteriRepository
    {
        private readonly AppDbContext _context;

        public MusteriRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Musteri>> GetAllAsync()
        {
            return await _context.Musteriler.ToListAsync();
        }

        public async Task<Musteri?> GetByIdAsync(int id)
        {
            return await _context.Musteriler.FindAsync(id);
        }

        public async Task AddAsync(Musteri musteri)
        {
            _context.Musteriler.Add(musteri);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Musteri musteri)
        {
            _context.Musteriler.Update(musteri);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var musteri = await _context.Musteriler.FindAsync(id);
            if (musteri != null)
            {
                _context.Musteriler.Remove(musteri);
                await _context.SaveChangesAsync();
            }
        }
    }
}