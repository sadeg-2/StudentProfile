using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Infrastructure.Services.Student
{
    public class StudentService : IStudentService
    {
        public Task<string> CreateAsync(CreateStudentDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(UpdateStudentDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
