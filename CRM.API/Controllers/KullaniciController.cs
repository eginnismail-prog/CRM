using CRM.Business;
using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/kullanicilar")]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciService _kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpGet]
        public async Task<ActionResult<List<KullaniciDto>>> GetAll()
        {
            var kullanicilar = await _kullaniciService.GetAllAsync();
            return Ok(kullanicilar);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KullaniciDto>> GetById(int id)
        {
            var kullanici = await _kullaniciService.GetByIdAsync(id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return Ok(kullanici);
        }

        [HttpPost]
        public async Task<ActionResult> Add(KullaniciDto kullaniciDto)
        {
            await _kullaniciService.AddAsync(kullaniciDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, KullaniciDto kullaniciDto)
        {
            kullaniciDto.KullaniciId = id;
            await _kullaniciService.UpdateAsync(kullaniciDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _kullaniciService.DeleteAsync(id);
            return Ok();
        }
    }
}