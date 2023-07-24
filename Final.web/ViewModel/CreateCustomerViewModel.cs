using Final.web.Enums;
using System.ComponentModel.DataAnnotations;

namespace Final.web.ViewModel
{
    public class CreateCustomerViewModel
    {
        [Required]
        [Display(Name = " اسم المستخدم")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name =" البريد الالكتروني")]
        public string Email{get; set;}
       
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "كلمة المرور ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "تاكيد كلمة المرور ")]
        public string ConfirmPassword { get; set; }

        public UserType userType { get; set; }
    }
}
