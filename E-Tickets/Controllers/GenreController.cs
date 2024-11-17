using E_Tickets.Models;
using E_Tickets.Repository;
using E_Tickets.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace E_Tickets.Controllers
{
    public class GenreController : Controller
    {
       // CategoryRepository Genre = new CategoryRepository();
        ICategoryRepository Genre;
        public GenreController(ICategoryRepository Genre)
        {
            this.Genre = Genre;
        }
        public IActionResult Index()
        {
            var genre = Genre.Get();
            return View(genre);
        }
        [HttpGet]
        public IActionResult AddGenre()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddGenre(Category category)
        {
            Genre.Create(category);
            Genre.Commit();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
          var genre =  Genre.GetOne( expression: e=>e.Id== id);
          return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            Genre.Edit(category);
            Genre.Commit();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Category category)
        {

            
            Genre.Delete(category);
            Genre.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
