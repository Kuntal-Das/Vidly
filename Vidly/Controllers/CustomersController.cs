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

            if (customer != null) return View(customer);

            return NotFound();
        }

        //GET /Customers/New
        public IActionResult New()
        {
            var CustomerFormVM = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipTypes
            };
            return View("CustomerForm", CustomerFormVM);
        }

        //POST /Customers/Save
        [HttpPost]
        public IActionResult Save(CustomerFormViewModel customerVM)
        {
            if (customerVM.Customer.Id == 0)
            {
                _context.Customers.Add(customerVM.Customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customerVM.Customer.Id);

                //Mapper.Map(vm.Customer, customerInDb);
                if (customerInDb.Name != customerVM.Customer.Name)
                    customerInDb.Name = customerVM.Customer.Name;

                if (customerInDb.DOB != customerVM.Customer.DOB)
                    customerInDb.DOB = customerVM.Customer.DOB;

                if (customerInDb.MembershipTypeId != customerVM.Customer.MembershipTypeId)
                    customerInDb.MembershipTypeId = customerVM.Customer.MembershipTypeId;

                if (customerInDb.IsSubscribedToNewsLetter != customerVM.Customer.IsSubscribedToNewsLetter)
                    customerInDb.IsSubscribedToNewsLetter = customerVM.Customer.IsSubscribedToNewsLetter;
            }


            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var CustomerFormVM = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(cus => cus.Id == id)
            };

            if (CustomerFormVM.Customer != null) return View("CustomerForm", CustomerFormVM);

            return NotFound();
        }


    }
}
