using Final.web.Enums;
using System.ComponentModel.DataAnnotations;

namespace Final.web.ViewModel
{
    public class UpdateWorkerViewModel
    {
        public string Id { get; set; }
        [Required]

        [Display(Name = " اسم المستخدم")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = " البريد الالكتروني")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "رقم الهوية  ")]
        public string IDNumber { get; set; }

        [Required]
        [Display(Name = "موقع المتجر  ")]
        public GoverType Governorate { get; set; }


        [Required]
        [Display(Name = " فئة المنتجات  ")]
        public SectionType Section { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        [Display(Name = "رقم الهاتف  ")]
        public string PhoneNumber { get; set; }

        public UserType userType { get; set; }


        //[DataType(DataType.Password)]
        //[Required]
        //[Display(Name = "كلمة المرور ")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Required]
        //[Display(Name = "تاكيد كلمة المرور ")]
        public string ConfirmPassword { get; set; }
    }
}
