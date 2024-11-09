using E_Tickets.Data;
using E_Tickets.Models;
using E_Tickets.Repository;
using E_Tickets.Repository.IRepository;
using E_Tickets.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;

namespace E_Tickets.Controllers
{
    public class BookingController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();

        private readonly IBookingRepository Booking;
        private readonly UserManager<ApplicationUser> userManager;

        public BookingController(IBookingRepository Booking, UserManager<ApplicationUser> userManager)
        {
            this.Booking = Booking;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var appUser = userManager.GetUserId(User);

            var shoppingCarts = Booking.Get([e=>e.Movie , e=>e.applicationUser], e => e.ApplicationUserId == appUser);

            ViewBag.TotalPrice = shoppingCarts.Sum(e => e.Movie.Price * e.NumOfTickets);

            return View(shoppingCarts);
        }

        public IActionResult BookATicket(int MovieId, int NumOfTickets=1)
        {
            var appUser = userManager.GetUserId(User);

            if (appUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var shoppingCarts = Booking.Get([e => e.Movie, e => e.applicationUser], e => e.ApplicationUserId == appUser);

            Booking Book = new Booking()
            {
                NumOfTickets = NumOfTickets,
                MovieId = MovieId,
                ApplicationUserId = appUser
            };
            Order Order = new Order()
            {
                NumOfTickets = NumOfTickets,
                MovieId = MovieId,
                ApplicationUserId = appUser,
                OrderDate = DateTime.Now,
                Status = "Completed",
                TotalPrice = (decimal)shoppingCarts.Sum(e => e.Movie.Price * e.NumOfTickets)
            };
            var BookDB = Booking.GetOne(expression: e => e.MovieId == MovieId && e.ApplicationUserId == appUser);

            if (BookDB == null)
                Booking.Create(Book);
            else
                BookDB.NumOfTickets += NumOfTickets;

            Booking.Commit();

            TempData["success"] = "Add product to cart successfully";
            Context.Orders.Add(Order);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Increment(int MovieId)
        {
            var appUser = userManager.GetUserId(User);
            var BookDB = Booking.GetOne(expression: e => e.MovieId == MovieId && e.ApplicationUserId == appUser);

            if (BookDB != null)
            {
                BookDB.NumOfTickets++;
            }
            Booking.Commit();

            return RedirectToAction("Index");
        }

        public IActionResult Decrement(int MovieId)
        {
            var appUser = userManager.GetUserId(User);
            var BookDB = Booking.GetOne(expression: e => e.MovieId == MovieId && e.ApplicationUserId == appUser);

            if (BookDB != null)
            {
                BookDB.NumOfTickets--;
                if (BookDB.NumOfTickets == 0)
                {
                    Booking.Delete(BookDB);

                }
            }
            Booking.Commit();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int MovieId)
        {
            var appUser = userManager.GetUserId(User);
            var BookDB = Booking.GetOne(expression: e => e.MovieId == MovieId && e.ApplicationUserId == appUser);

            if (BookDB != null)
            {
                Booking.Delete(BookDB);
            }
            Booking.Commit();

            return RedirectToAction("Index");
        }
        public IActionResult Pay()
        {
            var appUser = userManager.GetUserId(User);
            var BookDBs = Booking.Get(includeProps: [e => e.Movie], expression: e => e.ApplicationUserId == appUser).ToList();

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = $"{Request.Scheme}://{Request.Host}/Booking/success",
                CancelUrl = $"{Request.Scheme}://{Request.Host}/Booking/index",
            };

            foreach (var item in BookDBs)
            {
                var result = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "egp",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Movie.Name,
                        },
                        UnitAmount = (long)item.Movie.Price * 100,
                    },
                    Quantity = item.NumOfTickets,
                };
                options.LineItems.Add(result);
            }

            var service = new SessionService();
            var session = service.Create(options);

            return Redirect(session.Url);
        }
        public IActionResult Success(decimal amount, string transactionId)
        {
            ViewBag.PaymentAmount = amount;
            ViewBag.TransactionId = transactionId;
            return View("Success");
        }
        public async Task<IActionResult> OrderHistory()
        {
            var userId = userManager.GetUserId(User);
            var orders = await Context.Orders
                .Include(o => o.Movie)
                .Where(o => o.ApplicationUserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }

    }
}

