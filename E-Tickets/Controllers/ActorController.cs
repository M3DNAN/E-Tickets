using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository.IRepository;
using E_Tickets.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Controllers
{
    public class ActorController : Controller
    {
       // ApplicationDbContext Context = new ApplicationDbContext();
        IActorRepository ActorRepo;
        public ActorController(IActorRepository ActorRepo)
        {
            this.ActorRepo = ActorRepo;
        }
        public IActionResult Actors()
        {
            var Actors = ActorRepo.Get();
            return View(Actors);
        }
        public IActionResult AddActor()
        {
            ViewBag.Movies = ActorRepo.GetMovies();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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


            ActorRepo.Create(actor);
            ActorRepo.Commit();



            foreach (var movieId in SelectedMovies)
            {
                var actorMovie = new ActorMovie
                {
                    ActorId = actor.Id,  
                    MovieId = movieId
                };
                ActorRepo.AddMovieActor(actorMovie);
            }


            ActorRepo.Commit();

            TempData["Add"] = "Actor successfully added!";
            return RedirectToAction("Actors");
        }
        [HttpGet]
        public IActionResult EditActor(int id)
        {
         
            var actor = ActorRepo.Select(id);
            if (actor == null)
            {
                return NotFound();
            }

            var selectedMovieIds = actor.ActorMovies.Select(am => am.MovieId).ToList();

            ViewBag.Movies = ActorRepo.GetMovies()
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name,
                    Selected = selectedMovieIds.Contains(m.Id) 
                }).ToList();

            return View(actor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditActor(Actor actor, IFormFile ProfilePictrue, List<int> SelectedMovies)
        {
   

            var existingActor = ActorRepo.Select(actor.Id);

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
                    ActorRepo.RemoveMovieActor(actorMovie);
                }
            }

            foreach (var movieId in SelectedMovies)
            {
                if (!existingMovieIds.Contains(movieId))
                {
                    ActorRepo.AddMovieActor
                    (new ActorMovie
                    {
                        ActorId = existingActor.Id,
                        MovieId = movieId
                    });
                }
            }

            ActorRepo.Commit();

            TempData["Edit"] = "Actor successfully updated!";
            return RedirectToAction("Actors");
        }
    public IActionResult DeleteActor(Actor actor)
        {
            ActorRepo.Delete(actor);
            ActorRepo.Commit();
            return RedirectToAction("Actors");
        }

    }
}
