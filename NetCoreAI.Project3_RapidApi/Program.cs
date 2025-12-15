using NetCoreAI.Project3_RapidApi.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;



var client = new HttpClient();
List<ApiSeriesViewModel> apiSeriesViewModels = new List<ApiSeriesViewModel>();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"), //istek atılacak adres
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
    apiSeriesViewModels = JsonConvert.DeserializeObject<List<ApiSeriesViewModel>>(body);
    foreach (var series in apiSeriesViewModels)
    { Console.WriteLine(series); }
}

Console.ReadLine();