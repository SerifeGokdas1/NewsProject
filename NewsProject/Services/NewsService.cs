using NewsProject.Model.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace NewsProject.Services
{
    public class NewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<News>> GetHaberler()
        {
            // API'den JSON verisini çektim
            string jsonUrl = "https://www.turkmedya.com.tr/anasayfa.json";
            string jsonString = await _httpClient.GetStringAsync(jsonUrl);

            // JSON verisini News listesine çevirdim
            List<News> haberler = JsonConvert.DeserializeObject<List<News>>(jsonString);

            return haberler;
        }

        
    }
}
