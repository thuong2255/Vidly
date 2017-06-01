using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using  System.Data.Entity;
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
        public ActionResult Create(NewCustomerViewModel viewModel)
        {
            return View();
        }

    }
}