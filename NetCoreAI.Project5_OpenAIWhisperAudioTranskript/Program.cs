using System.Net.Http;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        var apiKey = "key";

        // İşlenecek ses dosyasının yolu
        var audioFilePath = "sarzamanimizigeriye.mp3";

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            //dosya gönderimi için bu format kullanılır. API'ye gönderilecek verileri "multipart/form-data" formatında hazırlar
            var form = new MultipartFormDataContent();

            //ses dosyasını byte dizisi olarak oku ve form'a ekle
            var audioContent = new ByteArrayContent(File.ReadAllBytes(audioFilePath));

            //gönderilen dosyanın türünü belirttik
            audioContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/mpeg");

            //dosyayı form'a ekle
            form.Add(audioContent, "file", Path.GetFileName(audioFilePath));

            //Kullanılacak yapay zeka modelini (whisper-1) form verisine ekliyoruz
            form.Add(new StringContent("whisper-1"), "model");
            Console.WriteLine("Ses dosyası işeniyor. Lütfen bekleyiniz...");


            // API'ye POST isteği gönder ve yanıtı bekle
            // 'await' ile ağ üzerinden veri gönderilirken programın donmasını engelliyor
            // 'PostAsync' metodu, hazırladığımız 'form' verisini (ses dosyası ve model adı)
            // verilen OpenAI internet adresine (URL) gönderir.
            // Gelen tüm yanıt (sonuç metni, durum kodu vb.) 'response' değişkenine atanır.
            var response = await httpClient.PostAsync("https://api.openai.com/v1/audio/transcriptions", form);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Transkript Sonucu:\n" + result);
            }
            else
            {
                Console.WriteLine("Hata: " + response.StatusCode);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
    }
}