using E_Tickets.Data;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Controllers
{
    public class CRUDController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddMovie()
        {
            var Movies = Context.Movies.ToList();
            return View(Movies);
        }
        [HttpPost]
        public IActionResult AddMovie(Movie movie, IFormFile PhotoUrl)
        {
            if (PhotoUrl.Length > 0)
            {
                var fileName = PhotoUrl.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\images", fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    PhotoUrl.CopyTo(stream);
                }
                movie.ImgUrl = fileName;
            }
            Context.Movies.Add(movie);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult EditMovie(int movieId)
        {
            var movie = Context.Movies.Find(movieId);
            var Genre = Context.Categories.ToList();
            ViewData["Genres"] = Genre;
            return View(movie);
        }
        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            Context.Movies.Update(movie);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult DeleteMovie(Movie movie)
        {
            Context.Movies.Remove(movie);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
      

        //////////////////////////////////////////////////////////////////////////////////////////////////////
      

        public IActionResult Actors()
        {
            var Actors = Context.Actors.ToList();
            return View(Actors);
        }
        public IActionResult AddActor()
        {
            ViewBag.Movies = Context.Movies.ToList();
            return View();
        }
        [HttpPost]
        [HttpPost]
        public IActionResult AddActor(Actor actor, IFormFile ProfilePictrue, List<int> SelectedMovies)
        {
            if (ProfilePictrue != null && ProfilePictrue.Length > 0)
            {
                
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfilePictrue.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Actors", fileName);

              
                using (var stream = System.IO.File.Create(filePath))
                {
                    ProfilePictrue.CopyTo(stream);
                }

             
                actor.ProfilePictrue = fileName;
            }

         
            Context.Actors.Add(actor);
            Context.SaveChanges();

           
            foreach (var movieId in SelectedMovies)
            {
                var actorMovie = new ActorMovie
                {
                    ActorId = actor.Id,
                    MovieId = movieId
                };
                Context.ActorMovies.Add(actorMovie);
            }

         
            Context.SaveChanges();

            TempData["Add"] = "Actor successfully added!";
            return RedirectToAction("Actors");
        }

        [HttpGet]
        public IActionResult EditActor(int id)
        {
            var actor = Context.Actors
                .Include(a => a.ActorMovies)
                .ThenInclude(am => am.Movie)
                .FirstOrDefault(a => a.Id == id);

            if (actor == null)
            {
                return NotFound();
            }

            var selectedMovieIds = actor.ActorMovies.Select(am => am.MovieId).ToList();

            ViewBag.Movies = Context.Movies
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name,
                    Selected = selectedMovieIds.Contains(m.Id) 
                }).ToList();

            return View(actor);
        }

        [HttpPost]
        public IActionResult EditActor(Actor actor, IFormFile ProfilePictrue, List<int> SelectedMovies)
        {
            var existingActor = Context.Actors
                .Include(a => a.ActorMovies)
                .FirstOrDefault(a => a.Id == actor.Id);

            if (existingActor == null)
            {
                return NotFound();
            }

         
            existingActor.FirstName = actor.FirstName;
            existingActor.LastName = actor.LastName;
            existingActor.Bio = actor.Bio;
            existingActor.News = actor.News;

          
            if (ProfilePictrue != null && ProfilePictrue.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfilePictrue.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Actors", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    ProfilePictrue.CopyTo(stream);
                }

                if (!string.IsNullOrEmpty(existingActor.ProfilePictrue))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Actors", existingActor.ProfilePictrue);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                existingActor.ProfilePictrue = fileName;
            }

            var existingMovieIds = existingActor.ActorMovies.Select(am => am.MovieId).ToList();

            foreach (var actorMovie in existingActor.ActorMovies.ToList())
            {
                if (!SelectedMovies.Contains(actorMovie.MovieId))
                {
                    Context.ActorMovies.Remove(actorMovie);
                }
            }

            foreach (var movieId in SelectedMovies)
            {
                if (!existingMovieIds.Contains(movieId))
                {
                    Context.ActorMovies.Add(new ActorMovie
                    {
                        ActorId = existingActor.Id,
                        MovieId = movieId
                    });
                }
            }

            Context.SaveChanges();

            TempData["Edit"] = "Actor successfully updated!";
            return RedirectToAction("Actors");
        }

    

    public IActionResult DeleteActor(Actor actor)
        {
            Context.Actors.Remove(actor);
            Context.SaveChanges();
            return RedirectToAction("Actors");
        }

    }
}
