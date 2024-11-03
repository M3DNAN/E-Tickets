using E_Tickets.Models;

namespace E_Tickets.Repository.IRepository
{
    public interface IActorRepository
    {
        List<Actor> GetAll(string? expression = null);

        Actor GetById(int ActorId);

        void CreateNew(Actor Actor);
        List<Movie> GetMovies();
        void Edit(Actor Actor);

        void Delete(Actor Actor);

        void AddMovieActor(ActorMovie actorMovie);
        void RemoveMovieActor(ActorMovie actorMovie);

        Actor Select(int actorId);

        void Commit();
    }
}
