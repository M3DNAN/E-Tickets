using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository.IRepository;

namespace E_Tickets.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
