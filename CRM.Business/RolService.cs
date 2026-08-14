using CRM.DataAccess;
using CRM.DTO;
using CRM.Entities;

namespace CRM.Business
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _repository;

        public RolService(IRolRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RolDto>> GetAllAsync()
        {
            var roller = await _repository.GetAllAsync();

            return roller.Select(r => new RolDto
            {
                RolId = r.RolId,
                RolAdi = r.RolAdi,
                Aciklama = r.Aciklama
            }).ToList();
        }

        public async Task<RolDto?> GetByIdAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id);
            if (rol == null)
            {
                return null;
            }

            return new RolDto
            {
                RolId = rol.RolId,
                RolAdi = rol.RolAdi,
                Aciklama = rol.Aciklama
            };
        }

        public async Task AddAsync(RolDto rolDto)
        {
            var rol = new Rol
            {
                RolAdi = rolDto.RolAdi,
                Aciklama = rolDto.Aciklama
            };

            await _repository.AddAsync(rol);
        }

        public async Task UpdateAsync(RolDto rolDto)
        {
            var rol = await _repository.GetByIdAsync(rolDto.RolId);
            if (rol == null)
            {
                return;
            }

            rol.RolAdi = rolDto.RolAdi;
            rol.Aciklama = rolDto.Aciklama;

            await _repository.UpdateAsync(rol);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}