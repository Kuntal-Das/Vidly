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
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
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

        public IActionResult New()
        {
            var vm = new MovieFormViewModel()
            {
                Generes = _context.Generes.ToList()
            };
            return View("MovieForm", vm);
        }


        public IActionResult Edit(int id)
        {
            MovieFormViewModel movieFormVm = new MovieFormViewModel()
            {
                Generes = _context.Generes,
                Movie = _context.Movies
                .Include(m => m.Genere)
                .SingleOrDefault(m => m.Id == id)
            };

            if (movieFormVm.Movie != null)
                return View("MovieForm", movieFormVm);

            return NotFound();
        }


        [HttpPost]
        public IActionResult Save(MovieFormViewModel moviesFormVM)
        {
            if (moviesFormVM.Movie.Id == 0)
            {
                _context.Movies.Add(moviesFormVM.Movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(m => m.Id == moviesFormVM.Movie.Id);

                if (MovieInDb.Name != moviesFormVM.Movie.Name)
                    MovieInDb.Name = moviesFormVM.Movie.Name;

                if (MovieInDb.ReleaseDate != moviesFormVM.Movie.ReleaseDate)
                    MovieInDb.ReleaseDate = moviesFormVM.Movie.ReleaseDate;

                if (MovieInDb.Stock != moviesFormVM.Movie.Stock)
                    MovieInDb.Stock = moviesFormVM.Movie.Stock;

                if (MovieInDb.GenereId != moviesFormVM.Movie.GenereId)
                    MovieInDb.GenereId = moviesFormVM.Movie.GenereId;

                if (MovieInDb.DateAdded != moviesFormVM.Movie.DateAdded)
                    MovieInDb.DateAdded = moviesFormVM.Movie.DateAdded;

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
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

        // custom Routing with Attribute Routing 
        //[Route("movies/released/{year:regex(2015|2016)}/{month:regex(\\d{{2}}):range(1,12)}")]
        //public IActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content($"{year}/{month}");
        //}
    }
}
