using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewMVC_HW6;

namespace NewMVC_HW6.Controllers
{
    public class TopMoviesController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: TopMovies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Director);
            var top10 = movies.OrderByDescending(m =>m.gross ).Take(10);
            return View(top10.ToList());
        }

        // GET: TopMovies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
    }
}