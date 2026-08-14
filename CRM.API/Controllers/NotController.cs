using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/notlar")]
    public class NotController : ControllerBase
    {
        private readonly INotService _notService;

        public NotController(INotService notService)
        {
            _notService = notService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NotDto>>> GetAll()
        {
            var notlar = await _notService.GetAllAsync();
            return Ok(notlar);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotDto>> GetById(int id)
        {
            var not = await _notService.GetByIdAsync(id);
            if (not == null)
            {
                return NotFound();
            }
            return Ok(not);
        }

        [HttpPost]
        public async Task<ActionResult> Add(NotDto notDto)
        {
            await _notService.AddAsync(notDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, NotDto notDto)
        {
            notDto.NotId = id;
            await _notService.UpdateAsync(notDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _notService.DeleteAsync(id);
            return Ok();
        }
    }
}