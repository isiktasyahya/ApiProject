using ApiProjeKampi.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7063/api/Categories/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();

            /*
                # Listeleme İşlemi #
                1. Adım: Bağlantı Kurma
                2. Adım: Mesajın Hangi Bağlantıdan Geleceğini Belirleme.
                3. Adım: Gelen mesajın doğruluna şart koyma.
                4. Adım: Verimizi String formata çevirme.
                5. Adım: Gelen verinin formatına göre Listeleme yapma
                6. Adım: Veriyi Döndürme

            */
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7063/api/Categories/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();
            /*
                # Listeleme İşlemi
            * Get ve Post alanlarından oluşur, Get sadece sayfayı döndürür, Post ise bu işlemleri Yapar: 
            1. Adım: Bağlantı Kurma.
            2. Adım: JsonData verisin, parametre ile JsonConver aracılığıyla tip çevirme işlemi yapma.
            3. Adım: Verimizin İçeriğini StringContent ile çevirme.
            4. Adım: Eklenecek verini gideceği yere(Url) gönderim yapma
            5. Adım: Doğrulamayı şartlandırma
            6. Adım: İşlem sonrasında gidelecek sayfayı yazma
             
             */
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7063/api/Categories?id=" + id);
            return RedirectToAction("CategoryList");

            /*
             # Silme İşlemi #
            1. Adım: Bağlantıyı kurma.
            2. Adım: Silinicek verinin Url'sine id ile gönderim yapma.
            3. Adım: Gidilecek sayfaya yazma.
             */
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7063/api/Categories/GetCategori?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetCategoryByIdDto>(jsonData);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7063/api/Categories/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();
        }




    }
}
