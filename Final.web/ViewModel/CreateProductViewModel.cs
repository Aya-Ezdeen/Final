using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Final.web.ViewModel
{
    public class CreateProductViewModel
    {

        [Required]
        [Display(Name = "اسم المنتج")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "سعر المنتج ")]
        public float Price { get; set; }

        
        public int WorkerId { get; set; }


        [Required]
        [Display(Name = "صورة المنتج")]
        public IFormFile ImageUrl { get; set; }

        [Required]
        [Display(Name = "وصف المنتج")]
        public string Description { get; set; }

    }
}
