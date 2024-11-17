using E_Tickets.Models;

namespace E_Tickets.Repository.IRepository
{
    public interface IMovieRepository :IRepository<Movie>
    {

        List<Category> GetGenres();
        List<Cinema> GetCinemas();
        List<Actor> GetActors();


        void AddMovieActor(ActorMovie actorMovie);
        void RemoveMovieActor(ActorMovie actorMovie);
        
        Movie Select(int actorId);

    }
}
