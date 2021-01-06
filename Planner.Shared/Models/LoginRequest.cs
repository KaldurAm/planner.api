using System.ComponentModel.DataAnnotations;

namespace Planner.Shared.Models
{
    public class LoginRequest
    {
        [Required]
        [StringLength(55)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
