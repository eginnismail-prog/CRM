using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class KullaniciRepository : IKullaniciRepository
    {
        private readonly AppDbContext _context;

        public KullaniciRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Kullanici>> GetAllAsync()
        {
            return await _context.Kullanicilar.ToListAsync();
        }

        public async Task<Kullanici?> GetByIdAsync(int id)
        {
            return await _context.Kullanicilar.FindAsync(id);
        }

        public async Task AddAsync(Kullanici kullanici)
        {
            _context.Kullanicilar.Add(kullanici);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Kullanici kullanici)
        {
            _context.Kullanicilar.Update(kullanici);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici != null)
            {
                _context.Kullanicilar.Remove(kullanici);
                await _context.SaveChangesAsync();
            }
        }
    }
}