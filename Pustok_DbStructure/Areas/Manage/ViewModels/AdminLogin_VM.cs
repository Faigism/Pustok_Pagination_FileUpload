using System.ComponentModel.DataAnnotations;

namespace Pustok_DbStructure.Areas.Manage.ViewModels
{
    public class AdminLogin_VM
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(25)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
