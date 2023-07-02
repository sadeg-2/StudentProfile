namespace STD.Infrastructure.Services.Student
{
    public interface IStudentService
    {
        Task<string> CreateAsync(CreateStudentDto dto);
        Task<string> UpdateAsync(UpdateStudentDto dto);
        Task<string> DeleteAsync(string id);
        Task<string> GetAsync(string id);
        Task<ResponseDto> GetAll();
    }
}
