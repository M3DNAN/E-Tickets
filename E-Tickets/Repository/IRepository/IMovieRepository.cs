using E_Tickets.Models;

namespace E_Tickets.Repository.IRepository
{
    public interface IMovieRepository
    {
        List<Movie> GetAll(string? expression = null);

        Movie GetById(int MovieId);

        void CreateNew(Movie Movie);
        List<Category> GetGenres();
        List<Cinema> GetCinemas();
        List<Actor> GetActors();
        void Edit(Movie Movie);

        void Delete(Movie Movie);

        void AddMovieActor(ActorMovie actorMovie);
        void RemoveMovieActor(ActorMovie actorMovie);
        
        Movie Select(int actorId);

        void Commit();
    }
}
