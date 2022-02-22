using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission4.Models;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FilmContext dbContext { get; set; }

        public HomeController(ILogger<HomeController> logger, FilmContext fc)
        {
            _logger = logger;
            dbContext = fc;
        }

        public IActionResult Index()
        {
            var films = dbContext.Responses.ToList();

            return View(films);
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddFilm()
        {
            ViewBag.Ratings = dbContext.Rating.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddFilm(Film f)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(f);
                dbContext.SaveChanges();

                return View("Confirmation");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int filmid)
        {
            ViewBag.Ratings = dbContext.Rating.ToList();

            var application = dbContext.Responses.Single(x => x.FilmID == filmid);

            return View("AddFilm", application);
        }

        [HttpPost]
        public IActionResult Edit(Film f)
        {
            if(ModelState.IsValid)
            {
                dbContext.Update(f);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("AddFilm");
            }

           
        }

        [HttpGet]
        public IActionResult DeleteFilm(int filmid)
        {
            var application = dbContext.Responses.Single(x => x.FilmID == filmid);

            return View(application);
        }

        [HttpPost]
        public IActionResult DeleteFilm(Film f)
        {
            dbContext.Responses.Remove(f);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
