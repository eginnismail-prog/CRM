using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Controllers
{
    public class FirsatController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FirsatController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var firsatlar = await client.GetFromJsonAsync<List<FirsatDto>>("api/firsatlar");

            return View(firsatlar);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            ViewBag.Musteriler = await client.GetFromJsonAsync<List<MusteriDto>>("api/musteriler");
            ViewBag.Kullanicilar = await client.GetFromJsonAsync<List<KullaniciDto>>("api/kullanicilar");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FirsatDto firsatDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PostAsJsonAsync("api/firsatlar", firsatDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var firsat = await client.GetFromJsonAsync<FirsatDto>($"api/firsatlar/{id}");
            ViewBag.Musteriler = await client.GetFromJsonAsync<List<MusteriDto>>("api/musteriler");
            ViewBag.Kullanicilar = await client.GetFromJsonAsync<List<KullaniciDto>>("api/kullanicilar");

            return View(firsat);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FirsatDto firsatDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PutAsJsonAsync($"api/firsatlar/{id}", firsatDto);

            return RedirectToAction("Index");
        }
    }
}