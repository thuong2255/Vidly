using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie   
            {
                Id = 1,
                Name = "Titanic",
            };
            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Nguyễn Văn A"},
                new Customer {Id = 2, Name = "Nguyễn Văn B"},
                new Customer {Id = 3, Name = "Nguyễn Văn C"}

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);

        }

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        ////movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace((sortBy)))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex = {0}&sortBy = {1}", pageIndex, sortBy));
        //}

        //[Route("movies/released/{year}/{month}")]
        //public ActionResult ReleaseDate(int year, int month)
        //{
        //    return Content(string.Format("{0}/{1}", year, month));
        //}
    }



}