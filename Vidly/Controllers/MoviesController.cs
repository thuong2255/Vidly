using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new NewMovieViewModel
            {
                Genres = genre
            };

            return View(viewModel);
        }

        public ActionResult Create(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieDb = _context.Movies.Single(x => x.Id == movie.Id);
                movieDb.Name = movie.Name;
                movieDb.Genre = movie.Genre;
                movieDb.ReleaseDate = movie.ReleaseDate;
                movieDb.DateAdded = movie.DateAdded;
                movieDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            var modelView = new NewMovieViewModel
            {
                Movie =  movie,
                Genres = _context.Genres.ToList()
            };
            return View("New", modelView);
        }
    }

}