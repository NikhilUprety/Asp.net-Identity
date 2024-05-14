using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.Models
{
    public class AppUser: IdentityUser  
    {

        [MaxLength(100)]
        [Required]
        public int Name { get; set; }
        public string Address { get; set;}
    }
}
