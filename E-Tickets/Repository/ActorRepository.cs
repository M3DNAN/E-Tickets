using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Repository
{
    public class ActorRepository: Repository<Actor> , IActorRepository
    {




        private readonly ApplicationDbContext dbContext;

        public ActorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Movie> GetMovies()
        {
            return dbContext.Movies.ToList();
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

