using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/kategoriler")]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        [HttpGet]
        public async Task<ActionResult<List<KategoriDto>>> GetAll()
        {
            var kategoriler = await _kategoriService.GetAllAsync();
            return Ok(kategoriler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KategoriDto>> GetById(int id)
        {
            var kategori = await _kategoriService.GetByIdAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }
            return Ok(kategori);
        }

        [HttpPost]
        public async Task<ActionResult> Add(KategoriDto kategoriDto)
        {
            await _kategoriService.AddAsync(kategoriDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, KategoriDto kategoriDto)
        {
            kategoriDto.KategoriId = id;
            await _kategoriService.UpdateAsync(kategoriDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _kategoriService.DeleteAsync(id);
            return Ok();
        }
    }
}