namespace STD.Infrastructure.Services.User
{
    public interface IUserService
    {
        Task<string> CreateAsync(CreateUserDto dto);
        Task<string> UpdateAsync(UpdateUserDto dto);
        Task<string> DeleteAsync(string id);
        Task<string> GetAsync(string id);
        Task<ResponseDto> GetAll();
    }

}
