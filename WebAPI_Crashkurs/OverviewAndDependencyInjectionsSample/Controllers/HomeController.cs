using DependencySampleLib.GoodSample;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OverviewAndDependencyInjectionsSample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OverviewAndDependencyInjectionsSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICar _car;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, ICar car, IConfiguration configuration)
        {
            _logger = logger;
            _car = car;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("HomeController->Index wurde eben aufgerufen");
            
            PositionOptions positionOptions = new(); //PositionOptions positionOptions = new PositionOptions();

            _configuration.GetSection(PositionOptions.Position).Bind(positionOptions);

            Debug.WriteLine(positionOptions.Name);
            Debug.WriteLine(positionOptions.Title);

            return View();

            //return Content($"Title: {positionOptions.Title} \n" +
            //    $"Name: {positionOptions.Name} ");
        }

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
