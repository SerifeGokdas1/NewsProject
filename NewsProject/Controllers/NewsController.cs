using Microsoft.AspNetCore.Mvc;
using NewsProject.Business.Services;
using NewsProject.Model.Models;

namespace NewsProject.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsService _newsService;


        public NewsController(NewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 5; // Her sayfada 5 haber görüntülenecek

            // Tüm haberleri aldım
            var allNews = await _newsService.GetNews();

            // Toplam sayfa sayısını hesapladım
            int totalPages = (int)Math.Ceiling((double)(allNews.data[0].itemList.Count + allNews.data[1].itemList.Count) / pageSize);

            // hem data[0] hem de data[1]i aldım
            var combinedItemList = allNews.data[0].itemList.Concat(allNews.data[1].itemList);

            // Belirtilen sayfa için haberleri aldım
            var pagedNews = combinedItemList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var viewModel = new NewsViewModel
            {
                ItemLists = pagedNews,
                CurrentPage = page,
                TotalPages = totalPages,
                Categories = null,
                SelectedCategory = null,
                Keyword = null
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