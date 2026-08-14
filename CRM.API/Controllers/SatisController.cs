using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/satislar")]
    public class SatisController : ControllerBase
    {
        private readonly ISatisService _satisService;

        public SatisController(ISatisService satisService)
        {
            _satisService = satisService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SatisDto>>> GetAll()
        {
            var satislar = await _satisService.GetAllAsync();
            return Ok(satislar);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SatisDto>> GetById(int id)
        {
            var satis = await _satisService.GetByIdAsync(id);
            if (satis == null)
            {
                return NotFound();
            }
            return Ok(satis);
        }

        [HttpPost]
        public async Task<ActionResult> Add(SatisDto satisDto)
        {
            await _satisService.AddAsync(satisDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, SatisDto satisDto)
        {
            satisDto.SatisId = id;
            await _satisService.UpdateAsync(satisDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _satisService.DeleteAsync(id);
            return Ok();
        }
    }
}