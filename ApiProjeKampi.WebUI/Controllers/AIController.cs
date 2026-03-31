using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class AIController : Controller
    {
        [HttpGet]
        public IActionResult CreateRecipeWithOpenAI()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRecipeWithOpenAI(string prompt)
        {
            var apikey = "OpenAI api gelecek";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);

            var requestData = new
            {
                model = "gpt-4o",
                messages = new[]
                {
                    new
                    {
                        role="system",
                        content="Sen profesyonel bir şefsin ve görevin, kullanıcının verdiği malzemelerle hiçbir şekilde ekstra malzeme eklemeden, tamamen gerçek hayatta uygulanabilir, mantıklı ve yaratıcı bir yemek tarifi oluşturmaktır; yalnızca verilen malzemeleri kullanmalı, “isteğe bağlı”, “varsa ekleyebilirsin” gibi ifadelerden kesinlikle kaçınmalı, tuz, yağ ve baharatlar dahil listede olmayan hiçbir şeyi kullanmamalı, eğer malzemeler sınırlıysa en verimli ve mantıklı sonucu üretmeli, tarifini “Yemek Adı”, kısa bir açıklama, sadece verilen malzemelerden oluşan liste, hazırlık süresi, pişirme süresi, numaralandırılmış ve detaylı adımlar, yalnızca mevcut malzemelere dayalı püf noktaları ve yine aynı malzemelerle servis önerisi olacak şekilde düzenli bir formatta sunmalı, profesyonel ama anlaşılır bir dil kullanmalı, gereksiz uzatmadan her adımı net açıklamalı ve hiçbir şekilde tahmin ya da uydurma bilgi eklemeden sadece kullanıcı girdisine göre hareket etmelidir."
                    },
                    new
                    {
                        role="user",
                        content=prompt
                    }
                },
                temperature = 0.5
            };

            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                var content = result.Choices[0].message.content;
                ViewBag.receipe = content;
            }
            else
            {
                ViewBag.receipe = "Bir hata oluştu: " + response.StatusCode;
            }
            return View();
        }
        public class OpenAIResponse
        {
            public List<Choice> Choices { get; set; }
        }
        public class Choice
        {
            public Message message { get; set; }
        }
        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }
    }
}
