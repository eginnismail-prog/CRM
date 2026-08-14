using System.Diagnostics;
using CRM.DTO;
using CRM.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Controllers;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("CRMApi");

        var musteriler = await client.GetFromJsonAsync<List<MusteriDto>>("api/musteriler");
        var firsatlar = await client.GetFromJsonAsync<List<FirsatDto>>("api/firsatlar");
        var satislar = await client.GetFromJsonAsync<List<SatisDto>>("api/satislar");

        var viewModel = new DashboardViewModel
        {
            ToplamMusteriSayisi = musteriler?.Count ?? 0,
            ToplamFirsatSayisi = firsatlar?.Count ?? 0,
            ToplamSatisSayisi = satislar?.Count ?? 0,
            ToplamSatisTutari = satislar?.Sum(s => s.ToplamTutar) ?? 0
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}