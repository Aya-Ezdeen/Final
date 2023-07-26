using Final.web.Enums;
using System.ComponentModel.DataAnnotations;

namespace Final.web.Models
{
    public class Product
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
   
        [Required]
        public string ImageUrl { get; set; }
      

        [Required]
        public string Description { get; set; }

        public string StoreId { get; set; }
        public User Store { get; set; }


        [Required]

        public GoverType Governorate { get; set; }
        [Required]

        public SectionType Section { get; set; }

     
         public bool IsDelete { get; set; }
    }
}
