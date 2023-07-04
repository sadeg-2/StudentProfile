using STD.Core.Dots.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace STD.Core.Dots.Student
{
    public class CreateStudentDto
    {
        public CreateUserDto user { get; set; }
        [Display(Name = "تاريخ التسجيل")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
        [Required]
        [Display(Name ="المستوى الدراسي")]
        public string Level { get; set; }
        [Required]
        [Display(Name = " معدل في اخر سنة")]
        public byte LastYearPercent { get; set; }
    }
}
