using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/aktiviteler")]
    public class AktiviteController : ControllerBase
    {
        private readonly IAktiviteService _aktiviteService;

        public AktiviteController(IAktiviteService aktiviteService)
        {
            _aktiviteService = aktiviteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AktiviteDto>>> GetAll()
        {
            var aktiviteler = await _aktiviteService.GetAllAsync();
            return Ok(aktiviteler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AktiviteDto>> GetById(int id)
        {
            var aktivite = await _aktiviteService.GetByIdAsync(id);
            if (aktivite == null)
            {
                return NotFound();
            }
            return Ok(aktivite);
        }

        [HttpPost]
        public async Task<ActionResult> Add(AktiviteDto aktiviteDto)
        {
            await _aktiviteService.AddAsync(aktiviteDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, AktiviteDto aktiviteDto)
        {
            aktiviteDto.AktiviteId = id;
            await _aktiviteService.UpdateAsync(aktiviteDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _aktiviteService.DeleteAsync(id);
            return Ok();
        }
    }
}