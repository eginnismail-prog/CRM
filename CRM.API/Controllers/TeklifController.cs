using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/teklifler")]
    public class TeklifController : ControllerBase
    {
        private readonly ITeklifService _teklifService;

        public TeklifController(ITeklifService teklifService)
        {
            _teklifService = teklifService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeklifDto>>> GetAll()
        {
            var teklifler = await _teklifService.GetAllAsync();
            return Ok(teklifler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeklifDto>> GetById(int id)
        {
            var teklif = await _teklifService.GetByIdAsync(id);
            if (teklif == null)
            {
                return NotFound();
            }
            return Ok(teklif);
        }

        [HttpPost]
        public async Task<ActionResult> Add(TeklifDto teklifDto)
        {
            await _teklifService.AddAsync(teklifDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TeklifDto teklifDto)
        {
            teklifDto.TeklifId = id;
            await _teklifService.UpdateAsync(teklifDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _teklifService.DeleteAsync(id);
            return Ok();
        }
    }
}