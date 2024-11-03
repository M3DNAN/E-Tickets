using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Repository
{
    public class ActorRepository: IActorRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ActorRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Actor> GetAll(string? expression = null)
        {
            return expression == null ? dbContext.Actors.ToList() : dbContext.Actors.Include(expression).ToList();
        }
        public List<Movie> GetMovies()
        {
            return dbContext.Movies.ToList();
        }
        public Actor GetById(int ActorId)
        {
            return dbContext.Actors.FirstOrDefault(c => c.Id == ActorId);
        }

        public void CreateNew(Actor Actor)
        {
            dbContext.Actors.Add(Actor);
        }

        public void Edit(Actor Actor)
        {
            dbContext.Actors.Update(Actor);
        }

        public void Delete(Actor Actor)
        {
            dbContext.Actors.Remove(Actor);
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
        
        public Actor Select(int actorId)
        {
            return dbContext.Actors
                  .Include(a => a.ActorMovies)
                  .ThenInclude(am => am.Movie)
                  .FirstOrDefault(a => a.Id == actorId);
        }


    }
}

