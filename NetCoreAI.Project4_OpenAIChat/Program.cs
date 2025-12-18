class Program
{
    static async Task Main(string[] args)
    {
        var apiKey = "api key";

        Console.WriteLine("Merhaba, size nasıl yarımcı olabilirim?");

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

        await Task.CompletedTask;
    }
}