using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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
        public IActionResult Random()
        {
            Movie movie = new() { Name = "Dune 2021" };

            //return View(movie);
            //return new ViewResult();
            //return Content("Hellow World!");
            //return NotFound();

            //return new EmptyResult();

            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        //GET: movies/edit/{id}
        public IActionResult Edit(int id)
        {
            return Content($"id = {id}");
        }

        public IActionResult Index(int pageIndex = 1, string sortBy = "name")
        {
            //if (pageIndex.HasValue) pageIndex = 1;

            //if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "name";

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        [Route("movies/released/{year:regex(2015|2016)}/{month:regex(\\d{{2}}):range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }
    }
}
