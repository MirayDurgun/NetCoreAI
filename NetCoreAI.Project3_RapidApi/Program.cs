using NetCoreAI.Project3_RapidApi.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;



var client = new HttpClient();

//API'den gelecek dizi listesini hafızada tutmak için boş bir liste oluşturuluyor
List<ApiSeriesViewModel> apiSeriesViewModels = new List<ApiSeriesViewModel>();

//apiye gidecek istek detayları
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"), //istek atılacak adres, veri alınacak get
    Headers = //istek atılan kaynak 
    {
        { "x-rapidapi-key", "0d63638b74mshf218c5b70b03499p1ae6bbjsn7318835503c5" }, //key
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" }, //sunucu adresi
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();

    //JSON formatındaki ham metni, C# dilinde dönüştürme
    apiSeriesViewModels = JsonConvert.DeserializeObject<List<ApiSeriesViewModel>>(body);
    foreach (var series in apiSeriesViewModels)
    { Console.WriteLine("Film Adı" + series.title + "Film Puanı" + series.rating + "-" + series.rank + "Yıl" + series.year); }
}

Console.ReadLine();