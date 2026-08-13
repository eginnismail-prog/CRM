using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/urunler")]
    public class UrunController : ControllerBase
    {
        private readonly IUrunService _urunService;

        public UrunController(IUrunService urunService)
        {
            _urunService = urunService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UrunDto>>> GetAll()
        {
            var urunler = await _urunService.GetAllAsync();
            return Ok(urunler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UrunDto>> GetById(int id)
        {
            var urun = await _urunService.GetByIdAsync(id);
            if (urun == null)
            {
                return NotFound();
            }
            return Ok(urun);
        }

        [HttpPost]
        public async Task<ActionResult> Add(UrunDto urunDto)
        {
            await _urunService.AddAsync(urunDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UrunDto urunDto)
        {
            urunDto.UrunId = id;
            await _urunService.UpdateAsync(urunDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _urunService.DeleteAsync(id);
            return Ok();
        }
    }
}
