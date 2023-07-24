using System.ComponentModel.DataAnnotations;

namespace Final.web.Models
{
    public class Customers
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

    }
}
