using STD.Core.Dtos.Helpers;

namespace STD.Infrastructure.Services.Students
{
    public interface IStudentService
    {
        Task<Student> CreateAsync(CreateStudentDto dto);
        Task<string> UpdateAsync(UpdateStudentDto dto);
        Task<string> DeleteAsync(int id);
        Task<UpdateStudentDto> GetAsync(int id);
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        List<Student> GetAllData();

    }
}
