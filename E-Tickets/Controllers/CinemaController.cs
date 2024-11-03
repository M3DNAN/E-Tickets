using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository;
using E_Tickets.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Controllers
{
    public class CinemaController : Controller
    {
       //ApplicationDbContext context  = new ApplicationDbContext();
       //CinemaRepository CinemaRepository = new CinemaRepository();

        ICinemaRepository CinemaRepository;
        public CinemaController(ICinemaRepository CinemaRepository)
        {
            this.CinemaRepository = CinemaRepository;
        }
        public IActionResult Index()
        {
            var Cinema = CinemaRepository.GetAll("Movies");

            return View(Cinema);
        }

        [HttpGet]
        public IActionResult AddCinema()
        {
            ViewBag.Movies = CinemaRepository.GetMovies();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCinema(Cinema Cinema, IFormFile CinemaLogo)
        {

            if (CinemaLogo != null && CinemaLogo.Length > 0)
            {

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(CinemaLogo.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Cinemas", fileName);


                using (var stream = System.IO.File.Create(filePath))
                {
                    CinemaLogo.CopyTo(stream);
                }


                Cinema.CinemaLogo = fileName;
            }
            CinemaRepository.CreateNew(Cinema);
            CinemaRepository.Commit();
            TempData["Add"] = "Actor successfully added!";

            return RedirectToAction(nameof(Index));
        
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var Cinema = CinemaRepository.GetById(Id);
  
                return View(Cinema);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cinema cinema, IFormFile? CinemaLogoFile)
        {
            if (id != cinema.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // If a new image is uploaded
                    if (CinemaLogoFile != null)
                    {
                        // Generate a unique file name
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(CinemaLogoFile.FileName);

                        // Hardcoded path to save the image (adjust as necessary)
                        string uploadPath = "wwwroot\\images\\Cinemas";

                        // Ensure the directory exists
                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        // Combine the path and filename
                        string filePath = Path.Combine(uploadPath, fileName);

                        // Save the file to the specified path
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            CinemaLogoFile.CopyTo(fileStream);
                        }

                        // Update the CinemaLogo property with the relative path (for use in the views)
                        cinema.CinemaLogo = "wwwroot\\images\\Cinemas" + fileName;
                    }

                    // Update cinema
                    CinemaRepository.Edit(cinema);
                    CinemaRepository.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (CinemaRepository.GetById(cinema.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        

    }

        public IActionResult DeleteCinema(Cinema cinema)
        {

            //var cinema =  CinemaRepository.GetById(CinemaId);
            CinemaRepository.Delete(cinema);
            CinemaRepository.Commit();
            return RedirectToAction(nameof(Index));
        }

    }
}
