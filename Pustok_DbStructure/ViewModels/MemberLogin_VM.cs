using System.ComponentModel.DataAnnotations;

namespace Pustok_DbStructure.ViewModels
{
    public class MemberLogin_VM
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
