using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponents.HomePageViewComponents
{
    public class _HomePageStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePageStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7063/api/Statistics/ProductCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData;

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7063/api/Statistics/ReservationCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.reservationCount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7063/api/Statistics/ProductCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.chefCount = jsonData3;

            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:7063/api/Statistics/TotalGestCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.totalGestCount = jsonData4;

            return View();
        }
    }
}
