using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/musteriler")]
    public class MusteriController : ControllerBase
    {
        private readonly IMusteriService _musteriService;

        public MusteriController(IMusteriService musteriService)
        {
            _musteriService = musteriService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MusteriDto>>> GetAll()
        {
            var musteriler = await _musteriService.GetAllAsync();
            return Ok(musteriler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusteriDto>> GetById(int id)
        {
            var musteri = await _musteriService.GetByIdAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return Ok(musteri);
        }

        [HttpPost]
        public async Task<ActionResult> Add(MusteriDto musteriDto)
        {
            await _musteriService.AddAsync(musteriDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MusteriDto musteriDto)
        {
            musteriDto.MusteriId = id;
            await _musteriService.UpdateAsync(musteriDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _musteriService.DeleteAsync(id);
            return Ok();
        }
    }
}