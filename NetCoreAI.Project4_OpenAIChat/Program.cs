using System.Text;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var apiKey = "Token";

        Console.WriteLine("Merhaba, nasıl yarımcı olabilirim?");

        var prompt = Console.ReadLine();

        //internet üzerinden veri alışverişi OpenAI Chat API'sine istek gönderme
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        //istek gövdesi, API'ye gönderilecek JSON formatındaki ayarlar ve mesaj içeriği
        var requestBody = new
        {
            model = "gpt-3.5-turbo", //kullanılıcak yapay zeka modeli
            messages = new[]
            {
                new {role="system", content="You are a helpful assistant."}, //sistem mesajı, yapay zekanın davranışını belirler
                new {role="user",content =prompt} //kullanıcı mesajı, kullanıcının girdiği metin
            },
            max_tokens = 100 //Cevabın uzunluğunu sınırlar; maliyet ve performans kontrolü için
        };

        var json = JsonSerializer.Serialize(requestBody); //istek gövdesini JSON formatına dönüştürme
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            //veriyi belirtilen adrese gönderir ve yanıt bekler
            var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            //gelen yanıtı string formatında oku
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // Gelen metin yığınını (JSON), bilgisayarın "içinde arama yapabileceği" düzenli bir nesneye dönüştürür.
                // Neden: Ham metin halindeyken içinden belirli bir kelimeyi veya cevabı çekip almak imkansızdır.
                var result = JsonSerializer.Deserialize<JsonElement>(responseString);

                /// Bu satır bir "adres tarifi" gibidir:
                // 1. 'choices' listesine git, 2. ilk elemanı ([0]) seç, 3. 'message' kutusunu aç, 4. 'content' (asıl cevap) yazısını al.
                // Neden: API bize sadece cevabı değil; tarih, ID ve kullanım verisi gibi 20-30 tane gereksiz bilgi de gönderir. 
                // Biz sadece yapay zekanın yazdığı mesajı ayıklamak için bu yolu izliyoruz.
                var answer = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

                Console.WriteLine("\n OpenAI: " + answer);

            }
            else
            {
                Console.WriteLine("Hata: " + response.StatusCode);
                Console.WriteLine(responseString);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("bir hata oluştu: " + exception.Message);
            throw;
        }

    }
}