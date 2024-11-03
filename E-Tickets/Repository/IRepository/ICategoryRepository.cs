using E_Tickets.Models;

namespace E_Tickets.Repository.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();

        Category GetById(int Id);

        void CreateNew(Category Category);
      
        void Edit(Category Category);

        void Delete(Category Category);


        void Commit();

    }
}
