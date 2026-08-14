using CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess
{
    public class RolRepository : IRolRepository
    {
        private readonly AppDbContext _context;

        public RolRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> GetAllAsync()
        {
            return await _context.Roller.ToListAsync();
        }

        public async Task<Rol?> GetByIdAsync(int id)
        {
            return await _context.Roller.FindAsync(id);
        }

        public async Task AddAsync(Rol rol)
        {
            _context.Roller.Add(rol);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rol rol)
        {
            _context.Roller.Update(rol);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rol = await _context.Roller.FindAsync(id);
            if (rol != null)
            {
                _context.Roller.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }
    }
}