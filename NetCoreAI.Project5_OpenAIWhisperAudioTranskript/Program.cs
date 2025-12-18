using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        var apiKey = "key";
        var audioFilePath = "sarzamanimizigeriye.mp3";

        using(var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", apiKey);
        }
}