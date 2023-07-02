using Microsoft.AspNetCore.Identity;
using STD.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Data.Models
{
    public class User : IdentityUser
    {
        public UserStatus Active { get; set; }
        public DateTime TimeRegister { get; set; }

        [Key]
        public string  IDNumber { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string GrandFatherName { get; set; }
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public string PersonalImageUrl { get; set; }
        [Required]
        public string IdImageUrl { get; set; }

        public string Student { get; set; }
        public GenderType Gender { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public DateTime DOB { get; set; }
    }

}
