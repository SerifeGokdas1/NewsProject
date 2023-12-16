using Microsoft.AspNetCore.Mvc;
using NewsProject.Business.Services;
using NewsProject.Model.Models;

namespace NewsProject.Controllers
{
    public class DetailsController : Controller
    {
        private readonly DetailService _detailService;
        public DetailsController(DetailService detailService)
        {
            _detailService = detailService;
        }
        public async Task<IActionResult> Index(string itemId)
        {
            var detailModel = await _detailService.GetDetail(itemId);

            var viewModel = new DetailsViewModel
            {
                Data = detailModel.data,
                Details = detailModel
            };

            if (detailModel != null)
            {
                return View(viewModel);
            }
            else
            {
                return View("Error");
            }
        }
    }
    public class DetailsViewModel
    {
        public Data Data { get; set; }
        public Details Details { get; set; }
    }

}
