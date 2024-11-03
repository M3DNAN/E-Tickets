using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Repository
{
    public class MovieRepository: IMovieRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MovieRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Movie> GetAll(string? expression = null)
        {
            return expression == null ? dbContext.Movies.ToList() : dbContext.Movies.Include(expression).ToList();
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
        public Movie GetById(int MovieId)
        {
            return dbContext.Movies.FirstOrDefault(c => c.Id == MovieId);
        }

        public void CreateNew(Movie Movie)
        {
            dbContext.Movies.Add(Movie);
        }

        public void Edit(Movie Movie)
        {
            dbContext.Movies.Update(Movie);
        }

        public void Delete(Movie Movie)
        {
            dbContext.Movies.Remove(Movie);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
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
