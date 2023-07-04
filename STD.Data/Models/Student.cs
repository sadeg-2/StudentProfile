using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Data.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Level { get; set; }

        public byte LastYearPercent { get; set; }

        public bool isDelete { get; set; }

    }
}
