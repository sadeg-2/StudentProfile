using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Data.Models
{
    public class Student
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Level { get; set; }

        public byte LastYearPercent { get; set; }

    }
}
