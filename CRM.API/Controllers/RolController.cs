using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/roller")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RolDto>>> GetAll()
        {
            var roller = await _rolService.GetAllAsync();
            return Ok(roller);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolDto>> GetById(int id)
        {
            var rol = await _rolService.GetByIdAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        [HttpPost]
        public async Task<ActionResult> Add(RolDto rolDto)
        {
            await _rolService.AddAsync(rolDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, RolDto rolDto)
        {
            rolDto.RolId = id;
            await _rolService.UpdateAsync(rolDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _rolService.DeleteAsync(id);
            return Ok();
        }
    }
}