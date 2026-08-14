using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/teklifkalemleri")]
    public class TeklifKalemiController : ControllerBase
    {
        private readonly ITeklifKalemiService _kalemService;

        public TeklifKalemiController(ITeklifKalemiService kalemService)
        {
            _kalemService = kalemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeklifKalemiDto>>> GetAll()
        {
            var kalemler = await _kalemService.GetAllAsync();
            return Ok(kalemler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeklifKalemiDto>> GetById(int id)
        {
            var kalem = await _kalemService.GetByIdAsync(id);
            if (kalem == null)
            {
                return NotFound();
            }
            return Ok(kalem);
        }

        [HttpPost]
        public async Task<ActionResult> Add(TeklifKalemiDto kalemDto)
        {
            await _kalemService.AddAsync(kalemDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TeklifKalemiDto kalemDto)
        {
            kalemDto.TeklifKalemiId = id;
            await _kalemService.UpdateAsync(kalemDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _kalemService.DeleteAsync(id);
            return Ok();
        }
    }
}