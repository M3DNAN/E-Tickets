using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository.IRepository;

namespace E_Tickets.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        //ApplicationDbContext dbContext = new ApplicationDbContext();

        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }
        public Category GetById(int Id)
        {
            return dbContext.Categories.FirstOrDefault(c => c.Id == Id);
        }

        public void CreateNew(Category Category)
        {
            dbContext.Categories.Add(Category);
        }

        public void Edit(Category Category)
        {
            dbContext.Categories.Update(Category);
        }

        public void Delete(Category Category)
        {
            dbContext.Categories.Remove(Category);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
   
    }
}
