using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public static CustomersViewModel customersVM = new CustomersViewModel();

        //GET /Customers
        public IActionResult Index()
        {
            customersVM.Customers = new()
            {
                new Customer { Id = 1, Name = "customer 1" },
                new Customer { Id = 2, Name = "customer 2" }
            };
            return View(customersVM);
        }

        //GET /Customers/Details
        public IActionResult Details(int id)
        {
            var customer = customersVM.Customers.SingleOrDefault(c => c.Id == id);
            return View(customer);
        }
    }
}
