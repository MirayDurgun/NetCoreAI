using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project2_ApiConsumeUI.Dtos;
using Newtonsoft.Json;

namespace NetCoreAI.Project2_ApiConsumeUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //HttpClient:  Başka bir sisteme internet üzerinden istek atan şey
        //IHttpClientFactory: Bu istek atan şeyleri güvenli ve doğru şekilde veren sistem
        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //IActionResult Basit, anlık biten işler için kullanılır. (veri tabanı sorgusu veya uzun işlemlerde kullanılmaz) Çünkü sunucunun verimini düşürür.
        //Asenkron Veritabanı, Harici API, Dosya Okuma gibi bekleme içeren işler için kullanılır.
        public async Task<IActionResult> CustomerList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44344/api/Customers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //responsemesage içindeki değeri okuyup jsonData'ya atıyor
                var values = JsonConvert.DeserializeObject<List<ResultCustomerDto>>(jsonData);
                //Json formatındaki veriyi string olarak alıp List<ResultCustomerDto> formatına çeviriyor
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
    }
}