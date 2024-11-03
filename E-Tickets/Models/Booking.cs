using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Tickets.Models
{
    [PrimaryKey("MovieId", "ApplicationUserId")]
    public class Booking
    {
       public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        [ValidateNever]
        public Movie Movie { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser applicationUser { get; set; }
       public string ApplicationUserId { get; set; }

        [Required]
        [Range(1, 1000)]
        public int NumOfTickets { get; set; }
        public List<string> SelectedSeats { get; set; } = new List<string>();
    }
}
