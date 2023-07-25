using Final.web.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Final.web.ViewModel
{
    public class UpdateProductViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "اسم المنتج")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "سعر المنتج ")]
        public float Price { get; set; }


        public string WorkerId { get; set; }


        [Required]
        [Display(Name = "صورة المنتج")]
        public IFormFile ImageUrl { get; set; }

        [Required]
        [Display(Name = "وصف المنتج")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "موقع المتجر  ")]
        public GoverType Governorate { get; set; }


        [Required]
        [Display(Name = " فئة المنتجات  ")]
        public SectionType Section { get; set; }


    }
}
