using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Controllers
{
    public class TeklifController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TeklifController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var teklifler = await client.GetFromJsonAsync<List<TeklifDto>>("api/teklifler");

            return View(teklifler);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            ViewBag.Musteriler = await client.GetFromJsonAsync<List<MusteriDto>>("api/musteriler");
            ViewBag.Firsatlar = await client.GetFromJsonAsync<List<FirsatDto>>("api/firsatlar");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeklifDto teklifDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PostAsJsonAsync("api/teklifler", teklifDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var teklif = await client.GetFromJsonAsync<TeklifDto>($"api/teklifler/{id}");
            ViewBag.Musteriler = await client.GetFromJsonAsync<List<MusteriDto>>("api/musteriler");
            ViewBag.Firsatlar = await client.GetFromJsonAsync<List<FirsatDto>>("api/firsatlar");

            return View(teklif);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TeklifDto teklifDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PutAsJsonAsync($"api/teklifler/{id}", teklifDto);

            return RedirectToAction("Index");
        }
    }
}