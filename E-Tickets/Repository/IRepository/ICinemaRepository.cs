using E_Tickets.Models;

namespace E_Tickets.Repository.IRepository
{
    public interface ICinemaRepository
    {
        List<Cinema> GetAll(string? expression = null);

        Cinema GetById(int CinemaId);

        void CreateNew(Cinema Cinema);
           List<Movie> GetMovies();
        void Edit(Cinema Cinema);

        void Delete(Cinema Cinema);
        void Commit();
    }
}
