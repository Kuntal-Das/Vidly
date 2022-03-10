using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public static MoviesViewModel moviesVM = new MoviesViewModel();
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GET /Movies
        public IActionResult Index()
        {
            moviesVM.Movies = _context.Movies.Include(m => m.Genere).ToList();
            return View(moviesVM);
        }

        //GET /Movies/Details
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genere).SingleOrDefault(movie => movie.Id == id);
            return View(movie);
        }

        //Action Results:
        // ViewResult           -> View() 
        // PartialViewResult    -> PartialView()
        // ContentResult        -> Content()
        // RedirectResult       -> Redirect()
        // RedirectRouteResult  -> RedirectToAction()
        // JsonResult           -> Json()
        // FileResult           -> File()
        // HttpNotFoundResult   -> HttpNotFound() or NotFound()
        // EmptyResult          

        //GET: Movies/Random
        //public IActionResult Random()
        //{
        //    Movie movie = new() { Name = "Dune 2021" };
        //    var customers = new List<Customer> {
        //        new Customer{Name="Customer 1"},
        //        new Customer{Name="Customer 2"},
        //    };

        //    var vm = new RandomMovieViewModel()
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };
        //    return View(vm);

        //    //might case prob later for parameter passing to the controller
        //    //ViewData["Movie"] = movie; 
        //    //ViewBag.Movie = movie;
        //    //return View();

        //    //return new ViewResult();

        //    //return Content("Hellow World!");

        //    //return NotFound();

        //    //return new EmptyResult();

        //    //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        //}

        ////GET: movies/edit/{id}
        //public IActionResult Edit(int id)
        //{
        //    return Content($"id = {id}");
        //}

        //public IActionResult Index(int pageIndex = 1, string sortBy = "name")
        //{
        //    //if (pageIndex.HasValue) pageIndex = 1;

        //    //if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "name";

        //    return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        //}

        //[Route("movies/released/{year:regex(2015|2016)}/{month:regex(\\d{{2}}):range(1,12)}")]
        //public IActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content($"{year}/{month}");
        //}
    }
}
