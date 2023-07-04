using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Core.ViewModels
{
    public class StudentViewModel
    {
        public int id { get; set; }
        public UserViewModel User { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string Level { get; set; }

        public byte LastYearPercent { get; set; }

    }
}
