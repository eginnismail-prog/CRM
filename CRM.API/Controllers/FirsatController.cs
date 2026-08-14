using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/firsatlar")]
    public class FirsatController : ControllerBase
    {
        private readonly IFirsatService _firsatService;

        public FirsatController(IFirsatService firsatService)
        {
            _firsatService = firsatService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FirsatDto>>> GetAll()
        {
            var firsatlar = await _firsatService.GetAllAsync();
            return Ok(firsatlar);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FirsatDto>> GetById(int id)
        {
            var firsat = await _firsatService.GetByIdAsync(id);
            if (firsat == null)
            {
                return NotFound();
            }
            return Ok(firsat);
        }

        [HttpPost]
        public async Task<ActionResult> Add(FirsatDto firsatDto)
        {
            await _firsatService.AddAsync(firsatDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, FirsatDto firsatDto)
        {
            firsatDto.FirsatId = id;
            await _firsatService.UpdateAsync(firsatDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _firsatService.DeleteAsync(id);
            return Ok();
        }
    }
}