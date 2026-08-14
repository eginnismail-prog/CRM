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
    }
}