using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Repository
{
    public class CinemaRepository: ICinemaRepository
    {
      //  ApplicationDbContext dbContext = new ApplicationDbContext();
        private readonly ApplicationDbContext dbContext;

        public CinemaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Cinema> GetAll(string? expression = null)
        {
            return expression == null ? dbContext.Cinemas.ToList() : dbContext.Cinemas.Include(expression).ToList();
        }
        public List<Movie> GetMovies()
        {
            return dbContext.Movies.ToList();
        }
        public Cinema GetById(int CinemaId)
        {
            return dbContext.Cinemas.FirstOrDefault(c => c.Id == CinemaId);
        }

        public void CreateNew(Cinema Cinema)
        {
            dbContext.Cinemas.Add(Cinema);
        }

        public void Edit(Cinema Cinema)
        {
            dbContext.Cinemas.Update(Cinema);
        }

        public void Delete(Cinema Cinema)
        {
            dbContext.Cinemas.Remove(Cinema);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
     
    }
}
