using System.ComponentModel.DataAnnotations;

namespace E_Tickets.ViewModel
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
