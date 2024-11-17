using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Repository
{
    public class MovieRepository: Repository<Movie> ,IMovieRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<Category> GetGenres()
        {
            return dbContext.Categories.ToList();
        }
        public List<Cinema> GetCinemas()
        {
            return dbContext.Cinemas.ToList();
        }
        public List<Actor> GetActors()
        {
            return dbContext.Actors.ToList();
        }


        public void AddMovieActor(ActorMovie actorMovie)
        {
            dbContext.ActorMovies.Add(actorMovie);
        }
        public void RemoveMovieActor(ActorMovie actorMovie)
        {
            dbContext.ActorMovies.Remove(actorMovie);
        }

        public Movie Select(int actorId)
        {
            return dbContext.Movies
                  .Include(a => a.ActorMovies)
                  .ThenInclude(am => am.Actor)
                  .FirstOrDefault(a => a.Id == actorId);
        }
    }
}
