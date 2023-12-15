using NewsProject.Model.Models;
using Newtonsoft.Json;

namespace NewsProject.Services
{
    public class DetailService
    {
        private readonly HttpClient _httpClient;
        public DetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Details> GetDetail(string itemId)
        {
            // API'den JSON verilerini çekme işlemi yaptım
            string detailUrl = $"https://www.turkmedya.com.tr/detay.json?itemId={itemId}";
            string jsonString = await _httpClient.GetStringAsync(detailUrl);

            // Çektiğim JSON verisini Details nesnesine çevirdim 
            Details haberDetay = JsonConvert.DeserializeObject<Details>(jsonString);

            return haberDetay;
        }
    }
}
