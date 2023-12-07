using ApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProject.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yahoo-weather5.p.rapidapi.com/weather?location=Ankara&format=json&u=c"),
                Headers =
    {
        { "X-RapidAPI-Key", "2602c4f31bmsh48f6eb3aa21a800p1dc741jsn73c85b7a6749" },
        { "X-RapidAPI-Host", "yahoo-weather5.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel>(body);
                return View(values.locations);
            }
        }
    }
}
