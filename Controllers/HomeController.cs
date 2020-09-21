using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojodachi.Models;

using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Fullness = Dachi.Fullness;
            ViewBag.Happiness = Dachi.Happiness;
            ViewBag.Meals = Dachi.Meals;
            ViewBag.Energy = Dachi.Energy;
            ViewBag.Photo = Dachi.Photo;
            return View();
        }
        [HttpPost("Action")]
        public IActionResult Action(string activity)
        {
            switch (activity)
            {
                case "feed":
                {
                    Dachi.Feed();
                    break;
                }
                case "play":
                {
                    Dachi.Play();
                    break;
                }
                case "work":
                {
                    Dachi.Work();
                    break;
                }
                case "sleep":
                {
                    Dachi.Sleep();
                    break;
                }
            }
            return RedirectToAction("Index");
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
