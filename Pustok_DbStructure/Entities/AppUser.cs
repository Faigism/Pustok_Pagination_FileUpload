using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Pustok_DbStructure.Entities
{
    public class AppUser:IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
    }
}
