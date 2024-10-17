using E_Tickets.Data;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_Tickets.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext() ;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? Id)
        {
            var Movies = Context.Movies.Include(e=>e.Category).Include(e=>e.Cinema) .ToList();
            ViewBag.Genre = Context.Categories.ToList();
            if (Id.HasValue && Id > 0)
            {
                Movies = Movies.Where(m => m.CategoryId == Id.Value).ToList();
            }
            return View(Movies);
        }
        public IActionResult Welcome()
        {
            return View();
        }
        public IActionResult MovieDetails(int id , string? search)
        {
            var Movies = Context.Movies.Include(m => m.ActorMovies).ThenInclude(m => m.Actor)  
        .Include(m => m.Cinema)  
        .Include(m => m.Category)  
        .FirstOrDefault(m => m.Id == id);

   

            return View(Movies);
        }
        public IActionResult GenreDetails(string? search)
        {
            var Genre = Context.Categories.ToList();
       
            return View(Genre);
        }
        public IActionResult ActorDetails(int id, string? search)
        {
            var Actors = Context.Actors
                .Include(e => e.ActorMovies)
                .ThenInclude(e => e.Movie)
                .ThenInclude(m => m.Category)
                .Where(e => e.Id == id)
                .FirstOrDefault();
         
            return View(Actors);
        }
        public IActionResult CinemaDetails(int id, string? search)
        {
            var Cinema = Context.Cinemas.Include(e=>e.Movies).ThenInclude(m => m.Category).Where(e=>e.Id==id).FirstOrDefault();
        

            return View(Cinema);
        }
        public IActionResult Search(string query)
        {
          
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index"); 
            }

            var movie = Context.Movies.FirstOrDefault(m => m.Name.Contains(query) || m.Description.Contains(query));

            if (movie != null)
            {
                return RedirectToAction("Details", new { id = movie.Id, type = "movie" });
            }

            var actor = Context.Actors.FirstOrDefault(a => a.FirstName.Contains(query) || a.LastName.Contains(query));
            if (actor != null)
            {
                return RedirectToAction("Details", new { id = actor.Id, type = "actor" });
            }

           
            var genre = Context.Categories.FirstOrDefault(g => g.Name.Contains(query));
            if (genre != null)
            {
                return RedirectToAction("Details", new { id = genre.Id, type = "genre" });
            }

           
            var cinema = Context.Cinemas.FirstOrDefault(c => c.Name.Contains(query) || c.Address.Contains(query));
            if (cinema != null)
            {
                return RedirectToAction("Details", new { id = cinema.Id, type = "cinema" });
            }

            return RedirectToAction("Index"); 
        }


        public IActionResult Details(int id, string type)
        {
            switch (type.ToLower())
            {
                case "movie":
                    var movie = Context.Movies.Include(m => m.ActorMovies).ThenInclude(m => m.Actor)
        .Include(m => m.Cinema)
        .Include(m => m.Category).FirstOrDefault(m => m.Id == id);
                    if (movie != null) return View("MovieDetails", movie);
                    break;

                case "actor":
                    var actor = Context.Actors
                .Include(e => e.ActorMovies)
                .ThenInclude(e => e.Movie)
                .ThenInclude(m => m.Category).FirstOrDefault(a => a.Id == id);
                    if (actor != null) return View("ActorDetails", actor);
                    break;

                case "genre":
                    var genre = Context.Categories.FirstOrDefault(g => g.Id == id);
                    if (genre != null) return View("GenreDetails", genre);
                    break;

                case "cinema":
                    var cinema = Context.Cinemas.Include(e => e.Movies).ThenInclude(m => m.Category).FirstOrDefault(c => c.Id == id);
                    if (cinema != null) return View("CinemaDetails", cinema);
                    break;
            }

            return NotFound(); // Handle the case where no details are found
        }


















        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
