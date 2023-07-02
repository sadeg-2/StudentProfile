using STD.Core.Dots.User;
using STD.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STD.Infrastructure.Services.User
{
    public class UserService : IUserService
    {
        public Task<string> CreateAsync(CreateUserDto dto)
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

        public Task<string> UpdateAsync(UpdateUserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
