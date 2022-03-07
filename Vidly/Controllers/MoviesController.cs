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
    }
}
