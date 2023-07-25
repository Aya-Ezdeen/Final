using System.ComponentModel.DataAnnotations;

namespace Final.web.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = " البريد الالكتروني")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "كلمة المرور ")]
        public string Password { get; set; }
    }
}
