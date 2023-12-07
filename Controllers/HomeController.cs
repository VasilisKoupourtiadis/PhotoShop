using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhotoShop.Data;
using PhotoShop.Helpers;
using PhotoShop.Models;
using PhotoShop.Models.ViewModels;
using System.Diagnostics;

namespace PhotoShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        private readonly ApplicationContext context;

        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var dataFetcher = new DataFetcher(context, mapper);

            var products = dataFetcher.GetProducts().Result.ToList();

            return View(products);
        }                   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}