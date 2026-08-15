using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Controllers
{
    public class UrunController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UrunController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var urunler = await client.GetFromJsonAsync<List<UrunDto>>("api/urunler");

            return View(urunler);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var kategoriler = await client.GetFromJsonAsync<List<KategoriDto>>("api/kategoriler");
            ViewBag.Kategoriler = kategoriler;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UrunDto urunDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PostAsJsonAsync("api/urunler", urunDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var urun = await client.GetFromJsonAsync<UrunDto>($"api/urunler/{id}");
            var kategoriler = await client.GetFromJsonAsync<List<KategoriDto>>("api/kategoriler");
            ViewBag.Kategoriler = kategoriler;

            return View(urun);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UrunDto urunDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PutAsJsonAsync($"api/urunler/{id}", urunDto);

            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.DeleteAsync($"api/urunler/{id}");

            return RedirectToAction("Index");
        }
    }
}