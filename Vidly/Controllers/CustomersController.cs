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
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }


        //GET /Customers
        public IActionResult Index()
        {
            CustomersViewModel customersVM = new CustomersViewModel()
            {
                Customers = _context.Customers.Include(c => c.MembershipType).ToList()
            };
            return View(customersVM);
        }

        //GET /Customers/Details
        public IActionResult Details(int id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(cus => cus.Id == id);
            return View(customer);
        }

        //GET /Customers/New
        public IActionResult New()
        {
            var newCustomerVM = new NewCustomerViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(newCustomerVM);
        }

        //POST /Customers/Create
        [HttpPost]
        public IActionResult Create(NewCustomerViewModel vm)
        {
            _context.Customers.Add(vm.Customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
