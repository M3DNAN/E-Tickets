using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Order
    {
       
        public int Id { get; set; } 

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int NumOfTickets { get; set; }

        public DateTime OrderDate { get; set; } 

        public decimal TotalPrice { get; set; } 

        public string Status { get; set; } 
    }
}
