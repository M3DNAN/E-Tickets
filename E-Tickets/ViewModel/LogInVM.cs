using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.ViewModel
{
    public class LogInVM
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
      //  public IEnumerable<AuthenticationScheme> Schemes { get; set; }

    }
}
