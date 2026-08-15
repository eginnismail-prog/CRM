using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Controllers
{
    public class MusteriController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MusteriController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var musteriler = await client.GetFromJsonAsync<List<MusteriDto>>("api/musteriler");

            return View(musteriler);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MusteriDto musteriDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PostAsJsonAsync("api/musteriler", musteriDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var musteri = await client.GetFromJsonAsync<MusteriDto>($"api/musteriler/{id}");

            return View(musteri);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MusteriDto musteriDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PutAsJsonAsync($"api/musteriler/{id}", musteriDto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.DeleteAsync($"api/musteriler/{id}");

            return RedirectToAction("Index");
        }
    }
}
