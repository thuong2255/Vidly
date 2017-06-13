using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers.AsEnumerable());
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult New()
        {
            var memberShipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MemberShipTypes = memberShipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                return View("New", viewModel);
            }
            else
            {
                if (customer.Id == 0)
                    _context.Customers.Add(customer);
                else
                {
                    var customerDb = _context.Customers.Single(c => c.Id == customer.Id);
                    customerDb.Name = customer.Name;
                    customerDb.BirthDate = customer.BirthDate;
                    customerDb.MemberShipType = customer.MemberShipType;
                    customerDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                    customerDb.MemberShipTypeId = customer.MemberShipTypeId;
                }

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };
            return View("New", viewModel);
        }

    }
}