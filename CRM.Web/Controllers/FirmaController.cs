using CRM.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Controllers
{
    public class FirmaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FirmaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var firmalar = await client.GetFromJsonAsync<List<FirmaDto>>("api/firmalar");

            return View(firmalar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FirmaDto firmaDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PostAsJsonAsync("api/firmalar", firmaDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            var firma = await client.GetFromJsonAsync<FirmaDto>($"api/firmalar/{id}");

            return View(firma);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FirmaDto firmaDto)
        {
            var client = _httpClientFactory.CreateClient("CRMApi");
            await client.PutAsJsonAsync($"api/firmalar/{id}", firmaDto);

            return RedirectToAction("Index");
        }
    }
}