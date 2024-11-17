using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Cinema Logo")]
        public string CinemaLogo { get; set; }
        public string Address { get; set; }


        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
