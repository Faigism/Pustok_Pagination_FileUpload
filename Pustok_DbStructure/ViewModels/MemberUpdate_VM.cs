﻿using System.ComponentModel.DataAnnotations;

namespace Pustok_DbStructure.ViewModels
{
    public class MemberUpdate_VM
    {
        [Required]
        [MaxLength(35)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(25)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [MaxLength(25)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [MaxLength(25)]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }
    }
}