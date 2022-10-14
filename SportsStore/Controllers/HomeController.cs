using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System.Diagnostics;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;

        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public ViewResult Index(string? category, int productPage = 1)
      => View(new ProductsListViewModel
      {
          Products = repository.Products
      .Where(p => category == null || p.Category == category)
      .OrderBy(p => p.ProductID)
      .Skip((productPage - 1) * PageSize)
      .Take(PageSize),
          PagingInfo = new PagingInfo
          {
              CurrentPage = productPage,
              ItemsPerPage = PageSize,
              TotalItems = category == null
      ? repository.Products.Count()
     : repository.Products.Where(e =>
      e.Category == category).Count()
          },
          CurrentCategory = category
      });



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}