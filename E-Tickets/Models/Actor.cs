using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Bio { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictrue { get; set; }
        public string News { get; set; }

        public ICollection<ActorMovie> ActorMovies { get; set; } = new List<ActorMovie>();

    }
}
