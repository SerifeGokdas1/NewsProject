using Microsoft.AspNetCore.Mvc;
using NewsProject.Business.Services;
using NewsProject.Model.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace NewsProject.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsService _newsService;


        public NewsController(NewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index(int page = 1, string category = null, string keyword = null)
        {
            const int pageSize = 5; // Her sayfada 5 haber görüntülenecek

            // Tüm haberleri aldım
            var allNews = await _newsService.GetNews();

            // hem data[0] hem de data[1]i aldım
            var combinedItemList = allNews.data[0].itemList.Concat(allNews.data[1].itemList);

            // Kategoriye göre filtreleme
            if (!string.IsNullOrEmpty(category))
            {
                combinedItemList = combinedItemList.Where(item => item.category?.CategoryId == category);
            }

            // Anahtar kelimeye göre filtreleme
            if (!string.IsNullOrEmpty(keyword))
            {
                combinedItemList = combinedItemList.Where(item => item.title.Contains(keyword));
            }

            // Tüm kategorileri aldım
            var allCategories = combinedItemList
                .Where(item => item.category != null)
                .Select(item => item.category)
                .Distinct()
                .ToList();

            // Toplam sayfa sayısını hesapladım
            int totalPages = (int)Math.Ceiling((double)combinedItemList.Count() / pageSize);

            // Belirtilen sayfa için haberleri aldım
            var pagedNews = combinedItemList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var viewModel = new NewsViewModel
            {
                ItemLists = pagedNews,
                CurrentPage = page,
                TotalPages = totalPages,
                Categories = allCategories,
                SelectedCategory = category,
                Keyword = keyword
            };

            return View(viewModel);
        }



    }

    public class NewsViewModel
    {
        public List<ItemList> ItemLists { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? SelectedCategory { get; set; }
        public string? Keyword { get; set; }
        public List<Category>? Categories { get; set; }
    }
}