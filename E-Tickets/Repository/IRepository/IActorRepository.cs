using E_Tickets.Models;

namespace E_Tickets.Repository.IRepository
{
    public interface IActorRepository:IRepository<Actor>
    {
        public List<Movie> GetMovies();
        public void AddMovieActor(ActorMovie actorMovie);
        public void RemoveMovieActor(ActorMovie actorMovie);
        public Actor Select(int actorId);

    }
}
