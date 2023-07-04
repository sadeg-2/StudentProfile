using STD.Core.Dtos.Helpers;
using STD.Core.ViewModels;

namespace STD.Infrastructure.Services.Users
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserDto dto);
        Task<string> UpdateAsync(UpdateUserDto dto);
        Task<string> DeleteAsync(string id);
        Task<UpdateUserDto> GetAsync(string id);
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        UserViewModel GetUserByUsername(string username);
        List<User> GetAllData();
        Task<ProfileViewModel> GetUserById(string id);
        User GetUserByUsernames(string username);
    }

}
