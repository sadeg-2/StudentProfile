using Microsoft.AspNetCore.Http;
using STD.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace STD.Core.Dots.User
{
    public class CreateUserDto
    {
        [Required]
        [Display(Name = " رقم الهوية")]
        public string IDNumber { get; set; }

        [Required]
        [Display(Name = "الاسم الاول")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "اسم الاب")]
        public string FatherName { get; set; }
        [Required]
        [Display(Name = "اسم الجد")]
        public string GrandFatherName { get; set; }
        [Required]
        [Display(Name = "اسم العائلة")]
        public string FamilyName { get; set; }

        [Display(Name = " الجنس")]
        public GenderType Gender { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "البريد الالكتروني ")]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        [Display(Name = "رقم الجوال ")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "الصورة الشخصية")]
        public IFormFile PersonalImageUrl { get; set; }
        [Display(Name = "صورة الهوية")]
        public IFormFile IdImageUrl { get; set; }

        [Display(Name = "تاريخ الميلاد")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [Required]
        [Display(Name =" الموقع ")]
        public string Address { get; set; }
    }
}
