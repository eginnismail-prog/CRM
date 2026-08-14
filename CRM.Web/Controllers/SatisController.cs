using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Controllers
{
    public class SatisController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SatisController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var satislar = await client.GetFromJsonAsync<List<SatisDto>>("api/satislar");

            return View(satislar);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            ViewBag.Musteriler = await client.GetFromJsonAsync<List<MusteriDto>>("api/musteriler");
            ViewBag.Teklifler = await client.GetFromJsonAsync<List<TeklifDto>>("api/teklifler");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SatisDto satisDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PostAsJsonAsync("api/satislar", satisDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var satis = await client.GetFromJsonAsync<SatisDto>($"api/satislar/{id}");
            ViewBag.Musteriler = await client.GetFromJsonAsync<List<MusteriDto>>("api/musteriler");
            ViewBag.Teklifler = await client.GetFromJsonAsync<List<TeklifDto>>("api/teklifler");

            return View(satis);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SatisDto satisDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PutAsJsonAsync($"api/satislar/{id}", satisDto);

            return RedirectToAction("Index");
        }
    }
}