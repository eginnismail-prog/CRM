using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/firmalar")]
    public class FirmaController : ControllerBase
    {
        private readonly IFirmaService _firmaService;

        public FirmaController(IFirmaService firmaService)
        {
            _firmaService = firmaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FirmaDto>>> GetAll()
        {
            var firmalar = await _firmaService.GetAllAsync();
            return Ok(firmalar);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FirmaDto>> GetById(int id)
        {
            var firma = await _firmaService.GetByIdAsync(id);
            if (firma == null)
            {
                return NotFound();
            }
            return Ok(firma);
        }

        [HttpPost]
        public async Task<ActionResult> Add(FirmaDto firmaDto)
        {
            await _firmaService.AddAsync(firmaDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, FirmaDto firmaDto)
        {
            firmaDto.FirmaId = id;
            await _firmaService.UpdateAsync(firmaDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _firmaService.DeleteAsync(id);
            return Ok();
        }
    }
}