using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Tickets.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();
        IMovieRepository MovieRepo;
        public MovieController(IMovieRepository MovieRepo)
        {
            this.MovieRepo = MovieRepo;
        }

        public IActionResult Index()
        {
            var movie = MovieRepo.GetAll();
            return View(movie);
        }

        public IActionResult AddMovie()
        {
            
            ViewBag.Actor = MovieRepo.GetActors();
            ViewBag.Genre = MovieRepo.GetGenres();
            ViewBag.Cinema= MovieRepo.GetCinemas();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovie(Movie movie, IFormFile ImgUrl, List<int> SelectedMovies)
        {
            if (ImgUrl != null && ImgUrl.Length > 0)
            {

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Posters", fileName);


                using (var stream = System.IO.File.Create(filePath))
                {
                    ImgUrl.CopyTo(stream);
                }


                movie.ImgUrl = fileName;
            }


            MovieRepo.CreateNew(movie);
            MovieRepo.Commit();
       
			foreach (var actorId in SelectedMovies)
			{
				var actorMovie = new ActorMovie
				{
					MovieId = movie.Id,
					ActorId = actorId
				};
				MovieRepo.AddMovieActor(actorMovie);
			}

			MovieRepo.Commit();

            TempData["Add"] = "Actor successfully added!";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            ViewBag.Actor = MovieRepo.GetActors();
            ViewBag.Genre = MovieRepo.GetGenres();
            ViewBag.Cinema = MovieRepo.GetCinemas();
            var movie = MovieRepo.Select(id);
			if (movie == null)
			{
				return NotFound();
			}

			var selectedMovieIds = movie.ActorMovies.Select(am => am.MovieId).ToList();

			ViewBag.Movies = MovieRepo.GetAll()
				.Select(m => new SelectListItem
				{
					Value = m.Id.ToString(),
					Text = m.Name,
					Selected = selectedMovieIds.Contains(m.Id)
				}).ToList();

			return View(movie);
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMovie(Movie movie, IFormFile ImgUrl, List<int> SelectedMovies)
        {
			var existingMovie = MovieRepo.Select(movie.Id);

			if (existingMovie == null)
			{
				return NotFound();
			}


			existingMovie.Name = movie.Name;
			existingMovie.Description = movie.Description;
			existingMovie.Price = movie.Price;
			existingMovie.StartDate = movie.StartDate;
			existingMovie.EndDate = movie.EndDate;
			existingMovie.CategoryId = movie.CategoryId;
			existingMovie.CinemaId = movie.CinemaId;


			if (ImgUrl != null && ImgUrl.Length > 0)
			{
				var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Posters", fileName);

				using (var stream = System.IO.File.Create(filePath))
				{
					ImgUrl.CopyTo(stream);
				}

				if (!string.IsNullOrEmpty(existingMovie.ImgUrl))
				{
					var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Posters", existingMovie.ImgUrl);
					if (System.IO.File.Exists(oldFilePath))
					{
						System.IO.File.Delete(oldFilePath);
					}
				}

				existingMovie.ImgUrl = fileName;
			}

			var existingActorId = existingMovie.ActorMovies.Select(am => am.ActorId).ToList();

			foreach (var actorMovie in existingMovie.ActorMovies.ToList())
			{
				if (!SelectedMovies.Contains(actorMovie.ActorId))
				{
					MovieRepo.RemoveMovieActor(actorMovie);
				}
			}

			foreach (var movieId in SelectedMovies)
			{
				if (!existingActorId.Contains(movieId))
				{
					MovieRepo.AddMovieActor
					(new ActorMovie
					{
                        MovieId = existingMovie.Id,
                        ActorId = movieId
					});
				}
			}

			MovieRepo.Commit();

			TempData["Edit"] = "Actor successfully updated!";
			return RedirectToAction("index");
		}

	
        public IActionResult DeleteMovie(Movie movie)
        {
            MovieRepo.Delete(movie);
            MovieRepo.Commit();
            return RedirectToAction("Index");
        }
    }
}
