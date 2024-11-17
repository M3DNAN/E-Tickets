using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
