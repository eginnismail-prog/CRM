using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/destektalepleri")]
    public class DestekTalebiController : ControllerBase
    {
        private readonly IDestekTalebiService _talepService;

        public DestekTalebiController(IDestekTalebiService talepService)
        {
            _talepService = talepService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DestekTalebiDto>>> GetAll()
        {
            var talepler = await _talepService.GetAllAsync();
            return Ok(talepler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DestekTalebiDto>> GetById(int id)
        {
            var talep = await _talepService.GetByIdAsync(id);
            if (talep == null)
            {
                return NotFound();
            }
            return Ok(talep);
        }

        [HttpPost]
        public async Task<ActionResult> Add(DestekTalebiDto talepDto)
        {
            await _talepService.AddAsync(talepDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DestekTalebiDto talepDto)
        {
            talepDto.TalepId = id;
            await _talepService.UpdateAsync(talepDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _talepService.DeleteAsync(id);
            return Ok();
        }
    }
}