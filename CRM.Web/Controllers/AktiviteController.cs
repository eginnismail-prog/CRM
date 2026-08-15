using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Controllers
{
    public class AktiviteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AktiviteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var aktiviteler = await client.GetFromJsonAsync<List<AktiviteDto>>("api/aktiviteler");

            return View(aktiviteler);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            ViewBag.Musteriler = await client.GetFromJsonAsync<List<MusteriDto>>("api/musteriler");
            ViewBag.Firsatlar = await client.GetFromJsonAsync<List<FirsatDto>>("api/firsatlar");
            ViewBag.Kullanicilar = await client.GetFromJsonAsync<List<KullaniciDto>>("api/kullanicilar");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AktiviteDto aktiviteDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PostAsJsonAsync("api/aktiviteler", aktiviteDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var aktivite = await client.GetFromJsonAsync<AktiviteDto>($"api/aktiviteler/{id}");
            ViewBag.Musteriler = await client.GetFromJsonAsync<List<MusteriDto>>("api/musteriler");
            ViewBag.Firsatlar = await client.GetFromJsonAsync<List<FirsatDto>>("api/firsatlar");
            ViewBag.Kullanicilar = await client.GetFromJsonAsync<List<KullaniciDto>>("api/kullanicilar");

            return View(aktivite);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AktiviteDto aktiviteDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PutAsJsonAsync($"api/aktiviteler/{id}", aktiviteDto);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.DeleteAsync($"api/aktiviteler/{id}");

            return RedirectToAction("Index");
        }
    }
}