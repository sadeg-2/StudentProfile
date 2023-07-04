using STD.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Core.ViewModels
{
    public class ProfileViewModel
    {
        public UserStatus Active { get; set; }
        public DateTime TimeRegister { get; set; }
        public string Email { get; set; }
        public string IDNumber { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }
        public string PersonalImageUrl { get; set; }
        public string IdImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public GenderType Gender { get; set; }
        public string Address { get; set; }
        public bool isDelete { get; set; }

    }
}
