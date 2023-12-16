using NewsProject.Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Business.Services
{
    public class NewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<News> GetNews()
        {
            // API'den JSON verisini çektim
            string jsonUrl = "https://www.turkmedya.com.tr/anasayfa.json";
            string jsonString = await _httpClient.GetStringAsync(jsonUrl);

            // JSON verisini News listesine çevirdim
            News haberler = JsonConvert.DeserializeObject<News>(jsonString);
            return haberler;
        }

        public async Task<List<ItemList>> GetNewsByCategoryId(string categoryId)
        {
            string apiUrl = $"https://www.turkmedya.com.tr/category/{categoryId}.json";
            string jsonString = await _httpClient.GetStringAsync(apiUrl);

            var newsByCategory = JsonConvert.DeserializeObject<List<ItemList>>(jsonString);
            return newsByCategory;
        }

    }
}
