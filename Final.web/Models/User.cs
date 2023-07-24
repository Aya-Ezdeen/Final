
using Final.web.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Final.web.Models
{
    public class User:IdentityUser

    {
        public bool IsDelete { get; set; }
        [Required]

        public UserType UserType { get; set; }
        [Required]

        public string IDNumber { get; set; }
        [Required]

        public GoverType Governorate { get; set; }
        [Required]

        public SectionType Section { get; set; }

        
       
        public List<Product> Products { get; set; }

    }
}
