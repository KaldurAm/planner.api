using System.ComponentModel.DataAnnotations;

namespace Planner.Shared.Models
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(55)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string ConfirmPassword { get; set; }
    }
}
